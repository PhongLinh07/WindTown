Public Class frmMain
    ' Ghi chu: cap nhat nho theo yeu cau, khong thay doi logic (frmHopDong update).

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        HoTroPhongChu.ApDungPhongChu(Me)
        NavigationService.Initialize(Me, pnlMain)

        UcSidebar1.SetMainPanel(pnlMain)

        Me.KeyPreview = True

        NavigationService.NavigateInMain(Of frmDashboard)(False)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
#If DEBUG Then
        ' Ghi log danh s�ch form c�n m? d? truy v?t khi ?ng d?ng kh�ng tho�t.
        Dim openForms = Application.OpenForms.Cast(Of Form)().Select(Function(f) f.Name).ToArray()
        System.Diagnostics.Debug.WriteLine("[frmMain.FormClosing] OpenForms: " & String.Join(", ", openForms))
#End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' ��ng frmMain b?ng n�t t?t th� tho�t h?n; ri�ng lu?ng logout th� kh�ng tho�t app.
        If NavigationService.ShouldTerminateWhenMainClosed() Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        ' Alt+Left d? quay l?i m�n tru?c trong v�ng n?i dung ch�nh.
        If e.Alt AndAlso e.KeyCode = Keys.Left Then
            If NavigationService.GoBackInMain() Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

End Class


