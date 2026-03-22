Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("department")>
Public Class Department
    Inherits BaseEntity

    Public Sub New()
        code = "DEP" + GenerateRandomNumbers.Generate()
        name = ""
        note = ""
        status = 0
    End Sub

#Region "Navigation"
    <Browsable(False)>
    Public Property Jobs As ICollection(Of Job)

#End Region

#Region "Field"
    <DisplayName("Mã phòng ban")> <Display(Order:=0)>
    Public Property code As String

    <DisplayName("Tên phòng ban")> <Display(Order:=1)>
    Public Property name As String

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=4)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property department_UI As String
        Get
            Return $"{Me.name} ({Me.code})"
        End Get
    End Property
    <NotMapped> <DisplayName("Tổng công việc")> <Display(Order:=3)>
    Public ReadOnly Property job_UI As Integer
        Get
            Return If(Jobs IsNot Nothing, Jobs.Count(), 0)
        End Get
    End Property
    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=3)>
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