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

#Region "Field json"
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

    <Write(False)> <DisplayName("Hệ số")> <Display(Order:=2)>
    Public Property mult As Decimal
        Get
            Return GetV(Of Decimal)("mult")
        End Get
        Set(value As Decimal)
            SetV("mult", value)
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
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=4)>
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









