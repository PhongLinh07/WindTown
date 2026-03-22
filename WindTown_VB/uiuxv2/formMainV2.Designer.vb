<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formMainV2
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
        components = New ComponentModel.Container()
        tmrSb = New Timer(components)
        tipNav = New ToolTip(components)
        btnDash = New Button()
        btnEmployee = New Button()
        btnAttend = New Button()
        btnPayroll = New Button()
        btnProject = New Button()
        btnReport = New Button()
        btnSettings = New Button()
        btnPayPeriod = New Button()
        btnContract = New Button()
        btnPosition = New Button()
        btnJob = New Button()
        btnLevel = New Button()
        btnSalaryMult = New Button()
        btnLeave = New Button()
        btnLeaveCategory = New Button()
        btnHoliday = New Button()
        btnAssignment = New Button()
        btnPolicy = New Button()
        btnDepartment = New Button()
        pnlSidebar = New Panel()
        pnlSbNav = New Panel()
        lblSec2 = New Label()
        lblSec1 = New Label()
        pnlSbFooter = New Panel()
        lblSbRole = New Label()
        lblSbUser = New Label()
        pnlSbTop = New Panel()
        btnToggle = New Button()
        lblBrandSub = New Label()
        lblBrand = New Label()
        pnlMain = New Panel()
        pnlContent = New Panel()
        pnlTopbar = New Panel()
        pnlTopRight = New Panel()
        picAvatar = New PictureBox()
        lblPageDate = New Label()
        lblPageTitle = New Label()
        lblTopAvatar = New Label()
        pnlSidebar.SuspendLayout()
        pnlSbNav.SuspendLayout()
        pnlSbFooter.SuspendLayout()
        pnlSbTop.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlTopbar.SuspendLayout()
        pnlTopRight.SuspendLayout()
        CType(picAvatar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tmrSb
        ' 
        tmrSb.Interval = 12
        ' 
        ' tipNav
        ' 
        tipNav.AutoPopDelay = 3000
        tipNav.BackColor = Color.FromArgb(CByte(13), CByte(16), CByte(32))
        tipNav.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tipNav.InitialDelay = 300
        tipNav.ReshowDelay = 100
        ' 
        ' btnDash
        ' 
        btnDash.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnDash.Cursor = Cursors.Hand
        btnDash.Dock = DockStyle.Top
        btnDash.FlatAppearance.BorderSize = 0
        btnDash.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnDash.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnDash.FlatStyle = FlatStyle.Flat
        btnDash.Font = New Font("Microsoft YaHei UI", 10F)
        btnDash.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnDash.Location = New Point(0, 22)
        btnDash.Name = "btnDash"
        btnDash.Padding = New Padding(10, 0, 0, 0)
        btnDash.Size = New Size(200, 42)
        btnDash.TabIndex = 7
        btnDash.Tag = "  Dashboard"
        btnDash.Text = "  Dashboard"
        btnDash.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnDash, "Dashboard")
        btnDash.UseVisualStyleBackColor = False
        ' 
        ' btnEmployee
        ' 
        btnEmployee.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnEmployee.Cursor = Cursors.Hand
        btnEmployee.Dock = DockStyle.Top
        btnEmployee.FlatAppearance.BorderSize = 0
        btnEmployee.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnEmployee.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnEmployee.FlatStyle = FlatStyle.Flat
        btnEmployee.Font = New Font("Microsoft YaHei UI", 10F)
        btnEmployee.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnEmployee.Location = New Point(0, 64)
        btnEmployee.Name = "btnEmployee"
        btnEmployee.Padding = New Padding(10, 0, 0, 0)
        btnEmployee.Size = New Size(200, 42)
        btnEmployee.TabIndex = 6
        btnEmployee.Tag = "  Nhân viên"
        btnEmployee.Text = "  Nhân viên"
        btnEmployee.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnEmployee, "Nhân viên")
        btnEmployee.UseVisualStyleBackColor = False
        ' 
        ' btnAttend
        ' 
        btnAttend.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnAttend.Cursor = Cursors.Hand
        btnAttend.Dock = DockStyle.Top
        btnAttend.FlatAppearance.BorderSize = 0
        btnAttend.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnAttend.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnAttend.FlatStyle = FlatStyle.Flat
        btnAttend.Font = New Font("Microsoft YaHei UI", 10F)
        btnAttend.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnAttend.Location = New Point(0, 358)
        btnAttend.Name = "btnAttend"
        btnAttend.Padding = New Padding(10, 0, 0, 0)
        btnAttend.Size = New Size(200, 42)
        btnAttend.TabIndex = 5
        btnAttend.Tag = "  Chấm công"
        btnAttend.Text = "  Chấm công"
        btnAttend.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnAttend, "Chấm công")
        btnAttend.UseVisualStyleBackColor = False
        ' 
        ' btnPayroll
        ' 
        btnPayroll.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnPayroll.Cursor = Cursors.Hand
        btnPayroll.Dock = DockStyle.Top
        btnPayroll.FlatAppearance.BorderSize = 0
        btnPayroll.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnPayroll.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnPayroll.FlatStyle = FlatStyle.Flat
        btnPayroll.Font = New Font("Microsoft YaHei UI", 10F)
        btnPayroll.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPayroll.Location = New Point(0, 632)
        btnPayroll.Name = "btnPayroll"
        btnPayroll.Padding = New Padding(10, 0, 0, 0)
        btnPayroll.Size = New Size(200, 42)
        btnPayroll.TabIndex = 4
        btnPayroll.Tag = "  Lương thưởng"
        btnPayroll.Text = "  Lương thưởng"
        btnPayroll.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnPayroll, "Lương thưởng")
        btnPayroll.UseVisualStyleBackColor = False
        ' 
        ' btnProject
        ' 
        btnProject.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnProject.Cursor = Cursors.Hand
        btnProject.Dock = DockStyle.Top
        btnProject.FlatAppearance.BorderSize = 0
        btnProject.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnProject.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnProject.FlatStyle = FlatStyle.Flat
        btnProject.Font = New Font("Microsoft YaHei UI", 10F)
        btnProject.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnProject.Location = New Point(0, 526)
        btnProject.Name = "btnProject"
        btnProject.Padding = New Padding(10, 0, 0, 0)
        btnProject.Size = New Size(200, 42)
        btnProject.TabIndex = 2
        btnProject.Tag = "Dự án"
        btnProject.Text = "  Dự án"
        btnProject.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnProject, "Dự án")
        btnProject.UseVisualStyleBackColor = False
        ' 
        ' btnReport
        ' 
        btnReport.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnReport.Cursor = Cursors.Hand
        btnReport.Dock = DockStyle.Top
        btnReport.FlatAppearance.BorderSize = 0
        btnReport.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnReport.FlatStyle = FlatStyle.Flat
        btnReport.Font = New Font("Microsoft YaHei UI", 10F)
        btnReport.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnReport.Location = New Point(0, 758)
        btnReport.Name = "btnReport"
        btnReport.Padding = New Padding(10, 0, 0, 0)
        btnReport.Size = New Size(200, 42)
        btnReport.TabIndex = 1
        btnReport.Tag = "  Báo cáo"
        btnReport.Text = "  Báo cáo"
        btnReport.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnReport, "Báo cáo")
        btnReport.UseVisualStyleBackColor = False
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnSettings.Cursor = Cursors.Hand
        btnSettings.Dock = DockStyle.Top
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Microsoft YaHei UI", 10F)
        btnSettings.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnSettings.Location = New Point(0, 800)
        btnSettings.Name = "btnSettings"
        btnSettings.Padding = New Padding(10, 0, 0, 0)
        btnSettings.Size = New Size(200, 42)
        btnSettings.TabIndex = 0
        btnSettings.Tag = "  Cài đặt"
        btnSettings.Text = "  Cài đặt"
        btnSettings.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnSettings, "Cài đặt")
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnPayPeriod
        ' 
        btnPayPeriod.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnPayPeriod.Cursor = Cursors.Hand
        btnPayPeriod.Dock = DockStyle.Top
        btnPayPeriod.FlatAppearance.BorderSize = 0
        btnPayPeriod.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnPayPeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnPayPeriod.FlatStyle = FlatStyle.Flat
        btnPayPeriod.Font = New Font("Microsoft YaHei UI", 10F)
        btnPayPeriod.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPayPeriod.Location = New Point(0, 674)
        btnPayPeriod.Name = "btnPayPeriod"
        btnPayPeriod.Padding = New Padding(10, 0, 0, 0)
        btnPayPeriod.Size = New Size(200, 42)
        btnPayPeriod.TabIndex = 9
        btnPayPeriod.Tag = "Kỳ lương"
        btnPayPeriod.Text = "  Kỳ lương"
        btnPayPeriod.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnPayPeriod, "Kỳ lương")
        btnPayPeriod.UseVisualStyleBackColor = False
        ' 
        ' btnContract
        ' 
        btnContract.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnContract.Cursor = Cursors.Hand
        btnContract.Dock = DockStyle.Top
        btnContract.FlatAppearance.BorderSize = 0
        btnContract.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnContract.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnContract.FlatStyle = FlatStyle.Flat
        btnContract.Font = New Font("Microsoft YaHei UI", 10F)
        btnContract.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnContract.Location = New Point(0, 106)
        btnContract.Name = "btnContract"
        btnContract.Padding = New Padding(10, 0, 0, 0)
        btnContract.Size = New Size(200, 42)
        btnContract.TabIndex = 10
        btnContract.Tag = "Hợp đồng"
        btnContract.Text = "  Hợp đồng"
        btnContract.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnContract, "Hợp đồng")
        btnContract.UseVisualStyleBackColor = False
        ' 
        ' btnPosition
        ' 
        btnPosition.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnPosition.Cursor = Cursors.Hand
        btnPosition.Dock = DockStyle.Top
        btnPosition.FlatAppearance.BorderSize = 0
        btnPosition.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnPosition.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnPosition.FlatStyle = FlatStyle.Flat
        btnPosition.Font = New Font("Microsoft YaHei UI", 10F)
        btnPosition.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPosition.Location = New Point(0, 148)
        btnPosition.Name = "btnPosition"
        btnPosition.Padding = New Padding(10, 0, 0, 0)
        btnPosition.Size = New Size(200, 42)
        btnPosition.TabIndex = 12
        btnPosition.Tag = "Vị trí"
        btnPosition.Text = "  Vị trí"
        btnPosition.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnPosition, "Vị trí")
        btnPosition.UseVisualStyleBackColor = False
        ' 
        ' btnJob
        ' 
        btnJob.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnJob.Cursor = Cursors.Hand
        btnJob.Dock = DockStyle.Top
        btnJob.FlatAppearance.BorderSize = 0
        btnJob.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnJob.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnJob.FlatStyle = FlatStyle.Flat
        btnJob.Font = New Font("Microsoft YaHei UI", 10F)
        btnJob.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnJob.Location = New Point(0, 232)
        btnJob.Name = "btnJob"
        btnJob.Padding = New Padding(10, 0, 0, 0)
        btnJob.Size = New Size(200, 42)
        btnJob.TabIndex = 13
        btnJob.Tag = "Chức danh"
        btnJob.Text = "  Chức danh"
        btnJob.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnJob, "Chức danh")
        btnJob.UseVisualStyleBackColor = False
        ' 
        ' btnLevel
        ' 
        btnLevel.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnLevel.Cursor = Cursors.Hand
        btnLevel.Dock = DockStyle.Top
        btnLevel.FlatAppearance.BorderSize = 0
        btnLevel.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnLevel.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnLevel.FlatStyle = FlatStyle.Flat
        btnLevel.Font = New Font("Microsoft YaHei UI", 10F)
        btnLevel.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnLevel.Location = New Point(0, 274)
        btnLevel.Name = "btnLevel"
        btnLevel.Padding = New Padding(10, 0, 0, 0)
        btnLevel.Size = New Size(200, 42)
        btnLevel.TabIndex = 14
        btnLevel.Tag = "Cấp bậc"
        btnLevel.Text = "  Cấp bậc"
        btnLevel.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnLevel, "Cấp bậc")
        btnLevel.UseVisualStyleBackColor = False
        ' 
        ' btnSalaryMult
        ' 
        btnSalaryMult.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnSalaryMult.Cursor = Cursors.Hand
        btnSalaryMult.Dock = DockStyle.Top
        btnSalaryMult.FlatAppearance.BorderSize = 0
        btnSalaryMult.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnSalaryMult.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnSalaryMult.FlatStyle = FlatStyle.Flat
        btnSalaryMult.Font = New Font("Microsoft YaHei UI", 10F)
        btnSalaryMult.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnSalaryMult.Location = New Point(0, 316)
        btnSalaryMult.Name = "btnSalaryMult"
        btnSalaryMult.Padding = New Padding(10, 0, 0, 0)
        btnSalaryMult.Size = New Size(200, 42)
        btnSalaryMult.TabIndex = 15
        btnSalaryMult.Tag = "Hệ số lương"
        btnSalaryMult.Text = "  Hệ số lương"
        btnSalaryMult.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnSalaryMult, "Hệ số lương")
        btnSalaryMult.UseVisualStyleBackColor = False
        ' 
        ' btnLeave
        ' 
        btnLeave.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnLeave.Cursor = Cursors.Hand
        btnLeave.Dock = DockStyle.Top
        btnLeave.FlatAppearance.BorderSize = 0
        btnLeave.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnLeave.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnLeave.FlatStyle = FlatStyle.Flat
        btnLeave.Font = New Font("Microsoft YaHei UI", 10F)
        btnLeave.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnLeave.Location = New Point(0, 400)
        btnLeave.Name = "btnLeave"
        btnLeave.Padding = New Padding(10, 0, 0, 0)
        btnLeave.Size = New Size(200, 42)
        btnLeave.TabIndex = 16
        btnLeave.Tag = "Nghỉ phép"
        btnLeave.Text = "  Nghỉ phép"
        btnLeave.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnLeave, "Nghỉ phép")
        btnLeave.UseVisualStyleBackColor = False
        ' 
        ' btnLeaveCategory
        ' 
        btnLeaveCategory.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnLeaveCategory.Cursor = Cursors.Hand
        btnLeaveCategory.Dock = DockStyle.Top
        btnLeaveCategory.FlatAppearance.BorderSize = 0
        btnLeaveCategory.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnLeaveCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnLeaveCategory.FlatStyle = FlatStyle.Flat
        btnLeaveCategory.Font = New Font("Microsoft YaHei UI", 10F)
        btnLeaveCategory.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnLeaveCategory.Location = New Point(0, 442)
        btnLeaveCategory.Name = "btnLeaveCategory"
        btnLeaveCategory.Padding = New Padding(10, 0, 0, 0)
        btnLeaveCategory.Size = New Size(200, 42)
        btnLeaveCategory.TabIndex = 17
        btnLeaveCategory.Tag = "Loại nghỉ"
        btnLeaveCategory.Text = "  Loại nghỉ"
        btnLeaveCategory.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnLeaveCategory, "Loại nghỉ")
        btnLeaveCategory.UseVisualStyleBackColor = False
        ' 
        ' btnHoliday
        ' 
        btnHoliday.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnHoliday.Cursor = Cursors.Hand
        btnHoliday.Dock = DockStyle.Top
        btnHoliday.FlatAppearance.BorderSize = 0
        btnHoliday.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnHoliday.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnHoliday.FlatStyle = FlatStyle.Flat
        btnHoliday.Font = New Font("Microsoft YaHei UI", 10F)
        btnHoliday.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnHoliday.Location = New Point(0, 484)
        btnHoliday.Name = "btnHoliday"
        btnHoliday.Padding = New Padding(10, 0, 0, 0)
        btnHoliday.Size = New Size(200, 42)
        btnHoliday.TabIndex = 18
        btnHoliday.Tag = "Ngày lễ"
        btnHoliday.Text = "  Ngày lễ"
        btnHoliday.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnHoliday, "Ngày lễ")
        btnHoliday.UseVisualStyleBackColor = False
        ' 
        ' btnAssignment
        ' 
        btnAssignment.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnAssignment.Cursor = Cursors.Hand
        btnAssignment.Dock = DockStyle.Top
        btnAssignment.FlatAppearance.BorderSize = 0
        btnAssignment.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnAssignment.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnAssignment.FlatStyle = FlatStyle.Flat
        btnAssignment.Font = New Font("Microsoft YaHei UI", 10F)
        btnAssignment.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnAssignment.Location = New Point(0, 568)
        btnAssignment.Name = "btnAssignment"
        btnAssignment.Padding = New Padding(10, 0, 0, 0)
        btnAssignment.Size = New Size(200, 42)
        btnAssignment.TabIndex = 19
        btnAssignment.Tag = "Phân công"
        btnAssignment.Text = "  Phân công"
        btnAssignment.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnAssignment, "Phân công")
        btnAssignment.UseVisualStyleBackColor = False
        ' 
        ' btnPolicy
        ' 
        btnPolicy.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnPolicy.Cursor = Cursors.Hand
        btnPolicy.Dock = DockStyle.Top
        btnPolicy.FlatAppearance.BorderSize = 0
        btnPolicy.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnPolicy.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnPolicy.FlatStyle = FlatStyle.Flat
        btnPolicy.Font = New Font("Microsoft YaHei UI", 10F)
        btnPolicy.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPolicy.Location = New Point(0, 716)
        btnPolicy.Name = "btnPolicy"
        btnPolicy.Padding = New Padding(10, 0, 0, 0)
        btnPolicy.Size = New Size(200, 42)
        btnPolicy.TabIndex = 20
        btnPolicy.Tag = "Chính sách"
        btnPolicy.Text = "  Chính sách"
        btnPolicy.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnPolicy, "Chính sách")
        btnPolicy.UseVisualStyleBackColor = False
        ' 
        ' btnDepartment
        ' 
        btnDepartment.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        btnDepartment.Cursor = Cursors.Hand
        btnDepartment.Dock = DockStyle.Top
        btnDepartment.FlatAppearance.BorderSize = 0
        btnDepartment.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(30), CByte(50), CByte(80))
        btnDepartment.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(25), CByte(32), CByte(55))
        btnDepartment.FlatStyle = FlatStyle.Flat
        btnDepartment.Font = New Font("Microsoft YaHei UI", 10F)
        btnDepartment.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnDepartment.Location = New Point(0, 190)
        btnDepartment.Name = "btnDepartment"
        btnDepartment.Padding = New Padding(10, 0, 0, 0)
        btnDepartment.Size = New Size(200, 42)
        btnDepartment.TabIndex = 11
        btnDepartment.Tag = "Phòng ban"
        btnDepartment.Text = "  Phòng ban"
        btnDepartment.TextAlign = ContentAlignment.MiddleLeft
        tipNav.SetToolTip(btnDepartment, "Phòng ban")
        btnDepartment.UseVisualStyleBackColor = False
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(19), CByte(22), CByte(41))
        pnlSidebar.Controls.Add(pnlSbNav)
        pnlSidebar.Controls.Add(pnlSbFooter)
        pnlSidebar.Controls.Add(pnlSbTop)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(200, 720)
        pnlSidebar.TabIndex = 1
        ' 
        ' pnlSbNav
        ' 
        pnlSbNav.BackColor = Color.Transparent
        pnlSbNav.Controls.Add(btnSettings)
        pnlSbNav.Controls.Add(btnReport)
        pnlSbNav.Controls.Add(btnPolicy)
        pnlSbNav.Controls.Add(btnPayPeriod)
        pnlSbNav.Controls.Add(btnPayroll)
        pnlSbNav.Controls.Add(lblSec2)
        pnlSbNav.Controls.Add(btnAssignment)
        pnlSbNav.Controls.Add(btnProject)
        pnlSbNav.Controls.Add(btnHoliday)
        pnlSbNav.Controls.Add(btnLeaveCategory)
        pnlSbNav.Controls.Add(btnLeave)
        pnlSbNav.Controls.Add(btnAttend)
        pnlSbNav.Controls.Add(btnSalaryMult)
        pnlSbNav.Controls.Add(btnLevel)
        pnlSbNav.Controls.Add(btnJob)
        pnlSbNav.Controls.Add(btnDepartment)
        pnlSbNav.Controls.Add(btnPosition)
        pnlSbNav.Controls.Add(btnContract)
        pnlSbNav.Controls.Add(btnEmployee)
        pnlSbNav.Controls.Add(btnDash)
        pnlSbNav.Controls.Add(lblSec1)
        pnlSbNav.Dock = DockStyle.Fill
        pnlSbNav.Location = New Point(0, 60)
        pnlSbNav.Name = "pnlSbNav"
        pnlSbNav.Size = New Size(200, 601)
        pnlSbNav.TabIndex = 0
        ' 
        ' lblSec2
        ' 
        lblSec2.BackColor = Color.Transparent
        lblSec2.Dock = DockStyle.Top
        lblSec2.Font = New Font("Microsoft YaHei UI", 7.5F, FontStyle.Bold)
        lblSec2.ForeColor = Color.FromArgb(CByte(45), CByte(58), CByte(90))
        lblSec2.Location = New Point(0, 610)
        lblSec2.Name = "lblSec2"
        lblSec2.Padding = New Padding(14, 0, 0, 0)
        lblSec2.Size = New Size(200, 22)
        lblSec2.TabIndex = 3
        lblSec2.Text = "QUẢN LÝ"
        ' 
        ' lblSec1
        ' 
        lblSec1.BackColor = Color.Transparent
        lblSec1.Dock = DockStyle.Top
        lblSec1.Font = New Font("Microsoft YaHei UI", 7.5F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(45), CByte(58), CByte(90))
        lblSec1.Location = New Point(0, 0)
        lblSec1.Name = "lblSec1"
        lblSec1.Padding = New Padding(14, 0, 0, 0)
        lblSec1.Size = New Size(200, 22)
        lblSec1.TabIndex = 8
        lblSec1.Text = "CHÍNH"
        ' 
        ' pnlSbFooter
        ' 
        pnlSbFooter.BackColor = Color.FromArgb(CByte(13), CByte(16), CByte(32))
        pnlSbFooter.Controls.Add(lblSbRole)
        pnlSbFooter.Controls.Add(lblSbUser)
        pnlSbFooter.Dock = DockStyle.Bottom
        pnlSbFooter.Location = New Point(0, 661)
        pnlSbFooter.Name = "pnlSbFooter"
        pnlSbFooter.Size = New Size(200, 59)
        pnlSbFooter.TabIndex = 1
        ' 
        ' lblSbRole
        ' 
        lblSbRole.Dock = DockStyle.Top
        lblSbRole.Font = New Font("Microsoft YaHei UI", 8F)
        lblSbRole.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSbRole.Location = New Point(0, 31)
        lblSbRole.Name = "lblSbRole"
        lblSbRole.Size = New Size(200, 18)
        lblSbRole.TabIndex = 0
        lblSbRole.Text = "Quản trị viên"
        ' 
        ' lblSbUser
        ' 
        lblSbUser.Dock = DockStyle.Top
        lblSbUser.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblSbUser.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblSbUser.Location = New Point(0, 0)
        lblSbUser.Name = "lblSbUser"
        lblSbUser.Size = New Size(200, 31)
        lblSbUser.TabIndex = 1
        lblSbUser.Text = "Admin"
        ' 
        ' pnlSbTop
        ' 
        pnlSbTop.BackColor = Color.FromArgb(CByte(13), CByte(16), CByte(32))
        pnlSbTop.Controls.Add(btnToggle)
        pnlSbTop.Controls.Add(lblBrandSub)
        pnlSbTop.Controls.Add(lblBrand)
        pnlSbTop.Dock = DockStyle.Top
        pnlSbTop.Location = New Point(0, 0)
        pnlSbTop.Name = "pnlSbTop"
        pnlSbTop.Size = New Size(200, 60)
        pnlSbTop.TabIndex = 2
        ' 
        ' btnToggle
        ' 
        btnToggle.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        btnToggle.Cursor = Cursors.Hand
        btnToggle.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnToggle.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        btnToggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnToggle.FlatStyle = FlatStyle.Flat
        btnToggle.Font = New Font("Microsoft YaHei UI", 9F)
        btnToggle.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnToggle.Location = New Point(166, 18)
        btnToggle.Name = "btnToggle"
        btnToggle.Size = New Size(24, 24)
        btnToggle.TabIndex = 0
        btnToggle.Text = "<"
        btnToggle.UseVisualStyleBackColor = False
        ' 
        ' lblBrandSub
        ' 
        lblBrandSub.AutoSize = True
        lblBrandSub.Font = New Font("Microsoft YaHei UI", 8F)
        lblBrandSub.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblBrandSub.Location = New Point(12, 30)
        lblBrandSub.Name = "lblBrandSub"
        lblBrandSub.Size = New Size(86, 20)
        lblBrandSub.TabIndex = 1
        lblBrandSub.Text = "Wind Town"
        ' 
        ' lblBrand
        ' 
        lblBrand.AutoSize = True
        lblBrand.Font = New Font("Microsoft YaHei UI", 11F, FontStyle.Bold)
        lblBrand.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblBrand.Location = New Point(12, 8)
        lblBrand.Name = "lblBrand"
        lblBrand.Size = New Size(136, 26)
        lblBrand.TabIndex = 2
        lblBrand.Text = "HRM System"
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlTopbar)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(200, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1080, 720)
        pnlMain.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 56)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1080, 664)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTopbar
        ' 
        pnlTopbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlTopbar.Controls.Add(pnlTopRight)
        pnlTopbar.Controls.Add(lblPageDate)
        pnlTopbar.Controls.Add(lblPageTitle)
        pnlTopbar.Dock = DockStyle.Top
        pnlTopbar.Location = New Point(0, 0)
        pnlTopbar.Name = "pnlTopbar"
        pnlTopbar.Size = New Size(1080, 56)
        pnlTopbar.TabIndex = 1
        ' 
        ' pnlTopRight
        ' 
        pnlTopRight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlTopRight.BackColor = Color.Transparent
        pnlTopRight.Controls.Add(picAvatar)
        pnlTopRight.Location = New Point(1780, 8)
        pnlTopRight.Name = "pnlTopRight"
        pnlTopRight.Size = New Size(40, 40)
        pnlTopRight.TabIndex = 0
        ' 
        ' picAvatar
        ' 
        picAvatar.Dock = DockStyle.Fill
        picAvatar.Image = My.Resources.Resources.AvatarUser
        picAvatar.Location = New Point(0, 0)
        picAvatar.Name = "picAvatar"
        picAvatar.Size = New Size(40, 40)
        picAvatar.SizeMode = PictureBoxSizeMode.Zoom
        picAvatar.TabIndex = 0
        picAvatar.TabStop = False
        ' 
        ' lblPageDate
        ' 
        lblPageDate.AutoSize = True
        lblPageDate.Font = New Font("Microsoft YaHei UI", 9F)
        lblPageDate.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPageDate.Location = New Point(18, 32)
        lblPageDate.Name = "lblPageDate"
        lblPageDate.Size = New Size(0, 20)
        lblPageDate.TabIndex = 1
        ' 
        ' lblPageTitle
        ' 
        lblPageTitle.AutoSize = True
        lblPageTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblPageTitle.Location = New Point(18, 8)
        lblPageTitle.Name = "lblPageTitle"
        lblPageTitle.Size = New Size(134, 30)
        lblPageTitle.TabIndex = 2
        lblPageTitle.Text = "Dashboard"
        ' 
        ' lblTopAvatar
        ' 
        lblTopAvatar.BackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        lblTopAvatar.Cursor = Cursors.Hand
        lblTopAvatar.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblTopAvatar.ForeColor = Color.White
        lblTopAvatar.Location = New Point(0, 0)
        lblTopAvatar.Name = "lblTopAvatar"
        lblTopAvatar.Size = New Size(36, 36)
        lblTopAvatar.TabIndex = 0
        lblTopAvatar.Text = "AD"
        lblTopAvatar.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' formMainV2
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1280, 720)
        Controls.Add(pnlMain)
        Controls.Add(pnlSidebar)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(900, 600)
        Name = "formMainV2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Wind Town — HRM"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlSbNav.ResumeLayout(False)
        pnlSbFooter.ResumeLayout(False)
        pnlSbTop.ResumeLayout(False)
        pnlSbTop.PerformLayout()
        pnlMain.ResumeLayout(False)
        pnlTopbar.ResumeLayout(False)
        pnlTopbar.PerformLayout()
        pnlTopRight.ResumeLayout(False)
        CType(picAvatar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

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
    Friend WithEvents btnDepartment As Button
    Friend WithEvents btnPosition As Button
    Friend WithEvents btnJob As Button
    Friend WithEvents btnLevel As Button
    Friend WithEvents btnSalaryMult As Button
    Friend WithEvents btnLeave As Button
    Friend WithEvents btnLeaveCategory As Button
    Friend WithEvents btnHoliday As Button
    Friend WithEvents btnAssignment As Button
    Friend WithEvents btnPolicy As Button
End Class
