<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReport
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
        tlpContent = New TableLayoutPanel()
        pnlLeft = New Panel()
        pnlTable = New Panel()
        dgvReport = New DataGridView()
        colCode = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colScore = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        lblTableTitle = New Label()
        tlpKpi = New TableLayoutPanel()
        pnlKpi1 = New Panel()
        lblKpi1Sub = New Label()
        lblKpi1Value = New Label()
        lblKpi1Title = New Label()
        pnlKpi2 = New Panel()
        lblKpi2Sub = New Label()
        lblKpi2Value = New Label()
        lblKpi2Title = New Label()
        pnlKpi3 = New Panel()
        lblKpi3Sub = New Label()
        lblKpi3Value = New Label()
        lblKpi3Title = New Label()
        pnlKpi4 = New Panel()
        lblKpi4Sub = New Label()
        lblKpi4Value = New Label()
        lblKpi4Title = New Label()
        pnlRight = New Panel()
        pnlDetail = New Panel()
        pnlDetailBody = New Panel()
        lblDetailNote = New Label()
        tlpDetail = New TableLayoutPanel()
        lblDetailCode = New Label()
        txtDetailCode = New TextBox()
        lblDetailName = New Label()
        txtDetailName = New TextBox()
        lblDetailDept = New Label()
        txtDetailDept = New TextBox()
        lblDetailScore = New Label()
        txtDetailScore = New TextBox()
        lblDetailStatus = New Label()
        txtDetailStatus = New TextBox()
        lblDetailNoteLabel = New Label()
        txtDetailNote = New TextBox()
        lblDetailTitle = New Label()
        pnlChart = New Panel()
        flpChart = New FlowLayoutPanel()
        lblChartTitle = New Label()
        pnlFooter = New Panel()
        lblPage = New Label()
        lblRowInfo = New Label()
        pnlToolbar = New Panel()
        lblError = New Label()
        btnExportPdf = New Button()
        btnExportExcel = New Button()
        btnView = New Button()
        btnReset = New Button()
        cboExportScope = New ComboBox()
        cboDeptFilter = New ComboBox()
        dtpTo = New DateTimePicker()
        dtpFrom = New DateTimePicker()
        cboReportType = New ComboBox()
        pnlHeader = New Panel()
        lblHdrBadge = New Label()
        lblHdrSub = New Label()
        lblHdrTitle = New Label()
        toolTip1 = New ToolTip(components)
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        tlpContent.SuspendLayout()
        pnlLeft.SuspendLayout()
        pnlTable.SuspendLayout()
        CType(dgvReport, ComponentModel.ISupportInitialize).BeginInit()
        tlpKpi.SuspendLayout()
        pnlKpi1.SuspendLayout()
        pnlKpi2.SuspendLayout()
        pnlKpi3.SuspendLayout()
        pnlKpi4.SuspendLayout()
        pnlRight.SuspendLayout()
        pnlDetail.SuspendLayout()
        pnlDetailBody.SuspendLayout()
        tlpDetail.SuspendLayout()
        pnlChart.SuspendLayout()
        pnlFooter.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlFooter)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Controls.Add(pnlHeader)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(1200, 720)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Controls.Add(tlpContent)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 124)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(16)
        pnlContent.Size = New Size(1200, 560)
        pnlContent.TabIndex = 3
        ' 
        ' tlpContent
        ' 
        tlpContent.ColumnCount = 2
        tlpContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60F))
        tlpContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        tlpContent.Controls.Add(pnlLeft, 0, 0)
        tlpContent.Controls.Add(pnlRight, 1, 0)
        tlpContent.Dock = DockStyle.Fill
        tlpContent.Location = New Point(16, 16)
        tlpContent.Name = "tlpContent"
        tlpContent.RowCount = 1
        tlpContent.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpContent.Size = New Size(1168, 528)
        tlpContent.TabIndex = 0
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlLeft.Controls.Add(pnlTable)
        pnlLeft.Controls.Add(tlpKpi)
        pnlLeft.Dock = DockStyle.Fill
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Margin = New Padding(0, 0, 12, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(688, 528)
        pnlLeft.TabIndex = 0
        ' 
        ' pnlTable
        ' 
        pnlTable.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlTable.Controls.Add(dgvReport)
        pnlTable.Controls.Add(lblTableTitle)
        pnlTable.Dock = DockStyle.Fill
        pnlTable.Location = New Point(0, 100)
        pnlTable.Name = "pnlTable"
        pnlTable.Size = New Size(688, 428)
        pnlTable.TabIndex = 1
        ' 
        ' dgvReport
        ' 
        dgvReport.AllowUserToAddRows = False
        dgvReport.AllowUserToDeleteRows = False
        dgvReport.AllowUserToResizeRows = False
        dgvReport.BackgroundColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dgvReport.BorderStyle = BorderStyle.None
        dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvReport.ColumnHeadersHeight = 38
        dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvReport.Columns.AddRange(New DataGridViewColumn() {colCode, colName, colDept, colScore, colStatus})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(40), CByte(66), CByte(106))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvReport.DefaultCellStyle = DataGridViewCellStyle2
        dgvReport.Dock = DockStyle.Fill
        dgvReport.EnableHeadersVisualStyles = False
        dgvReport.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvReport.Location = New Point(0, 36)
        dgvReport.MultiSelect = False
        dgvReport.Name = "dgvReport"
        dgvReport.ReadOnly = True
        dgvReport.RowHeadersVisible = False
        dgvReport.RowHeadersWidth = 51
        dgvReport.RowTemplate.Height = 40
        dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReport.Size = New Size(688, 392)
        dgvReport.TabIndex = 1
        ' 
        ' colCode
        ' 
        colCode.HeaderText = "Mã"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 90
        ' 
        ' colName
        ' 
        colName.HeaderText = "NHÂN VIÊN"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 180
        ' 
        ' colDept
        ' 
        colDept.HeaderText = "PHÒNG BAN"
        colDept.MinimumWidth = 6
        colDept.Name = "colDept"
        colDept.ReadOnly = True
        colDept.Width = 140
        ' 
        ' colScore
        ' 
        colScore.HeaderText = "CHỈ SỐ"
        colScore.MinimumWidth = 6
        colScore.Name = "colScore"
        colScore.ReadOnly = True
        colScore.Width = 80
        ' 
        ' colStatus
        ' 
        colStatus.HeaderText = "TRẠNG THÁI"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        colStatus.Width = 120
        ' 
        ' lblTableTitle
        ' 
        lblTableTitle.Dock = DockStyle.Top
        lblTableTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblTableTitle.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblTableTitle.Location = New Point(0, 0)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Padding = New Padding(12, 10, 0, 0)
        lblTableTitle.Size = New Size(688, 36)
        lblTableTitle.TabIndex = 0
        lblTableTitle.Text = "DANH SÁCH CHI TIẾT"
        ' 
        ' tlpKpi
        ' 
        tlpKpi.ColumnCount = 4
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpKpi.Controls.Add(pnlKpi1, 0, 0)
        tlpKpi.Controls.Add(pnlKpi2, 1, 0)
        tlpKpi.Controls.Add(pnlKpi3, 2, 0)
        tlpKpi.Controls.Add(pnlKpi4, 3, 0)
        tlpKpi.Dock = DockStyle.Top
        tlpKpi.Location = New Point(0, 0)
        tlpKpi.Name = "tlpKpi"
        tlpKpi.RowCount = 1
        tlpKpi.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpKpi.Size = New Size(688, 100)
        tlpKpi.TabIndex = 0
        ' 
        ' pnlKpi1
        ' 
        pnlKpi1.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlKpi1.Controls.Add(lblKpi1Sub)
        pnlKpi1.Controls.Add(lblKpi1Value)
        pnlKpi1.Controls.Add(lblKpi1Title)
        pnlKpi1.Dock = DockStyle.Fill
        pnlKpi1.Location = New Point(0, 0)
        pnlKpi1.Margin = New Padding(0, 0, 8, 8)
        pnlKpi1.Name = "pnlKpi1"
        pnlKpi1.Padding = New Padding(12, 10, 12, 10)
        pnlKpi1.Size = New Size(164, 92)
        pnlKpi1.TabIndex = 0
        ' 
        ' lblKpi1Sub
        ' 
        lblKpi1Sub.AutoSize = True
        lblKpi1Sub.Font = New Font("Microsoft YaHei UI", 8F)
        lblKpi1Sub.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(106))
        lblKpi1Sub.Location = New Point(12, 66)
        lblKpi1Sub.Name = "lblKpi1Sub"
        lblKpi1Sub.Size = New Size(162, 20)
        lblKpi1Sub.TabIndex = 2
        lblKpi1Sub.Text = "+5% so với tháng trước"
        ' 
        ' lblKpi1Value
        ' 
        lblKpi1Value.AutoSize = True
        lblKpi1Value.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblKpi1Value.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi1Value.Location = New Point(12, 30)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.Size = New Size(59, 31)
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "230"
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi1Title.Location = New Point(12, 12)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New Size(127, 19)
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "TỔNG NHÂN SỰ"
        ' 
        ' pnlKpi2
        ' 
        pnlKpi2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlKpi2.Controls.Add(lblKpi2Sub)
        pnlKpi2.Controls.Add(lblKpi2Value)
        pnlKpi2.Controls.Add(lblKpi2Title)
        pnlKpi2.Dock = DockStyle.Fill
        pnlKpi2.Location = New Point(172, 0)
        pnlKpi2.Margin = New Padding(0, 0, 8, 8)
        pnlKpi2.Name = "pnlKpi2"
        pnlKpi2.Padding = New Padding(12, 10, 12, 10)
        pnlKpi2.Size = New Size(164, 92)
        pnlKpi2.TabIndex = 1
        ' 
        ' lblKpi2Sub
        ' 
        lblKpi2Sub.AutoSize = True
        lblKpi2Sub.Font = New Font("Microsoft YaHei UI", 8F)
        lblKpi2Sub.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(106))
        lblKpi2Sub.Location = New Point(12, 66)
        lblKpi2Sub.Name = "lblKpi2Sub"
        lblKpi2Sub.Size = New Size(113, 20)
        lblKpi2Sub.TabIndex = 2
        lblKpi2Sub.Text = "+2.1% tuần này"
        ' 
        ' lblKpi2Value
        ' 
        lblKpi2Value.AutoSize = True
        lblKpi2Value.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblKpi2Value.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi2Value.Location = New Point(12, 30)
        lblKpi2Value.Name = "lblKpi2Value"
        lblKpi2Value.Size = New Size(66, 31)
        lblKpi2Value.TabIndex = 1
        lblKpi2Value.Text = "92%"
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi2Title.Location = New Point(12, 12)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New Size(143, 19)
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "ĐI LÀM ĐÚNG GIỜ"
        ' 
        ' pnlKpi3
        ' 
        pnlKpi3.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlKpi3.Controls.Add(lblKpi3Sub)
        pnlKpi3.Controls.Add(lblKpi3Value)
        pnlKpi3.Controls.Add(lblKpi3Title)
        pnlKpi3.Dock = DockStyle.Fill
        pnlKpi3.Location = New Point(344, 0)
        pnlKpi3.Margin = New Padding(0, 0, 8, 8)
        pnlKpi3.Name = "pnlKpi3"
        pnlKpi3.Padding = New Padding(12, 10, 12, 10)
        pnlKpi3.Size = New Size(164, 92)
        pnlKpi3.TabIndex = 2
        ' 
        ' lblKpi3Sub
        ' 
        lblKpi3Sub.AutoSize = True
        lblKpi3Sub.Font = New Font("Microsoft YaHei UI", 8F)
        lblKpi3Sub.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(106))
        lblKpi3Sub.Location = New Point(12, 66)
        lblKpi3Sub.Name = "lblKpi3Sub"
        lblKpi3Sub.Size = New Size(131, 20)
        lblKpi3Sub.TabIndex = 2
        lblKpi3Sub.Text = "Đơn nghỉ trong kỳ"
        ' 
        ' lblKpi3Value
        ' 
        lblKpi3Value.AutoSize = True
        lblKpi3Value.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblKpi3Value.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi3Value.Location = New Point(12, 30)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.Size = New Size(44, 31)
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "18"
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi3Title.Location = New Point(12, 12)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New Size(90, 19)
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "NGHỈ PHÉP"
        ' 
        ' pnlKpi4
        ' 
        pnlKpi4.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlKpi4.Controls.Add(lblKpi4Sub)
        pnlKpi4.Controls.Add(lblKpi4Value)
        pnlKpi4.Controls.Add(lblKpi4Title)
        pnlKpi4.Dock = DockStyle.Fill
        pnlKpi4.Location = New Point(516, 0)
        pnlKpi4.Margin = New Padding(0, 0, 0, 8)
        pnlKpi4.Name = "pnlKpi4"
        pnlKpi4.Padding = New Padding(12, 10, 12, 10)
        pnlKpi4.Size = New Size(172, 92)
        pnlKpi4.TabIndex = 3
        ' 
        ' lblKpi4Sub
        ' 
        lblKpi4Sub.AutoSize = True
        lblKpi4Sub.Font = New Font("Microsoft YaHei UI", 8F)
        lblKpi4Sub.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(106))
        lblKpi4Sub.Location = New Point(12, 66)
        lblKpi4Sub.Name = "lblKpi4Sub"
        lblKpi4Sub.Size = New Size(117, 20)
        lblKpi4Sub.TabIndex = 2
        lblKpi4Sub.Text = "Theo kỳ hiện tại"
        ' 
        ' lblKpi4Value
        ' 
        lblKpi4Value.AutoSize = True
        lblKpi4Value.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblKpi4Value.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi4Value.Location = New Point(12, 30)
        lblKpi4Value.Name = "lblKpi4Value"
        lblKpi4Value.Size = New Size(82, 31)
        lblKpi4Value.TabIndex = 1
        lblKpi4Value.Text = "4.2 tỷ"
        ' 
        ' lblKpi4Title
        ' 
        lblKpi4Title.AutoSize = True
        lblKpi4Title.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblKpi4Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi4Title.Location = New Point(12, 12)
        lblKpi4Title.Name = "lblKpi4Title"
        lblKpi4Title.Size = New Size(123, 19)
        lblKpi4Title.TabIndex = 0
        lblKpi4Title.Text = "CHI PHÍ LƯƠNG"
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRight.Controls.Add(pnlDetail)
        pnlRight.Controls.Add(pnlChart)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(700, 0)
        pnlRight.Margin = New Padding(0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(468, 528)
        pnlRight.TabIndex = 1
        ' 
        ' pnlDetail
        ' 
        pnlDetail.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlDetail.Controls.Add(pnlDetailBody)
        pnlDetail.Controls.Add(lblDetailTitle)
        pnlDetail.Dock = DockStyle.Fill
        pnlDetail.Location = New Point(0, 240)
        pnlDetail.Name = "pnlDetail"
        pnlDetail.Size = New Size(468, 288)
        pnlDetail.TabIndex = 1
        ' 
        ' pnlDetailBody
        ' 
        pnlDetailBody.BackColor = Color.Transparent
        pnlDetailBody.Controls.Add(lblDetailNote)
        pnlDetailBody.Controls.Add(tlpDetail)
        pnlDetailBody.Dock = DockStyle.Fill
        pnlDetailBody.Location = New Point(0, 36)
        pnlDetailBody.Name = "pnlDetailBody"
        pnlDetailBody.Padding = New Padding(12, 12, 12, 8)
        pnlDetailBody.Size = New Size(468, 252)
        pnlDetailBody.TabIndex = 1
        ' 
        ' lblDetailNote
        ' 
        lblDetailNote.Dock = DockStyle.Bottom
        lblDetailNote.Font = New Font("Microsoft YaHei UI", 8F)
        lblDetailNote.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(106))
        lblDetailNote.Location = New Point(12, 228)
        lblDetailNote.Name = "lblDetailNote"
        lblDetailNote.Size = New Size(444, 16)
        lblDetailNote.TabIndex = 1
        lblDetailNote.Text = "* Dữ liệu mock"
        ' 
        ' tlpDetail
        ' 
        tlpDetail.ColumnCount = 2
        tlpDetail.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpDetail.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpDetail.Controls.Add(lblDetailCode, 0, 0)
        tlpDetail.Controls.Add(txtDetailCode, 0, 1)
        tlpDetail.Controls.Add(lblDetailName, 1, 0)
        tlpDetail.Controls.Add(txtDetailName, 1, 1)
        tlpDetail.Controls.Add(lblDetailDept, 0, 2)
        tlpDetail.Controls.Add(txtDetailDept, 0, 3)
        tlpDetail.Controls.Add(lblDetailScore, 1, 2)
        tlpDetail.Controls.Add(txtDetailScore, 1, 3)
        tlpDetail.Controls.Add(lblDetailStatus, 0, 4)
        tlpDetail.Controls.Add(txtDetailStatus, 0, 5)
        tlpDetail.Controls.Add(lblDetailNoteLabel, 1, 4)
        tlpDetail.Controls.Add(txtDetailNote, 1, 5)
        tlpDetail.Dock = DockStyle.Fill
        tlpDetail.Location = New Point(12, 12)
        tlpDetail.Name = "tlpDetail"
        tlpDetail.RowCount = 6
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpDetail.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlpDetail.Size = New Size(444, 232)
        tlpDetail.TabIndex = 0
        ' 
        ' lblDetailCode
        ' 
        lblDetailCode.AutoSize = True
        lblDetailCode.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailCode.Location = New Point(3, 0)
        lblDetailCode.Name = "lblDetailCode"
        lblDetailCode.Size = New Size(31, 19)
        lblDetailCode.TabIndex = 0
        lblDetailCode.Text = "Mã"
        ' 
        ' txtDetailCode
        ' 
        txtDetailCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailCode.BorderStyle = BorderStyle.FixedSingle
        txtDetailCode.Dock = DockStyle.Fill
        txtDetailCode.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailCode.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailCode.Location = New Point(0, 20)
        txtDetailCode.Margin = New Padding(0, 0, 8, 4)
        txtDetailCode.Name = "txtDetailCode"
        txtDetailCode.ReadOnly = True
        txtDetailCode.Size = New Size(214, 29)
        txtDetailCode.TabIndex = 1
        ' 
        ' lblDetailName
        ' 
        lblDetailName.AutoSize = True
        lblDetailName.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailName.Location = New Point(230, 0)
        lblDetailName.Margin = New Padding(8, 0, 0, 0)
        lblDetailName.Name = "lblDetailName"
        lblDetailName.Size = New Size(80, 19)
        lblDetailName.TabIndex = 2
        lblDetailName.Text = "Nhân viên"
        ' 
        ' txtDetailName
        ' 
        txtDetailName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailName.BorderStyle = BorderStyle.FixedSingle
        txtDetailName.Dock = DockStyle.Fill
        txtDetailName.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailName.Location = New Point(230, 20)
        txtDetailName.Margin = New Padding(8, 0, 0, 4)
        txtDetailName.Name = "txtDetailName"
        txtDetailName.ReadOnly = True
        txtDetailName.Size = New Size(214, 29)
        txtDetailName.TabIndex = 3
        ' 
        ' lblDetailDept
        ' 
        lblDetailDept.AutoSize = True
        lblDetailDept.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailDept.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailDept.Location = New Point(3, 54)
        lblDetailDept.Name = "lblDetailDept"
        lblDetailDept.Size = New Size(84, 19)
        lblDetailDept.TabIndex = 4
        lblDetailDept.Text = "Phòng ban"
        ' 
        ' txtDetailDept
        ' 
        txtDetailDept.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailDept.BorderStyle = BorderStyle.FixedSingle
        txtDetailDept.Dock = DockStyle.Fill
        txtDetailDept.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailDept.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailDept.Location = New Point(0, 74)
        txtDetailDept.Margin = New Padding(0, 0, 8, 4)
        txtDetailDept.Name = "txtDetailDept"
        txtDetailDept.ReadOnly = True
        txtDetailDept.Size = New Size(214, 29)
        txtDetailDept.TabIndex = 5
        ' 
        ' lblDetailScore
        ' 
        lblDetailScore.AutoSize = True
        lblDetailScore.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailScore.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailScore.Location = New Point(230, 54)
        lblDetailScore.Margin = New Padding(8, 0, 0, 0)
        lblDetailScore.Name = "lblDetailScore"
        lblDetailScore.Size = New Size(51, 19)
        lblDetailScore.TabIndex = 6
        lblDetailScore.Text = "Chỉ số"
        ' 
        ' txtDetailScore
        ' 
        txtDetailScore.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailScore.BorderStyle = BorderStyle.FixedSingle
        txtDetailScore.Dock = DockStyle.Fill
        txtDetailScore.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailScore.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailScore.Location = New Point(230, 74)
        txtDetailScore.Margin = New Padding(8, 0, 0, 4)
        txtDetailScore.Name = "txtDetailScore"
        txtDetailScore.ReadOnly = True
        txtDetailScore.Size = New Size(214, 29)
        txtDetailScore.TabIndex = 7
        ' 
        ' lblDetailStatus
        ' 
        lblDetailStatus.AutoSize = True
        lblDetailStatus.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailStatus.Location = New Point(3, 108)
        lblDetailStatus.Name = "lblDetailStatus"
        lblDetailStatus.Size = New Size(82, 19)
        lblDetailStatus.TabIndex = 8
        lblDetailStatus.Text = "Trạng thái"
        ' 
        ' txtDetailStatus
        ' 
        txtDetailStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailStatus.BorderStyle = BorderStyle.FixedSingle
        txtDetailStatus.Dock = DockStyle.Fill
        txtDetailStatus.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailStatus.Location = New Point(0, 128)
        txtDetailStatus.Margin = New Padding(0, 0, 8, 4)
        txtDetailStatus.Name = "txtDetailStatus"
        txtDetailStatus.ReadOnly = True
        txtDetailStatus.Size = New Size(214, 29)
        txtDetailStatus.TabIndex = 9
        ' 
        ' lblDetailNoteLabel
        ' 
        lblDetailNoteLabel.AutoSize = True
        lblDetailNoteLabel.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblDetailNoteLabel.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailNoteLabel.Location = New Point(230, 108)
        lblDetailNoteLabel.Margin = New Padding(8, 0, 0, 0)
        lblDetailNoteLabel.Name = "lblDetailNoteLabel"
        lblDetailNoteLabel.Size = New Size(62, 19)
        lblDetailNoteLabel.TabIndex = 10
        lblDetailNoteLabel.Text = "Ghi chú"
        ' 
        ' txtDetailNote
        ' 
        txtDetailNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtDetailNote.BorderStyle = BorderStyle.FixedSingle
        txtDetailNote.Dock = DockStyle.Fill
        txtDetailNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtDetailNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtDetailNote.Location = New Point(230, 128)
        txtDetailNote.Margin = New Padding(8, 0, 0, 4)
        txtDetailNote.Name = "txtDetailNote"
        txtDetailNote.ReadOnly = True
        txtDetailNote.Size = New Size(214, 29)
        txtDetailNote.TabIndex = 11
        ' 
        ' lblDetailTitle
        ' 
        lblDetailTitle.Dock = DockStyle.Top
        lblDetailTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblDetailTitle.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailTitle.Location = New Point(0, 0)
        lblDetailTitle.Name = "lblDetailTitle"
        lblDetailTitle.Padding = New Padding(12, 10, 0, 0)
        lblDetailTitle.Size = New Size(468, 36)
        lblDetailTitle.TabIndex = 0
        lblDetailTitle.Text = "CHI TIẾT ĐANG CHỌN"
        ' 
        ' pnlChart
        ' 
        pnlChart.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlChart.Controls.Add(flpChart)
        pnlChart.Controls.Add(lblChartTitle)
        pnlChart.Dock = DockStyle.Top
        pnlChart.Location = New Point(0, 0)
        pnlChart.Name = "pnlChart"
        pnlChart.Size = New Size(468, 240)
        pnlChart.TabIndex = 0
        ' 
        ' flpChart
        ' 
        flpChart.Dock = DockStyle.Fill
        flpChart.Location = New Point(0, 36)
        flpChart.Name = "flpChart"
        flpChart.Padding = New Padding(12, 8, 12, 8)
        flpChart.Size = New Size(468, 204)
        flpChart.TabIndex = 1
        flpChart.WrapContents = False
        ' 
        ' lblChartTitle
        ' 
        lblChartTitle.Dock = DockStyle.Top
        lblChartTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblChartTitle.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblChartTitle.Location = New Point(0, 0)
        lblChartTitle.Name = "lblChartTitle"
        lblChartTitle.Padding = New Padding(12, 10, 0, 0)
        lblChartTitle.Size = New Size(468, 36)
        lblChartTitle.TabIndex = 0
        lblChartTitle.Text = "XU HƯỚNG THEO TUẦN"
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlFooter.Controls.Add(lblPage)
        pnlFooter.Controls.Add(lblRowInfo)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 684)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1200, 36)
        pnlFooter.TabIndex = 2
        ' 
        ' lblPage
        ' 
        lblPage.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblPage.AutoSize = True
        lblPage.Font = New Font("Microsoft YaHei UI", 9F)
        lblPage.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPage.Location = New Point(1128, 9)
        lblPage.Name = "lblPage"
        lblPage.Size = New Size(58, 20)
        lblPage.TabIndex = 1
        lblPage.Text = "Page 1"
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(14, 9)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(111, 20)
        lblRowInfo.TabIndex = 0
        lblRowInfo.Text = "Hiển thị 0 mục"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(lblError)
        pnlToolbar.Controls.Add(btnExportPdf)
        pnlToolbar.Controls.Add(btnExportExcel)
        pnlToolbar.Controls.Add(btnView)
        pnlToolbar.Controls.Add(btnReset)
        pnlToolbar.Controls.Add(cboExportScope)
        pnlToolbar.Controls.Add(cboDeptFilter)
        pnlToolbar.Controls.Add(dtpTo)
        pnlToolbar.Controls.Add(dtpFrom)
        pnlToolbar.Controls.Add(cboReportType)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 72)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1200, 52)
        pnlToolbar.TabIndex = 1
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.Font = New Font("Microsoft YaHei UI", 8F)
        lblError.ForeColor = Color.FromArgb(CByte(224), CByte(85), CByte(85))
        lblError.Location = New Point(12, 34)
        lblError.Name = "lblError"
        lblError.Size = New Size(332, 20)
        lblError.TabIndex = 10
        lblError.Text = "Vui lòng chọn loại báo cáo và khoảng thời gian."
        lblError.Visible = False
        ' 
        ' btnExportPdf
        ' 
        btnExportPdf.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportPdf.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnExportPdf.Cursor = Cursors.Hand
        btnExportPdf.FlatAppearance.BorderColor = Color.FromArgb(CByte(55), CByte(62), CByte(90))
        btnExportPdf.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnExportPdf.FlatStyle = FlatStyle.Flat
        btnExportPdf.Font = New Font("Microsoft YaHei UI", 9F)
        btnExportPdf.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        btnExportPdf.Location = New Point(1076, 10)
        btnExportPdf.Name = "btnExportPdf"
        btnExportPdf.Size = New Size(90, 30)
        btnExportPdf.TabIndex = 9
        btnExportPdf.Text = "Xuất PDF"
        btnExportPdf.UseVisualStyleBackColor = False
        ' 
        ' btnExportExcel
        ' 
        btnExportExcel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportExcel.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnExportExcel.Cursor = Cursors.Hand
        btnExportExcel.FlatAppearance.BorderColor = Color.FromArgb(CByte(55), CByte(62), CByte(90))
        btnExportExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnExportExcel.FlatStyle = FlatStyle.Flat
        btnExportExcel.Font = New Font("Microsoft YaHei UI", 9F)
        btnExportExcel.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        btnExportExcel.Location = New Point(978, 10)
        btnExportExcel.Name = "btnExportExcel"
        btnExportExcel.Size = New Size(90, 30)
        btnExportExcel.TabIndex = 8
        btnExportExcel.Text = "Xuất Excel"
        btnExportExcel.UseVisualStyleBackColor = False
        ' 
        ' btnView
        ' 
        btnView.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnView.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnView.Cursor = Cursors.Hand
        btnView.FlatAppearance.BorderSize = 0
        btnView.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnView.FlatStyle = FlatStyle.Flat
        btnView.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        btnView.ForeColor = Color.White
        btnView.Location = New Point(868, 10)
        btnView.Name = "btnView"
        btnView.Size = New Size(100, 30)
        btnView.TabIndex = 7
        btnView.Text = "Xem báo cáo"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' btnReset
        ' 
        btnReset.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnReset.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnReset.Cursor = Cursors.Hand
        btnReset.FlatAppearance.BorderColor = Color.FromArgb(CByte(55), CByte(62), CByte(90))
        btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Microsoft YaHei UI", 9F)
        btnReset.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        btnReset.Location = New Point(772, 10)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(90, 30)
        btnReset.TabIndex = 6
        btnReset.Text = "Làm mới"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' cboExportScope
        ' 
        cboExportScope.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cboExportScope.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboExportScope.DropDownStyle = ComboBoxStyle.DropDownList
        cboExportScope.FlatStyle = FlatStyle.Flat
        cboExportScope.Font = New Font("Microsoft YaHei UI", 9F)
        cboExportScope.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboExportScope.Location = New Point(600, 11)
        cboExportScope.Name = "cboExportScope"
        cboExportScope.Size = New Size(160, 28)
        cboExportScope.TabIndex = 5
        ' 
        ' cboDeptFilter
        ' 
        cboDeptFilter.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDeptFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDeptFilter.FlatStyle = FlatStyle.Flat
        cboDeptFilter.Font = New Font("Microsoft YaHei UI", 9F)
        cboDeptFilter.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDeptFilter.Location = New Point(442, 11)
        cboDeptFilter.Name = "cboDeptFilter"
        cboDeptFilter.Size = New Size(150, 28)
        cboDeptFilter.TabIndex = 4
        ' 
        ' dtpTo
        ' 
        dtpTo.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpTo.CalendarMonthBackground = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpTo.CustomFormat = "dd/MM/yyyy"
        dtpTo.Font = New Font("Microsoft YaHei UI", 9F)
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.Location = New Point(306, 11)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(130, 27)
        dtpTo.TabIndex = 3
        ' 
        ' dtpFrom
        ' 
        dtpFrom.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpFrom.CalendarMonthBackground = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpFrom.Font = New Font("Microsoft YaHei UI", 9F)
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.Location = New Point(170, 11)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(130, 27)
        dtpFrom.TabIndex = 2
        ' 
        ' cboReportType
        ' 
        cboReportType.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList
        cboReportType.FlatStyle = FlatStyle.Flat
        cboReportType.Font = New Font("Microsoft YaHei UI", 9F)
        cboReportType.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboReportType.Location = New Point(12, 11)
        cboReportType.Name = "cboReportType"
        cboReportType.Size = New Size(150, 28)
        cboReportType.TabIndex = 1
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlHeader.Controls.Add(lblHdrBadge)
        pnlHeader.Controls.Add(lblHdrSub)
        pnlHeader.Controls.Add(lblHdrTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(16, 12, 16, 12)
        pnlHeader.Size = New Size(1200, 72)
        pnlHeader.TabIndex = 0
        ' 
        ' lblHdrBadge
        ' 
        lblHdrBadge.AutoSize = True
        lblHdrBadge.BackColor = Color.FromArgb(CByte(20), CByte(74), CByte(158), CByte(255))
        lblHdrBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrBadge.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblHdrBadge.Location = New Point(266, 42)
        lblHdrBadge.Name = "lblHdrBadge"
        lblHdrBadge.Padding = New Padding(6, 2, 6, 2)
        lblHdrBadge.Size = New Size(95, 24)
        lblHdrBadge.TabIndex = 2
        lblHdrBadge.Text = "Full layout"
        ' 
        ' lblHdrSub
        ' 
        lblHdrSub.AutoSize = True
        lblHdrSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblHdrSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblHdrSub.Location = New Point(18, 42)
        lblHdrSub.Name = "lblHdrSub"
        lblHdrSub.Size = New Size(206, 20)
        lblHdrSub.TabIndex = 1
        lblHdrSub.Text = "Theo thời gian / phòng ban"
        ' 
        ' lblHdrTitle
        ' 
        lblHdrTitle.AutoSize = True
        lblHdrTitle.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblHdrTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblHdrTitle.Location = New Point(16, 10)
        lblHdrTitle.Name = "lblHdrTitle"
        lblHdrTitle.Size = New Size(207, 30)
        lblHdrTitle.TabIndex = 0
        lblHdrTitle.Text = "Báo cáo tổng hợp"
        ' 
        ' formReport
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1200, 720)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MinimumSize = New Size(1024, 600)
        Name = "formReport"
        Text = "Báo cáo"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        tlpContent.ResumeLayout(False)
        pnlLeft.ResumeLayout(False)
        pnlTable.ResumeLayout(False)
        CType(dgvReport, ComponentModel.ISupportInitialize).EndInit()
        tlpKpi.ResumeLayout(False)
        pnlKpi1.ResumeLayout(False)
        pnlKpi1.PerformLayout()
        pnlKpi2.ResumeLayout(False)
        pnlKpi2.PerformLayout()
        pnlKpi3.ResumeLayout(False)
        pnlKpi3.PerformLayout()
        pnlKpi4.ResumeLayout(False)
        pnlKpi4.PerformLayout()
        pnlRight.ResumeLayout(False)
        pnlDetail.ResumeLayout(False)
        pnlDetailBody.ResumeLayout(False)
        tlpDetail.ResumeLayout(False)
        tlpDetail.PerformLayout()
        pnlChart.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRoot As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHdrTitle As Label
    Friend WithEvents lblHdrSub As Label
    Friend WithEvents lblHdrBadge As Label
    Friend WithEvents pnlToolbar As Panel
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents cboDeptFilter As ComboBox
    Friend WithEvents cboExportScope As ComboBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnExportPdf As Button
    Friend WithEvents lblError As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents tlpContent As TableLayoutPanel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents tlpKpi As TableLayoutPanel
    Friend WithEvents pnlKpi1 As Panel
    Friend WithEvents lblKpi1Title As Label
    Friend WithEvents lblKpi1Value As Label
    Friend WithEvents lblKpi1Sub As Label
    Friend WithEvents pnlKpi2 As Panel
    Friend WithEvents lblKpi2Title As Label
    Friend WithEvents lblKpi2Value As Label
    Friend WithEvents lblKpi2Sub As Label
    Friend WithEvents pnlKpi3 As Panel
    Friend WithEvents lblKpi3Title As Label
    Friend WithEvents lblKpi3Value As Label
    Friend WithEvents lblKpi3Sub As Label
    Friend WithEvents pnlKpi4 As Panel
    Friend WithEvents lblKpi4Title As Label
    Friend WithEvents lblKpi4Value As Label
    Friend WithEvents lblKpi4Sub As Label
    Friend WithEvents pnlTable As Panel
    Friend WithEvents lblTableTitle As Label
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents colCode As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colDept As DataGridViewTextBoxColumn
    Friend WithEvents colScore As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents pnlRight As Panel
    Friend WithEvents pnlChart As Panel
    Friend WithEvents lblChartTitle As Label
    Friend WithEvents flpChart As FlowLayoutPanel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents lblDetailTitle As Label
    Friend WithEvents pnlDetailBody As Panel
    Friend WithEvents tlpDetail As TableLayoutPanel
    Friend WithEvents lblDetailCode As Label
    Friend WithEvents txtDetailCode As TextBox
    Friend WithEvents lblDetailName As Label
    Friend WithEvents txtDetailName As TextBox
    Friend WithEvents lblDetailDept As Label
    Friend WithEvents txtDetailDept As TextBox
    Friend WithEvents lblDetailScore As Label
    Friend WithEvents txtDetailScore As TextBox
    Friend WithEvents lblDetailStatus As Label
    Friend WithEvents txtDetailStatus As TextBox
    Friend WithEvents lblDetailNoteLabel As Label
    Friend WithEvents txtDetailNote As TextBox
    Friend WithEvents lblDetailNote As Label
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents lblRowInfo As Label
    Friend WithEvents lblPage As Label
    Friend WithEvents toolTip1 As ToolTip
End Class
