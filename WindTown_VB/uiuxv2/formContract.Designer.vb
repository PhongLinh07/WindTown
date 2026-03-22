<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formContract
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
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlRight = New Panel()
        pnlFormScroll = New Panel()
        pnlSec4 = New Panel()
        txtFNote = New TextBox()
        lblSec4Title = New Label()
        pnlSec3 = New Panel()
        tlpSec3 = New TableLayoutPanel()
        lblFBaseSalary = New Label()
        txtFBaseSalary = New TextBox()
        lblFBaseSalaryHint = New Label()
        lblFSalaryPreview = New Label()
        lblSalaryPreviewVal = New Label()
        lblSec3Title = New Label()
        pnlSec2 = New Panel()
        tlpSec2 = New TableLayoutPanel()
        lblFStart = New Label()
        dtpStart = New DateTimePicker()
        lblFEnd = New Label()
        pnlEndDateRow = New Panel()
        chkNoEndDate = New CheckBox()
        dtpEnd = New DateTimePicker()
        lblFDuration = New Label()
        lblDurationVal = New Label()
        lblSec2Title = New Label()
        pnlSec1 = New Panel()
        tlpSec1 = New TableLayoutPanel()
        lblFCode = New Label()
        txtFCode = New TextBox()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
        lblFEmp = New Label()
        cboFEmp = New ComboBox()
        lblSec1Title = New Label()
        pnlRightFooter = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        pnlEmpCard = New Panel()
        pnlContractBadge = New Panel()
        lblBadgeDaysLeft = New Label()
        lblBadgeStatus = New Label()
        lblEmpDept = New Label()
        lblEmpMeta = New Label()
        lblEmpName = New Label()
        pnlEmpAvatar = New Panel()
        splitter = New Splitter()
        pnlLeft = New Panel()
        dgvContract = New DataGridView()
        colAvatar = New DataGridViewTextBoxColumn()
        colEmpName = New DataGridViewTextBoxColumn()
        colCode = New DataGridViewTextBoxColumn()
        colStartDate = New DataGridViewTextBoxColumn()
        colEndDate = New DataGridViewTextBoxColumn()
        colBaseSalary = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        colDaysLeft = New DataGridViewTextBoxColumn()
        pnlLeftFooter = New Panel()
        pnlPageBtns = New Panel()
        btnPageNext = New Button()
        btnPage2 = New Button()
        btnPage1 = New Button()
        btnPagePrev = New Button()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        cboDept = New ComboBox()
        txtSearch = New TextBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
        pnlSec4.SuspendLayout()
        pnlSec3.SuspendLayout()
        tlpSec3.SuspendLayout()
        pnlSec2.SuspendLayout()
        tlpSec2.SuspendLayout()
        pnlEndDateRow.SuspendLayout()
        pnlSec1.SuspendLayout()
        tlpSec1.SuspendLayout()
        pnlRightFooter.SuspendLayout()
        pnlEmpCard.SuspendLayout()
        pnlContractBadge.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(dgvContract, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftFooter.SuspendLayout()
        pnlPageBtns.SuspendLayout()
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
        pnlRoot.Size = New Size(982, 553)
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
        pnlContent.Size = New Size(982, 501)
        pnlContent.TabIndex = 0
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlFormScroll)
        pnlRight.Controls.Add(pnlRightFooter)
        pnlRight.Controls.Add(pnlEmpCard)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(641, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(341, 501)
        pnlRight.TabIndex = 0
        ' 
        ' pnlFormScroll
        ' 
        pnlFormScroll.AutoScroll = True
        pnlFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFormScroll.Controls.Add(pnlSec4)
        pnlFormScroll.Controls.Add(pnlSec3)
        pnlFormScroll.Controls.Add(pnlSec2)
        pnlFormScroll.Controls.Add(pnlSec1)
        pnlFormScroll.Dock = DockStyle.Fill
        pnlFormScroll.Location = New Point(0, 96)
        pnlFormScroll.Name = "pnlFormScroll"
        pnlFormScroll.Padding = New Padding(16, 14, 16, 14)
        pnlFormScroll.Size = New Size(341, 353)
        pnlFormScroll.TabIndex = 0
        ' 
        ' pnlSec4
        ' 
        pnlSec4.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec4.Controls.Add(txtFNote)
        pnlSec4.Controls.Add(lblSec4Title)
        pnlSec4.Dock = DockStyle.Top
        pnlSec4.Location = New Point(16, 662)
        pnlSec4.Margin = New Padding(0, 10, 0, 0)
        pnlSec4.Name = "pnlSec4"
        pnlSec4.Padding = New Padding(16, 12, 16, 12)
        pnlSec4.Size = New Size(288, 116)
        pnlSec4.TabIndex = 0
        ' 
        ' txtFNote
        ' 
        txtFNote.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFNote.BorderStyle = BorderStyle.FixedSingle
        txtFNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtFNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFNote.Location = New Point(16, 34)
        txtFNote.Multiline = True
        txtFNote.Name = "txtFNote"
        txtFNote.ScrollBars = ScrollBars.Vertical
        txtFNote.Size = New Size(288, 68)
        txtFNote.TabIndex = 7
        ' 
        ' lblSec4Title
        ' 
        lblSec4Title.AutoSize = True
        lblSec4Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec4Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec4Title.Location = New Point(16, 12)
        lblSec4Title.Name = "lblSec4Title"
        lblSec4Title.Size = New Size(73, 19)
        lblSec4Title.TabIndex = 8
        lblSec4Title.Text = "GHI CHÚ"
        ' 
        ' pnlSec3
        ' 
        pnlSec3.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec3.Controls.Add(tlpSec3)
        pnlSec3.Controls.Add(lblSec3Title)
        pnlSec3.Dock = DockStyle.Top
        pnlSec3.Location = New Point(16, 496)
        pnlSec3.Margin = New Padding(0, 10, 0, 10)
        pnlSec3.Name = "pnlSec3"
        pnlSec3.Padding = New Padding(16, 12, 16, 12)
        pnlSec3.Size = New Size(288, 166)
        pnlSec3.TabIndex = 1
        ' 
        ' tlpSec3
        ' 
        tlpSec3.BackColor = Color.Transparent
        tlpSec3.ColumnCount = 2
        tlpSec3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec3.Controls.Add(lblFBaseSalary, 0, 0)
        tlpSec3.Controls.Add(txtFBaseSalary, 0, 1)
        tlpSec3.Controls.Add(lblFBaseSalaryHint, 1, 1)
        tlpSec3.Controls.Add(lblFSalaryPreview, 0, 2)
        tlpSec3.Controls.Add(lblSalaryPreviewVal, 1, 2)
        tlpSec3.Dock = DockStyle.Bottom
        tlpSec3.Location = New Point(16, 20)
        tlpSec3.Name = "tlpSec3"
        tlpSec3.RowCount = 3
        tlpSec3.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec3.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec3.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        tlpSec3.Size = New Size(256, 134)
        tlpSec3.TabIndex = 0
        ' 
        ' lblFBaseSalary
        ' 
        lblFBaseSalary.AutoSize = True
        tlpSec3.SetColumnSpan(lblFBaseSalary, 2)
        lblFBaseSalary.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFBaseSalary.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFBaseSalary.Location = New Point(3, 0)
        lblFBaseSalary.Name = "lblFBaseSalary"
        lblFBaseSalary.Size = New Size(228, 19)
        lblFBaseSalary.TabIndex = 0
        lblFBaseSalary.Text = "Lương cơ bản (base_salary)  *"
        ' 
        ' txtFBaseSalary
        ' 
        txtFBaseSalary.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFBaseSalary.BorderStyle = BorderStyle.FixedSingle
        txtFBaseSalary.Dock = DockStyle.Fill
        txtFBaseSalary.Font = New Font("Microsoft YaHei UI", 10F)
        txtFBaseSalary.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFBaseSalary.Location = New Point(0, 22)
        txtFBaseSalary.Margin = New Padding(0, 0, 8, 4)
        txtFBaseSalary.Name = "txtFBaseSalary"
        txtFBaseSalary.Size = New Size(120, 28)
        txtFBaseSalary.TabIndex = 6
        txtFBaseSalary.Text = "0"
        ' 
        ' lblFBaseSalaryHint
        ' 
        lblFBaseSalaryHint.AutoSize = True
        lblFBaseSalaryHint.Font = New Font("Microsoft YaHei UI", 9F)
        lblFBaseSalaryHint.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblFBaseSalaryHint.Location = New Point(136, 36)
        lblFBaseSalaryHint.Margin = New Padding(8, 14, 0, 0)
        lblFBaseSalaryHint.Name = "lblFBaseSalaryHint"
        lblFBaseSalaryHint.Size = New Size(111, 28)
        lblFBaseSalaryHint.TabIndex = 7
        lblFBaseSalaryHint.Text = "Nhập số nguyên, đơn vị VNĐ"
        ' 
        ' lblFSalaryPreview
        ' 
        lblFSalaryPreview.AutoSize = True
        lblFSalaryPreview.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFSalaryPreview.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFSalaryPreview.Location = New Point(0, 72)
        lblFSalaryPreview.Margin = New Padding(0, 8, 0, 0)
        lblFSalaryPreview.Name = "lblFSalaryPreview"
        lblFSalaryPreview.Size = New Size(72, 19)
        lblFSalaryPreview.TabIndex = 8
        lblFSalaryPreview.Text = "Hiển thị:"
        ' 
        ' lblSalaryPreviewVal
        ' 
        lblSalaryPreviewVal.AutoSize = True
        lblSalaryPreviewVal.Font = New Font("Microsoft YaHei UI", 11F, FontStyle.Bold)
        lblSalaryPreviewVal.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblSalaryPreviewVal.Location = New Point(136, 70)
        lblSalaryPreviewVal.Margin = New Padding(8, 6, 0, 0)
        lblSalaryPreviewVal.Name = "lblSalaryPreviewVal"
        lblSalaryPreviewVal.Size = New Size(33, 26)
        lblSalaryPreviewVal.TabIndex = 9
        lblSalaryPreviewVal.Text = "—"
        ' 
        ' lblSec3Title
        ' 
        lblSec3Title.AutoSize = True
        lblSec3Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec3Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec3Title.Location = New Point(16, 12)
        lblSec3Title.Name = "lblSec3Title"
        lblSec3Title.Size = New Size(124, 19)
        lblSec3Title.TabIndex = 1
        lblSec3Title.Text = "LƯƠNG CƠ BẢN"
        ' 
        ' pnlSec2
        ' 
        pnlSec2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec2.Controls.Add(tlpSec2)
        pnlSec2.Controls.Add(lblSec2Title)
        pnlSec2.Dock = DockStyle.Top
        pnlSec2.Location = New Point(16, 238)
        pnlSec2.Margin = New Padding(0, 10, 0, 10)
        pnlSec2.Name = "pnlSec2"
        pnlSec2.Padding = New Padding(16, 12, 16, 12)
        pnlSec2.Size = New Size(288, 258)
        pnlSec2.TabIndex = 2
        ' 
        ' tlpSec2
        ' 
        tlpSec2.BackColor = Color.Transparent
        tlpSec2.ColumnCount = 2
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec2.Controls.Add(lblFStart, 0, 0)
        tlpSec2.Controls.Add(dtpStart, 0, 1)
        tlpSec2.Controls.Add(lblFEnd, 1, 0)
        tlpSec2.Controls.Add(pnlEndDateRow, 1, 1)
        tlpSec2.Controls.Add(lblFDuration, 0, 2)
        tlpSec2.Controls.Add(lblDurationVal, 1, 2)
        tlpSec2.Dock = DockStyle.Bottom
        tlpSec2.Location = New Point(16, 22)
        tlpSec2.Name = "tlpSec2"
        tlpSec2.RowCount = 3
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        tlpSec2.Size = New Size(256, 224)
        tlpSec2.TabIndex = 0
        ' 
        ' lblFStart
        ' 
        lblFStart.AutoSize = True
        lblFStart.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStart.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStart.Location = New Point(3, 0)
        lblFStart.Name = "lblFStart"
        lblFStart.Size = New Size(120, 22)
        lblFStart.TabIndex = 0
        lblFStart.Text = "Ngày bắt đầu  *"
        ' 
        ' dtpStart
        ' 
        dtpStart.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpStart.CalendarMonthBackground = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dtpStart.CalendarTitleBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        dtpStart.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        dtpStart.CustomFormat = "dd/MM/yyyy"
        dtpStart.Dock = DockStyle.Fill
        dtpStart.Font = New Font("Microsoft YaHei UI", 10F)
        dtpStart.Format = DateTimePickerFormat.Custom
        dtpStart.Location = New Point(0, 22)
        dtpStart.Margin = New Padding(0, 0, 8, 4)
        dtpStart.Name = "dtpStart"
        dtpStart.Size = New Size(120, 28)
        dtpStart.TabIndex = 3
        ' 
        ' lblFEnd
        ' 
        lblFEnd.AutoSize = True
        lblFEnd.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFEnd.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFEnd.Location = New Point(136, 0)
        lblFEnd.Margin = New Padding(8, 0, 0, 0)
        lblFEnd.Name = "lblFEnd"
        lblFEnd.Size = New Size(116, 19)
        lblFEnd.TabIndex = 4
        lblFEnd.Text = "Ngày kết thúc"
        ' 
        ' pnlEndDateRow
        ' 
        pnlEndDateRow.BackColor = Color.Transparent
        pnlEndDateRow.Controls.Add(chkNoEndDate)
        pnlEndDateRow.Controls.Add(dtpEnd)
        pnlEndDateRow.Dock = DockStyle.Fill
        pnlEndDateRow.Location = New Point(136, 22)
        pnlEndDateRow.Margin = New Padding(8, 0, 0, 4)
        pnlEndDateRow.Name = "pnlEndDateRow"
        pnlEndDateRow.Size = New Size(120, 38)
        pnlEndDateRow.TabIndex = 5
        ' 
        ' chkNoEndDate
        ' 
        chkNoEndDate.AutoSize = True
        chkNoEndDate.Font = New Font("Microsoft YaHei UI", 9F)
        chkNoEndDate.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        chkNoEndDate.Location = New Point(186, 5)
        chkNoEndDate.Name = "chkNoEndDate"
        chkNoEndDate.Size = New Size(141, 24)
        chkNoEndDate.TabIndex = 5
        chkNoEndDate.Text = "Không thời hạn"
        chkNoEndDate.UseVisualStyleBackColor = True
        ' 
        ' dtpEnd
        ' 
        dtpEnd.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpEnd.CalendarMonthBackground = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dtpEnd.CalendarTitleBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        dtpEnd.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        dtpEnd.CustomFormat = "dd/MM/yyyy"
        dtpEnd.Font = New Font("Microsoft YaHei UI", 10F)
        dtpEnd.Format = DateTimePickerFormat.Custom
        dtpEnd.Location = New Point(0, 0)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(180, 28)
        dtpEnd.TabIndex = 4
        ' 
        ' lblFDuration
        ' 
        lblFDuration.AutoSize = True
        lblFDuration.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFDuration.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFDuration.Location = New Point(3, 64)
        lblFDuration.Name = "lblFDuration"
        lblFDuration.Size = New Size(113, 38)
        lblFDuration.TabIndex = 6
        lblFDuration.Text = "Thời hạn hợp đồng"
        ' 
        ' lblDurationVal
        ' 
        lblDurationVal.AutoSize = True
        lblDurationVal.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblDurationVal.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblDurationVal.Location = New Point(136, 72)
        lblDurationVal.Margin = New Padding(8, 8, 0, 0)
        lblDurationVal.Name = "lblDurationVal"
        lblDurationVal.Size = New Size(27, 22)
        lblDurationVal.TabIndex = 7
        lblDurationVal.Text = "—"
        ' 
        ' lblSec2Title
        ' 
        lblSec2Title.AutoSize = True
        lblSec2Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec2Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec2Title.Location = New Point(16, 12)
        lblSec2Title.Name = "lblSec2Title"
        lblSec2Title.Size = New Size(172, 19)
        lblSec2Title.TabIndex = 1
        lblSec2Title.Text = "THỜI HẠN HỢP ĐỒNG"
        ' 
        ' pnlSec1
        ' 
        pnlSec1.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec1.Controls.Add(tlpSec1)
        pnlSec1.Controls.Add(lblSec1Title)
        pnlSec1.Dock = DockStyle.Top
        pnlSec1.Location = New Point(16, 14)
        pnlSec1.Margin = New Padding(0, 0, 0, 10)
        pnlSec1.Name = "pnlSec1"
        pnlSec1.Padding = New Padding(16, 12, 16, 12)
        pnlSec1.Size = New Size(288, 224)
        pnlSec1.TabIndex = 3
        ' 
        ' tlpSec1
        ' 
        tlpSec1.BackColor = Color.Transparent
        tlpSec1.ColumnCount = 2
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.Controls.Add(lblFCode, 0, 0)
        tlpSec1.Controls.Add(txtFCode, 0, 1)
        tlpSec1.Controls.Add(lblFStatus, 1, 0)
        tlpSec1.Controls.Add(cboFStatus, 1, 1)
        tlpSec1.Controls.Add(lblFEmp, 0, 2)
        tlpSec1.Controls.Add(cboFEmp, 0, 3)
        tlpSec1.Dock = DockStyle.Bottom
        tlpSec1.Location = New Point(16, 20)
        tlpSec1.Name = "tlpSec1"
        tlpSec1.RowCount = 4
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        tlpSec1.Size = New Size(256, 192)
        tlpSec1.TabIndex = 0
        ' 
        ' lblFCode
        ' 
        lblFCode.AutoSize = True
        lblFCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCode.Location = New Point(3, 0)
        lblFCode.Name = "lblFCode"
        lblFCode.Size = New Size(119, 22)
        lblFCode.TabIndex = 0
        lblFCode.Text = "Mã hợp đồng  *"
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
        txtFCode.Size = New Size(120, 26)
        txtFCode.TabIndex = 0
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(136, 0)
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
        cboFStatus.Items.AddRange(New Object() {"● Đang hiệu lực", "⚠ Sắp hết hạn", "○ Đã hết hạn", "✕ Đã hủy"})
        cboFStatus.Location = New Point(136, 22)
        cboFStatus.Margin = New Padding(8, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(120, 29)
        cboFStatus.TabIndex = 1
        ' 
        ' lblFEmp
        ' 
        lblFEmp.AutoSize = True
        tlpSec1.SetColumnSpan(lblFEmp, 2)
        lblFEmp.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFEmp.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFEmp.Location = New Point(3, 64)
        lblFEmp.Name = "lblFEmp"
        lblFEmp.Size = New Size(102, 19)
        lblFEmp.TabIndex = 2
        lblFEmp.Text = "Nhân viên  *"
        ' 
        ' cboFEmp
        ' 
        cboFEmp.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        tlpSec1.SetColumnSpan(cboFEmp, 2)
        cboFEmp.Dock = DockStyle.Fill
        cboFEmp.DropDownStyle = ComboBoxStyle.DropDownList
        cboFEmp.FlatStyle = FlatStyle.Flat
        cboFEmp.Font = New Font("Microsoft YaHei UI", 10F)
        cboFEmp.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFEmp.Location = New Point(0, 86)
        cboFEmp.Margin = New Padding(0, 0, 0, 4)
        cboFEmp.Name = "cboFEmp"
        cboFEmp.Size = New Size(256, 29)
        cboFEmp.TabIndex = 2
        ' 
        ' lblSec1Title
        ' 
        lblSec1Title.AutoSize = True
        lblSec1Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1Title.Location = New Point(16, 12)
        lblSec1Title.Name = "lblSec1Title"
        lblSec1Title.Size = New Size(181, 19)
        lblSec1Title.TabIndex = 1
        lblSec1Title.Text = "THÔNG TIN HỢP ĐỒNG"
        ' 
        ' pnlRightFooter
        ' 
        pnlRightFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlRightFooter.Controls.Add(btnSave)
        pnlRightFooter.Controls.Add(btnClear)
        pnlRightFooter.Controls.Add(btnDelete)
        pnlRightFooter.Dock = DockStyle.Bottom
        pnlRightFooter.Location = New Point(0, 449)
        pnlRightFooter.Name = "pnlRightFooter"
        pnlRightFooter.Size = New Size(341, 52)
        pnlRightFooter.TabIndex = 1
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
        btnSave.Location = New Point(820, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "✓  Lưu hợp đồng"
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
        btnClear.Location = New Point(710, 10)
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
        btnDelete.Text = "Xóa hợp đồng"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' pnlEmpCard
        ' 
        pnlEmpCard.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlEmpCard.Controls.Add(pnlContractBadge)
        pnlEmpCard.Controls.Add(lblEmpDept)
        pnlEmpCard.Controls.Add(lblEmpMeta)
        pnlEmpCard.Controls.Add(lblEmpName)
        pnlEmpCard.Controls.Add(pnlEmpAvatar)
        pnlEmpCard.Dock = DockStyle.Top
        pnlEmpCard.Location = New Point(0, 0)
        pnlEmpCard.Name = "pnlEmpCard"
        pnlEmpCard.Padding = New Padding(16, 14, 16, 14)
        pnlEmpCard.Size = New Size(341, 96)
        pnlEmpCard.TabIndex = 2
        ' 
        ' pnlContractBadge
        ' 
        pnlContractBadge.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlContractBadge.BackColor = Color.Transparent
        pnlContractBadge.Controls.Add(lblBadgeDaysLeft)
        pnlContractBadge.Controls.Add(lblBadgeStatus)
        pnlContractBadge.Location = New Point(400, 18)
        pnlContractBadge.Name = "pnlContractBadge"
        pnlContractBadge.Size = New Size(200, 60)
        pnlContractBadge.TabIndex = 0
        ' 
        ' lblBadgeDaysLeft
        ' 
        lblBadgeDaysLeft.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblBadgeDaysLeft.AutoSize = True
        lblBadgeDaysLeft.Font = New Font("Microsoft YaHei UI", 9F)
        lblBadgeDaysLeft.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblBadgeDaysLeft.Location = New Point(0, 30)
        lblBadgeDaysLeft.Name = "lblBadgeDaysLeft"
        lblBadgeDaysLeft.Size = New Size(0, 20)
        lblBadgeDaysLeft.TabIndex = 0
        ' 
        ' lblBadgeStatus
        ' 
        lblBadgeStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblBadgeStatus.AutoSize = True
        lblBadgeStatus.BackColor = Color.FromArgb(CByte(20), CByte(123), CByte(139), CByte(178))
        lblBadgeStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblBadgeStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblBadgeStatus.Location = New Point(0, 0)
        lblBadgeStatus.Name = "lblBadgeStatus"
        lblBadgeStatus.Padding = New Padding(8, 3, 8, 3)
        lblBadgeStatus.Size = New Size(67, 25)
        lblBadgeStatus.TabIndex = 1
        lblBadgeStatus.Text = "○ Mới"
        ' 
        ' lblEmpDept
        ' 
        lblEmpDept.AutoSize = True
        lblEmpDept.Font = New Font("Microsoft YaHei UI", 9F)
        lblEmpDept.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblEmpDept.Location = New Point(88, 62)
        lblEmpDept.Name = "lblEmpDept"
        lblEmpDept.Size = New Size(25, 20)
        lblEmpDept.TabIndex = 1
        lblEmpDept.Text = "—"
        ' 
        ' lblEmpMeta
        ' 
        lblEmpMeta.AutoSize = True
        lblEmpMeta.Font = New Font("Courier New", 9F)
        lblEmpMeta.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblEmpMeta.Location = New Point(88, 44)
        lblEmpMeta.Name = "lblEmpMeta"
        lblEmpMeta.Size = New Size(17, 17)
        lblEmpMeta.TabIndex = 2
        lblEmpMeta.Text = "—"
        ' 
        ' lblEmpName
        ' 
        lblEmpName.AutoSize = True
        lblEmpName.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblEmpName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblEmpName.Location = New Point(86, 16)
        lblEmpName.Name = "lblEmpName"
        lblEmpName.Size = New Size(185, 30)
        lblEmpName.TabIndex = 3
        lblEmpName.Text = "Chọn nhân viên"
        ' 
        ' pnlEmpAvatar
        ' 
        pnlEmpAvatar.BackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        pnlEmpAvatar.Location = New Point(16, 18)
        pnlEmpAvatar.Name = "pnlEmpAvatar"
        pnlEmpAvatar.Size = New Size(60, 60)
        pnlEmpAvatar.TabIndex = 4
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(640, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 501)
        splitter.TabIndex = 1
        splitter.TabStop = False
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(dgvContract)
        pnlLeft.Controls.Add(pnlLeftFooter)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(640, 501)
        pnlLeft.TabIndex = 2
        ' 
        ' dgvContract
        ' 
        dgvContract.AllowUserToAddRows = False
        dgvContract.AllowUserToDeleteRows = False
        dgvContract.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvContract.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvContract.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvContract.BorderStyle = BorderStyle.None
        dgvContract.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvContract.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(4, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvContract.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvContract.ColumnHeadersHeight = 40
        dgvContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvContract.Columns.AddRange(New DataGridViewColumn() {colAvatar, colEmpName, colCode, colStartDate, colEndDate, colBaseSalary, colStatus, colDaysLeft})
        dgvContract.Cursor = Cursors.Hand
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle9.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle9.Padding = New Padding(4, 0, 0, 0)
        DataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.False
        dgvContract.DefaultCellStyle = DataGridViewCellStyle9
        dgvContract.Dock = DockStyle.Fill
        dgvContract.EnableHeadersVisualStyles = False
        dgvContract.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvContract.Location = New Point(0, 0)
        dgvContract.MultiSelect = False
        dgvContract.Name = "dgvContract"
        dgvContract.ReadOnly = True
        dgvContract.RowHeadersVisible = False
        dgvContract.RowHeadersWidth = 51
        dgvContract.RowTemplate.Height = 52
        dgvContract.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvContract.Size = New Size(640, 461)
        dgvContract.TabIndex = 0
        ' 
        ' colAvatar
        ' 
        colAvatar.HeaderText = ""
        colAvatar.MinimumWidth = 6
        colAvatar.Name = "colAvatar"
        colAvatar.ReadOnly = True
        colAvatar.Resizable = DataGridViewTriState.False
        colAvatar.Width = 52
        ' 
        ' colEmpName
        ' 
        colEmpName.HeaderText = "NHÂN VIÊN"
        colEmpName.MinimumWidth = 6
        colEmpName.Name = "colEmpName"
        colEmpName.ReadOnly = True
        colEmpName.Width = 170
        ' 
        ' colCode
        ' 
        DataGridViewCellStyle3.Font = New Font("Courier New", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colCode.DefaultCellStyle = DataGridViewCellStyle3
        colCode.HeaderText = "MÃ HĐ"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 110
        ' 
        ' colStartDate
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colStartDate.DefaultCellStyle = DataGridViewCellStyle4
        colStartDate.HeaderText = "BẮT ĐẦU"
        colStartDate.MinimumWidth = 6
        colStartDate.Name = "colStartDate"
        colStartDate.ReadOnly = True
        colStartDate.Width = 88
        ' 
        ' colEndDate
        ' 
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colEndDate.DefaultCellStyle = DataGridViewCellStyle5
        colEndDate.HeaderText = "KẾT THÚC"
        colEndDate.MinimumWidth = 6
        colEndDate.Name = "colEndDate"
        colEndDate.ReadOnly = True
        colEndDate.Width = 88
        ' 
        ' colBaseSalary
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        colBaseSalary.DefaultCellStyle = DataGridViewCellStyle6
        colBaseSalary.HeaderText = "LƯƠNG CB"
        colBaseSalary.MinimumWidth = 6
        colBaseSalary.Name = "colBaseSalary"
        colBaseSalary.ReadOnly = True
        colBaseSalary.Width = 110
        ' 
        ' colStatus
        ' 
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStatus.DefaultCellStyle = DataGridViewCellStyle7
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 128
        ' 
        ' colDaysLeft
        ' 
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        colDaysLeft.DefaultCellStyle = DataGridViewCellStyle8
        colDaysLeft.HeaderText = "CÒN LẠI"
        colDaysLeft.MinimumWidth = 6
        colDaysLeft.Name = "colDaysLeft"
        colDaysLeft.ReadOnly = True
        colDaysLeft.Width = 80
        ' 
        ' pnlLeftFooter
        ' 
        pnlLeftFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlLeftFooter.Controls.Add(pnlPageBtns)
        pnlLeftFooter.Controls.Add(lblRowInfo)
        pnlLeftFooter.Dock = DockStyle.Bottom
        pnlLeftFooter.Location = New Point(0, 461)
        pnlLeftFooter.Name = "pnlLeftFooter"
        pnlLeftFooter.Size = New Size(640, 40)
        pnlLeftFooter.TabIndex = 1
        ' 
        ' pnlPageBtns
        ' 
        pnlPageBtns.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlPageBtns.BackColor = Color.Transparent
        pnlPageBtns.Controls.Add(btnPageNext)
        pnlPageBtns.Controls.Add(btnPage2)
        pnlPageBtns.Controls.Add(btnPage1)
        pnlPageBtns.Controls.Add(btnPagePrev)
        pnlPageBtns.Location = New Point(930, 5)
        pnlPageBtns.Name = "pnlPageBtns"
        pnlPageBtns.Size = New Size(136, 30)
        pnlPageBtns.TabIndex = 0
        ' 
        ' btnPageNext
        ' 
        btnPageNext.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPageNext.Cursor = Cursors.Hand
        btnPageNext.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPageNext.FlatStyle = FlatStyle.Flat
        btnPageNext.Font = New Font("Microsoft YaHei UI", 9F)
        btnPageNext.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPageNext.Location = New Point(102, 0)
        btnPageNext.Name = "btnPageNext"
        btnPageNext.Size = New Size(30, 30)
        btnPageNext.TabIndex = 0
        btnPageNext.Text = "›"
        btnPageNext.UseVisualStyleBackColor = False
        ' 
        ' btnPage2
        ' 
        btnPage2.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPage2.Cursor = Cursors.Hand
        btnPage2.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPage2.FlatStyle = FlatStyle.Flat
        btnPage2.Font = New Font("Microsoft YaHei UI", 9F)
        btnPage2.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPage2.Location = New Point(68, 0)
        btnPage2.Name = "btnPage2"
        btnPage2.Size = New Size(30, 30)
        btnPage2.TabIndex = 1
        btnPage2.Text = "2"
        btnPage2.UseVisualStyleBackColor = False
        ' 
        ' btnPage1
        ' 
        btnPage1.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnPage1.Cursor = Cursors.Hand
        btnPage1.FlatAppearance.BorderSize = 0
        btnPage1.FlatStyle = FlatStyle.Flat
        btnPage1.Font = New Font("Microsoft YaHei UI", 9F)
        btnPage1.ForeColor = Color.White
        btnPage1.Location = New Point(34, 0)
        btnPage1.Name = "btnPage1"
        btnPage1.Size = New Size(30, 30)
        btnPage1.TabIndex = 2
        btnPage1.Text = "1"
        btnPage1.UseVisualStyleBackColor = False
        ' 
        ' btnPagePrev
        ' 
        btnPagePrev.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPagePrev.Cursor = Cursors.Hand
        btnPagePrev.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPagePrev.FlatStyle = FlatStyle.Flat
        btnPagePrev.Font = New Font("Microsoft YaHei UI", 9F)
        btnPagePrev.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPagePrev.Location = New Point(0, 0)
        btnPagePrev.Name = "btnPagePrev"
        btnPagePrev.Size = New Size(30, 30)
        btnPagePrev.TabIndex = 3
        btnPagePrev.Text = "‹"
        btnPagePrev.UseVisualStyleBackColor = False
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 12)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(92, 20)
        lblRowInfo.TabIndex = 1
        lblRowInfo.Text = "0 hợp đồng"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(cboStatusFilter)
        pnlToolbar.Controls.Add(cboDept)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(982, 52)
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
        btnAdd.Location = New Point(1862, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(180, 30)
        btnAdd.TabIndex = 3
        btnAdd.Text = "+ Thêm hợp đồng"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang hiệu lực", "Hết hạn trong 30 ngày", "Đã hết hạn", "Đã hủy"})
        cboStatusFilter.Location = New Point(422, 11)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(190, 28)
        cboStatusFilter.TabIndex = 2
        ' 
        ' cboDept
        ' 
        cboDept.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDept.DropDownStyle = ComboBoxStyle.DropDownList
        cboDept.FlatStyle = FlatStyle.Flat
        cboDept.Font = New Font("Microsoft YaHei UI", 9F)
        cboDept.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDept.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        cboDept.Location = New Point(252, 11)
        cboDept.Name = "cboDept"
        cboDept.Size = New Size(160, 28)
        cboDept.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Microsoft YaHei UI", 10F)
        txtSearch.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtSearch.Location = New Point(12, 11)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(230, 28)
        txtSearch.TabIndex = 0
        ' 
        ' formContract
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(982, 553)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1000, 600)
        Name = "formContract"
        Text = "Quản lý hợp đồng"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlFormScroll.ResumeLayout(False)
        pnlSec4.ResumeLayout(False)
        pnlSec4.PerformLayout()
        pnlSec3.ResumeLayout(False)
        pnlSec3.PerformLayout()
        tlpSec3.ResumeLayout(False)
        tlpSec3.PerformLayout()
        pnlSec2.ResumeLayout(False)
        pnlSec2.PerformLayout()
        tlpSec2.ResumeLayout(False)
        tlpSec2.PerformLayout()
        pnlEndDateRow.ResumeLayout(False)
        pnlEndDateRow.PerformLayout()
        pnlSec1.ResumeLayout(False)
        pnlSec1.PerformLayout()
        tlpSec1.ResumeLayout(False)
        tlpSec1.PerformLayout()
        pnlRightFooter.ResumeLayout(False)
        pnlEmpCard.ResumeLayout(False)
        pnlEmpCard.PerformLayout()
        pnlContractBadge.ResumeLayout(False)
        pnlContractBadge.PerformLayout()
        pnlLeft.ResumeLayout(False)
        CType(dgvContract, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftFooter.ResumeLayout(False)
        pnlLeftFooter.PerformLayout()
        pnlPageBtns.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' ── Declarations ──────────────────────────────────────────
    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvContract As System.Windows.Forms.DataGridView
    Friend WithEvents colAvatar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBaseSalary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDaysLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLeftFooter As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents pnlPageBtns As System.Windows.Forms.Panel
    Friend WithEvents btnPagePrev As System.Windows.Forms.Button
    Friend WithEvents btnPage1 As System.Windows.Forms.Button
    Friend WithEvents btnPage2 As System.Windows.Forms.Button
    Friend WithEvents btnPageNext As System.Windows.Forms.Button
    Friend WithEvents splitter As System.Windows.Forms.Splitter
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpCard As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpAvatar As System.Windows.Forms.Panel
    Friend WithEvents lblEmpName As System.Windows.Forms.Label
    Friend WithEvents lblEmpMeta As System.Windows.Forms.Label
    Friend WithEvents lblEmpDept As System.Windows.Forms.Label
    Friend WithEvents pnlContractBadge As System.Windows.Forms.Panel
    Friend WithEvents lblBadgeStatus As System.Windows.Forms.Label
    Friend WithEvents lblBadgeDaysLeft As System.Windows.Forms.Label
    Friend WithEvents pnlFormScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1Title As System.Windows.Forms.Label
    Friend WithEvents tlpSec1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCode As System.Windows.Forms.Label
    Friend WithEvents txtFCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFEmp As System.Windows.Forms.Label
    Friend WithEvents cboFEmp As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSec2 As System.Windows.Forms.Panel
    Friend WithEvents lblSec2Title As System.Windows.Forms.Label
    Friend WithEvents tlpSec2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFStart As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFEnd As System.Windows.Forms.Label
    Friend WithEvents pnlEndDateRow As System.Windows.Forms.Panel
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNoEndDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblFDuration As System.Windows.Forms.Label
    Friend WithEvents lblDurationVal As System.Windows.Forms.Label
    Friend WithEvents pnlSec3 As System.Windows.Forms.Panel
    Friend WithEvents lblSec3Title As System.Windows.Forms.Label
    Friend WithEvents tlpSec3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFBaseSalary As System.Windows.Forms.Label
    Friend WithEvents txtFBaseSalary As System.Windows.Forms.TextBox
    Friend WithEvents lblFBaseSalaryHint As System.Windows.Forms.Label
    Friend WithEvents lblFSalaryPreview As System.Windows.Forms.Label
    Friend WithEvents lblSalaryPreviewVal As System.Windows.Forms.Label
    Friend WithEvents pnlSec4 As System.Windows.Forms.Panel
    Friend WithEvents lblSec4Title As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlRightFooter As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button

End Class