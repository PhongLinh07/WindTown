Public Class formSystem

    Private Sub formSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTheme.SelectedIndex = 0
        cboAccent.SelectedIndex = 0
        cboFontSize.SelectedIndex = 1

        txtDbHost.Text = "localhost"
        txtDbName.Text = "WindTown"
        txtDbUser.Text = "sa"
        txtDbPort.Text = "1433"
        txtDbTimeout.Text = "30"

        LoadMockRoles()
    End Sub

    Private Sub btnTestConn_Click(sender As Object, e As EventArgs) Handles btnTestConn.Click
        MessageBox.Show("Đã thử kết nối (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSaveDb_Click(sender As Object, e As EventArgs) Handles btnSaveDb.Click
        MessageBox.Show("Đã lưu cấu hình DB (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSaveDisplay_Click(sender As Object, e As EventArgs) Handles btnSaveDisplay.Click
        MessageBox.Show("Đã lưu cấu hình hiển thị (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAddRole_Click(sender As Object, e As EventArgs) Handles btnAddRole.Click
        MessageBox.Show("Thêm role (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDeleteRole_Click(sender As Object, e As EventArgs) Handles btnDeleteRole.Click
        MessageBox.Show("Xóa role (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadMockRoles()
        dgvRoles.Rows.Clear()
        dgvRoles.Rows.Add("Admin", "Toàn quyền hệ thống", "*" )
        dgvRoles.Rows.Add("HR", "Quản lý nhân sự", "employee, contract, position")
        dgvRoles.Rows.Add("Accountant", "Quản lý lương", "payroll, pay_period")
    End Sub

End Class
