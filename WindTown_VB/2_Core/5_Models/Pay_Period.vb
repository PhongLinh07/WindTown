Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("pay_period")>
Public Class Pay_Period
    Inherits BaseEntity

    Public Sub New()
        code = $"PERIOD{GenerateRandomNumbers.Generate()}"
        name = ""
        month = DateTime.Now
        start_date = DateTime.Now
        end_date = DateTime.Now
        std_hours = 0
        note = ""
        status = 0
    End Sub

#Region "Field"
    <DisplayName("Mã Kỳ lương")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên Kỳ lương")> <Display(Order:=1)>
    Public Property name As String

    <DisplayName("Tháng lương")> <DisplayFormat(DataFormatString:="{0:MM-yyyy}")> <Display(Order:=3)>
    Public Property month As DateTime?

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime

    <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime

    <DisplayName("Số giờ chuẩn")> <DisplayFormat(DataFormatString:="{0:N2}")> <Display(Order:=5)>
    Public Property std_hours As Decimal

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property pay_period_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=6)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped> <Browsable(False)>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã đóng"},
        {1, "Đang mở"}
    }
#End Region

#Region "Const"
    <NotMapped> <Browsable(False)>
    Public Shared ReadOnly Property status_closed = 0
    <NotMapped> <Browsable(False)>
    Public Shared ReadOnly Property status_opening = 1
#End Region

End Class
