
Imports WindTown_VB

Public Class Leave_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As WindTown_VB.Leave



    Private _employees As List(Of Employee)
    Private _leaveTypes As List(Of Leave_Cat)

    Public Sub New(data As Leave, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "New", "Detail")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(WindTown_VB.Leave.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"


        If isCreate = False Then
            Return
        End If

        Dim employeetService As New EmployeeService()
        Dim response = employeetService.Execute(DataIntent.GetList)
        _employees = If(response.IsSuccess, response.Data, New List(Of Employee))
        ui_employee.DataSource = _employees.Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        Dim leaveTypeService As New BaseService(Of Leave_Cat)
        response = leaveTypeService.Execute(DataIntent.GetList)
        _leaveTypes = If(response.IsSuccess, response.Data, New List(Of Leave_Cat))
        ui_leave_type.DataSource = _leaveTypes.Select(Function(x) New With {.Display = $"{x.code} - {x.name}", .Value = x}).ToList()
        ui_leave_type.DisplayMember = "Display"
        ui_leave_type.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_employee.SelectedIndex = -1
            ui_leave_type.SelectedIndex = -1
        Else
            ui_employee.Text = _data.employee_UI
            ui_employee.Enabled = False

            ui_leave_type.Text = _data.leave_type_UI
            ui_leave_type.Enabled = False

            ui_approved.Text = _data.approved_UI
        End If


        ui_code.Text = _data.code

        ui_start_date.Value = If(_data.start_date, DateTime.Now)
        ui_total_days.Text = _data.total_days

        ui_reason.Text = _data.reason
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc
        If isCreate Then
            If ui_employee.SelectedValue Is Nothing OrElse ui_leave_type.SelectedValue Is Nothing Then
                MessageBox.Show("Thông tin Nhân viên và Loại phép không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False

            End If

            ' Gán các ID quan trọng khi tạo mới
            _data.Employee = ui_employee.SelectedValue
            _data.Leave_Cat = ui_leave_type.SelectedValue

            _data.Approved = New Employee With {.id = 1} ' tạm gán Approved bằng 1 đối tượng Employee rỗng, sẽ cập nhật sau khi được duyệt
        End If

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã phép không hợp lệ")
            ui_code.Focus()
            Return False
        End If


        If Not Decimal.TryParse(ui_total_days.Text, _data.total_days) Then
            MessageBox.Show("Tổng ngày nghỉ không hợp lệ")
            ui_total_days.Focus()
            Return False
        End If


        _data.code = ui_code.Text.Trim()

        _data.start_date = ui_start_date.Value

        _data.reason = ui_reason.Text
        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                        ui_leave_type.SelectedIndexChanged,
                                        ui_code.TextChanged,
                                        ui_start_date.ValueChanged,
                                        ui_total_days.TextChanged,
                                        ui_reason.TextChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class