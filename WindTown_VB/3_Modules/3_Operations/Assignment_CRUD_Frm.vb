Public Class Assignment_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Assignment


    Private _positionsWithoutAssignment As List(Of Position) 'dùng chức vị để phân công vào dự án
    Private _projectsIsActive As List(Of Project)

    Public Sub New(data As Assignment, Optional isCreate As Boolean = False)

        InitializeComponent()
        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm phân công", "Chi tiết phân công")
        InitComboBox()

        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()
        ' ===== Status =====
        ui_status.DataSource = New BindingSource(Assignment.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_role.DataSource = New BindingSource(Assignment.role_Dict, Nothing)
        ui_role.DisplayMember = "Value"
        ui_role.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        Dim response = AppServices.Instance.PositionSV.GetWithoutAssignment()
        If Not response.IsSuccess Then
            MessageBox.Show(response.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tool_save.Enabled = False
            Return
        End If
        _positionsWithoutAssignment = If(response.IsSuccess, response.Data, New List(Of Position))

        ui_employee.DataSource = _positionsWithoutAssignment.Select(Function(x) New With {.Display = x.employee_UI, .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        response = AppServices.Instance.ProjectSV.GetActive()
        If Not response.IsSuccess Then
            MessageBox.Show(response.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tool_save.Enabled = False
            Return
        End If
        _projectsIsActive = If(response.IsSuccess, response.Data, New List(Of Project))
        ui_project.DataSource = _projectsIsActive.Select(Function(x) New With {.Display = x.project_UI, .Value = x}).ToList()
        ui_project.DisplayMember = "Display"
        ui_project.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_project.SelectedIndex = -1
            ui_employee.SelectedIndex = -1
        Else
            ui_position.Text = _data.Position.code
            ui_position.Enabled = False

            ui_contract.Text = _data.Position?.contract_UI
            ui_contract.Enabled = False

            ui_employee.DropDownStyle = ComboBoxStyle.DropDown
            ui_employee.Text = _data.Position?.employee_UI
            ui_employee.Enabled = False

            ui_job.Text = _data.Position?.job_UI
            ui_job.Enabled = False

            ui_level.Text = _data.Position?.level_UI
            ui_level.Enabled = False

            ui_project.DropDownStyle = ComboBoxStyle.DropDown
            ui_project.Text = _data.project_UI
            ui_project.Enabled = False


        End If

        ui_code.Text = _data.code
        ui_role.SelectedValue = _data.role
        ui_start_date.Value = _data.start_date
        ui_end_date.Value = If(_data.end_date, DateTime.Now)

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status


    End Sub

    Protected Overrides Function SyncUIToData() As Boolean
        Try
            If String.IsNullOrWhiteSpace(ui_code.Text) Then
                MessageBox.Show("Mã phân công không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ui_code.Focus()
                Return False
            End If
            If AppServices.Instance.AssigmentSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
                MessageBox.Show("Mã phân công này đã tồn tại.")
                Return False
            End If

            If isCreate Then
                If ui_project.SelectedValue Is Nothing OrElse ui_role.SelectedValue Is Nothing OrElse ui_employee.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn đầy Dự án, quyền, nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                _data.project_id = CType(ui_project.SelectedValue, Project).id
                _data.Project = CType(ui_project.SelectedValue, Project)
                _data.position_id = CType(ui_employee.SelectedValue, Position).id
                _data.Position = CType(ui_employee.SelectedValue, Position)
            End If

            If AppServices.Instance.AssigmentSV.IsConflictStatusActive(_data.position_id, If(isCreate, 0, _data.id)) Then
                MessageBox.Show("Nhân viên/Chức vụ này hiện đang tham gia một dự án khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            _data.code = ui_code.Text.Trim()
            _data.start_date = ui_start_date.Value
            _data.end_date = ui_end_date.Value
            _data.role = ui_role.SelectedValue

            _data.note = If(String.IsNullOrWhiteSpace(ui_note.Text.Trim()),
            $"{_data.Project?.name} + {_data.job_UI} + {_data.level_UI}",
            ui_note.Text.Trim())

            _data.status = CInt(ui_status.SelectedValue)

            ' Logic kiểm tra ngày tháng
            If _data.start_date > _data.end_date Then
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi đồng bộ dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Protected Overrides Sub DataChanged() _
        Handles ui_code.TextChanged,
                ui_project.SelectedValueChanged,
                ui_role.SelectedValueChanged,
                ui_employee.SelectedValueChanged,
                ui_start_date.ValueChanged,
                ui_end_date.ValueChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub


    Private Sub SnapEmployeeData() Handles ui_employee.SelectedValueChanged, ui_employee.SelectedIndexChanged

        If ui_employee.SelectedIndex = -1 Then
            ui_position.Text = ""
            ui_contract.Text = ""
            ui_job.Text = ""
            ui_level.Text = ""
            Return
        End If

        If ui_employee.SelectedItem Is Nothing Then Return

        Dim item = ui_employee.SelectedItem
        Dim pos As Position = item.Value

        If pos Is Nothing Then
            MessageBox.Show("Nhân viên này ko hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ui_position.Text = pos.code
        ui_contract.Text = pos.contract_UI
        ui_job.Text = pos.job_UI
        ui_level.Text = pos.level_UI

    End Sub

End Class