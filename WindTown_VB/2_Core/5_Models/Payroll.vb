Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("payroll")>
Public Class Payroll
    Inherits BaseEntity

    Public Sub New()
        code = $"PAY{GenerateRandomNumbers.Generate}"
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property position_id As Integer

    <Browsable(False)>
    Public Property Position As Position

    <Browsable(False)>
    Public Property period_id As Integer

    <Browsable(False)>
    Public Property Pay_Period As Pay_Period

    ' Collection navigation — EF Core tự nạp khi Include()
    <Browsable(False)>
    Public Property Pay_Items As ICollection(Of Pay_Item)
#End Region

#Region "Field"
    <DisplayName("Mã bảng lương")> <Display(Order:=1)>
    Public Property code As String

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Kỳ lương")> <Display(Order:=2)>
    Public ReadOnly Property pay_period_UI As String
        Get
            Return If(Pay_Period?.pay_period_UI, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Hợp đồng")> <Display(Order:=3)>
    Public ReadOnly Property contract_UI As String
        Get
            Return Position?.contract_UI
        End Get
    End Property

    <NotMapped> <DisplayName("Nhân viên")> <Display(Order:=3)>
    Public ReadOnly Property employee_UI As String
        Get
            Return Position?.employee_UI
        End Get
    End Property

    <NotMapped> <DisplayName("Công việc")> <Display(Order:=3)>
    Public ReadOnly Property job_UI As String
        Get
            Return Position?.job_UI
        End Get
    End Property

    <NotMapped> <DisplayName("Trình độ")> <Display(Order:=4)>
    Public ReadOnly Property level_UI As String
        Get
            Return Position?.level_UI
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
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
