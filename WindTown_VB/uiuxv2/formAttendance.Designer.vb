<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAttendance
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlRight = New Panel()
        pnlFormScroll = New Panel()
        pnlSec2 = New Panel()
        tlpSec2 = New TableLayoutPanel()
        lblFCheckIn = New Label()
        txtFCheckIn = New TextBox()
        lblFCheckOut = New Label()
        txtFCheckOut = New TextBox()
        lblFHours = New Label()
        txtFHours = New TextBox()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
        lblSec2 = New Label()
        pnlSec1 = New Panel()
        tlpSec1 = New TableLayoutPanel()
        lblFEmp = New Label()
        cboFEmp = New ComboBox()
        lblFDept = New Label()
        cboFDept = New ComboBox()
        lblFDate = New Label()
        dtpFDate = New DateTimePicker()
        lblFShift = New Label()
        cboFShift = New ComboBox()
        lblFNote = New Label()
        txtFNote = New TextBox()
        lblSec1 = New Label()
        pnlFoot = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        pnlHdr = New Panel()
        lblHdrBadge = New Label()
        lblHdrSub = New Label()
        lblHdrTitle = New Label()
        pnlHdrIcon = New Panel()
        splitter = New Splitter()
        pnlLeft = New Panel()
        dgv = New DataGridView()
        colDate = New DataGridViewTextBoxColumn()
        colEmp = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colCheckIn = New DataGridViewTextBoxColumn()
        colCheckOut = New DataGridViewTextBoxColumn()
        colHours = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFoot = New Panel()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        cboDeptFilter = New ComboBox()
        cboMonthFilter = New ComboBox()
        txtSearch = New TextBox()
        toolTip1 = New ToolTip(components)
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
        pnlSec2.SuspendLayout()
        tlpSec2.SuspendLayout()
        pnlSec1.SuspendLayout()
        tlpSec1.SuspendLayout()
        pnlFoot.SuspendLayout()
        pnlHdr.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftFoot.SuspendLayout()
        pnlToolbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(1200, 709)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Controls.Add(pnlRight)
        pnlContent.Controls.Add(splitter)
        pnlContent.Controls.Add(pnlLeft)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 52)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1200, 657)
        pnlContent.TabIndex = 0
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlFormScroll)
        pnlRight.Controls.Add(pnlFoot)
        pnlRight.Controls.Add(pnlHdr)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(700, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(500, 657)
        pnlRight.TabIndex = 0
        ' 
        ' pnlFormScroll
        ' 
        pnlFormScroll.AutoScroll = True
        pnlFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFormScroll.Controls.Add(pnlSec2)
        pnlFormScroll.Controls.Add(pnlSec1)
        pnlFormScroll.Dock = DockStyle.Fill
        pnlFormScroll.Location = New Point(0, 88)
        pnlFormScroll.Name = "pnlFormScroll"
        pnlFormScroll.Padding = New Padding(16, 14, 16, 14)
        pnlFormScroll.Size = New Size(500, 517)
        pnlFormScroll.TabIndex = 0
        ' 
        ' pnlSec2
        ' 
        pnlSec2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec2.Controls.Add(tlpSec2)
        pnlSec2.Controls.Add(lblSec2)
        pnlSec2.Dock = DockStyle.Top
        pnlSec2.Location = New Point(16, 262)
        pnlSec2.Margin = New Padding(0, 10, 0, 10)
        pnlSec2.Name = "pnlSec2"
        pnlSec2.Padding = New Padding(16, 12, 16, 12)
        pnlSec2.Size = New Size(468, 220)
        pnlSec2.TabIndex = 1
        ' 
        ' tlpSec2
        ' 
        tlpSec2.BackColor = Color.Transparent
        tlpSec2.ColumnCount = 2
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.Controls.Add(lblFCheckIn, 0, 0)
        tlpSec2.Controls.Add(txtFCheckIn, 0, 1)
        tlpSec2.Controls.Add(lblFCheckOut, 1, 0)
        tlpSec2.Controls.Add(txtFCheckOut, 1, 1)
        tlpSec2.Controls.Add(lblFHours, 0, 2)
        tlpSec2.Controls.Add(txtFHours, 0, 3)
        tlpSec2.Controls.Add(lblFStatus, 1, 2)
        tlpSec2.Controls.Add(cboFStatus, 1, 3)
        tlpSec2.Dock = DockStyle.Bottom
        tlpSec2.Location = New Point(16, 32)
        tlpSec2.Name = "tlpSec2"
        tlpSec2.RowCount = 4
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec2.Size = New Size(436, 176)
        tlpSec2.TabIndex = 0
        ' 
        ' lblFCheckIn
        ' 
        lblFCheckIn.AutoSize = True
        lblFCheckIn.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCheckIn.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCheckIn.Location = New Point(3, 0)
        lblFCheckIn.Name = "lblFCheckIn"
        lblFCheckIn.Size = New Size(81, 19)
        lblFCheckIn.TabIndex = 0
        lblFCheckIn.Text = "Giờ vào  *"
        ' 
        ' txtFCheckIn
        ' 
        txtFCheckIn.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFCheckIn.BorderStyle = BorderStyle.FixedSingle
        txtFCheckIn.Dock = DockStyle.Fill
        txtFCheckIn.Font = New Font("Microsoft YaHei UI", 10F)
        txtFCheckIn.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFCheckIn.Location = New Point(0, 22)
        txtFCheckIn.Margin = New Padding(0, 0, 8, 4)
        txtFCheckIn.Name = "txtFCheckIn"
        txtFCheckIn.Size = New Size(210, 29)
        txtFCheckIn.TabIndex = 4
        ' 
        ' lblFCheckOut
        ' 
        lblFCheckOut.AutoSize = True
        lblFCheckOut.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCheckOut.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCheckOut.Location = New Point(226, 0)
        lblFCheckOut.Margin = New Padding(8, 0, 0, 0)
        lblFCheckOut.Name = "lblFCheckOut"
        lblFCheckOut.Size = New Size(68, 19)
        lblFCheckOut.TabIndex = 1
        lblFCheckOut.Text = "Giờ ra  *"
        ' 
        ' txtFCheckOut
        ' 
        txtFCheckOut.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFCheckOut.BorderStyle = BorderStyle.FixedSingle
        txtFCheckOut.Dock = DockStyle.Fill
        txtFCheckOut.Font = New Font("Microsoft YaHei UI", 10F)
        txtFCheckOut.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFCheckOut.Location = New Point(226, 22)
        txtFCheckOut.Margin = New Padding(8, 0, 0, 4)
        txtFCheckOut.Name = "txtFCheckOut"
        txtFCheckOut.Size = New Size(210, 29)
        txtFCheckOut.TabIndex = 5
        ' 
        ' lblFHours
        ' 
        lblFHours.AutoSize = True
        lblFHours.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFHours.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFHours.Location = New Point(3, 62)
        lblFHours.Name = "lblFHours"
        lblFHours.Size = New Size(76, 19)
        lblFHours.TabIndex = 2
        lblFHours.Text = "Tổng giờ"
        ' 
        ' txtFHours
        ' 
        txtFHours.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFHours.BorderStyle = BorderStyle.FixedSingle
        txtFHours.Dock = DockStyle.Fill
        txtFHours.Font = New Font("Microsoft YaHei UI", 10F)
        txtFHours.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFHours.Location = New Point(0, 84)
        txtFHours.Margin = New Padding(0, 0, 8, 4)
        txtFHours.Name = "txtFHours"
        txtFHours.Size = New Size(210, 29)
        txtFHours.TabIndex = 6
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(226, 62)
        lblFStatus.Margin = New Padding(8, 0, 0, 0)
        lblFStatus.Name = "lblFStatus"
        lblFStatus.Size = New Size(97, 19)
        lblFStatus.TabIndex = 3
        lblFStatus.Text = "Trạng thái *"
        ' 
        ' cboFStatus
        ' 
        cboFStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFStatus.Dock = DockStyle.Fill
        cboFStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFStatus.FlatStyle = FlatStyle.Flat
        cboFStatus.Font = New Font("Microsoft YaHei UI", 10F)
        cboFStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFStatus.Location = New Point(226, 84)
        cboFStatus.Margin = New Padding(8, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(210, 31)
        cboFStatus.TabIndex = 7
        ' 
        ' lblSec2
        ' 
        lblSec2.AutoSize = True
        lblSec2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec2.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec2.Location = New Point(16, 12)
        lblSec2.Name = "lblSec2"
        lblSec2.Size = New Size(178, 19)
        lblSec2.TabIndex = 1
        lblSec2.Text = "GIỜ LÀM & TRẠNG THÁI"
        ' 
        ' pnlSec1
        ' 
        pnlSec1.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec1.Controls.Add(tlpSec1)
        pnlSec1.Controls.Add(lblSec1)
        pnlSec1.Dock = DockStyle.Top
        pnlSec1.Location = New Point(16, 14)
        pnlSec1.Name = "pnlSec1"
        pnlSec1.Padding = New Padding(16, 12, 16, 12)
        pnlSec1.Size = New Size(468, 248)
        pnlSec1.TabIndex = 0
        ' 
        ' tlpSec1
        ' 
        tlpSec1.BackColor = Color.Transparent
        tlpSec1.ColumnCount = 2
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.Controls.Add(lblFEmp, 0, 0)
        tlpSec1.Controls.Add(cboFEmp, 0, 1)
        tlpSec1.Controls.Add(lblFDept, 1, 0)
        tlpSec1.Controls.Add(cboFDept, 1, 1)
        tlpSec1.Controls.Add(lblFDate, 0, 2)
        tlpSec1.Controls.Add(dtpFDate, 0, 3)
        tlpSec1.Controls.Add(lblFShift, 1, 2)
        tlpSec1.Controls.Add(cboFShift, 1, 3)
        tlpSec1.Controls.Add(lblFNote, 0, 4)
        tlpSec1.Controls.Add(txtFNote, 0, 5)
        tlpSec1.Dock = DockStyle.Bottom
        tlpSec1.Location = New Point(16, 22)
        tlpSec1.Name = "tlpSec1"
        tlpSec1.RowCount = 6
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 68F))
        tlpSec1.Size = New Size(436, 214)
        tlpSec1.TabIndex = 0
        ' 
        ' lblFEmp
        ' 
        lblFEmp.AutoSize = True
        lblFEmp.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFEmp.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFEmp.Location = New Point(3, 0)
        lblFEmp.Name = "lblFEmp"
        lblFEmp.Size = New Size(102, 19)
        lblFEmp.TabIndex = 0
        lblFEmp.Text = "Nhân viên  *"
        ' 
        ' cboFEmp
        ' 
        cboFEmp.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFEmp.Dock = DockStyle.Fill
        cboFEmp.DropDownStyle = ComboBoxStyle.DropDownList
        cboFEmp.FlatStyle = FlatStyle.Flat
        cboFEmp.Font = New Font("Microsoft YaHei UI", 10F)
        cboFEmp.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFEmp.Location = New Point(0, 22)
        cboFEmp.Margin = New Padding(0, 0, 8, 4)
        cboFEmp.Name = "cboFEmp"
        cboFEmp.Size = New Size(210, 31)
        cboFEmp.TabIndex = 0
        ' 
        ' lblFDept
        ' 
        lblFDept.AutoSize = True
        lblFDept.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFDept.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFDept.Location = New Point(226, 0)
        lblFDept.Margin = New Padding(8, 0, 0, 0)
        lblFDept.Name = "lblFDept"
        lblFDept.Size = New Size(107, 19)
        lblFDept.TabIndex = 1
        lblFDept.Text = "Phòng ban  *"
        ' 
        ' cboFDept
        ' 
        cboFDept.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFDept.Dock = DockStyle.Fill
        cboFDept.DropDownStyle = ComboBoxStyle.DropDownList
        cboFDept.FlatStyle = FlatStyle.Flat
        cboFDept.Font = New Font("Microsoft YaHei UI", 10F)
        cboFDept.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFDept.Location = New Point(226, 22)
        cboFDept.Margin = New Padding(8, 0, 0, 4)
        cboFDept.Name = "cboFDept"
        cboFDept.Size = New Size(210, 31)
        cboFDept.TabIndex = 1
        ' 
        ' lblFDate
        ' 
        lblFDate.AutoSize = True
        lblFDate.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFDate.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFDate.Location = New Point(3, 62)
        lblFDate.Name = "lblFDate"
        lblFDate.Size = New Size(111, 19)
        lblFDate.TabIndex = 2
        lblFDate.Text = "Ngày chấm  *"
        ' 
        ' dtpFDate
        ' 
        dtpFDate.CustomFormat = "dd/MM/yyyy"
        dtpFDate.Dock = DockStyle.Fill
        dtpFDate.Font = New Font("Microsoft YaHei UI", 10F)
        dtpFDate.Format = DateTimePickerFormat.Custom
        dtpFDate.Location = New Point(0, 84)
        dtpFDate.Margin = New Padding(0, 0, 8, 4)
        dtpFDate.Name = "dtpFDate"
        dtpFDate.Size = New Size(210, 29)
        dtpFDate.TabIndex = 2
        ' 
        ' lblFShift
        ' 
        lblFShift.AutoSize = True
        lblFShift.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFShift.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFShift.Location = New Point(226, 62)
        lblFShift.Margin = New Padding(8, 0, 0, 0)
        lblFShift.Name = "lblFShift"
        lblFShift.Size = New Size(60, 19)
        lblFShift.TabIndex = 3
        lblFShift.Text = "Ca làm"
        ' 
        ' cboFShift
        ' 
        cboFShift.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFShift.Dock = DockStyle.Fill
        cboFShift.DropDownStyle = ComboBoxStyle.DropDownList
        cboFShift.FlatStyle = FlatStyle.Flat
        cboFShift.Font = New Font("Microsoft YaHei UI", 10F)
        cboFShift.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFShift.Location = New Point(226, 84)
        cboFShift.Margin = New Padding(8, 0, 0, 4)
        cboFShift.Name = "cboFShift"
        cboFShift.Size = New Size(210, 31)
        cboFShift.TabIndex = 3
        ' 
        ' lblFNote
        ' 
        lblFNote.AutoSize = True
        tlpSec1.SetColumnSpan(lblFNote, 2)
        lblFNote.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFNote.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFNote.Location = New Point(3, 124)
        lblFNote.Name = "lblFNote"
        lblFNote.Size = New Size(66, 19)
        lblFNote.TabIndex = 4
        lblFNote.Text = "Ghi chú"
        ' 
        ' txtFNote
        ' 
        txtFNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFNote.BorderStyle = BorderStyle.FixedSingle
        tlpSec1.SetColumnSpan(txtFNote, 2)
        txtFNote.Dock = DockStyle.Fill
        txtFNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtFNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFNote.Location = New Point(3, 149)
        txtFNote.Multiline = True
        txtFNote.Name = "txtFNote"
        txtFNote.ScrollBars = ScrollBars.Vertical
        txtFNote.Size = New Size(430, 62)
        txtFNote.TabIndex = 4
        ' 
        ' lblSec1
        ' 
        lblSec1.AutoSize = True
        lblSec1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1.Location = New Point(16, 12)
        lblSec1.Name = "lblSec1"
        lblSec1.Size = New Size(198, 19)
        lblSec1.TabIndex = 1
        lblSec1.Text = "THÔNG TIN CHẤM CÔNG"
        ' 
        ' pnlFoot
        ' 
        pnlFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlFoot.Controls.Add(btnSave)
        pnlFoot.Controls.Add(btnClear)
        pnlFoot.Controls.Add(btnDelete)
        pnlFoot.Dock = DockStyle.Bottom
        pnlFoot.Location = New Point(0, 605)
        pnlFoot.Name = "pnlFoot"
        pnlFoot.Size = New Size(500, 52)
        pnlFoot.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSave.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(1354, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "✓  Lưu chấm công"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Microsoft YaHei UI", 9F)
        btnClear.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnClear.Location = New Point(1244, 10)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 32)
        btnClear.TabIndex = 1
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(25), CByte(229), CByte(62), CByte(62))
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(229), CByte(62), CByte(62))
        btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(50), CByte(229), CByte(62), CByte(62))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Microsoft YaHei UI", 9F)
        btnDelete.ForeColor = Color.FromArgb(CByte(240), CByte(128), CByte(128))
        btnDelete.Location = New Point(14, 10)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(150, 32)
        btnDelete.TabIndex = 0
        btnDelete.Text = "Xóa chấm công"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' pnlHdr
        ' 
        pnlHdr.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlHdr.Controls.Add(lblHdrBadge)
        pnlHdr.Controls.Add(lblHdrSub)
        pnlHdr.Controls.Add(lblHdrTitle)
        pnlHdr.Controls.Add(pnlHdrIcon)
        pnlHdr.Dock = DockStyle.Top
        pnlHdr.Location = New Point(0, 0)
        pnlHdr.Name = "pnlHdr"
        pnlHdr.Padding = New Padding(16, 12, 16, 12)
        pnlHdr.Size = New Size(500, 88)
        pnlHdr.TabIndex = 2
        ' 
        ' lblHdrBadge
        ' 
        lblHdrBadge.AutoSize = True
        lblHdrBadge.BackColor = Color.FromArgb(CByte(20), CByte(76), CByte(175), CByte(80))
        lblHdrBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrBadge.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblHdrBadge.Location = New Point(78, 56)
        lblHdrBadge.Name = "lblHdrBadge"
        lblHdrBadge.Padding = New Padding(6, 2, 6, 2)
        lblHdrBadge.Size = New Size(95, 24)
        lblHdrBadge.TabIndex = 0
        lblHdrBadge.Text = "● Đủ công"
        ' 
        ' lblHdrSub
        ' 
        lblHdrSub.AutoSize = True
        lblHdrSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblHdrSub.Location = New Point(78, 38)
        lblHdrSub.Name = "lblHdrSub"
        lblHdrSub.Size = New Size(180, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Chọn dòng để chỉnh sửa"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(76, 12)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(222, 30)
        lblHdrTitle.TabIndex = 2
        lblHdrTitle.Text = "Chi tiết chấm công"
        ' 
        ' pnlHdrIcon
        ' 
        pnlHdrIcon.BackColor = Color.FromArgb(CByte(15), CByte(123), CByte(97), CByte(255))
        pnlHdrIcon.Location = New Point(16, 14)
        pnlHdrIcon.Name = "pnlHdrIcon"
        pnlHdrIcon.Size = New Size(50, 50)
        pnlHdrIcon.TabIndex = 3
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(699, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 657)
        splitter.TabIndex = 1
        splitter.TabStop = False
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(dgv)
        pnlLeft.Controls.Add(pnlLeftFoot)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(699, 657)
        pnlLeft.TabIndex = 2
        ' 
        ' dgv
        ' 
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgv.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgv.ColumnHeadersHeight = 40
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.Columns.AddRange(New DataGridViewColumn() {colDate, colEmp, colDept, colCheckIn, colCheckOut, colHours, colStatus})
        dgv.Cursor = Cursors.Hand
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle8.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle8.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle8
        dgv.Dock = DockStyle.Fill
        dgv.EnableHeadersVisualStyles = False
        dgv.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgv.Location = New Point(0, 0)
        dgv.MultiSelect = False
        dgv.Name = "dgv"
        dgv.ReadOnly = True
        dgv.RowHeadersVisible = False
        dgv.RowHeadersWidth = 51
        dgv.RowTemplate.Height = 46
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.Size = New Size(699, 621)
        dgv.TabIndex = 0
        ' 
        ' colDate
        ' 
        DataGridViewCellStyle3.Font = New Font("Courier New", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colDate.DefaultCellStyle = DataGridViewCellStyle3
        colDate.HeaderText = "NGÀY"
        colDate.MinimumWidth = 6
        colDate.Name = "colDate"
        colDate.ReadOnly = True
        colDate.Width = 90
        ' 
        ' colEmp
        ' 
        colEmp.HeaderText = "NHÂN VIÊN"
        colEmp.MinimumWidth = 6
        colEmp.Name = "colEmp"
        colEmp.ReadOnly = True
        colEmp.Width = 160
        ' 
        ' colDept
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colDept.DefaultCellStyle = DataGridViewCellStyle4
        colDept.HeaderText = "PHÒNG BAN"
        colDept.MinimumWidth = 6
        colDept.Name = "colDept"
        colDept.ReadOnly = True
        colDept.Width = 120
        ' 
        ' colCheckIn
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        colCheckIn.DefaultCellStyle = DataGridViewCellStyle5
        colCheckIn.HeaderText = "GIỜ VÀO"
        colCheckIn.MinimumWidth = 6
        colCheckIn.Name = "colCheckIn"
        colCheckIn.ReadOnly = True
        colCheckIn.Width = 90
        ' 
        ' colCheckOut
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        colCheckOut.DefaultCellStyle = DataGridViewCellStyle6
        colCheckOut.HeaderText = "GIỜ RA"
        colCheckOut.MinimumWidth = 6
        colCheckOut.Name = "colCheckOut"
        colCheckOut.ReadOnly = True
        colCheckOut.Width = 90
        ' 
        ' colHours
        ' 
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        colHours.DefaultCellStyle = DataGridViewCellStyle7
        colHours.HeaderText = "GIỜ"
        colHours.MinimumWidth = 6
        colHours.Name = "colHours"
        colHours.ReadOnly = True
        colHours.Width = 70
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 110
        ' 
        ' pnlLeftFoot
        ' 
        pnlLeftFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlLeftFoot.Controls.Add(lblRowInfo)
        pnlLeftFoot.Dock = DockStyle.Bottom
        pnlLeftFoot.Location = New Point(0, 621)
        pnlLeftFoot.Name = "pnlLeftFoot"
        pnlLeftFoot.Size = New Size(699, 36)
        pnlLeftFoot.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(61, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "0 dòng"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(cboDeptFilter)
        pnlToolbar.Controls.Add(cboMonthFilter)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1200, 52)
        pnlToolbar.TabIndex = 1
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAdd.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(1016, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(170, 30)
        btnAdd.TabIndex = 4
        btnAdd.Text = "+ Chấm công mới"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Đủ công", "Thiếu", "Nghỉ"})
        cboStatusFilter.Location = New Point(520, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(140, 28)
        cboStatusFilter.TabIndex = 3
        ' 
        ' cboDeptFilter
        ' 
        cboDeptFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDeptFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDeptFilter.FlatStyle = FlatStyle.Flat
        cboDeptFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboDeptFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDeptFilter.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Nhân sự", "Kế toán", "Vận hành"})
        cboDeptFilter.Location = New Point(350, 11)
        cboDeptFilter.Name = "cboDeptFilter"
        cboDeptFilter.Size = New Size(160, 28)
        cboDeptFilter.TabIndex = 2
        ' 
        ' cboMonthFilter
        ' 
        cboMonthFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboMonthFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboMonthFilter.FlatStyle = FlatStyle.Flat
        cboMonthFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboMonthFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboMonthFilter.Items.AddRange(New Object() {"Tất cả tháng", "Tháng 01/2026", "Tháng 02/2026", "Tháng 03/2026"})
        cboMonthFilter.Location = New Point(220, 11)
        cboMonthFilter.Name = "cboMonthFilter"
        cboMonthFilter.Size = New Size(120, 28)
        cboMonthFilter.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Microsoft YaHei UI", 10F)
        txtSearch.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtSearch.Location = New Point(12, 11)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(200, 29)
        txtSearch.TabIndex = 0
        ' 
        ' formAttendance
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 709)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1024, 600)
        Name = "formAttendance"
        Text = "Chấm công"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlFormScroll.ResumeLayout(False)
        pnlSec2.ResumeLayout(False)
        pnlSec2.PerformLayout()
        tlpSec2.ResumeLayout(False)
        tlpSec2.PerformLayout()
        pnlSec1.ResumeLayout(False)
        pnlSec1.PerformLayout()
        tlpSec1.ResumeLayout(False)
        tlpSec1.PerformLayout()
        pnlFoot.ResumeLayout(False)
        pnlHdr.ResumeLayout(False)
        pnlHdr.PerformLayout()
        pnlLeft.ResumeLayout(False)
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftFoot.ResumeLayout(False)
        pnlLeftFoot.PerformLayout()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboMonthFilter As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeptFilter As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckIn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLeftFoot As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents splitter As System.Windows.Forms.Splitter
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlHdr As System.Windows.Forms.Panel
    Friend WithEvents pnlHdrIcon As System.Windows.Forms.Panel
    Friend WithEvents lblHdrTitle As System.Windows.Forms.Label
    Friend WithEvents lblHdrSub As System.Windows.Forms.Label
    Friend WithEvents lblHdrBadge As System.Windows.Forms.Label
    Friend WithEvents pnlFormScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlSec2 As System.Windows.Forms.Panel
    Friend WithEvents lblSec2 As System.Windows.Forms.Label
    Friend WithEvents tlpSec2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCheckIn As System.Windows.Forms.Label
    Friend WithEvents txtFCheckIn As System.Windows.Forms.TextBox
    Friend WithEvents lblFCheckOut As System.Windows.Forms.Label
    Friend WithEvents txtFCheckOut As System.Windows.Forms.TextBox
    Friend WithEvents lblFHours As System.Windows.Forms.Label
    Friend WithEvents txtFHours As System.Windows.Forms.TextBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents tlpSec1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFEmp As System.Windows.Forms.Label
    Friend WithEvents cboFEmp As System.Windows.Forms.ComboBox
    Friend WithEvents lblFDept As System.Windows.Forms.Label
    Friend WithEvents cboFDept As System.Windows.Forms.ComboBox
    Friend WithEvents lblFDate As System.Windows.Forms.Label
    Friend WithEvents dtpFDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFShift As System.Windows.Forms.Label
    Friend WithEvents cboFShift As System.Windows.Forms.ComboBox
    Friend WithEvents lblFNote As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlFoot As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
End Class
