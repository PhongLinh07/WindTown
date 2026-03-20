Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("leave")>
Public Class Leave 'Leave: bị trùng tên với keyword của VB " Control.Leave", cần Imports WindTown_VB
    Inherits BaseEntity

    Public Sub New()
        code = $"LEAVE{GenerateRandomNumbers.Generate()}"
        start_date = DateTime.Now
        total_days = 0
        reason = ""
        note = ""
        status = 0
    End Sub
#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee = New Employee()

    <Write(False)> <Browsable(False)>
    Public Property Approved = New Employee()

    <Write(False)> <Browsable(False)>
    Public Property Leave_Cat = New Leave_Cat()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property approved_id As Integer
        Get
            Return Approved?.id
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property leave_cat_id As Integer
        Get
            Return Leave_Cat?.id
        End Get
    End Property

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

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee IsNot Nothing, $"{Employee?.code} - {Employee?.name}", "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Người phê duyệt")> <Display(Order:=7)>
    Public ReadOnly Property approved_UI As String
        Get
            Return If(Approved IsNot Nothing, $"{Approved?.code} - {Approved?.name}", "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Loại nghỉ phép")> <Display(Order:=6)>
    Public ReadOnly Property leave_type_UI As String
        Get
            Return If(Leave_Cat IsNot Nothing, $"{Leave_Cat?.code} - {Leave_Cat?.name}", "---")
        End Get
    End Property

#End Region


#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã bị từ chối"},
        {1, "Đã được phê duyệt"},
        {2, "Đang chờ phê duyệt"}
    }

#End Region
End Class



