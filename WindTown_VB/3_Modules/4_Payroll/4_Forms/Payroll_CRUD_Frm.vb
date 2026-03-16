Public Class Payroll_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Payroll


    Private _positions As List(Of Position) 'dùng chức vị để phân công vào dự án
    Private _payPeriod As List(Of Pay_Period)

    Private _pay_item_list_uc As Pay_Item_List_UC

    Public Sub New(data As Payroll, Optional isCreate As Boolean = False)

        InitializeComponent()
        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm bảng lương", "Bảng lương chi tiết")
        InitComboBox()

        BindDataToUI()

        tool_save.Enabled = False


        If isCreate Then
            Return 'chỉ mở khi ko phải tạo
        End If
        tool_net_salary.Visible = True

        grb_pay_item.Controls.Clear()
        _pay_item_list_uc = New Pay_Item_List_UC(_data)
        grb_pay_item.Controls.Add(_pay_item_list_uc)
        _pay_item_list_uc.Dock = DockStyle.Fill
    End Sub

    Private Sub InitComboBox()
        ' ===== Status =====
        ui_status.DataSource = New BindingSource(Payroll.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        ' Lấy tất cả Position chưa có Assignment nào (có thể đang có Assignment nhưng không có Active)
        Dim positionService As New PositionService()
        Dim response = positionService.Execute(DataIntent.GetList)

        _positions = If(response.IsSuccess, response.Data, New List(Of Position))

        If (_positions.Count = 0) Then
            MessageBox.Show("Không có nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tool_save.Enabled = False
            Return
        End If

        ui_employee.DataSource = _positions.Select(Function(x) New With {.Display = $"{x.employee_UI}", .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        Dim payPeriodService As New Pay_PeriodService()
        response = payPeriodService.Execute(DataIntent.GetList)

        _payPeriod = If(response.IsSuccess, response.Data, New List(Of Pay_Period))
        If (_payPeriod.Count = 0) Then
            MessageBox.Show("Không có bảng lương nào đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tool_save.Enabled = False
            Return
        End If
        ui_pay_period.DataSource = _payPeriod.Select(Function(x) New With {.Display = $"{x.name} ({x.code})", .Value = x}).ToList()
        ui_pay_period.DisplayMember = "Display"
        ui_pay_period.ValueMember = "Value"
    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()


        If isCreate Then
            ui_pay_period.SelectedIndex = -1
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

            ui_pay_period.Text = _data.pay_period_UI
            ui_pay_period.Enabled = False


        End If

        ui_code.Text = _data.code
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
                MessageBox.Show("Mã bản lương không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ui_code.Focus()
                Return False
            End If

            ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc
            If isCreate Then
                If ui_pay_period.SelectedValue Is Nothing OrElse ui_employee.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn đầy đủ chu kỳ lương, nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Gán các ID quan trọng khi tạo mới
                _data.Pay_Period = ui_pay_period.SelectedValue
                _data.Position = ui_employee.SelectedValue
            End If

            ' 2. Gán dữ liệu từ UI vào Model (_data)
            _data.code = ui_code.Text.Trim()

            _data.note = If(String.IsNullOrWhiteSpace(ui_note.Text.Trim()),
            $"{_data.Pay_Period?.name} + {_data.Position?.employee_UI}",
            ui_note.Text.Trim())
            _data.status = CInt(ui_status.SelectedValue)

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
                ui_pay_period.SelectedValueChanged,
                ui_employee.SelectedValueChanged,
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


    Protected Overrides Sub tool_net_salary_Click(sender As Object, e As EventArgs)
        If _data Is Nothing Then
            Return
        End If

        If (_data.status = Pay_Period.status_closed) Then

            MessageBox.Show("Bảng lương này đã đóng", "Không thể sửa đổi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim payrollService As PayrollService = New PayrollService()
        Dim response = payrollService.Execute(DataIntent.Cal_Net_Salary_One_Payroll, _data)

        If response.IsSuccess Then
            MessageBox.Show("Tính lương cho bảng lương thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _pay_item_list_uc.Refreash()
        Else
            MessageBox.Show(response.Message)
        End If
    End Sub

End Class