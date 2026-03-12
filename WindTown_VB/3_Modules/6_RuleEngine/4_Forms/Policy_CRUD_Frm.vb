Public Class Policy_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Policy

    Public Sub New(data As Policy, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Thêm chính sách", "Chi tiết chính sách")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Policy.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_category.DataSource = New BindingSource(Policy.category_Dict, Nothing)
        ui_category.DisplayMember = "Value"
        ui_category.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_category.SelectedValue = _data.category

        ui_rule.Text = _data.rule

        ui_priority.Value = _data.priority

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã chính sách không hợp lệ")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tên chính sách không hợp lệ")
            ui_name.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.category = ui_category.SelectedValue

        _data.rule = ui_rule.Text.Trim()

        If Not Integer.TryParse(ui_priority.Value, _data.priority) Then
            MessageBox.Show("Độ ưu tiên không hợp lệ")
            ui_priority.Focus()
            Return False
        End If

        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_category.SelectedValueChanged,
                                        ui_rule.TextChanged,
                                        ui_priority.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class