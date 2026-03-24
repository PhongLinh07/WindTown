Public Class frmLogin

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Đăng nhập"

        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Lỗi kết nối CSDL: " & bootstrap.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnLogin.Enabled = False
            'btnRegister.Enabled = False
            Return
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = tbxUsername.Text.Trim()
        Dim password As String = tbxPassword.Text.Trim()

        If Not KiemTraDuLieuDangNhap(username, password) Then
            Return
        End If

        Dim response = CheckLogin(username, password)
        If Not response.IsSuccess Then
            MessageBox.Show(response.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim acc = CType(response.Data, Account)
        If acc Is Nothing Then
            MessageBox.Show("Không tìm thấy thông tin tài khoản sau đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        UserProfile.User = acc
        NavigationService.SwitchToForm(Me, New FormMain())

    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs)
    End Sub

    Private Function CheckLogin(username As String, password As String) As ServiceResponse(Of Object)
        Dim result = AppServices.Instance.AccountSV.Login(New Account With {.user = username, .password = password})
        Return result
    End Function

    Private Function KiemTraDuLieuDangNhap(username As String, password As String) As Boolean
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Vui lòng nhập mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxPassword.Focus()
            Return False
        End If

        Return True
    End Function

End Class
