<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DfrmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.tmrSb = New System.Windows.Forms.Timer(Me.components)
        Me.tipNav = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDash = New System.Windows.Forms.Button()
        Me.btnEmployee = New System.Windows.Forms.Button()
        Me.btnAttend = New System.Windows.Forms.Button()
        Me.btnPayroll = New System.Windows.Forms.Button()
        Me.btnProject = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnPayPeriod = New System.Windows.Forms.Button()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.pnlSbNav = New System.Windows.Forms.Panel()
        Me.lblSec2 = New System.Windows.Forms.Label()
        Me.lblSec1 = New System.Windows.Forms.Label()
        Me.pnlSbFooter = New System.Windows.Forms.Panel()
        Me.lblSbRole = New System.Windows.Forms.Label()
        Me.lblSbUser = New System.Windows.Forms.Label()
        Me.pnlSbTop = New System.Windows.Forms.Panel()
        Me.btnToggle = New System.Windows.Forms.Button()
        Me.lblBrandSub = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlTopbar = New System.Windows.Forms.Panel()
        Me.pnlTopRight = New System.Windows.Forms.Panel()
        Me.picAvatar = New System.Windows.Forms.PictureBox()
        Me.lblPageDate = New System.Windows.Forms.Label()
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.lblTopAvatar = New System.Windows.Forms.Label()
        Me.btnContract = New System.Windows.Forms.Button()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlSbNav.SuspendLayout()
        Me.pnlSbFooter.SuspendLayout()
        Me.pnlSbTop.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlTopbar.SuspendLayout()
        Me.pnlTopRight.SuspendLayout()
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrSb
        '
        Me.tmrSb.Interval = 12
        '
        'tipNav
        '
        Me.tipNav.AutoPopDelay = 3000
        Me.tipNav.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tipNav.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.tipNav.InitialDelay = 300
        Me.tipNav.ReshowDelay = 100
        '
        'btnDash
        '
        Me.btnDash.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnDash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDash.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDash.FlatAppearance.BorderSize = 0
        Me.btnDash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnDash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDash.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnDash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnDash.Location = New System.Drawing.Point(0, 22)
        Me.btnDash.Name = "btnDash"
        Me.btnDash.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnDash.Size = New System.Drawing.Size(200, 42)
        Me.btnDash.TabIndex = 7
        Me.btnDash.Tag = "  Dashboard"
        Me.btnDash.Text = "  Dashboard"
        Me.btnDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnDash, "Dashboard")
        Me.btnDash.UseVisualStyleBackColor = False
        '
        'btnEmployee
        '
        Me.btnEmployee.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmployee.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEmployee.FlatAppearance.BorderSize = 0
        Me.btnEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmployee.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnEmployee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnEmployee.Location = New System.Drawing.Point(0, 64)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnEmployee.Size = New System.Drawing.Size(200, 42)
        Me.btnEmployee.TabIndex = 6
        Me.btnEmployee.Tag = "  Nhân viên"
        Me.btnEmployee.Text = "  Nhân viên"
        Me.btnEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnEmployee, "Nhân viên")
        Me.btnEmployee.UseVisualStyleBackColor = False
        '
        'btnAttend
        '
        Me.btnAttend.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnAttend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAttend.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAttend.FlatAppearance.BorderSize = 0
        Me.btnAttend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnAttend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAttend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttend.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnAttend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnAttend.Location = New System.Drawing.Point(0, 148)
        Me.btnAttend.Name = "btnAttend"
        Me.btnAttend.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnAttend.Size = New System.Drawing.Size(200, 42)
        Me.btnAttend.TabIndex = 5
        Me.btnAttend.Tag = "  Chấm công"
        Me.btnAttend.Text = "  Chấm công"
        Me.btnAttend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnAttend, "Chấm công")
        Me.btnAttend.UseVisualStyleBackColor = False
        '
        'btnPayroll
        '
        Me.btnPayroll.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnPayroll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayroll.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPayroll.FlatAppearance.BorderSize = 0
        Me.btnPayroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnPayroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayroll.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnPayroll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnPayroll.Location = New System.Drawing.Point(0, 190)
        Me.btnPayroll.Name = "btnPayroll"
        Me.btnPayroll.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnPayroll.Size = New System.Drawing.Size(200, 42)
        Me.btnPayroll.TabIndex = 4
        Me.btnPayroll.Tag = "  Lương thưởng"
        Me.btnPayroll.Text = "  Lương thưởng"
        Me.btnPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnPayroll, "Lương thưởng")
        Me.btnPayroll.UseVisualStyleBackColor = False
        '
        'btnProject
        '
        Me.btnProject.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnProject.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProject.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProject.FlatAppearance.BorderSize = 0
        Me.btnProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProject.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnProject.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnProject.Location = New System.Drawing.Point(0, 254)
        Me.btnProject.Name = "btnProject"
        Me.btnProject.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnProject.Size = New System.Drawing.Size(200, 42)
        Me.btnProject.TabIndex = 2
        Me.btnProject.Tag = "  Chính sách"
        Me.btnProject.Text = "  Chính sách"
        Me.btnProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnProject, "Chính sách")
        Me.btnProject.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReport.FlatAppearance.BorderSize = 0
        Me.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnReport.Location = New System.Drawing.Point(0, 296)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnReport.Size = New System.Drawing.Size(200, 42)
        Me.btnReport.TabIndex = 1
        Me.btnReport.Tag = "  Báo cáo"
        Me.btnReport.Text = "  Báo cáo"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnReport, "Báo cáo")
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnSettings.Location = New System.Drawing.Point(0, 338)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnSettings.Size = New System.Drawing.Size(200, 42)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.Tag = "  Cài đặt"
        Me.btnSettings.Text = "  Cài đặt"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnSettings, "Cài đặt")
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnPayPeriod
        '
        Me.btnPayPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnPayPeriod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayPeriod.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPayPeriod.FlatAppearance.BorderSize = 0
        Me.btnPayPeriod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnPayPeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnPayPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayPeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnPayPeriod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnPayPeriod.Location = New System.Drawing.Point(0, 380)
        Me.btnPayPeriod.Name = "btnPayPeriod"
        Me.btnPayPeriod.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnPayPeriod.Size = New System.Drawing.Size(200, 42)
        Me.btnPayPeriod.TabIndex = 9
        Me.btnPayPeriod.Tag = "Kỳ lương"
        Me.btnPayPeriod.Text = "  Kỳ lương"
        Me.btnPayPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnPayPeriod, "Kỳ lương")
        Me.btnPayPeriod.UseVisualStyleBackColor = False
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.pnlSbNav)
        Me.pnlSidebar.Controls.Add(Me.pnlSbFooter)
        Me.pnlSidebar.Controls.Add(Me.pnlSbTop)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 720)
        Me.pnlSidebar.TabIndex = 1
        '
        'pnlSbNav
        '
        Me.pnlSbNav.BackColor = System.Drawing.Color.Transparent
        Me.pnlSbNav.Controls.Add(Me.btnPayPeriod)
        Me.pnlSbNav.Controls.Add(Me.btnSettings)
        Me.pnlSbNav.Controls.Add(Me.btnReport)
        Me.pnlSbNav.Controls.Add(Me.btnProject)
        Me.pnlSbNav.Controls.Add(Me.lblSec2)
        Me.pnlSbNav.Controls.Add(Me.btnPayroll)
        Me.pnlSbNav.Controls.Add(Me.btnAttend)
        Me.pnlSbNav.Controls.Add(Me.btnContract)
        Me.pnlSbNav.Controls.Add(Me.btnEmployee)
        Me.pnlSbNav.Controls.Add(Me.btnDash)
        Me.pnlSbNav.Controls.Add(Me.lblSec1)
        Me.pnlSbNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSbNav.Location = New System.Drawing.Point(0, 60)
        Me.pnlSbNav.Name = "pnlSbNav"
        Me.pnlSbNav.Size = New System.Drawing.Size(200, 606)
        Me.pnlSbNav.TabIndex = 0
        '
        'lblSec2
        '
        Me.lblSec2.BackColor = System.Drawing.Color.Transparent
        Me.lblSec2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSec2.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblSec2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.lblSec2.Location = New System.Drawing.Point(0, 232)
        Me.lblSec2.Name = "lblSec2"
        Me.lblSec2.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblSec2.Size = New System.Drawing.Size(200, 22)
        Me.lblSec2.TabIndex = 3
        Me.lblSec2.Text = "QUẢN LÝ"
        '
        'lblSec1
        '
        Me.lblSec1.BackColor = System.Drawing.Color.Transparent
        Me.lblSec1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSec1.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblSec1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.lblSec1.Location = New System.Drawing.Point(0, 0)
        Me.lblSec1.Name = "lblSec1"
        Me.lblSec1.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblSec1.Size = New System.Drawing.Size(200, 22)
        Me.lblSec1.TabIndex = 8
        Me.lblSec1.Text = "CHÍNH"
        '
        'pnlSbFooter
        '
        Me.pnlSbFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.pnlSbFooter.Controls.Add(Me.lblSbRole)
        Me.pnlSbFooter.Controls.Add(Me.lblSbUser)
        Me.pnlSbFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSbFooter.Location = New System.Drawing.Point(0, 666)
        Me.pnlSbFooter.Name = "pnlSbFooter"
        Me.pnlSbFooter.Size = New System.Drawing.Size(200, 54)
        Me.pnlSbFooter.TabIndex = 1
        '
        'lblSbRole
        '
        Me.lblSbRole.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblSbRole.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.lblSbRole.Location = New System.Drawing.Point(46, 28)
        Me.lblSbRole.Name = "lblSbRole"
        Me.lblSbRole.Size = New System.Drawing.Size(148, 18)
        Me.lblSbRole.TabIndex = 0
        Me.lblSbRole.Text = "Quản trị viên"
        '
        'lblSbUser
        '
        Me.lblSbUser.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSbUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblSbUser.Location = New System.Drawing.Point(46, 8)
        Me.lblSbUser.Name = "lblSbUser"
        Me.lblSbUser.Size = New System.Drawing.Size(148, 20)
        Me.lblSbUser.TabIndex = 1
        Me.lblSbUser.Text = "Admin"
        '
        'pnlSbTop
        '
        Me.pnlSbTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.pnlSbTop.Controls.Add(Me.btnToggle)
        Me.pnlSbTop.Controls.Add(Me.lblBrandSub)
        Me.pnlSbTop.Controls.Add(Me.lblBrand)
        Me.pnlSbTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSbTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSbTop.Name = "pnlSbTop"
        Me.pnlSbTop.Size = New System.Drawing.Size(200, 60)
        Me.pnlSbTop.TabIndex = 2
        '
        'btnToggle
        '
        Me.btnToggle.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggle.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.btnToggle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnToggle.Location = New System.Drawing.Point(166, 18)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(24, 24)
        Me.btnToggle.TabIndex = 0
        Me.btnToggle.Text = "<"
        Me.btnToggle.UseVisualStyleBackColor = False
        '
        'lblBrandSub
        '
        Me.lblBrandSub.AutoSize = True
        Me.lblBrandSub.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.lblBrandSub.Location = New System.Drawing.Point(12, 30)
        Me.lblBrandSub.Name = "lblBrandSub"
        Me.lblBrandSub.Size = New System.Drawing.Size(86, 20)
        Me.lblBrandSub.TabIndex = 1
        Me.lblBrandSub.Text = "Wind Town"
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrand.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblBrand.Location = New System.Drawing.Point(12, 8)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(136, 26)
        Me.lblBrand.TabIndex = 2
        Me.lblBrand.Text = "HRM System"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlTopbar)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(200, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1080, 720)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 56)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(1080, 664)
        Me.pnlContent.TabIndex = 0
        '
        'pnlTopbar
        '
        Me.pnlTopbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.pnlTopbar.Controls.Add(Me.pnlTopRight)
        Me.pnlTopbar.Controls.Add(Me.lblPageDate)
        Me.pnlTopbar.Controls.Add(Me.lblPageTitle)
        Me.pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopbar.Name = "pnlTopbar"
        Me.pnlTopbar.Size = New System.Drawing.Size(1080, 56)
        Me.pnlTopbar.TabIndex = 1
        '
        'pnlTopRight
        '
        Me.pnlTopRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTopRight.BackColor = System.Drawing.Color.Transparent
        Me.pnlTopRight.Controls.Add(Me.picAvatar)
        Me.pnlTopRight.Location = New System.Drawing.Point(1780, 8)
        Me.pnlTopRight.Name = "pnlTopRight"
        Me.pnlTopRight.Size = New System.Drawing.Size(40, 40)
        Me.pnlTopRight.TabIndex = 0
        '
        'picAvatar
        '
        Me.picAvatar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picAvatar.Image = Global.WindTown_VB.My.Resources.Resources.AvatarUser
        Me.picAvatar.Location = New System.Drawing.Point(0, 0)
        Me.picAvatar.Name = "picAvatar"
        Me.picAvatar.Size = New System.Drawing.Size(40, 40)
        Me.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAvatar.TabIndex = 0
        Me.picAvatar.TabStop = False
        '
        'lblPageDate
        '
        Me.lblPageDate.AutoSize = True
        Me.lblPageDate.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.lblPageDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.lblPageDate.Location = New System.Drawing.Point(18, 32)
        Me.lblPageDate.Name = "lblPageDate"
        Me.lblPageDate.Size = New System.Drawing.Size(0, 20)
        Me.lblPageDate.TabIndex = 1
        '
        'lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblPageTitle.Location = New System.Drawing.Point(18, 8)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblPageTitle.TabIndex = 2
        Me.lblPageTitle.Text = "Dashboard"
        '
        'lblTopAvatar
        '
        Me.lblTopAvatar.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblTopAvatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTopAvatar.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTopAvatar.ForeColor = System.Drawing.Color.White
        Me.lblTopAvatar.Location = New System.Drawing.Point(0, 0)
        Me.lblTopAvatar.Name = "lblTopAvatar"
        Me.lblTopAvatar.Size = New System.Drawing.Size(36, 36)
        Me.lblTopAvatar.TabIndex = 0
        Me.lblTopAvatar.Text = "AD"
        Me.lblTopAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContract
        '
        Me.btnContract.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnContract.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContract.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnContract.FlatAppearance.BorderSize = 0
        Me.btnContract.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnContract.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContract.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnContract.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.btnContract.Location = New System.Drawing.Point(0, 106)
        Me.btnContract.Name = "btnContract"
        Me.btnContract.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnContract.Size = New System.Drawing.Size(200, 42)
        Me.btnContract.TabIndex = 10
        Me.btnContract.Tag = "Hợp đồng"
        Me.btnContract.Text = "  Hợp đồng"
        Me.btnContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tipNav.SetToolTip(Me.btnContract, "Hợp đồng")
        Me.btnContract.UseVisualStyleBackColor = False
        '
        'DfrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "DfrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wind Town — HRM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSbNav.ResumeLayout(False)
        Me.pnlSbFooter.ResumeLayout(False)
        Me.pnlSbTop.ResumeLayout(False)
        Me.pnlSbTop.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlTopbar.ResumeLayout(False)
        Me.pnlTopbar.PerformLayout()
        Me.pnlTopRight.ResumeLayout(False)
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ' ── Control Declarations ──────────────────────────────────
    Friend WithEvents tmrSb As System.Windows.Forms.Timer
    Friend WithEvents tipNav As System.Windows.Forms.ToolTip
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlSbTop As System.Windows.Forms.Panel
    Friend WithEvents btnToggle As System.Windows.Forms.Button
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblBrandSub As System.Windows.Forms.Label
    Friend WithEvents pnlSbNav As System.Windows.Forms.Panel
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents btnDash As System.Windows.Forms.Button
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents btnAttend As System.Windows.Forms.Button
    Friend WithEvents btnPayroll As System.Windows.Forms.Button
    Friend WithEvents lblSec2 As System.Windows.Forms.Label
    Friend WithEvents btnProject As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents pnlSbFooter As System.Windows.Forms.Panel
    Friend WithEvents lblSbUser As System.Windows.Forms.Label
    Friend WithEvents lblSbRole As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlTopbar As System.Windows.Forms.Panel
    Friend WithEvents lblPageTitle As System.Windows.Forms.Label
    Friend WithEvents lblPageDate As System.Windows.Forms.Label
    Friend WithEvents pnlTopRight As System.Windows.Forms.Panel
    Friend WithEvents lblTopAvatar As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents btnPayPeriod As Button
    Friend WithEvents picAvatar As PictureBox
    Friend WithEvents btnContract As Button
End Class