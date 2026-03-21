Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("job")>
Public Class Job
    Inherits BaseEntity

    Public Sub New()
        code = "JOB" + GenerateRandomNumbers.Generate()
        name = ""
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property department_id As Integer

    <Browsable(False)>
    Public Property Department As Department
#End Region

#Region "Field"
    <DisplayName("Mã công việc")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên công việc")> <Display(Order:=2)>
    Public Property name As String

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=5)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property job_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property

    <NotMapped> <DisplayName("Phòng ban")> <Display(Order:=3)>
    Public ReadOnly Property Department_UI As String
        Get
            Return If(Department?.department_UI, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=4)>
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