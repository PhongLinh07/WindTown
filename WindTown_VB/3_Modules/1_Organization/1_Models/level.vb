Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("level")>
Public Class Level
    Inherits BaseEntity

    Public Sub New()
        code = ""
        name = ""
        note = ""
        rank = 1
        status = 0
    End Sub
#Region "Field json"
    <Write(False)> <DisplayName("Mã trình độ")> <Display(Order:=0)>
    Public Property code As String
    <Write(False)> <DisplayName("Tên trình độ")> <Display(Order:=1)>
    Public Property name As String
    <Write(False)> <DisplayName("Giá trị cấp bậc")> <Display(Order:=2)>
    Public Property rank As Integer
    <Write(False)> <Browsable(False)>
    Public Property status As Integer
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=4)>
    Public Property note As String
#End Region

#Region "Field Display"
    <Write(False)> <Browsable(False)>
    Public ReadOnly Property level_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=3)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }

#End Region
End Class









