Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class formParameterList

    Public Class ParameterVM
        <DisplayName("Mã Hệ Thống")>
        Public Property Code As String
        <DisplayName("Tên mã")>
        Public Property Name As String
        <DisplayName("Dữ liệu nguồn")>
        Public Property Resource As String
        <DisplayName("Mô tả")>
        Public Property Note As String
    End Class
    Public Shared ReadOnly DisplayList As New List(Of ParameterVM) From {
    New ParameterVM With {.Code = "SYS_STD_HOURS", .Name = "Giờ công chuẩn", .Resource = "pay_period", .Note = "Tổng số giờ làm việc tiêu chuẩn của tháng"},
    New ParameterVM With {.Code = "SYS_BASE_SALARY", .Name = "Lương cơ bản", .Resource = "contract", .Note = "Mức lương chính trong hợp đồng"},
    New ParameterVM With {.Code = "SYS_SALARY_MULT", .Name = "Hệ số lương", .Resource = "position", .Note = "Hệ số lương trong chức vụ"},
    New ParameterVM With {.Code = "SYS_OFFICE_HOURS", .Name = "Giờ hành chính", .Resource = "attendance", .Note = "Tổng số giờ làm việc trong ca của từng ngày"},
    New ParameterVM With {.Code = "SYS_OVERTIME_HOURS", .Name = "Giờ tăng ca", .Resource = "attendance", .Note = "Tổng số giờ làm thêm của từng ngày"},
    New ParameterVM With {.Code = "SYS_LATE_HOURS", .Name = "Giờ đi trễ", .Resource = "attendance", .Note = "Tổng số giờ đi trễ của từng ngày"},
    New ParameterVM With {.Code = "SYS_EARLY_LEAVE_HOURS", .Name = "Giờ về sớm", .Resource = "attendance", .Note = "Tổng số giờ về sớm của từng ngày"},
    New ParameterVM With {.Code = "SYS_SHIFT", .Name = "Ca làm việc", .Resource = "attendance", .Note = "0 = ca đêm, 1 = ca ngày, Của từng ngày"},
    New ParameterVM With {.Code = "SYS_IS_HOLIDAY", .Name = "Là ngày lễ", .Resource = "holiday", .Note = "1 = ngày lễ, 0 = ngày thường, Kiểm tra theo ngày"},
    New ParameterVM With {.Code = "SYS_DAY_MULT_HOLIDAY", .Name = "Hệ số ngày lễ", .Resource = "holiday", .Note = "Hệ số giờ ngày lễ, kiểm tra từng ngày"},
    New ParameterVM With {.Code = "SYS_TOTAL_INCOME", .Name = "Tổng thu nhập", .Resource = "Payroll", .Note = "Tổng thu nhập cả kỳ"},
    New ParameterVM With {.Code = "SYS_TAX_AMOUNT", .Name = "Tổng thuế", .Resource = "Payroll", .Note = "Tổng thuế"},
    New ParameterVM With {.Code = "SYS_DEDUCTION", .Name = "Tổng khấu trừ", .Resource = "Payroll", .Note = "Tổng khấu trừ"},
    New ParameterVM With {.Code = "SYS_NET_SALARY", .Name = "Thực lĩnh", .Resource = "Payroll", .Note = "Tổng thực lĩnh cả kỳ"}
}
    Public Sub New()
        InitializeComponent()
        Me.Tag = "formParameterList"
        Me.Text = "Tham số hệ thống"


    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dgv.Columns.Clear()
        ' 1. Gán nguồn dữ liệu
        _dgv.DataSource = DisplayList

        ' 2. Cấu hình chỉ đọc và chọn dòng
        _dgv.ReadOnly = True
        _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        _dgv.AllowUserToAddRows = False

        ' 3. Đổi tiêu đề cột cho chuyên nghiệp (Tùy chọn)
        _dgv.Columns("Code").HeaderText = "Mã Hệ Thống"
        _dgv.Columns("Name").HeaderText = "Tên Tham Số"
        _dgv.Columns("Resource").HeaderText = "Nguồn"
        _dgv.Columns("Note").HeaderText = "Ghi Chú"

        ' Cho cột Ghi chú rộng ra để dễ đọc
        _dgv.Columns("Note").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class

