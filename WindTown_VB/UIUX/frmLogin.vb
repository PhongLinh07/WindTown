Public Class frmLogin
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Lỗi kết nối CSDL: " & bootstrap.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnLogin.Enabled = False
            btnRegister.Enabled = False
            Return
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = tbxUsername.Text.Trim()
        Dim password As String = tbxPassword.Text.Trim()

        If Not KiemTraDuLieuDangNhap(username, password) Then
            Return
        End If

        If CheckLogin(username, password) Then
            Dim repo As New AccountRepository()
            Dim acc = repo.GetAccountByUsername(New Account With {.user = username})

            NguoiDungHienTaiService.GanTaiKhoanDangNhap(acc)

            MessageBox.Show("Đăng nhập thành công!", "Thành công")

            ' 🔐 Phân quyền theo role
            Select Case acc.role
                Case 1 ' Admin / Developer
                    NavigationService.SwitchTopLevel(Of Developer_Mode)(Me)
                    Return

                Case 2 ' User thường
                    NavigationService.SwitchTopLevel(Of frmMain)(Me)
                    Return
                Case Else
                    MessageBox.Show("Tài khoản không có quyền truy cập!", "Lỗi")
            End Select
        Else
            MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Nhập lại")
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        'NavigationService.SwitchTopLevel(Of frmRegister)(Me)
    End Sub

    Private Function CheckLogin(username As String, password As String) As Boolean

        Dim accService As AccountService = New AccountService()
        Dim result = accService.Execute(DataIntent.Login, New Account With {.user = username, .password = password})
        Return result.IsSuccess
    End Function

    Private Function KiemTraDuLieuDangNhap(username As String, password As String) As Boolean
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thiếu thông tin")
            tbxUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Vui lòng nhập mật khẩu.", "Thiếu thông tin")
            tbxPassword.Focus()
            Return False
        End If

        Return True
    End Function

End Class
