Public Class formAssignment

    Private Sub formAssignment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboProject.Items.Clear()
        cboProject.Items.AddRange(New Object() {"Dự án A", "Dự án B", "Dự án C"})
        cboProject.SelectedIndex = 0

        cboEmployee.Items.Clear()
        cboEmployee.Items.AddRange(New Object() {"Nguyễn Văn A", "Trần Thị B", "Lê Văn C"})
        cboEmployee.SelectedIndex = 0

        cboRole.Items.Clear()
        cboRole.Items.AddRange(New Object() {"Leader", "Developer", "Tester"})
        cboRole.SelectedIndex = 0

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Đang tham gia", "Tạm dừng", "Kết thúc"})
        cboStatus.SelectedIndex = 0

        txtAllocation.Text = "100"
        dtpStart.Value = DateTime.Today
        dtpEnd.Value = DateTime.Today.AddMonths(1)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        MessageBox.Show("Đã lưu phân công (mock).", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

End Class
