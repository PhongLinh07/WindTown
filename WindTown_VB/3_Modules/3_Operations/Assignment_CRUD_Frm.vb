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

        ' Lấy tất cả Position chưa có Assignment nào (có thể đang có Assignment nhưng không có Active)

        Dim response = AppServices.Instance.PositionSV.Execute(DataIntent.GetPositionsWithoutAssignment)

        _positionsWithoutAssignment = If(response.IsSuccess, response.Data, New List(Of Position))

        If (_positionsWithoutAssignment.Count = 0) Then
            MessageBox.Show("Không có nhân viên nào rảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tool_save.Enabled = False
            Return
        End If

        ui_employee.DataSource = _positionsWithoutAssignment.Select(Function(x) New With {.Display = $"{x.employee_UI}", .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        response = AppServices.Instance.ProjectSV.Execute(DataIntent.GetProjectsIsActive)

        _projectsIsActive = If(response.IsSuccess, response.Data, New List(Of Project))
        If (_projectsIsActive.Count = 0) Then
            MessageBox.Show("Không có dự án nào đang được triển khai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tool_save.Enabled = False
            Return
        End If
        ui_project.DataSource = _projectsIsActive.Select(Function(x) New With {.Display = $"{x.name} ({x.code})", .Value = x}).ToList()
        ui_project.DisplayMember = "Display"
        ui_project.ValueMember = "Value"
    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()


        If isCreate Then
            ui_project.SelectedIndex = -1
            ui_employee.SelectedIndex = -1
        Else
            ui_position.Text = _data.Position.code
            ui_position.Enabled = False

            ui_contract.Text = _data.Position?.contract_UI
            ui_contract.Enabled = False

            ui_employee.Text = _data.Position?.employee_UI
            ui_employee.Enabled = False

            ui_job.Text = _data.Position?.job_UI
            ui_job.Enabled = False

            ui_level.Text = _data.Position?.level_UI
            ui_level.Enabled = False

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


    ' =============================
    ' Sync UI → Data
    ' =============================
    Protected Overrides Function SyncUIToData() As Boolean
        Try
            ' 1. Validation cơ bản
            If String.IsNullOrWhiteSpace(ui_code.Text) Then
                MessageBox.Show("Max phân công không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ui_code.Focus()
                Return False
            End If

            ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc
            If isCreate Then
                If ui_project.SelectedValue Is Nothing OrElse ui_role.SelectedValue Is Nothing OrElse ui_employee.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn đầy Dự án, quyền, nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Gán các ID quan trọng khi tạo mới
                _data.Project = ui_project.SelectedValue
                _data.Position = ui_employee.SelectedValue
            End If

            ' 2. Gán dữ liệu từ UI vào Model (_data)
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



    ' =============================
    ' Detect Change
    ' =============================
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
            MessageBox.Show("Nhân viên này ko hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ui_position.Text = pos.code
        ui_contract.Text = pos.contract_UI
        ui_job.Text = pos.job_UI
        ui_level.Text = pos.level_UI

    End Sub

End Class