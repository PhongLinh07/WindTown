Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("employee")>
Public Class Employee
    Inherits BaseEntity

#Region "Field json"
    <Write(False)> <DisplayName("Mã nhân viên")> <Display(Order:=0)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên nhân viên")> <Display(Order:=1)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property gender As Integer
        Get
            Return GetV(Of Integer)("gender")
        End Get
        Set(value As Integer)
            SetV("gender", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property cccd As String
        Get
            Return GetV(Of String)("cccd")
        End Get
        Set(value As String)
            SetV("cccd", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ngày sinh")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property birth_date As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("birth_date")
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("birth_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Địa chỉ")> <Display(Order:=5)>
    Public Property address As String
        Get
            Return GetV(Of String)("address")
        End Get
        Set(value As String)
            SetV("address", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property email As String
        Get
            Return GetV(Of String)("email")
        End Get
        Set(value As String)
            SetV("email", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property phone As String
        Get
            Return GetV(Of String)("phone")
        End Get
        Set(value As String)
            SetV("phone", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property bank As String
        Get
            Return GetV(Of String)("bank")
        End Get
        Set(value As String)
            SetV("bank", value)
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
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=10)>
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
    <Write(False)> <DisplayName("Giới tính")> <Display(Order:=2)>
    Public ReadOnly Property gender_UI As String
        Get
            Return If(gender = 1, "Nam", If(gender = 0, "Nữ", "Khác"))
        End Get
    End Property

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status = 1, "Đang hoạt động", "Ngừng hoạt động")
        End Get
    End Property
#End Region
End Class
