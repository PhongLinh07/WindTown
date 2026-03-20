Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("holiday")>
Public Class Holiday
    Inherits BaseEntity

    Public Sub New()
        code = $"HOLD{GenerateRandomNumbers.Generate()}"
        name = ""
        of_date = DateTime.Now
        mult = 3.0
        note = ""
        status = 3
    End Sub

#Region "Field"
    <DisplayName("Mã ngày lễ")> <Display(Order:=2)>
    Public Property code As String

    <DisplayName("Tên ngày lễ")> <Display(Order:=2)>
    Public Property name As String

    <DisplayName("Thời gian")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=2)>
    Public Property of_date As DateTime

    <DisplayName("Hệ số")> <Display(Order:=2)>
    Public Property mult As Decimal

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=3)>
    Public Property note As String

#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=2)>
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