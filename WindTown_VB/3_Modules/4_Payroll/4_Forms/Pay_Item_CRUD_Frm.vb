
Public Class Pay_Item_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Pay_Item


    Public Sub New(data As Pay_Item, Optional isCreate As Boolean = False)

        InitializeComponent()
        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm khoản tiền", "Chi tiết khoản tiền")
        InitComboBox()

        BindDataToUI()
        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()
        ' ===== Status =====
        ui_status.DataSource = New BindingSource(Pay_Item.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_category.DataSource = New BindingSource(Category_PayItem.Dict_UI, Nothing)
        ui_category.DisplayMember = "Value"
        ui_category.ValueMember = "Key"

        ui_unit.DataSource = New BindingSource(UnitSuffix.Dict_UI, Nothing)
        ui_unit.DisplayMember = "Value"
        ui_unit.ValueMember = "Key"

        ui_source.DataSource = New BindingSource(Pay_Item.source_Dict, Nothing)
        ui_source.DisplayMember = "Value"
        ui_source.ValueMember = "Key"

    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code.ToUpper()
        ui_name.Text = _data.name
        ui_payroll.Text = _data.Payroll?.code
        ui_value.Text = _data.value_UI
        ui_priority.Value = _data.priority
        ui_category.SelectedValue = _data.category
        ui_unit.SelectedValue = _data.unit
        ui_source.SelectedValue = _data.source
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status


    End Sub


    ' =============================
    ' Sync UI → Data
    ' =============================
    Protected Overrides Function SyncUIToData() As Boolean
        Try
            If isCreate Then
                If System_Parameter.IsSystemParameter(ui_code.Text.Trim().ToUpper()) Then
                    MessageBox.Show("Mã không thể trùng với mã hệ thống và không bắt đầu bằng 'SYS_'")
                End If
            End If
            ' 1. Validation cơ bản
            If String.IsNullOrWhiteSpace(ui_code.Text) Then
                MessageBox.Show("Mã khoản tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ui_code.Focus()
                Return False
            End If
            If String.IsNullOrWhiteSpace(ui_name.Text) Then
                MessageBox.Show("Tên khoản tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ui_name.Focus()
                Return False
            End If

            If Not Decimal.TryParse(ui_value.Text, _data.value) Then
                MessageBox.Show("Giá trị Item không hợp lệ")
                ui_value.Focus()
                Return False

            End If
            ' 2. Gán dữ liệu từ UI vào Model (_data)
            _data.code = ui_code.Text.Trim().ToUpper()
            _data.name = ui_name.Text.Trim()
            _data.priority = ui_priority.Value
            _data.category = ui_category.SelectedValue
            _data.unit = ui_unit.SelectedValue
            _data.source = ui_source.SelectedValue

            _data.note = ui_note.Text.Trim()
            _data.status = CInt(ui_status.SelectedValue)

            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi đồng bộ dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function



    ' =============================
    ' Detect Change
    ' =============================
    Protected Overrides Sub DataChanged() _
        Handles ui_code.TextChanged,
                ui_value.TextChanged,
                ui_priority.ValueChanged,
                ui_category.SelectedValueChanged,
                ui_unit.SelectedIndexChanged,
                ui_source.SelectedValueChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub

    Private Sub SnapValue(sender As Object, e As EventArgs) Handles ui_value.TextChanged
        If ui_unit.SelectedValue Is Nothing Then Return
        If Not String.IsNullOrWhiteSpace(ui_value.Text) Then Return
        If Not Decimal.TryParse(ui_value.Text, _data.value) Then Return
        ui_value.Text = UnitSuffix.FomatNumber(_data.value, CInt(ui_unit.SelectedValue))
    End Sub


End Class