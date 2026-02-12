Imports WindTown_VB.DatabaseConfig
Imports WindTown_VB.WindTown.Modules.Assignment


Public Class ClientsForm
        Inherits AForm

    Private _cfgModel As New ClientModel()

    Public Sub New()
        InitializeComponent()
        RefreshDgv()
    End Sub

    ' ===== Refresh DGV =====
    Protected Overrides Sub RefreshDgv()
        Dim service As New ClientService()
        Dim _cfgModelResponse As Response(Of ClientModel) = Nothing

        service.Process(EIntent.Selects, _cfgModel, _cfgModelResponse)

        If _cfgModelResponse IsNot Nothing AndAlso _cfgModelResponse.Datas IsNot Nothing Then
            Dgv.DataSource = _cfgModelResponse.Datas
        Else
            Dgv.DataSource = Nothing
        End If
    End Sub


    ' ===== tool_new Click =====
    'Protected Overrides Sub tool_new_Click(sender As Object, e As EventArgs)
    '    Dim data As New ClientModel()

    '    ' Mở form CRUD cho product
    '    Dim crud As New ProductCRUD(data, True)

    '    If crud.ShowDialog() = DialogResult.OK Then
    '        Dim service As New ClientService()
    '        Dim result As Response(Of ClientModel) = Nothing
    '        service.Process(EIntent.Insert, data, result)

    '        If result.IsSuccess Then
    '            MessageBox.Show("Create succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            RefreshDgv()
    '        Else
    '            MessageBox.Show(result.ErrorMessage, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End If
    'End Sub

    ' ===== tool_delete Click =====
    'Protected Overrides Sub tool_delete_Click(sender As Object, e As EventArgs)
    '    If Dgv.SelectedRows.Count = 0 Then
    '        MessageBox.Show("No rows have been selected for deletion yet!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    Dim confirm As DialogResult = MessageBox.Show($"Are you sure delete {Dgv.SelectedRows.Count} record?", "Sure delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If confirm = DialogResult.No Then Return

    '    If TypeOf Dgv.DataSource Is BindingList(Of ClientModel) Then
    '        Dim list As BindingList(Of ClientModel) = CType(Dgv.DataSource, BindingList(Of ClientModel))
    '        Dim service As New ClientService()
    '        Dim dialog As String = "___Log___" & vbCrLf

    '        For Each row As DataGridViewRow In Dgv.SelectedRows
    '            If TypeOf row.DataBoundItem Is ClientModel Then
    '                Dim item As ClientModel = CType(row.DataBoundItem, ClientModel)
    '                service.Process(EIntent.Delete, item, result)
    '                dialog &= $"{item.code}: " & If(result.IsSuccess, "Deleted succeeded!", $"Failed: {result.ErrorMessage}") & vbCrLf
    '            End If
    '        Next

    '        MessageBox.Show(dialog, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        RefreshDgv()
    '    End If
    'End Sub

    ' ===== Dgv_CellDoubleClick =====
    'Protected Overrides Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

    '    Dim row As DataGridViewRow = Dgv.Rows(e.RowIndex)
    '    Dim data As ClientModel = CType(row.DataBoundItem, ClientModel)

    '    Dim crud As New ProductCRUD(data)
    '    If crud.ShowDialog() = DialogResult.OK Then
    '        Dim service As New ClientService()
    '        Dim result As Response(Of ClientModel) = Nothing
    '        service.Process(EIntent.Update, data, result)

    '        If result.IsSuccess Then
    '            MessageBox.Show("Update succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            RefreshDgv()
    '        Else
    '            MessageBox.Show(result.ErrorMessage, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End If
    'End Sub

    ' ===== Dgv_ColumnHeaderMouseClick =====
    Protected Overrides Sub Dgv_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
            Dim columnName As String = Dgv.Columns(e.ColumnIndex).DataPropertyName
            If String.IsNullOrEmpty(columnName) Then Return

            '   _cfgModel.Sort.Field = columnName
            '  _cfgModel.Sort.Ascending = Not _cfgModel.Sort.Ascending
            RefreshDgv()
        End Sub

    End Class
