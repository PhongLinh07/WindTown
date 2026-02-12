Partial Public Class FormMain
    Inherits Form

    Private currentForm As Form = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    '-----------------------------------------
    ' Mở Child Form
    Private Sub OpenChildForm(childForm As Form)
        If currentForm IsNot Nothing Then
            currentForm.Close()
        End If

        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        pnl_main.Controls.Add(childForm)
        pnl_main.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub


    Private Sub menuItem_Product_Click(sender As Object, e As EventArgs) Handles menuItem_Product.Click
        If currentForm IsNot Nothing AndAlso currentForm.Name = "ProductsForm" Then Return
        OpenChildForm(New ProductsForm())
    End Sub

    Private Sub menuItem_Client_Click(sender As Object, e As EventArgs) Handles menuItem_Client.Click
        If currentForm IsNot Nothing AndAlso currentForm.Name = "ClientsForm" Then Return
        OpenChildForm(New ClientsForm())
    End Sub


End Class