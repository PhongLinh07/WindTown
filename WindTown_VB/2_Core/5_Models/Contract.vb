Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("contract")>
Public Class Contract
    Inherits BaseEntity

    Public Sub New()
        code = "CTR" + GenerateRandomNumbers.Generate()
        start_date = DateTime.Now
        end_date = start_date.AddYears(3)
        base_salary = 0.0
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property employee_id As Integer

    <Browsable(False)>
    Public Property Employee As Employee
#End Region

#Region "Field"
    <DisplayName("Mã hợp đồng")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime

    <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime

    <DisplayName("Lương cơ bản")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=5)>
    Public Property base_salary As Decimal

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee?.employee_UI, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=7)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng hoạt động"},
        {1, "Đang hoạt động"}
    }
#End Region

End Class