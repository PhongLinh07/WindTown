<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formPayPeriod
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
        pnlSec3 = New Panel()
        txtFNote = New TextBox()
        lblSec3Title = New Label()
        pnlSec2 = New Panel()
        tlpSec2 = New TableLayoutPanel()
        lblFStart = New Label()
        dtpStart = New DateTimePicker()
        lblFEnd = New Label()
        dtpEnd = New DateTimePicker()
        lblFStdHours = New Label()
        txtFStdHours = New TextBox()
        lblFStdHoursHint = New Label()
        lblSec2Title = New Label()
        pnlSec1 = New Panel()
        tlpSec1 = New TableLayoutPanel()
        lblFCode = New Label()
        txtFCode = New TextBox()
        lblFName = New Label()
        txtFName = New TextBox()
        lblFMonth = New Label()
        dtpMonth = New DateTimePicker()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
        lblSec1Title = New Label()
        pnlRightFooter = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        btnClose = New Button()
        btnDelete = New Button()
        pnlRightHeader = New Panel()
        pnlKpiRow = New Panel()
        pnlKpi3 = New Panel()
        lblKpi3Val = New Label()
        lblKpi3Title = New Label()
        pnlKpi2 = New Panel()
        lblKpi2Val = New Label()
        lblKpi2Title = New Label()
        pnlKpi1 = New Panel()
        lblKpi1Val = New Label()
        lblKpi1Title = New Label()
        lblRightBadge = New Label()
        lblRightSub = New Label()
        lblRightTitle = New Label()
        pnlRightHdrIcon = New Panel()
        splitter = New Splitter()
        pnlLeft = New Panel()
        dgvPeriod = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colMonth = New DataGridViewTextBoxColumn()
        colStartDate = New DataGridViewTextBoxColumn()
        colEndDate = New DataGridViewTextBoxColumn()
        colStdHours = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlLeftFooter = New Panel()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        cboStatusFilter = New ComboBox()
        txtSearch = New TextBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlFormScroll.SuspendLayout()
        pnlSec3.SuspendLayout()
        pnlSec2.SuspendLayout()
        tlpSec2.SuspendLayout()
        pnlSec1.SuspendLayout()
        tlpSec1.SuspendLayout()
        pnlRightFooter.SuspendLayout()
        pnlRightHeader.SuspendLayout()
        pnlKpiRow.SuspendLayout()
        pnlKpi3.SuspendLayout()
        pnlKpi2.SuspendLayout()
        pnlKpi1.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(dgvPeriod, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftFooter.SuspendLayout()
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
        pnlRoot.Size = New Size(1135, 798)
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
        pnlContent.Size = New Size(1135, 746)
        pnlContent.TabIndex = 0
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlFormScroll)
        pnlRight.Controls.Add(pnlRightFooter)
        pnlRight.Controls.Add(pnlRightHeader)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(561, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(574, 746)
        pnlRight.TabIndex = 0
        ' 
        ' pnlFormScroll
        ' 
        pnlFormScroll.AutoScroll = True
        pnlFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFormScroll.Controls.Add(pnlSec3)
        pnlFormScroll.Controls.Add(pnlSec2)
        pnlFormScroll.Controls.Add(pnlSec1)
        pnlFormScroll.Dock = DockStyle.Fill
        pnlFormScroll.Location = New Point(0, 148)
        pnlFormScroll.Name = "pnlFormScroll"
        pnlFormScroll.Padding = New Padding(16, 14, 16, 14)
        pnlFormScroll.Size = New Size(574, 546)
        pnlFormScroll.TabIndex = 0
        ' 
        ' pnlSec3
        ' 
        pnlSec3.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec3.Controls.Add(txtFNote)
        pnlSec3.Controls.Add(lblSec3Title)
        pnlSec3.Dock = DockStyle.Top
        pnlSec3.Location = New Point(16, 375)
        pnlSec3.Margin = New Padding(0, 10, 0, 0)
        pnlSec3.Name = "pnlSec3"
        pnlSec3.Padding = New Padding(16, 12, 16, 12)
        pnlSec3.Size = New Size(542, 116)
        pnlSec3.TabIndex = 0
        ' 
        ' txtFNote
        ' 
        txtFNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFNote.BorderStyle = BorderStyle.FixedSingle
        txtFNote.Dock = DockStyle.Bottom
        txtFNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtFNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFNote.Location = New Point(16, 36)
        txtFNote.Multiline = True
        txtFNote.Name = "txtFNote"
        txtFNote.ScrollBars = ScrollBars.Vertical
        txtFNote.Size = New Size(510, 68)
        txtFNote.TabIndex = 7
        ' 
        ' lblSec3Title
        ' 
        lblSec3Title.AutoSize = True
        lblSec3Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec3Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec3Title.Location = New Point(16, 12)
        lblSec3Title.Name = "lblSec3Title"
        lblSec3Title.Size = New Size(73, 19)
        lblSec3Title.TabIndex = 8
        lblSec3Title.Text = "GHI CHÚ"
        ' 
        ' pnlSec2
        ' 
        pnlSec2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSec2.Controls.Add(tlpSec2)
        pnlSec2.Controls.Add(lblSec2Title)
        pnlSec2.Dock = DockStyle.Top
        pnlSec2.Location = New Point(16, 182)
        pnlSec2.Margin = New Padding(0, 10, 0, 10)
        pnlSec2.Name = "pnlSec2"
        pnlSec2.Padding = New Padding(16, 12, 16, 12)
        pnlSec2.Size = New Size(542, 193)
        pnlSec2.TabIndex = 1
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
        tlpSec2.Controls.Add(dtpEnd, 1, 1)
        tlpSec2.Controls.Add(lblFStdHours, 0, 2)
        tlpSec2.Controls.Add(txtFStdHours, 0, 3)
        tlpSec2.Controls.Add(lblFStdHoursHint, 1, 3)
        tlpSec2.Dock = DockStyle.Top
        tlpSec2.Location = New Point(16, 31)
        tlpSec2.Name = "tlpSec2"
        tlpSec2.RowCount = 4
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec2.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec2.Size = New Size(510, 150)
        tlpSec2.TabIndex = 0
        ' 
        ' lblFStart
        ' 
        lblFStart.AutoSize = True
        lblFStart.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStart.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStart.Location = New Point(3, 0)
        lblFStart.Name = "lblFStart"
        lblFStart.Size = New Size(127, 19)
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
        dtpStart.Size = New Size(247, 28)
        dtpStart.TabIndex = 4
        ' 
        ' lblFEnd
        ' 
        lblFEnd.AutoSize = True
        lblFEnd.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFEnd.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFEnd.Location = New Point(263, 0)
        lblFEnd.Margin = New Padding(8, 0, 0, 0)
        lblFEnd.Name = "lblFEnd"
        lblFEnd.Size = New Size(131, 19)
        lblFEnd.TabIndex = 5
        lblFEnd.Text = "Ngày kết thúc  *"
        ' 
        ' dtpEnd
        ' 
        dtpEnd.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpEnd.CalendarMonthBackground = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dtpEnd.CalendarTitleBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        dtpEnd.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        dtpEnd.CustomFormat = "dd/MM/yyyy"
        dtpEnd.Dock = DockStyle.Fill
        dtpEnd.Font = New Font("Microsoft YaHei UI", 10F)
        dtpEnd.Format = DateTimePickerFormat.Custom
        dtpEnd.Location = New Point(263, 22)
        dtpEnd.Margin = New Padding(8, 0, 0, 4)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(247, 28)
        dtpEnd.TabIndex = 5
        ' 
        ' lblFStdHours
        ' 
        lblFStdHours.AutoSize = True
        tlpSec2.SetColumnSpan(lblFStdHours, 2)
        lblFStdHours.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStdHours.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStdHours.Location = New Point(3, 64)
        lblFStdHours.Name = "lblFStdHours"
        lblFStdHours.Size = New Size(278, 19)
        lblFStdHours.TabIndex = 6
        lblFStdHours.Text = "Giờ làm chuẩn trong kỳ  (std_hours)"
        ' 
        ' txtFStdHours
        ' 
        txtFStdHours.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFStdHours.BorderStyle = BorderStyle.FixedSingle
        txtFStdHours.Dock = DockStyle.Fill
        txtFStdHours.Font = New Font("Microsoft YaHei UI", 10F)
        txtFStdHours.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFStdHours.Location = New Point(0, 86)
        txtFStdHours.Margin = New Padding(0, 0, 8, 4)
        txtFStdHours.Name = "txtFStdHours"
        txtFStdHours.Size = New Size(247, 28)
        txtFStdHours.TabIndex = 6
        txtFStdHours.Text = "176"
        ' 
        ' lblFStdHoursHint
        ' 
        lblFStdHoursHint.AutoSize = True
        lblFStdHoursHint.Font = New Font("Microsoft YaHei UI", 9F)
        lblFStdHoursHint.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblFStdHoursHint.Location = New Point(263, 98)
        lblFStdHoursHint.Margin = New Padding(8, 12, 0, 0)
        lblFStdHoursHint.Name = "lblFStdHoursHint"
        lblFStdHoursHint.Size = New Size(231, 40)
        lblFStdHoursHint.TabIndex = 7
        lblFStdHoursHint.Text = "Thường = số ngày làm việc × 8 giờ"
        ' 
        ' lblSec2Title
        ' 
        lblSec2Title.AutoSize = True
        lblSec2Title.Dock = DockStyle.Top
        lblSec2Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec2Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec2Title.Location = New Point(16, 12)
        lblSec2Title.Name = "lblSec2Title"
        lblSec2Title.Size = New Size(184, 19)
        lblSec2Title.TabIndex = 1
        lblSec2Title.Text = "THỜI GIAN & GIỜ CHUẨN"
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
        pnlSec1.Size = New Size(542, 168)
        pnlSec1.TabIndex = 2
        ' 
        ' tlpSec1
        ' 
        tlpSec1.BackColor = Color.Transparent
        tlpSec1.ColumnCount = 2
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpSec1.Controls.Add(lblFCode, 0, 0)
        tlpSec1.Controls.Add(txtFCode, 0, 1)
        tlpSec1.Controls.Add(lblFName, 1, 0)
        tlpSec1.Controls.Add(txtFName, 1, 1)
        tlpSec1.Controls.Add(lblFMonth, 0, 2)
        tlpSec1.Controls.Add(dtpMonth, 0, 3)
        tlpSec1.Controls.Add(lblFStatus, 1, 2)
        tlpSec1.Controls.Add(cboFStatus, 1, 3)
        tlpSec1.Dock = DockStyle.Fill
        tlpSec1.Location = New Point(16, 12)
        tlpSec1.Name = "tlpSec1"
        tlpSec1.RowCount = 4
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpSec1.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpSec1.Size = New Size(510, 144)
        tlpSec1.TabIndex = 0
        ' 
        ' lblFCode
        ' 
        lblFCode.AutoSize = True
        lblFCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFCode.Location = New Point(3, 0)
        lblFCode.Name = "lblFCode"
        lblFCode.Size = New Size(117, 19)
        lblFCode.TabIndex = 0
        lblFCode.Text = "Mã kỳ lương  *"
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
        txtFCode.Size = New Size(247, 26)
        txtFCode.TabIndex = 0
        ' 
        ' lblFName
        ' 
        lblFName.AutoSize = True
        lblFName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFName.Location = New Point(263, 0)
        lblFName.Margin = New Padding(8, 0, 0, 0)
        lblFName.Name = "lblFName"
        lblFName.Size = New Size(121, 19)
        lblFName.TabIndex = 1
        lblFName.Text = "Tên kỳ lương  *"
        ' 
        ' txtFName
        ' 
        txtFName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFName.BorderStyle = BorderStyle.FixedSingle
        txtFName.Dock = DockStyle.Fill
        txtFName.Font = New Font("Microsoft YaHei UI", 10F)
        txtFName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFName.Location = New Point(263, 22)
        txtFName.Margin = New Padding(8, 0, 0, 4)
        txtFName.Name = "txtFName"
        txtFName.Size = New Size(247, 28)
        txtFName.TabIndex = 1
        ' 
        ' lblFMonth
        ' 
        lblFMonth.AutoSize = True
        lblFMonth.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFMonth.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFMonth.Location = New Point(3, 64)
        lblFMonth.Name = "lblFMonth"
        lblFMonth.Size = New Size(138, 19)
        lblFMonth.TabIndex = 2
        lblFMonth.Text = "Tháng tính lương"
        ' 
        ' dtpMonth
        ' 
        dtpMonth.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpMonth.CalendarMonthBackground = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dtpMonth.CalendarTitleBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        dtpMonth.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        dtpMonth.CustomFormat = "MM/yyyy"
        dtpMonth.Dock = DockStyle.Fill
        dtpMonth.Font = New Font("Microsoft YaHei UI", 10F)
        dtpMonth.Format = DateTimePickerFormat.Custom
        dtpMonth.Location = New Point(0, 86)
        dtpMonth.Margin = New Padding(0, 0, 8, 4)
        dtpMonth.Name = "dtpMonth"
        dtpMonth.Size = New Size(247, 28)
        dtpMonth.TabIndex = 2
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(263, 64)
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
        cboFStatus.Items.AddRange(New Object() {"Nháp", "Đang xử lý", "Đã chốt"})
        cboFStatus.Location = New Point(263, 90)
        cboFStatus.Margin = New Padding(8, 4, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(247, 29)
        cboFStatus.TabIndex = 3
        ' 
        ' lblSec1Title
        ' 
        lblSec1Title.AutoSize = True
        lblSec1Title.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSec1Title.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1Title.Location = New Point(16, 12)
        lblSec1Title.Name = "lblSec1Title"
        lblSec1Title.Size = New Size(175, 19)
        lblSec1Title.TabIndex = 1
        lblSec1Title.Text = "THÔNG TIN KỲ LƯƠNG"
        ' 
        ' pnlRightFooter
        ' 
        pnlRightFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlRightFooter.Controls.Add(btnSave)
        pnlRightFooter.Controls.Add(btnClear)
        pnlRightFooter.Controls.Add(btnClose)
        pnlRightFooter.Controls.Add(btnDelete)
        pnlRightFooter.Dock = DockStyle.Bottom
        pnlRightFooter.Location = New Point(0, 694)
        pnlRightFooter.Name = "pnlRightFooter"
        pnlRightFooter.Size = New Size(574, 52)
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
        btnSave.Location = New Point(1113, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(160, 32)
        btnSave.TabIndex = 3
        btnSave.Text = "Lưu kỳ lương"
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
        btnClear.Location = New Point(1003, 10)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 32)
        btnClear.TabIndex = 2
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(30), CByte(245), CByte(158), CByte(11))
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(245), CByte(158), CByte(11))
        btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(245), CByte(158), CByte(11))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        btnClose.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        btnClose.Location = New Point(853, 10)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(140, 32)
        btnClose.TabIndex = 1
        btnClose.Text = "Chốt kỳ lương"
        btnClose.UseVisualStyleBackColor = False
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
        btnDelete.Text = "Xóa kỳ lương"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' pnlRightHeader
        ' 
        pnlRightHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlRightHeader.Controls.Add(pnlKpiRow)
        pnlRightHeader.Controls.Add(lblRightBadge)
        pnlRightHeader.Controls.Add(lblRightSub)
        pnlRightHeader.Controls.Add(lblRightTitle)
        pnlRightHeader.Controls.Add(pnlRightHdrIcon)
        pnlRightHeader.Dock = DockStyle.Top
        pnlRightHeader.Location = New Point(0, 0)
        pnlRightHeader.Name = "pnlRightHeader"
        pnlRightHeader.Padding = New Padding(16, 14, 16, 10)
        pnlRightHeader.Size = New Size(574, 148)
        pnlRightHeader.TabIndex = 2
        ' 
        ' pnlKpiRow
        ' 
        pnlKpiRow.BackColor = Color.Transparent
        pnlKpiRow.Controls.Add(pnlKpi3)
        pnlKpiRow.Controls.Add(pnlKpi2)
        pnlKpiRow.Controls.Add(pnlKpi1)
        pnlKpiRow.Dock = DockStyle.Bottom
        pnlKpiRow.Location = New Point(16, 76)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New Size(542, 62)
        pnlKpiRow.TabIndex = 0
        ' 
        ' pnlKpi3
        ' 
        pnlKpi3.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi3.Controls.Add(lblKpi3Val)
        pnlKpi3.Controls.Add(lblKpi3Title)
        pnlKpi3.Location = New Point(336, 0)
        pnlKpi3.Name = "pnlKpi3"
        pnlKpi3.Padding = New Padding(12, 6, 12, 6)
        pnlKpi3.Size = New Size(200, 58)
        pnlKpi3.TabIndex = 0
        ' 
        ' lblKpi3Val
        ' 
        lblKpi3Val.AutoSize = True
        lblKpi3Val.Font = New Font("Microsoft YaHei UI", 15F, FontStyle.Bold)
        lblKpi3Val.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblKpi3Val.Location = New Point(10, 24)
        lblKpi3Val.Name = "lblKpi3Val"
        lblKpi3Val.Size = New Size(42, 33)
        lblKpi3Val.TabIndex = 0
        lblKpi3Val.Text = "—"
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi3Title.Location = New Point(12, 6)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New Size(133, 19)
        lblKpi3Title.TabIndex = 1
        lblKpi3Title.Text = "THỜI HẠN CÒN LẠI"
        ' 
        ' pnlKpi2
        ' 
        pnlKpi2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi2.Controls.Add(lblKpi2Val)
        pnlKpi2.Controls.Add(lblKpi2Title)
        pnlKpi2.Location = New Point(168, 0)
        pnlKpi2.Name = "pnlKpi2"
        pnlKpi2.Padding = New Padding(12, 6, 12, 6)
        pnlKpi2.Size = New Size(160, 58)
        pnlKpi2.TabIndex = 1
        ' 
        ' lblKpi2Val
        ' 
        lblKpi2Val.AutoSize = True
        lblKpi2Val.Font = New Font("Microsoft YaHei UI", 15F, FontStyle.Bold)
        lblKpi2Val.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblKpi2Val.Location = New Point(10, 24)
        lblKpi2Val.Name = "lblKpi2Val"
        lblKpi2Val.Size = New Size(42, 33)
        lblKpi2Val.TabIndex = 0
        lblKpi2Val.Text = "—"
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi2Title.Location = New Point(12, 6)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New Size(86, 19)
        lblKpi2Title.TabIndex = 1
        lblKpi2Title.Text = "GIỜ CHUẨN"
        ' 
        ' pnlKpi1
        ' 
        pnlKpi1.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi1.Controls.Add(lblKpi1Val)
        pnlKpi1.Controls.Add(lblKpi1Title)
        pnlKpi1.Location = New Point(0, 0)
        pnlKpi1.Name = "pnlKpi1"
        pnlKpi1.Padding = New Padding(12, 6, 12, 6)
        pnlKpi1.Size = New Size(160, 58)
        pnlKpi1.TabIndex = 2
        ' 
        ' lblKpi1Val
        ' 
        lblKpi1Val.AutoSize = True
        lblKpi1Val.Font = New Font("Microsoft YaHei UI", 15F, FontStyle.Bold)
        lblKpi1Val.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi1Val.Location = New Point(10, 24)
        lblKpi1Val.Name = "lblKpi1Val"
        lblKpi1Val.Size = New Size(42, 33)
        lblKpi1Val.TabIndex = 0
        lblKpi1Val.Text = "—"
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi1Title.Location = New Point(12, 6)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New Size(137, 19)
        lblKpi1Title.TabIndex = 1
        lblKpi1Title.Text = "SỐ NGÀY LÀM VIỆC"
        ' 
        ' lblRightBadge
        ' 
        lblRightBadge.AutoSize = True
        lblRightBadge.BackColor = Color.FromArgb(CByte(20), CByte(123), CByte(139), CByte(178))
        lblRightBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblRightBadge.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRightBadge.Location = New Point(263, 42)
        lblRightBadge.MaximumSize = New Size(73, 24)
        lblRightBadge.MinimumSize = New Size(73, 24)
        lblRightBadge.Name = "lblRightBadge"
        lblRightBadge.Padding = New Padding(6, 2, 6, 2)
        lblRightBadge.Size = New Size(73, 24)
        lblRightBadge.TabIndex = 1
        lblRightBadge.Text = "Nháp"
        ' 
        ' lblRightSub
        ' 
        lblRightSub.AutoSize = True
        lblRightSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblRightSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRightSub.Location = New Point(78, 44)
        lblRightSub.Name = "lblRightSub"
        lblRightSub.Size = New Size(179, 20)
        lblRightSub.TabIndex = 2
        lblRightSub.Text = "Điền thông tin bên dưới"
        ' 
        ' lblRightTitle
        ' 
        lblRightTitle.AutoSize = True
        lblRightTitle.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblRightTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblRightTitle.Location = New Point(76, 14)
        lblRightTitle.Name = "lblRightTitle"
        lblRightTitle.Size = New Size(224, 31)
        lblRightTitle.TabIndex = 3
        lblRightTitle.Text = "Tạo kỳ lương mới"
        ' 
        ' pnlRightHdrIcon
        ' 
        pnlRightHdrIcon.BackColor = Color.FromArgb(CByte(15), CByte(74), CByte(158), CByte(255))
        pnlRightHdrIcon.Location = New Point(16, 14)
        pnlRightHdrIcon.Name = "pnlRightHdrIcon"
        pnlRightHdrIcon.Size = New Size(52, 52)
        pnlRightHdrIcon.TabIndex = 4
        ' 
        ' splitter
        ' 
        splitter.BackColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        splitter.Location = New Point(560, 0)
        splitter.Name = "splitter"
        splitter.Size = New Size(1, 746)
        splitter.TabIndex = 1
        splitter.TabStop = False
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(dgvPeriod)
        pnlLeft.Controls.Add(pnlLeftFooter)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(560, 746)
        pnlLeft.TabIndex = 2
        ' 
        ' dgvPeriod
        ' 
        dgvPeriod.AllowUserToAddRows = False
        dgvPeriod.AllowUserToDeleteRows = False
        dgvPeriod.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvPeriod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvPeriod.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvPeriod.BorderStyle = BorderStyle.None
        dgvPeriod.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvPeriod.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvPeriod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvPeriod.ColumnHeadersHeight = 40
        dgvPeriod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvPeriod.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colMonth, colStartDate, colEndDate, colStdHours, colStatus})
        dgvPeriod.Cursor = Cursors.Hand
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle9.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle9.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.False
        dgvPeriod.DefaultCellStyle = DataGridViewCellStyle9
        dgvPeriod.Dock = DockStyle.Fill
        dgvPeriod.EnableHeadersVisualStyles = False
        dgvPeriod.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvPeriod.Location = New Point(0, 0)
        dgvPeriod.MultiSelect = False
        dgvPeriod.Name = "dgvPeriod"
        dgvPeriod.ReadOnly = True
        dgvPeriod.RowHeadersVisible = False
        dgvPeriod.RowHeadersWidth = 51
        dgvPeriod.RowTemplate.Height = 48
        dgvPeriod.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPeriod.Size = New Size(560, 710)
        dgvPeriod.TabIndex = 0
        ' 
        ' colCode
        ' 
        DataGridViewCellStyle3.Font = New Font("Courier New", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colCode.DefaultCellStyle = DataGridViewCellStyle3
        colCode.HeaderText = "MÃ KỲ"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 110
        ' 
        ' colName
        ' 
        colName.HeaderText = "TÊN KỲ LƯƠNG"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 180
        ' 
        ' colMonth
        ' 
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colMonth.DefaultCellStyle = DataGridViewCellStyle4
        colMonth.HeaderText = "THÁNG"
        colMonth.MinimumWidth = 6
        colMonth.Name = "colMonth"
        colMonth.ReadOnly = True
        colMonth.Width = 70
        ' 
        ' colStartDate
        ' 
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colStartDate.DefaultCellStyle = DataGridViewCellStyle5
        colStartDate.HeaderText = "BẮT ĐẦU"
        colStartDate.MinimumWidth = 6
        colStartDate.Name = "colStartDate"
        colStartDate.ReadOnly = True
        colStartDate.Width = 90
        ' 
        ' colEndDate
        ' 
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colEndDate.DefaultCellStyle = DataGridViewCellStyle6
        colEndDate.HeaderText = "KẾT THÚC"
        colEndDate.MinimumWidth = 6
        colEndDate.Name = "colEndDate"
        colEndDate.ReadOnly = True
        colEndDate.Width = 90
        ' 
        ' colStdHours
        ' 
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colStdHours.DefaultCellStyle = DataGridViewCellStyle7
        colStdHours.HeaderText = "GIỜ CHUẨN"
        colStdHours.MinimumWidth = 6
        colStdHours.Name = "colStdHours"
        colStdHours.ReadOnly = True
        colStdHours.Width = 88
        ' 
        ' colStatus
        ' 
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStatus.DefaultCellStyle = DataGridViewCellStyle8
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 110
        ' 
        ' pnlLeftFooter
        ' 
        pnlLeftFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlLeftFooter.Controls.Add(lblRowInfo)
        pnlLeftFooter.Dock = DockStyle.Bottom
        pnlLeftFooter.Location = New Point(0, 710)
        pnlLeftFooter.Name = "pnlLeftFooter"
        pnlLeftFooter.Size = New Size(560, 36)
        pnlLeftFooter.TabIndex = 1
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(82, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "0 kỳ lương"
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
        pnlToolbar.Size = New Size(1135, 52)
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
        btnAdd.Location = New Point(2015, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(180, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "+ Tạo kỳ lương mới"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FlatStyle = FlatStyle.Flat
        cboStatusFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboStatusFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Nháp", "Đang xử lý", "Đã chốt"})
        cboStatusFilter.Location = New Point(262, 11)
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
        txtSearch.Size = New Size(240, 28)
        txtSearch.TabIndex = 0
        ' 
        ' formPayPeriod
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1135, 798)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(900, 600)
        Name = "formPayPeriod"
        Text = "Kỳ tính lương"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlRight.ResumeLayout(False)
        pnlFormScroll.ResumeLayout(False)
        pnlSec3.ResumeLayout(False)
        pnlSec3.PerformLayout()
        pnlSec2.ResumeLayout(False)
        pnlSec2.PerformLayout()
        tlpSec2.ResumeLayout(False)
        tlpSec2.PerformLayout()
        pnlSec1.ResumeLayout(False)
        pnlSec1.PerformLayout()
        tlpSec1.ResumeLayout(False)
        tlpSec1.PerformLayout()
        pnlRightFooter.ResumeLayout(False)
        pnlRightHeader.ResumeLayout(False)
        pnlRightHeader.PerformLayout()
        pnlKpiRow.ResumeLayout(False)
        pnlKpi3.ResumeLayout(False)
        pnlKpi3.PerformLayout()
        pnlKpi2.ResumeLayout(False)
        pnlKpi2.PerformLayout()
        pnlKpi1.ResumeLayout(False)
        pnlKpi1.PerformLayout()
        pnlLeft.ResumeLayout(False)
        CType(dgvPeriod, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftFooter.ResumeLayout(False)
        pnlLeftFooter.PerformLayout()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' ── Declarations ──────────────────────────────────────────
    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvPeriod As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStdHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlLeftFooter As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents splitter As System.Windows.Forms.Splitter
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlRightHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlRightHdrIcon As System.Windows.Forms.Panel
    Friend WithEvents lblRightTitle As System.Windows.Forms.Label
    Friend WithEvents lblRightSub As System.Windows.Forms.Label
    Friend WithEvents lblRightBadge As System.Windows.Forms.Label
    Friend WithEvents pnlKpiRow As System.Windows.Forms.Panel
    Friend WithEvents pnlKpi1 As System.Windows.Forms.Panel
    Friend WithEvents lblKpi1Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Val As System.Windows.Forms.Label
    Friend WithEvents pnlKpi2 As System.Windows.Forms.Panel
    Friend WithEvents lblKpi2Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Val As System.Windows.Forms.Label
    Friend WithEvents pnlKpi3 As System.Windows.Forms.Panel
    Friend WithEvents lblKpi3Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Val As System.Windows.Forms.Label
    Friend WithEvents pnlFormScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlSec1 As System.Windows.Forms.Panel
    Friend WithEvents lblSec1Title As System.Windows.Forms.Label
    Friend WithEvents tlpSec1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFCode As System.Windows.Forms.Label
    Friend WithEvents txtFCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblFMonth As System.Windows.Forms.Label
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSec2 As System.Windows.Forms.Panel
    Friend WithEvents lblSec2Title As System.Windows.Forms.Label
    Friend WithEvents tlpSec2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFStart As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFEnd As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFStdHours As System.Windows.Forms.Label
    Friend WithEvents txtFStdHours As System.Windows.Forms.TextBox
    Friend WithEvents lblFStdHoursHint As System.Windows.Forms.Label
    Friend WithEvents pnlSec3 As System.Windows.Forms.Panel
    Friend WithEvents lblSec3Title As System.Windows.Forms.Label
    Friend WithEvents txtFNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlRightFooter As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button

End Class