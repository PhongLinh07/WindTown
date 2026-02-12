Partial Public Class AForm
    Inherits Form

    Public Sub New()
        InitializeComponent()
        Dgv.AutoGenerateColumns = True
        Dgv.ReadOnly = True
    End Sub

    ' ===== Refresh Dgv =====
    Protected Overridable Sub RefreshDgv()
        Dgv.ClearSelection()
        viewSelected.Text = "Rows selected:  0"
        tool_delete.Enabled = False
    End Sub


    '#Region "Form Event"
    Protected Overridable Sub BaseForm_Click(sender As Object, e As EventArgs)
        Dgv.ClearSelection()
        viewSelected.Text = "Rows selected:  0"
        tool_delete.Enabled = False
    End Sub
    '#End Region


    '#Region "Tool Menu Trip"
    Protected Overridable Sub tool_new_Click(sender As Object, e As EventArgs) Handles tool_new.Click
        ' TODO: implement
    End Sub

    Protected Overridable Sub tool_delete_Click(sender As Object, e As EventArgs) Handles tool_delete.Click
        ' TODO: implement
    End Sub

    Protected Overridable Sub tool_filter_Click(sender As Object, e As EventArgs)
        ' TODO: implement
    End Sub
    '#End Region


    '#Region "Dgv Event"
    Protected Overridable Sub Dgv_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv.SelectionChanged
        viewSelected.Text = $"Rows selected:  {Dgv.SelectedRows.Count}"
        tool_delete.Enabled = Dgv.SelectedRows.Count > 0
    End Sub

    Protected Overridable Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellDoubleClick
        ' TODO: implement
    End Sub

    Protected Overridable Sub Dgv_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        ' TODO: implement
    End Sub
    '#End Region


    Private Sub tool_refresh_Click(sender As Object, e As EventArgs)
        RefreshDgv()
    End Sub


End Class
