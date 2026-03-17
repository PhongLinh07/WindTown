Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("account")>
Public Class Account
    Inherits BaseEntity

    Public Sub New()
        user = $"ACC{GenerateRandomNumbers.Generate()}"
        password = ""
        role = 1
        last_active = DateTime.Now
        note = ""
        status = 0
    End Sub
#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee As Employee = New Employee()
#End Region

#Region "Field Json"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property

    <Write(False)> <DisplayName("Tên tài khoản")> <Display(Order:=2)>
    Public Property user As String
        Get
            Return GetV(Of String)("user")
        End Get
        Set(value As String)
            SetV("user", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Mật khẩu")> <Display(Order:=3)>
    Public Property password As String
        Get
            Return GetV(Of String)("password")
        End Get
        Set(value As String)
            SetV("password", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property role As Integer
        Get
            Return GetV(Of Integer)("role")
        End Get
        Set(value As Integer)
            SetV("role", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Lần cuối hoạt động")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy HH:mm}")> <Display(Order:=5)>
    Public Property last_active As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("last_active") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("last_active", value)
        End Set
    End Property

    <Write(False)> <Browsable(False)>
    Public Property status As Integer
        Get
            Return GetV(Of Integer)("status")
        End Get
        Set(value As Integer)
            SetV("status", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String
        Get
            Return GetV(Of String)("note")
        End Get
        Set(value As String)
            SetV("note", value)
        End Set
    End Property

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
    Public Shared ReadOnly role_Dict As New Dictionary(Of Integer, String) From {
        {1, "ADMIN"},
        {2, "STAFF "}
    }

#End Region

End Class