Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("attendance")>
Public Class Attendance
    Inherits BaseEntity

    Public Sub New()
        code = ""
        of_date = DateTime.Now
        office_hours = 0
        overtime_hours = 0
        late_hours = 0
        early_hours = 0
        shift = 1
        note = ""
        status = 0
    End Sub
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

    <Write(False)> <DisplayName("Code")> <Display(Order:=2)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Date")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=5)>
    Public Property of_date As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("of_date") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("of_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Office Hours")> <Display(Order:=2)>
    Public Property office_hours As Decimal
        Get
            Return GetV(Of Decimal)("office_hours")
        End Get
        Set(value As Decimal)
            SetV("office_hours", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Overtime Hours")> <Display(Order:=2)>
    Public Property overtime_hours As Decimal
        Get
            Return GetV(Of Decimal)("overtime_hours")
        End Get
        Set(value As Decimal)
            SetV("overtime_hours", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Late Hours")> <Display(Order:=2)>
    Public Property late_hours As Decimal
        Get
            Return GetV(Of Decimal)("late_hours")
        End Get
        Set(value As Decimal)
            SetV("late_hours", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Early Hours")> <Display(Order:=2)>
    Public Property early_hours As Decimal
        Get
            Return GetV(Of Decimal)("early_hours")
        End Get
        Set(value As Decimal)
            SetV("early_hours", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property shift As Integer
        Get
            Return GetV(Of Integer)("shift")
        End Get
        Set(value As Integer)
            SetV("shift", value)
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

    <Write(False)> <DisplayName("Shift")> <Display(Order:=4)>
    Public ReadOnly Property shift_UI As String
        Get
            Return If(Dict_Shift.ContainsKey(Me.shift), Dict_Shift(Me.shift), "---")
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


#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly Dict_Shift As New Dictionary(Of Integer, String) From {
        {0, "NIGHT"},
        {1, "DAY"}
    }

#End Region
End Class