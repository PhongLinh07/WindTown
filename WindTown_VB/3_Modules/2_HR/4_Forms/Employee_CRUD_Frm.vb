Public Class Employee_CRUD_Frm
    Inherits BaseACRUDForm

    Protected _data As Employee

    Public Sub New(data As Employee, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate

        ' ===== Status =====
        ui_status.DataSource = New BindingSource(Employee.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ' ===== Gender =====
        ui_gender.DataSource = New BindingSource(Employee.gender_Dict, Nothing)
        ui_gender.DisplayMember = "Value"
        ui_gender.ValueMember = "Key"

        Me.Text = If(isCreate, "Thêm nhân viên mới", "Chi tiết nhân viên")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    ' =============================
    ' Bind Data → UI
    ' =============================
    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_note.Text = _data.note

        ui_status.SelectedValue = _data.status
        ui_gender.SelectedValue = _data.gender

        ui_birth_date.Value = If(_data.birth_date, DateTime.Now)

        ui_address.Text = _data.address
        ui_email.Text = _data.email
        ui_cccd.Text = _data.cccd
        ui_phone.Text = _data.phone
        ui_bank.Text = _data.bank
    End Sub

    ' =============================
    ' Sync UI → Data
    ' =============================
    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Code cannot be empty")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Name cannot be empty")
            ui_name.Focus()
            Return False
        End If

        ' Optional: Validate email format đơn giản
        If Not String.IsNullOrWhiteSpace(ui_email.Text) AndAlso
           Not ui_email.Text.Contains("@") Then
            MessageBox.Show("Invalid email format")
            ui_email.Focus()
            Return False
        End If

        ' ===== Assign =====
        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.note = ui_note.Text

        _data.address = ui_address.Text.Trim()
        _data.email = ui_email.Text.Trim()
        _data.cccd = ui_cccd.Text.Trim()
        _data.phone = ui_phone.Text.Trim()
        _data.bank = ui_bank.Text.Trim()

        _data.birth_date = ui_birth_date.Value

        If ui_status.SelectedValue IsNot Nothing Then
            _data.status = CInt(ui_status.SelectedValue)
        End If

        If ui_gender.SelectedValue IsNot Nothing Then
            _data.gender = CInt(ui_gender.SelectedValue)
        End If

        Return True
    End Function

    ' =============================
    ' Detect Change
    ' =============================
    Protected Overrides Sub DataChanged() _
        Handles ui_code.TextChanged,
                ui_name.TextChanged,
                ui_note.TextChanged,
                ui_status.SelectedIndexChanged,
                ui_gender.SelectedIndexChanged,
                ui_birth_date.ValueChanged,
                ui_address.TextChanged,
                ui_email.TextChanged,
                ui_cccd.TextChanged,
                ui_phone.TextChanged,
                ui_bank.TextChanged

        tool_save.Enabled = True
    End Sub

End Class