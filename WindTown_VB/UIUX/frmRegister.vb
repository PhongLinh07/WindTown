
Public Class frmRegister
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        ErrorProvider1.Clear()

        Dim username As String = tbxUsername.Text.Trim()
        Dim password As String = tbxPassword.Text.Trim()
        Dim confirmPassword As String = tbxAcceptPassword.Text.Trim()

        Dim isValid As Boolean = True

        If username = "" Then
            ErrorProvider1.SetError(tbxUsername, "Vui lòng nhập tên đăng nhập")
            isValid = False
        End If

        If password = "" Then
            ErrorProvider1.SetError(tbxPassword, "Vui lòng nhập mật khẩu")
            isValid = False
        End If

        If confirmPassword = "" Then
            ErrorProvider1.SetError(tbxAcceptPassword, "Vui lòng xác nhận mật khẩu")
            isValid = False
        End If

        If password <> "" AndAlso confirmPassword <> "" AndAlso password <> confirmPassword Then
            ErrorProvider1.SetError(tbxAcceptPassword, "Mật khẩu xác nhận không khớp")
            isValid = False
        End If

        If Not isValid Then Return

        If checkRegister(username, password) Then
            MessageBox.Show("Đăng ký thành công!")

            Dim frm As New frmLogin()
            frm.Show()
            'Me.Close()
        Else
            ErrorProvider1.SetError(tbxUsername, "Tên đăng nhập đã tồn tại")
        End If
    End Sub

    Private Function checkRegister(username As String, password As String) As Boolean
        ' Giả sử chỉ có một tài khoản admin đã tồn tại
        If username = "admin" Then
            Return False
        End If
        Return True
    End Function
End Class