Public Class Leave_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Leave



    Private _employees As List(Of Employee)
    Private _leaveTypes As List(Of Leave_Cat)

    Public Sub New(data As Leave, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm nghỉ phép", "Chi tiết nghỉ phép")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(WindTown_VB.Leave.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"


        Dim response = AppServices.Instance.EmployeeSV.GetList()
        _employees = If(response.IsSuccess, response.Data, New List(Of Employee))
        ui_employee.DataSource = _employees.Select(Function(x) New With {.Display = x.employee_UI, .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        Dim items = _employees.Select(Function(x) New With {.Display = x.employee_UI, .Value = x}).ToList()
        items.Insert(0, New With {.Display = "--- None ---", .Value = CType(Nothing, Employee)})
        ui_approved.DataSource = items
        ui_approved.DisplayMember = "Display"
        ui_approved.ValueMember = "Value"


        response = AppServices.Instance.Leave_CatSV.GetList()
        _leaveTypes = If(response.IsSuccess, response.Data, New List(Of Leave_Cat))
        ui_leave_type.DataSource = _leaveTypes.Select(Function(x) New With {.Display = x.leave_cat_UI, .Value = x}).ToList()
        ui_leave_type.DisplayMember = "Display"
        ui_leave_type.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_start_date.Value = _data.start_date
        ui_total_days.Text = _data.total_days

        ui_reason.Text = _data.reason
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

        If isCreate Then
            ui_employee.SelectedIndex = -1
            ui_approved.SelectedIndex = -1
            ui_leave_type.SelectedIndex = -1
            Return
        End If

        ui_employee.SelectedValue = If(_employees.FirstOrDefault(Function(x) x.id = _data.employee_id), DBNull.Value) : ui_employee.Enabled = False
        ui_approved.SelectedValue = If(_employees.FirstOrDefault(Function(x) x.id = _data.approved_id), DBNull.Value)
        ui_leave_type.SelectedValue = If(_leaveTypes.FirstOrDefault(Function(x) x.id = _data.leave_cat_id), DBNull.Value)

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã nghỉ phép không hợp lệ!")
            ui_code.Focus()
            Return False
        End If

        If AppServices.Instance.LeaveSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Mã phép này đã tồn tại.")
            Return False
        End If

        ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc

        If ui_employee.SelectedValue Is Nothing Then
            MessageBox.Show("Thông tin Nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If ui_leave_type.SelectedValue Is Nothing Then
            MessageBox.Show("Loại phép không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If Not Decimal.TryParse(ui_total_days.Value, _data.total_days) Then
            MessageBox.Show("Tổng ngày nghỉ không hợp lệ")
            ui_total_days.Focus()
            Return False
        End If

        If Not ui_approved.SelectedValue Is Nothing Then
            _data.approved_id = CType(ui_approved.SelectedValue, Employee).id
        Else
            _data.approved_id = -1
        End If

        _data.code = ui_code.Text.Trim()
        _data.employee_id = CType(ui_employee.SelectedValue, Employee).id
        _data.leave_cat_id = CType(ui_leave_type.SelectedValue, Leave_Cat).id
        _data.start_date = ui_start_date.Value
        _data.reason = ui_reason.Text
        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function
    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged, ui_approved.SelectedValueChanged, ui_leave_type.SelectedIndexChanged, ui_code.TextChanged, ui_start_date.ValueChanged, ui_total_days.TextChanged, ui_reason.TextChanged, ui_note.TextChanged, ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class