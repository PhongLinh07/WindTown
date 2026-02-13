Imports WindTown_VB.DatabaseConfig

Public Class Department_List
    Inherits BaseListForm(Of Department)

    Public Sub New()
        MyBase.New(New BaseService(Of Department), "Department")
    End Sub

    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dgv.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim row As DataGridViewRow = _dgv.Rows(e.RowIndex)
        Dim data As Department = CType(row.DataBoundItem, Department)

        Dim crud As New Department_CRUD(data)
        If crud.ShowDialog() = DialogResult.OK Then

            Dim result = _service.Execute(DataIntent.Update, data)


            If result.IsSuccess Then
                MessageBox.Show("Update succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' RefreshDgv()
            Else
                MessageBox.Show(result.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class