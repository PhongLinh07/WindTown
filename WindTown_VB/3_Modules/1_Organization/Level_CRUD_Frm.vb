Public Class Level_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Level



    Public Sub New(data As Level, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate

        ui_status.DataSource = New BindingSource(Level.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        Me.Text = If(isCreate, "Thêm cấp bậc mới", "Chi tiết cấp bậc")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Protected Overrides Sub BindDataToUI()
        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_rank.Value = _data.rank
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã cấp bậc không hợp lệ")
            ui_code.Focus()
            Return False
        End If
        If AppServices.Instance.LevelSV.IsCodeDuplicate(ui_code.Text.Trim(), If(isCreate, 0, _data.id)) Then
            MessageBox.Show("Mã cấp bậc đã tồn tại.")
            Return False
        End If
        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tên cấp bậc không hợp lệ!")
            ui_name.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.rank = Convert.ToInt32(ui_rank.Value)
        _data.note = ui_note.Text

        _data.status = CInt(ui_status.SelectedValue.ToString())

        Return True
    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                 ui_name.TextChanged,
                                 ui_rank.ValueChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub


End Class