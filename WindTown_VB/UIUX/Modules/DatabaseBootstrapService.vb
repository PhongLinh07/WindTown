Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Data.SqlClient

Public Class DatabaseBootstrapResult
    Public Property IsSuccess As Boolean
    Public Property WasCreated As Boolean
    Public Property Message As String
    Public Property SelectedDataSource As String
    Public Property ConnectionString As String
End Class

Public NotInheritable Class DatabaseBootstrapService
    Private Shared ReadOnly _sync As New Object()
    Private Shared _initialized As Boolean = False
    Private Shared _lastResult As DatabaseBootstrapResult = Nothing

    Private Const DatabaseName As String = "wind_town"
    Private Shared ReadOnly CoreTables As String() = {"department", "job", "employee", "contract", "position", "account"}

    Private Shared ReadOnly CandidateDataSources As String() = {
        ".",
        "localhost",
        ".\\SQLEXPRESS",
        "(local)"
    }

    Public Shared Function EnsureReady() As DatabaseBootstrapResult
        SyncLock _sync
            If _initialized AndAlso _lastResult IsNot Nothing Then
                Return _lastResult
            End If

            Dim scriptPath = ResolveSqlScriptPath()
            If String.IsNullOrWhiteSpace(scriptPath) OrElse Not File.Exists(scriptPath) Then
                _lastResult = New DatabaseBootstrapResult With {
                    .IsSuccess = False,
                    .Message = "Khong tim thay file khoi tao DB: 1_Documents/db_json.sql hoac create_db.sql"
                }
                Return _lastResult
            End If

            Dim lastError As String = String.Empty

            Dim userConn = ConnectionSettingsStore.TryLoadConnectionString()
            If Not String.IsNullOrWhiteSpace(userConn) Then
                Try
                    If IsSchemaInitialized(userConn) Then
                        DatabaseConfig.Database.SetConnectionString(userConn)
                        EnsureDefaultAdminCredentials(userConn)
                        _lastResult = New DatabaseBootstrapResult With {
                            .IsSuccess = True,
                            .WasCreated = False,
                            .Message = "Ket noi theo cau hinh da luu (formSystem).",
                            .SelectedDataSource = "(user)",
                            .ConnectionString = userConn
                        }
                        _initialized = True
                        Return _lastResult
                    End If
                Catch ex As Exception
                    AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] User connection FAIL - {ex.Message}")
                End Try
            End If

            For Each dataSource In CandidateDataSources
                Dim masterConnStr = BuildConnectionString(dataSource, "master")
                Try
                    Using masterConn As New SqlConnection(masterConnStr)
                        masterConn.Open()

                        Dim dbExists = DatabaseExists(masterConn)
                        Dim wasCreated As Boolean = False

                        If Not dbExists Then
                            CreateDatabase(masterConn)
                            wasCreated = True
                            AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Tao moi database '{DatabaseName}' tren datasource '{dataSource}'.")
                        End If

                        Dim targetConnStr = BuildConnectionString(dataSource, DatabaseName)
                        Dim needInitialize As Boolean = wasCreated OrElse Not IsSchemaInitialized(targetConnStr)

                        If needInitialize Then
                            ExecuteSqlScript(masterConnStr, scriptPath, DatabaseName)
                            AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Da chay script khoi tao schema/demo cho datasource '{dataSource}'.")
                        End If

                        If Not IsSchemaInitialized(targetConnStr) Then
                            Throw New Exception("Khoi tao schema khong thanh cong: thieu bang loi.")
                        End If

                        DatabaseConfig.Database.SetConnectionString(targetConnStr)
                        EnsureDefaultAdminCredentials(targetConnStr)

                        _lastResult = New DatabaseBootstrapResult With {
                            .IsSuccess = True,
                            .WasCreated = wasCreated,
                            .Message = BuildSuccessMessage(wasCreated, needInitialize),
                            .SelectedDataSource = dataSource,
                            .ConnectionString = targetConnStr
                        }
                        _initialized = True
                        Return _lastResult
                    End Using
                Catch ex As Exception
                    lastError = $"DataSource '{dataSource}': {ex.Message}"
                    AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Bootstrap FAIL - {lastError}")
                End Try
            Next

            _lastResult = New DatabaseBootstrapResult With {
                .IsSuccess = False,
                .Message = "Khong the ket noi/tao database. " & lastError
            }
            Return _lastResult
        End SyncLock
    End Function

    Private Shared Function BuildSuccessMessage(wasCreated As Boolean, needInitialize As Boolean) As String
        If wasCreated Then
            Return "Da tao moi database va khoi tao bang/du lieu demo."
        End If

        If needInitialize Then
            Return "Database da ton tai nhung thieu schema. Da khoi tao bang/du lieu demo."
        End If

        Return "Ket noi database thanh cong."
    End Function

    Private Shared Function BuildConnectionString(dataSource As String, catalog As String) As String
        Return $"Data Source={dataSource};Initial Catalog={catalog};Integrated Security=True;TrustServerCertificate=True;Connection Timeout=5"
    End Function

    Private Shared Function DatabaseExists(conn As SqlConnection) As Boolean
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT CASE WHEN DB_ID(@name) IS NULL THEN 0 ELSE 1 END"
            cmd.Parameters.AddWithValue("@name", DatabaseName)
            Dim result = Convert.ToInt32(cmd.ExecuteScalar())
            Return result = 1
        End Using
    End Function

    Private Shared Sub CreateDatabase(conn As SqlConnection)
        Using cmd = conn.CreateCommand()
            cmd.CommandText = $"CREATE DATABASE [{DatabaseName}]"
            cmd.CommandTimeout = 30
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Function IsSchemaInitialized(targetConnStr As String) As Boolean
        Try
            Using conn As New SqlConnection(targetConnStr)
                conn.Open()

                For Each tableName In CoreTables
                    Using cmd = conn.CreateCommand()
                        cmd.CommandText = "SELECT CASE WHEN OBJECT_ID(@obj, 'U') IS NULL THEN 0 ELSE 1 END"
                        cmd.Parameters.AddWithValue("@obj", "dbo." & tableName)
                        Dim existsFlag = Convert.ToInt32(cmd.ExecuteScalar())
                        If existsFlag = 0 Then
                            Return False
                        End If
                    End Using
                Next

                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Shared Sub ExecuteSqlScript(masterConnStr As String, scriptPath As String, dbName As String)
        Dim sql = File.ReadAllText(scriptPath, Encoding.UTF8)
        Dim batches = SplitSqlBatches(sql)

        Using conn As New SqlConnection(masterConnStr)
            conn.Open()

            For Each rawBatch In batches
                Dim batch = NormalizeBatch(rawBatch, dbName)
                If String.IsNullOrWhiteSpace(batch) Then Continue For

                Using cmd = conn.CreateCommand()
                    cmd.CommandText = batch
                    cmd.CommandTimeout = 120
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Dim preview = rawBatch.Trim()
                        If preview.Length > 180 Then preview = preview.Substring(0, 180) & "..."
                        Throw New Exception("Loi khi chay SQL batch: " & preview & " | " & ex.Message)
                    End Try
                End Using
            Next
        End Using
    End Sub

    Private Shared Function SplitSqlBatches(sql As String) As List(Of String)
        Dim results As New List(Of String)()
        Dim sb As New StringBuilder()
        Dim lines = sql.Replace(vbCrLf, vbLf).Split(ControlChars.Lf)

        For Each line In lines
            If Regex.IsMatch(line, "^\s*GO\s*(--.*)?$", RegexOptions.IgnoreCase) Then
                Dim batch = sb.ToString().Trim()
                If batch <> String.Empty Then
                    results.Add(batch)
                End If
                sb.Clear()
            Else
                sb.AppendLine(line)
            End If
        Next

        Dim tail = sb.ToString().Trim()
        If tail <> String.Empty Then
            results.Add(tail)
        End If

        Return results
    End Function

    Private Shared Function NormalizeBatch(batch As String, dbName As String) As String
        Dim normalized = batch.Trim()
        If normalized = String.Empty Then Return String.Empty

        If Regex.IsMatch(normalized, "^\s*USE\s+", RegexOptions.IgnoreCase) Then
            Return String.Empty
        End If

        If Regex.IsMatch(normalized, "DROP\s+DATABASE\s+\[?" & Regex.Escape(dbName) & "\]?", RegexOptions.IgnoreCase) Then
            Return String.Empty
        End If

        If Regex.IsMatch(normalized, "CREATE\s+DATABASE\s+\[?" & Regex.Escape(dbName) & "\]?", RegexOptions.IgnoreCase) Then
            Return String.Empty
        End If

        Return $"USE [{dbName}];{vbCrLf}{normalized}"
    End Function

    Private Shared Function ResolveSqlScriptPath() As String
        Dim baseDir = AppDomain.CurrentDomain.BaseDirectory

        Dim candidates As String() = {
            Path.Combine(baseDir, "1_Documents", "db_json.sql"),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "1_Documents", "db_json.sql")),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "1_Documents", "db_json.sql")),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "1_Documents", "db_json.sql")),
            Path.Combine(baseDir, "1_Documents", "create_db.sql"),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "1_Documents", "create_db.sql")),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "1_Documents", "create_db.sql")),
            Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "1_Documents", "create_db.sql"))
        }

        Return candidates.FirstOrDefault(Function(path) File.Exists(path))
    End Function

    Private Shared Function ColumnExists(conn As SqlConnection, tableName As String, columnName As String) As Boolean
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = N'dbo' AND TABLE_NAME = @t AND COLUMN_NAME = @c"
            cmd.Parameters.AddWithValue("@t", tableName)
            cmd.Parameters.AddWithValue("@c", columnName)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ''' <summary>Đảm bảo có thể đăng nhập admin / 123456 (schema quan hệ hoặc JSON legacy).</summary>
    Private Shared Sub EnsureDefaultAdminCredentials(targetConnStr As String)
        Try
            Using conn As New SqlConnection(targetConnStr)
                conn.Open()
                Dim hasUser = ColumnExists(conn, "account", "user")
                Dim hasDatas = ColumnExists(conn, "account", "datas")

                If hasUser Then
                    Using cmd = conn.CreateCommand()
                        cmd.CommandTimeout = 30
                        cmd.CommandText =
                            "IF EXISTS (SELECT 1 FROM dbo.account WHERE [user] = N'admin') " &
                            "UPDATE dbo.account SET [password] = N'123456', role = 1, status = 1 WHERE [user] = N'admin'; " &
                            "ELSE IF EXISTS (SELECT 1 FROM dbo.account WHERE employee_id = 1) " &
                            "UPDATE dbo.account SET [user] = N'admin', [password] = N'123456', role = 1, status = 1 WHERE id = (SELECT TOP 1 id FROM dbo.account WHERE employee_id = 1 ORDER BY id); " &
                            "ELSE IF EXISTS (SELECT 1 FROM dbo.employee WHERE id = 1) " &
                            "INSERT INTO dbo.account (employee_id, [user], [password], role, last_active, note, status) " &
                            "VALUES (1, N'admin', N'123456', 1, SYSUTCDATETIME(), N'', 1);"
                        cmd.ExecuteNonQuery()
                    End Using
                ElseIf hasDatas Then
                    Using cmd = conn.CreateCommand()
                        cmd.CommandTimeout = 30
                        cmd.CommandText =
                            "UPDATE dbo.account SET datas = JSON_MODIFY(datas, '$.password', '123456') " &
                            "WHERE JSON_VALUE(datas, '$.user') = N'admin';"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch
        End Try
    End Sub

    Private Shared Sub AppendLog(message As String)
        Try
            Dim logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
            If Not Directory.Exists(logDir) Then
                Directory.CreateDirectory(logDir)
            End If

            Dim logPath = Path.Combine(logDir, "db_bootstrap.log")
            File.AppendAllText(logPath, message & Environment.NewLine)
        Catch
            ' Khong de log lam gián đoạn luồng bootstrap
        End Try
    End Sub
End Class
