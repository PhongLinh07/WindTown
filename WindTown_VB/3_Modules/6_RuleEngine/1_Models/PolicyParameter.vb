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
    New PolicyParameter With {.code = "BASE_SALARY", .name = "Lương cơ bản", .category = "SYSTEM", .note = "Mức lương chính trong hợp đồng"},
    New PolicyParameter With {.code = "HOURLY_RATE", .name = "Lương mỗi giờ", .category = "SYSTEM", .note = "Đơn giá lương tính trên 1 giờ làm việc"},
    New PolicyParameter With {.code = "STD_HOURS", .name = "Giờ công chuẩn", .category = "SYSTEM", .note = "Tổng số giờ làm việc tiêu chuẩn của tháng"},
    New PolicyParameter With {.code = "OFFICE_HOURS", .name = "Giờ hành chính", .category = "TIMEKEEPING", .note = "Số giờ làm việc trong ca"},
    New PolicyParameter With {.code = "OVERTIME_HOURS", .name = "Giờ tăng ca", .category = "TIMEKEEPING", .note = "Số giờ làm thêm"},
    New PolicyParameter With {.code = "LATE_HOURS", .name = "Giờ đi trễ", .category = "TIMEKEEPING", .note = "Số giờ đến muộn"},
    New PolicyParameter With {.code = "EARLY_LEAVE_HOURS", .name = "Giờ về sớm", .category = "TIMEKEEPING", .note = "Số giờ về sớm"},
    New PolicyParameter With {.code = "IS_NIGHT", .name = "Xác định ca đêm", .category = "TIMEKEEPING", .note = "1 = ca đêm, 0 = ca ngày"},
    New PolicyParameter With {.code = "TOTAL_OFFICE_HOURS", .name = "Tổng giờ làm tháng", .category = "ACCUMULATION", .note = "Tổng giờ hành chính trong tháng"},
    New PolicyParameter With {.code = "WORK_DAYS", .name = "Số ngày công", .category = "ACCUMULATION", .note = "Tổng ngày làm việc thực tế"},
    New PolicyParameter With {.code = "MULT_ALLOW_DEPARTMENT", .name = "Hệ số PC phòng ban", .category = "ALLOWANCE", .note = "Hệ số phụ cấp phòng ban"},
    New PolicyParameter With {.code = "MULT_ALLOW_POSITION", .name = "Hệ số PC chức vụ", .category = "ALLOWANCE", .note = "Hệ số phụ cấp chức vụ"},
    New PolicyParameter With {.code = "KPI", .name = "Điểm KPI", .category = "PERFORMANCE", .note = "Điểm hiệu suất (0-100)"}}

    'hệ số, số giờ chuẩn, lương tb 1h chuẩn , số giờ thực tế,  lương thực nhận khấu trừ 
    ' 2. Hàm chuyển đổi nhanh sang Dictionary để dùng trong Code tính toán
    Public Shared Function GetAsDictionary() As Dictionary(Of String, PolicyParameter)
        Return PARAMETERs.ToDictionary(Function(v) v.code)
    End Function


#End Region

End Class