Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("account")>
Public Class Account
    Inherits BaseEntity

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee = New Employee()
#End Region

#Region "Field Json"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property

    <Write(False)> <DisplayName("User")> <Display(Order:=2)>
    Public Property user As String
        Get
            Return GetV(Of String)("user")
        End Get
        Set(value As String)
            SetV("user", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Password")> <Display(Order:=3)>
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
    <Write(False)> <DisplayName("Last Login")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy HH:mm}")> <Display(Order:=5)>
    Public Property last_login As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("last_login") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("last_login", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Last Logout")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy HH:mm}")> <Display(Order:=6)>
    Public Property last_logout As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("last_logout")
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("last_logout", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Note")> <Display(Order:=7)>
    Public Property note As String
        Get
            Return GetV(Of String)("note")
        End Get
        Set(value As String)
            SetV("note", value)
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

#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Role")> <Display(Order:=4)>
    Public ReadOnly Property role_UI As String
        Get
            Return If(role = 1, "ADMIN", "STAFF")
        End Get
    End Property
    <Write(False)> <DisplayName("Status")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status = 1, "Active", "Inactive")
        End Get
    End Property

    <Write(False)> <DisplayName("Employee")> <Display(Order:=1)>
    Public ReadOnly Property Employee_UI As String
        Get
            Return If(Employee?.code, "---")
        End Get
    End Property
#End Region
End Class