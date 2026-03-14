Public Class Position_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Position


    Private _contracsWithoutPosition As List(Of Contract)
    Private _jobs As List(Of Job)
    Private _levels As List(Of Level)


    Public Sub New(data As Position, Optional isCreate As Boolean = False)

        InitializeComponent()
        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm mới chức vụ", "Chi tiết chức vụ")
        InitComboBox()

        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()
        ' ===== Status =====
        ui_status.DataSource = New BindingSource(Position.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        ' Lấy tất cả nhân viên chưa có vị trí nào (có thể đang có hợp đồng nhưng không có vị trí)
        Dim contracService As New ContractService()
        Dim response = contracService.Execute(DataIntent.GetContractsWithoutPosition)
        _contracsWithoutPosition = If(response.IsSuccess, response.Data, New List(Of Contract))

        If (_contracsWithoutPosition.Count = 0) Then
            MessageBox.Show("Không có hợp đồng nào đang hoạt động mà chưa được gán vị trí. Vui lòng tạo hợp đồng trước khi tạo vị trí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tool_save.Enabled = False
            Return
        End If


        ui_contract.DataSource = _contracsWithoutPosition.Select(Function(x) New With {.Display = $"{x.code}", .Value = x}).ToList()
        ui_contract.DisplayMember = "Display"
        ui_contract.ValueMember = "Value"

        ui_employee.DataSource = _contracsWithoutPosition.Select(Function(x) New With {.Display = $"{x.Employee.code} - {x.Employee.name}", .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        Dim jobService As New JobService()
        response = jobService.Execute(DataIntent.GetList)
        _jobs = If(response.IsSuccess, response.Data, New List(Of Job))

        ui_job.DataSource = _jobs.Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x}).ToList()
        ui_job.DisplayMember = "Display"
        ui_job.ValueMember = "Value"

        Dim levelService As New BaseService(Of Level)
        response = levelService.Execute(DataIntent.GetList)
        _levels = If(response.IsSuccess, response.Data, New List(Of Level))

        ui_level.DataSource = _levels.Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x}).ToList()
        ui_level.DisplayMember = "Display"
        ui_level.ValueMember = "Value"

    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()


        If isCreate Then
            ui_contract.SelectedIndex = -1
            ui_employee.SelectedIndex = -1
            ui_job.SelectedIndex = -1
            ui_level.SelectedIndex = -1

        Else
            ui_contract.Text = _data.Contract_UI
            ui_contract.Enabled = False

            ui_employee.Text = _data.employee_UI
            ui_employee.Enabled = False

            ui_job.Text = _data.job_UI
            ui_job.Enabled = False

            ui_level.Text = _data.level_UI
            ui_level.Enabled = False

        End If

        ui_code.Text = _data.code

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
                MessageBox.Show("Vui lòng nhập mã vị trí (Code)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc
            If isCreate Then
                If ui_contract.SelectedValue Is Nothing OrElse ui_job.SelectedValue Is Nothing OrElse ui_level.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn đầy đủ Hợp đồng, Công việc và Cấp độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Gán các ID quan trọng khi tạo mới
                _data.Contract = ui_contract.SelectedValue
                _data.Job = ui_job.SelectedValue
                _data.Level = ui_level.SelectedValue
            End If

            ' 2. Gán dữ liệu từ UI vào Model (_data)
            _data.code = ui_code.Text.Trim()
            _data.start_date = ui_start_date.Value
            _data.end_date = ui_end_date.Value
            _data.note = ui_note.Text.Trim()
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
        Handles ui_contract.SelectedValueChanged,
                ui_job.SelectedValueChanged,
                ui_level.SelectedValueChanged,
                ui_code.TextChanged,
                ui_start_date.ValueChanged,
                ui_end_date.ValueChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub


End Class