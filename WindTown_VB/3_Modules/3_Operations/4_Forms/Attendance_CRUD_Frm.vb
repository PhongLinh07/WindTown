Imports Microsoft.IdentityModel.Tokens

Public Class Attendance_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Attendance


    Private _displayStatus As New Dictionary(Of Integer, String) From {
        {0, "INACTIVE"},
        {1, "ACTIVE"}
    }

    Private _employeesWithoutAccount As List(Of Employee)

    Public Sub New(data As Attendance, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "New", "Detail")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(_displayStatus, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_shift.DataSource = New BindingSource(Attendance.Dict_Shift, Nothing)
        ui_shift.DisplayMember = "Value"
        ui_shift.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        Dim employeetService As New EmployeeService()
        Dim response = employeetService.Execute(DataIntent.GetEmployeesWithoutAccount)
        _employeesWithoutAccount = If(response.IsSuccess, response.Data, New List(Of Employee))

        ui_employee.DataSource =
            _employeesWithoutAccount.
            Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x.id}).ToList()

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

        ui_code.Text = _data.user
        ui_office_hours.Text = _data.password
        ui_shift.SelectedValue = _data.role


        ui_of_date.Value = If(_data.last_login, DateTime.Now)
        ui_last_logout.Value = If(_data.last_logout, DateTime.Now)

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If isCreate AndAlso ui_employee.SelectedValue Is Nothing Then
            MessageBox.Show("Please select employee")
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("User cannot be empty")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_office_hours.Text) Then
            MessageBox.Show("Password cannot be empty")
            ui_office_hours.Focus()
            Return False
        End If

        If isCreate Then
            Dim selectedId = If(ui_employee.SelectedValue, 0)
            Dim employee = _employeesWithoutAccount.FirstOrDefault(Function(x) x.id = Convert.ToInt32(selectedId))
            If employee Is Nothing Then
                MessageBox.Show("Invalid employee selected")
                ui_employee.Focus()
                Return False
            End If
            _data.Employee = employee
        End If


        _data.user = ui_code.Text.Trim()
        _data.password = ui_office_hours.Text.Trim()
        _data.role = CInt(ui_shift.SelectedValue)
        _data.note = ui_note.Text

        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                        ui_code.TextChanged,
                                        ui_office_hours.TextChanged,
                                        ui_shift.SelectedIndexChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

    Private Sub DataChanged(sender As Object, e As EventArgs) Handles ui_status.SelectedIndexChanged, ui_shift.SelectedIndexChanged, ui_office_hours.TextChanged, ui_note.TextChanged, ui_employee.SelectedIndexChanged, ui_code.TextChanged

    End Sub
End Class