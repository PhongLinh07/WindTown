<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formSalaryMult
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlTab2 = New Panel()
        pnlRight = New Panel()
        pnlFormScroll = New Panel()
        pnlSec1 = New Panel()
        tlp = New TableLayoutPanel()
        lblFCode = New Label()
        txtFCode = New TextBox()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
        lblFJob = New Label()
        cboFJob = New ComboBox()
        lblFLevel = New Label()
        cboFLevel = New ComboBox()
        lblFMult = New Label()
        pnlMultCtrl = New Panel()
        lblMultPreviewVal = New Label()
        lblMultPreview = New Label()
        lblMultHint = New Label()
        txtFMult = New TextBox()
        lblFNote = New Label()
        txtFNote = New TextBox()
        lblSec1 = New Label()
        pnlFoot = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        pnlHdr = New Panel()
        lblHdrSub = New Label()
        lblHdrTitle = New Label()
        splitter = New Splitter()
        pnlLeft = New Panel()
        dgvDetail = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colJob = New DataGridViewTextBoxColumn()
        colLevel = New DataGridViewTextBoxColumn()
        colMult = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFoot = New Panel()
        lblRowInfo = New Label()
        pnlTab1 = New Panel()
        dgvMatrix = New DataGridView()
        colJobMatrix = New DataGridViewTextBoxColumn()
        pnlMatrixHeader = New Panel()
        lblLegend2 = New Label()
        lblLegend1 = New Label()
        lblMatrixSub = New Label()
        lblMatrixTitle = New Label()
        pnlTabBar = New Panel()
        pnlTabIndicator = New Panel()
        btnTab2 = New Button()
        btnTab1 = New Button()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        btnExport = New Button()
        cboDeptFilter = New ComboBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTab2.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
        pnlSec1.SuspendLayout()
        tlp.SuspendLayout()
        pnlMultCtrl.SuspendLayout()
        pnlFoot.SuspendLayout()
        pnlHdr.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(dgvDetail, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftFoot.SuspendLayout()
        pnlTab1.SuspendLayout()
        CType(dgvMatrix, ComponentModel.ISupportInitialize).BeginInit()
        pnlMatrixHeader.SuspendLayout()
        pnlTabBar.SuspendLayout()
        pnlToolbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlTabBar)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(882, 553)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Controls.Add(pnlTab2)
        pnlContent.Controls.Add(pnlTab1)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 96)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(882, 457)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTab2
        ' 
        pnlTab2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab2.Controls.Add(pnlRight)
        pnlTab2.Controls.Add(splitter)
        pnlTab2.Controls.Add(pnlLeft)
        pnlTab2.Dock = DockStyle.Fill
        pnlTab2.Location = New Point(0, 0)
        pnlTab2.Name = "pnlTab2"
        pnlTab2.Size = New Size(882, 457)
        pnlTab2.TabIndex = 0
        pnlTab2.Visible = False
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlFormScroll)
        pnlRight.Controls.Add(pnlFoot)
        pnlRight.Controls.Add(pnlHdr)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(521, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(361, 457)
        pnlRight.TabIndex = 0
        ' 
        ' pnlFormScroll
        ' 
        pnlFormScroll.AutoScroll = True
        pnlFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFormScroll.Controls.Add(pnlSec1)
        pnlFormScroll.Dock = DockStyle.Fill
        pnlFormScroll.Location = New Point(0, 64)
        pnlFormScroll.Name = "pnlFormScroll"
        pnlFormScroll.Padding = New Padding(16, 14, 16, 14)
        pnlFormScroll.Size = New Size(361, 341)
        pnlFormScroll.TabIndex = 0
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
        pnlSec1.Size = New Size(308, 420)
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
        tlp.Controls.Add(lblFStatus, 1, 0)
        tlp.Controls.Add(cboFStatus, 1, 1)
        tlp.Controls.Add(lblFJob, 0, 2)
        tlp.Controls.Add(cboFJob, 0, 3)
        tlp.Controls.Add(lblFLevel, 1, 2)
        tlp.Controls.Add(cboFLevel, 1, 3)
        tlp.Controls.Add(lblFMult, 0, 4)
        tlp.Controls.Add(pnlMultCtrl, 0, 5)
        tlp.Controls.Add(lblFNote, 0, 6)
        tlp.Controls.Add(txtFNote, 0, 7)
        tlp.Dock = DockStyle.Bottom
        tlp.Location = New Point(16, 20)
        tlp.Name = "tlp"
        tlp.RowCount = 8
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 68F))
        tlp.Size = New Size(276, 388)
        tlp.TabIndex = 0
        ' 
        ' lblFCode
        ' 
        lblFCode.AutoSize = True
        lblFCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCode.Location = New Point(3, 0)
        lblFCode.Name = "lblFCode"
        lblFCode.Size = New Size(92, 19)
        lblFCode.TabIndex = 0
        lblFCode.Text = "Mã hệ số  *"
        ' 
        ' txtFCode
        ' 
        txtFCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFCode.BorderStyle = BorderStyle.FixedSingle
        txtFCode.Dock = DockStyle.Fill
        txtFCode.Font = New Font("Courier New", 10F)
        txtFCode.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        txtFCode.Location = New Point(0, 22)
        txtFCode.Margin = New Padding(0, 0, 8, 4)
        txtFCode.Name = "txtFCode"
        txtFCode.Size = New Size(130, 26)
        txtFCode.TabIndex = 0
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(146, 0)
        lblFStatus.Margin = New Padding(8, 0, 0, 0)
        lblFStatus.Name = "lblFStatus"
        lblFStatus.Size = New Size(86, 19)
        lblFStatus.TabIndex = 1
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
        cboFStatus.Items.AddRange(New Object() {"Đang dùng", "Ngừng dùng"})
        cboFStatus.Location = New Point(146, 22)
        cboFStatus.Margin = New Padding(8, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(130, 31)
        cboFStatus.TabIndex = 1
        ' 
        ' lblFJob
        ' 
        lblFJob.AutoSize = True
        lblFJob.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFJob.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFJob.Location = New Point(3, 62)
        lblFJob.Name = "lblFJob"
        lblFJob.Size = New Size(104, 19)
        lblFJob.TabIndex = 2
        lblFJob.Text = "Chức danh  *"
        ' 
        ' cboFJob
        ' 
        cboFJob.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFJob.Dock = DockStyle.Fill
        cboFJob.DropDownStyle = ComboBoxStyle.DropDownList
        cboFJob.FlatStyle = FlatStyle.Flat
        cboFJob.Font = New Font("Microsoft YaHei UI", 10F)
        cboFJob.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFJob.Location = New Point(0, 84)
        cboFJob.Margin = New Padding(0, 0, 8, 4)
        cboFJob.Name = "cboFJob"
        cboFJob.Size = New Size(130, 31)
        cboFJob.TabIndex = 2
        ' 
        ' lblFLevel
        ' 
        lblFLevel.AutoSize = True
        lblFLevel.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFLevel.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFLevel.Location = New Point(146, 62)
        lblFLevel.Margin = New Padding(8, 0, 0, 0)
        lblFLevel.Name = "lblFLevel"
        lblFLevel.Size = New Size(84, 19)
        lblFLevel.TabIndex = 3
        lblFLevel.Text = "Cấp bậc  *"
        ' 
        ' cboFLevel
        ' 
        cboFLevel.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFLevel.Dock = DockStyle.Fill
        cboFLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cboFLevel.FlatStyle = FlatStyle.Flat
        cboFLevel.Font = New Font("Microsoft YaHei UI", 10F)
        cboFLevel.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFLevel.Location = New Point(146, 84)
        cboFLevel.Margin = New Padding(8, 0, 0, 4)
        cboFLevel.Name = "cboFLevel"
        cboFLevel.Size = New Size(130, 31)
        cboFLevel.TabIndex = 3
        ' 
        ' lblFMult
        ' 
        lblFMult.AutoSize = True
        tlp.SetColumnSpan(lblFMult, 2)
        lblFMult.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFMult.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFMult.Location = New Point(3, 124)
        lblFMult.Name = "lblFMult"
        lblFMult.Size = New Size(168, 19)
        lblFMult.TabIndex = 4
        lblFMult.Text = "Hệ số lương  (mult)  *"
        ' 
        ' pnlMultCtrl
        ' 
        pnlMultCtrl.BackColor = Color.Transparent
        tlp.SetColumnSpan(pnlMultCtrl, 2)
        pnlMultCtrl.Controls.Add(lblMultPreviewVal)
        pnlMultCtrl.Controls.Add(lblMultPreview)
        pnlMultCtrl.Controls.Add(lblMultHint)
        pnlMultCtrl.Controls.Add(txtFMult)
        pnlMultCtrl.Dock = DockStyle.Fill
        pnlMultCtrl.Location = New Point(0, 146)
        pnlMultCtrl.Margin = New Padding(0, 0, 0, 4)
        pnlMultCtrl.Name = "pnlMultCtrl"
        pnlMultCtrl.Size = New Size(276, 76)
        pnlMultCtrl.TabIndex = 5
        ' 
        ' lblMultPreviewVal
        ' 
        lblMultPreviewVal.AutoSize = True
        lblMultPreviewVal.Font = New Font("Microsoft YaHei UI", 11F, FontStyle.Bold)
        lblMultPreviewVal.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblMultPreviewVal.Location = New Point(0, 62)
        lblMultPreviewVal.Name = "lblMultPreviewVal"
        lblMultPreviewVal.Size = New Size(336, 26)
        lblMultPreviewVal.TabIndex = 0
        lblMultPreviewVal.Text = "15,000,000 × 1.00 = 15,000,000 đ"
        ' 
        ' lblMultPreview
        ' 
        lblMultPreview.AutoSize = True
        lblMultPreview.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblMultPreview.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblMultPreview.Location = New Point(0, 44)
        lblMultPreview.Name = "lblMultPreview"
        lblMultPreview.Size = New Size(258, 19)
        lblMultPreview.TabIndex = 1
        lblMultPreview.Text = "Ví dụ với lương CB = 15,000,000đ:"
        ' 
        ' lblMultHint
        ' 
        lblMultHint.AutoSize = True
        lblMultHint.Font = New Font("Microsoft YaHei UI", 9F)
        lblMultHint.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblMultHint.Location = New Point(130, 8)
        lblMultHint.Name = "lblMultHint"
        lblMultHint.Size = New Size(314, 20)
        lblMultHint.TabIndex = 2
        lblMultHint.Text = "Ví dụ: 1.0 = lương CB · 1.5 = lương CB × 1.5"
        ' 
        ' txtFMult
        ' 
        txtFMult.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFMult.BorderStyle = BorderStyle.FixedSingle
        txtFMult.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold)
        txtFMult.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        txtFMult.Location = New Point(0, 0)
        txtFMult.Name = "txtFMult"
        txtFMult.Size = New Size(120, 33)
        txtFMult.TabIndex = 4
        txtFMult.Text = "1.00"
        ' 
        ' lblFNote
        ' 
        lblFNote.AutoSize = True
        tlp.SetColumnSpan(lblFNote, 2)
        lblFNote.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFNote.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFNote.Location = New Point(3, 226)
        lblFNote.Name = "lblFNote"
        lblFNote.Size = New Size(66, 19)
        lblFNote.TabIndex = 6
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
        txtFNote.Location = New Point(3, 251)
        txtFNote.Multiline = True
        txtFNote.Name = "txtFNote"
        txtFNote.ScrollBars = ScrollBars.Vertical
        txtFNote.Size = New Size(270, 134)
        txtFNote.TabIndex = 5
        ' 
        ' lblSec1
        ' 
        lblSec1.AutoSize = True
        lblSec1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1.Location = New Point(16, 12)
        lblSec1.Name = "lblSec1"
        lblSec1.Size = New Size(211, 19)
        lblSec1.TabIndex = 1
        lblSec1.Text = "THÔNG TIN HỆ SỐ LƯƠNG"
        ' 
        ' pnlFoot
        ' 
        pnlFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlFoot.Controls.Add(btnSave)
        pnlFoot.Controls.Add(btnClear)
        pnlFoot.Controls.Add(btnDelete)
        pnlFoot.Dock = DockStyle.Bottom
        pnlFoot.Location = New Point(0, 405)
        pnlFoot.Name = "pnlFoot"
        pnlFoot.Size = New Size(361, 52)
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
        btnSave.Location = New Point(960, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "Lưu hệ số"
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
        btnClear.Location = New Point(850, 10)
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
        btnDelete.Text = "Xóa hệ số"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' pnlHdr
        ' 
        pnlHdr.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlHdr.Controls.Add(lblHdrSub)
        pnlHdr.Controls.Add(lblHdrTitle)
        pnlHdr.Dock = DockStyle.Top
        pnlHdr.Location = New Point(0, 0)
        pnlHdr.Name = "pnlHdr"
        pnlHdr.Padding = New Padding(18, 12, 16, 12)
        pnlHdr.Size = New Size(361, 64)
        pnlHdr.TabIndex = 2
        ' 
        ' lblHdrSub
        ' 
        lblHdrSub.AutoSize = True
        lblHdrSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblHdrSub.Location = New Point(20, 38)
        lblHdrSub.Name = "lblHdrSub"
        lblHdrSub.Size = New Size(179, 20)
        lblHdrSub.TabIndex = 0
        lblHdrSub.Text = "Điền thông tin bên dưới"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(18, 12)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(259, 30)
        lblHdrTitle.TabIndex = 1
        lblHdrTitle.Text = "Thêm hệ số lương mới"
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(520, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 457)
        splitter.TabIndex = 1
        splitter.TabStop = False
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(dgvDetail)
        pnlLeft.Controls.Add(pnlLeftFoot)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(520, 457)
        pnlLeft.TabIndex = 2
        ' 
        ' dgvDetail
        ' 
        dgvDetail.AllowUserToAddRows = False
        dgvDetail.AllowUserToDeleteRows = False
        dgvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvDetail.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvDetail.BorderStyle = BorderStyle.None
        dgvDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvDetail.ColumnHeadersHeight = 40
        dgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvDetail.Columns.AddRange(New DataGridViewColumn() {colCode, colJob, colLevel, colMult, colStatus})
        dgvDetail.Cursor = Cursors.Hand
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle7.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle7.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.False
        dgvDetail.DefaultCellStyle = DataGridViewCellStyle7
        dgvDetail.Dock = DockStyle.Fill
        dgvDetail.EnableHeadersVisualStyles = False
        dgvDetail.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvDetail.Location = New Point(0, 0)
        dgvDetail.MultiSelect = False
        dgvDetail.Name = "dgvDetail"
        dgvDetail.ReadOnly = True
        dgvDetail.RowHeadersVisible = False
        dgvDetail.RowHeadersWidth = 51
        dgvDetail.RowTemplate.Height = 46
        dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetail.Size = New Size(520, 421)
        dgvDetail.TabIndex = 0
        ' 
        ' colCode
        ' 
        DataGridViewCellStyle3.Font = New Font("Courier New", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        colCode.DefaultCellStyle = DataGridViewCellStyle3
        colCode.HeaderText = "MÃ"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 110
        ' 
        ' colJob
        ' 
        colJob.HeaderText = "CHỨC DANH"
        colJob.MinimumWidth = 6
        colJob.Name = "colJob"
        colJob.ReadOnly = True
        colJob.Width = 160
        ' 
        ' colLevel
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colLevel.DefaultCellStyle = DataGridViewCellStyle4
        colLevel.HeaderText = "CẤP BẬC"
        colLevel.MinimumWidth = 6
        colLevel.Name = "colLevel"
        colLevel.ReadOnly = True
        colLevel.Width = 110
        ' 
        ' colMult
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New Font("Microsoft YaHei UI", 11F, FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        colMult.DefaultCellStyle = DataGridViewCellStyle5
        colMult.HeaderText = "HỆ SỐ"
        colMult.MinimumWidth = 6
        colMult.Name = "colMult"
        colMult.ReadOnly = True
        colMult.Width = 80
        ' 
        ' colStatus
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStatus.DefaultCellStyle = DataGridViewCellStyle6
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
        pnlLeftFoot.Location = New Point(0, 421)
        pnlLeftFoot.Name = "pnlLeftFoot"
        pnlLeftFoot.Size = New Size(520, 36)
        pnlLeftFoot.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(59, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "0 hệ số"
        ' 
        ' pnlTab1
        ' 
        pnlTab1.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab1.Controls.Add(dgvMatrix)
        pnlTab1.Controls.Add(pnlMatrixHeader)
        pnlTab1.Dock = DockStyle.Fill
        pnlTab1.Location = New Point(0, 0)
        pnlTab1.Name = "pnlTab1"
        pnlTab1.Size = New Size(882, 457)
        pnlTab1.TabIndex = 1
        ' 
        ' dgvMatrix
        ' 
        dgvMatrix.AllowUserToAddRows = False
        dgvMatrix.AllowUserToDeleteRows = False
        dgvMatrix.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(40), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvMatrix.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        dgvMatrix.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvMatrix.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvMatrix.BorderStyle = BorderStyle.None
        dgvMatrix.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle9.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        DataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvMatrix.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvMatrix.ColumnHeadersHeight = 44
        dgvMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvMatrix.Columns.AddRange(New DataGridViewColumn() {colJobMatrix})
        dgvMatrix.Cursor = Cursors.Hand
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle11.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle11.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(CByte(40), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        dgvMatrix.DefaultCellStyle = DataGridViewCellStyle11
        dgvMatrix.EnableHeadersVisualStyles = False
        dgvMatrix.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvMatrix.Location = New Point(0, 70)
        dgvMatrix.MultiSelect = False
        dgvMatrix.Name = "dgvMatrix"
        dgvMatrix.ReadOnly = True
        dgvMatrix.RowHeadersVisible = False
        dgvMatrix.RowHeadersWidth = 51
        dgvMatrix.RowTemplate.Height = 44
        dgvMatrix.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvMatrix.Size = New Size(922, 507)
        dgvMatrix.TabIndex = 0
        ' 
        ' colJobMatrix
        ' 
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle10.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        DataGridViewCellStyle10.Padding = New Padding(8, 0, 0, 0)
        colJobMatrix.DefaultCellStyle = DataGridViewCellStyle10
        colJobMatrix.Frozen = True
        colJobMatrix.HeaderText = "Chức danh \ Cấp bậc"
        colJobMatrix.MinimumWidth = 6
        colJobMatrix.Name = "colJobMatrix"
        colJobMatrix.ReadOnly = True
        colJobMatrix.Width = 180
        ' 
        ' pnlMatrixHeader
        ' 
        pnlMatrixHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlMatrixHeader.Controls.Add(lblLegend2)
        pnlMatrixHeader.Controls.Add(lblLegend1)
        pnlMatrixHeader.Controls.Add(lblMatrixSub)
        pnlMatrixHeader.Controls.Add(lblMatrixTitle)
        pnlMatrixHeader.Dock = DockStyle.Top
        pnlMatrixHeader.Location = New Point(0, 0)
        pnlMatrixHeader.Name = "pnlMatrixHeader"
        pnlMatrixHeader.Padding = New Padding(16, 10, 16, 10)
        pnlMatrixHeader.Size = New Size(882, 70)
        pnlMatrixHeader.TabIndex = 1
        ' 
        ' lblLegend2
        ' 
        lblLegend2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblLegend2.AutoSize = True
        lblLegend2.BackColor = Color.FromArgb(CByte(15), CByte(123), CByte(139), CByte(178))
        lblLegend2.Font = New Font("Microsoft YaHei UI", 9F)
        lblLegend2.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblLegend2.Location = New Point(1712, 14)
        lblLegend2.Name = "lblLegend2"
        lblLegend2.Padding = New Padding(6, 2, 6, 2)
        lblLegend2.Size = New Size(137, 24)
        lblLegend2.TabIndex = 0
        lblLegend2.Text = "□  Chưa thiết lập"
        ' 
        ' lblLegend1
        ' 
        lblLegend1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblLegend1.AutoSize = True
        lblLegend1.BackColor = Color.FromArgb(CByte(20), CByte(76), CByte(175), CByte(80))
        lblLegend1.Font = New Font("Microsoft YaHei UI", 9F)
        lblLegend1.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblLegend1.Location = New Point(1582, 14)
        lblLegend1.Name = "lblLegend1"
        lblLegend1.Padding = New Padding(6, 2, 6, 2)
        lblLegend1.Size = New Size(120, 24)
        lblLegend1.TabIndex = 1
        lblLegend1.Text = "■  Đã có hệ số"
        ' 
        ' lblMatrixSub
        ' 
        lblMatrixSub.AutoSize = True
        lblMatrixSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblMatrixSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblMatrixSub.Location = New Point(18, 36)
        lblMatrixSub.Name = "lblMatrixSub"
        lblMatrixSub.Size = New Size(468, 20)
        lblMatrixSub.TabIndex = 2
        lblMatrixSub.Text = "Hàng = Chức danh  ·  Cột = Cấp bậc  ·  Giá trị = Hệ số nhân lương"
        ' 
        ' lblMatrixTitle
        ' 
        lblMatrixTitle.AutoSize = True
        lblMatrixTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblMatrixTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblMatrixTitle.Location = New Point(16, 10)
        lblMatrixTitle.Name = "lblMatrixTitle"
        lblMatrixTitle.Size = New Size(235, 30)
        lblMatrixTitle.TabIndex = 3
        lblMatrixTitle.Text = "Ma trận hệ số lương"
        ' 
        ' pnlTabBar
        ' 
        pnlTabBar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlTabBar.Controls.Add(pnlTabIndicator)
        pnlTabBar.Controls.Add(btnTab2)
        pnlTabBar.Controls.Add(btnTab1)
        pnlTabBar.Dock = DockStyle.Top
        pnlTabBar.Location = New Point(0, 52)
        pnlTabBar.Name = "pnlTabBar"
        pnlTabBar.Size = New Size(882, 44)
        pnlTabBar.TabIndex = 1
        ' 
        ' pnlTabIndicator
        ' 
        pnlTabIndicator.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        pnlTabIndicator.Location = New Point(0, 41)
        pnlTabIndicator.Name = "pnlTabIndicator"
        pnlTabIndicator.Size = New Size(180, 3)
        pnlTabIndicator.TabIndex = 0
        ' 
        ' btnTab2
        ' 
        btnTab2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTab2.Cursor = Cursors.Hand
        btnTab2.FlatAppearance.BorderSize = 0
        btnTab2.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTab2.FlatStyle = FlatStyle.Flat
        btnTab2.Font = New Font("Microsoft YaHei UI", 10F)
        btnTab2.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnTab2.Location = New Point(180, 0)
        btnTab2.Name = "btnTab2"
        btnTab2.Size = New Size(180, 42)
        btnTab2.TabIndex = 1
        btnTab2.Text = "Chi tiết"
        btnTab2.UseVisualStyleBackColor = False
        ' 
        ' btnTab1
        ' 
        btnTab1.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTab1.Cursor = Cursors.Hand
        btnTab1.FlatAppearance.BorderSize = 0
        btnTab1.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTab1.FlatStyle = FlatStyle.Flat
        btnTab1.Font = New Font("Microsoft YaHei UI", 10F)
        btnTab1.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnTab1.Location = New Point(0, 0)
        btnTab1.Name = "btnTab1"
        btnTab1.Size = New Size(180, 42)
        btnTab1.TabIndex = 0
        btnTab1.Text = "Ma trận hệ số"
        btnTab1.UseVisualStyleBackColor = False
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(btnExport)
        pnlToolbar.Controls.Add(cboDeptFilter)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(882, 52)
        pnlToolbar.TabIndex = 2
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
        btnAdd.Location = New Point(1812, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(200, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "+ Thêm hệ số lương"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExport.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnExport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Microsoft YaHei UI", 9F)
        btnExport.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnExport.Location = New Point(1692, 11)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(110, 30)
        btnExport.TabIndex = 1
        btnExport.Text = "Xuất Excel"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' cboDeptFilter
        ' 
        cboDeptFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDeptFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDeptFilter.FlatStyle = FlatStyle.Flat
        cboDeptFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboDeptFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDeptFilter.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        cboDeptFilter.Location = New Point(12, 11)
        cboDeptFilter.Name = "cboDeptFilter"
        cboDeptFilter.Size = New Size(180, 28)
        cboDeptFilter.TabIndex = 0
        ' 
        ' formSalaryMult
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(882, 553)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(900, 600)
        Name = "formSalaryMult"
        Text = "Hệ số lương"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTab2.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlFormScroll.ResumeLayout(False)
        pnlSec1.ResumeLayout(False)
        pnlSec1.PerformLayout()
        tlp.ResumeLayout(False)
        tlp.PerformLayout()
        pnlMultCtrl.ResumeLayout(False)
        pnlMultCtrl.PerformLayout()
        pnlFoot.ResumeLayout(False)
        pnlHdr.ResumeLayout(False)
        pnlHdr.PerformLayout()
        pnlLeft.ResumeLayout(False)
        CType(dgvDetail, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftFoot.ResumeLayout(False)
        pnlLeftFoot.PerformLayout()
        pnlTab1.ResumeLayout(False)
        CType(dgvMatrix, ComponentModel.ISupportInitialize).EndInit()
        pnlMatrixHeader.ResumeLayout(False)
        pnlMatrixHeader.PerformLayout()
        pnlTabBar.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents cboDeptFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents pnlTabBar As System.Windows.Forms.Panel
    Friend WithEvents btnTab1 As System.Windows.Forms.Button
    Friend WithEvents btnTab2 As System.Windows.Forms.Button
    Friend WithEvents pnlTabIndicator As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlTab1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMatrixHeader As System.Windows.Forms.Panel
    Friend WithEvents lblMatrixTitle As System.Windows.Forms.Label
    Friend WithEvents lblMatrixSub As System.Windows.Forms.Label
    Friend WithEvents lblLegend1 As System.Windows.Forms.Label
    Friend WithEvents lblLegend2 As System.Windows.Forms.Label
    Friend WithEvents dgvMatrix As System.Windows.Forms.DataGridView
    Friend WithEvents colJobMatrix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlTab2 As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLeftFoot As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents splitter As System.Windows.Forms.Splitter
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlHdr As System.Windows.Forms.Panel
    Friend WithEvents lblHdrTitle As System.Windows.Forms.Label
    Friend WithEvents lblHdrSub As System.Windows.Forms.Label
    Friend WithEvents pnlFormScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents tlp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCode As System.Windows.Forms.Label
    Friend WithEvents txtFCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFJob As System.Windows.Forms.Label
    Friend WithEvents cboFJob As System.Windows.Forms.ComboBox
    Friend WithEvents lblFLevel As System.Windows.Forms.Label
    Friend WithEvents cboFLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblFMult As System.Windows.Forms.Label
    Friend WithEvents pnlMultCtrl As System.Windows.Forms.Panel
    Friend WithEvents txtFMult As System.Windows.Forms.TextBox
    Friend WithEvents lblMultHint As System.Windows.Forms.Label
    Friend WithEvents lblMultPreview As System.Windows.Forms.Label
    Friend WithEvents lblMultPreviewVal As System.Windows.Forms.Label
    Friend WithEvents lblFNote As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlFoot As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
