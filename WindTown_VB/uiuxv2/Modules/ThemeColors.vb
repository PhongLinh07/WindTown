Imports System.Drawing

' ============================================================
'  ThemeColors — Bảng màu dùng chung uiuxv2 (đồng bộ design system)
' ============================================================
Public NotInheritable Class ThemeColors

    ''' <summary>Palette avatar vòng tròn / DataGridView (8 màu cố định).</summary>
    Public Shared ReadOnly AvatarPalette As Color() = {
        Color.FromArgb(74, 158, 255), Color.FromArgb(123, 97, 255),
        Color.FromArgb(76, 175, 80), Color.FromArgb(245, 158, 11),
        Color.FromArgb(224, 85, 85), Color.FromArgb(38, 198, 218),
        Color.FromArgb(236, 72, 153), Color.FromArgb(249, 115, 22)
    }

    Private Sub New()
    End Sub

End Class
