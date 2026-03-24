Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Data.SqlClient

''' <summary>Kết quả trả về từ các thao tác quản lý database.</summary>
Public Class DbOperationResult
    Public Property IsSuccess As Boolean
    Public Property Message As String
    Public Property Detail As String
End Class

''' <summary>
''' Service quản lý database: tạo rỗng, xóa, load dữ liệu, backup, đổi kết nối.
''' Tách biệt khỏi DatabaseBootstrapService để dùng độc lập từ DatabaseManagerForm.
''' </summary>
Public NotInheritable Class DatabaseManagerService

    Public Const DatabaseName As String = "wind_town"

    ' ── Tạo database rỗng (chỉ schema, không có dữ liệu mẫu) ─────────────────
    Public Shared Function CreateEmptyDatabase(connStr As String) As DbOperationResult
        Try
            Dim masterConn = SwapCatalog(connStr, "master")
            Using conn As New SqlConnection(masterConn)
                conn.Open()

                ' Kiểm tra đã tồn tại chưa
                Using chk = conn.CreateCommand()
                    chk.CommandText = "SELECT CASE WHEN DB_ID(@n) IS NULL THEN 0 ELSE 1 END"
                    chk.Parameters.AddWithValue("@n", DatabaseName)
                    If Convert.ToInt32(chk.ExecuteScalar()) = 1 Then
                        Return Fail($"Database '{DatabaseName}' đã tồn tại. Xóa trước nếu muốn tạo lại.")
                    End If
                End Using

                ' Tạo mới
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = $"CREATE DATABASE [{DatabaseName}]"
                    cmd.CommandTimeout = 30
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Chạy script schema (không chạy INSERT dữ liệu mẫu — dùng schema-only script nếu có)
            Dim scriptPath = ResolveSchemaScript()
            If String.IsNullOrWhiteSpace(scriptPath) Then
                Return Fail("Không tìm thấy file schema SQL (1_Documents/db_json.sql hoặc create_db.sql).")
            End If

            RunScript(masterConn, scriptPath, DatabaseName)

            ' Lưu kết nối
            Dim targetConn = SwapCatalog(connStr, DatabaseName)
            DatabaseConfig.Database.SetConnectionString(targetConn)
            ConnectionSettingsStore.SaveConnectionString(targetConn)

            Return OK($"Đã tạo database rỗng '{DatabaseName}' và khởi tạo schema thành công.", scriptPath)
        Catch ex As Exception
            Return Fail("Tạo database thất bại: " & ex.Message)
        End Try
    End Function

    ' ── Xóa database ──────────────────────────────────────────────────────────
    Public Shared Function DropDatabase(connStr As String) As DbOperationResult
        Try
            Dim masterConn = SwapCatalog(connStr, "master")
            Using conn As New SqlConnection(masterConn)
                conn.Open()

                Using chk = conn.CreateCommand()
                    chk.CommandText = "SELECT CASE WHEN DB_ID(@n) IS NULL THEN 0 ELSE 1 END"
                    chk.Parameters.AddWithValue("@n", DatabaseName)
                    If Convert.ToInt32(chk.ExecuteScalar()) = 0 Then
                        Return Fail($"Database '{DatabaseName}' không tồn tại.")
                    End If
                End Using

                ' Ngắt tất cả kết nối đang mở trước khi drop
                Using kick = conn.CreateCommand()
                    kick.CommandTimeout = 30
                    kick.CommandText =
                        $"ALTER DATABASE [{DatabaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " &
                        $"DROP DATABASE [{DatabaseName}];"
                    kick.ExecuteNonQuery()
                End Using
            End Using

            ' Xóa file lưu kết nối
            '  ConnectionSettingsStore.ClearSavedConnectionString()
            DatabaseBootstrapService.Reset()

            Return OK($"Đã xóa database '{DatabaseName}' thành công.")
        Catch ex As Exception
            Return Fail("Xóa database thất bại: " & ex.Message)
        End Try
    End Function

    ' ── Load dữ liệu từ file SQL ──────────────────────────────────────────────
    Public Shared Function LoadFromSqlFile(connStr As String, sqlFilePath As String) As DbOperationResult
        Try
            If Not File.Exists(sqlFilePath) Then
                Return Fail($"Không tìm thấy file: {sqlFilePath}")
            End If

            Dim masterConn = SwapCatalog(connStr, "master")
            RunScript(masterConn, sqlFilePath, DatabaseName)

            Return OK($"Đã load dữ liệu từ file thành công.", sqlFilePath)
        Catch ex As Exception
            Return Fail("Load dữ liệu thất bại: " & ex.Message)
        End Try
    End Function

    ' ── Backup database ra file .bak ──────────────────────────────────────────
    Public Shared Function BackupDatabase(connStr As String, backupPath As String) As DbOperationResult
        Try
            Dim masterConn = SwapCatalog(connStr, "master")

            ' Đảm bảo thư mục tồn tại
            Dim dir = Path.GetDirectoryName(backupPath)
            If Not String.IsNullOrWhiteSpace(dir) AndAlso Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            Using conn As New SqlConnection(masterConn)
                conn.Open()
                Using cmd = conn.CreateCommand()
                    cmd.CommandTimeout = 300
                    cmd.CommandText =
                        $"BACKUP DATABASE [{DatabaseName}] TO DISK = @path WITH FORMAT, INIT, COMPRESSION, STATS = 10"
                    cmd.Parameters.AddWithValue("@path", backupPath)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Dim size = New FileInfo(backupPath).Length
            Return OK($"Backup thành công ({FormatSize(size)}).", backupPath)
        Catch ex As Exception
            Return Fail("Backup thất bại: " & ex.Message)
        End Try
    End Function

    ' ── Kiểm tra kết nối ─────────────────────────────────────────────────────
    Public Shared Function TestConnection(connStr As String) As DbOperationResult
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "SELECT @@VERSION, DB_NAME(), SUSER_SNAME()"
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim ver = rdr.GetString(0).Split(vbCrLf)(0).Trim()
                            Dim db = rdr.GetString(1)
                            Dim user = rdr.GetString(2)
                            Return OK($"Kết nối thành công — DB: {db}, User: {user}", ver)
                        End If
                    End Using
                End Using
            End Using
            Return OK("Kết nối thành công.")
        Catch ex As Exception
            Return Fail("Kết nối thất bại: " & ex.Message)
        End Try
    End Function

    ' ── Đổi và lưu kết nối mới ───────────────────────────────────────────────
    Public Shared Function ApplyNewConnection(connStr As String) As DbOperationResult
        Dim test = TestConnection(connStr)
        If Not test.IsSuccess Then Return test

        DatabaseConfig.Database.SetConnectionString(connStr)
        ConnectionSettingsStore.SaveConnectionString(connStr)
        DatabaseBootstrapService.Reset()

        Return OK("Đã lưu và áp dụng chuỗi kết nối mới.", connStr)
    End Function

    ' ── Lấy thông tin database hiện tại ──────────────────────────────────────
    Public Shared Function GetDatabaseInfo(connStr As String) As Dictionary(Of String, String)
        Dim info As New Dictionary(Of String, String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText =
                        "SELECT " &
                        "  DB_NAME() AS db_name, " &
                        "  @@SERVERNAME AS server, " &
                        "  (SELECT SUM(size) * 8 / 1024 FROM sys.database_files WHERE type_desc = 'ROWS') AS size_mb, " &
                        "  (SELECT COUNT(*) FROM sys.tables WHERE type = 'U') AS table_count, " &
                        "  (SELECT SUM(row_count) FROM sys.dm_db_partition_stats WHERE index_id IN (0,1)) AS row_count"
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            info("Tên database") = rdr("db_name").ToString()
                            info("Server") = rdr("server").ToString()
                            info("Dung lượng") = rdr("size_mb").ToString() & " MB"
                            info("Số bảng") = rdr("table_count").ToString()
                            info("Tổng bản ghi") = rdr("row_count").ToString()
                        End If
                    End Using
                End Using
                info("File cấu hình") = ConnectionSettingsStore.FilePath
                info("Trạng thái") = "Kết nối"
            End Using
        Catch ex As Exception
            info("Lỗi") = ex.Message
            info("Trạng thái") = "Mất kết nối"
        End Try
        Return info
    End Function

#Region "Helpers"
    Private Shared Function SwapCatalog(connStr As String, catalog As String) As String
        Dim builder As New SqlConnectionStringBuilder(connStr)
        builder.InitialCatalog = catalog
        Return builder.ConnectionString
    End Function

    Private Shared Sub RunScript(masterConnStr As String, scriptPath As String, dbName As String)
        Dim sql = File.ReadAllText(scriptPath, Encoding.UTF8)
        Dim batches = SplitBatches(sql)

        Using conn As New SqlConnection(masterConnStr)
            conn.Open()
            For Each rawBatch In batches
                Dim batch = NormalizeBatch(rawBatch, dbName)
                If String.IsNullOrWhiteSpace(batch) Then Continue For
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = batch
                    cmd.CommandTimeout = 120
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub

    Private Shared Function SplitBatches(sql As String) As List(Of String)
        Dim results As New List(Of String)()
        Dim sb As New StringBuilder()
        For Each line In sql.Replace(vbCrLf, vbLf).Split(ControlChars.Lf)
            If Regex.IsMatch(line, "^\s*GO\s*(--.*)?$", RegexOptions.IgnoreCase) Then
                Dim b = sb.ToString().Trim()
                If b <> String.Empty Then results.Add(b)
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

    Private Shared Function ResolveSchemaScript() As String
        Dim baseDir = AppDomain.CurrentDomain.BaseDirectory
        Dim names = {"db_json.sql", "create_db.sql"}
        Dim depths = {0, 2, 3, 4}
        For Each name In names
            For Each d In depths
                Dim parts(d + 1) As String
                parts(0) = baseDir
                For i = 1 To d
                    parts(i) = ".."
                Next
                parts(d) = "1_Documents"
                parts(d + 1) = name
                Dim p = Path.GetFullPath(Path.Combine(parts))
                If File.Exists(p) Then Return p
            Next
        Next
        Return Nothing
    End Function

    Private Shared Function FormatSize(bytes As Long) As String
        If bytes > 1073741824 Then Return $"{bytes / 1073741824.0:F1} GB"
        If bytes > 1048576 Then Return $"{bytes / 1048576.0:F1} MB"
        Return $"{bytes / 1024.0:F0} KB"
    End Function

    Private Shared Function OK(msg As String, Optional detail As String = "") As DbOperationResult
        Return New DbOperationResult With {.IsSuccess = True, .Message = msg, .Detail = detail}
    End Function

    Private Shared Function Fail(msg As String, Optional detail As String = "") As DbOperationResult
        Return New DbOperationResult With {.IsSuccess = False, .Message = msg, .Detail = detail}
    End Function
#End Region
End Class