Public Class Developer_Mode
    Private Sub btn_backend_Click(sender As Object, e As EventArgs) Handles btn_backend.Click
        Dim f As New FormMain()
        f.Show()
        Me.Close() ' Đóng hẳn Form chọn, giải phóng bộ nhớ ngay lập tức
    End Sub

    Private Sub btn_fontend_Click(sender As Object, e As EventArgs) Handles btn_fontend.Click
        Dim f As New frmLogin()
        f.Show()
        Me.Close() ' Đóng hẳn Form chọn, giải phóng bộ nhớ ngay lập tức
    End Sub
End Class