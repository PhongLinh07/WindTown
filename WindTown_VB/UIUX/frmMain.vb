Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UcSidebar1.SetMainPanel(pnlMain)

        OpenForm(New frmDashboard)
    End Sub
    Private Sub OpenForm(frm As Form)

        pnlMain.Controls.Clear()

        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None   ' Ẩn thanh tiêu đề
        frm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(frm)
        frm.Show()

    End Sub

End Class