Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("attendance")>
Public Class Attendance
    Inherits BaseEntity

    Public Sub New()
        code = $"ATTD{GenerateRandomNumbers.Generate()}"
        of_date = DateTime.Now
        office_hours = 0
        overtime_hours = 0
        late_hours = 0
        early_hours = 0
        shift = 1
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property employee_id As Integer

    <Browsable(False)>
    Public Property Employee As Employee
#End Region

#Region "Field"
    <DisplayName("Mã chấm công")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Ngày chấm công")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property of_date As DateTime

    <DisplayName("Số Giờ hành chính")> <Display(Order:=5)>
    Public Property office_hours As Decimal

    <DisplayName("Số Giờ tăng ca")> <Display(Order:=6)>
    Public Property overtime_hours As Decimal

    <DisplayName("Số giờ đi muộn")> <Display(Order:=7)>
    Public Property late_hours As Decimal

    <DisplayName("Số giờ về sớm")> <Display(Order:=8)>
    Public Property early_hours As Decimal

    <Browsable(False)>
    Public Property shift As Integer

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Ca làm")> <Display(Order:=4)>
    Public ReadOnly Property shift_UI As String
        Get
            Return If(shift_Dic.ContainsKey(Me.shift), shift_Dic(Me.shift), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee IsNot Nothing, $"{Employee?.name} ({Employee?.code})", "---")
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
    Public Shared ReadOnly shift_Dic As New Dictionary(Of Integer, String) From {
        {0, "Đêm"},
        {1, "Ngày"}
    }
#End Region

End Class