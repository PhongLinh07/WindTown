Imports System.Data.SqlClient
Public Class frmLogin

    Dim account As List(Of Account) = New List(Of Account)

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Khong the ket noi database: " & bootstrap.Message, "Loi ket noi DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnLogin.Enabled = False
            btnRegister.Enabled = False
            Return
        End If

        loadAccount()
    End Sub
    Private Sub loadAccount()
        Dim accountSV = New AccountService()
        Dim result = accountSV.Execute(DataIntent.GetList)
        If result.IsSuccess Then
            account = CType(result.Data, List(Of Account))
        Else
            MessageBox.Show("Khong the tai danh sach tai khoan: " & If(result.Message, "Loi khong xac dinh."), "Loi du lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = tbxUsername.Text.Trim()
        Dim password As String = tbxPassword.Text.Trim()

        If CheckLogin(username, password) Then
            MessageBox.Show("Đăng nhập thành công!", "Thất bại")

            NavigationService.SwitchTopLevel(Of frmMain)(Me)
        Else
            MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Nhập lại")
        End If
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        NavigationService.SwitchTopLevel(Of frmRegister)(Me)
    End Sub
    Private Function CheckLogin(username As String, password As String) As Boolean
        Return account.Any(Function(acc) acc.user = username AndAlso acc.password = password)
    End Function

End Class
