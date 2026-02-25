Imports Microsoft.Data.Common

Partial Public Class FormMain
    Inherits Form

    Private currentForm As UserControl = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    '-----------------------------------------
    ' Mở Child Form
    Private Sub OpenChildForm(childForm As UserControl)
        If currentForm IsNot Nothing Then
            pnl_main.Controls.Remove(currentForm)
        End If

        currentForm = childForm
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

        Dim frm As New Department_List_UC()
        OpenChildForm(frm)
    End Sub
End Class