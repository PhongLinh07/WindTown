
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLeaveCategory
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
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlRight = New Panel()
        pnlDetailScroll = New Panel()
        pnlDetailSection = New Panel()
        tlpDetail = New TableLayoutPanel()
        lblCode = New Label()
        txtCode = New TextBox()
        lblName = New Label()
        txtName = New TextBox()
        lblPaid = New Label()
        cboPaid = New ComboBox()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        lblDays = New Label()
        txtDays = New TextBox()
        lblNote = New Label()
        txtNote = New TextBox()
        lblSecInfo = New Label()
        pnlDetailFoot = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        splitter = New Splitter()
        pnlLeft = New Panel()
        dgvLeaveCat = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colPaid = New DataGridViewTextBoxColumn()
        colDays = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFoot = New Panel()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        txtSearch = New TextBox()
        pnlHdr = New Panel()
        lblHdrBadge = New Label()
        lblHdrSub = New Label()
        lblHdrTitle = New Label()
        toolTip1 = New ToolTip(components)
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlDetailScroll.SuspendLayout()
        pnlDetailSection.SuspendLayout()
        tlpDetail.SuspendLayout()
        pnlDetailFoot.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(dgvLeaveCat, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftFoot.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlHdr.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Controls.Add(pnlHdr)
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
        pnlContent.Location = New Point(0, 124)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1200, 585)
        pnlContent.TabIndex = 2
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlDetailScroll)
        pnlRight.Controls.Add(pnlDetailFoot)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(720, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(480, 585)
        pnlRight.TabIndex = 0
        ' 
        ' pnlDetailScroll
        ' 
        pnlDetailScroll.AutoScroll = True
        pnlDetailScroll.Controls.Add(pnlDetailSection)
        pnlDetailScroll.Dock = DockStyle.Fill
        pnlDetailScroll.Location = New Point(0, 0)
        pnlDetailScroll.Name = "pnlDetailScroll"
        pnlDetailScroll.Padding = New Padding(16, 14, 16, 14)
        pnlDetailScroll.Size = New Size(480, 539)
        pnlDetailScroll.TabIndex = 0
        ' 
        ' pnlDetailSection
        ' 
        pnlDetailSection.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlDetailSection.Controls.Add(tlpDetail)
        pnlDetailSection.Controls.Add(lblSecInfo)
        pnlDetailSection.Dock = DockStyle.Top
        pnlDetailSection.Location = New Point(16, 14)
        pnlDetailSection.Name = "pnlDetailSection"
        pnlDetailSection.Padding = New Padding(16, 12, 16, 12)
        pnlDetailSection.Size = New Size(448, 318)
        pnlDetailSection.TabIndex = 0
        ' 
        ' tlpDetail
        ' 
        tlpDetail.BackColor = Color.Transparent
        tlpDetail.ColumnCount = 2
        tlpDetail.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpDetail.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpDetail.Controls.Add(lblCode, 0, 0)
        tlpDetail.Controls.Add(txtCode, 0, 1)
        tlpDetail.Controls.Add(lblName, 1, 0)
        tlpDetail.Controls.Add(txtName, 1, 1)
        tlpDetail.Controls.Add(lblPaid, 0, 2)
        tlpDetail.Controls.Add(cboPaid, 0, 3)
        tlpDetail.Controls.Add(lblStatus, 1, 2)
        tlpDetail.Controls.Add(cboStatus, 1, 3)
        tlpDetail.Controls.Add(lblDays, 0, 4)
        tlpDetail.Controls.Add(txtDays, 0, 5)
        tlpDetail.Controls.Add(lblNote, 0, 6)
        tlpDetail.Controls.Add(txtNote, 0, 7)
        tlpDetail.Dock = DockStyle.Bottom
        tlpDetail.Location = New Point(16, 32)
        tlpDetail.Name = "tlpDetail"
        tlpDetail.RowCount = 8
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 70F))
        tlpDetail.Size = New Size(416, 274)
        tlpDetail.TabIndex = 0
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblCode.Location = New Point(3, 0)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(79, 19)
        lblCode.TabIndex = 0
        lblCode.Text = "Mã loại  *"
        ' 
        ' txtCode
        ' 
        txtCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtCode.BorderStyle = BorderStyle.FixedSingle
        txtCode.Dock = DockStyle.Fill
        txtCode.Font = New Font("Microsoft YaHei UI", 10F)
        txtCode.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtCode.Location = New Point(0, 22)
        txtCode.Margin = New Padding(0, 0, 8, 4)
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(200, 29)
        txtCode.TabIndex = 0
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblName.Location = New Point(216, 0)
        lblName.Margin = New Padding(8, 0, 0, 0)
        lblName.Name = "lblName"
        lblName.Size = New Size(83, 19)
        lblName.TabIndex = 1
        lblName.Text = "Tên loại  *"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.Dock = DockStyle.Fill
        txtName.Font = New Font("Microsoft YaHei UI", 10F)
        txtName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtName.Location = New Point(216, 22)
        txtName.Margin = New Padding(8, 0, 0, 4)
        txtName.Name = "txtName"
        txtName.Size = New Size(200, 29)
        txtName.TabIndex = 1
        ' 
        ' lblPaid
        ' 
        lblPaid.AutoSize = True
        lblPaid.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPaid.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPaid.Location = New Point(3, 62)
        lblPaid.Name = "lblPaid"
        lblPaid.Size = New Size(118, 19)
        lblPaid.TabIndex = 2
        lblPaid.Text = "Hưởng lương *"
        ' 
        ' cboPaid
        ' 
        cboPaid.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboPaid.Dock = DockStyle.Fill
        cboPaid.DropDownStyle = ComboBoxStyle.DropDownList
        cboPaid.FlatStyle = FlatStyle.Flat
        cboPaid.Font = New Font("Microsoft YaHei UI", 10F)
        cboPaid.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboPaid.Location = New Point(0, 84)
        cboPaid.Margin = New Padding(0, 0, 8, 4)
        cboPaid.Name = "cboPaid"
        cboPaid.Size = New Size(200, 31)
        cboPaid.TabIndex = 2
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblStatus.Location = New Point(216, 62)
        lblStatus.Margin = New Padding(8, 0, 0, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(86, 19)
        lblStatus.TabIndex = 3
        lblStatus.Text = "Trạng thái"
        ' 
        ' cboStatus
        ' 
        cboStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatus.Dock = DockStyle.Fill
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FlatStyle = FlatStyle.Flat
        cboStatus.Font = New Font("Microsoft YaHei UI", 10F)
        cboStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatus.Location = New Point(216, 84)
        cboStatus.Margin = New Padding(8, 0, 0, 4)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(200, 31)
        cboStatus.TabIndex = 3
        ' 
        ' lblDays
        ' 
        lblDays.AutoSize = True
        lblDays.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblDays.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDays.Location = New Point(3, 124)
        lblDays.Name = "lblDays"
        lblDays.Size = New Size(111, 19)
        lblDays.TabIndex = 4
        lblDays.Text = "Số ngày/năm"
        ' 
        ' txtDays
        ' 
        txtDays.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDays.BorderStyle = BorderStyle.FixedSingle
        txtDays.Dock = DockStyle.Fill
        txtDays.Font = New Font("Microsoft YaHei UI", 10F)
        txtDays.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDays.Location = New Point(0, 146)
        txtDays.Margin = New Padding(0, 0, 8, 4)
        txtDays.Name = "txtDays"
        txtDays.Size = New Size(200, 29)
        txtDays.TabIndex = 4
        ' 
        ' lblNote
        ' 
        lblNote.AutoSize = True
        tlpDetail.SetColumnSpan(lblNote, 2)
        lblNote.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblNote.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblNote.Location = New Point(3, 186)
        lblNote.Name = "lblNote"
        lblNote.Size = New Size(66, 19)
        lblNote.TabIndex = 5
        lblNote.Text = "Ghi chú"
        ' 
        ' txtNote
        ' 
        txtNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtNote.BorderStyle = BorderStyle.FixedSingle
        tlpDetail.SetColumnSpan(txtNote, 2)
        txtNote.Dock = DockStyle.Fill
        txtNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtNote.Location = New Point(3, 211)
        txtNote.Multiline = True
        txtNote.Name = "txtNote"
        txtNote.ScrollBars = ScrollBars.Vertical
        txtNote.Size = New Size(410, 64)
        txtNote.TabIndex = 5
        ' 
        ' lblSecInfo
        ' 
        lblSecInfo.AutoSize = True
        lblSecInfo.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSecInfo.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSecInfo.Location = New Point(16, 12)
        lblSecInfo.Name = "lblSecInfo"
        lblSecInfo.Size = New Size(186, 19)
        lblSecInfo.TabIndex = 1
        lblSecInfo.Text = "THÔNG TIN NGHỈ PHÉP"
        ' 
        ' pnlDetailFoot
        ' 
        pnlDetailFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlDetailFoot.Controls.Add(btnSave)
        pnlDetailFoot.Controls.Add(btnClear)
        pnlDetailFoot.Dock = DockStyle.Bottom
        pnlDetailFoot.Location = New Point(0, 539)
        pnlDetailFoot.Name = "pnlDetailFoot"
        pnlDetailFoot.Size = New Size(480, 46)
        pnlDetailFoot.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSave.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(340, 8)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 30)
        btnSave.TabIndex = 1
        btnSave.Text = "Lưu loại nghỉ"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderColor = Color.FromArgb(CByte(55), CByte(62), CByte(90))
        btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Microsoft YaHei UI", 9F)
        btnClear.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnClear.Location = New Point(210, 8)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(120, 30)
        btnClear.TabIndex = 0
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(719, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 585)
        splitter.TabIndex = 1
        splitter.TabStop = False
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(dgvLeaveCat)
        pnlLeft.Controls.Add(pnlLeftFoot)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(719, 585)
        pnlLeft.TabIndex = 2
        ' 
        ' dgvLeaveCat
        ' 
        dgvLeaveCat.AllowUserToAddRows = False
        dgvLeaveCat.AllowUserToDeleteRows = False
        dgvLeaveCat.AllowUserToResizeRows = False
        dgvLeaveCat.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvLeaveCat.BorderStyle = BorderStyle.None
        dgvLeaveCat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvLeaveCat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvLeaveCat.ColumnHeadersHeight = 40
        dgvLeaveCat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvLeaveCat.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colPaid, colDays, colStatus})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvLeaveCat.DefaultCellStyle = DataGridViewCellStyle2
        dgvLeaveCat.Dock = DockStyle.Fill
        dgvLeaveCat.EnableHeadersVisualStyles = False
        dgvLeaveCat.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvLeaveCat.Location = New Point(0, 0)
        dgvLeaveCat.MultiSelect = False
        dgvLeaveCat.Name = "dgvLeaveCat"
        dgvLeaveCat.ReadOnly = True
        dgvLeaveCat.RowHeadersVisible = False
        dgvLeaveCat.RowHeadersWidth = 51
        dgvLeaveCat.RowTemplate.Height = 46
        dgvLeaveCat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLeaveCat.Size = New Size(719, 549)
        dgvLeaveCat.TabIndex = 0
        ' 
        ' colCode
        ' 
        colCode.HeaderText = "Mã"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 110
        ' 
        ' colName
        ' 
        colName.HeaderText = "Tên loại"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 200
        ' 
        ' colPaid
        ' 
        colPaid.HeaderText = "Hưởng lương"
        colPaid.MinimumWidth = 6
        colPaid.Name = "colPaid"
        colPaid.ReadOnly = True
        colPaid.Width = 120
        ' 
        ' colDays
        ' 
        colDays.HeaderText = "Số ngày"
        colDays.MinimumWidth = 6
        colDays.Name = "colDays"
        colDays.ReadOnly = True
        colDays.Width = 90
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "Trạng thái"
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
        pnlLeftFoot.Location = New Point(0, 549)
        pnlLeftFoot.Name = "pnlLeftFoot"
        pnlLeftFoot.Size = New Size(719, 36)
        pnlLeftFoot.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(77, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "Hiển thị 0"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 72)
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
        btnAdd.Location = New Point(1000, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(180, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "+ Thêm loại nghỉ"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Location = New Point(264, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(150, 28)
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
        txtSearch.Size = New Size(240, 29)
        txtSearch.TabIndex = 0
        toolTip1.SetToolTip(txtSearch, "Tìm theo mã hoặc tên loại nghỉ")
        ' 
        ' pnlHdr
        ' 
        pnlHdr.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlHdr.Controls.Add(lblHdrBadge)
        pnlHdr.Controls.Add(lblHdrSub)
        pnlHdr.Controls.Add(lblHdrTitle)
        pnlHdr.Dock = DockStyle.Top
        pnlHdr.Location = New Point(0, 0)
        pnlHdr.Name = "pnlHdr"
        pnlHdr.Padding = New Padding(16, 12, 16, 12)
        pnlHdr.Size = New Size(1200, 72)
        pnlHdr.TabIndex = 0
        ' 
        ' lblHdrBadge
        ' 
        lblHdrBadge.AutoSize = True
        lblHdrBadge.BackColor = Color.FromArgb(CByte(20), CByte(245), CByte(158), CByte(11))
        lblHdrBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrBadge.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        lblHdrBadge.Location = New Point(332, 40)
        lblHdrBadge.Name = "lblHdrBadge"
        lblHdrBadge.Padding = New Padding(6, 2, 6, 2)
        lblHdrBadge.Size = New Size(95, 24)
        lblHdrBadge.TabIndex = 2
        lblHdrBadge.Text = "● Pending"
        ' 
        ' lblHdrSub
        ' 
        lblHdrSub.AutoSize = True
        lblHdrSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblHdrSub.Location = New Point(18, 42)
        lblHdrSub.Name = "lblHdrSub"
        lblHdrSub.Size = New Size(370, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Quản lý loại nghỉ: phép năm, thai sản, không lương"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(16, 10)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(179, 30)
        lblHdrTitle.TabIndex = 0
        lblHdrTitle.Text = "Loại nghỉ phép"
        ' 
        ' formLeaveCategory
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 709)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1024, 600)
        Name = "formLeaveCategory"
        Text = "Loại nghỉ phép"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlDetailScroll.ResumeLayout(False)
        pnlDetailSection.ResumeLayout(False)
        pnlDetailSection.PerformLayout()
        tlpDetail.ResumeLayout(False)
        tlpDetail.PerformLayout()
        pnlDetailFoot.ResumeLayout(False)
        pnlLeft.ResumeLayout(False)
        CType(dgvLeaveCat, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftFoot.ResumeLayout(False)
        pnlLeftFoot.PerformLayout()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlHdr.ResumeLayout(False)
        pnlHdr.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlHdr As System.Windows.Forms.Panel
    Friend WithEvents lblHdrTitle As System.Windows.Forms.Label
    Friend WithEvents lblHdrSub As System.Windows.Forms.Label
    Friend WithEvents lblHdrBadge As System.Windows.Forms.Label
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvLeaveCat As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLeftFoot As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents splitter As System.Windows.Forms.Splitter
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailSection As System.Windows.Forms.Panel
    Friend WithEvents lblSecInfo As System.Windows.Forms.Label
    Friend WithEvents tlpDetail As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblPaid As System.Windows.Forms.Label
    Friend WithEvents cboPaid As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDays As System.Windows.Forms.Label
    Friend WithEvents txtDays As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlDetailFoot As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
End Class
