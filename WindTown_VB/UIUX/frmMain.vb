Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UcSidebar1.SetMainPanel(pnlMain)

        OpenForm(New frmDashboard)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
#If DEBUG Then
        ' Ghi log danh sách form còn mở để truy vết khi ứng dụng không thoát.
        Dim openForms = Application.OpenForms.Cast(Of Form)().Select(Function(f) f.Name).ToArray()
        System.Diagnostics.Debug.WriteLine("[frmMain.FormClosing] OpenForms: " & String.Join(", ", openForms))
#End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' frmMain là cửa sổ chính của luồng Frontend, đóng nó thì thoát toàn bộ ứng dụng.
        Application.Exit()
    End Sub

    Private Sub OpenForm(frm As Form)

        For i As Integer = pnlMain.Controls.Count - 1 To 0 Step -1
            Dim oldCtrl As Control = pnlMain.Controls(i)
            pnlMain.Controls.RemoveAt(i)
            oldCtrl.Dispose()
        Next

        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(frm)
        frm.Show()

    End Sub

End Class
