Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("payroll")>
Public Class Payroll
    Inherits BaseEntity

    Public Sub New()
        code = ""
        gross_salary = 0
        bonus = 0
        deduction = 0
        net_salary = 0
        note = ""
        status = 1
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Period = New Pay_Period()

    <Write(False)> <Browsable(False)>
    Public Property Position = New Position()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property period_id As Integer
        Get
            Return Period?.id
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property position_id As Integer
        Get
            Return Position?.id
        End Get
    End Property
#End Region

#Region "Field Json"
    <Write(False)> <DisplayName("Mã bảng lương")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Lương cơ bản")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=5)>
    Public Property gross_salary As Decimal?
        Get
            Return GetV(Of Decimal?)("gross_salary")
        End Get
        Set(value As Decimal?)
            SetV("gross_salary", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Phụ cấp")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=6)>
    Public Property bonus As Decimal?
        Get
            Return GetV(Of Decimal?)("bonus")
        End Get
        Set(value As Decimal?)
            SetV("bonus", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Khấu trừ")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=7)>
    Public Property deduction As Decimal?
        Get
            Return GetV(Of Decimal?)("deduction")
        End Get
        Set(value As Decimal?)
            SetV("deduction", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Thực lĩnh")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=8)>
    Public Property net_salary As Decimal?
        Get
            Return GetV(Of Decimal?)("net_salary")
        End Get
        Set(value As Decimal?)
            SetV("net_salary", value)
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

    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=9)>
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
    <Write(False)> <DisplayName("Kỳ lương")> <Display(Order:=2)>
    Public ReadOnly Property period_UI As String
        Get
            If Period Is Nothing Then Return "---"
            Dim label = If(Period.name, Period.code)
            If String.IsNullOrWhiteSpace(label) Then label = Period.code
            Return label
        End Get
    End Property

    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=3)>
    Public ReadOnly Property employee_UI As String
        Get
            Dim emp = Position?.Contract?.Employee
            If emp Is Nothing Then Return "---"
            Return $"{emp.name} ({emp.code})"
        End Get
    End Property

    <Write(False)> <DisplayName("Công việc")> <Display(Order:=4)>
    Public ReadOnly Property job_UI As String
        Get
            If Position Is Nothing OrElse Position.Job Is Nothing Then Return "---"
            Return $"{Position.Job.name} ({Position.Job.code})"
        End Get
    End Property

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=10)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã khóa"},
        {1, "Đang mở"}
    }
#End Region
End Class
