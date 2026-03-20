Public Class Payroll_List_UC
    Inherits BaseList_UC

    Public Delegate Sub PayrollDaChonHandler(sender As Object, payroll As Payroll)
    Public Event PayrollDaChon As PayrollDaChonHandler

    Public Sub New()
        MyBase.New(AppServices.Instance.PayrollSV, "Payroll_List_UC", "Bảng lương")
        InitializeComponent()
        Init(GetType(Payroll))

    End Sub



    Protected Overrides Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim row As DataGridViewRow = _dgv.Rows(e.RowIndex)

        ' Tạo bản sao của đối tượng để tránh sửa trực tiếp trên DataGridView
        Dim data = Utils.DeepClone(CType(row.DataBoundItem, Payroll))

        Dim crud As New Payroll_CRUD_Frm(data)
        If crud.ShowDialog() = DialogResult.OK Then

            Dim result = _service.Update(data)

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
        Dim data As Payroll = New Payroll() ' tạo mới đối tượng với giá trị mặc định

        Dim crud As New Payroll_CRUD_Frm(data, True)
        If crud.ShowDialog() = DialogResult.OK Then

            Dim result = _service.Insert(data)

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


        Dim items As List(Of Payroll) = _dgv.SelectedRows.
                                                Cast(Of DataGridViewRow)().
                                                Select(Function(r) TryCast(r.DataBoundItem, Payroll)).
                                                Where(Function(x) x IsNot Nothing).
                                                ToList()

        Dim result = _service.Delete(items)

        If result.IsSuccess Then
            MessageBox.Show("Delete succeeded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show(result.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadData()

    End Sub

    Protected Overrides Sub Dgv_SelectionChanged(sender As Object, e As EventArgs)
        MyBase.Dgv_SelectionChanged(sender, e)

        Dim payroll As Payroll = Nothing
        If _dgv IsNot Nothing AndAlso _dgv.SelectedRows.Count > 0 Then
            payroll = TryCast(_dgv.SelectedRows(0).DataBoundItem, Payroll)
        ElseIf _dgv IsNot Nothing AndAlso _dgv.CurrentRow IsNot Nothing Then
            payroll = TryCast(_dgv.CurrentRow.DataBoundItem, Payroll)
        End If

        If payroll IsNot Nothing Then
            RaiseEvent PayrollDaChon(Me, payroll)
        End If
    End Sub
End Class
