<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formSystem
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
        pnlRoot = New Panel()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubTitle = New Label()
        tabMain = New TabControl()
        tabDb = New TabPage()
        tabDisplay = New TabPage()
        tabPermissions = New TabPage()
        pnlDb = New Panel()
        lblDbHeader = New Label()
        lblDbHost = New Label()
        txtDbHost = New TextBox()
        lblDbName = New Label()
        txtDbName = New TextBox()
        lblDbUser = New Label()
        txtDbUser = New TextBox()
        lblDbPass = New Label()
        txtDbPass = New TextBox()
        lblDbPort = New Label()
        txtDbPort = New TextBox()
        lblDbTimeout = New Label()
        txtDbTimeout = New TextBox()
        btnTestConn = New Button()
        btnSaveDb = New Button()
        pnlDisplay = New Panel()
        lblDisplayHeader = New Label()
        lblTheme = New Label()
        cboTheme = New ComboBox()
        lblAccent = New Label()
        cboAccent = New ComboBox()
        lblFontSize = New Label()
        cboFontSize = New ComboBox()
        chkCompact = New CheckBox()
        chkShowIcons = New CheckBox()
        btnSaveDisplay = New Button()
        pnlPermissions = New Panel()
        lblPermHeader = New Label()
        dgvRoles = New DataGridView()
        colRole = New DataGridViewTextBoxColumn()
        colDesc = New DataGridViewTextBoxColumn()
        colScope = New DataGridViewTextBoxColumn()
        btnAddRole = New Button()
        btnDeleteRole = New Button()
        pnlRoot.SuspendLayout()
        pnlHeader.SuspendLayout()
        tabMain.SuspendLayout()
        tabDb.SuspendLayout()
        tabDisplay.SuspendLayout()
        tabPermissions.SuspendLayout()
        pnlDb.SuspendLayout()
        pnlDisplay.SuspendLayout()
        pnlPermissions.SuspendLayout()
        CType(dgvRoles, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(tabMain)
        pnlRoot.Controls.Add(pnlHeader)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Padding = New Padding(16)
        pnlRoot.Size = New Size(1100, 680)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlHeader.Controls.Add(lblSubTitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(16, 16)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(16, 10, 16, 10)
        pnlHeader.Size = New Size(1068, 60)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblTitle.Location = New Point(16, 8)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(156, 22)
        lblTitle.TabIndex = 0
        lblTitle.Text = "System Settings"
        ' 
        ' lblSubTitle
        ' 
        lblSubTitle.AutoSize = True
        lblSubTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubTitle.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblSubTitle.Location = New Point(18, 32)
        lblSubTitle.Name = "lblSubTitle"
        lblSubTitle.Size = New Size(316, 16)
        lblSubTitle.TabIndex = 1
        lblSubTitle.Text = "DB config, hiển thị giao diện, phân quyền tài khoản"
        ' 
        ' tabMain
        ' 
        tabMain.Controls.Add(tabDb)
        tabMain.Controls.Add(tabDisplay)
        tabMain.Controls.Add(tabPermissions)
        tabMain.Dock = DockStyle.Fill
        tabMain.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabMain.Location = New Point(16, 76)
        tabMain.Name = "tabMain"
        tabMain.Padding = New Point(12, 8)
        tabMain.SelectedIndex = 0
        tabMain.Size = New Size(1068, 588)
        tabMain.TabIndex = 1
        ' 
        ' tabDb
        ' 
        tabDb.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tabDb.Controls.Add(pnlDb)
        tabDb.Location = New Point(4, 33)
        tabDb.Name = "tabDb"
        tabDb.Padding = New Padding(12)
        tabDb.Size = New Size(1060, 551)
        tabDb.TabIndex = 0
        tabDb.Text = "DB Config"
        ' 
        ' tabDisplay
        ' 
        tabDisplay.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tabDisplay.Controls.Add(pnlDisplay)
        tabDisplay.Location = New Point(4, 33)
        tabDisplay.Name = "tabDisplay"
        tabDisplay.Padding = New Padding(12)
        tabDisplay.Size = New Size(1060, 551)
        tabDisplay.TabIndex = 1
        tabDisplay.Text = "Hiển thị"
        ' 
        ' tabPermissions
        ' 
        tabPermissions.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tabPermissions.Controls.Add(pnlPermissions)
        tabPermissions.Location = New Point(4, 33)
        tabPermissions.Name = "tabPermissions"
        tabPermissions.Padding = New Padding(12)
        tabPermissions.Size = New Size(1060, 551)
        tabPermissions.TabIndex = 2
        tabPermissions.Text = "Phân quyền"
        ' 
        ' pnlDb
        ' 
        pnlDb.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlDb.Controls.Add(btnSaveDb)
        pnlDb.Controls.Add(btnTestConn)
        pnlDb.Controls.Add(txtDbTimeout)
        pnlDb.Controls.Add(lblDbTimeout)
        pnlDb.Controls.Add(txtDbPort)
        pnlDb.Controls.Add(lblDbPort)
        pnlDb.Controls.Add(txtDbPass)
        pnlDb.Controls.Add(lblDbPass)
        pnlDb.Controls.Add(txtDbUser)
        pnlDb.Controls.Add(lblDbUser)
        pnlDb.Controls.Add(txtDbName)
        pnlDb.Controls.Add(lblDbName)
        pnlDb.Controls.Add(txtDbHost)
        pnlDb.Controls.Add(lblDbHost)
        pnlDb.Controls.Add(lblDbHeader)
        pnlDb.Dock = DockStyle.Fill
        pnlDb.Location = New Point(12, 12)
        pnlDb.Name = "pnlDb"
        pnlDb.Padding = New Padding(16)
        pnlDb.Size = New Size(1036, 527)
        pnlDb.TabIndex = 0
        ' 
        ' lblDbHeader
        ' 
        lblDbHeader.AutoSize = True
        lblDbHeader.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDbHeader.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbHeader.Location = New Point(16, 14)
        lblDbHeader.Name = "lblDbHeader"
        lblDbHeader.Size = New Size(153, 19)
        lblDbHeader.TabIndex = 0
        lblDbHeader.Text = "Cấu hình kết nối DB"
        ' 
        ' lblDbHost
        ' 
        lblDbHost.AutoSize = True
        lblDbHost.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbHost.Location = New Point(20, 56)
        lblDbHost.Name = "lblDbHost"
        lblDbHost.Size = New Size(95, 17)
        lblDbHost.TabIndex = 1
        lblDbHost.Text = "Server / Host"
        ' 
        ' txtDbHost
        ' 
        txtDbHost.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbHost.BorderStyle = BorderStyle.FixedSingle
        txtDbHost.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbHost.Location = New Point(20, 76)
        txtDbHost.Name = "txtDbHost"
        txtDbHost.Size = New Size(320, 23)
        txtDbHost.TabIndex = 2
        ' 
        ' lblDbName
        ' 
        lblDbName.AutoSize = True
        lblDbName.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbName.Location = New Point(360, 56)
        lblDbName.Name = "lblDbName"
        lblDbName.Size = New Size(64, 17)
        lblDbName.TabIndex = 3
        lblDbName.Text = "Database"
        ' 
        ' txtDbName
        ' 
        txtDbName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbName.BorderStyle = BorderStyle.FixedSingle
        txtDbName.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbName.Location = New Point(360, 76)
        txtDbName.Name = "txtDbName"
        txtDbName.Size = New Size(320, 23)
        txtDbName.TabIndex = 4
        ' 
        ' lblDbUser
        ' 
        lblDbUser.AutoSize = True
        lblDbUser.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbUser.Location = New Point(20, 120)
        lblDbUser.Name = "lblDbUser"
        lblDbUser.Size = New Size(72, 17)
        lblDbUser.TabIndex = 5
        lblDbUser.Text = "User name"
        ' 
        ' txtDbUser
        ' 
        txtDbUser.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbUser.BorderStyle = BorderStyle.FixedSingle
        txtDbUser.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbUser.Location = New Point(20, 140)
        txtDbUser.Name = "txtDbUser"
        txtDbUser.Size = New Size(320, 23)
        txtDbUser.TabIndex = 6
        ' 
        ' lblDbPass
        ' 
        lblDbPass.AutoSize = True
        lblDbPass.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbPass.Location = New Point(360, 120)
        lblDbPass.Name = "lblDbPass"
        lblDbPass.Size = New Size(60, 17)
        lblDbPass.TabIndex = 7
        lblDbPass.Text = "Password"
        ' 
        ' txtDbPass
        ' 
        txtDbPass.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbPass.BorderStyle = BorderStyle.FixedSingle
        txtDbPass.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbPass.Location = New Point(360, 140)
        txtDbPass.Name = "txtDbPass"
        txtDbPass.PasswordChar = ChrW(9679)
        txtDbPass.Size = New Size(320, 23)
        txtDbPass.TabIndex = 8
        ' 
        ' lblDbPort
        ' 
        lblDbPort.AutoSize = True
        lblDbPort.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbPort.Location = New Point(20, 184)
        lblDbPort.Name = "lblDbPort"
        lblDbPort.Size = New Size(30, 17)
        lblDbPort.TabIndex = 9
        lblDbPort.Text = "Port"
        ' 
        ' txtDbPort
        ' 
        txtDbPort.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbPort.BorderStyle = BorderStyle.FixedSingle
        txtDbPort.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbPort.Location = New Point(20, 204)
        txtDbPort.Name = "txtDbPort"
        txtDbPort.Size = New Size(140, 23)
        txtDbPort.TabIndex = 10
        ' 
        ' lblDbTimeout
        ' 
        lblDbTimeout.AutoSize = True
        lblDbTimeout.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDbTimeout.Location = New Point(180, 184)
        lblDbTimeout.Name = "lblDbTimeout"
        lblDbTimeout.Size = New Size(56, 17)
        lblDbTimeout.TabIndex = 11
        lblDbTimeout.Text = "Timeout"
        ' 
        ' txtDbTimeout
        ' 
        txtDbTimeout.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDbTimeout.BorderStyle = BorderStyle.FixedSingle
        txtDbTimeout.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtDbTimeout.Location = New Point(180, 204)
        txtDbTimeout.Name = "txtDbTimeout"
        txtDbTimeout.Size = New Size(160, 23)
        txtDbTimeout.TabIndex = 12
        ' 
        ' btnTestConn
        ' 
        btnTestConn.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnTestConn.FlatStyle = FlatStyle.Flat
        btnTestConn.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnTestConn.Location = New Point(20, 260)
        btnTestConn.Name = "btnTestConn"
        btnTestConn.Size = New Size(140, 30)
        btnTestConn.TabIndex = 13
        btnTestConn.Text = "Test connection"
        btnTestConn.UseVisualStyleBackColor = False
        ' 
        ' btnSaveDb
        ' 
        btnSaveDb.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSaveDb.FlatStyle = FlatStyle.Flat
        btnSaveDb.ForeColor = Color.White
        btnSaveDb.Location = New Point(180, 260)
        btnSaveDb.Name = "btnSaveDb"
        btnSaveDb.Size = New Size(120, 30)
        btnSaveDb.TabIndex = 14
        btnSaveDb.Text = "Save"
        btnSaveDb.UseVisualStyleBackColor = False
        ' 
        ' pnlDisplay
        ' 
        pnlDisplay.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlDisplay.Controls.Add(btnSaveDisplay)
        pnlDisplay.Controls.Add(chkShowIcons)
        pnlDisplay.Controls.Add(chkCompact)
        pnlDisplay.Controls.Add(cboFontSize)
        pnlDisplay.Controls.Add(lblFontSize)
        pnlDisplay.Controls.Add(cboAccent)
        pnlDisplay.Controls.Add(lblAccent)
        pnlDisplay.Controls.Add(cboTheme)
        pnlDisplay.Controls.Add(lblTheme)
        pnlDisplay.Controls.Add(lblDisplayHeader)
        pnlDisplay.Dock = DockStyle.Fill
        pnlDisplay.Location = New Point(12, 12)
        pnlDisplay.Name = "pnlDisplay"
        pnlDisplay.Padding = New Padding(16)
        pnlDisplay.Size = New Size(1036, 527)
        pnlDisplay.TabIndex = 0
        ' 
        ' lblDisplayHeader
        ' 
        lblDisplayHeader.AutoSize = True
        lblDisplayHeader.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDisplayHeader.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblDisplayHeader.Location = New Point(16, 14)
        lblDisplayHeader.Name = "lblDisplayHeader"
        lblDisplayHeader.Size = New Size(99, 19)
        lblDisplayHeader.TabIndex = 0
        lblDisplayHeader.Text = "Hiển thị UI"
        ' 
        ' lblTheme
        ' 
        lblTheme.AutoSize = True
        lblTheme.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblTheme.Location = New Point(20, 56)
        lblTheme.Name = "lblTheme"
        lblTheme.Size = New Size(50, 17)
        lblTheme.TabIndex = 1
        lblTheme.Text = "Theme"
        ' 
        ' cboTheme
        ' 
        cboTheme.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboTheme.DropDownStyle = ComboBoxStyle.DropDownList
        cboTheme.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboTheme.FormattingEnabled = True
        cboTheme.Items.AddRange(New Object() {"Dark", "Light"})
        cboTheme.Location = New Point(20, 76)
        cboTheme.Name = "cboTheme"
        cboTheme.Size = New Size(220, 25)
        cboTheme.TabIndex = 2
        ' 
        ' lblAccent
        ' 
        lblAccent.AutoSize = True
        lblAccent.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblAccent.Location = New Point(260, 56)
        lblAccent.Name = "lblAccent"
        lblAccent.Size = New Size(88, 17)
        lblAccent.TabIndex = 3
        lblAccent.Text = "Accent color"
        ' 
        ' cboAccent
        ' 
        cboAccent.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboAccent.DropDownStyle = ComboBoxStyle.DropDownList
        cboAccent.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboAccent.FormattingEnabled = True
        cboAccent.Items.AddRange(New Object() {"Blue", "Green", "Orange", "Red"})
        cboAccent.Location = New Point(260, 76)
        cboAccent.Name = "cboAccent"
        cboAccent.Size = New Size(220, 25)
        cboAccent.TabIndex = 4
        ' 
        ' lblFontSize
        ' 
        lblFontSize.AutoSize = True
        lblFontSize.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblFontSize.Location = New Point(500, 56)
        lblFontSize.Name = "lblFontSize"
        lblFontSize.Size = New Size(57, 17)
        lblFontSize.TabIndex = 5
        lblFontSize.Text = "Font size"
        ' 
        ' cboFontSize
        ' 
        cboFontSize.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFontSize.DropDownStyle = ComboBoxStyle.DropDownList
        cboFontSize.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboFontSize.FormattingEnabled = True
        cboFontSize.Items.AddRange(New Object() {"12", "13", "14", "15"})
        cboFontSize.Location = New Point(500, 76)
        cboFontSize.Name = "cboFontSize"
        cboFontSize.Size = New Size(140, 25)
        cboFontSize.TabIndex = 6
        ' 
        ' chkCompact
        ' 
        chkCompact.AutoSize = True
        chkCompact.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        chkCompact.Location = New Point(20, 120)
        chkCompact.Name = "chkCompact"
        chkCompact.Size = New Size(102, 21)
        chkCompact.TabIndex = 7
        chkCompact.Text = "Compact mode"
        chkCompact.UseVisualStyleBackColor = True
        ' 
        ' chkShowIcons
        ' 
        chkShowIcons.AutoSize = True
        chkShowIcons.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        chkShowIcons.Location = New Point(160, 120)
        chkShowIcons.Name = "chkShowIcons"
        chkShowIcons.Size = New Size(124, 21)
        chkShowIcons.TabIndex = 8
        chkShowIcons.Text = "Show menu icons"
        chkShowIcons.UseVisualStyleBackColor = True
        ' 
        ' btnSaveDisplay
        ' 
        btnSaveDisplay.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSaveDisplay.FlatStyle = FlatStyle.Flat
        btnSaveDisplay.ForeColor = Color.White
        btnSaveDisplay.Location = New Point(20, 160)
        btnSaveDisplay.Name = "btnSaveDisplay"
        btnSaveDisplay.Size = New Size(120, 30)
        btnSaveDisplay.TabIndex = 9
        btnSaveDisplay.Text = "Save"
        btnSaveDisplay.UseVisualStyleBackColor = False
        ' 
        ' pnlPermissions
        ' 
        pnlPermissions.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlPermissions.Controls.Add(btnDeleteRole)
        pnlPermissions.Controls.Add(btnAddRole)
        pnlPermissions.Controls.Add(dgvRoles)
        pnlPermissions.Controls.Add(lblPermHeader)
        pnlPermissions.Dock = DockStyle.Fill
        pnlPermissions.Location = New Point(12, 12)
        pnlPermissions.Name = "pnlPermissions"
        pnlPermissions.Padding = New Padding(16)
        pnlPermissions.Size = New Size(1036, 527)
        pnlPermissions.TabIndex = 0
        ' 
        ' lblPermHeader
        ' 
        lblPermHeader.AutoSize = True
        lblPermHeader.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPermHeader.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblPermHeader.Location = New Point(16, 14)
        lblPermHeader.Name = "lblPermHeader"
        lblPermHeader.Size = New Size(161, 19)
        lblPermHeader.TabIndex = 0
        lblPermHeader.Text = "Phân quyền tài khoản"
        ' 
        ' dgvRoles
        ' 
        dgvRoles.AllowUserToAddRows = False
        dgvRoles.AllowUserToDeleteRows = False
        dgvRoles.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvRoles.BorderStyle = BorderStyle.None
        dgvRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        DataGridViewCellStyle1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvRoles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvRoles.ColumnHeadersHeight = 32
        dgvRoles.Columns.AddRange(New DataGridViewColumn() {colRole, colDesc, colScope})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvRoles.DefaultCellStyle = DataGridViewCellStyle2
        dgvRoles.GridColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dgvRoles.Location = New Point(20, 52)
        dgvRoles.Name = "dgvRoles"
        dgvRoles.ReadOnly = True
        dgvRoles.RowHeadersVisible = False
        dgvRoles.RowTemplate.Height = 28
        dgvRoles.Size = New Size(980, 390)
        dgvRoles.TabIndex = 1
        ' 
        ' colRole
        ' 
        colRole.HeaderText = "Role"
        colRole.Name = "colRole"
        colRole.ReadOnly = True
        colRole.Width = 220
        ' 
        ' colDesc
        ' 
        colDesc.HeaderText = "Mô tả"
        colDesc.Name = "colDesc"
        colDesc.ReadOnly = True
        colDesc.Width = 360
        ' 
        ' colScope
        ' 
        colScope.HeaderText = "Quyền"
        colScope.Name = "colScope"
        colScope.ReadOnly = True
        colScope.Width = 360
        ' 
        ' btnAddRole
        ' 
        btnAddRole.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnAddRole.FlatStyle = FlatStyle.Flat
        btnAddRole.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnAddRole.Location = New Point(20, 460)
        btnAddRole.Name = "btnAddRole"
        btnAddRole.Size = New Size(120, 30)
        btnAddRole.TabIndex = 2
        btnAddRole.Text = "Thêm role"
        btnAddRole.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteRole
        ' 
        btnDeleteRole.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnDeleteRole.FlatStyle = FlatStyle.Flat
        btnDeleteRole.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnDeleteRole.Location = New Point(150, 460)
        btnDeleteRole.Name = "btnDeleteRole"
        btnDeleteRole.Size = New Size(120, 30)
        btnDeleteRole.TabIndex = 3
        btnDeleteRole.Text = "Xóa role"
        btnDeleteRole.UseVisualStyleBackColor = False
        ' 
        ' formSystem
        ' 
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1100, 680)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        Name = "formSystem"
        Text = "System"
        pnlRoot.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        tabMain.ResumeLayout(False)
        tabDb.ResumeLayout(False)
        tabDisplay.ResumeLayout(False)
        tabPermissions.ResumeLayout(False)
        pnlDb.ResumeLayout(False)
        pnlDb.PerformLayout()
        pnlDisplay.ResumeLayout(False)
        pnlDisplay.PerformLayout()
        pnlPermissions.ResumeLayout(False)
        pnlPermissions.PerformLayout()
        CType(dgvRoles, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlRoot As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubTitle As Label
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabDb As TabPage
    Friend WithEvents tabDisplay As TabPage
    Friend WithEvents tabPermissions As TabPage
    Friend WithEvents pnlDb As Panel
    Friend WithEvents lblDbHeader As Label
    Friend WithEvents lblDbHost As Label
    Friend WithEvents txtDbHost As TextBox
    Friend WithEvents lblDbName As Label
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents lblDbUser As Label
    Friend WithEvents txtDbUser As TextBox
    Friend WithEvents lblDbPass As Label
    Friend WithEvents txtDbPass As TextBox
    Friend WithEvents lblDbPort As Label
    Friend WithEvents txtDbPort As TextBox
    Friend WithEvents lblDbTimeout As Label
    Friend WithEvents txtDbTimeout As TextBox
    Friend WithEvents btnTestConn As Button
    Friend WithEvents btnSaveDb As Button
    Friend WithEvents pnlDisplay As Panel
    Friend WithEvents lblDisplayHeader As Label
    Friend WithEvents lblTheme As Label
    Friend WithEvents cboTheme As ComboBox
    Friend WithEvents lblAccent As Label
    Friend WithEvents cboAccent As ComboBox
    Friend WithEvents lblFontSize As Label
    Friend WithEvents cboFontSize As ComboBox
    Friend WithEvents chkCompact As CheckBox
    Friend WithEvents chkShowIcons As CheckBox
    Friend WithEvents btnSaveDisplay As Button
    Friend WithEvents pnlPermissions As Panel
    Friend WithEvents lblPermHeader As Label
    Friend WithEvents dgvRoles As DataGridView
    Friend WithEvents colRole As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colScope As DataGridViewTextBoxColumn
    Friend WithEvents btnAddRole As Button
    Friend WithEvents btnDeleteRole As Button

End Class
