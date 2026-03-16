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

        ui_data_source.DataSource = New BindingSource(PolicyParameter.Data_Source.Dict_UI, Nothing)
        ui_data_source.DisplayMember = "Value"
        ui_data_source.ValueMember = "Key"

        ui_aggregate.DataSource = New BindingSource(PolicyParameter.Aggregate_Func.Dict_UI, Nothing)
        ui_aggregate.DisplayMember = "Value"
        ui_aggregate.ValueMember = "Key"

        ui_gen_item.DataSource = New BindingSource(Policy.gen_item_Dict, Nothing)
        ui_gen_item.DisplayMember = "Value"
        ui_gen_item.ValueMember = "Key"

        ' ui_category.DataSource = New BindingSource(PolicyParameter.Category_Amount.Dict_UI, Nothing)
        ui_category.DisplayMember = "Value"
        ui_category.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_data_source.SelectedValue = _data.data_source
        ui_aggregate.SelectedValue = _data.aggregate
        ui_gen_item.SelectedValue = _data.gen_item
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

        If String.IsNullOrWhiteSpace(ui_rule.Text) Then
            MessageBox.Show("Quy tắc/Công thức không hợp lệ")
            ui_rule.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.data_source = ui_data_source.SelectedValue
        _data.aggregate = ui_aggregate.SelectedValue
        _data.category = ui_category.SelectedValue
        _data.gen_item = ui_gen_item.SelectedValue

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
                                        ui_data_source.SelectedValueChanged,
                                        ui_aggregate.SelectedValueChanged,
                                        ui_gen_item.SelectedValueChanged,
                                        ui_category.SelectedValueChanged,
                                        ui_rule.TextChanged,
                                        ui_priority.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

    Private Sub ui_category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ui_category.SelectedIndexChanged

    End Sub
End Class