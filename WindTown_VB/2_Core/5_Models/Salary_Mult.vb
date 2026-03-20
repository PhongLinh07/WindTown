Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("salary_mult")>
Public Class Salary_Mult
    Inherits BaseEntity

    Public Sub New()
        mult = 1
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property job_id As Integer

    <Browsable(False)>
    Public Property Job As Job

    <Browsable(False)>
    Public Property level_id As Integer

    <Browsable(False)>
    Public Property Level As Level
#End Region

#Region "Field"
    <DisplayName("Hệ số")> <Display(Order:=2)>
    Public Property mult As Decimal

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=4)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Cấp bậc")> <Display(Order:=1)>
    Public ReadOnly Property level_UI As String
        Get
            Return If(Level?.name, "---")
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
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region

End Class