Public Class Contract_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Contract

    Private _employeesWithoutContract As List(Of Employee)

    Public Sub New(data As Contract, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm hợp đồng mới", "Chi tiết hợp đồng")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Contract.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"


        If isCreate = False Then
            Return
        End If

        Dim response = AppServices.Instance.EmployeeSV.GetWithoutContract() 'Những nhân viên đang ko có tài hợp đồng or hợp đồng đã hết hạn

        If (response.IsSuccess = False) Then
            MessageBox.Show("Failed to load employees: " & response.Message)
            Return
        End If
        _employeesWithoutContract = If(response.IsSuccess, response.Data, New List(Of Employee))
        ui_employee.DataSource = _employeesWithoutContract.Select(Function(x) New With {.Display = x.employee_UI, .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
            ui_employee.SelectedIndex = -1
        Else
            ui_employee.DropDownStyle = ComboBoxStyle.DropDown
            ui_employee.Text = _data.Employee_UI
            ui_employee.Enabled = False
        End If

        ui_code.Text = _data.code
        ui_start_date.Value = _data.start_date
        ui_end_date.Value = _data.end_date
        ui_base_salary.Value = _data.base_salary
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean


        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã hợp đồng không hợp lệ!")
            ui_code.Focus()
            Return False
        End If

        If AppServices.Instance.ContractSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Mã hợp đồng đã tồn tại.")
            Return False
        End If

        If Not Decimal.TryParse(ui_base_salary.Value, _data.base_salary) Then
            MessageBox.Show("Lương cơ bản không hợp lệ!")
            ui_base_salary.Focus()
            Return False
        End If

        If isCreate Then
            If ui_employee.SelectedValue Is Nothing Then
                MessageBox.Show("Thông tin nhân viên không hợp lệ!")
                ui_employee.Focus()
                Return False
            End If
            _data.employee_id = CType(ui_employee.SelectedValue, Employee).id
        End If

        If AppServices.Instance.ContractSV.IsConflictStatusActive(_data.employee_id, If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Nhân viên này hiện đang có hợp đồng khác hoạt động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If


        _data.code = ui_code.Text
        _data.start_date = ui_start_date.Value
        _data.end_date = ui_end_date.Value


        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        If _data.start_date > _data.end_date Then
            MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                        ui_code.TextChanged,
                                        ui_base_salary.ValueChanged,
                                        ui_start_date.ValueChanged,
                                        ui_end_date.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class