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

        ui_aggregate.DataSource = New BindingSource(Aggregate_Func.Dict_UI, Nothing)
        ui_aggregate.DisplayMember = "Value"
        ui_aggregate.ValueMember = "Key"

        ui_category.DataSource = New BindingSource(Category_PayItem.Dict_UI, Nothing)
        ui_category.DisplayMember = "Value"
        ui_category.ValueMember = "Key"

        ui_gen_item.DataSource = New BindingSource(Policy.gen_item_Dict, Nothing)
        ui_gen_item.DisplayMember = "Value"
        ui_gen_item.ValueMember = "Key"

        ui_unit.DataSource = New BindingSource(UnitSuffix.Dict_UI, Nothing)
        ui_unit.DisplayMember = "Value"
        ui_unit.ValueMember = "Key"
    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code.Trim().ToUpper()
        ui_name.Text = _data.name
        ui_data_source.Text = Data_Source.GetParameter(_data.source).name
        ui_aggregate.SelectedValue = _data.aggregate
        ui_gen_item.SelectedValue = _data.gen_item
        ui_category.SelectedValue = _data.category
        ui_rule.Text = _data.rule
        ui_priority.Value = _data.priority
        ui_unit.SelectedValue = _data.unit
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If isCreate Then
            If System_Parameter.IsSystemParameter(ui_code.Text.Trim().ToUpper()) Then
                MessageBox.Show("Mã không thể trùng với mã hệ thống và không bắt đầu bằng 'SYS_'")
            End If
        End If
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

        _data.code = ui_code.Text.Trim().ToUpper()
        _data.name = ui_name.Text.Trim()
        _data.aggregate = ui_aggregate.SelectedValue
        _data.category = ui_category.SelectedValue
        _data.gen_item = ui_gen_item.SelectedValue
        _data.unit = ui_unit.SelectedValue
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
                                        ui_aggregate.SelectedValueChanged,
                                        ui_gen_item.SelectedValueChanged,
                                        ui_category.SelectedValueChanged,
                                        ui_unit.SelectedIndexChanged,
                                        ui_rule.TextChanged,
                                        ui_priority.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

    Private Sub ui_data_source_TextChanged(sender As Object, e As EventArgs) Handles ui_rule.TextChanged

        _data.source = Data_Source.GetDataSourceByRule(ui_rule.Text)
        ui_data_source.Text = Data_Source.GetParameter(_data.source).name
    End Sub

    Private Sub ui_code_TextChanged(sender As Object, e As EventArgs) Handles ui_code.TextChanged
        If System_Parameter.IsSystemParameter(ui_code.Text.Trim().ToUpper()) Then
            MessageBox.Show("Mã không thể trùng với mã hệ thống và không bắt đầu bằng 'SYS_'")
        End If
    End Sub
End Class