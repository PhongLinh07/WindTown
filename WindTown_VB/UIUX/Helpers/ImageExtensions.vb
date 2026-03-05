Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

Module ImageExtensions
    <Extension()>
    Public Sub ResizeImageControl(ctrl As Control)

        If ctrl.BackgroundImage Is Nothing Then Exit Sub

        Dim img = ctrl.BackgroundImage
        Dim newWidth = ctrl.Width
        Dim newHeight = ctrl.Height

        Dim bmp As New Bitmap(newWidth, newHeight)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using

        ctrl.BackgroundImage = bmp

    End Sub
    <Extension()>
    Public Sub ResizeImageCol(col As DataGridViewImageColumn)

        If col.Image Is Nothing Then Exit Sub

        Dim size As Integer = 20

        Dim bmp As New Bitmap(size, size)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(col.Image, 0, 0, size, size)
        End Using

        col.Image = bmp

    End Sub

    <Extension()>
    Public Sub ResizeImageButton(btn As Button)

        If btn.Image Is Nothing Then Exit Sub

        Dim bmp As New Bitmap(btn.Width - 6, btn.Height - 6)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.DrawImage(btn.Image, 0, 0, bmp.Width, bmp.Height)
        End Using

        btn.Image = bmp

    End Sub
End Module
