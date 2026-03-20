Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("project")>
Public Class Project
    Inherits BaseEntity

    Public Sub New()
        code = $"PROJ{GenerateRandomNumbers.Generate()}"
        name = ""
        start_date = DateTime.Now
        end_date = DateTime.Now
        note = ""
        status = 0
    End Sub

#Region "Field Json"

    <DisplayName("Mã dự án")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên dự án")> <Display(Order:=2)>
    Public Property name As String

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime

    <DisplayName("Ngày kết thúc dự kiến")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime?

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=5)>
    Public Property note As String
#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=4)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region


#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã bị từ chối"},
        {1, "Đang lập kế hoạch"},
        {2, "Đang thực hiện"},
        {3, "Đã hoàn thành"}
    }
#End Region
End Class
