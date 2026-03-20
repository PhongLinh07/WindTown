Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("account")>
Public Class Account
    Inherits BaseEntity

    Public Sub New()
        user = $"ACC{GenerateRandomNumbers.Generate()}"
        password = "123456"
        role = 1
        last_active = DateTime.Now
        note = ""
        status = 0
    End Sub
#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee As Employee = New Employee()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property

    <DisplayName("Tên tài khoản")> <Display(Order:=2)>
    Public Property user As String

    <DisplayName("Mật khẩu")> <Display(Order:=3)>
    Public Property password As String

    <Browsable(False)>
    Public Property role As Integer

    <DisplayName("Lần cuối hoạt động")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy HH:mm}")> <Display(Order:=5)>
    Public Property last_active As DateTime? ' Thêm dấu ? để cho phép Null

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String

#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Quyền")> <Display(Order:=4)>
    Public ReadOnly Property role_UI As String
        Get
            Return If(role_Dict.ContainsKey(Me.role), role_Dict(Me.role), "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=6)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")

        End Get
    End Property

    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=1)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee?.employee_UI, "---")
        End Get
    End Property
#End Region
#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng hoạt động"},
        {1, "Đang hoạt động"}
    }

    <Browsable(False)>
    Public Const ROLE_ADM As Integer = 1
    <Browsable(False)>
    Public Const ROLE_STAFF As Integer = 2

    Public Shared ReadOnly role_Dict As New Dictionary(Of Integer, String) From {
        {ROLE_ADM, "Admin"},
        {ROLE_STAFF, "Staff"}
    }

#End Region


End Class