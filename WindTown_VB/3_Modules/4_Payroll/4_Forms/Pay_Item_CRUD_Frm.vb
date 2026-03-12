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

        If isCreate = False Then
            Return
        End If


    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_payroll.Text = _data.Payroll?.code
        ui_value.Value = _data.value
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status


    End Sub


    ' =============================
    ' Sync UI → Data
    ' =============================
    Protected Overrides Function SyncUIToData() As Boolean
        Try
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



            ' 2. Gán dữ liệu từ UI vào Model (_data)
            _data.code = ui_code.Text.Trim()
            _data.name = ui_name.Text.Trim()
            If Not Decimal.TryParse(ui_value.Value, _data.value) Then
                MessageBox.Show("Overtime Hours must be a valid number")
                ui_value.Focus()
                Return False
            End If
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
                ui_value.ValueChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub

End Class