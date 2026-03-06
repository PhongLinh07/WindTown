Public Class Account_List_UC
    Inherits BaseList_UC

    Public Sub New()
        MyBase.New(New AccountService(), "Tài khoản")
        InitializeComponent()
        Init(GetType(Account))

    End Sub



    Protected Overrides Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim row As DataGridViewRow = _dgv.Rows(e.RowIndex)

        ' Tạo bản sao của đối tượng để tránh sửa trực tiếp trên DataGridView
        Dim data = Utils.DeepClone(CType(row.DataBoundItem, Account))

        Dim crud As New Account_CRUD_Frm(data)
        If crud.ShowDialog() = DialogResult.OK Then

            Dim result = _service.Execute(DataIntent.Update, data)

            If result.IsSuccess Then
                MessageBox.Show("Update succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Else
                MessageBox.Show(result.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Protected Overrides Sub tool_new_Click(sender As Object, e As EventArgs)
        ' Tạo bản sao của đối tượng để tránh sửa trực tiếp trên DataGridView
        Dim data = New Account() ' tạo mới đối tượng với giá trị mặc định

        Dim crud As New Account_CRUD_Frm(data, True)
        If crud.ShowDialog() = DialogResult.OK Then

            Dim result = _service.Execute(DataIntent.Insert, data)

            If result.IsSuccess Then
                MessageBox.Show("Insert succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Else
                MessageBox.Show(result.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Protected Overrides Sub tool_delete_Click(sender As Object, e As EventArgs)

        If _dgv.SelectedRows.Count = 0 Then
            MessageBox.Show("No rows selected", "Notification")
            Return
        End If

        If MessageBox.Show($"Delete {_dgv.SelectedRows.Count} record?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then Return


        Dim items As List(Of Account) = _dgv.SelectedRows.
                                                Cast(Of DataGridViewRow)().
                                                Select(Function(r) TryCast(r.DataBoundItem, Account)).
                                                Where(Function(x) x IsNot Nothing).
                                                ToList()

        Dim result = _service.Execute(DataIntent.SoftDeleteMany, items)

        If result.IsSuccess Then
            MessageBox.Show("Delete succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show(result.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadData()

    End Sub
End Class
