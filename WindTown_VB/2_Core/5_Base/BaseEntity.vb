Imports Dapper.Contrib.Extensions

Public MustInherit Class BaseEntity
    <Key> ' Đánh dấu khóa chính tự tăng
    Public Property id As Integer
    Public Property datas As String ' Lưu JSON nvarchar(max)
    Public Property code As String
    Public Property name As String
    Public Property note As String
    Public Property status As Integer
End Class