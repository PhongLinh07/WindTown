Imports System.Data.SqlClient

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = tbxUsername.Text.Trim()
        Dim password As String = tbxPassword.Text.Trim()

        If CheckLogin(username, password) Then
            MessageBox.Show("Đăng nhập thành công!", "Thông báo")

            Dim frm As New frmDashboard()
            frm.Show()

            Me.Hide() ' Ẩn frmLogin thay vì Close
        Else
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi")
        End If
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click, MyBase.Click
        Dim frm As New frmRegister
        frm.Show()
        Me.Hide() ' Ẩn frmLogin khi mở frmRegister
    End Sub
    Private Function CheckLogin(username As String, password As String) As Boolean
        If username = "admin" AndAlso password = "admin" Then
            Return True
        End If
        Return False
    End Function

End Class