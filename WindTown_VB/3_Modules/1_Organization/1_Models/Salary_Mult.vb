Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("salary_mult")>
Public Class Salary_Mult
    Inherits BaseEntity

    Public Sub New()

        mult = 1
        note = ""
        status = 0
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Job As Job = New Job()

    <Write(False)> <Browsable(False)>
    Public Property Level As Level = New Level()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property job_id As Integer
        Get
            Return Job?.id
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property level_id As Integer
        Get
            Return Level?.id
        End Get
    End Property

    <DisplayName("Hệ số")> <Display(Order:=2)>
    Public Property mult As Decimal

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=4)>
    Public Property note As String
#End Region


#Region "Field Display"

    <Write(False)> <DisplayName("Cấp bậc")> <Display(Order:=1)>
    Public ReadOnly Property level_UI As String
        Get
            Return If(Level?.name, "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=3)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property


#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }

#End Region
End Class









