Namespace My
    Partial Friend Class MyApplication

        ' Hỗ trợ cập nhật MainForm an toàn từ module dùng chung.
        Public Sub DatMainFormMoi(formMoi As Form)
            If formMoi Is Nothing Then Return
            If Me.MainForm Is formMoi Then Return
            Me.MainForm = formMoi
        End Sub

    End Class
End Namespace
