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

        Dim employeetService As New EmployeeService()
        Dim response = employeetService.Execute(DataIntent.GetList)
        _employees = If(response.IsSuccess, response.Data, New List(Of Employee))

        ui_employee.DataSource = _employees.Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x.id}).ToList()

        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_employee.SelectedIndex = -1
        Else
            ui_employee.Text = _data.Employee_UI
            ui_employee.Enabled = False
        End If

        ui_code.Text = _data.code

        ui_of_date.Value = If(_data.of_date, DateTime.Now)

        ui_office_hours.Text = _data.office_hours

        ui_overtime_hours.Text = _data.overtime_hours
        ui_late_hours.Text = _data.late_hours
        ui_early_hours.Text = _data.early_hours


        ui_shift.SelectedValue = _data.shift

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If isCreate Then
            Dim selectedId = If(ui_employee.SelectedValue, 0)
            Dim employee = _employees.FirstOrDefault(Function(x) x.id = Convert.ToInt32(selectedId))
            If employee Is Nothing Then
                MessageBox.Show("Invalid employee selected")
                ui_employee.Focus()
                Return False
            End If
            _data.Employee = employee
        End If

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("User cannot be empty")
            ui_code.Focus()
            Return False
        End If


        If Not Decimal.TryParse(ui_office_hours.Text, _data.office_hours) Then
            MessageBox.Show("Office Hours must be a valid number")
            ui_office_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_overtime_hours.Text, _data.overtime_hours) Then
            MessageBox.Show("Overtime Hours must be a valid number")
            ui_overtime_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_late_hours.Text, _data.late_hours) Then
            MessageBox.Show("Late Hours must be a valid number")
            ui_late_hours.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_early_hours.Text, _data.early_hours) Then
            MessageBox.Show("Early Hours must be a valid number")
            ui_early_hours.Focus()
            Return False
        End If


        _data.code = ui_code.Text.Trim()

        _data.of_date = ui_of_date.Value
        _data.status = CInt(ui_shift.SelectedValue)

        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                        ui_code.TextChanged,
                                        ui_office_hours.TextChanged,
                                        ui_overtime_hours.TextChanged,
                                        ui_late_hours.TextChanged,
                                        ui_early_hours.TextChanged,
                                        ui_shift.SelectedIndexChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class