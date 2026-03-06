Imports Microsoft.Data.Common

Partial Public Class FormMain
    Inherits Form

    Private currentForm As UserControl = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    '-----------------------------------------
    ' Mở Child Form
    Private Sub OpenChildForm(Of T As {UserControl, New})()
        ' 1. Giải phóng tài nguyên của form cũ để tránh leak bộ nhớ
        If currentForm IsNot Nothing Then
            pnl_main.Controls.Remove(currentForm)
            currentForm.Dispose()
        End If

        ' 2. Khởi tạo UserControl mới từ tham số Generic T
        Dim childForm As New T()

        ' 3. Thiết lập thuộc tính hiển thị
        currentForm = childForm
        _title.Text = childForm.Tag?.ToString() ' Thường UC dùng Tag hoặc một thuộc tính riêng cho Title

        childForm.Dock = DockStyle.Fill

        ' 4. Thêm vào Panel chính
        pnl_main.Controls.Add(childForm)
        pnl_main.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub menu_department_Click(sender As Object, e As EventArgs) Handles menu_department.Click
        OpenChildForm(Of Department_List_UC)()
    End Sub

    Private Sub menu_job_Click(sender As Object, e As EventArgs) Handles menu_job.Click
        OpenChildForm(Of Job_List_UC)()
    End Sub

    Private Sub menu_level_Click(sender As Object, e As EventArgs) Handles menu_level.Click
        OpenChildForm(Of Level_List_UC)()
    End Sub

    Private Sub menu_empolyee_Click(sender As Object, e As EventArgs) Handles menu_empolyee.Click
        OpenChildForm(Of Employee_List_UC)()
    End Sub

    Private Sub menu_contract_Click(sender As Object, e As EventArgs) Handles menu_contract.Click
        OpenChildForm(Of Contract_List_UC)()
    End Sub

    Private Sub menu_position_Click(sender As Object, e As EventArgs) Handles menu_position.Click
        OpenChildForm(Of Position_List_UC)()
    End Sub

    Private Sub menu_project_Click(sender As Object, e As EventArgs) Handles menu_project.Click
        OpenChildForm(Of Project_List_UC)()
    End Sub

    Private Sub menu_attendance_Click(sender As Object, e As EventArgs) Handles menu_attendance.Click
        OpenChildForm(Of Attendance_List_UC)()
    End Sub

    Private Sub menu_account_Click(sender As Object, e As EventArgs) Handles menu_account.Click
        OpenChildForm(Of Account_List_UC)()
    End Sub

    Private Sub menu_holiday_Click(sender As Object, e As EventArgs) Handles menu_holiday.Click
        OpenChildForm(Of Holiday_List_UC)()
    End Sub
End Class