Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("leave")>
Public Class Leave ' Leave: bị trùng tên với keyword của VB "Control.Leave", cần Imports WindTown_VB
    Inherits BaseEntity

    Public Sub New()
        code = $"LEAVE{GenerateRandomNumbers.Generate()}"
        employee_id = -1
        approved_id = -1
        leave_cat_id = -1
        start_date = DateTime.Now
        total_days = 0
        reason = ""
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property employee_id As Integer

    ' ⚠️ 2 FK cùng trỏ Employee — EF Core cần cấu hình OnDelete(Restrict) trong AppDbContext
    <Browsable(False)>
    Public Property Employee As Employee

    <Browsable(False)>
    Public Property approved_id As Integer?

    <Browsable(False)>
    Public Property Approved As Employee

    <Browsable(False)>
    Public Property leave_cat_id As Integer

    <Browsable(False)>
    Public Property Leave_Cat As Leave_Cat
#End Region

#Region "Field"
    <DisplayName("Mã phép")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime

    <DisplayName("Tổng ngày nghỉ")> <Display(Order:=4)>
    Public Property total_days As Decimal

    <DisplayName("Lý do nghỉ")> <Display(Order:=5)>
    Public Property reason As String

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee IsNot Nothing, $"{Employee?.code} - {Employee?.name}", "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Người phê duyệt")> <Display(Order:=7)>
    Public ReadOnly Property approved_UI As String
        Get
            Return If(Approved IsNot Nothing, $"{Approved?.code} - {Approved?.name}", "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Loại nghỉ phép")> <Display(Order:=6)>
    Public ReadOnly Property leave_type_UI As String
        Get
            Return If(Leave_Cat IsNot Nothing, $"{Leave_Cat?.code} - {Leave_Cat?.name}", "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã bị từ chối"},
        {1, "Đã được phê duyệt"},
        {2, "Đang chờ phê duyệt"}
    }
#End Region

End Class