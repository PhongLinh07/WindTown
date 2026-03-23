<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formDepartment
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlRight = New Panel()
        pnlFormScroll = New Panel()
        pnlSec1 = New Panel()
        tlp = New TableLayoutPanel()
        lblFCode = New Label()
        txtFCode = New TextBox()
        lblFName = New Label()
        txtFName = New TextBox()
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
        colEmpCount = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFoot = New Panel()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        txtSearch = New TextBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
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
        pnlRoot.Size = New Size(1338, 737)
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
        pnlContent.Size = New Size(1338, 685)
        pnlContent.TabIndex = 0
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlFormScroll)
        pnlRight.Controls.Add(pnlFoot)
        pnlRight.Controls.Add(pnlHdr)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(481, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(857, 685)
        pnlRight.TabIndex = 0
        ' 
        ' pnlFormScroll
        ' 
        pnlFormScroll.AutoScroll = True
        pnlFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFormScroll.Controls.Add(pnlSec1)
        pnlFormScroll.Dock = DockStyle.Fill
        pnlFormScroll.Location = New Point(0, 96)
        pnlFormScroll.Name = "pnlFormScroll"
        pnlFormScroll.Padding = New Padding(16, 14, 16, 14)
        pnlFormScroll.Size = New Size(857, 537)
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
        pnlSec1.Size = New Size(825, 332)
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
        tlp.Controls.Add(lblFStatus, 0, 2)
        tlp.Controls.Add(cboFStatus, 0, 3)
        tlp.Controls.Add(lblFNote, 0, 4)
        tlp.Controls.Add(txtFNote, 0, 5)
        tlp.Dock = DockStyle.Bottom
        tlp.Location = New Point(16, 52)
        tlp.Name = "tlp"
        tlp.RowCount = 6
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 68F))
        tlp.Size = New Size(793, 268)
        tlp.TabIndex = 0
        ' 
        ' lblFCode
        ' 
        lblFCode.AutoSize = True
        lblFCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCode.Location = New Point(3, 0)
        lblFCode.Name = "lblFCode"
        lblFCode.Size = New Size(112, 17)
        lblFCode.TabIndex = 0
        lblFCode.Text = "Mã phòng ban  *"
        ' 
        ' txtFCode
        ' 
        txtFCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFCode.BorderStyle = BorderStyle.FixedSingle
        txtFCode.Dock = DockStyle.Fill
        txtFCode.Font = New Font("Courier New", 10F)
        txtFCode.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        txtFCode.Location = New Point(0, 22)
        txtFCode.Margin = New Padding(0, 0, 8, 4)
        txtFCode.Name = "txtFCode"
        txtFCode.Size = New Size(388, 23)
        txtFCode.TabIndex = 0
        ' 
        ' lblFName
        ' 
        lblFName.AutoSize = True
        lblFName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFName.Location = New Point(404, 0)
        lblFName.Margin = New Padding(8, 0, 0, 0)
        lblFName.Name = "lblFName"
        lblFName.Size = New Size(116, 17)
        lblFName.TabIndex = 1
        lblFName.Text = "Tên phòng ban  *"
        ' 
        ' txtFName
        ' 
        txtFName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFName.BorderStyle = BorderStyle.FixedSingle
        txtFName.Dock = DockStyle.Fill
        txtFName.Font = New Font("Microsoft YaHei UI", 10F)
        txtFName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFName.Location = New Point(404, 22)
        txtFName.Margin = New Padding(8, 0, 0, 4)
        txtFName.Name = "txtFName"
        txtFName.Size = New Size(389, 24)
        txtFName.TabIndex = 1
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        tlp.SetColumnSpan(lblFStatus, 2)
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(3, 62)
        lblFStatus.Name = "lblFStatus"
        lblFStatus.Size = New Size(73, 17)
        lblFStatus.TabIndex = 2
        lblFStatus.Text = "Trạng thái"
        ' 
        ' cboFStatus
        ' 
        cboFStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        tlp.SetColumnSpan(cboFStatus, 2)
        cboFStatus.Dock = DockStyle.Fill
        cboFStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFStatus.FlatStyle = FlatStyle.Flat
        cboFStatus.Font = New Font("Microsoft YaHei UI", 10F)
        cboFStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFStatus.Items.AddRange(New Object() {"Đang hoạt động", "Ngừng hoạt động"})
        cboFStatus.Location = New Point(0, 84)
        cboFStatus.Margin = New Padding(0, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(793, 27)
        cboFStatus.TabIndex = 2
        ' 
        ' lblFNote
        ' 
        lblFNote.AutoSize = True
        tlp.SetColumnSpan(lblFNote, 2)
        lblFNote.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFNote.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFNote.Location = New Point(3, 124)
        lblFNote.Name = "lblFNote"
        lblFNote.Size = New Size(55, 17)
        lblFNote.TabIndex = 3
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
        txtFNote.Size = New Size(787, 116)
        txtFNote.TabIndex = 3
        ' 
        ' lblSec1
        ' 
        lblSec1.AutoSize = True
        lblSec1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1.Location = New Point(16, 12)
        lblSec1.Name = "lblSec1"
        lblSec1.Size = New Size(163, 17)
        lblSec1.TabIndex = 1
        lblSec1.Text = "THÔNG TIN PHÒNG BAN"
        ' 
        ' pnlFoot
        ' 
        pnlFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlFoot.Controls.Add(btnSave)
        pnlFoot.Controls.Add(btnClear)
        pnlFoot.Controls.Add(btnDelete)
        pnlFoot.Dock = DockStyle.Bottom
        pnlFoot.Location = New Point(0, 633)
        pnlFoot.Name = "pnlFoot"
        pnlFoot.Size = New Size(857, 52)
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
        btnSave.Location = New Point(1496, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "Lưu phòng ban"
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
        btnClear.Location = New Point(1386, 10)
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
        btnDelete.Text = "Xóa phòng ban"
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
        pnlHdr.Size = New Size(857, 96)
        pnlHdr.TabIndex = 2
        ' 
        ' lblHdrBadge
        ' 
        lblHdrBadge.AutoSize = True
        lblHdrBadge.BackColor = Color.FromArgb(CByte(20), CByte(76), CByte(175), CByte(80))
        lblHdrBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrBadge.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblHdrBadge.Location = New Point(78, 61)
        lblHdrBadge.Name = "lblHdrBadge"
        lblHdrBadge.Padding = New Padding(6, 2, 6, 2)
        lblHdrBadge.Size = New Size(115, 21)
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
        lblHdrSub.Size = New Size(145, 17)
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
        lblHdrTitle.Size = New Size(207, 25)
        lblHdrTitle.TabIndex = 2
        lblHdrTitle.Text = "Thêm phòng ban mới"
        ' 
        ' pnlHdrIcon
        ' 
        pnlHdrIcon.BackColor = Color.FromArgb(CByte(15), CByte(74), CByte(158), CByte(255))
        pnlHdrIcon.Location = New Point(16, 14)
        pnlHdrIcon.Name = "pnlHdrIcon"
        pnlHdrIcon.Size = New Size(50, 50)
        pnlHdrIcon.TabIndex = 3
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(480, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 685)
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
        pnlLeft.Size = New Size(480, 685)
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
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgv.ColumnHeadersHeight = 40
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colEmpCount, colStatus})
        dgv.Cursor = Cursors.Hand
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle6.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle6.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle6
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
        dgv.Size = New Size(480, 649)
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
        colName.HeaderText = "TÊN PHÒNG BAN"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 200
        ' 
        ' colEmpCount
        ' 
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colEmpCount.DefaultCellStyle = DataGridViewCellStyle4
        colEmpCount.HeaderText = "CÔNG VIỆC"
        colEmpCount.MinimumWidth = 6
        colEmpCount.Name = "colEmpCount"
        colEmpCount.ReadOnly = True
        colEmpCount.Width = 88
        ' 
        ' colStatus
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStatus.DefaultCellStyle = DataGridViewCellStyle5
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
        pnlLeftFoot.Location = New Point(0, 649)
        pnlLeftFoot.Name = "pnlLeftFoot"
        pnlLeftFoot.Size = New Size(480, 36)
        pnlLeftFoot.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(83, 17)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "0 phòng ban"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1338, 52)
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
        btnAdd.Location = New Point(2198, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(200, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "+ Thêm phòng ban"
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
        cboStatusFilter.Location = New Point(252, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(180, 25)
        cboStatusFilter.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Microsoft YaHei UI", 10F)
        txtSearch.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtSearch.Location = New Point(12, 11)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(230, 24)
        txtSearch.TabIndex = 0
        ' 
        ' formDepartment
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1338, 737)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(800, 500)
        Name = "formDepartment"
        Text = "Phòng ban"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlFormScroll.ResumeLayout(False)
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
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents tlp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCode As System.Windows.Forms.Label
    Friend WithEvents txtFCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFNote As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlFoot As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class