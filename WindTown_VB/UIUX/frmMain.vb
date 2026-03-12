Public Class frmMain
    ' Ghi chu: cap nhat nho theo yeu cau, khong thay doi logic.

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NavigationService.Initialize(Me, pnlMain)

        UcSidebar1.SetMainPanel(pnlMain)

        Me.KeyPreview = True

        NavigationService.NavigateInMain(Of frmDashboard)(False)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
#If DEBUG Then
        ' Ghi log danh sách form còn m? d? truy v?t khi ?ng d?ng không thoát.
        Dim openForms = Application.OpenForms.Cast(Of Form)().Select(Function(f) f.Name).ToArray()
        System.Diagnostics.Debug.WriteLine("[frmMain.FormClosing] OpenForms: " & String.Join(", ", openForms))
#End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Ðóng frmMain b?ng nút t?t thì thoát h?n; riêng lu?ng logout thì không thoát app.
        If NavigationService.ShouldTerminateWhenMainClosed() Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        ' Alt+Left d? quay l?i màn tru?c trong vùng n?i dung chính.
        If e.Alt AndAlso e.KeyCode = Keys.Left Then
            If NavigationService.GoBackInMain() Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

End Class
