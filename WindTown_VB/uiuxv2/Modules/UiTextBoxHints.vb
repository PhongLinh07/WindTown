Imports System.Runtime.InteropServices
Imports System.Windows.Forms

' ============================================================
'  UiTextBoxHints — Gợi ý ô trống (cue banner) cho TextBox WinForms
'  WinForms không có PlaceholderText ổn định trên mọi theme/OS.
' ============================================================
Public Module UiTextBoxHints

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As String) As IntPtr
    End Function

    Private Const EM_SETCUEBANNER As Integer = &H1501

    ''' <summary>Đặt chữ gợi ý khi TextBox rỗng (EM_SETCUEBANNER).</summary>
    Public Sub SetCueBanner(tb As TextBox, hint As String)
        If tb Is Nothing Then Return
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), If(hint, ""))
    End Sub

End Module
