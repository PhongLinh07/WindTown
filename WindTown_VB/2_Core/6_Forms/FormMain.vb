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


    Private Sub menu_department_Click(sender As Object, e As EventArgs) Handles menu_department.Click
        Dim frm As New Department_List_UC()
        OpenChildForm(frm)
    End Sub

    Private Sub menu_job_Click(sender As Object, e As EventArgs) Handles menu_job.Click
        Dim frm As New Job_List_UC()
        OpenChildForm(frm)
    End Sub

    Private Sub menu_level_Click(sender As Object, e As EventArgs) Handles menu_level.Click
        Dim frm As New Level_List_UC()
        OpenChildForm(frm)
    End Sub

    Private Sub menu_employee_Click(sender As Object, e As EventArgs) Handles menu_employee.Click
        Dim frm As New Employee_List_UC()
        OpenChildForm(frm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Account_List_UC()
        OpenChildForm(frm)
    End Sub
End Class