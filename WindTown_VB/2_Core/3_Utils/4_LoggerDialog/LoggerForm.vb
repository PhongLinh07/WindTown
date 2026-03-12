Public Class LoggerForm

    Public Sub New()
        InitializeComponent()
        _output.ReadOnly = True
    End Sub

    Public Sub AppendLog(ByRef message As String, Optional clr As Color? = Nothing)

        If String.IsNullOrEmpty(message) Then Return

        ' Di chuyển caret tới cuối RichTextBox
        _output.SelectionStart = _output.TextLength
        _output.SelectionLength = 0

        ' Set màu chữ
        _output.SelectionColor = If(clr, Color.Black)

        ' Append message
        _output.AppendText(message & Environment.NewLine)

        ' Reset màu về mặc định
        _output.SelectionColor = _output.ForeColor

        ' Scroll xuống cuối
        _output.ScrollToCaret()

    End Sub


    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)

        ' Ẩn form thay vì đóng
        e.Cancel = True
        Me.Hide()

        MyBase.OnFormClosing(e)

    End Sub


    Private Sub tool_clear_Click(sender As Object, e As EventArgs) Handles tool_clear.Click
        _output.Clear()
    End Sub

End Class