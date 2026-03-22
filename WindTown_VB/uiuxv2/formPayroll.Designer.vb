<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formPayroll
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
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlTab3 = New Panel()
        pnlSlipRight = New Panel()
        pnlSlipScroll = New Panel()
        pnlSlipCard = New Panel()
        pnlSlipFooter = New Panel()
        lblSlipNetVal = New Label()
        lblSlipNetLabel = New Label()
        pnlSlipBody = New Panel()
        pnlSlipDeductSection = New Panel()
        flpSlipDeductItems = New FlowLayoutPanel()
        lblSlipDeductTotal = New Label()
        lblSlipDeductTitle = New Label()
        pnlSlipIncomeSection = New Panel()
        flpSlipIncomeItems = New FlowLayoutPanel()
        lblSlipIncomeTotal = New Label()
        lblSlipIncomeTitle = New Label()
        pnlSlipCardHeader = New Panel()
        lblSlipPeriodDates = New Label()
        lblSlipPeriodInfo = New Label()
        pnlSlipAvatar = New Panel()
        lblSlipEmpSub = New Label()
        lblSlipEmpName = New Label()
        pnlSlipActions = New Panel()
        btnExportOne = New Button()
        btnPrintOne = New Button()
        pnlSlipLeft = New Panel()
        flpSlipEmps = New FlowLayoutPanel()
        lblSlipListTitle = New Label()
        pnlTab2 = New Panel()
        dgvPayroll = New DataGridView()
        colChk = New DataGridViewCheckBoxColumn()
        colEmpName = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colJob = New DataGridViewTextBoxColumn()
        colBase = New DataGridViewTextBoxColumn()
        colIncome = New DataGridViewTextBoxColumn()
        colDeduct = New DataGridViewTextBoxColumn()
        colNet = New DataGridViewTextBoxColumn()
        colPayStatus = New DataGridViewTextBoxColumn()
        colView = New DataGridViewTextBoxColumn()
        pnlPayFooter = New Panel()
        pnlPayPageBtns = New Panel()
        btnPayNext = New Button()
        btnPayPage2 = New Button()
        btnPayPage1 = New Button()
        btnPayPrev = New Button()
        lblPayInfo = New Label()
        pnlPayrollHeader = New Panel()
        pnlSummaryChips = New Panel()
        lblChipNet = New Label()
        lblChipDeduct = New Label()
        lblChipIncome = New Label()
        lblPayPeriodBadge = New Label()
        pnlTab1 = New Panel()
        pnlT1Right = New Panel()
        pnlPeriodFormScroll = New Panel()
        tlpPeriodForm = New TableLayoutPanel()
        lblPCode = New Label()
        txtPCode = New TextBox()
        lblPName = New Label()
        txtPName = New TextBox()
        lblPStart = New Label()
        dtpStart = New DateTimePicker()
        lblPEnd = New Label()
        dtpEnd = New DateTimePicker()
        lblPMonth = New Label()
        dtpMonth = New DateTimePicker()
        lblPStdHours = New Label()
        txtStdHours = New TextBox()
        lblPNote = New Label()
        txtPNote = New TextBox()
        pnlPeriodFooter = New Panel()
        btnSavePeriod = New Button()
        btnClosePeriod = New Button()
        btnDeletePeriod = New Button()
        pnlPeriodHeader = New Panel()
        pnlKpiRow = New Panel()
        pnlKpi4 = New Panel()
        lblKpi4Val = New Label()
        lblKpi4Title = New Label()
        pnlKpi3 = New Panel()
        lblKpi3Val = New Label()
        lblKpi3Title = New Label()
        pnlKpi2 = New Panel()
        lblKpi2Val = New Label()
        lblKpi2Title = New Label()
        pnlKpi1 = New Panel()
        lblKpi1Val = New Label()
        lblKpi1Title = New Label()
        pnlPeriodHdrLeft = New Panel()
        lblPeriodBadge = New Label()
        lblPeriodSub = New Label()
        lblPeriodCode = New Label()
        pnlT1Left = New Panel()
        flpPeriods = New FlowLayoutPanel()
        pnlT1AddBtn = New Panel()
        btnAddPeriod = New Button()
        lblPeriodListTitle = New Label()
        pnlTabBar = New Panel()
        pnlTabIndicator = New Panel()
        btnTab3 = New Button()
        btnTab2 = New Button()
        btnTab1 = New Button()
        pnlToolbar = New Panel()
        btnCalcPayroll = New Button()
        btnManagePeriod = New Button()
        btnPrintSlip = New Button()
        btnExportExcel = New Button()
        cboDept = New ComboBox()
        txtSearch = New TextBox()
        cboPeriodSel = New ComboBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTab3.SuspendLayout()
        pnlSlipRight.SuspendLayout()
        pnlSlipScroll.SuspendLayout()
        pnlSlipCard.SuspendLayout()
        pnlSlipFooter.SuspendLayout()
        pnlSlipBody.SuspendLayout()
        pnlSlipDeductSection.SuspendLayout()
        pnlSlipIncomeSection.SuspendLayout()
        pnlSlipCardHeader.SuspendLayout()
        pnlSlipActions.SuspendLayout()
        pnlSlipLeft.SuspendLayout()
        pnlTab2.SuspendLayout()
        CType(dgvPayroll, ComponentModel.ISupportInitialize).BeginInit()
        pnlPayFooter.SuspendLayout()
        pnlPayPageBtns.SuspendLayout()
        pnlPayrollHeader.SuspendLayout()
        pnlSummaryChips.SuspendLayout()
        pnlTab1.SuspendLayout()
        pnlT1Right.SuspendLayout()
        pnlPeriodFormScroll.SuspendLayout()
        tlpPeriodForm.SuspendLayout()
        pnlPeriodFooter.SuspendLayout()
        pnlPeriodHeader.SuspendLayout()
        pnlKpiRow.SuspendLayout()
        pnlKpi4.SuspendLayout()
        pnlKpi3.SuspendLayout()
        pnlKpi2.SuspendLayout()
        pnlKpi1.SuspendLayout()
        pnlPeriodHdrLeft.SuspendLayout()
        pnlT1Left.SuspendLayout()
        pnlT1AddBtn.SuspendLayout()
        pnlTabBar.SuspendLayout()
        pnlToolbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlTabBar)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(284, 261)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Controls.Add(pnlTab3)
        pnlContent.Controls.Add(pnlTab2)
        pnlContent.Controls.Add(pnlTab1)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 96)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(284, 165)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTab3
        ' 
        pnlTab3.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab3.Controls.Add(pnlSlipRight)
        pnlTab3.Controls.Add(pnlSlipLeft)
        pnlTab3.Dock = DockStyle.Fill
        pnlTab3.Location = New Point(0, 0)
        pnlTab3.Name = "pnlTab3"
        pnlTab3.Size = New Size(284, 165)
        pnlTab3.TabIndex = 0
        pnlTab3.Visible = False
        ' 
        ' pnlSlipRight
        ' 
        pnlSlipRight.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlSlipRight.Controls.Add(pnlSlipScroll)
        pnlSlipRight.Controls.Add(pnlSlipActions)
        pnlSlipRight.Dock = DockStyle.Fill
        pnlSlipRight.Location = New Point(260, 0)
        pnlSlipRight.Name = "pnlSlipRight"
        pnlSlipRight.Size = New Size(24, 165)
        pnlSlipRight.TabIndex = 0
        ' 
        ' pnlSlipScroll
        ' 
        pnlSlipScroll.AutoScroll = True
        pnlSlipScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlSlipScroll.Controls.Add(pnlSlipCard)
        pnlSlipScroll.Dock = DockStyle.Fill
        pnlSlipScroll.Location = New Point(0, 0)
        pnlSlipScroll.Name = "pnlSlipScroll"
        pnlSlipScroll.Padding = New Padding(20, 16, 20, 16)
        pnlSlipScroll.Size = New Size(24, 113)
        pnlSlipScroll.TabIndex = 0
        ' 
        ' pnlSlipCard
        ' 
        pnlSlipCard.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSlipCard.Controls.Add(pnlSlipFooter)
        pnlSlipCard.Controls.Add(pnlSlipBody)
        pnlSlipCard.Controls.Add(pnlSlipCardHeader)
        pnlSlipCard.Dock = DockStyle.Top
        pnlSlipCard.Location = New Point(20, 16)
        pnlSlipCard.Name = "pnlSlipCard"
        pnlSlipCard.Size = New Size(0, 600)
        pnlSlipCard.TabIndex = 0
        ' 
        ' pnlSlipFooter
        ' 
        pnlSlipFooter.BackColor = Color.FromArgb(CByte(15), CByte(74), CByte(158), CByte(255))
        pnlSlipFooter.Controls.Add(lblSlipNetVal)
        pnlSlipFooter.Controls.Add(lblSlipNetLabel)
        pnlSlipFooter.Dock = DockStyle.Bottom
        pnlSlipFooter.Location = New Point(0, 536)
        pnlSlipFooter.Name = "pnlSlipFooter"
        pnlSlipFooter.Padding = New Padding(18, 14, 18, 14)
        pnlSlipFooter.Size = New Size(0, 64)
        pnlSlipFooter.TabIndex = 0
        ' 
        ' lblSlipNetVal
        ' 
        lblSlipNetVal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSlipNetVal.AutoSize = True
        lblSlipNetVal.Font = New Font("Microsoft YaHei UI", 16F, FontStyle.Bold)
        lblSlipNetVal.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblSlipNetVal.Location = New Point(338, 10)
        lblSlipNetVal.Name = "lblSlipNetVal"
        lblSlipNetVal.Size = New Size(231, 45)
        lblSlipNetVal.TabIndex = 0
        lblSlipNetVal.Text = "15,625,000đ"
        ' 
        ' lblSlipNetLabel
        ' 
        lblSlipNetLabel.AutoSize = True
        lblSlipNetLabel.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold)
        lblSlipNetLabel.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblSlipNetLabel.Location = New Point(18, 18)
        lblSlipNetLabel.Name = "lblSlipNetLabel"
        lblSlipNetLabel.Size = New Size(172, 27)
        lblSlipNetLabel.TabIndex = 1
        lblSlipNetLabel.Text = "Lương thực lãnh"
        ' 
        ' pnlSlipBody
        ' 
        pnlSlipBody.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlSlipBody.Controls.Add(pnlSlipDeductSection)
        pnlSlipBody.Controls.Add(pnlSlipIncomeSection)
        pnlSlipBody.Dock = DockStyle.Fill
        pnlSlipBody.Location = New Point(0, 88)
        pnlSlipBody.Name = "pnlSlipBody"
        pnlSlipBody.Size = New Size(0, 512)
        pnlSlipBody.TabIndex = 1
        ' 
        ' pnlSlipDeductSection
        ' 
        pnlSlipDeductSection.BackColor = Color.Transparent
        pnlSlipDeductSection.Controls.Add(flpSlipDeductItems)
        pnlSlipDeductSection.Controls.Add(lblSlipDeductTotal)
        pnlSlipDeductSection.Controls.Add(lblSlipDeductTitle)
        pnlSlipDeductSection.Dock = DockStyle.Top
        pnlSlipDeductSection.Location = New Point(0, 260)
        pnlSlipDeductSection.Name = "pnlSlipDeductSection"
        pnlSlipDeductSection.Padding = New Padding(18, 12, 18, 8)
        pnlSlipDeductSection.Size = New Size(0, 180)
        pnlSlipDeductSection.TabIndex = 0
        ' 
        ' flpSlipDeductItems
        ' 
        flpSlipDeductItems.BackColor = Color.Transparent
        flpSlipDeductItems.Dock = DockStyle.Bottom
        flpSlipDeductItems.FlowDirection = FlowDirection.TopDown
        flpSlipDeductItems.Location = New Point(18, 24)
        flpSlipDeductItems.Name = "flpSlipDeductItems"
        flpSlipDeductItems.Size = New Size(0, 148)
        flpSlipDeductItems.TabIndex = 0
        flpSlipDeductItems.WrapContents = False
        ' 
        ' lblSlipDeductTotal
        ' 
        lblSlipDeductTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSlipDeductTotal.AutoSize = True
        lblSlipDeductTotal.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblSlipDeductTotal.ForeColor = Color.FromArgb(CByte(240), CByte(128), CByte(128))
        lblSlipDeductTotal.Location = New Point(388, 12)
        lblSlipDeductTotal.Name = "lblSlipDeductTotal"
        lblSlipDeductTotal.Size = New Size(109, 24)
        lblSlipDeductTotal.TabIndex = 1
        lblSlipDeductTotal.Text = "-1,875,000đ"
        ' 
        ' lblSlipDeductTitle
        ' 
        lblSlipDeductTitle.AutoSize = True
        lblSlipDeductTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSlipDeductTitle.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSlipDeductTitle.Location = New Point(18, 12)
        lblSlipDeductTitle.Name = "lblSlipDeductTitle"
        lblSlipDeductTitle.Size = New Size(88, 19)
        lblSlipDeductTitle.TabIndex = 2
        lblSlipDeductTitle.Text = "KHẤU TRỪ"
        ' 
        ' pnlSlipIncomeSection
        ' 
        pnlSlipIncomeSection.BackColor = Color.Transparent
        pnlSlipIncomeSection.Controls.Add(flpSlipIncomeItems)
        pnlSlipIncomeSection.Controls.Add(lblSlipIncomeTotal)
        pnlSlipIncomeSection.Controls.Add(lblSlipIncomeTitle)
        pnlSlipIncomeSection.Dock = DockStyle.Top
        pnlSlipIncomeSection.Location = New Point(0, 0)
        pnlSlipIncomeSection.Name = "pnlSlipIncomeSection"
        pnlSlipIncomeSection.Padding = New Padding(18, 12, 18, 8)
        pnlSlipIncomeSection.Size = New Size(0, 260)
        pnlSlipIncomeSection.TabIndex = 1
        ' 
        ' flpSlipIncomeItems
        ' 
        flpSlipIncomeItems.BackColor = Color.Transparent
        flpSlipIncomeItems.Dock = DockStyle.Bottom
        flpSlipIncomeItems.FlowDirection = FlowDirection.TopDown
        flpSlipIncomeItems.Location = New Point(18, 22)
        flpSlipIncomeItems.Name = "flpSlipIncomeItems"
        flpSlipIncomeItems.Size = New Size(0, 230)
        flpSlipIncomeItems.TabIndex = 0
        flpSlipIncomeItems.WrapContents = False
        ' 
        ' lblSlipIncomeTotal
        ' 
        lblSlipIncomeTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSlipIncomeTotal.AutoSize = True
        lblSlipIncomeTotal.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblSlipIncomeTotal.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblSlipIncomeTotal.Location = New Point(388, 12)
        lblSlipIncomeTotal.Name = "lblSlipIncomeTotal"
        lblSlipIncomeTotal.Size = New Size(125, 24)
        lblSlipIncomeTotal.TabIndex = 1
        lblSlipIncomeTotal.Text = "+17,500,000đ"
        ' 
        ' lblSlipIncomeTitle
        ' 
        lblSlipIncomeTitle.AutoSize = True
        lblSlipIncomeTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSlipIncomeTitle.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSlipIncomeTitle.Location = New Point(18, 12)
        lblSlipIncomeTitle.Name = "lblSlipIncomeTitle"
        lblSlipIncomeTitle.Size = New Size(91, 19)
        lblSlipIncomeTitle.TabIndex = 2
        lblSlipIncomeTitle.Text = "THU NHẬP"
        ' 
        ' pnlSlipCardHeader
        ' 
        pnlSlipCardHeader.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlSlipCardHeader.Controls.Add(lblSlipPeriodDates)
        pnlSlipCardHeader.Controls.Add(lblSlipPeriodInfo)
        pnlSlipCardHeader.Controls.Add(pnlSlipAvatar)
        pnlSlipCardHeader.Controls.Add(lblSlipEmpSub)
        pnlSlipCardHeader.Controls.Add(lblSlipEmpName)
        pnlSlipCardHeader.Dock = DockStyle.Top
        pnlSlipCardHeader.Location = New Point(0, 0)
        pnlSlipCardHeader.Name = "pnlSlipCardHeader"
        pnlSlipCardHeader.Padding = New Padding(18, 14, 18, 14)
        pnlSlipCardHeader.Size = New Size(0, 88)
        pnlSlipCardHeader.TabIndex = 2
        ' 
        ' lblSlipPeriodDates
        ' 
        lblSlipPeriodDates.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSlipPeriodDates.AutoSize = True
        lblSlipPeriodDates.Font = New Font("Microsoft YaHei UI", 9F)
        lblSlipPeriodDates.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblSlipPeriodDates.Location = New Point(288, 44)
        lblSlipPeriodDates.Name = "lblSlipPeriodDates"
        lblSlipPeriodDates.Size = New Size(321, 20)
        lblSlipPeriodDates.TabIndex = 0
        lblSlipPeriodDates.Text = "01/03/2026 → 31/03/2026  ·  176 giờ chuẩn"
        ' 
        ' lblSlipPeriodInfo
        ' 
        lblSlipPeriodInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSlipPeriodInfo.AutoSize = True
        lblSlipPeriodInfo.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblSlipPeriodInfo.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblSlipPeriodInfo.Location = New Point(288, 16)
        lblSlipPeriodInfo.Name = "lblSlipPeriodInfo"
        lblSlipPeriodInfo.Size = New Size(310, 24)
        lblSlipPeriodInfo.TabIndex = 1
        lblSlipPeriodInfo.Text = "PP2026-03  —  Lương tháng 3/2026"
        ' 
        ' pnlSlipAvatar
        ' 
        pnlSlipAvatar.BackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        pnlSlipAvatar.Location = New Point(18, 16)
        pnlSlipAvatar.Name = "pnlSlipAvatar"
        pnlSlipAvatar.Size = New Size(52, 52)
        pnlSlipAvatar.TabIndex = 2
        ' 
        ' lblSlipEmpSub
        ' 
        lblSlipEmpSub.AutoSize = True
        lblSlipEmpSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblSlipEmpSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblSlipEmpSub.Location = New Point(82, 44)
        lblSlipEmpSub.Name = "lblSlipEmpSub"
        lblSlipEmpSub.Size = New Size(186, 20)
        lblSlipEmpSub.TabIndex = 3
        lblSlipEmpSub.Text = "Kỹ thuật  ·  Lập trình viên"
        ' 
        ' lblSlipEmpName
        ' 
        lblSlipEmpName.AutoSize = True
        lblSlipEmpName.Font = New Font("Microsoft YaHei UI", 13F, FontStyle.Bold)
        lblSlipEmpName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblSlipEmpName.Location = New Point(80, 16)
        lblSlipEmpName.Name = "lblSlipEmpName"
        lblSlipEmpName.Size = New Size(189, 30)
        lblSlipEmpName.TabIndex = 4
        lblSlipEmpName.Text = "Nguyễn Văn An"
        ' 
        ' pnlSlipActions
        ' 
        pnlSlipActions.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlSlipActions.Controls.Add(btnExportOne)
        pnlSlipActions.Controls.Add(btnPrintOne)
        pnlSlipActions.Dock = DockStyle.Bottom
        pnlSlipActions.Location = New Point(0, 113)
        pnlSlipActions.Name = "pnlSlipActions"
        pnlSlipActions.Size = New Size(24, 52)
        pnlSlipActions.TabIndex = 1
        ' 
        ' btnExportOne
        ' 
        btnExportOne.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportOne.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnExportOne.Cursor = Cursors.Hand
        btnExportOne.FlatAppearance.BorderSize = 0
        btnExportOne.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnExportOne.FlatStyle = FlatStyle.Flat
        btnExportOne.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnExportOne.ForeColor = Color.White
        btnExportOne.Location = New Point(904, 10)
        btnExportOne.Name = "btnExportOne"
        btnExportOne.Size = New Size(120, 32)
        btnExportOne.TabIndex = 1
        btnExportOne.Text = "Xuất PDF"
        btnExportOne.UseVisualStyleBackColor = False
        ' 
        ' btnPrintOne
        ' 
        btnPrintOne.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnPrintOne.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPrintOne.Cursor = Cursors.Hand
        btnPrintOne.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPrintOne.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnPrintOne.FlatStyle = FlatStyle.Flat
        btnPrintOne.Font = New Font("Microsoft YaHei UI", 9F)
        btnPrintOne.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPrintOne.Location = New Point(784, 10)
        btnPrintOne.Name = "btnPrintOne"
        btnPrintOne.Size = New Size(110, 32)
        btnPrintOne.TabIndex = 0
        btnPrintOne.Text = "In phiếu"
        btnPrintOne.UseVisualStyleBackColor = False
        ' 
        ' pnlSlipLeft
        ' 
        pnlSlipLeft.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlSlipLeft.Controls.Add(flpSlipEmps)
        pnlSlipLeft.Controls.Add(lblSlipListTitle)
        pnlSlipLeft.Dock = DockStyle.Left
        pnlSlipLeft.Location = New Point(0, 0)
        pnlSlipLeft.Name = "pnlSlipLeft"
        pnlSlipLeft.Size = New Size(260, 165)
        pnlSlipLeft.TabIndex = 1
        ' 
        ' flpSlipEmps
        ' 
        flpSlipEmps.AutoScroll = True
        flpSlipEmps.BackColor = Color.Transparent
        flpSlipEmps.Dock = DockStyle.Fill
        flpSlipEmps.FlowDirection = FlowDirection.TopDown
        flpSlipEmps.Location = New Point(0, 36)
        flpSlipEmps.Name = "flpSlipEmps"
        flpSlipEmps.Padding = New Padding(8, 6, 8, 6)
        flpSlipEmps.Size = New Size(260, 129)
        flpSlipEmps.TabIndex = 0
        flpSlipEmps.WrapContents = False
        ' 
        ' lblSlipListTitle
        ' 
        lblSlipListTitle.Dock = DockStyle.Top
        lblSlipListTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblSlipListTitle.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSlipListTitle.Location = New Point(0, 0)
        lblSlipListTitle.Name = "lblSlipListTitle"
        lblSlipListTitle.Padding = New Padding(12, 12, 0, 0)
        lblSlipListTitle.Size = New Size(260, 36)
        lblSlipListTitle.TabIndex = 1
        lblSlipListTitle.Text = "CHỌN NHÂN VIÊN"
        ' 
        ' pnlTab2
        ' 
        pnlTab2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab2.Controls.Add(dgvPayroll)
        pnlTab2.Controls.Add(pnlPayFooter)
        pnlTab2.Controls.Add(pnlPayrollHeader)
        pnlTab2.Dock = DockStyle.Fill
        pnlTab2.Location = New Point(0, 0)
        pnlTab2.Name = "pnlTab2"
        pnlTab2.Size = New Size(284, 165)
        pnlTab2.TabIndex = 1
        ' 
        ' dgvPayroll
        ' 
        dgvPayroll.AllowUserToAddRows = False
        dgvPayroll.AllowUserToDeleteRows = False
        dgvPayroll.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvPayroll.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvPayroll.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPayroll.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvPayroll.BorderStyle = BorderStyle.None
        dgvPayroll.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvPayroll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvPayroll.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvPayroll.ColumnHeadersHeight = 40
        dgvPayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvPayroll.Columns.AddRange(New DataGridViewColumn() {colChk, colEmpName, colDept, colJob, colBase, colIncome, colDeduct, colNet, colPayStatus, colView})
        dgvPayroll.Cursor = Cursors.Hand
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle10.Font = New Font("Microsoft YaHei UI", 10F)
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle10.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        dgvPayroll.DefaultCellStyle = DataGridViewCellStyle10
        dgvPayroll.EnableHeadersVisualStyles = False
        dgvPayroll.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvPayroll.Location = New Point(0, 48)
        dgvPayroll.Name = "dgvPayroll"
        dgvPayroll.RowHeadersVisible = False
        dgvPayroll.RowHeadersWidth = 51
        dgvPayroll.RowTemplate.Height = 50
        dgvPayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPayroll.Size = New Size(324, 215)
        dgvPayroll.TabIndex = 0
        ' 
        ' colChk
        ' 
        colChk.HeaderText = ""
        colChk.MinimumWidth = 6
        colChk.Name = "colChk"
        colChk.Resizable = DataGridViewTriState.False
        colChk.Width = 36
        ' 
        ' colEmpName
        ' 
        colEmpName.HeaderText = "NHÂN VIÊN"
        colEmpName.MinimumWidth = 6
        colEmpName.Name = "colEmpName"
        colEmpName.ReadOnly = True
        colEmpName.Width = 200
        ' 
        ' colDept
        ' 
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colDept.DefaultCellStyle = DataGridViewCellStyle3
        colDept.HeaderText = "PHÒNG BAN"
        colDept.MinimumWidth = 6
        colDept.Name = "colDept"
        colDept.ReadOnly = True
        colDept.Width = 110
        ' 
        ' colJob
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colJob.DefaultCellStyle = DataGridViewCellStyle4
        colJob.HeaderText = "VỊ TRÍ"
        colJob.MinimumWidth = 6
        colJob.Name = "colJob"
        colJob.ReadOnly = True
        colJob.Width = 160
        ' 
        ' colBase
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colBase.DefaultCellStyle = DataGridViewCellStyle5
        colBase.HeaderText = "LƯƠNG CB"
        colBase.MinimumWidth = 6
        colBase.Name = "colBase"
        colBase.ReadOnly = True
        colBase.Width = 110
        ' 
        ' colIncome
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        colIncome.DefaultCellStyle = DataGridViewCellStyle6
        colIncome.HeaderText = "THU NHẬP"
        colIncome.MinimumWidth = 6
        colIncome.Name = "colIncome"
        colIncome.ReadOnly = True
        colIncome.Width = 120
        ' 
        ' colDeduct
        ' 
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(240), CByte(128), CByte(128))
        colDeduct.DefaultCellStyle = DataGridViewCellStyle7
        colDeduct.HeaderText = "KHẤU TRỪ"
        colDeduct.MinimumWidth = 6
        colDeduct.Name = "colDeduct"
        colDeduct.ReadOnly = True
        colDeduct.Width = 110
        ' 
        ' colNet
        ' 
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colNet.DefaultCellStyle = DataGridViewCellStyle8
        colNet.HeaderText = "THỰC LÃNH"
        colNet.MinimumWidth = 6
        colNet.Name = "colNet"
        colNet.ReadOnly = True
        colNet.Width = 130
        ' 
        ' colPayStatus
        ' 
        colPayStatus.HeaderText = "TRẠNG THÁI"
        colPayStatus.MinimumWidth = 6
        colPayStatus.Name = "colPayStatus"
        colPayStatus.ReadOnly = True
        colPayStatus.Width = 110
        ' 
        ' colView
        ' 
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        colView.DefaultCellStyle = DataGridViewCellStyle9
        colView.HeaderText = ""
        colView.MinimumWidth = 6
        colView.Name = "colView"
        colView.ReadOnly = True
        colView.Resizable = DataGridViewTriState.False
        colView.Width = 70
        ' 
        ' pnlPayFooter
        ' 
        pnlPayFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlPayFooter.Controls.Add(pnlPayPageBtns)
        pnlPayFooter.Controls.Add(lblPayInfo)
        pnlPayFooter.Dock = DockStyle.Bottom
        pnlPayFooter.Location = New Point(0, 121)
        pnlPayFooter.Name = "pnlPayFooter"
        pnlPayFooter.Size = New Size(284, 44)
        pnlPayFooter.TabIndex = 1
        ' 
        ' pnlPayPageBtns
        ' 
        pnlPayPageBtns.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlPayPageBtns.BackColor = Color.Transparent
        pnlPayPageBtns.Controls.Add(btnPayNext)
        pnlPayPageBtns.Controls.Add(btnPayPage2)
        pnlPayPageBtns.Controls.Add(btnPayPage1)
        pnlPayPageBtns.Controls.Add(btnPayPrev)
        pnlPayPageBtns.Location = New Point(1144, 7)
        pnlPayPageBtns.Name = "pnlPayPageBtns"
        pnlPayPageBtns.Size = New Size(130, 30)
        pnlPayPageBtns.TabIndex = 0
        ' 
        ' btnPayNext
        ' 
        btnPayNext.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPayNext.Cursor = Cursors.Hand
        btnPayNext.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPayNext.FlatStyle = FlatStyle.Flat
        btnPayNext.Font = New Font("Microsoft YaHei UI", 9F)
        btnPayNext.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPayNext.Location = New Point(102, 0)
        btnPayNext.Name = "btnPayNext"
        btnPayNext.Size = New Size(30, 30)
        btnPayNext.TabIndex = 0
        btnPayNext.Text = "›"
        btnPayNext.UseVisualStyleBackColor = False
        ' 
        ' btnPayPage2
        ' 
        btnPayPage2.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPayPage2.Cursor = Cursors.Hand
        btnPayPage2.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPayPage2.FlatStyle = FlatStyle.Flat
        btnPayPage2.Font = New Font("Microsoft YaHei UI", 9F)
        btnPayPage2.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPayPage2.Location = New Point(68, 0)
        btnPayPage2.Name = "btnPayPage2"
        btnPayPage2.Size = New Size(30, 30)
        btnPayPage2.TabIndex = 1
        btnPayPage2.Text = "2"
        btnPayPage2.UseVisualStyleBackColor = False
        ' 
        ' btnPayPage1
        ' 
        btnPayPage1.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnPayPage1.Cursor = Cursors.Hand
        btnPayPage1.FlatAppearance.BorderSize = 0
        btnPayPage1.FlatStyle = FlatStyle.Flat
        btnPayPage1.Font = New Font("Microsoft YaHei UI", 9F)
        btnPayPage1.ForeColor = Color.White
        btnPayPage1.Location = New Point(34, 0)
        btnPayPage1.Name = "btnPayPage1"
        btnPayPage1.Size = New Size(30, 30)
        btnPayPage1.TabIndex = 2
        btnPayPage1.Text = "1"
        btnPayPage1.UseVisualStyleBackColor = False
        ' 
        ' btnPayPrev
        ' 
        btnPayPrev.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPayPrev.Cursor = Cursors.Hand
        btnPayPrev.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPayPrev.FlatStyle = FlatStyle.Flat
        btnPayPrev.Font = New Font("Microsoft YaHei UI", 9F)
        btnPayPrev.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPayPrev.Location = New Point(0, 0)
        btnPayPrev.Name = "btnPayPrev"
        btnPayPrev.Size = New Size(30, 30)
        btnPayPrev.TabIndex = 3
        btnPayPrev.Text = "‹"
        btnPayPrev.UseVisualStyleBackColor = False
        ' 
        ' lblPayInfo
        ' 
        lblPayInfo.AutoSize = True
        lblPayInfo.Font = New Font("Microsoft YaHei UI", 9F)
        lblPayInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPayInfo.Location = New Point(16, 14)
        lblPayInfo.Name = "lblPayInfo"
        lblPayInfo.Size = New Size(150, 20)
        lblPayInfo.TabIndex = 1
        lblPayInfo.Text = "Hiển thị 0 nhân viên"
        ' 
        ' pnlPayrollHeader
        ' 
        pnlPayrollHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlPayrollHeader.Controls.Add(pnlSummaryChips)
        pnlPayrollHeader.Controls.Add(lblPayPeriodBadge)
        pnlPayrollHeader.Dock = DockStyle.Top
        pnlPayrollHeader.Location = New Point(0, 0)
        pnlPayrollHeader.Name = "pnlPayrollHeader"
        pnlPayrollHeader.Padding = New Padding(14, 10, 14, 10)
        pnlPayrollHeader.Size = New Size(284, 48)
        pnlPayrollHeader.TabIndex = 2
        ' 
        ' pnlSummaryChips
        ' 
        pnlSummaryChips.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlSummaryChips.BackColor = Color.Transparent
        pnlSummaryChips.Controls.Add(lblChipNet)
        pnlSummaryChips.Controls.Add(lblChipDeduct)
        pnlSummaryChips.Controls.Add(lblChipIncome)
        pnlSummaryChips.Location = New Point(784, 6)
        pnlSummaryChips.Name = "pnlSummaryChips"
        pnlSummaryChips.Size = New Size(560, 36)
        pnlSummaryChips.TabIndex = 0
        ' 
        ' lblChipNet
        ' 
        lblChipNet.AutoSize = True
        lblChipNet.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        lblChipNet.Font = New Font("Microsoft YaHei UI", 9F)
        lblChipNet.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblChipNet.Location = New Point(340, 8)
        lblChipNet.Name = "lblChipNet"
        lblChipNet.Padding = New Padding(8, 3, 8, 3)
        lblChipNet.Size = New Size(144, 26)
        lblChipNet.TabIndex = 0
        lblChipNet.Text = "Thực lãnh:  4.2 tỷ"
        ' 
        ' lblChipDeduct
        ' 
        lblChipDeduct.AutoSize = True
        lblChipDeduct.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        lblChipDeduct.Font = New Font("Microsoft YaHei UI", 9F)
        lblChipDeduct.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblChipDeduct.Location = New Point(170, 8)
        lblChipDeduct.Name = "lblChipDeduct"
        lblChipDeduct.Padding = New Padding(8, 3, 8, 3)
        lblChipDeduct.Size = New Size(146, 26)
        lblChipDeduct.TabIndex = 1
        lblChipDeduct.Text = "Khấu trừ:  -650 tr"
        ' 
        ' lblChipIncome
        ' 
        lblChipIncome.AutoSize = True
        lblChipIncome.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        lblChipIncome.Font = New Font("Microsoft YaHei UI", 9F)
        lblChipIncome.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblChipIncome.Location = New Point(0, 8)
        lblChipIncome.Name = "lblChipIncome"
        lblChipIncome.Padding = New Padding(8, 3, 8, 3)
        lblChipIncome.Size = New Size(152, 26)
        lblChipIncome.TabIndex = 2
        lblChipIncome.Text = "Thu nhập:  4.85 tỷ"
        ' 
        ' lblPayPeriodBadge
        ' 
        lblPayPeriodBadge.AutoSize = True
        lblPayPeriodBadge.BackColor = Color.FromArgb(CByte(15), CByte(74), CByte(158), CByte(255))
        lblPayPeriodBadge.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        lblPayPeriodBadge.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblPayPeriodBadge.Location = New Point(14, 11)
        lblPayPeriodBadge.Name = "lblPayPeriodBadge"
        lblPayPeriodBadge.Padding = New Padding(8, 3, 8, 3)
        lblPayPeriodBadge.Size = New Size(265, 28)
        lblPayPeriodBadge.TabIndex = 1
        lblPayPeriodBadge.Text = "PP2026-03  —  Tháng 3/2026"
        ' 
        ' pnlTab1
        ' 
        pnlTab1.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab1.Controls.Add(pnlT1Right)
        pnlTab1.Controls.Add(pnlT1Left)
        pnlTab1.Dock = DockStyle.Fill
        pnlTab1.Location = New Point(0, 0)
        pnlTab1.Name = "pnlTab1"
        pnlTab1.Size = New Size(284, 165)
        pnlTab1.TabIndex = 2
        pnlTab1.Visible = False
        ' 
        ' pnlT1Right
        ' 
        pnlT1Right.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlT1Right.Controls.Add(pnlPeriodFormScroll)
        pnlT1Right.Controls.Add(pnlPeriodFooter)
        pnlT1Right.Controls.Add(pnlPeriodHeader)
        pnlT1Right.Dock = DockStyle.Fill
        pnlT1Right.Location = New Point(300, 0)
        pnlT1Right.Name = "pnlT1Right"
        pnlT1Right.Size = New Size(0, 165)
        pnlT1Right.TabIndex = 0
        ' 
        ' pnlPeriodFormScroll
        ' 
        pnlPeriodFormScroll.AutoScroll = True
        pnlPeriodFormScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlPeriodFormScroll.Controls.Add(tlpPeriodForm)
        pnlPeriodFormScroll.Dock = DockStyle.Fill
        pnlPeriodFormScroll.Location = New Point(0, 160)
        pnlPeriodFormScroll.Name = "pnlPeriodFormScroll"
        pnlPeriodFormScroll.Padding = New Padding(18, 14, 18, 14)
        pnlPeriodFormScroll.Size = New Size(0, 0)
        pnlPeriodFormScroll.TabIndex = 0
        ' 
        ' tlpPeriodForm
        ' 
        tlpPeriodForm.BackColor = Color.Transparent
        tlpPeriodForm.ColumnCount = 2
        tlpPeriodForm.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpPeriodForm.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpPeriodForm.Controls.Add(lblPCode, 0, 0)
        tlpPeriodForm.Controls.Add(txtPCode, 0, 1)
        tlpPeriodForm.Controls.Add(lblPName, 1, 0)
        tlpPeriodForm.Controls.Add(txtPName, 1, 1)
        tlpPeriodForm.Controls.Add(lblPStart, 0, 2)
        tlpPeriodForm.Controls.Add(dtpStart, 0, 3)
        tlpPeriodForm.Controls.Add(lblPEnd, 1, 2)
        tlpPeriodForm.Controls.Add(dtpEnd, 1, 3)
        tlpPeriodForm.Controls.Add(lblPMonth, 0, 4)
        tlpPeriodForm.Controls.Add(dtpMonth, 0, 5)
        tlpPeriodForm.Controls.Add(lblPStdHours, 1, 4)
        tlpPeriodForm.Controls.Add(txtStdHours, 1, 5)
        tlpPeriodForm.Controls.Add(lblPNote, 0, 6)
        tlpPeriodForm.Controls.Add(txtPNote, 0, 7)
        tlpPeriodForm.Dock = DockStyle.Top
        tlpPeriodForm.Location = New Point(18, 14)
        tlpPeriodForm.Name = "tlpPeriodForm"
        tlpPeriodForm.RowCount = 8
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpPeriodForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpPeriodForm.Size = New Size(0, 340)
        tlpPeriodForm.TabIndex = 0
        ' 
        ' lblPCode
        ' 
        lblPCode.AutoSize = True
        lblPCode.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPCode.Location = New Point(3, 0)
        lblPCode.Name = "lblPCode"
        lblPCode.Size = New Size(1, 19)
        lblPCode.TabIndex = 0
        lblPCode.Text = "Mã kỳ lương  *"
        ' 
        ' txtPCode
        ' 
        txtPCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtPCode.BorderStyle = BorderStyle.FixedSingle
        txtPCode.Dock = DockStyle.Fill
        txtPCode.Font = New Font("Courier New", 10F)
        txtPCode.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        txtPCode.Location = New Point(0, 22)
        txtPCode.Margin = New Padding(0, 0, 8, 4)
        txtPCode.Name = "txtPCode"
        txtPCode.Size = New Size(1, 25)
        txtPCode.TabIndex = 1
        ' 
        ' lblPName
        ' 
        lblPName.AutoSize = True
        lblPName.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPName.Location = New Point(8, 0)
        lblPName.Margin = New Padding(8, 0, 0, 0)
        lblPName.Name = "lblPName"
        lblPName.Size = New Size(1, 19)
        lblPName.TabIndex = 2
        lblPName.Text = "Tên kỳ lương  *"
        ' 
        ' txtPName
        ' 
        txtPName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtPName.BorderStyle = BorderStyle.FixedSingle
        txtPName.Dock = DockStyle.Fill
        txtPName.Font = New Font("Microsoft YaHei UI", 10F)
        txtPName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtPName.Location = New Point(8, 22)
        txtPName.Margin = New Padding(8, 0, 0, 4)
        txtPName.Name = "txtPName"
        txtPName.Size = New Size(1, 28)
        txtPName.TabIndex = 3
        ' 
        ' lblPStart
        ' 
        lblPStart.AutoSize = True
        lblPStart.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPStart.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPStart.Location = New Point(3, 64)
        lblPStart.Name = "lblPStart"
        lblPStart.Size = New Size(1, 19)
        lblPStart.TabIndex = 4
        lblPStart.Text = "Ngày bắt đầu"
        ' 
        ' dtpStart
        ' 
        dtpStart.CustomFormat = "dd/MM/yyyy"
        dtpStart.Dock = DockStyle.Fill
        dtpStart.Font = New Font("Microsoft YaHei UI", 10F)
        dtpStart.Format = DateTimePickerFormat.Custom
        dtpStart.Location = New Point(0, 86)
        dtpStart.Margin = New Padding(0, 0, 8, 4)
        dtpStart.Name = "dtpStart"
        dtpStart.Size = New Size(1, 28)
        dtpStart.TabIndex = 5
        ' 
        ' lblPEnd
        ' 
        lblPEnd.AutoSize = True
        lblPEnd.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPEnd.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPEnd.Location = New Point(8, 64)
        lblPEnd.Margin = New Padding(8, 0, 0, 0)
        lblPEnd.Name = "lblPEnd"
        lblPEnd.Size = New Size(1, 19)
        lblPEnd.TabIndex = 6
        lblPEnd.Text = "Ngày kết thúc"
        ' 
        ' dtpEnd
        ' 
        dtpEnd.CustomFormat = "dd/MM/yyyy"
        dtpEnd.Dock = DockStyle.Fill
        dtpEnd.Font = New Font("Microsoft YaHei UI", 10F)
        dtpEnd.Format = DateTimePickerFormat.Custom
        dtpEnd.Location = New Point(8, 86)
        dtpEnd.Margin = New Padding(8, 0, 0, 4)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(1, 28)
        dtpEnd.TabIndex = 7
        ' 
        ' lblPMonth
        ' 
        lblPMonth.AutoSize = True
        lblPMonth.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPMonth.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPMonth.Location = New Point(3, 128)
        lblPMonth.Name = "lblPMonth"
        lblPMonth.Size = New Size(1, 19)
        lblPMonth.TabIndex = 8
        lblPMonth.Text = "Tháng tính lương"
        ' 
        ' dtpMonth
        ' 
        dtpMonth.CustomFormat = "MM/yyyy"
        dtpMonth.Dock = DockStyle.Fill
        dtpMonth.Font = New Font("Microsoft YaHei UI", 10F)
        dtpMonth.Format = DateTimePickerFormat.Custom
        dtpMonth.Location = New Point(0, 150)
        dtpMonth.Margin = New Padding(0, 0, 8, 4)
        dtpMonth.Name = "dtpMonth"
        dtpMonth.Size = New Size(1, 28)
        dtpMonth.TabIndex = 9
        ' 
        ' lblPStdHours
        ' 
        lblPStdHours.AutoSize = True
        lblPStdHours.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPStdHours.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPStdHours.Location = New Point(8, 128)
        lblPStdHours.Margin = New Padding(8, 0, 0, 0)
        lblPStdHours.Name = "lblPStdHours"
        lblPStdHours.Size = New Size(1, 19)
        lblPStdHours.TabIndex = 10
        lblPStdHours.Text = "Giờ chuẩn (std_hours)"
        ' 
        ' txtStdHours
        ' 
        txtStdHours.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtStdHours.BorderStyle = BorderStyle.FixedSingle
        txtStdHours.Dock = DockStyle.Fill
        txtStdHours.Font = New Font("Microsoft YaHei UI", 10F)
        txtStdHours.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtStdHours.Location = New Point(8, 150)
        txtStdHours.Margin = New Padding(8, 0, 0, 4)
        txtStdHours.Name = "txtStdHours"
        txtStdHours.Size = New Size(1, 28)
        txtStdHours.TabIndex = 11
        txtStdHours.Text = "176"
        ' 
        ' lblPNote
        ' 
        lblPNote.AutoSize = True
        tlpPeriodForm.SetColumnSpan(lblPNote, 2)
        lblPNote.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPNote.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPNote.Location = New Point(3, 192)
        lblPNote.Name = "lblPNote"
        lblPNote.Size = New Size(1, 19)
        lblPNote.TabIndex = 12
        lblPNote.Text = "Ghi chú"
        ' 
        ' txtPNote
        ' 
        txtPNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtPNote.BorderStyle = BorderStyle.FixedSingle
        tlpPeriodForm.SetColumnSpan(txtPNote, 2)
        txtPNote.Dock = DockStyle.Fill
        txtPNote.Font = New Font("Microsoft YaHei UI", 10F)
        txtPNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtPNote.Location = New Point(0, 214)
        txtPNote.Margin = New Padding(0, 0, 0, 4)
        txtPNote.Name = "txtPNote"
        txtPNote.Size = New Size(1, 28)
        txtPNote.TabIndex = 13
        ' 
        ' pnlPeriodFooter
        ' 
        pnlPeriodFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlPeriodFooter.Controls.Add(btnSavePeriod)
        pnlPeriodFooter.Controls.Add(btnClosePeriod)
        pnlPeriodFooter.Controls.Add(btnDeletePeriod)
        pnlPeriodFooter.Dock = DockStyle.Bottom
        pnlPeriodFooter.Location = New Point(0, 113)
        pnlPeriodFooter.Name = "pnlPeriodFooter"
        pnlPeriodFooter.Size = New Size(0, 52)
        pnlPeriodFooter.TabIndex = 1
        ' 
        ' btnSavePeriod
        ' 
        btnSavePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSavePeriod.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSavePeriod.Cursor = Cursors.Hand
        btnSavePeriod.FlatAppearance.BorderSize = 0
        btnSavePeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnSavePeriod.FlatStyle = FlatStyle.Flat
        btnSavePeriod.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnSavePeriod.ForeColor = Color.White
        btnSavePeriod.Location = New Point(718, 10)
        btnSavePeriod.Name = "btnSavePeriod"
        btnSavePeriod.Size = New Size(130, 32)
        btnSavePeriod.TabIndex = 2
        btnSavePeriod.Text = "Lưu thông tin"
        btnSavePeriod.UseVisualStyleBackColor = False
        ' 
        ' btnClosePeriod
        ' 
        btnClosePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClosePeriod.BackColor = Color.FromArgb(CByte(30), CByte(245), CByte(158), CByte(11))
        btnClosePeriod.Cursor = Cursors.Hand
        btnClosePeriod.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(245), CByte(158), CByte(11))
        btnClosePeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(245), CByte(158), CByte(11))
        btnClosePeriod.FlatStyle = FlatStyle.Flat
        btnClosePeriod.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        btnClosePeriod.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        btnClosePeriod.Location = New Point(578, 10)
        btnClosePeriod.Name = "btnClosePeriod"
        btnClosePeriod.Size = New Size(130, 32)
        btnClosePeriod.TabIndex = 1
        btnClosePeriod.Text = "Chốt kỳ lương"
        btnClosePeriod.UseVisualStyleBackColor = False
        ' 
        ' btnDeletePeriod
        ' 
        btnDeletePeriod.BackColor = Color.FromArgb(CByte(25), CByte(229), CByte(62), CByte(62))
        btnDeletePeriod.Cursor = Cursors.Hand
        btnDeletePeriod.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(229), CByte(62), CByte(62))
        btnDeletePeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(50), CByte(229), CByte(62), CByte(62))
        btnDeletePeriod.FlatStyle = FlatStyle.Flat
        btnDeletePeriod.Font = New Font("Microsoft YaHei UI", 9F)
        btnDeletePeriod.ForeColor = Color.FromArgb(CByte(240), CByte(128), CByte(128))
        btnDeletePeriod.Location = New Point(14, 10)
        btnDeletePeriod.Name = "btnDeletePeriod"
        btnDeletePeriod.Size = New Size(120, 32)
        btnDeletePeriod.TabIndex = 0
        btnDeletePeriod.Text = "Xóa kỳ lương"
        btnDeletePeriod.UseVisualStyleBackColor = False
        ' 
        ' pnlPeriodHeader
        ' 
        pnlPeriodHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlPeriodHeader.Controls.Add(pnlKpiRow)
        pnlPeriodHeader.Controls.Add(pnlPeriodHdrLeft)
        pnlPeriodHeader.Dock = DockStyle.Top
        pnlPeriodHeader.Location = New Point(0, 0)
        pnlPeriodHeader.Name = "pnlPeriodHeader"
        pnlPeriodHeader.Padding = New Padding(18, 14, 18, 10)
        pnlPeriodHeader.Size = New Size(0, 160)
        pnlPeriodHeader.TabIndex = 2
        ' 
        ' pnlKpiRow
        ' 
        pnlKpiRow.BackColor = Color.Transparent
        pnlKpiRow.Controls.Add(pnlKpi4)
        pnlKpiRow.Controls.Add(pnlKpi3)
        pnlKpiRow.Controls.Add(pnlKpi2)
        pnlKpiRow.Controls.Add(pnlKpi1)
        pnlKpiRow.Dock = DockStyle.Bottom
        pnlKpiRow.Location = New Point(18, 74)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New Size(0, 76)
        pnlKpiRow.TabIndex = 0
        ' 
        ' pnlKpi4
        ' 
        pnlKpi4.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi4.Controls.Add(lblKpi4Val)
        pnlKpi4.Controls.Add(lblKpi4Title)
        pnlKpi4.Location = New Point(584, 0)
        pnlKpi4.Name = "pnlKpi4"
        pnlKpi4.Padding = New Padding(12, 8, 12, 8)
        pnlKpi4.Size = New Size(160, 72)
        pnlKpi4.TabIndex = 0
        ' 
        ' lblKpi4Val
        ' 
        lblKpi4Val.AutoSize = True
        lblKpi4Val.Font = New Font("Microsoft YaHei UI", 16F, FontStyle.Bold)
        lblKpi4Val.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi4Val.Location = New Point(10, 28)
        lblKpi4Val.Name = "lblKpi4Val"
        lblKpi4Val.Size = New Size(91, 36)
        lblKpi4Val.TabIndex = 0
        lblKpi4Val.Text = "176 h"
        ' 
        ' lblKpi4Title
        ' 
        lblKpi4Title.AutoSize = True
        lblKpi4Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi4Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi4Title.Location = New Point(12, 8)
        lblKpi4Title.Name = "lblKpi4Title"
        lblKpi4Title.Size = New Size(88, 20)
        lblKpi4Title.TabIndex = 1
        lblKpi4Title.Text = "GIỜ CHUẨN"
        ' 
        ' pnlKpi3
        ' 
        pnlKpi3.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi3.Controls.Add(lblKpi3Val)
        pnlKpi3.Controls.Add(lblKpi3Title)
        pnlKpi3.Location = New Point(376, 0)
        pnlKpi3.Name = "pnlKpi3"
        pnlKpi3.Padding = New Padding(12, 8, 12, 8)
        pnlKpi3.Size = New Size(200, 72)
        pnlKpi3.TabIndex = 1
        ' 
        ' lblKpi3Val
        ' 
        lblKpi3Val.AutoSize = True
        lblKpi3Val.Font = New Font("Microsoft YaHei UI", 16F, FontStyle.Bold)
        lblKpi3Val.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        lblKpi3Val.Location = New Point(10, 28)
        lblKpi3Val.Name = "lblKpi3Val"
        lblKpi3Val.Size = New Size(92, 36)
        lblKpi3Val.TabIndex = 0
        lblKpi3Val.Text = "4.2 tỷ"
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi3Title.Location = New Point(12, 8)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New Size(130, 20)
        lblKpi3Title.TabIndex = 1
        lblKpi3Title.Text = "TỔNG CHI LƯƠNG"
        ' 
        ' pnlKpi2
        ' 
        pnlKpi2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi2.Controls.Add(lblKpi2Val)
        pnlKpi2.Controls.Add(lblKpi2Title)
        pnlKpi2.Location = New Point(188, 0)
        pnlKpi2.Name = "pnlKpi2"
        pnlKpi2.Padding = New Padding(12, 8, 12, 8)
        pnlKpi2.Size = New Size(180, 72)
        pnlKpi2.TabIndex = 2
        ' 
        ' lblKpi2Val
        ' 
        lblKpi2Val.AutoSize = True
        lblKpi2Val.Font = New Font("Microsoft YaHei UI", 16F, FontStyle.Bold)
        lblKpi2Val.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblKpi2Val.Location = New Point(10, 28)
        lblKpi2Val.Name = "lblKpi2Val"
        lblKpi2Val.Size = New Size(66, 36)
        lblKpi2Val.TabIndex = 0
        lblKpi2Val.Text = "228"
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi2Title.Location = New Point(12, 8)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New Size(121, 20)
        lblKpi2Title.TabIndex = 1
        lblKpi2Title.Text = "ĐÃ TÍNH LƯƠNG"
        ' 
        ' pnlKpi1
        ' 
        pnlKpi1.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlKpi1.Controls.Add(lblKpi1Val)
        pnlKpi1.Controls.Add(lblKpi1Title)
        pnlKpi1.Location = New Point(0, 0)
        pnlKpi1.Name = "pnlKpi1"
        pnlKpi1.Padding = New Padding(12, 8, 12, 8)
        pnlKpi1.Size = New Size(180, 72)
        pnlKpi1.TabIndex = 3
        ' 
        ' lblKpi1Val
        ' 
        lblKpi1Val.AutoSize = True
        lblKpi1Val.Font = New Font("Microsoft YaHei UI", 16F, FontStyle.Bold)
        lblKpi1Val.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblKpi1Val.Location = New Point(10, 28)
        lblKpi1Val.Name = "lblKpi1Val"
        lblKpi1Val.Size = New Size(66, 36)
        lblKpi1Val.TabIndex = 0
        lblKpi1Val.Text = "230"
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New Font("Microsoft YaHei UI", 9F)
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblKpi1Title.Location = New Point(12, 8)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New Size(88, 20)
        lblKpi1Title.TabIndex = 1
        lblKpi1Title.Text = "NHÂN VIÊN"
        ' 
        ' pnlPeriodHdrLeft
        ' 
        pnlPeriodHdrLeft.BackColor = Color.Transparent
        pnlPeriodHdrLeft.Controls.Add(lblPeriodBadge)
        pnlPeriodHdrLeft.Controls.Add(lblPeriodSub)
        pnlPeriodHdrLeft.Controls.Add(lblPeriodCode)
        pnlPeriodHdrLeft.Dock = DockStyle.Top
        pnlPeriodHdrLeft.Location = New Point(18, 14)
        pnlPeriodHdrLeft.Name = "pnlPeriodHdrLeft"
        pnlPeriodHdrLeft.Size = New Size(0, 68)
        pnlPeriodHdrLeft.TabIndex = 1
        ' 
        ' lblPeriodBadge
        ' 
        lblPeriodBadge.AutoSize = True
        lblPeriodBadge.BackColor = Color.FromArgb(CByte(20), CByte(76), CByte(175), CByte(80))
        lblPeriodBadge.Font = New Font("Microsoft YaHei UI", 9F)
        lblPeriodBadge.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblPeriodBadge.Location = New Point(2, 54)
        lblPeriodBadge.Name = "lblPeriodBadge"
        lblPeriodBadge.Padding = New Padding(6, 2, 6, 2)
        lblPeriodBadge.Size = New Size(109, 24)
        lblPeriodBadge.TabIndex = 0
        lblPeriodBadge.Text = "● Đang xử lý"
        ' 
        ' lblPeriodSub
        ' 
        lblPeriodSub.AutoSize = True
        lblPeriodSub.Font = New Font("Microsoft YaHei UI", 9F)
        lblPeriodSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPeriodSub.Location = New Point(2, 36)
        lblPeriodSub.Name = "lblPeriodSub"
        lblPeriodSub.Size = New Size(200, 20)
        lblPeriodSub.TabIndex = 1
        lblPeriodSub.Text = "01/03/2026 → 31/03/2026"
        ' 
        ' lblPeriodCode
        ' 
        lblPeriodCode.AutoSize = True
        lblPeriodCode.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblPeriodCode.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblPeriodCode.Location = New Point(0, 0)
        lblPeriodCode.Name = "lblPeriodCode"
        lblPeriodCode.Size = New Size(433, 31)
        lblPeriodCode.TabIndex = 2
        lblPeriodCode.Text = "PP2026-03 — Lương tháng 3/2026"
        ' 
        ' pnlT1Left
        ' 
        pnlT1Left.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlT1Left.Controls.Add(flpPeriods)
        pnlT1Left.Controls.Add(pnlT1AddBtn)
        pnlT1Left.Controls.Add(lblPeriodListTitle)
        pnlT1Left.Dock = DockStyle.Left
        pnlT1Left.Location = New Point(0, 0)
        pnlT1Left.Name = "pnlT1Left"
        pnlT1Left.Size = New Size(300, 165)
        pnlT1Left.TabIndex = 1
        ' 
        ' flpPeriods
        ' 
        flpPeriods.AutoScroll = True
        flpPeriods.BackColor = Color.Transparent
        flpPeriods.Dock = DockStyle.Fill
        flpPeriods.FlowDirection = FlowDirection.TopDown
        flpPeriods.Location = New Point(0, 36)
        flpPeriods.Name = "flpPeriods"
        flpPeriods.Padding = New Padding(10, 6, 10, 6)
        flpPeriods.Size = New Size(300, 75)
        flpPeriods.TabIndex = 0
        flpPeriods.WrapContents = False
        ' 
        ' pnlT1AddBtn
        ' 
        pnlT1AddBtn.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlT1AddBtn.Controls.Add(btnAddPeriod)
        pnlT1AddBtn.Dock = DockStyle.Bottom
        pnlT1AddBtn.Location = New Point(0, 111)
        pnlT1AddBtn.Name = "pnlT1AddBtn"
        pnlT1AddBtn.Padding = New Padding(10)
        pnlT1AddBtn.Size = New Size(300, 54)
        pnlT1AddBtn.TabIndex = 1
        ' 
        ' btnAddPeriod
        ' 
        btnAddPeriod.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnAddPeriod.Cursor = Cursors.Hand
        btnAddPeriod.Dock = DockStyle.Fill
        btnAddPeriod.FlatAppearance.BorderSize = 0
        btnAddPeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnAddPeriod.FlatStyle = FlatStyle.Flat
        btnAddPeriod.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnAddPeriod.ForeColor = Color.White
        btnAddPeriod.Location = New Point(10, 10)
        btnAddPeriod.Name = "btnAddPeriod"
        btnAddPeriod.Size = New Size(280, 34)
        btnAddPeriod.TabIndex = 0
        btnAddPeriod.Text = "+ Tạo kỳ lương mới"
        btnAddPeriod.UseVisualStyleBackColor = False
        ' 
        ' lblPeriodListTitle
        ' 
        lblPeriodListTitle.Dock = DockStyle.Top
        lblPeriodListTitle.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Bold)
        lblPeriodListTitle.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblPeriodListTitle.Location = New Point(0, 0)
        lblPeriodListTitle.Name = "lblPeriodListTitle"
        lblPeriodListTitle.Padding = New Padding(12, 12, 0, 0)
        lblPeriodListTitle.Size = New Size(300, 36)
        lblPeriodListTitle.TabIndex = 2
        lblPeriodListTitle.Text = "CÁC KỲ LƯƠNG"
        ' 
        ' pnlTabBar
        ' 
        pnlTabBar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlTabBar.Controls.Add(pnlTabIndicator)
        pnlTabBar.Controls.Add(btnTab3)
        pnlTabBar.Controls.Add(btnTab2)
        pnlTabBar.Controls.Add(btnTab1)
        pnlTabBar.Dock = DockStyle.Top
        pnlTabBar.Location = New Point(0, 52)
        pnlTabBar.Name = "pnlTabBar"
        pnlTabBar.Size = New Size(284, 44)
        pnlTabBar.TabIndex = 1
        ' 
        ' pnlTabIndicator
        ' 
        pnlTabIndicator.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        pnlTabIndicator.Location = New Point(160, 41)
        pnlTabIndicator.Name = "pnlTabIndicator"
        pnlTabIndicator.Size = New Size(160, 3)
        pnlTabIndicator.TabIndex = 0
        ' 
        ' btnTab3
        ' 
        btnTab3.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTab3.Cursor = Cursors.Hand
        btnTab3.FlatAppearance.BorderSize = 0
        btnTab3.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTab3.FlatStyle = FlatStyle.Flat
        btnTab3.Font = New Font("Microsoft YaHei UI", 10F)
        btnTab3.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnTab3.Location = New Point(320, 0)
        btnTab3.Name = "btnTab3"
        btnTab3.Size = New Size(200, 42)
        btnTab3.TabIndex = 2
        btnTab3.Text = "Phiếu lương chi tiết"
        btnTab3.UseVisualStyleBackColor = False
        ' 
        ' btnTab2
        ' 
        btnTab2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTab2.Cursor = Cursors.Hand
        btnTab2.FlatAppearance.BorderSize = 0
        btnTab2.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTab2.FlatStyle = FlatStyle.Flat
        btnTab2.Font = New Font("Microsoft YaHei UI", 10F)
        btnTab2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnTab2.Location = New Point(160, 0)
        btnTab2.Name = "btnTab2"
        btnTab2.Size = New Size(160, 42)
        btnTab2.TabIndex = 1
        btnTab2.Text = "Bảng lương"
        btnTab2.UseVisualStyleBackColor = False
        ' 
        ' btnTab1
        ' 
        btnTab1.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTab1.Cursor = Cursors.Hand
        btnTab1.FlatAppearance.BorderSize = 0
        btnTab1.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTab1.FlatStyle = FlatStyle.Flat
        btnTab1.Font = New Font("Microsoft YaHei UI", 10F)
        btnTab1.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnTab1.Location = New Point(0, 0)
        btnTab1.Name = "btnTab1"
        btnTab1.Size = New Size(160, 42)
        btnTab1.TabIndex = 0
        btnTab1.Text = "Kỳ lương"
        btnTab1.UseVisualStyleBackColor = False
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnCalcPayroll)
        pnlToolbar.Controls.Add(btnManagePeriod)
        pnlToolbar.Controls.Add(btnPrintSlip)
        pnlToolbar.Controls.Add(btnExportExcel)
        pnlToolbar.Controls.Add(cboDept)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(cboPeriodSel)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(284, 52)
        pnlToolbar.TabIndex = 2
        ' 
        ' btnCalcPayroll
        ' 
        btnCalcPayroll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnCalcPayroll.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnCalcPayroll.Cursor = Cursors.Hand
        btnCalcPayroll.FlatAppearance.BorderSize = 0
        btnCalcPayroll.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnCalcPayroll.FlatStyle = FlatStyle.Flat
        btnCalcPayroll.Font = New Font("Microsoft YaHei UI", 10F, FontStyle.Bold)
        btnCalcPayroll.ForeColor = Color.White
        btnCalcPayroll.Location = New Point(1234, 11)
        btnCalcPayroll.Name = "btnCalcPayroll"
        btnCalcPayroll.Size = New Size(120, 30)
        btnCalcPayroll.TabIndex = 6
        btnCalcPayroll.Text = "▶  Tính lương"
        btnCalcPayroll.UseVisualStyleBackColor = False
        ' 
        ' btnManagePeriod
        ' 
        btnManagePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnManagePeriod.BackColor = Color.FromArgb(CByte(30), CByte(245), CByte(158), CByte(11))
        btnManagePeriod.Cursor = Cursors.Hand
        btnManagePeriod.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(245), CByte(158), CByte(11))
        btnManagePeriod.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(50), CByte(245), CByte(158), CByte(11))
        btnManagePeriod.FlatStyle = FlatStyle.Flat
        btnManagePeriod.Font = New Font("Microsoft YaHei UI", 9F)
        btnManagePeriod.ForeColor = Color.FromArgb(CByte(245), CByte(158), CByte(11))
        btnManagePeriod.Location = New Point(1084, 11)
        btnManagePeriod.Name = "btnManagePeriod"
        btnManagePeriod.Size = New Size(140, 30)
        btnManagePeriod.TabIndex = 5
        btnManagePeriod.Text = "⚙  Quản lý kỳ lương"
        btnManagePeriod.UseVisualStyleBackColor = False
        ' 
        ' btnPrintSlip
        ' 
        btnPrintSlip.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnPrintSlip.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPrintSlip.Cursor = Cursors.Hand
        btnPrintSlip.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPrintSlip.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnPrintSlip.FlatStyle = FlatStyle.Flat
        btnPrintSlip.Font = New Font("Microsoft YaHei UI", 9F)
        btnPrintSlip.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPrintSlip.Location = New Point(974, 11)
        btnPrintSlip.Name = "btnPrintSlip"
        btnPrintSlip.Size = New Size(100, 30)
        btnPrintSlip.TabIndex = 4
        btnPrintSlip.Text = "In phiếu"
        btnPrintSlip.UseVisualStyleBackColor = False
        ' 
        ' btnExportExcel
        ' 
        btnExportExcel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExportExcel.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnExportExcel.Cursor = Cursors.Hand
        btnExportExcel.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnExportExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnExportExcel.FlatStyle = FlatStyle.Flat
        btnExportExcel.Font = New Font("Microsoft YaHei UI", 9F)
        btnExportExcel.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnExportExcel.Location = New Point(854, 11)
        btnExportExcel.Name = "btnExportExcel"
        btnExportExcel.Size = New Size(110, 30)
        btnExportExcel.TabIndex = 3
        btnExportExcel.Text = "Xuất Excel"
        btnExportExcel.UseVisualStyleBackColor = False
        ' 
        ' cboDept
        ' 
        cboDept.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDept.DropDownStyle = ComboBoxStyle.DropDownList
        cboDept.FlatStyle = FlatStyle.Flat
        cboDept.Font = New Font("Microsoft YaHei UI", 9F)
        cboDept.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDept.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        cboDept.Location = New Point(442, 11)
        cboDept.Name = "cboDept"
        cboDept.Size = New Size(160, 28)
        cboDept.TabIndex = 2
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Microsoft YaHei UI", 10F)
        txtSearch.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtSearch.Location = New Point(232, 11)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(200, 28)
        txtSearch.TabIndex = 1
        ' 
        ' cboPeriodSel
        ' 
        cboPeriodSel.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboPeriodSel.DropDownStyle = ComboBoxStyle.DropDownList
        cboPeriodSel.FlatStyle = FlatStyle.Flat
        cboPeriodSel.Font = New Font("Microsoft YaHei UI", 9F)
        cboPeriodSel.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboPeriodSel.Items.AddRange(New Object() {"Tháng 3/2026 (hiện tại)", "Tháng 2/2026", "Tháng 1/2026"})
        cboPeriodSel.Location = New Point(12, 11)
        cboPeriodSel.Name = "cboPeriodSel"
        cboPeriodSel.Size = New Size(210, 28)
        cboPeriodSel.TabIndex = 0
        ' 
        ' formPayroll
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(284, 261)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "formPayroll"
        Text = "Bảng lương"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTab3.ResumeLayout(False)
        pnlSlipRight.ResumeLayout(False)
        pnlSlipScroll.ResumeLayout(False)
        pnlSlipCard.ResumeLayout(False)
        pnlSlipFooter.ResumeLayout(False)
        pnlSlipFooter.PerformLayout()
        pnlSlipBody.ResumeLayout(False)
        pnlSlipDeductSection.ResumeLayout(False)
        pnlSlipDeductSection.PerformLayout()
        pnlSlipIncomeSection.ResumeLayout(False)
        pnlSlipIncomeSection.PerformLayout()
        pnlSlipCardHeader.ResumeLayout(False)
        pnlSlipCardHeader.PerformLayout()
        pnlSlipActions.ResumeLayout(False)
        pnlSlipLeft.ResumeLayout(False)
        pnlTab2.ResumeLayout(False)
        CType(dgvPayroll, ComponentModel.ISupportInitialize).EndInit()
        pnlPayFooter.ResumeLayout(False)
        pnlPayFooter.PerformLayout()
        pnlPayPageBtns.ResumeLayout(False)
        pnlPayrollHeader.ResumeLayout(False)
        pnlPayrollHeader.PerformLayout()
        pnlSummaryChips.ResumeLayout(False)
        pnlSummaryChips.PerformLayout()
        pnlTab1.ResumeLayout(False)
        pnlT1Right.ResumeLayout(False)
        pnlPeriodFormScroll.ResumeLayout(False)
        tlpPeriodForm.ResumeLayout(False)
        tlpPeriodForm.PerformLayout()
        pnlPeriodFooter.ResumeLayout(False)
        pnlPeriodHeader.ResumeLayout(False)
        pnlKpiRow.ResumeLayout(False)
        pnlKpi4.ResumeLayout(False)
        pnlKpi4.PerformLayout()
        pnlKpi3.ResumeLayout(False)
        pnlKpi3.PerformLayout()
        pnlKpi2.ResumeLayout(False)
        pnlKpi2.PerformLayout()
        pnlKpi1.ResumeLayout(False)
        pnlKpi1.PerformLayout()
        pnlPeriodHdrLeft.ResumeLayout(False)
        pnlPeriodHdrLeft.PerformLayout()
        pnlT1Left.ResumeLayout(False)
        pnlT1AddBtn.ResumeLayout(False)
        pnlTabBar.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' ── Declarations ──────────────────────────────────────────
    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents cboPeriodSel As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrintSlip As System.Windows.Forms.Button
    Friend WithEvents btnManagePeriod As System.Windows.Forms.Button
    Friend WithEvents btnCalcPayroll As System.Windows.Forms.Button
    Friend WithEvents pnlTabBar As System.Windows.Forms.Panel
    Friend WithEvents btnTab1 As System.Windows.Forms.Button
    Friend WithEvents btnTab2 As System.Windows.Forms.Button
    Friend WithEvents btnTab3 As System.Windows.Forms.Button
    Friend WithEvents pnlTabIndicator As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlTab1 As System.Windows.Forms.Panel
    Friend WithEvents pnlT1Left As System.Windows.Forms.Panel
    Friend WithEvents lblPeriodListTitle As System.Windows.Forms.Label
    Friend WithEvents flpPeriods As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlT1AddBtn As System.Windows.Forms.Panel
    Friend WithEvents btnAddPeriod As System.Windows.Forms.Button
    Friend WithEvents pnlT1Right As System.Windows.Forms.Panel
    Friend WithEvents pnlPeriodHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlPeriodHdrLeft As System.Windows.Forms.Panel
    Friend WithEvents lblPeriodCode As System.Windows.Forms.Label
    Friend WithEvents lblPeriodSub As System.Windows.Forms.Label
    Friend WithEvents lblPeriodBadge As System.Windows.Forms.Label
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
    Friend WithEvents pnlKpi4 As System.Windows.Forms.Panel
    Friend WithEvents lblKpi4Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi4Val As System.Windows.Forms.Label
    Friend WithEvents pnlPeriodFormScroll As System.Windows.Forms.Panel
    Friend WithEvents tlpPeriodForm As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblPCode As System.Windows.Forms.Label
    Friend WithEvents txtPCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPName As System.Windows.Forms.Label
    Friend WithEvents txtPName As System.Windows.Forms.TextBox
    Friend WithEvents lblPStart As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPEnd As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPMonth As System.Windows.Forms.Label
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPStdHours As System.Windows.Forms.Label
    Friend WithEvents txtStdHours As System.Windows.Forms.TextBox
    Friend WithEvents lblPNote As System.Windows.Forms.Label
    Friend WithEvents txtPNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlPeriodFooter As System.Windows.Forms.Panel
    Friend WithEvents btnDeletePeriod As System.Windows.Forms.Button
    Friend WithEvents btnClosePeriod As System.Windows.Forms.Button
    Friend WithEvents btnSavePeriod As System.Windows.Forms.Button
    Friend WithEvents pnlTab2 As System.Windows.Forms.Panel
    Friend WithEvents pnlPayrollHeader As System.Windows.Forms.Panel
    Friend WithEvents lblPayPeriodBadge As System.Windows.Forms.Label
    Friend WithEvents pnlSummaryChips As System.Windows.Forms.Panel
    Friend WithEvents lblChipIncome As System.Windows.Forms.Label
    Friend WithEvents lblChipDeduct As System.Windows.Forms.Label
    Friend WithEvents lblChipNet As System.Windows.Forms.Label
    Friend WithEvents dgvPayroll As System.Windows.Forms.DataGridView
    Friend WithEvents colChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIncome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlPayFooter As System.Windows.Forms.Panel
    Friend WithEvents lblPayInfo As System.Windows.Forms.Label
    Friend WithEvents pnlPayPageBtns As System.Windows.Forms.Panel
    Friend WithEvents btnPayPrev As System.Windows.Forms.Button
    Friend WithEvents btnPayPage1 As System.Windows.Forms.Button
    Friend WithEvents btnPayPage2 As System.Windows.Forms.Button
    Friend WithEvents btnPayNext As System.Windows.Forms.Button
    Friend WithEvents pnlTab3 As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipLeft As System.Windows.Forms.Panel
    Friend WithEvents lblSlipListTitle As System.Windows.Forms.Label
    Friend WithEvents flpSlipEmps As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSlipRight As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipCard As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipCardHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipAvatar As System.Windows.Forms.Panel
    Friend WithEvents lblSlipEmpName As System.Windows.Forms.Label
    Friend WithEvents lblSlipEmpSub As System.Windows.Forms.Label
    Friend WithEvents lblSlipPeriodInfo As System.Windows.Forms.Label
    Friend WithEvents lblSlipPeriodDates As System.Windows.Forms.Label
    Friend WithEvents pnlSlipBody As System.Windows.Forms.Panel
    Friend WithEvents pnlSlipIncomeSection As System.Windows.Forms.Panel
    Friend WithEvents lblSlipIncomeTitle As System.Windows.Forms.Label
    Friend WithEvents lblSlipIncomeTotal As System.Windows.Forms.Label
    Friend WithEvents flpSlipIncomeItems As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSlipDeductSection As System.Windows.Forms.Panel
    Friend WithEvents lblSlipDeductTitle As System.Windows.Forms.Label
    Friend WithEvents lblSlipDeductTotal As System.Windows.Forms.Label
    Friend WithEvents flpSlipDeductItems As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSlipFooter As System.Windows.Forms.Panel
    Friend WithEvents lblSlipNetLabel As System.Windows.Forms.Label
    Friend WithEvents lblSlipNetVal As System.Windows.Forms.Label
    Friend WithEvents pnlSlipActions As System.Windows.Forms.Panel
    Friend WithEvents btnPrintOne As System.Windows.Forms.Button
    Friend WithEvents btnExportOne As System.Windows.Forms.Button

End Class