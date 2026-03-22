Public Class Logger

    Public Shared ReadOnly Information As Color = Color.Black
    Public Shared ReadOnly Warning As Color = Color.Orange
    Public Shared ReadOnly [Error] As Color = Color.Red
    Public Shared ReadOnly Success As Color = Color.Green

    Private Shared ReadOnly _instance As New Logger()

    Public Shared ReadOnly Property Instance As Logger
        Get
            Return _instance
        End Get
    End Property

    Private _form As LoggerForm = New LoggerForm()

    Protected Sub New()
        _form.Hide()
    End Sub

    Public Sub Show()

        If _form Is Nothing OrElse _form.IsDisposed Then

            _form = New LoggerForm()
            _form.Show()
            _form.TopLevel = True

        Else

            _form.Visible = Not _form.Visible

        End If

    End Sub

    Public Sub Logging(message As String, Optional color As Color? = Nothing)

        If String.IsNullOrEmpty(message) Then Return

        If Not _form.Visible Then
            _form.Show()
            _form.TopLevel = True
        End If


        _form.TopLevel = True
        _form.AppendLog(message, color)

    End Sub
    Public Sub Quit()

        _form.Close()

    End Sub

End Class
