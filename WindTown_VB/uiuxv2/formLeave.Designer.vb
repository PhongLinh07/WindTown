
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLeave
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        tabMain = New TabControl()
        tabList = New TabPage()
        pnlList = New Panel()
        dgvLeave = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colEmp = New DataGridViewTextBoxColumn()
        colCat = New DataGridViewTextBoxColumn()
        colFrom = New DataGridViewTextBoxColumn()
        colTo = New DataGridViewTextBoxColumn()
        colDays = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlListFoot = New Panel()
        lblRowInfo = New Label()
        tabDetail = New TabPage()
        pnlDetailRoot = New Panel()
        pnlDetailScroll = New Panel()
        pnlDetailSection = New Panel()
        tlpDetail = New TableLayoutPanel()
        lblCode = New Label()
        txtCode = New TextBox()
        lblEmployee = New Label()
        cboEmployee = New ComboBox()
        lblCategory = New Label()
        cboCategory = New ComboBox()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        lblFrom = New Label()
        dtpFrom = New DateTimePicker()
        lblTo = New Label()
        dtpTo = New DateTimePicker()
        lblDays = New Label()
        txtDays = New TextBox()
        lblReason = New Label()
        txtReason = New TextBox()
        lblSecInfo = New Label()
        pnlDetailFoot = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        cboDeptFilter = New ComboBox()
        txtSearch = New TextBox()
        pnlHdr = New Panel()
        lblHdrBadge = New Label()
        lblHdrSub = New Label()
        lblHdrTitle = New Label()
        toolTip1 = New ToolTip(components)
        pnlRoot.SuspendLayout()
        tabMain.SuspendLayout()
        tabList.SuspendLayout()
        pnlList.SuspendLayout()
        CType(dgvLeave, ComponentModel.ISupportInitialize).BeginInit()
        pnlListFoot.SuspendLayout()
        tabDetail.SuspendLayout()
        pnlDetailRoot.SuspendLayout()
        pnlDetailScroll.SuspendLayout()
        pnlDetailSection.SuspendLayout()
        tlpDetail.SuspendLayout()
        pnlDetailFoot.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlHdr.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(tabMain)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Controls.Add(pnlHdr)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(1200, 709)
        pnlRoot.TabIndex = 0
        ' 
        ' tabMain
        ' 
        tabMain.Controls.Add(tabList)
        tabMain.Controls.Add(tabDetail)
        tabMain.Dock = DockStyle.Fill
        tabMain.Font = New Font("Microsoft YaHei UI", 9F)
        tabMain.Location = New Point(0, 124)
        tabMain.Name = "tabMain"
        tabMain.SelectedIndex = 0
        tabMain.Size = New Size(1200, 585)
        tabMain.TabIndex = 2
        ' 
        ' tabList
        ' 
        tabList.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tabList.Controls.Add(pnlList)
        tabList.Location = New Point(4, 29)
        tabList.Name = "tabList"
        tabList.Padding = New Padding(8)
        tabList.Size = New Size(1192, 552)
        tabList.TabIndex = 0
        tabList.Text = "Danh sách"
        ' 
        ' pnlList
        ' 
        pnlList.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlList.Controls.Add(dgvLeave)
        pnlList.Controls.Add(pnlListFoot)
        pnlList.Dock = DockStyle.Fill
        pnlList.Location = New Point(8, 8)
        pnlList.Name = "pnlList"
        pnlList.Size = New Size(1176, 536)
        pnlList.TabIndex = 0
        ' 
        ' dgvLeave
        ' 
        dgvLeave.AllowUserToAddRows = False
        dgvLeave.AllowUserToDeleteRows = False
        dgvLeave.AllowUserToResizeRows = False
        dgvLeave.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvLeave.BorderStyle = BorderStyle.None
        dgvLeave.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle3.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle3.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvLeave.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvLeave.ColumnHeadersHeight = 40
        dgvLeave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvLeave.Columns.AddRange(New DataGridViewColumn() {colCode, colEmp, colCat, colFrom, colTo, colDays, colStatus})
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle4.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle4.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        dgvLeave.DefaultCellStyle = DataGridViewCellStyle4
        dgvLeave.Dock = DockStyle.Fill
        dgvLeave.EnableHeadersVisualStyles = False
        dgvLeave.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvLeave.Location = New Point(0, 0)
        dgvLeave.MultiSelect = False
        dgvLeave.Name = "dgvLeave"
        dgvLeave.ReadOnly = True
        dgvLeave.RowHeadersVisible = False
        dgvLeave.RowHeadersWidth = 51
        dgvLeave.RowTemplate.Height = 46
        dgvLeave.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLeave.Size = New Size(1176, 500)
        dgvLeave.TabIndex = 0
        ' 
        ' colCode
        ' 
        colCode.HeaderText = "Mã"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 110
        ' 
        ' colEmp
        ' 
        colEmp.HeaderText = "NHÂN VIÊN"
        colEmp.MinimumWidth = 6
        colEmp.Name = "colEmp"
        colEmp.ReadOnly = True
        colEmp.Width = 170
        ' 
        ' colCat
        ' 
        colCat.HeaderText = "LOẠI NGHỈ"
        colCat.MinimumWidth = 6
        colCat.Name = "colCat"
        colCat.ReadOnly = True
        colCat.Width = 140
        ' 
        ' colFrom
        ' 
        colFrom.HeaderText = "TỪ"
        colFrom.MinimumWidth = 6
        colFrom.Name = "colFrom"
        colFrom.ReadOnly = True
        colFrom.Width = 90
        ' 
        ' colTo
        ' 
        colTo.HeaderText = "ĐẾN"
        colTo.MinimumWidth = 6
        colTo.Name = "colTo"
        colTo.ReadOnly = True
        colTo.Width = 90
        ' 
        ' colDays
        ' 
        colDays.HeaderText = "SỐ NGÀY"
        colDays.MinimumWidth = 6
        colDays.Name = "colDays"
        colDays.ReadOnly = True
        colDays.Width = 90
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 120
        ' 
        ' pnlListFoot
        ' 
        pnlListFoot.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlListFoot.Controls.Add(lblRowInfo)
        pnlListFoot.Dock = DockStyle.Bottom
        pnlListFoot.Location = New Point(0, 500)
        pnlListFoot.Name = "pnlListFoot"
        pnlListFoot.Size = New Size(1176, 36)
        pnlListFoot.TabIndex = 1
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
        ' tabDetail
        ' 
        tabDetail.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tabDetail.Controls.Add(pnlDetailRoot)
        tabDetail.Location = New Point(4, 29)
        tabDetail.Name = "tabDetail"
        tabDetail.Padding = New Padding(8)
        tabDetail.Size = New Size(1192, 552)
        tabDetail.TabIndex = 1
        tabDetail.Text = "Chi tiết"
        ' 
        ' pnlDetailRoot
        ' 
        pnlDetailRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlDetailRoot.Controls.Add(pnlDetailScroll)
        pnlDetailRoot.Controls.Add(pnlDetailFoot)
        pnlDetailRoot.Dock = DockStyle.Fill
        pnlDetailRoot.Location = New Point(8, 8)
        pnlDetailRoot.Name = "pnlDetailRoot"
        pnlDetailRoot.Size = New Size(1176, 536)
        pnlDetailRoot.TabIndex = 0
        ' 
        ' pnlDetailScroll
        ' 
        pnlDetailScroll.AutoScroll = True
        pnlDetailScroll.Controls.Add(pnlDetailSection)
        pnlDetailScroll.Dock = DockStyle.Fill
        pnlDetailScroll.Location = New Point(0, 0)
        pnlDetailScroll.Name = "pnlDetailScroll"
        pnlDetailScroll.Padding = New Padding(16, 14, 16, 14)
        pnlDetailScroll.Size = New Size(1176, 490)
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
        pnlDetailSection.Size = New Size(1144, 318)
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
        tlpDetail.Controls.Add(lblEmployee, 1, 0)
        tlpDetail.Controls.Add(cboEmployee, 1, 1)
        tlpDetail.Controls.Add(lblCategory, 0, 2)
        tlpDetail.Controls.Add(cboCategory, 0, 3)
        tlpDetail.Controls.Add(lblStatus, 1, 2)
        tlpDetail.Controls.Add(cboStatus, 1, 3)
        tlpDetail.Controls.Add(lblFrom, 0, 4)
        tlpDetail.Controls.Add(dtpFrom, 0, 5)
        tlpDetail.Controls.Add(lblTo, 1, 4)
        tlpDetail.Controls.Add(dtpTo, 1, 5)
        tlpDetail.Controls.Add(lblDays, 0, 6)
        tlpDetail.Controls.Add(txtDays, 0, 7)
        tlpDetail.Controls.Add(lblReason, 0, 8)
        tlpDetail.Controls.Add(txtReason, 0, 9)
        tlpDetail.Dock = DockStyle.Bottom
        tlpDetail.Location = New Point(16, 32)
        tlpDetail.Name = "tlpDetail"
        tlpDetail.RowCount = 10
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 70F))
        tlpDetail.Size = New Size(1112, 274)
        tlpDetail.TabIndex = 0
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblCode.Location = New Point(3, 0)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(82, 19)
        lblCode.TabIndex = 0
        lblCode.Text = "Mã đơn  *"
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
        txtCode.Size = New Size(548, 29)
        txtCode.TabIndex = 0
        ' 
        ' lblEmployee
        ' 
        lblEmployee.AutoSize = True
        lblEmployee.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblEmployee.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblEmployee.Location = New Point(564, 0)
        lblEmployee.Margin = New Padding(8, 0, 0, 0)
        lblEmployee.Name = "lblEmployee"
        lblEmployee.Size = New Size(102, 19)
        lblEmployee.TabIndex = 1
        lblEmployee.Text = "Nhân viên  *"
        ' 
        ' cboEmployee
        ' 
        cboEmployee.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboEmployee.Dock = DockStyle.Fill
        cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList
        cboEmployee.FlatStyle = FlatStyle.Flat
        cboEmployee.Font = New Font("Microsoft YaHei UI", 10F)
        cboEmployee.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboEmployee.Location = New Point(564, 22)
        cboEmployee.Margin = New Padding(8, 0, 0, 4)
        cboEmployee.Name = "cboEmployee"
        cboEmployee.Size = New Size(548, 31)
        cboEmployee.TabIndex = 1
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblCategory.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblCategory.Location = New Point(3, 62)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(93, 19)
        lblCategory.TabIndex = 2
        lblCategory.Text = "Loại nghỉ  *"
        ' 
        ' cboCategory
        ' 
        cboCategory.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboCategory.Dock = DockStyle.Fill
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.FlatStyle = FlatStyle.Flat
        cboCategory.Font = New Font("Microsoft YaHei UI", 10F)
        cboCategory.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboCategory.Location = New Point(0, 84)
        cboCategory.Margin = New Padding(0, 0, 8, 4)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(548, 31)
        cboCategory.TabIndex = 2
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblStatus.Location = New Point(564, 62)
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
        cboStatus.Location = New Point(564, 84)
        cboStatus.Margin = New Padding(8, 0, 0, 4)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(548, 31)
        cboStatus.TabIndex = 3
        ' 
        ' lblFrom
        ' 
        lblFrom.AutoSize = True
        lblFrom.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFrom.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFrom.Location = New Point(3, 124)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(84, 19)
        lblFrom.TabIndex = 4
        lblFrom.Text = "Từ ngày  *"
        ' 
        ' dtpFrom
        ' 
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpFrom.Dock = DockStyle.Fill
        dtpFrom.Font = New Font("Microsoft YaHei UI", 10F)
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.Location = New Point(0, 146)
        dtpFrom.Margin = New Padding(0, 0, 8, 4)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(548, 29)
        dtpFrom.TabIndex = 4
        ' 
        ' lblTo
        ' 
        lblTo.AutoSize = True
        lblTo.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblTo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblTo.Location = New Point(564, 124)
        lblTo.Margin = New Padding(8, 0, 0, 0)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(97, 19)
        lblTo.TabIndex = 5
        lblTo.Text = "Đến ngày  *"
        ' 
        ' dtpTo
        ' 
        dtpTo.CustomFormat = "dd/MM/yyyy"
        dtpTo.Dock = DockStyle.Fill
        dtpTo.Font = New Font("Microsoft YaHei UI", 10F)
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.Location = New Point(564, 146)
        dtpTo.Margin = New Padding(8, 0, 0, 4)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(548, 29)
        dtpTo.TabIndex = 5
        ' 
        ' lblDays
        ' 
        lblDays.AutoSize = True
        lblDays.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblDays.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDays.Location = New Point(3, 186)
        lblDays.Name = "lblDays"
        lblDays.Size = New Size(70, 19)
        lblDays.TabIndex = 6
        lblDays.Text = "Số ngày"
        ' 
        ' txtDays
        ' 
        txtDays.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDays.BorderStyle = BorderStyle.FixedSingle
        txtDays.Dock = DockStyle.Fill
        txtDays.Font = New Font("Microsoft YaHei UI", 10F)
        txtDays.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDays.Location = New Point(0, 208)
        txtDays.Margin = New Padding(0, 0, 8, 4)
        txtDays.Name = "txtDays"
        txtDays.Size = New Size(548, 29)
        txtDays.TabIndex = 6
        ' 
        ' lblReason
        ' 
        lblReason.AutoSize = True
        tlpDetail.SetColumnSpan(lblReason, 2)
        lblReason.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblReason.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblReason.Location = New Point(3, 248)
        lblReason.Name = "lblReason"
        lblReason.Size = New Size(50, 19)
        lblReason.TabIndex = 7
        lblReason.Text = "Lý do"
        ' 
        ' txtReason
        ' 
        txtReason.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtReason.BorderStyle = BorderStyle.FixedSingle
        tlpDetail.SetColumnSpan(txtReason, 2)
        txtReason.Dock = DockStyle.Fill
        txtReason.Font = New Font("Microsoft YaHei UI", 10F)
        txtReason.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtReason.Location = New Point(3, 273)
        txtReason.Multiline = True
        txtReason.Name = "txtReason"
        txtReason.ScrollBars = ScrollBars.Vertical
        txtReason.Size = New Size(1106, 64)
        txtReason.TabIndex = 7
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
        pnlDetailFoot.Location = New Point(0, 490)
        pnlDetailFoot.Name = "pnlDetailFoot"
        pnlDetailFoot.Size = New Size(1176, 46)
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
        btnSave.Location = New Point(1036, 8)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 30)
        btnSave.TabIndex = 1
        btnSave.Text = "Lưu đơn nghỉ"
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
        btnClear.Location = New Point(900, 8)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(120, 30)
        btnClear.TabIndex = 0
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(cboDeptFilter)
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
        btnAdd.Location = New Point(998, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(180, 30)
        btnAdd.TabIndex = 3
        btnAdd.Text = "+ Thêm đơn nghỉ"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Location = New Point(424, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(150, 28)
        cboStatusFilter.TabIndex = 2
        ' 
        ' cboDeptFilter
        ' 
        cboDeptFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDeptFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDeptFilter.FlatStyle = FlatStyle.Flat
        cboDeptFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboDeptFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDeptFilter.Location = New Point(244, 11)
        cboDeptFilter.Name = "cboDeptFilter"
        cboDeptFilter.Size = New Size(170, 28)
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
        txtSearch.Size = New Size(220, 29)
        txtSearch.TabIndex = 0
        toolTip1.SetToolTip(txtSearch, "Tìm theo mã hoặc nhân viên")
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
        lblHdrBadge.Location = New Point(319, 42)
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
        lblHdrSub.Size = New Size(296, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Tạo đơn nghỉ, duyệt, theo dõi trạng thái"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(16, 10)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(131, 30)
        lblHdrTitle.TabIndex = 0
        lblHdrTitle.Text = "Nghỉ phép"
        ' 
        ' formLeave
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 709)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1024, 600)
        Name = "formLeave"
        Text = "Nghỉ phép"
        pnlRoot.ResumeLayout(False)
        tabMain.ResumeLayout(False)
        tabList.ResumeLayout(False)
        pnlList.ResumeLayout(False)
        CType(dgvLeave, ComponentModel.ISupportInitialize).EndInit()
        pnlListFoot.ResumeLayout(False)
        pnlListFoot.PerformLayout()
        tabDetail.ResumeLayout(False)
        pnlDetailRoot.ResumeLayout(False)
        pnlDetailScroll.ResumeLayout(False)
        pnlDetailSection.ResumeLayout(False)
        pnlDetailSection.PerformLayout()
        tlpDetail.ResumeLayout(False)
        tlpDetail.PerformLayout()
        pnlDetailFoot.ResumeLayout(False)
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
    Friend WithEvents cboDeptFilter As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabList As System.Windows.Forms.TabPage
    Friend WithEvents tabDetail As System.Windows.Forms.TabPage
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents dgvLeave As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlListFoot As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents pnlDetailRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailSection As System.Windows.Forms.Panel
    Friend WithEvents lblSecInfo As System.Windows.Forms.Label
    Friend WithEvents tlpDetail As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents cboEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDays As System.Windows.Forms.Label
    Friend WithEvents txtDays As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents pnlDetailFoot As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
End Class
