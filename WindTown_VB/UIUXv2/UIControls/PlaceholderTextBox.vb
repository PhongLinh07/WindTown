Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class PlaceholderTextBox
    Inherits TextBox

    Private _placeholder As String = ""
    Private _placeholderColor As Color = Color.Gray
    Private _isPlaceholderActive As Boolean = True

    <Category("Custom")>
    Public Property Placeholder As String
        Get
            Return _placeholder
        End Get
        Set(value As String)
            _placeholder = value
            ShowPlaceholder()
        End Set
    End Property

    <Category("Custom")>
    Public Property PlaceholderColor As Color
        Get
            Return _placeholderColor
        End Get
        Set(value As Color)
            _placeholderColor = value
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ShowPlaceholder()
    End Sub

    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)

        If _isPlaceholderActive Then
            Me.Text = ""
            Me.ForeColor = Color.Black
            _isPlaceholderActive = False
        End If
    End Sub

    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
        ShowPlaceholder()
    End Sub

    Private Sub ShowPlaceholder()
        If String.IsNullOrWhiteSpace(Me.Text) Then
            _isPlaceholderActive = True
            Me.Text = _placeholder
            Me.ForeColor = _placeholderColor
        End If
    End Sub

    Public Overrides Property Text As String
        Get
            If _isPlaceholderActive Then
                Return ""
            End If
            Return MyBase.Text
        End Get
        Set(value As String)
            _isPlaceholderActive = False
            MyBase.Text = value
        End Set
    End Property

End Class