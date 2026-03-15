Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

Public Class PolicyParameter

    Public Sub New()
        code = ""
        name = ""
        category = 1
        note = ""
    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Tham số")> <Display(Order:=2)>
    Public Property code As String

    <Write(False)> <DisplayName("Tên tham số")> <Display(Order:=2)>
    Public Property name As String

    <Write(False)> <DisplayName("Danh mục")> <Display(Order:=3)>
    Public Property category As Integer

    <Write(False)> <DisplayName("Mô tả")> <Display(Order:=7)>
    Public Property note As String


#End Region

#Region "Static readonly"

    Public Shared ReadOnly PARAMETERs As List(Of PolicyParameter) = New List(Of PolicyParameter) From {
    New PolicyParameter With {.code = STD_HOURS, .name = "Giờ công chuẩn", .category = "Period", .note = "Tổng số giờ làm việc tiêu chuẩn của tháng"},
    New PolicyParameter With {.code = BASE_SALARY, .name = "Lương cơ bản", .category = "Employee", .note = "Mức lương chính trong hợp đồng"},
    New PolicyParameter With {.code = SALARY_MULT, .name = "Hệ số lương", .category = "Employee", .note = "Hệ số lương trong chức vụ"},
    New PolicyParameter With {.code = HOURLY_RATE, .name = "Lương mỗi giờ", .category = "Employee", .note = "Đơn giá lương tính trên 1 giờ làm việc"},
    New PolicyParameter With {.code = OFFICE_HOURS, .name = "Giờ hành chính", .category = "TIMEKEEPING", .note = "Số giờ làm việc trong ca"},
    New PolicyParameter With {.code = OVERTIME_HOURS, .name = "Giờ tăng ca", .category = "TIMEKEEPING", .note = "Số giờ làm thêm"},
    New PolicyParameter With {.code = LATE_HOURS, .name = "Giờ đi trễ", .category = "TIMEKEEPING", .note = "Số giờ đến muộn"},
    New PolicyParameter With {.code = EARLY_LEAVE_HOURS, .name = "Giờ về sớm", .category = "TIMEKEEPING", .note = "Số giờ về sớm"},
    New PolicyParameter With {.code = SHIFT, .name = "Xác định ca đêm", .category = "TIMEKEEPING", .note = "1 = ca đêm, 0 = ca ngày"},
    New PolicyParameter With {.code = TOTAL_OFFICE_HOURS, .name = "Tổng giờ làm tháng", .category = "ACCUMULATION", .note = "Tổng giờ hành chính trong tháng"},
    New PolicyParameter With {.code = WORK_DAYS, .name = "Số ngày công", .category = "ACCUMULATION", .note = "Tổng ngày làm việc thực tế"}}


    'hệ số, số giờ chuẩn, lương tb 1h chuẩn , số giờ thực tế,  lương thực nhận khấu trừ 
    ' 2. Hàm chuyển đổi nhanh sang Dictionary để dùng trong Code tính toán
    Public Shared Function GetAsDictionary() As Dictionary(Of String, PolicyParameter)
        Return PARAMETERs.ToDictionary(Function(v) v.code)
    End Function


    'Kỳ lương
    Public Shared ReadOnly STD_HOURS As String = "STD_HOURS"
    'Nhân viên
    Public Shared ReadOnly BASE_SALARY As String = "BASE_SALARY"
    Public Shared ReadOnly SALARY_MULT As String = "SALARY_MULT"
    Public Shared ReadOnly HOURLY_RATE As String = "HOURLY_RATE"

    'Chấm công
    Public Shared ReadOnly OFFICE_HOURS As String = "OFFICE_HOURS"
    Public Shared ReadOnly OVERTIME_HOURS As String = "OVERTIME_HOURS"
    Public Shared ReadOnly LATE_HOURS As String = "LATE_HOURS"
    Public Shared ReadOnly EARLY_LEAVE_HOURS As String = "EARLY_LEAVE_HOURS"
    Public Shared ReadOnly SHIFT As String = "SHIFT"
    Public Shared ReadOnly TOTAL_OFFICE_HOURS As String = "TOTAL_OFFICE_HOURS"
    Public Shared ReadOnly WORK_DAYS As String = "WORK_DAYS"


#End Region

End Class