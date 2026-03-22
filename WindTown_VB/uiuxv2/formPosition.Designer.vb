<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPosition
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
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlRight = New Panel()
        pnlFormScroll = New Panel()
        pnlSec2 = New Panel()
        tlpSec2 = New TableLayoutPanel()
        lblFContract = New Label()
        cboFContract = New ComboBox()
        lblFSalaryMult = New Label()
        cboFSalaryMult = New ComboBox()
        lblFBaseSalary = New Label()
        txtFBaseSalary = New TextBox()
        lblFEffective = New Label()
        dtpEffective = New DateTimePicker()
        lblSec2 = New Label()
        pnlSec1 = New Panel()
        tlp = New TableLayoutPanel()
        lblFCode = New Label()
        txtFCode = New TextBox()
        lblFName = New Label()
        txtFName = New TextBox()
        lblFDept = New Label()
        cboFDept = New ComboBox()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
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
        colCode = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colEmpCount = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFoot = New Panel()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        cboDeptFilter = New ComboBox()
        txtSearch = New TextBox()
        toolTip1 = New ToolTip(components)
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
        pnlSec2.SuspendLayout()
        tlpSec2.SuspendLayout()
        pnlSec1.SuspendLayout()
        tlp.SuspendLayout()
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
        pnlRight.Location = New Point(640, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(560, 657)
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
        pnlFormScroll.Size = New Size(560, 517)
        pnlFormScroll.TabIndex = 0
        ' 
        ' pnlSec2
        ' 
        pnlSec2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec2.Controls.Add(tlpSec2)
        pnlSec2.Controls.Add(lblSec2)
        pnlSec2.Dock = DockStyle.Top
        pnlSec2.Location = New Point(16, 242)
        pnlSec2.Margin = New Padding(0, 10, 0, 10)
        pnlSec2.Name = "pnlSec2"
        pnlSec2.Padding = New Padding(16, 12, 16, 12)
        pnlSec2.Size = New Size(528, 264)
        pnlSec2.TabIndex = 1
        ' 
        ' tlpSec2
        ' 
        tlpSec2.BackColor = Color.Transparent
        tlpSec2.ColumnCount = 2
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.Controls.Add(lblFContract, 0, 0)
        tlpSec2.Controls.Add(cboFContract, 0, 1)
        tlpSec2.Controls.Add(lblFSalaryMult, 1, 0)
        tlpSec2.Controls.Add(cboFSalaryMult, 1, 1)
        tlpSec2.Controls.Add(lblFBaseSalary, 0, 2)
        tlpSec2.Controls.Add(txtFBaseSalary, 0, 3)
        tlpSec2.Controls.Add(lblFEffective, 1, 2)
        tlpSec2.Controls.Add(dtpEffective, 1, 3)
        tlpSec2.Dock = DockStyle.Bottom
        tlpSec2.Location = New Point(16, 32)
        tlpSec2.Name = "tlpSec2"
        tlpSec2.RowCount = 4
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpSec2.Size = New Size(496, 220)
        tlpSec2.TabIndex = 0
        ' 
        ' lblFContract
        ' 
        lblFContract.AutoSize = True
        lblFContract.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFContract.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFContract.Location = New Point(3, 0)
        lblFContract.Name = "lblFContract"
        lblFContract.Size = New Size(133, 19)
        lblFContract.TabIndex = 0
        lblFContract.Text = "Loại hợp đồng  *"
        ' 
        ' cboFContract
        ' 
        cboFContract.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFContract.Dock = DockStyle.Fill
        cboFContract.DropDownStyle = ComboBoxStyle.DropDownList
        cboFContract.FlatStyle = FlatStyle.Flat
        cboFContract.Font = New Font("Microsoft YaHei UI", 10F)
        cboFContract.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFContract.Location = New Point(0, 22)
        cboFContract.Margin = New Padding(0, 0, 8, 4)
        cboFContract.Name = "cboFContract"
        cboFContract.Size = New Size(240, 31)
        cboFContract.TabIndex = 5
        ' 
        ' lblFSalaryMult
        ' 
        lblFSalaryMult.AutoSize = True
        lblFSalaryMult.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFSalaryMult.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFSalaryMult.Location = New Point(256, 0)
        lblFSalaryMult.Margin = New Padding(8, 0, 0, 0)
        lblFSalaryMult.Name = "lblFSalaryMult"
        lblFSalaryMult.Size = New Size(113, 19)
        lblFSalaryMult.TabIndex = 1
        lblFSalaryMult.Text = "Hệ số lương  *"
        ' 
        ' cboFSalaryMult
        ' 
        cboFSalaryMult.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFSalaryMult.Dock = DockStyle.Fill
        cboFSalaryMult.DropDownStyle = ComboBoxStyle.DropDownList
        cboFSalaryMult.FlatStyle = FlatStyle.Flat
        cboFSalaryMult.Font = New Font("Microsoft YaHei UI", 10F)
        cboFSalaryMult.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFSalaryMult.Location = New Point(256, 22)
        cboFSalaryMult.Margin = New Padding(8, 0, 0, 4)
        cboFSalaryMult.Name = "cboFSalaryMult"
        cboFSalaryMult.Size = New Size(240, 31)
        cboFSalaryMult.TabIndex = 6
        ' 
        ' lblFBaseSalary
        ' 
        lblFBaseSalary.AutoSize = True
        lblFBaseSalary.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFBaseSalary.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFBaseSalary.Location = New Point(3, 62)
        lblFBaseSalary.Name = "lblFBaseSalary"
        lblFBaseSalary.Size = New Size(111, 19)
        lblFBaseSalary.TabIndex = 2
        lblFBaseSalary.Text = "Lương cơ bản"
        ' 
        ' txtFBaseSalary
        ' 
        txtFBaseSalary.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFBaseSalary.BorderStyle = BorderStyle.FixedSingle
        txtFBaseSalary.Dock = DockStyle.Fill
        txtFBaseSalary.Font = New Font("Microsoft YaHei UI", 10F)
        txtFBaseSalary.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFBaseSalary.Location = New Point(0, 84)
        txtFBaseSalary.Margin = New Padding(0, 0, 8, 4)
        txtFBaseSalary.Name = "txtFBaseSalary"
        txtFBaseSalary.Size = New Size(240, 29)
        txtFBaseSalary.TabIndex = 7
        ' 
        ' lblFEffective
        ' 
        lblFEffective.AutoSize = True
        lblFEffective.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFEffective.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFEffective.Location = New Point(256, 62)
        lblFEffective.Margin = New Padding(8, 0, 0, 0)
        lblFEffective.Name = "lblFEffective"
        lblFEffective.Size = New Size(112, 19)
        lblFEffective.TabIndex = 3
        lblFEffective.Text = "Ngày hiệu lực"
        ' 
        ' dtpEffective
        ' 
        dtpEffective.CustomFormat = "dd/MM/yyyy"
        dtpEffective.Dock = DockStyle.Fill
        dtpEffective.Font = New Font("Microsoft YaHei UI", 10F)
        dtpEffective.Format = DateTimePickerFormat.Custom
        dtpEffective.Location = New Point(256, 84)
        dtpEffective.Margin = New Padding(8, 0, 0, 4)
        dtpEffective.Name = "dtpEffective"
        dtpEffective.Size = New Size(240, 29)
        dtpEffective.TabIndex = 8
        ' 
        ' lblSec2
        ' 
        lblSec2.AutoSize = True
        lblSec2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec2.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec2.Location = New Point(16, 12)
        lblSec2.Name = "lblSec2"
        lblSec2.Size = New Size(154, 19)
        lblSec2.TabIndex = 1
        lblSec2.Text = "HỢP ĐỒNG & HỆ SỐ"
        ' 
        ' pnlSec1
        ' 
        pnlSec1.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec1.Controls.Add(tlp)
        pnlSec1.Controls.Add(lblSec1)
        pnlSec1.Dock = DockStyle.Top
        pnlSec1.Location = New Point(16, 14)
        pnlSec1.Name = "pnlSec1"
        pnlSec1.Padding = New Padding(16, 12, 16, 12)
        pnlSec1.Size = New Size(528, 228)
        pnlSec1.TabIndex = 0
        ' 
        ' tlp
        ' 
        tlp.BackColor = Color.Transparent
        tlp.ColumnCount = 2
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlp.Controls.Add(lblFCode, 0, 0)
        tlp.Controls.Add(txtFCode, 0, 1)
        tlp.Controls.Add(lblFName, 1, 0)
        tlp.Controls.Add(txtFName, 1, 1)
        tlp.Controls.Add(lblFDept, 0, 2)
        tlp.Controls.Add(cboFDept, 0, 3)
        tlp.Controls.Add(lblFStatus, 1, 2)
        tlp.Controls.Add(cboFStatus, 1, 3)
        tlp.Controls.Add(lblFNote, 0, 4)
        tlp.Controls.Add(txtFNote, 0, 5)
        tlp.Dock = DockStyle.Bottom
        tlp.Location = New Point(16, 22)
        tlp.Name = "tlp"
        tlp.RowCount = 6
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 68F))
        tlp.Size = New Size(496, 194)
        tlp.TabIndex = 0
        ' 
        ' lblFCode
        ' 
        lblFCode.AutoSize = True
        lblFCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCode.Location = New Point(3, 0)
        lblFCode.Name = "lblFCode"
        lblFCode.Size = New Size(85, 19)
        lblFCode.TabIndex = 0
        lblFCode.Text = "Mã vị trí  *"
        ' 
        ' txtFCode
        ' 
        txtFCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFCode.BorderStyle = BorderStyle.FixedSingle
        txtFCode.Dock = DockStyle.Fill
        txtFCode.Font = New Font("Courier New", 10F)
        txtFCode.ForeColor = Color.FromArgb(CByte(123), CByte(97), CByte(255))
        txtFCode.Location = New Point(0, 22)
        txtFCode.Margin = New Padding(0, 0, 8, 4)
        txtFCode.Name = "txtFCode"
        txtFCode.Size = New Size(240, 26)
        txtFCode.TabIndex = 0
        ' 
        ' lblFName
        ' 
        lblFName.AutoSize = True
        lblFName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFName.Location = New Point(256, 0)
        lblFName.Margin = New Padding(8, 0, 0, 0)
        lblFName.Name = "lblFName"
        lblFName.Size = New Size(89, 19)
        lblFName.TabIndex = 1
        lblFName.Text = "Tên vị trí  *"
        ' 
        ' txtFName
        ' 
        txtFName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFName.BorderStyle = BorderStyle.FixedSingle
        txtFName.Dock = DockStyle.Fill
        txtFName.Font = New Font("Microsoft YaHei UI", 10F)
        txtFName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFName.Location = New Point(256, 22)
        txtFName.Margin = New Padding(8, 0, 0, 4)
        txtFName.Name = "txtFName"
        txtFName.Size = New Size(240, 29)
        txtFName.TabIndex = 1
        ' 
        ' lblFDept
        ' 
        lblFDept.AutoSize = True
        lblFDept.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFDept.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFDept.Location = New Point(3, 62)
        lblFDept.Name = "lblFDept"
        lblFDept.Size = New Size(107, 19)
        lblFDept.TabIndex = 2
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
        cboFDept.Location = New Point(0, 84)
        cboFDept.Margin = New Padding(0, 0, 8, 4)
        cboFDept.Name = "cboFDept"
        cboFDept.Size = New Size(240, 31)
        cboFDept.TabIndex = 2
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(256, 62)
        lblFStatus.Margin = New Padding(8, 0, 0, 0)
        lblFStatus.Name = "lblFStatus"
        lblFStatus.Size = New Size(86, 19)
        lblFStatus.TabIndex = 3
        lblFStatus.Text = "Trạng thái"
        ' 
        ' cboFStatus
        ' 
        cboFStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFStatus.Dock = DockStyle.Fill
        cboFStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFStatus.FlatStyle = FlatStyle.Flat
        cboFStatus.Font = New Font("Microsoft YaHei UI", 10F)
        cboFStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFStatus.Items.AddRange(New Object() {"Đang hoạt động", "Ngừng hoạt động"})
        cboFStatus.Location = New Point(256, 84)
        cboFStatus.Margin = New Padding(8, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(240, 31)
        cboFStatus.TabIndex = 3
        ' 
        ' lblFNote
        ' 
        lblFNote.AutoSize = True
        tlp.SetColumnSpan(lblFNote, 2)
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
        tlp.SetColumnSpan(txtFNote, 2)
        txtFNote.Dock = DockStyle.Fill
        txtFNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtFNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFNote.Location = New Point(3, 149)
        txtFNote.Multiline = True
        txtFNote.Name = "txtFNote"
        txtFNote.ScrollBars = ScrollBars.Vertical
        txtFNote.Size = New Size(490, 62)
        txtFNote.TabIndex = 4
        ' 
        ' lblSec1
        ' 
        lblSec1.AutoSize = True
        lblSec1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1.Location = New Point(16, 12)
        lblSec1.Name = "lblSec1"
        lblSec1.Size = New Size(144, 19)
        lblSec1.TabIndex = 1
        lblSec1.Text = "THÔNG TIN VỊ TRÍ"
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
        pnlFoot.Size = New Size(560, 52)
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
        btnSave.Location = New Point(1574, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "Lưu vị trí"
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
        btnClear.Location = New Point(1464, 10)
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
        btnDelete.Size = New Size(130, 32)
        btnDelete.TabIndex = 0
        btnDelete.Text = "Xóa vị trí"
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
        pnlHdr.Size = New Size(560, 88)
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
        lblHdrBadge.Size = New Size(152, 24)
        lblHdrBadge.TabIndex = 0
        lblHdrBadge.Text = "Đang hoạt động"
        ' 
        ' lblHdrSub
        ' 
        lblHdrSub.AutoSize = True
        lblHdrSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblHdrSub.Location = New Point(78, 38)
        lblHdrSub.Name = "lblHdrSub"
        lblHdrSub.Size = New Size(179, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Điền thông tin bên dưới"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(76, 12)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(183, 30)
        lblHdrTitle.TabIndex = 2
        lblHdrTitle.Text = "Thêm vị trí mới"
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
        splitter.Location = New Point(639, 0)
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
        pnlLeft.Size = New Size(639, 657)
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
        dgv.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colDept, colEmpCount, colStatus})
        dgv.Cursor = Cursors.Hand
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle7.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle7.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle7
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
        dgv.Size = New Size(639, 621)
        dgv.TabIndex = 0
        ' 
        ' colCode
        ' 
        DataGridViewCellStyle3.Font = New Font("Courier New", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colCode.DefaultCellStyle = DataGridViewCellStyle3
        colCode.HeaderText = "MÃ"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 125
        ' 
        ' colName
        ' 
        colName.HeaderText = "VỊ TRÍ"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 180
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
        ' colEmpCount
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colEmpCount.DefaultCellStyle = DataGridViewCellStyle5
        colEmpCount.HeaderText = "NHÂN VIÊN"
        colEmpCount.MinimumWidth = 6
        colEmpCount.Name = "colEmpCount"
        colEmpCount.ReadOnly = True
        colEmpCount.Width = 80
        ' 
        ' colStatus
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStatus.DefaultCellStyle = DataGridViewCellStyle6
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 120
        ' 
        ' pnlLeftFoot
        ' 
        pnlLeftFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlLeftFoot.Controls.Add(lblRowInfo)
        pnlLeftFoot.Dock = DockStyle.Bottom
        pnlLeftFoot.Location = New Point(0, 621)
        pnlLeftFoot.Name = "pnlLeftFoot"
        pnlLeftFoot.Size = New Size(639, 36)
        pnlLeftFoot.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(53, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "0 vị trí"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(cboDeptFilter)
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
        btnAdd.Size = New Size(200, 30)
        btnAdd.TabIndex = 3
        btnAdd.Text = "+ Thêm vị trí"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang hoạt động", "Ngừng hoạt động"})
        cboStatusFilter.Location = New Point(392, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(180, 28)
        cboStatusFilter.TabIndex = 2
        ' 
        ' cboDeptFilter
        ' 
        cboDeptFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDeptFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDeptFilter.FlatStyle = FlatStyle.Flat
        cboDeptFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboDeptFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDeptFilter.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        cboDeptFilter.Location = New Point(222, 11)
        cboDeptFilter.Name = "cboDeptFilter"
        cboDeptFilter.Size = New Size(160, 28)
        cboDeptFilter.TabIndex = 1
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
        ' formPosition
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 709)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1000, 600)
        Name = "formPosition"
        Text = "Vị trí"
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
        tlp.ResumeLayout(False)
        tlp.PerformLayout()
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
    Friend WithEvents cboDeptFilter As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpCount As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents lblFContract As System.Windows.Forms.Label
    Friend WithEvents cboFContract As System.Windows.Forms.ComboBox
    Friend WithEvents lblFSalaryMult As System.Windows.Forms.Label
    Friend WithEvents cboFSalaryMult As System.Windows.Forms.ComboBox
    Friend WithEvents lblFBaseSalary As System.Windows.Forms.Label
    Friend WithEvents txtFBaseSalary As System.Windows.Forms.TextBox
    Friend WithEvents lblFEffective As System.Windows.Forms.Label
    Friend WithEvents dtpEffective As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents tlp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCode As System.Windows.Forms.Label
    Friend WithEvents txtFCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblFDept As System.Windows.Forms.Label
    Friend WithEvents cboFDept As System.Windows.Forms.ComboBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFNote As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlFoot As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
End Class
