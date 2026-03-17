Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("job")>
Public Class Job
    Inherits BaseEntity

    Public Sub New()
        code = "JOB" + GenerateRandomNumbers.Generate()
        name = ""
        note = ""
        status = 0
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Department = New Department()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property department_id As Integer
        Get
            Return Department?.id
        End Get
    End Property
#End Region

#Region "Field Json"
    <Write(False)> <DisplayName("Mã công việc")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Tên công việc")> <Display(Order:=2)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
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
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=5)>
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
    <Write(False)> <Browsable(False)>
    Public ReadOnly Property job_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property
    <Write(False)> <DisplayName("Phòng ban")> <Display(Order:=3)>
    Public ReadOnly Property Department_UI As String
        Get
            Return If(Department?.name, "---")
        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=4)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng hoạt động"},
        {1, "Đang hoạt động"}
    }

#End Region

End Class