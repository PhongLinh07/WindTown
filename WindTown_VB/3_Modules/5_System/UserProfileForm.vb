Public Class UserProfileForm

    Private _inited As Boolean = False
    Private _parent As Form = Nothing
    Public Sub New(form As Form)
        InitializeComponent()

        If UserProfile.User Is Nothing Then
            Return
        End If

        ui_employee.Text = UserProfile.User.employee_UI
        ui_user.Text = UserProfile.User.user
        ui_role.Text = UserProfile.User.role_UI

        _parent = form

        ui_selectUI.Visible = (UserProfile.User.role = Account.ROLE_ADM)
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim result As DialogResult = MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            If UserProfile.Is_User Then
                NavigationService.LogoutToLogin(Me)
                Return
            End If
            _parent.Close()
            NavigationService.SwitchTopLevel(Of formLoginV2)(_parent)
            Me.Close()
        End If

    End Sub

    Private Sub btn_ui_user_Click(sender As Object, e As EventArgs) Handles btn_ui_user.Click
        If UserProfile.Is_User Then
            Return
        End If
        UserProfile.SwitchUser()
        frmMain.Instance?.Show()
        _parent.Close()
        Me.Close()
    End Sub

    Private Sub btn_ui_dev_Click(sender As Object, e As EventArgs) Handles btn_ui_dev.Click
        If UserProfile.Is_Dev Then
            Return
        End If
        UserProfile.SwitchDev()
        Dim frm = New FormMain()
        frm.Show()
        _parent.Hide()
        Me.Close()
    End Sub
End Class