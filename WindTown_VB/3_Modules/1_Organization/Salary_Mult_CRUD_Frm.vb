Imports System.Text

Public Class Salary_Mult_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Salary_Mult

    Private _jobs As List(Of Job)
    Private _lvls As List(Of Level)

    Public Sub New(data As Salary_Mult, Optional isCreate As Boolean = False)

        InitializeComponent()
        InitComboBox()

        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Tạo hệ số", "Chi tiết hệ số")


        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Salary_Mult.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        Dim response = AppServices.Instance.JobSV.Execute(DataIntent.GetList)
        _jobs = If(response.IsSuccess, response.Data, New List(Of Job))
        ui_job.DataSource = _jobs.Select(Function(x) New With {.Display = $"{x.job_UI}", .Value = x}).ToList()
        ui_job.DisplayMember = "Display"
        ui_job.ValueMember = "Value"

        response = AppServices.Instance.LevelSV.Execute(DataIntent.GetList)
        _lvls = If(response.IsSuccess, response.Data, New List(Of Level))
        ui_level.DataSource = _lvls.Select(Function(x) New With {.Display = $"{x.level_UI}", .Value = x}).ToList()
        ui_level.DisplayMember = "Display"
        ui_level.ValueMember = "Value"


    End Sub

    Protected Overrides Sub BindDataToUI()

        If isCreate Then
            ui_level.SelectedIndex = -1

        Else
            ui_level.Text = _data.level_UI

        End If
        ui_job.Text = _data.Job?.job_UI


        ui_mult.Value = _data.mult

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        Try

            ' Nếu là tạo mới, kiểm tra các ComboBox bắt buộc
            If isCreate Then
                If ui_job.SelectedValue Is Nothing OrElse ui_level.SelectedValue Is Nothing Then
                    MessageBox.Show("Vui lòng chọn đầy đủ Công việc và Cấp độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Gán các ID quan trọng khi tạo mới

                _data.Job = ui_job.SelectedValue
                _data.Level = ui_level.SelectedValue
            End If

            ' 2. Gán dữ liệu từ UI vào Model (_data)

            _data.note = ui_note.Text.Trim()
            _data.status = CInt(ui_status.SelectedValue)

            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi đồng bộ dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Protected Overrides Sub DataChanged() Handles ui_job.SelectedIndexChanged,
                                 ui_level.SelectedIndexChanged,
                                 ui_status.SelectedIndexChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged
        tool_save.Enabled = True
    End Sub


End Class