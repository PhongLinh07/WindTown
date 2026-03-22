Public Class Project_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Project

    Public Sub New(data As Project, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm dự án", "Chi tiết dự án")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Project.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_start_date.Value = _data.start_date
        ui_end_date.Value = _data.end_date

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean


        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã dự án không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_code.Focus()
            Return False
        End If
        If AppServices.Instance.ProjectSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Mã dự án này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tên dự án không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ui_code.Focus()
            Return False
        End If


        _data.code = ui_code.Text
        _data.name = ui_name.Text

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

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_start_date.ValueChanged,
                                        ui_end_date.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub


End Class