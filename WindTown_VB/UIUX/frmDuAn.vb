Public Class frmDuAn
    Private Sub btnTaoDuAn_Click(sender As Object, e As EventArgs) Handles btnTaoDuAn.Click
        Dim f As New frmDuAnEdit
        f.ShowDialog()
    End Sub
End Class