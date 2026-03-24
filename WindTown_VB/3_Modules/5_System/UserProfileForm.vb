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

    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim result As DialogResult = MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            _parent.Close()
            NavigationService.SwitchToForm(Me, New frmLogin())
        End If

    End Sub

End Class