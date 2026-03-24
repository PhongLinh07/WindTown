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
        ".\SQLEXPRESS",
        "(local)"
    }

    ' ── Event để UI lắng nghe tiến trình ──────────────────────────────────────
    Public Shared Event ProgressChanged(message As String, percent As Integer)

    Public Shared Function EnsureReady() As DatabaseBootstrapResult
        SyncLock _sync
            If _initialized AndAlso _lastResult IsNot Nothing Then
                Return _lastResult
            End If

            RaiseEvent ProgressChanged("Đang tìm file khởi tạo database...", 5)

            Dim scriptPath = ResolveSqlScriptPath()
            If String.IsNullOrWhiteSpace(scriptPath) OrElse Not File.Exists(scriptPath) Then
                _lastResult = New DatabaseBootstrapResult With {
                    .IsSuccess = False,
                    .Message = "Không tìm thấy file khởi tạo DB: 1_Documents/db_json.sql hoặc create_db.sql"
                }
                Return _lastResult
            End If

            Dim lastError As String = String.Empty

            ' ── Bước 1: thử chuỗi kết nối đã lưu ─────────────────────────────
            RaiseEvent ProgressChanged("Kiểm tra cấu hình kết nối đã lưu...", 15)
            Dim userConn = ConnectionSettingsStore.TryLoadConnectionString()
            If Not String.IsNullOrWhiteSpace(userConn) Then
                Try
                    If IsSchemaInitialized(userConn) Then
                        DatabaseConfig.Database.SetConnectionString(userConn)
                        EnsureDefaultAdminCredentials(userConn)
                        RaiseEvent ProgressChanged("Kết nối thành công từ cấu hình đã lưu.", 100)
                        _lastResult = New DatabaseBootstrapResult With {
                            .IsSuccess = True,
                            .WasCreated = False,
                            .Message = "Kết nối theo cấu hình đã lưu.",
                            .SelectedDataSource = "(saved)",
                            .ConnectionString = userConn
                        }
                        _initialized = True
                        Return _lastResult
                    End If
                Catch ex As Exception
                    AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Saved connection FAIL - {ex.Message}")
                End Try
            End If

            ' ── Bước 2: dò từng DataSource ────────────────────────────────────
            Dim totalSources = CandidateDataSources.Length
            For i As Integer = 0 To totalSources - 1
                Dim dataSource = CandidateDataSources(i)
                Dim pct = 20 + CInt((i / totalSources) * 60)
                RaiseEvent ProgressChanged($"Thử kết nối: {dataSource}...", pct)

                Dim masterConnStr = BuildConnectionString(dataSource, "master")
                Try
                    Using masterConn As New SqlConnection(masterConnStr)
                        masterConn.Open()

                        Dim dbExists = DatabaseExists(masterConn)
                        Dim wasCreated As Boolean = False

                        If Not dbExists Then
                            RaiseEvent ProgressChanged($"Tạo database '{DatabaseName}' trên {dataSource}...", pct + 5)
                            CreateDatabase(masterConn)
                            wasCreated = True
                            AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Tạo mới database '{DatabaseName}' trên datasource '{dataSource}'.")
                        End If

                        Dim targetConnStr = BuildConnectionString(dataSource, DatabaseName)
                        Dim needInitialize As Boolean = wasCreated OrElse Not IsSchemaInitialized(targetConnStr)

                        If needInitialize Then
                            RaiseEvent ProgressChanged("Đang khởi tạo schema và dữ liệu mẫu...", pct + 10)
                            ExecuteSqlScript(masterConnStr, scriptPath, DatabaseName)
                            AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Đã chạy script khởi tạo schema cho datasource '{dataSource}'.")
                        End If

                        If Not IsSchemaInitialized(targetConnStr) Then
                            Throw New Exception("Khởi tạo schema không thành công.")
                        End If

                        DatabaseConfig.Database.SetConnectionString(targetConnStr)
                        EnsureDefaultAdminCredentials(targetConnStr)

                        ' ✅ Lưu lại chuỗi kết nối để lần sau dùng luôn
                        ConnectionSettingsStore.SaveConnectionString(targetConnStr)
                        AppendLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Đã lưu connection string vào: {ConnectionSettingsStore.FilePath}")

                        RaiseEvent ProgressChanged("Hoàn tất! Đang khởi động ứng dụng...", 100)

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
                .Message = "Không thể kết nối hoặc tạo database. " & lastError
            }
            Return _lastResult
        End SyncLock
    End Function

    ''' <summary>Xóa cache — dùng khi user thay đổi cấu hình kết nối.</summary>
    Public Shared Sub Reset()
        SyncLock _sync
            _initialized = False
            _lastResult = Nothing
        End SyncLock
    End Sub

    Private Shared Function BuildSuccessMessage(wasCreated As Boolean, needInitialize As Boolean) As String
        If wasCreated Then Return "Đã tạo mới database và khởi tạo bảng/dữ liệu mẫu."
        If needInitialize Then Return "Database đã tồn tại nhưng thiếu schema. Đã khởi tạo bảng/dữ liệu mẫu."
        Return "Kết nối database thành công."
    End Function

    Private Shared Function BuildConnectionString(dataSource As String, catalog As String) As String
        Return $"Data Source={dataSource};Initial Catalog={catalog};Integrated Security=True;TrustServerCertificate=True;Connection Timeout=5"
    End Function

    Private Shared Function DatabaseExists(conn As SqlConnection) As Boolean
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT CASE WHEN DB_ID(@name) IS NULL THEN 0 ELSE 1 END"
            cmd.Parameters.AddWithValue("@name", DatabaseName)
            Return Convert.ToInt32(cmd.ExecuteScalar()) = 1
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
                        If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then Return False
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
                        Throw New Exception("Lỗi SQL batch: " & preview & " | " & ex.Message)
                    End Try
                End Using
            Next
        End Using
    End Sub

    Private Shared Function SplitSqlBatches(sql As String) As List(Of String)
        Dim results As New List(Of String)()
        Dim sb As New StringBuilder()
        For Each line In sql.Replace(vbCrLf, vbLf).Split(ControlChars.Lf)
            If Regex.IsMatch(line, "^\s*GO\s*(--.*)?$", RegexOptions.IgnoreCase) Then
                Dim batch = sb.ToString().Trim()
                If batch <> String.Empty Then results.Add(batch)
                sb.Clear()
            Else
                sb.AppendLine(line)
            End If
        Next
        Dim tail = sb.ToString().Trim()
        If tail <> String.Empty Then results.Add(tail)
        Return results
    End Function

    Private Shared Function NormalizeBatch(batch As String, dbName As String) As String
        Dim n = batch.Trim()
        If n = String.Empty Then Return String.Empty
        If Regex.IsMatch(n, "^\s*USE\s+", RegexOptions.IgnoreCase) Then Return String.Empty
        If Regex.IsMatch(n, "DROP\s+DATABASE\s+\[?" & Regex.Escape(dbName) & "\]?", RegexOptions.IgnoreCase) Then Return String.Empty
        If Regex.IsMatch(n, "CREATE\s+DATABASE\s+\[?" & Regex.Escape(dbName) & "\]?", RegexOptions.IgnoreCase) Then Return String.Empty
        Return $"USE [{dbName}];{vbCrLf}{n}"
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
        Return candidates.FirstOrDefault(Function(p) File.Exists(p))
    End Function

    Private Shared Function ColumnExists(conn As SqlConnection, tableName As String, columnName As String) As Boolean
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = N'dbo' AND TABLE_NAME = @t AND COLUMN_NAME = @c"
            cmd.Parameters.AddWithValue("@t", tableName)
            cmd.Parameters.AddWithValue("@c", columnName)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

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
            If Not Directory.Exists(logDir) Then Directory.CreateDirectory(logDir)
            File.AppendAllText(Path.Combine(logDir, "db_bootstrap.log"), message & Environment.NewLine)
        Catch
        End Try
    End Sub
End Class