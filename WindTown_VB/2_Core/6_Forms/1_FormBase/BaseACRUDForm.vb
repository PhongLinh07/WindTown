Imports System.Net.NetworkInformation
Imports System.Text

Partial Public Class BaseACRUDForm
    Inherits Form

    Protected isCreate As Boolean = False
    Protected isConfirm As Boolean = False

    Public Sub New()
        InitializeComponent()

        tool_save.Enabled = False

        ' Các toolbar mặc định ẩn, lớp con có thể bật
        ' tool_reassignment.Visible = False
        ' tool_initPeriod.Visible = False
        ' tool_calSalary.Visible = False
        ' tool_netSalary.Visible = False
    End Sub

    ' ===== FormClosing Event =====
    Protected Overridable Sub ACRUDForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isConfirm Then Return ' Xác nhận bằng nút tool_save

        Dim result As DialogResult = MessageBox.Show("Đóng và không lưu những gì thay đổi ?", "Xác nhận đóng", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            e.Cancel = True ' Hủy đóng form
        Else
            Me.DialogResult = DialogResult.No
        End If
    End Sub

    ' ===== tool_save Click =====
    Protected Overridable Sub BindDataToUI()

    End Sub
    Protected Overridable Function SyncUIToData() As Boolean
        Return True
    End Function
    Protected Overridable Sub DataChanged()

    End Sub


    Private Sub tool_save_Click(sender As Object, e As EventArgs) Handles tool_save.Click
        If Not SyncUIToData() Then
            tool_save.Enabled = False
            Return
        End If

        Me.DialogResult = DialogResult.OK
        isConfirm = True
        Me.Close()
    End Sub

    '' ===== tool_reassignment Click =====
    'Protected Overridable Sub tool_reassignment_Click(sender As Object, e As EventArgs) Handles tool_reassignment.Click
    '    ' Lớp con override
    'End Sub

    '' ===== tool_initPeriod Click =====
    'Protected Overridable Sub tool_initPeriod_Click(sender As Object, e As EventArgs) Handles tool_initPeriod.Click
    '    ' Lớp con override
    'End Sub

    '' ===== tool_calSalary Click =====
    'Protected Overridable Sub tool_calSalary_Click(sender As Object, e As EventArgs) Handles tool_calSalary.Click
    '    ' Lớp con override
    'End Sub

    '' ===== tool_netSalary Click =====
    'Protected Overridable Sub tool_netSalary_Click(sender As Object, e As EventArgs) Handles tool_netSalary.Click
    '    ' Lớp con override
    'End Sub

End Class