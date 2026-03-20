Public Class Salary_Mult_List_UC
    Inherits BaseList_UC

    Private _job As Job
    Private _lockTarget = False

    Public Sub New()
        MyBase.New(AppServices.Instance.Salary_MultSV, "Salary_Mult_List_UC", "Hệ số lương")
        InitializeComponent()
        Init(GetType(Salary_Mult))

    End Sub
    Public Sub New(job As Job)
        MyBase.New(AppServices.Instance.Salary_MultSV, "Salary_Mult_List_UC", "Hệ số lương")
        InitializeComponent()
        _job = job
        _lockTarget = True

        Init(GetType(Salary_Mult))
    End Sub


    Protected Overrides Sub LoadData()

        If Not _lockTarget Then
            MyBase.LoadData() ' Test
            Return
        End If

        Dim response = _service.Execute(DataIntent.GetSalaryMultItemByJob, _job)
        If response.IsSuccess Then
            ' Gán danh sách vào BindingSource để hỗ trợ lọc (Search)
            _bindingSource.DataSource = response.Data
            _dgv.DataSource = _bindingSource

        Else
            MessageBox.Show(response.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        _dgv.ClearSelection()
        viewSelected.Text = "Rows selected:  0"
        tool_delete.Enabled = False
    End Sub

    Protected Overrides Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim row As DataGridViewRow = _dgv.Rows(e.RowIndex)

        ' Tạo bản sao của đối tượng để tránh sửa trực tiếp trên DataGridView
        Dim data = Utils.DeepClone(CType(row.DataBoundItem, Salary_Mult))

        Dim crud As New Salary_Mult_CRUD_Frm(data)
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
        Dim data As Salary_Mult = New Salary_Mult With {.Job = _job} ' tạo mới đối tượng với giá trị mặc định

        Dim crud As New Salary_Mult_CRUD_Frm(data, True)
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


        Dim items As List(Of Salary_Mult) = _dgv.SelectedRows.
                                                Cast(Of DataGridViewRow)().
                                                Select(Function(r) TryCast(r.DataBoundItem, Salary_Mult)).
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
