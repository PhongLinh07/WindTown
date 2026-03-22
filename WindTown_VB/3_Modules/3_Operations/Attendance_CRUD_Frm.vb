Public Class Attendance_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Attendance

    Private _employees As List(Of Employee)

    Public Sub New(data As Attendance, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm mới chấm công", "Chi tiết chấm công")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Attendance.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_shift.DataSource = New BindingSource(Attendance.shift_Dic, Nothing)
        ui_shift.DisplayMember = "Value"
        ui_shift.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        Dim response = AppServices.Instance.EmployeeSV.GetList()
        _employees = If(response.IsSuccess, response.Data, New List(Of Employee))

        ui_employee.DataSource = _employees.Select(Function(x) New With {.Display = x.employee_UI, .Value = x}).ToList()

        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
            ui_employee.SelectedIndex = -1
            ui_employee.Enabled = True
        Else
            ui_employee.DropDownStyle = ComboBoxStyle.DropDown
            ui_employee.Text = _data.employee_UI
            ui_employee.Enabled = False
        End If

        ui_code.Text = _data.code
        ui_of_date.Value = _data.of_date
        ui_office_hours.Value = _data.office_hours
        ui_overtime_hours.Value = _data.overtime_hours
        ui_late_hours.Value = _data.late_hours
        ui_early_hours.Value = _data.early_hours
        ui_shift.SelectedValue = _data.shift
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã chấm công không hợp lệ!")
            ui_code.Focus()
            Return False
        End If

        If AppServices.Instance.AttendanceSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Mã chấm công này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If isCreate Then
            If ui_employee.SelectedValue Is Nothing Then
                MessageBox.Show("Nhân viên không hợp lệ")
                ui_employee.Focus()
                Return False
            End If
            _data.employee_id = CType(ui_employee.SelectedValue, Employee).id
        End If


        If Not Decimal.TryParse(ui_office_hours.Value, _data.office_hours) Then
            MessageBox.Show("Tổng giờ hành chính không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_office_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_overtime_hours.Value, _data.overtime_hours) Then
            MessageBox.Show("Tổng giờ tăng ca không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_overtime_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_late_hours.Value, _data.late_hours) Then
            MessageBox.Show("Tổng giờ đến muộn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_late_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_early_hours.Value, _data.early_hours) Then
            MessageBox.Show("Tổng giờ về sớm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_early_hours.Focus()
            Return False
        End If


        _data.code = ui_code.Text.Trim()
        _data.of_date = ui_of_date.Value
        _data.note = ui_note.Text.Trim()
        _data.shift = CInt(ui_shift.SelectedValue)
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
            ui_employee.SelectedValueChanged,
            ui_of_date.ValueChanged,
            ui_office_hours.ValueChanged,
            ui_overtime_hours.ValueChanged,
            ui_early_hours.ValueChanged,
            ui_note.TextChanged,
            ui_shift.SelectedValueChanged,
            ui_status.SelectedValueChanged

        tool_save.Enabled = True

    End Sub

End Class