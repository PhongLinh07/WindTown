Public Class Pay_Period_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Pay_Period

    Public Sub New(data As Pay_Period, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Tạo kỳ lương", "Chi tiết kỳ lương")

        BindDataToUI()

        tool_save.Enabled = False

        If isCreate Then
            Return 'chỉ mở khi ko phải tạo
        End If
        tool_init_payroll.Visible = True
        tool_net_salary.Visible = True
        tool_aggregate_payroll_data.Visible = True

    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Pay_Period.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_month.Value = If(_data.month, DateTime.Today)

        ui_start_date.Value = _data.start_date
        ui_end_date.Value = _data.end_date

        ui_std_hours.Text = _data.std_hours

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        Try

            If String.IsNullOrWhiteSpace(ui_code.Text) Then
                MessageBox.Show("Mã kỳ lương không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ui_code.Focus()
                Return False
            End If

            If AppServices.Instance.Pay_PeriodSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
                MessageBox.Show("Mã kỳ lương đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            If String.IsNullOrWhiteSpace(ui_name.Text) Then
                MessageBox.Show("Tiêu đề kỳ lương không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ui_name.Focus()
                Return False
            End If

            _data.code = ui_code.Text.Trim()
            _data.name = ui_name.Text.Trim()
            _data.month = ui_month.Value
            _data.start_date = ui_start_date.Value
            _data.end_date = ui_end_date.Value

            If Not Decimal.TryParse(ui_std_hours.Text, _data.std_hours) Then
                _data.std_hours = 0
            End If


            _data.note = ui_note.Text
            _data.status = CInt(ui_status.SelectedValue)

            ' 3. Logic kiểm tra ngày tháng
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

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_month.ValueChanged,
                                        ui_start_date.ValueChanged,
                                        ui_end_date.ValueChanged,
                                        ui_std_hours.TextChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub


    ' Tính số giờ công chuẩn của chu kỳ
    Private Sub CalculatorHoursStd() Handles btn_std_hours_cal.Click

        _data.start_date = ui_start_date.Value
        _data.end_date = ui_end_date.Value
        Dim response = AppServices.Instance.Pay_PeriodSV.CalcStdHours(_data)

        If response.IsSuccess Then
            ui_std_hours.Value = response.Data

        Else
            MessageBox.Show(response.Message)
        End If
    End Sub

    ' Tool khởi tạo bảng lương của chu kỳ
    Protected Overrides Sub tool_init_payroll_Click(sender As Object, e As EventArgs)
        If _data Is Nothing Then
            Return
        End If

        If (_data.status = Pay_Period.status_closed) Then

            MessageBox.Show("Chu kỳ lương này đã đóng", "Không thể khởi tạo bảng lương", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim response = AppServices.Instance.PayrollSV.Init_Payrolls(_data)

        If response.IsSuccess Then
            MessageBox.Show("Khởi tạo bảng lương của chu kỳ thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(response.Message)
        End If
    End Sub

    Protected Overrides Sub tool_aggregate_payroll_data_Click(sender As Object, e As EventArgs)
        If _data Is Nothing Then
            Return
        End If

        If (_data.status = Pay_Period.status_closed) Then

            MessageBox.Show("Kỳ lương này đã đóng", "Không thể sửa đổi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim response = AppServices.Instance.PayrollSV.Aggregation_Data_One_Period(_data)

        If response.IsSuccess Then
            MessageBox.Show("Tổng hợp lương cho kỳ lương thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(response.Message)
        End If
    End Sub
    Protected Overrides Sub tool_net_salary_Click(sender As Object, e As EventArgs)
        If _data Is Nothing Then
            Return
        End If

        If (_data.status = Pay_Period.status_closed) Then

            MessageBox.Show("Kỳ lương này đã đóng", "Không thể sửa đổi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim response = AppServices.Instance.PayrollSV.CalcNetSalaryByPeriod(_data)

        If response.IsSuccess Then
            MessageBox.Show("Tính lương cho Kỳ lương thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(response.Message)
        End If
    End Sub
End Class