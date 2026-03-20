Public Class Account_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Account

    Private _employeesWithoutAccount As List(Of Employee)

    Public Sub New(data As Account, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm tài khoản mới", "Chi tiết tài khoản")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Account.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_role.DataSource = New BindingSource(Account.role_Dict, Nothing)
        ui_role.DisplayMember = "Value"
        ui_role.ValueMember = "Key"

        If isCreate = False Then
            Return
        End If

        Dim response = AppServices.Instance.EmployeeSV.GetWithoutAccount()
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
            ui_employee.Text = _data.employee_UI
            ui_employee.Enabled = False
        End If

        ui_user.Text = _data.user
        ui_password.Text = _data.password
        ui_role.SelectedValue = _data.role


        ui_last_active.Value = If(_data.last_active, DateTime.Now)

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If isCreate AndAlso ui_employee.SelectedValue Is Nothing Then
            MessageBox.Show("Please select employee")
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_user.Text) Then
            MessageBox.Show("User cannot be empty")
            ui_user.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_password.Text) Then
            MessageBox.Show("Password cannot be empty")
            ui_password.Focus()
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


        _data.user = ui_user.Text.Trim()
        _data.password = ui_password.Text.Trim()
        _data.role = CInt(ui_role.SelectedValue)
        _data.note = ui_note.Text

        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                        ui_user.TextChanged,
                                        ui_password.TextChanged,
                                        ui_role.SelectedIndexChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class