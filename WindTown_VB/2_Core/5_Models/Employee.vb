Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("employee")>
Public Class Employee
    Inherits BaseEntity

    Public Sub New()
        code = "EMP" + GenerateRandomNumbers.Generate()
        name = ""
        note = ""
        status = 0
        gender = 0
        birth_date = DateTime.Now
    End Sub

#Region "Navigation"
    <Browsable(False)>
    Public Property Contracts As ICollection(Of Contract)
#End Region

#Region "Field"
    <DisplayName("Mã nhân viên")> <Display(Order:=0)>
    Public Property code As String

    <DisplayName("Tên nhân viên")> <Display(Order:=1)>
    Public Property name As String

    <Browsable(False)>
    Public Property gender As Integer

    <Browsable(False)>
    Public Property cccd As String

    <DisplayName("Ngày sinh")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property birth_date As DateTime?

    <DisplayName("Địa chỉ")> <Display(Order:=5)>
    Public Property address As String

    <Browsable(False)>
    Public Property email As String

    <Browsable(False)>
    Public Property phone As String

    <Browsable(False)>
    Public Property bank As String

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property employee_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property

    <NotMapped> <DisplayName("Giới tính")> <Display(Order:=2)>
    Public ReadOnly Property gender_UI As String
        Get
            Return If(gender_Dict.ContainsKey(Me.gender), gender_Dict(Me.gender), "---")
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

    <NotMapped>
    Public Shared ReadOnly gender_Dict As New Dictionary(Of Integer, String) From {
        {0, "Nữ"},
        {1, "Nam"},
        {2, "Khác"}
    }
#End Region

End Class