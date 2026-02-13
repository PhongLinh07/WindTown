Imports Microsoft.Data.Common

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


    Private Sub menuItem_Product_Click(sender As Object, e As EventArgs)
        If currentForm IsNot Nothing AndAlso currentForm.Name = "ProductsForm" Then Return
        ' //' OpenChildForm(New ProductsForm())
    End Sub

    Private Sub menuItem_Department_Click(sender As Object, e As EventArgs) Handles menuItem_Department.Click
        ' If currentForm IsNot Nothing AndAlso currentForm.Name = "" Then Return

        Dim frm As New Department_List()
        OpenChildForm(frm)
    End Sub
End Class