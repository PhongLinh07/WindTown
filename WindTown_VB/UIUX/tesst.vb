Public Class tesst
    Dim Lab As New Label
    Dim TextBox As New TextBox
    Private Sub tesst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lab.Text = "Hello World"
        Lab.Location = New Point(50, 50)
        Me.Controls.Add(Lab)

        TextBox.Location = New Point(50, 100)
        TextBox.Text = "Nhập gì đó vào đây"
        Me.Controls.Add(TextBox)


        Lab.Text = TextBox.Text
    End Sub


End Class