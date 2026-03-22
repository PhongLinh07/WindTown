Imports System.IO

''' <summary>Lưu/đọc chuỗi kết nối SQL Server do người dùng cấu hình (formSystem).</summary>
Public NotInheritable Class ConnectionSettingsStore

    Public Const RecommendedCatalog As String = "wind_town"

    Private Shared ReadOnly LockObj As New Object()

    Private Shared Function ConfigDirectory() As String
        Dim dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindTown")
        Return dir
    End Function

    Public Shared ReadOnly Property FilePath As String
        Get
            Return Path.Combine(ConfigDirectory(), "connection_string.txt")
        End Get
    End Property

    ''' <summary>Trả về Nothing nếu chưa lưu hoặc lỗi đọc.</summary>
    Public Shared Function TryLoadConnectionString() As String
        SyncLock LockObj
            Try
                Dim p = FilePath
                If Not File.Exists(p) Then Return Nothing
                Dim t = File.ReadAllText(p, Text.Encoding.UTF8).Trim()
                Return If(String.IsNullOrWhiteSpace(t), Nothing, t)
            Catch
                Return Nothing
            End Try
        End SyncLock
    End Function

    Public Shared Sub SaveConnectionString(connectionString As String)
        SyncLock LockObj
            Dim dir = ConfigDirectory()
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
            File.WriteAllText(FilePath, If(connectionString, "").Trim(), Text.Encoding.UTF8)
        End SyncLock
    End Sub
End Class
