Imports System.Linq

Public Class frmChucVuEdit
    Inherits Form

    Private ReadOnly _departmentService As New BaseService(Of Department)()
    Private ReadOnly _data As Job
    Private ReadOnly _isCreate As Boolean
    Private _departments As New List(Of Department)()

    Private ReadOnly _statusList As New List(Of KeyValuePair(Of Integer, String)) From {
        New KeyValuePair(Of Integer, String)(1, "Đang hoạt động"),
        New KeyValuePair(Of Integer, String)(0, "Ngừng hoạt động")
    }

    Private lblTitle As Label
    Private txtCode As TextBox
    Private txtName As TextBox
    Private cboDepartment As ComboBox
    Private cboStatus As ComboBox
    Private txtNote As TextBox
    Private btnSave As Button
    Private btnCancel As Button

    Public Sub New(data As Job, Optional isCreate As Boolean = False)
        _data = data
        _isCreate = isCreate
        BuildLayout()
    End Sub

    Private Sub BuildLayout()
        Me.Text = If(_isCreate, "Tạo chức vụ", "Cập nhật chức vụ")
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        Me.ClientSize = New Size(640, 420)

        lblTitle = New Label() With {
            .Text = If(_isCreate, "Tạo mới chức vụ", "Chi tiết chức vụ"),
            .Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Dock = DockStyle.Top,
            .Height = 48,
            .Padding = New Padding(16, 8, 0, 0)
        }

        Dim layout As New TableLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 6,
            .Padding = New Padding(16, 8, 16, 8)
        }
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 140))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 52))

        txtCode = New TextBox() With {.Dock = DockStyle.Fill}
        txtName = New TextBox() With {.Dock = DockStyle.Fill}
        cboDepartment = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        cboStatus = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtNote = New TextBox() With {.Dock = DockStyle.Fill, .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        layout.Controls.Add(New Label() With {.Text = "Mã chức vụ", .TextAlign = ContentAlignment.MiddleLeft}, 0, 0)
        layout.Controls.Add(txtCode, 1, 0)
        layout.Controls.Add(New Label() With {.Text = "Tên chức vụ", .TextAlign = ContentAlignment.MiddleLeft}, 0, 1)
        layout.Controls.Add(txtName, 1, 1)
        layout.Controls.Add(New Label() With {.Text = "Bộ phận", .TextAlign = ContentAlignment.MiddleLeft}, 0, 2)
        layout.Controls.Add(cboDepartment, 1, 2)
        layout.Controls.Add(New Label() With {.Text = "Trạng thái", .TextAlign = ContentAlignment.MiddleLeft}, 0, 3)
        layout.Controls.Add(cboStatus, 1, 3)
        layout.Controls.Add(New Label() With {.Text = "Ghi chú", .TextAlign = ContentAlignment.MiddleLeft}, 0, 4)
        layout.Controls.Add(txtNote, 1, 4)

        Dim panelButtons As New Panel() With {.Dock = DockStyle.Fill}
        btnSave = New Button() With {.Text = "Lưu", .Width = 100, .Height = 32, .BackColor = Color.FromArgb(24, 119, 242), .ForeColor = Color.White}
        btnCancel = New Button() With {.Text = "Hủy", .Width = 100, .Height = 32}
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat

        btnSave.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
        btnCancel.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
        btnCancel.Left = Me.ClientSize.Width - 220

        panelButtons.Controls.Add(btnSave)
        panelButtons.Controls.Add(btnCancel)

        btnCancel.Left = panelButtons.Width - 110
        btnSave.Left = panelButtons.Width - 220
        btnSave.Top = 8
        btnCancel.Top = 8

        AddHandler panelButtons.Resize, Sub()
                                            btnCancel.Left = panelButtons.Width - 110
                                            btnSave.Left = panelButtons.Width - 220
                                        End Sub

        layout.Controls.Add(panelButtons, 0, 5)
        layout.SetColumnSpan(panelButtons, 2)

        btnCancel.Left = panelButtons.Width - 110
        btnSave.Left = panelButtons.Width - 220

        Me.Controls.Add(layout)
        Me.Controls.Add(lblTitle)

        AddHandler Me.Load, AddressOf frmChucVuEdit_Load
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmChucVuEdit_Load(sender As Object, e As EventArgs)
        LoadDepartments()
        InitStatus()
        BindDataToUI()
    End Sub

    Private Sub LoadDepartments()
        Dim response = _departmentService.Execute(DataIntent.GetList)
        _departments = TryCast(response?.Data, IEnumerable(Of Department))?.
            Where(Function(d) d IsNot Nothing AndAlso d.status <> -1).
            OrderBy(Function(d) d.code).
            ToList()
        If _departments Is Nothing Then _departments = New List(Of Department)()

        cboDepartment.DataSource = _departments.Select(Function(d) New With {
            .Display = $"[{d.code}] {d.name}",
            .Value = d.id
        }).ToList()
        cboDepartment.DisplayMember = "Display"
        cboDepartment.ValueMember = "Value"
    End Sub

    Private Sub InitStatus()
        cboStatus.DataSource = _statusList
        cboStatus.DisplayMember = "Value"
        cboStatus.ValueMember = "Key"
    End Sub

    Private Sub BindDataToUI()
        If _data Is Nothing Then Return

        txtCode.Text = If(_data.code, String.Empty)
        txtName.Text = If(_data.name, String.Empty)
        txtNote.Text = If(_data.note, String.Empty)
        cboStatus.SelectedValue = _data.status

        If _data.Department IsNot Nothing Then
            cboDepartment.SelectedValue = _data.Department.id
        ElseIf _data.department_id > 0 Then
            cboDepartment.SelectedValue = _data.department_id
        Else
            cboDepartment.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not SyncUIToData() Then Return
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function SyncUIToData() As Boolean
        If _data Is Nothing Then Return False

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Vui lòng nhập tên chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If cboDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Vui lòng chọn bộ phận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDepartment.Focus()
            Return False
        End If

        Dim deptId = Convert.ToInt32(cboDepartment.SelectedValue)
        Dim dept = _departments.FirstOrDefault(Function(d) d.id = deptId)
        If dept Is Nothing Then
            MessageBox.Show("Bộ phận không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDepartment.Focus()
            Return False
        End If

        _data.Department = dept
        _data.code = txtCode.Text.Trim()
        _data.name = txtName.Text.Trim()
        _data.note = txtNote.Text.Trim()
        _data.status = Convert.ToInt32(cboStatus.SelectedValue)

        Return True
    End Function
End Class
