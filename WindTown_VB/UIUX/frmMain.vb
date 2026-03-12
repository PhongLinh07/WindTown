Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NavigationService.Initialize(Me, pnlMain)

        UcSidebar1.SetMainPanel(pnlMain)

        Me.KeyPreview = True

        NavigationService.NavigateInMain(Of frmDashboard)(False)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
#If DEBUG Then
        ' Ghi log danh sách form còn mở để truy vết khi ứng dụng không thoát.
        Dim openForms = Application.OpenForms.Cast(Of Form)().Select(Function(f) f.Name).ToArray()
        System.Diagnostics.Debug.WriteLine("[frmMain.FormClosing] OpenForms: " & String.Join(", ", openForms))
#End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Đóng frmMain bằng nút tắt thì thoát hẳn; riêng luồng logout thì không thoát app.
        If NavigationService.ShouldTerminateWhenMainClosed() Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        ' Alt+Left để quay lại màn trước trong vùng nội dung chính.
        If e.Alt AndAlso e.KeyCode = Keys.Left Then
            If NavigationService.GoBackInMain() Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

End Class
