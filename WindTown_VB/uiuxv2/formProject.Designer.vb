<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formProject
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
        tabMain = New TabControl()
        tabList = New TabPage()
        pnlList = New Panel()
        dgvProject = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colManager = New DataGridViewTextBoxColumn()
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
        lblName = New Label()
        txtName = New TextBox()
        lblClient = New Label()
        txtClient = New TextBox()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        lblStart = New Label()
        dtpStart = New DateTimePicker()
        lblEnd = New Label()
        dtpEnd = New DateTimePicker()
        lblManager = New Label()
        cboManager = New ComboBox()
        lblBudget = New Label()
        txtBudget = New TextBox()
        lblTeam = New Label()
        flpTeam = New FlowLayoutPanel()
        chipDev = New Label()
        chipQa = New Label()
        chipPm = New Label()
        chipBa = New Label()
        lblSecInfo = New Label()
        pnlDetailFoot = New Panel()
        btnSave = New Button()
        btnClear = New Button()
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
        tabMain.SuspendLayout()
        tabList.SuspendLayout()
        pnlList.SuspendLayout()
        CType(dgvProject, ComponentModel.ISupportInitialize).BeginInit()
        pnlListFoot.SuspendLayout()
        tabDetail.SuspendLayout()
        pnlDetailRoot.SuspendLayout()
        pnlDetailScroll.SuspendLayout()
        pnlDetailSection.SuspendLayout()
        tlpDetail.SuspendLayout()
        flpTeam.SuspendLayout()
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
        pnlList.Controls.Add(dgvProject)
        pnlList.Controls.Add(pnlListFoot)
        pnlList.Dock = DockStyle.Fill
        pnlList.Location = New Point(8, 8)
        pnlList.Name = "pnlList"
        pnlList.Size = New Size(1176, 536)
        pnlList.TabIndex = 0
        ' 
        ' dgvProject
        ' 
        dgvProject.AllowUserToAddRows = False
        dgvProject.AllowUserToDeleteRows = False
        dgvProject.AllowUserToResizeRows = False
        dgvProject.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvProject.BorderStyle = BorderStyle.None
        dgvProject.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvProject.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvProject.ColumnHeadersHeight = 40
        dgvProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvProject.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colManager, colStatus})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvProject.DefaultCellStyle = DataGridViewCellStyle2
        dgvProject.Dock = DockStyle.Fill
        dgvProject.EnableHeadersVisualStyles = False
        dgvProject.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvProject.Location = New Point(0, 0)
        dgvProject.MultiSelect = False
        dgvProject.Name = "dgvProject"
        dgvProject.ReadOnly = True
        dgvProject.RowHeadersVisible = False
        dgvProject.RowHeadersWidth = 51
        dgvProject.RowTemplate.Height = 46
        dgvProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProject.Size = New Size(1176, 500)
        dgvProject.TabIndex = 0
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
        colName.HeaderText = "TÊN DỰ ÁN"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 220
        ' 
        ' colManager
        ' 
        colManager.HeaderText = "QUẢN LÝ"
        colManager.MinimumWidth = 6
        colManager.Name = "colManager"
        colManager.ReadOnly = True
        colManager.Width = 180
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
        pnlDetailSection.Size = New Size(1144, 382)
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
        tlpDetail.Controls.Add(lblClient, 0, 2)
        tlpDetail.Controls.Add(txtClient, 0, 3)
        tlpDetail.Controls.Add(lblStatus, 1, 2)
        tlpDetail.Controls.Add(cboStatus, 1, 3)
        tlpDetail.Controls.Add(lblStart, 0, 4)
        tlpDetail.Controls.Add(dtpStart, 0, 5)
        tlpDetail.Controls.Add(lblEnd, 1, 4)
        tlpDetail.Controls.Add(dtpEnd, 1, 5)
        tlpDetail.Controls.Add(lblManager, 0, 6)
        tlpDetail.Controls.Add(cboManager, 0, 7)
        tlpDetail.Controls.Add(lblBudget, 1, 6)
        tlpDetail.Controls.Add(txtBudget, 1, 7)
        tlpDetail.Controls.Add(lblTeam, 0, 8)
        tlpDetail.Controls.Add(flpTeam, 0, 9)
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
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 44F))
        tlpDetail.Size = New Size(1112, 338)
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
        lblCode.Text = "Mã dự án *"
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
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblName.Location = New Point(564, 0)
        lblName.Margin = New Padding(8, 0, 0, 0)
        lblName.Name = "lblName"
        lblName.Size = New Size(96, 19)
        lblName.TabIndex = 1
        lblName.Text = "Tên dự án *"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.Dock = DockStyle.Fill
        txtName.Font = New Font("Microsoft YaHei UI", 10F)
        txtName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtName.Location = New Point(564, 22)
        txtName.Margin = New Padding(8, 0, 0, 4)
        txtName.Name = "txtName"
        txtName.Size = New Size(548, 29)
        txtName.TabIndex = 1
        ' 
        ' lblClient
        ' 
        lblClient.AutoSize = True
        lblClient.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblClient.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblClient.Location = New Point(3, 62)
        lblClient.Name = "lblClient"
        lblClient.Size = New Size(84, 19)
        lblClient.TabIndex = 2
        lblClient.Text = "Khách hàng"
        ' 
        ' txtClient
        ' 
        txtClient.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtClient.BorderStyle = BorderStyle.FixedSingle
        txtClient.Dock = DockStyle.Fill
        txtClient.Font = New Font("Microsoft YaHei UI", 10F)
        txtClient.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtClient.Location = New Point(0, 84)
        txtClient.Margin = New Padding(0, 0, 8, 4)
        txtClient.Name = "txtClient"
        txtClient.Size = New Size(548, 29)
        txtClient.TabIndex = 2
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblStatus.Location = New Point(564, 62)
        lblStatus.Margin = New Padding(8, 0, 0, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(98, 19)
        lblStatus.TabIndex = 3
        lblStatus.Text = "Trạng thái *"
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
        ' lblStart
        ' 
        lblStart.AutoSize = True
        lblStart.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblStart.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblStart.Location = New Point(3, 124)
        lblStart.Name = "lblStart"
        lblStart.Size = New Size(110, 19)
        lblStart.TabIndex = 4
        lblStart.Text = "Ngày bắt đầu *"
        ' 
        ' dtpStart
        ' 
        dtpStart.CustomFormat = "dd/MM/yyyy"
        dtpStart.Dock = DockStyle.Fill
        dtpStart.Font = New Font("Microsoft YaHei UI", 10F)
        dtpStart.Format = DateTimePickerFormat.Custom
        dtpStart.Location = New Point(0, 146)
        dtpStart.Margin = New Padding(0, 0, 8, 4)
        dtpStart.Name = "dtpStart"
        dtpStart.Size = New Size(548, 29)
        dtpStart.TabIndex = 4
        ' 
        ' lblEnd
        ' 
        lblEnd.AutoSize = True
        lblEnd.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblEnd.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblEnd.Location = New Point(564, 124)
        lblEnd.Margin = New Padding(8, 0, 0, 0)
        lblEnd.Name = "lblEnd"
        lblEnd.Size = New Size(107, 19)
        lblEnd.TabIndex = 5
        lblEnd.Text = "Ngày kết thúc *"
        ' 
        ' dtpEnd
        ' 
        dtpEnd.CustomFormat = "dd/MM/yyyy"
        dtpEnd.Dock = DockStyle.Fill
        dtpEnd.Font = New Font("Microsoft YaHei UI", 10F)
        dtpEnd.Format = DateTimePickerFormat.Custom
        dtpEnd.Location = New Point(564, 146)
        dtpEnd.Margin = New Padding(8, 0, 0, 4)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(548, 29)
        dtpEnd.TabIndex = 5
        ' 
        ' lblManager
        ' 
        lblManager.AutoSize = True
        lblManager.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblManager.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblManager.Location = New Point(3, 186)
        lblManager.Name = "lblManager"
        lblManager.Size = New Size(127, 19)
        lblManager.TabIndex = 6
        lblManager.Text = "Quản lý dự án *"
        ' 
        ' cboManager
        ' 
        cboManager.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboManager.Dock = DockStyle.Fill
        cboManager.DropDownStyle = ComboBoxStyle.DropDownList
        cboManager.FlatStyle = FlatStyle.Flat
        cboManager.Font = New Font("Microsoft YaHei UI", 10F)
        cboManager.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboManager.Location = New Point(0, 208)
        cboManager.Margin = New Padding(0, 0, 8, 4)
        cboManager.Name = "cboManager"
        cboManager.Size = New Size(548, 31)
        cboManager.TabIndex = 6
        ' 
        ' lblBudget
        ' 
        lblBudget.AutoSize = True
        lblBudget.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblBudget.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblBudget.Location = New Point(564, 186)
        lblBudget.Margin = New Padding(8, 0, 0, 0)
        lblBudget.Name = "lblBudget"
        lblBudget.Size = New Size(78, 19)
        lblBudget.TabIndex = 7
        lblBudget.Text = "Ngân sách"
        ' 
        ' txtBudget
        ' 
        txtBudget.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtBudget.BorderStyle = BorderStyle.FixedSingle
        txtBudget.Dock = DockStyle.Fill
        txtBudget.Font = New Font("Microsoft YaHei UI", 10F)
        txtBudget.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtBudget.Location = New Point(564, 208)
        txtBudget.Margin = New Padding(8, 0, 0, 4)
        txtBudget.Name = "txtBudget"
        txtBudget.Size = New Size(548, 29)
        txtBudget.TabIndex = 7
        ' 
        ' lblTeam
        ' 
        lblTeam.AutoSize = True
        tlpDetail.SetColumnSpan(lblTeam, 2)
        lblTeam.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblTeam.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblTeam.Location = New Point(3, 248)
        lblTeam.Name = "lblTeam"
        lblTeam.Size = New Size(124, 19)
        lblTeam.TabIndex = 8
        lblTeam.Text = "Nhân sự tham gia"
        ' 
        ' flpTeam
        ' 
        tlpDetail.SetColumnSpan(flpTeam, 2)
        flpTeam.Controls.Add(chipDev)
        flpTeam.Controls.Add(chipQa)
        flpTeam.Controls.Add(chipPm)
        flpTeam.Controls.Add(chipBa)
        flpTeam.Dock = DockStyle.Fill
        flpTeam.Location = New Point(3, 273)
        flpTeam.Name = "flpTeam"
        flpTeam.Size = New Size(1106, 38)
        flpTeam.TabIndex = 9
        ' 
        ' chipDev
        ' 
        chipDev.AutoSize = True
        chipDev.BackColor = Color.FromArgb(CByte(30), CByte(45), CByte(70))
        chipDev.Font = New Font("Microsoft YaHei UI", 9F)
        chipDev.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        chipDev.Location = New Point(3, 0)
        chipDev.Margin = New Padding(3, 3, 6, 3)
        chipDev.Name = "chipDev"
        chipDev.Padding = New Padding(8, 3, 8, 3)
        chipDev.Size = New Size(47, 26)
        chipDev.TabIndex = 0
        chipDev.Text = "Dev"
        ' 
        ' chipQa
        ' 
        chipQa.AutoSize = True
        chipQa.BackColor = Color.FromArgb(CByte(30), CByte(45), CByte(70))
        chipQa.Font = New Font("Microsoft YaHei UI", 9F)
        chipQa.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        chipQa.Location = New Point(59, 0)
        chipQa.Margin = New Padding(3, 3, 6, 3)
        chipQa.Name = "chipQa"
        chipQa.Padding = New Padding(8, 3, 8, 3)
        chipQa.Size = New Size(43, 26)
        chipQa.TabIndex = 1
        chipQa.Text = "QA"
        ' 
        ' chipPm
        ' 
        chipPm.AutoSize = True
        chipPm.BackColor = Color.FromArgb(CByte(30), CByte(45), CByte(70))
        chipPm.Font = New Font("Microsoft YaHei UI", 9F)
        chipPm.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        chipPm.Location = New Point(111, 0)
        chipPm.Margin = New Padding(3, 3, 6, 3)
        chipPm.Name = "chipPm"
        chipPm.Padding = New Padding(8, 3, 8, 3)
        chipPm.Size = New Size(47, 26)
        chipPm.TabIndex = 2
        chipPm.Text = "PM"
        ' 
        ' chipBa
        ' 
        chipBa.AutoSize = True
        chipBa.BackColor = Color.FromArgb(CByte(30), CByte(45), CByte(70))
        chipBa.Font = New Font("Microsoft YaHei UI", 9F)
        chipBa.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        chipBa.Location = New Point(167, 0)
        chipBa.Margin = New Padding(3, 3, 6, 3)
        chipBa.Name = "chipBa"
        chipBa.Padding = New Padding(8, 3, 8, 3)
        chipBa.Size = New Size(45, 26)
        chipBa.TabIndex = 3
        chipBa.Text = "BA"
        ' 
        ' lblSecInfo
        ' 
        lblSecInfo.AutoSize = True
        lblSecInfo.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSecInfo.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSecInfo.Location = New Point(16, 12)
        lblSecInfo.Name = "lblSecInfo"
        lblSecInfo.Size = New Size(146, 19)
        lblSecInfo.TabIndex = 1
        lblSecInfo.Text = "THÔNG TIN DỰ ÁN"
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
        btnSave.Text = "Lưu dự án"
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
        btnAdd.TabIndex = 2
        btnAdd.Text = "+ Tạo mới"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Location = New Point(244, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(160, 28)
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
        txtSearch.Size = New Size(220, 29)
        txtSearch.TabIndex = 0
        toolTip1.SetToolTip(txtSearch, "Tìm theo mã hoặc tên dự án")
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
        lblHdrBadge.Location = New Point(251, 42)
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
        lblHdrSub.Size = New Size(352, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Quản lý dự án và phân công nhân sự vào dự án"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(16, 10)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(69, 30)
        lblHdrTitle.TabIndex = 0
        lblHdrTitle.Text = "Dự án"
        ' 
        ' formProject
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 709)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1024, 600)
        Name = "formProject"
        Text = "Dự án"
        pnlRoot.ResumeLayout(False)
        tabMain.ResumeLayout(False)
        tabList.ResumeLayout(False)
        pnlList.ResumeLayout(False)
        CType(dgvProject, ComponentModel.ISupportInitialize).EndInit()
        pnlListFoot.ResumeLayout(False)
        pnlListFoot.PerformLayout()
        tabDetail.ResumeLayout(False)
        pnlDetailRoot.ResumeLayout(False)
        pnlDetailScroll.ResumeLayout(False)
        pnlDetailSection.ResumeLayout(False)
        pnlDetailSection.PerformLayout()
        tlpDetail.ResumeLayout(False)
        tlpDetail.PerformLayout()
        flpTeam.ResumeLayout(False)
        flpTeam.PerformLayout()
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
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabList As System.Windows.Forms.TabPage
    Friend WithEvents tabDetail As System.Windows.Forms.TabPage
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents dgvProject As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colManager As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents txtClient As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblManager As System.Windows.Forms.Label
    Friend WithEvents cboManager As System.Windows.Forms.ComboBox
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents txtBudget As System.Windows.Forms.TextBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents flpTeam As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chipDev As System.Windows.Forms.Label
    Friend WithEvents chipQa As System.Windows.Forms.Label
    Friend WithEvents chipPm As System.Windows.Forms.Label
    Friend WithEvents chipBa As System.Windows.Forms.Label
    Friend WithEvents pnlDetailFoot As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
End Class
