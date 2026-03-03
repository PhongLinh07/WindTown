Public Class frmHopDong
    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        loadControls()
    End Sub

    Private Sub loadControls()
        btnSearch.Image = ResizeImage(My.Resources.search, 26, 26)
    End Sub
    Private Function ResizeImage(img As Image, newWidth As Integer, newHeight As Integer) As Image
        Dim bmp As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return bmp
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub
End Class