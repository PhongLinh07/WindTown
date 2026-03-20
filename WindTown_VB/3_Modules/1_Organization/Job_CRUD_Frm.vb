Public Class Job_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Job


    Private _deparments As List(Of Department)

    Private _salary_mult_list_uc As Salary_Mult_List_UC

    Public Sub New(data As Job, Optional isCreate As Boolean = False)

        InitializeComponent()
        InitComboBox()

        Me._data = data
        Me.isCreate = isCreate

        ui_status.DataSource = New BindingSource(Department.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        Me.Text = If(isCreate, "Thêm chức danh", "Chi tiết chức danh")


        BindDataToUI()

        tool_save.Enabled = False

        If isCreate Then
            Return 'chỉ mở khi ko phải tạo
        End If

        grb_salary_mult.Controls.Clear()
        _salary_mult_list_uc = New Salary_Mult_List_UC(_data)
        grb_salary_mult.Controls.Add(_salary_mult_list_uc)
        _salary_mult_list_uc.Dock = DockStyle.Fill
    End Sub

    Private Sub InitComboBox()
        Dim response = AppServices.Instance.DepartmentSV.Execute(DataIntent.GetList)
        _deparments = If(response.IsSuccess, response.Data, New List(Of Department))

        ui_department.DataSource =
            _deparments.
            Select(Function(x) New With {
                .Display = $"{x.code} - {x.name}",
                .Value = x.id
            }).ToList()

        ui_department.DisplayMember = "Display"
        ui_department.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()
        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
        ui_department.SelectedValue = _data.department_id
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean
        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Code cannot be empty")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Name cannot be empty")
            ui_name.Focus()
            Return False
        End If

        If _deparments.All(Function(d) d.id <> Convert.ToInt32(ui_department.SelectedValue)) Then
            MessageBox.Show("Invalid department selected")
            ui_department.Focus()
            Return False
        End If
        If ui_department.SelectedValue IsNot Nothing Then
            _data.Department = _deparments.FirstOrDefault(Function(x) x.id = Convert.ToInt32(ui_department.SelectedValue))
        End If

        Dim selectedId = If(ui_department.SelectedValue, 0)
        Dim dept = _deparments.FirstOrDefault(Function(x) x.id = Convert.ToInt32(selectedId))
        If dept Is Nothing Then
            MessageBox.Show("Invalid Depatment selected")
            ui_department.Focus()
            Return False
        End If
        _data.Department = dept

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.note = ui_note.Text


        If ui_status.SelectedValue IsNot Nothing Then
            _data.status = ui_status.SelectedValue.ToString()
        End If

        Return True
    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                 ui_name.TextChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged,
                                 ui_department.SelectedIndexChanged
        tool_save.Enabled = True
    End Sub
End Class