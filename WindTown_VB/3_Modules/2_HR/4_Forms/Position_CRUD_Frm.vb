Public Class Position_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Position

    Private _contracsWithoutPosition As List(Of Contract)
    Private _jobs As List(Of Job)
    Private _salary_mult_list As List(Of Salary_Mult)

    Public Sub New(data As Position, Optional isCreate As Boolean = False)
        InitializeComponent()
        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm mới chức vụ", "Chi tiết chức vụ")

        InitComboBox()
        BindDataToUI()

        ' Mặc định khóa nút lưu khi vừa mở form (chưa có thay đổi)
        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()
        ' 1. Trạng thái (Status)
        ui_status.DataSource = New BindingSource(Position.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ' Nếu là chế độ xem/sửa, không cần nạp lại danh sách Hợp đồng trống và Job
        ' vì các trường này thường bị khóa (Disabled) để đảm bảo toàn vẹn dữ liệu
        If isCreate = False Then Return

        ' 2. Load Hợp đồng chưa có vị trí
        Dim contracService As New ContractService()
        Dim response = contracService.Execute(DataIntent.GetContractsWithoutPosition)
        _contracsWithoutPosition = If(response.IsSuccess, response.Data, New List(Of Contract))

        If (_contracsWithoutPosition.Count = 0) Then
            MessageBox.Show("Không có hợp đồng nào đang hoạt động mà chưa được gán vị trí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' Không đóng form ngay để user có thể xem, nhưng khóa nút Save
            Return
        End If

        ' Nạp Contract & Employee
        ui_contract.DataSource = _contracsWithoutPosition.Select(Function(x) New With {.Display = x.code, .Value = x}).ToList()
        ui_contract.DisplayMember = "Display"
        ui_contract.ValueMember = "Value"

        ui_employee.DataSource = _contracsWithoutPosition.Select(Function(x) New With {.Display = $"{x.Employee?.code} - {x.Employee?.name}", .Value = x}).ToList()
        ui_employee.DisplayMember = "Display"
        ui_employee.ValueMember = "Value"

        ' 3. Load Job (Công việc)
        Dim jobService As New JobService()
        Dim jobResponse = jobService.Execute(DataIntent.GetList)
        _jobs = If(jobResponse.IsSuccess, jobResponse.Data, New List(Of Job))

        ' SỬA LỖI: ValueMember không được để trống
        ui_job.DataSource = _jobs.Select(Function(x) New With {.Display = x.job_UI, .Value = x}).ToList()
        ui_job.DisplayMember = "Display"
        ui_job.ValueMember = "Value"

        ' 4. Load toàn bộ Salary Multiplier (Bảng ma trận Job/Level)
        Dim salary_multSV As New Salary_MultService()
        Dim smResponse = salary_multSV.Execute(DataIntent.GetList)
        _salary_mult_list = If(smResponse.IsSuccess, smResponse.Data, New List(Of Salary_Mult))

        ' Level sẽ được nạp động dựa vào Job qua sự kiện SelectedIndexChanged
        ui_level.DataSource = Nothing
    End Sub

    Protected Overrides Sub BindDataToUI()
        If isCreate Then
            ui_contract.SelectedIndex = -1
            ui_employee.SelectedIndex = -1
            ui_job.SelectedIndex = -1
            ui_level.SelectedIndex = -1
            ui_mult.Value = 1
        Else
            ' Chế độ xem/sửa: Hiển thị text từ data đã có
            ui_contract.Text = _data.Contract?.code : ui_contract.Enabled = False
            ui_employee.Text = $"{_data.Contract?.Employee?.code} - {_data.Contract?.Employee?.name}" : ui_employee.Enabled = False

            ' Hiển thị Job/Level từ Salary_Mult hiện tại
            ui_job.Text = _data.Salary_Mult?.Job?.name : ui_job.Enabled = False
            ui_level.Text = _data.Salary_Mult?.Level?.name : ui_level.Enabled = False

            ui_mult.Value = CDec(If(_data.Salary_Mult?.mult, 1.0))
            ui_mult.Enabled = False
        End If

        ui_code.Text = _data.code
        ui_start_date.Value = If(_data.start_date <= DateTime.MinValue, DateTime.Now, _data.start_date)

        ' Xử lý ngày kết thúc (nullable)
        If _data.end_date.HasValue Then
            ui_end_date.Value = _data.end_date.Value
        Else
            ui_end_date.Value = DateTime.Now.AddYears(1)
        End If

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    ' Sự kiện: Khi chọn Công việc -> Lọc ra các Cấp độ (Level) thuộc công việc đó
    Private Sub ui_job_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ui_job.SelectedIndexChanged
        ' Kiểm tra xem có item nào được chọn không (tránh lỗi khi gán DataSource)
        Dim selectedObj = ui_job.SelectedValue
        If selectedObj Is Nothing OrElse Not (TypeOf selectedObj Is Job) Then
            ui_level.DataSource = Nothing
            Return
        End If

        Dim job As Job = DirectCast(selectedObj, Job)

        ' Lọc danh sách Salary_Mult dựa trên JobID
        Dim levelsForJob = _salary_mult_list.Where(Function(x) x.job_id = job.id).
                           Select(Function(x) New With {.Display = x.Level?.name, .Value = x}).ToList()

        ui_level.DataSource = levelsForJob
        ui_level.DisplayMember = "Display"
        ui_level.ValueMember = "Value"
        ui_level.SelectedIndex = -1
        ui_mult.Value = 0
    End Sub

    ' Sự kiện: Khi chọn Cấp độ -> Hiển thị hệ số tương ứng
    Private Sub ui_level_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ui_level.SelectedIndexChanged
        Dim sm = TryCast(ui_level.SelectedValue, Salary_Mult)
        If sm IsNot Nothing Then
            ui_mult.Value = sm.mult
        End If
    End Sub

    ' Sync chéo Employee và Contract
    Private Sub ui_contract_SelectedValueChanged(sender As Object, e As EventArgs) Handles ui_contract.SelectedValueChanged
        If ui_contract.SelectedValue IsNot Nothing Then
            ui_employee.SelectedValue = ui_contract.SelectedValue
        End If
    End Sub

    Private Sub ui_employee_SelectedValueChanged(sender As Object, e As EventArgs) Handles ui_employee.SelectedValueChanged
        If ui_employee.SelectedValue IsNot Nothing Then
            ui_contract.SelectedValue = ui_employee.SelectedValue
        End If
    End Sub

    ' =============================
    ' Sync UI → Data (Lưu dữ liệu)
    ' =============================
    Protected Overrides Function SyncUIToData() As Boolean
        Try
            ' 1. Validation
            If String.IsNullOrWhiteSpace(ui_code.Text) Then
                MessageBox.Show("Vui lòng nhập mã vị trí (Code)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ui_code.Focus()
                Return False
            End If

            If isCreate Then
                If ui_contract.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn Hợp đồng/Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If ui_level.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn Công việc và Cấp độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Gán đối tượng đã chọn vào Model
                Dim selectedContract As Contract = DirectCast(ui_contract.SelectedValue, Contract)
                Dim selectedSM As Salary_Mult = DirectCast(ui_level.SelectedValue, Salary_Mult)

                _data.Contract = selectedContract

                _data.Salary_Mult = selectedSM
            End If

            ' 2. Gán các trường thông tin chung
            _data.code = ui_code.Text.Trim()
            _data.start_date = ui_start_date.Value
            _data.end_date = ui_end_date.Value
            _data.note = ui_note.Text.Trim()
            _data.status = CInt(ui_status.SelectedValue)

            ' 3. Logic kiểm tra ngày tháng
            If _data.end_date.HasValue AndAlso _data.start_date > _data.end_date.Value Then
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi đồng bộ dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Protected Overrides Sub DataChanged() _
        Handles ui_contract.SelectedValueChanged,
                ui_job.SelectedValueChanged,
                ui_level.SelectedValueChanged,
                ui_code.TextChanged,
                ui_start_date.ValueChanged,
                ui_end_date.ValueChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged

        ' Khi có bất kỳ thay đổi nào thì mới cho phép nhấn nút Save
        tool_save.Enabled = True
    End Sub
End Class