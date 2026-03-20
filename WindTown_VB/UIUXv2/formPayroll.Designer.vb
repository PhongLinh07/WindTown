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
        Me.components = New System.ComponentModel.Container()

        ' ── Root ─────────────────────────────────────────────
        Me.pnlRoot = New System.Windows.Forms.Panel()

        ' ── Toolbar ──────────────────────────────────────────
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.cboPeriodSel = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btnPrintSlip = New System.Windows.Forms.Button()
        Me.btnManagePeriod = New System.Windows.Forms.Button()
        Me.btnCalcPayroll = New System.Windows.Forms.Button()

        ' ── Tab bar ──────────────────────────────────────────
        Me.pnlTabBar = New System.Windows.Forms.Panel()
        Me.btnTab1 = New System.Windows.Forms.Button()
        Me.btnTab2 = New System.Windows.Forms.Button()
        Me.btnTab3 = New System.Windows.Forms.Button()
        Me.pnlTabIndicator = New System.Windows.Forms.Panel()

        ' ── Content ──────────────────────────────────────────
        Me.pnlContent = New System.Windows.Forms.Panel()

        ' ══ TAB 1 ════════════════════════════════════════════
        Me.pnlTab1 = New System.Windows.Forms.Panel()
        Me.pnlT1Left = New System.Windows.Forms.Panel()
        Me.lblPeriodListTitle = New System.Windows.Forms.Label()
        Me.flpPeriods = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlT1AddBtn = New System.Windows.Forms.Panel()
        Me.btnAddPeriod = New System.Windows.Forms.Button()
        Me.pnlT1Right = New System.Windows.Forms.Panel()

        ' Period detail header
        Me.pnlPeriodHeader = New System.Windows.Forms.Panel()
        Me.pnlPeriodHdrLeft = New System.Windows.Forms.Panel()
        Me.lblPeriodCode = New System.Windows.Forms.Label()
        Me.lblPeriodSub = New System.Windows.Forms.Label()
        Me.lblPeriodBadge = New System.Windows.Forms.Label()

        ' KPI mini cards
        Me.pnlKpiRow = New System.Windows.Forms.Panel()
        Me.pnlKpi1 = New System.Windows.Forms.Panel()
        Me.lblKpi1Title = New System.Windows.Forms.Label()
        Me.lblKpi1Val = New System.Windows.Forms.Label()
        Me.pnlKpi2 = New System.Windows.Forms.Panel()
        Me.lblKpi2Title = New System.Windows.Forms.Label()
        Me.lblKpi2Val = New System.Windows.Forms.Label()
        Me.pnlKpi3 = New System.Windows.Forms.Panel()
        Me.lblKpi3Title = New System.Windows.Forms.Label()
        Me.lblKpi3Val = New System.Windows.Forms.Label()
        Me.pnlKpi4 = New System.Windows.Forms.Panel()
        Me.lblKpi4Title = New System.Windows.Forms.Label()
        Me.lblKpi4Val = New System.Windows.Forms.Label()

        ' Period form
        Me.pnlPeriodFormScroll = New System.Windows.Forms.Panel()
        Me.tlpPeriodForm = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPCode = New System.Windows.Forms.Label()
        Me.txtPCode = New System.Windows.Forms.TextBox()
        Me.lblPName = New System.Windows.Forms.Label()
        Me.txtPName = New System.Windows.Forms.TextBox()
        Me.lblPStart = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblPEnd = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblPMonth = New System.Windows.Forms.Label()
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker()
        Me.lblPStdHours = New System.Windows.Forms.Label()
        Me.txtStdHours = New System.Windows.Forms.TextBox()
        Me.lblPNote = New System.Windows.Forms.Label()
        Me.txtPNote = New System.Windows.Forms.TextBox()

        ' Period footer
        Me.pnlPeriodFooter = New System.Windows.Forms.Panel()
        Me.btnDeletePeriod = New System.Windows.Forms.Button()
        Me.btnClosePeriod = New System.Windows.Forms.Button()
        Me.btnSavePeriod = New System.Windows.Forms.Button()

        ' ══ TAB 2 ════════════════════════════════════════════
        Me.pnlTab2 = New System.Windows.Forms.Panel()
        Me.pnlPayrollHeader = New System.Windows.Forms.Panel()
        Me.lblPayPeriodBadge = New System.Windows.Forms.Label()
        Me.pnlSummaryChips = New System.Windows.Forms.Panel()
        Me.lblChipIncome = New System.Windows.Forms.Label()
        Me.lblChipDeduct = New System.Windows.Forms.Label()
        Me.lblChipNet = New System.Windows.Forms.Label()
        Me.dgvPayroll = New System.Windows.Forms.DataGridView()
        Me.colChk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colEmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIncome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colView = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPayFooter = New System.Windows.Forms.Panel()
        Me.lblPayInfo = New System.Windows.Forms.Label()
        Me.pnlPayPageBtns = New System.Windows.Forms.Panel()
        Me.btnPayPrev = New System.Windows.Forms.Button()
        Me.btnPayPage1 = New System.Windows.Forms.Button()
        Me.btnPayPage2 = New System.Windows.Forms.Button()
        Me.btnPayNext = New System.Windows.Forms.Button()

        ' ══ TAB 3 ════════════════════════════════════════════
        Me.pnlTab3 = New System.Windows.Forms.Panel()
        Me.pnlSlipLeft = New System.Windows.Forms.Panel()
        Me.lblSlipListTitle = New System.Windows.Forms.Label()
        Me.flpSlipEmps = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSlipRight = New System.Windows.Forms.Panel()
        Me.pnlSlipScroll = New System.Windows.Forms.Panel()
        Me.pnlSlipCard = New System.Windows.Forms.Panel()
        Me.pnlSlipCardHeader = New System.Windows.Forms.Panel()
        Me.pnlSlipAvatar = New System.Windows.Forms.Panel()
        Me.lblSlipEmpName = New System.Windows.Forms.Label()
        Me.lblSlipEmpSub = New System.Windows.Forms.Label()
        Me.lblSlipPeriodInfo = New System.Windows.Forms.Label()
        Me.lblSlipPeriodDates = New System.Windows.Forms.Label()
        Me.pnlSlipBody = New System.Windows.Forms.Panel()
        Me.pnlSlipIncomeSection = New System.Windows.Forms.Panel()
        Me.lblSlipIncomeTitle = New System.Windows.Forms.Label()
        Me.lblSlipIncomeTotal = New System.Windows.Forms.Label()
        Me.flpSlipIncomeItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSlipDeductSection = New System.Windows.Forms.Panel()
        Me.lblSlipDeductTitle = New System.Windows.Forms.Label()
        Me.lblSlipDeductTotal = New System.Windows.Forms.Label()
        Me.flpSlipDeductItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSlipFooter = New System.Windows.Forms.Panel()
        Me.lblSlipNetLabel = New System.Windows.Forms.Label()
        Me.lblSlipNetVal = New System.Windows.Forms.Label()
        Me.pnlSlipActions = New System.Windows.Forms.Panel()
        Me.btnPrintOne = New System.Windows.Forms.Button()
        Me.btnExportOne = New System.Windows.Forms.Button()

        Me.pnlRoot.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlTabBar.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlTab1.SuspendLayout()
        Me.pnlT1Left.SuspendLayout()
        Me.pnlT1AddBtn.SuspendLayout()
        Me.pnlT1Right.SuspendLayout()
        Me.pnlPeriodHeader.SuspendLayout()
        Me.pnlPeriodHdrLeft.SuspendLayout()
        Me.pnlKpiRow.SuspendLayout()
        Me.pnlKpi1.SuspendLayout()
        Me.pnlKpi2.SuspendLayout()
        Me.pnlKpi3.SuspendLayout()
        Me.pnlKpi4.SuspendLayout()
        Me.pnlPeriodFormScroll.SuspendLayout()
        Me.tlpPeriodForm.SuspendLayout()
        Me.pnlPeriodFooter.SuspendLayout()
        Me.pnlTab2.SuspendLayout()
        Me.pnlPayrollHeader.SuspendLayout()
        Me.pnlSummaryChips.SuspendLayout()
        CType(Me.dgvPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPayFooter.SuspendLayout()
        Me.pnlPayPageBtns.SuspendLayout()
        Me.pnlTab3.SuspendLayout()
        Me.pnlSlipLeft.SuspendLayout()
        Me.pnlSlipRight.SuspendLayout()
        Me.pnlSlipScroll.SuspendLayout()
        Me.pnlSlipCard.SuspendLayout()
        Me.pnlSlipCardHeader.SuspendLayout()
        Me.pnlSlipBody.SuspendLayout()
        Me.pnlSlipIncomeSection.SuspendLayout()
        Me.pnlSlipDeductSection.SuspendLayout()
        Me.pnlSlipFooter.SuspendLayout()
        Me.pnlSlipActions.SuspendLayout()
        Me.SuspendLayout()

        ' ╔══════════════════════════════════════╗
        '  ROOT
        ' ╚══════════════════════════════════════╝
        Me.pnlRoot.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlRoot.Controls.Add(Me.pnlContent)
        Me.pnlRoot.Controls.Add(Me.pnlTabBar)
        Me.pnlRoot.Controls.Add(Me.pnlToolbar)
        Me.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRoot.Name = "pnlRoot"

        ' ╔══════════════════════════════════════╗
        '  TOOLBAR
        ' ╚══════════════════════════════════════╝
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlToolbar.Controls.Add(Me.btnCalcPayroll)
        Me.pnlToolbar.Controls.Add(Me.btnManagePeriod)
        Me.pnlToolbar.Controls.Add(Me.btnPrintSlip)
        Me.pnlToolbar.Controls.Add(Me.btnExportExcel)
        Me.pnlToolbar.Controls.Add(Me.cboDept)
        Me.pnlToolbar.Controls.Add(Me.txtSearch)
        Me.pnlToolbar.Controls.Add(Me.cboPeriodSel)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Height = 52
        Me.pnlToolbar.Name = "pnlToolbar"
        '
        'cboPeriodSel
        '
        Me.cboPeriodSel.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.cboPeriodSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPeriodSel.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.cboPeriodSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodSel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.cboPeriodSel.Items.AddRange(New Object() {
            "Tháng 3/2026 (hiện tại)",
            "Tháng 2/2026",
            "Tháng 1/2026"})
        Me.cboPeriodSel.SelectedIndex = 0
        Me.cboPeriodSel.Location = New System.Drawing.Point(12, 11)
        Me.cboPeriodSel.Name = "cboPeriodSel"
        Me.cboPeriodSel.Size = New System.Drawing.Size(210, 30)
        Me.cboPeriodSel.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.txtSearch.Location = New System.Drawing.Point(232, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 30)
        Me.txtSearch.TabIndex = 1
        '
        'cboDept
        '
        Me.cboDept.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.cboDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDept.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.cboDept.Items.AddRange(New Object() {
            "Tất cả phòng ban", "Kỹ thuật", "Kế toán",
            "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        Me.cboDept.SelectedIndex = 0
        Me.cboDept.Location = New System.Drawing.Point(442, 11)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(160, 30)
        Me.cboDept.TabIndex = 2
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80)
        Me.btnExportExcel.FlatAppearance.BorderSize = 1
        Me.btnExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 55, 85)
        Me.btnExportExcel.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.btnExportExcel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.btnExportExcel.Location = New System.Drawing.Point(770, 11)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(110, 30)
        Me.btnExportExcel.TabIndex = 3
        Me.btnExportExcel.Text = "Xuất Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        Me.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnPrintSlip
        '
        Me.btnPrintSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSlip.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.btnPrintSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintSlip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80)
        Me.btnPrintSlip.FlatAppearance.BorderSize = 1
        Me.btnPrintSlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 55, 85)
        Me.btnPrintSlip.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.btnPrintSlip.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.btnPrintSlip.Location = New System.Drawing.Point(890, 11)
        Me.btnPrintSlip.Name = "btnPrintSlip"
        Me.btnPrintSlip.Size = New System.Drawing.Size(100, 30)
        Me.btnPrintSlip.TabIndex = 4
        Me.btnPrintSlip.Text = "In phiếu"
        Me.btnPrintSlip.UseVisualStyleBackColor = False
        Me.btnPrintSlip.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnManagePeriod
        '
        Me.btnManagePeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManagePeriod.BackColor = System.Drawing.Color.FromArgb(30, 245, 158, 11)
        Me.btnManagePeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManagePeriod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 245, 158, 11)
        Me.btnManagePeriod.FlatAppearance.BorderSize = 1
        Me.btnManagePeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 245, 158, 11)
        Me.btnManagePeriod.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11)
        Me.btnManagePeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.btnManagePeriod.Location = New System.Drawing.Point(1000, 11)
        Me.btnManagePeriod.Name = "btnManagePeriod"
        Me.btnManagePeriod.Size = New System.Drawing.Size(140, 30)
        Me.btnManagePeriod.TabIndex = 5
        Me.btnManagePeriod.Text = "⚙  Quản lý kỳ lương"
        Me.btnManagePeriod.UseVisualStyleBackColor = False
        Me.btnManagePeriod.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnCalcPayroll
        '
        Me.btnCalcPayroll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcPayroll.BackColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.btnCalcPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcPayroll.FlatAppearance.BorderSize = 0
        Me.btnCalcPayroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(58, 138, 224)
        Me.btnCalcPayroll.ForeColor = System.Drawing.Color.White
        Me.btnCalcPayroll.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCalcPayroll.Location = New System.Drawing.Point(1150, 11)
        Me.btnCalcPayroll.Name = "btnCalcPayroll"
        Me.btnCalcPayroll.Size = New System.Drawing.Size(120, 30)
        Me.btnCalcPayroll.TabIndex = 6
        Me.btnCalcPayroll.Text = "▶  Tính lương"
        Me.btnCalcPayroll.UseVisualStyleBackColor = False
        Me.btnCalcPayroll.Cursor = System.Windows.Forms.Cursors.Hand

        ' ╔══════════════════════════════════════╗
        '  TAB BAR
        ' ╚══════════════════════════════════════╝
        Me.pnlTabBar.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlTabBar.Controls.Add(Me.pnlTabIndicator)
        Me.pnlTabBar.Controls.Add(Me.btnTab3)
        Me.pnlTabBar.Controls.Add(Me.btnTab2)
        Me.pnlTabBar.Controls.Add(Me.btnTab1)
        Me.pnlTabBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTabBar.Height = 44
        Me.pnlTabBar.Name = "pnlTabBar"
        '
        'btnTab1
        '
        Me.btnTab1.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.btnTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTab1.FlatAppearance.BorderSize = 0
        Me.btnTab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(28, 32, 52)
        Me.btnTab1.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.btnTab1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnTab1.Location = New System.Drawing.Point(0, 0)
        Me.btnTab1.Name = "btnTab1"
        Me.btnTab1.Size = New System.Drawing.Size(160, 42)
        Me.btnTab1.TabIndex = 0
        Me.btnTab1.Text = "Kỳ lương"
        Me.btnTab1.UseVisualStyleBackColor = False
        Me.btnTab1.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnTab2
        '
        Me.btnTab2.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.btnTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTab2.FlatAppearance.BorderSize = 0
        Me.btnTab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(28, 32, 52)
        Me.btnTab2.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.btnTab2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnTab2.Location = New System.Drawing.Point(160, 0)
        Me.btnTab2.Name = "btnTab2"
        Me.btnTab2.Size = New System.Drawing.Size(160, 42)
        Me.btnTab2.TabIndex = 1
        Me.btnTab2.Text = "Bảng lương"
        Me.btnTab2.UseVisualStyleBackColor = False
        Me.btnTab2.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnTab3
        '
        Me.btnTab3.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.btnTab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTab3.FlatAppearance.BorderSize = 0
        Me.btnTab3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(28, 32, 52)
        Me.btnTab3.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.btnTab3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.btnTab3.Location = New System.Drawing.Point(320, 0)
        Me.btnTab3.Name = "btnTab3"
        Me.btnTab3.Size = New System.Drawing.Size(200, 42)
        Me.btnTab3.TabIndex = 2
        Me.btnTab3.Text = "Phiếu lương chi tiết"
        Me.btnTab3.UseVisualStyleBackColor = False
        Me.btnTab3.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'pnlTabIndicator
        '
        Me.pnlTabIndicator.BackColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.pnlTabIndicator.Location = New System.Drawing.Point(160, 41)
        Me.pnlTabIndicator.Name = "pnlTabIndicator"
        Me.pnlTabIndicator.Size = New System.Drawing.Size(160, 3)

        ' ╔══════════════════════════════════════╗
        '  CONTENT
        ' ╚══════════════════════════════════════╝
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlContent.Controls.Add(Me.pnlTab3)
        Me.pnlContent.Controls.Add(Me.pnlTab2)
        Me.pnlContent.Controls.Add(Me.pnlTab1)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Name = "pnlContent"

        ' ╔══════════════════════════════════════╗
        '  TAB 1 — KỲ LƯƠNG
        ' ╚══════════════════════════════════════╝
        Me.pnlTab1.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlTab1.Controls.Add(Me.pnlT1Right)
        Me.pnlTab1.Controls.Add(Me.pnlT1Left)
        Me.pnlTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTab1.Name = "pnlTab1"
        Me.pnlTab1.Visible = False

        ' ── T1 Left ───────────────────────────────────────────
        Me.pnlT1Left.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlT1Left.Controls.Add(Me.flpPeriods)
        Me.pnlT1Left.Controls.Add(Me.pnlT1AddBtn)
        Me.pnlT1Left.Controls.Add(Me.lblPeriodListTitle)
        Me.pnlT1Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlT1Left.Name = "pnlT1Left"
        Me.pnlT1Left.Width = 300
        '
        'lblPeriodListTitle
        '
        Me.lblPeriodListTitle.AutoSize = False
        Me.lblPeriodListTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPeriodListTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodListTitle.ForeColor = System.Drawing.Color.FromArgb(61, 74, 114)
        Me.lblPeriodListTitle.Height = 36
        Me.lblPeriodListTitle.Name = "lblPeriodListTitle"
        Me.lblPeriodListTitle.Padding = New System.Windows.Forms.Padding(12, 12, 0, 0)
        Me.lblPeriodListTitle.Text = "CÁC KỲ LƯƠNG"
        '
        'flpPeriods  — period cards added dynamically
        '
        Me.flpPeriods.AutoScroll = True
        Me.flpPeriods.BackColor = System.Drawing.Color.Transparent
        Me.flpPeriods.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpPeriods.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpPeriods.Name = "flpPeriods"
        Me.flpPeriods.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.flpPeriods.WrapContents = False
        '
        'pnlT1AddBtn
        '
        Me.pnlT1AddBtn.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlT1AddBtn.Controls.Add(Me.btnAddPeriod)
        Me.pnlT1AddBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlT1AddBtn.Height = 54
        Me.pnlT1AddBtn.Name = "pnlT1AddBtn"
        Me.pnlT1AddBtn.Padding = New System.Windows.Forms.Padding(10, 10, 10, 10)
        '
        'btnAddPeriod
        '
        Me.btnAddPeriod.BackColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.btnAddPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddPeriod.FlatAppearance.BorderSize = 0
        Me.btnAddPeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(58, 138, 224)
        Me.btnAddPeriod.ForeColor = System.Drawing.Color.White
        Me.btnAddPeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAddPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddPeriod.Name = "btnAddPeriod"
        Me.btnAddPeriod.TabIndex = 0
        Me.btnAddPeriod.Text = "+ Tạo kỳ lương mới"
        Me.btnAddPeriod.UseVisualStyleBackColor = False
        Me.btnAddPeriod.Cursor = System.Windows.Forms.Cursors.Hand

        ' ── T1 Right ──────────────────────────────────────────
        Me.pnlT1Right.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlT1Right.Controls.Add(Me.pnlPeriodFormScroll)
        Me.pnlT1Right.Controls.Add(Me.pnlPeriodFooter)
        Me.pnlT1Right.Controls.Add(Me.pnlPeriodHeader)
        Me.pnlT1Right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlT1Right.Name = "pnlT1Right"

        ' Period header
        Me.pnlPeriodHeader.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlPeriodHeader.Controls.Add(Me.pnlKpiRow)
        Me.pnlPeriodHeader.Controls.Add(Me.pnlPeriodHdrLeft)
        Me.pnlPeriodHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPeriodHeader.Height = 160
        Me.pnlPeriodHeader.Name = "pnlPeriodHeader"
        Me.pnlPeriodHeader.Padding = New System.Windows.Forms.Padding(18, 14, 18, 10)
        '
        'pnlPeriodHdrLeft
        '
        Me.pnlPeriodHdrLeft.BackColor = System.Drawing.Color.Transparent
        Me.pnlPeriodHdrLeft.Controls.Add(Me.lblPeriodBadge)
        Me.pnlPeriodHdrLeft.Controls.Add(Me.lblPeriodSub)
        Me.pnlPeriodHdrLeft.Controls.Add(Me.lblPeriodCode)
        Me.pnlPeriodHdrLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPeriodHdrLeft.Height = 68
        Me.pnlPeriodHdrLeft.Name = "pnlPeriodHdrLeft"
        '
        'lblPeriodCode
        '
        Me.lblPeriodCode.AutoSize = True
        Me.lblPeriodCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodCode.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.lblPeriodCode.Location = New System.Drawing.Point(0, 0)
        Me.lblPeriodCode.Name = "lblPeriodCode"
        Me.lblPeriodCode.Text = "PP2026-03 — Lương tháng 3/2026"
        '
        'lblPeriodSub
        '
        Me.lblPeriodSub.AutoSize = True
        Me.lblPeriodSub.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.lblPeriodSub.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblPeriodSub.Location = New System.Drawing.Point(2, 36)
        Me.lblPeriodSub.Name = "lblPeriodSub"
        Me.lblPeriodSub.Text = "01/03/2026 → 31/03/2026"
        '
        'lblPeriodBadge
        '
        Me.lblPeriodBadge.AutoSize = True
        Me.lblPeriodBadge.BackColor = System.Drawing.Color.FromArgb(20, 76, 175, 80)
        Me.lblPeriodBadge.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.lblPeriodBadge.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
        Me.lblPeriodBadge.Location = New System.Drawing.Point(2, 54)
        Me.lblPeriodBadge.Name = "lblPeriodBadge"
        Me.lblPeriodBadge.Padding = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.lblPeriodBadge.Text = "● Đang xử lý"

        ' KPI row
        Me.pnlKpiRow.BackColor = System.Drawing.Color.Transparent
        Me.pnlKpiRow.Controls.Add(Me.pnlKpi4)
        Me.pnlKpiRow.Controls.Add(Me.pnlKpi3)
        Me.pnlKpiRow.Controls.Add(Me.pnlKpi2)
        Me.pnlKpiRow.Controls.Add(Me.pnlKpi1)
        Me.pnlKpiRow.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlKpiRow.Height = 76
        Me.pnlKpiRow.Name = "pnlKpiRow"

        ' KPI 1
        Me.pnlKpi1.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlKpi1.Controls.Add(Me.lblKpi1Val)
        Me.pnlKpi1.Controls.Add(Me.lblKpi1Title)
        Me.pnlKpi1.Location = New System.Drawing.Point(0, 0)
        Me.pnlKpi1.Name = "pnlKpi1"
        Me.pnlKpi1.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlKpi1.Size = New System.Drawing.Size(180, 72)

        Me.lblKpi1Title.AutoSize = True
        Me.lblKpi1Title.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblKpi1Title.Location = New System.Drawing.Point(12, 8)
        Me.lblKpi1Title.Name = "lblKpi1Title"
        Me.lblKpi1Title.Text = "NHÂN VIÊN"

        Me.lblKpi1Val.AutoSize = True
        Me.lblKpi1Val.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblKpi1Val.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.lblKpi1Val.Location = New System.Drawing.Point(10, 28)
        Me.lblKpi1Val.Name = "lblKpi1Val"
        Me.lblKpi1Val.Text = "230"

        ' KPI 2
        Me.pnlKpi2.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlKpi2.Controls.Add(Me.lblKpi2Val)
        Me.pnlKpi2.Controls.Add(Me.lblKpi2Title)
        Me.pnlKpi2.Location = New System.Drawing.Point(188, 0)
        Me.pnlKpi2.Name = "pnlKpi2"
        Me.pnlKpi2.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlKpi2.Size = New System.Drawing.Size(180, 72)

        Me.lblKpi2Title.AutoSize = True
        Me.lblKpi2Title.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblKpi2Title.Location = New System.Drawing.Point(12, 8)
        Me.lblKpi2Title.Name = "lblKpi2Title"
        Me.lblKpi2Title.Text = "ĐÃ TÍNH LƯƠNG"

        Me.lblKpi2Val.AutoSize = True
        Me.lblKpi2Val.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblKpi2Val.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
        Me.lblKpi2Val.Location = New System.Drawing.Point(10, 28)
        Me.lblKpi2Val.Name = "lblKpi2Val"
        Me.lblKpi2Val.Text = "228"

        ' KPI 3
        Me.pnlKpi3.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlKpi3.Controls.Add(Me.lblKpi3Val)
        Me.pnlKpi3.Controls.Add(Me.lblKpi3Title)
        Me.pnlKpi3.Location = New System.Drawing.Point(376, 0)
        Me.pnlKpi3.Name = "pnlKpi3"
        Me.pnlKpi3.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlKpi3.Size = New System.Drawing.Size(200, 72)

        Me.lblKpi3Title.AutoSize = True
        Me.lblKpi3Title.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblKpi3Title.Location = New System.Drawing.Point(12, 8)
        Me.lblKpi3Title.Name = "lblKpi3Title"
        Me.lblKpi3Title.Text = "TỔNG CHI LƯƠNG"

        Me.lblKpi3Val.AutoSize = True
        Me.lblKpi3Val.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblKpi3Val.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.lblKpi3Val.Location = New System.Drawing.Point(10, 28)
        Me.lblKpi3Val.Name = "lblKpi3Val"
        Me.lblKpi3Val.Text = "4.2 tỷ"

        ' KPI 4
        Me.pnlKpi4.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlKpi4.Controls.Add(Me.lblKpi4Val)
        Me.pnlKpi4.Controls.Add(Me.lblKpi4Title)
        Me.pnlKpi4.Location = New System.Drawing.Point(584, 0)
        Me.pnlKpi4.Name = "pnlKpi4"
        Me.pnlKpi4.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlKpi4.Size = New System.Drawing.Size(160, 72)

        Me.lblKpi4Title.AutoSize = True
        Me.lblKpi4Title.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
        Me.lblKpi4Title.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblKpi4Title.Location = New System.Drawing.Point(12, 8)
        Me.lblKpi4Title.Name = "lblKpi4Title"
        Me.lblKpi4Title.Text = "GIỜ CHUẨN"

        Me.lblKpi4Val.AutoSize = True
        Me.lblKpi4Val.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblKpi4Val.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.lblKpi4Val.Location = New System.Drawing.Point(10, 28)
        Me.lblKpi4Val.Name = "lblKpi4Val"
        Me.lblKpi4Val.Text = "176 h"

        ' Period form scroll
        Me.pnlPeriodFormScroll.AutoScroll = True
        Me.pnlPeriodFormScroll.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlPeriodFormScroll.Controls.Add(Me.tlpPeriodForm)
        Me.pnlPeriodFormScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPeriodFormScroll.Name = "pnlPeriodFormScroll"
        Me.pnlPeriodFormScroll.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        '
        'tlpPeriodForm
        '
        Me.tlpPeriodForm.BackColor = System.Drawing.Color.Transparent
        Me.tlpPeriodForm.ColumnCount = 2
        Me.tlpPeriodForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPeriodForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPeriodForm.Controls.Add(Me.lblPCode, 0, 0)
        Me.tlpPeriodForm.Controls.Add(Me.txtPCode, 0, 1)
        Me.tlpPeriodForm.Controls.Add(Me.lblPName, 1, 0)
        Me.tlpPeriodForm.Controls.Add(Me.txtPName, 1, 1)
        Me.tlpPeriodForm.Controls.Add(Me.lblPStart, 0, 2)
        Me.tlpPeriodForm.Controls.Add(Me.dtpStart, 0, 3)
        Me.tlpPeriodForm.Controls.Add(Me.lblPEnd, 1, 2)
        Me.tlpPeriodForm.Controls.Add(Me.dtpEnd, 1, 3)
        Me.tlpPeriodForm.Controls.Add(Me.lblPMonth, 0, 4)
        Me.tlpPeriodForm.Controls.Add(Me.dtpMonth, 0, 5)
        Me.tlpPeriodForm.Controls.Add(Me.lblPStdHours, 1, 4)
        Me.tlpPeriodForm.Controls.Add(Me.txtStdHours, 1, 5)
        Me.tlpPeriodForm.Controls.Add(Me.lblPNote, 0, 6)
        Me.tlpPeriodForm.Controls.Add(Me.txtPNote, 0, 7)
        Me.tlpPeriodForm.SetColumnSpan(Me.lblPNote, 2)
        Me.tlpPeriodForm.SetColumnSpan(Me.txtPNote, 2)
        Me.tlpPeriodForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPeriodForm.Height = 340
        Me.tlpPeriodForm.Name = "tlpPeriodForm"
        Me.tlpPeriodForm.RowCount = 8
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPeriodForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPeriodForm.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None

        ' Period form fields
        Me.lblPCode.AutoSize = True : Me.lblPCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPCode.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPCode.Name = "lblPCode" : Me.lblPCode.Text = "Mã kỳ lương  *"
        Me.txtPCode.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.txtPCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle : Me.txtPCode.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtPCode.Font = New System.Drawing.Font("Courier New", 9.5!) : Me.txtPCode.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.txtPCode.Margin = New System.Windows.Forms.Padding(0, 0, 8, 4) : Me.txtPCode.Name = "txtPCode"
        Me.lblPName.AutoSize = True : Me.lblPName.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPName.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPName.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0) : Me.lblPName.Name = "lblPName" : Me.lblPName.Text = "Tên kỳ lương  *"
        Me.txtPName.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.txtPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle : Me.txtPName.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtPName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.txtPName.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240) : Me.txtPName.Margin = New System.Windows.Forms.Padding(8, 0, 0, 4) : Me.txtPName.Name = "txtPName"
        Me.lblPStart.AutoSize = True : Me.lblPStart.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPStart.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPStart.Name = "lblPStart" : Me.lblPStart.Text = "Ngày bắt đầu"
        Me.dtpStart.CustomFormat = "dd/MM/yyyy" : Me.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill : Me.dtpStart.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom : Me.dtpStart.Margin = New System.Windows.Forms.Padding(0, 0, 8, 4) : Me.dtpStart.Name = "dtpStart"
        Me.lblPEnd.AutoSize = True : Me.lblPEnd.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPEnd.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPEnd.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0) : Me.lblPEnd.Name = "lblPEnd" : Me.lblPEnd.Text = "Ngày kết thúc"
        Me.dtpEnd.CustomFormat = "dd/MM/yyyy" : Me.dtpEnd.Dock = System.Windows.Forms.DockStyle.Fill : Me.dtpEnd.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom : Me.dtpEnd.Margin = New System.Windows.Forms.Padding(8, 0, 0, 4) : Me.dtpEnd.Name = "dtpEnd"
        Me.lblPMonth.AutoSize = True : Me.lblPMonth.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPMonth.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPMonth.Name = "lblPMonth" : Me.lblPMonth.Text = "Tháng tính lương"
        Me.dtpMonth.CustomFormat = "MM/yyyy" : Me.dtpMonth.Dock = System.Windows.Forms.DockStyle.Fill : Me.dtpMonth.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom : Me.dtpMonth.Margin = New System.Windows.Forms.Padding(0, 0, 8, 4) : Me.dtpMonth.Name = "dtpMonth"
        Me.lblPStdHours.AutoSize = True : Me.lblPStdHours.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPStdHours.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPStdHours.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0) : Me.lblPStdHours.Name = "lblPStdHours" : Me.lblPStdHours.Text = "Giờ chuẩn (std_hours)"
        Me.txtStdHours.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.txtStdHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle : Me.txtStdHours.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtStdHours.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.txtStdHours.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240) : Me.txtStdHours.Margin = New System.Windows.Forms.Padding(8, 0, 0, 4) : Me.txtStdHours.Name = "txtStdHours" : Me.txtStdHours.Text = "176"
        Me.lblPNote.AutoSize = True : Me.lblPNote.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblPNote.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPNote.Name = "lblPNote" : Me.lblPNote.Text = "Ghi chú"
        Me.txtPNote.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.txtPNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle : Me.txtPNote.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtPNote.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!) : Me.txtPNote.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240) : Me.txtPNote.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4) : Me.txtPNote.Name = "txtPNote"

        ' Period footer
        Me.pnlPeriodFooter.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlPeriodFooter.Controls.Add(Me.btnSavePeriod)
        Me.pnlPeriodFooter.Controls.Add(Me.btnClosePeriod)
        Me.pnlPeriodFooter.Controls.Add(Me.btnDeletePeriod)
        Me.pnlPeriodFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPeriodFooter.Height = 52
        Me.pnlPeriodFooter.Name = "pnlPeriodFooter"
        '
        'btnDeletePeriod
        '
        Me.btnDeletePeriod.BackColor = System.Drawing.Color.FromArgb(25, 229, 62, 62)
        Me.btnDeletePeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeletePeriod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 229, 62, 62)
        Me.btnDeletePeriod.FlatAppearance.BorderSize = 1
        Me.btnDeletePeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 229, 62, 62)
        Me.btnDeletePeriod.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
        Me.btnDeletePeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.btnDeletePeriod.Location = New System.Drawing.Point(14, 10)
        Me.btnDeletePeriod.Name = "btnDeletePeriod"
        Me.btnDeletePeriod.Size = New System.Drawing.Size(120, 32)
        Me.btnDeletePeriod.TabIndex = 0
        Me.btnDeletePeriod.Text = "Xóa kỳ lương"
        Me.btnDeletePeriod.UseVisualStyleBackColor = False
        Me.btnDeletePeriod.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnClosePeriod
        '
        Me.btnClosePeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClosePeriod.BackColor = System.Drawing.Color.FromArgb(30, 245, 158, 11)
        Me.btnClosePeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClosePeriod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 245, 158, 11)
        Me.btnClosePeriod.FlatAppearance.BorderSize = 1
        Me.btnClosePeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 245, 158, 11)
        Me.btnClosePeriod.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11)
        Me.btnClosePeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClosePeriod.Location = New System.Drawing.Point(990, 10)
        Me.btnClosePeriod.Name = "btnClosePeriod"
        Me.btnClosePeriod.Size = New System.Drawing.Size(130, 32)
        Me.btnClosePeriod.TabIndex = 1
        Me.btnClosePeriod.Text = "Chốt kỳ lương"
        Me.btnClosePeriod.UseVisualStyleBackColor = False
        Me.btnClosePeriod.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'btnSavePeriod
        '
        Me.btnSavePeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavePeriod.BackColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.btnSavePeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePeriod.FlatAppearance.BorderSize = 0
        Me.btnSavePeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(58, 138, 224)
        Me.btnSavePeriod.ForeColor = System.Drawing.Color.White
        Me.btnSavePeriod.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSavePeriod.Location = New System.Drawing.Point(1130, 10)
        Me.btnSavePeriod.Name = "btnSavePeriod"
        Me.btnSavePeriod.Size = New System.Drawing.Size(130, 32)
        Me.btnSavePeriod.TabIndex = 2
        Me.btnSavePeriod.Text = "Lưu thông tin"
        Me.btnSavePeriod.UseVisualStyleBackColor = False
        Me.btnSavePeriod.Cursor = System.Windows.Forms.Cursors.Hand

        ' ╔══════════════════════════════════════╗
        '  TAB 2 — BẢNG LƯƠNG
        ' ╚══════════════════════════════════════╝
        Me.pnlTab2.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlTab2.Controls.Add(Me.dgvPayroll)
        Me.pnlTab2.Controls.Add(Me.pnlPayFooter)
        Me.pnlTab2.Controls.Add(Me.pnlPayrollHeader)
        Me.pnlTab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTab2.Name = "pnlTab2"
        Me.pnlTab2.Visible = True
        '
        'pnlPayrollHeader
        '
        Me.pnlPayrollHeader.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlPayrollHeader.Controls.Add(Me.pnlSummaryChips)
        Me.pnlPayrollHeader.Controls.Add(Me.lblPayPeriodBadge)
        Me.pnlPayrollHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPayrollHeader.Height = 48
        Me.pnlPayrollHeader.Name = "pnlPayrollHeader"
        Me.pnlPayrollHeader.Padding = New System.Windows.Forms.Padding(14, 10, 14, 10)
        '
        'lblPayPeriodBadge
        '
        Me.lblPayPeriodBadge.AutoSize = True
        Me.lblPayPeriodBadge.BackColor = System.Drawing.Color.FromArgb(15, 74, 158, 255)
        Me.lblPayPeriodBadge.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblPayPeriodBadge.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.lblPayPeriodBadge.Location = New System.Drawing.Point(14, 11)
        Me.lblPayPeriodBadge.Name = "lblPayPeriodBadge"
        Me.lblPayPeriodBadge.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblPayPeriodBadge.Text = "PP2026-03  —  Tháng 3/2026"
        '
        'pnlSummaryChips
        '
        Me.pnlSummaryChips.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSummaryChips.BackColor = System.Drawing.Color.Transparent
        Me.pnlSummaryChips.Controls.Add(Me.lblChipNet)
        Me.pnlSummaryChips.Controls.Add(Me.lblChipDeduct)
        Me.pnlSummaryChips.Controls.Add(Me.lblChipIncome)
        Me.pnlSummaryChips.Location = New System.Drawing.Point(700, 6)
        Me.pnlSummaryChips.Name = "pnlSummaryChips"
        Me.pnlSummaryChips.Size = New System.Drawing.Size(560, 36)
        '
        'lblChipIncome
        '
        Me.lblChipIncome.AutoSize = True
        Me.lblChipIncome.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.lblChipIncome.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.lblChipIncome.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblChipIncome.Location = New System.Drawing.Point(0, 8)
        Me.lblChipIncome.Name = "lblChipIncome"
        Me.lblChipIncome.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblChipIncome.Text = "Thu nhập:  4.85 tỷ"
        '
        'lblChipDeduct
        '
        Me.lblChipDeduct.AutoSize = True
        Me.lblChipDeduct.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.lblChipDeduct.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.lblChipDeduct.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblChipDeduct.Location = New System.Drawing.Point(170, 8)
        Me.lblChipDeduct.Name = "lblChipDeduct"
        Me.lblChipDeduct.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblChipDeduct.Text = "Khấu trừ:  -650 tr"
        '
        'lblChipNet
        '
        Me.lblChipNet.AutoSize = True
        Me.lblChipNet.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.lblChipNet.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.lblChipNet.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.lblChipNet.Location = New System.Drawing.Point(340, 8)
        Me.lblChipNet.Name = "lblChipNet"
        Me.lblChipNet.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblChipNet.Text = "Thực lãnh:  4.2 tỷ"
        '
        'dgvPayroll
        '
        Me.dgvPayroll.AllowUserToAddRows = False
        Me.dgvPayroll.AllowUserToDeleteRows = False
        Me.dgvPayroll.AllowUserToResizeRows = False
        Me.dgvPayroll.BackgroundColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.dgvPayroll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPayroll.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPayroll.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPayroll.ColumnHeadersHeight = 40
        Me.dgvPayroll.EnableHeadersVisualStyles = False
        Me.dgvPayroll.GridColor = System.Drawing.Color.FromArgb(42, 48, 80)
        Me.dgvPayroll.MultiSelect = True
        Me.dgvPayroll.ReadOnly = False
        Me.dgvPayroll.RowHeadersVisible = False
        Me.dgvPayroll.RowTemplate.Height = 50
        Me.dgvPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPayroll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPayroll.Location = New System.Drawing.Point(0, 48)
        Me.dgvPayroll.Name = "dgvPayroll"
        Me.dgvPayroll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvPayroll.TabIndex = 0
        Me.dgvPayroll.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.dgvPayroll.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.dgvPayroll.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 74, 158, 255)
        Me.dgvPayroll.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.dgvPayroll.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.dgvPayroll.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.dgvPayroll.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(32, 36, 55)
        Me.dgvPayroll.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.dgvPayroll.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 74, 158, 255)
        Me.dgvPayroll.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.dgvPayroll.ColumnHeadersDefaultCellStyle.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        '
        'colChk
        '
        Me.colChk.HeaderText = "" : Me.colChk.Name = "colChk" : Me.colChk.Width = 36 : Me.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.False
        '
        'colEmpName
        '
        Me.colEmpName.HeaderText = "NHÂN VIÊN" : Me.colEmpName.Name = "colEmpName" : Me.colEmpName.Width = 200 : Me.colEmpName.ReadOnly = True
        '
        'colDept
        '
        Me.colDept.HeaderText = "PHÒNG BAN" : Me.colDept.Name = "colDept" : Me.colDept.Width = 110 : Me.colDept.ReadOnly = True : Me.colDept.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        '
        'colJob
        '
        Me.colJob.HeaderText = "VỊ TRÍ" : Me.colJob.Name = "colJob" : Me.colJob.Width = 160 : Me.colJob.ReadOnly = True : Me.colJob.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        '
        'colBase
        '
        Me.colBase.HeaderText = "LƯƠNG CB" : Me.colBase.Name = "colBase" : Me.colBase.Width = 110 : Me.colBase.ReadOnly = True : Me.colBase.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight : Me.colBase.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        '
        'colIncome
        '
        Me.colIncome.HeaderText = "THU NHẬP" : Me.colIncome.Name = "colIncome" : Me.colIncome.Width = 120 : Me.colIncome.ReadOnly = True : Me.colIncome.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight : Me.colIncome.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
        '
        'colDeduct
        '
        Me.colDeduct.HeaderText = "KHẤU TRỪ" : Me.colDeduct.Name = "colDeduct" : Me.colDeduct.Width = 110 : Me.colDeduct.ReadOnly = True : Me.colDeduct.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight : Me.colDeduct.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
        '
        'colNet
        '
        Me.colNet.HeaderText = "THỰC LÃNH" : Me.colNet.Name = "colNet" : Me.colNet.Width = 130 : Me.colNet.ReadOnly = True : Me.colNet.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight : Me.colNet.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.colNet.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'colPayStatus
        '
        Me.colPayStatus.HeaderText = "TRẠNG THÁI" : Me.colPayStatus.Name = "colPayStatus" : Me.colPayStatus.Width = 110 : Me.colPayStatus.ReadOnly = True
        '
        'colView
        '
        Me.colView.HeaderText = "" : Me.colView.Name = "colView" : Me.colView.Width = 70 : Me.colView.ReadOnly = True : Me.colView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.colView.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter : Me.colView.Resizable = System.Windows.Forms.DataGridViewTriState.False

        Me.dgvPayroll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {
            Me.colChk, Me.colEmpName, Me.colDept, Me.colJob,
            Me.colBase, Me.colIncome, Me.colDeduct, Me.colNet,
            Me.colPayStatus, Me.colView
        })
        '
        'pnlPayFooter
        '
        Me.pnlPayFooter.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlPayFooter.Controls.Add(Me.pnlPayPageBtns)
        Me.pnlPayFooter.Controls.Add(Me.lblPayInfo)
        Me.pnlPayFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPayFooter.Height = 44
        Me.pnlPayFooter.Name = "pnlPayFooter"

        Me.lblPayInfo.AutoSize = True : Me.lblPayInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.lblPayInfo.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblPayInfo.Location = New System.Drawing.Point(16, 14) : Me.lblPayInfo.Name = "lblPayInfo" : Me.lblPayInfo.Text = "Hiển thị 0 nhân viên"

        Me.pnlPayPageBtns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPayPageBtns.BackColor = System.Drawing.Color.Transparent
        Me.pnlPayPageBtns.Controls.Add(Me.btnPayNext)
        Me.pnlPayPageBtns.Controls.Add(Me.btnPayPage2)
        Me.pnlPayPageBtns.Controls.Add(Me.btnPayPage1)
        Me.pnlPayPageBtns.Controls.Add(Me.btnPayPrev)
        Me.pnlPayPageBtns.Location = New System.Drawing.Point(1060, 7)
        Me.pnlPayPageBtns.Name = "pnlPayPageBtns"
        Me.pnlPayPageBtns.Size = New System.Drawing.Size(130, 30)

        Me.btnPayPrev.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.btnPayPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnPayPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80) : Me.btnPayPrev.FlatAppearance.BorderSize = 1 : Me.btnPayPrev.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.btnPayPrev.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.btnPayPrev.Location = New System.Drawing.Point(0, 0) : Me.btnPayPrev.Name = "btnPayPrev" : Me.btnPayPrev.Size = New System.Drawing.Size(30, 30) : Me.btnPayPrev.Text = "‹" : Me.btnPayPrev.UseVisualStyleBackColor = False : Me.btnPayPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayPage1.BackColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.btnPayPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnPayPage1.FlatAppearance.BorderSize = 0 : Me.btnPayPage1.ForeColor = System.Drawing.Color.White : Me.btnPayPage1.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.btnPayPage1.Location = New System.Drawing.Point(34, 0) : Me.btnPayPage1.Name = "btnPayPage1" : Me.btnPayPage1.Size = New System.Drawing.Size(30, 30) : Me.btnPayPage1.Text = "1" : Me.btnPayPage1.UseVisualStyleBackColor = False : Me.btnPayPage1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayPage2.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.btnPayPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnPayPage2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80) : Me.btnPayPage2.FlatAppearance.BorderSize = 1 : Me.btnPayPage2.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.btnPayPage2.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.btnPayPage2.Location = New System.Drawing.Point(68, 0) : Me.btnPayPage2.Name = "btnPayPage2" : Me.btnPayPage2.Size = New System.Drawing.Size(30, 30) : Me.btnPayPage2.Text = "2" : Me.btnPayPage2.UseVisualStyleBackColor = False : Me.btnPayPage2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayNext.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.btnPayNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnPayNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80) : Me.btnPayNext.FlatAppearance.BorderSize = 1 : Me.btnPayNext.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.btnPayNext.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.btnPayNext.Location = New System.Drawing.Point(102, 0) : Me.btnPayNext.Name = "btnPayNext" : Me.btnPayNext.Size = New System.Drawing.Size(30, 30) : Me.btnPayNext.Text = "›" : Me.btnPayNext.UseVisualStyleBackColor = False : Me.btnPayNext.Cursor = System.Windows.Forms.Cursors.Hand

        ' ╔══════════════════════════════════════╗
        '  TAB 3 — PHIẾU LƯƠNG
        ' ╚══════════════════════════════════════╝
        Me.pnlTab3.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlTab3.Controls.Add(Me.pnlSlipRight)
        Me.pnlTab3.Controls.Add(Me.pnlSlipLeft)
        Me.pnlTab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTab3.Name = "pnlTab3"
        Me.pnlTab3.Visible = False

        ' ── Slip Left ─────────────────────────────────────────
        Me.pnlSlipLeft.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlSlipLeft.Controls.Add(Me.flpSlipEmps)
        Me.pnlSlipLeft.Controls.Add(Me.lblSlipListTitle)
        Me.pnlSlipLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSlipLeft.Name = "pnlSlipLeft"
        Me.pnlSlipLeft.Width = 260

        Me.lblSlipListTitle.AutoSize = False : Me.lblSlipListTitle.Dock = System.Windows.Forms.DockStyle.Top : Me.lblSlipListTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipListTitle.ForeColor = System.Drawing.Color.FromArgb(61, 74, 114) : Me.lblSlipListTitle.Height = 36 : Me.lblSlipListTitle.Name = "lblSlipListTitle" : Me.lblSlipListTitle.Padding = New System.Windows.Forms.Padding(12, 12, 0, 0) : Me.lblSlipListTitle.Text = "CHỌN NHÂN VIÊN"

        Me.flpSlipEmps.AutoScroll = True : Me.flpSlipEmps.BackColor = System.Drawing.Color.Transparent : Me.flpSlipEmps.Dock = System.Windows.Forms.DockStyle.Fill : Me.flpSlipEmps.FlowDirection = System.Windows.Forms.FlowDirection.TopDown : Me.flpSlipEmps.Name = "flpSlipEmps" : Me.flpSlipEmps.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6) : Me.flpSlipEmps.WrapContents = False

        ' ── Slip Right ────────────────────────────────────────
        Me.pnlSlipRight.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlSlipRight.Controls.Add(Me.pnlSlipScroll)
        Me.pnlSlipRight.Controls.Add(Me.pnlSlipActions)
        Me.pnlSlipRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSlipRight.Name = "pnlSlipRight"

        Me.pnlSlipActions.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlSlipActions.Controls.Add(Me.btnExportOne)
        Me.pnlSlipActions.Controls.Add(Me.btnPrintOne)
        Me.pnlSlipActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSlipActions.Height = 52
        Me.pnlSlipActions.Name = "pnlSlipActions"

        Me.btnPrintOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintOne.BackColor = System.Drawing.Color.FromArgb(38, 43, 66) : Me.btnPrintOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnPrintOne.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80) : Me.btnPrintOne.FlatAppearance.BorderSize = 1 : Me.btnPrintOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 55, 85) : Me.btnPrintOne.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.btnPrintOne.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!) : Me.btnPrintOne.Location = New System.Drawing.Point(1020, 10) : Me.btnPrintOne.Name = "btnPrintOne" : Me.btnPrintOne.Size = New System.Drawing.Size(110, 32) : Me.btnPrintOne.TabIndex = 0 : Me.btnPrintOne.Text = "In phiếu" : Me.btnPrintOne.UseVisualStyleBackColor = False : Me.btnPrintOne.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportOne.BackColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.btnExportOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat : Me.btnExportOne.FlatAppearance.BorderSize = 0 : Me.btnExportOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(58, 138, 224) : Me.btnExportOne.ForeColor = System.Drawing.Color.White : Me.btnExportOne.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold) : Me.btnExportOne.Location = New System.Drawing.Point(1140, 10) : Me.btnExportOne.Name = "btnExportOne" : Me.btnExportOne.Size = New System.Drawing.Size(120, 32) : Me.btnExportOne.TabIndex = 1 : Me.btnExportOne.Text = "Xuất PDF" : Me.btnExportOne.UseVisualStyleBackColor = False : Me.btnExportOne.Cursor = System.Windows.Forms.Cursors.Hand

        Me.pnlSlipScroll.AutoScroll = True
        Me.pnlSlipScroll.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.pnlSlipScroll.Controls.Add(Me.pnlSlipCard)
        Me.pnlSlipScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSlipScroll.Name = "pnlSlipScroll"
        Me.pnlSlipScroll.Padding = New System.Windows.Forms.Padding(20, 16, 20, 16)

        ' Slip card
        Me.pnlSlipCard.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlSlipCard.Controls.Add(Me.pnlSlipFooter)
        Me.pnlSlipCard.Controls.Add(Me.pnlSlipBody)
        Me.pnlSlipCard.Controls.Add(Me.pnlSlipCardHeader)
        Me.pnlSlipCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSlipCard.Name = "pnlSlipCard"
        Me.pnlSlipCard.Height = 600

        ' Slip card header
        Me.pnlSlipCardHeader.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.pnlSlipCardHeader.Controls.Add(Me.lblSlipPeriodDates)
        Me.pnlSlipCardHeader.Controls.Add(Me.lblSlipPeriodInfo)
        Me.pnlSlipCardHeader.Controls.Add(Me.pnlSlipAvatar)
        Me.pnlSlipCardHeader.Controls.Add(Me.lblSlipEmpSub)
        Me.pnlSlipCardHeader.Controls.Add(Me.lblSlipEmpName)
        Me.pnlSlipCardHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSlipCardHeader.Height = 88
        Me.pnlSlipCardHeader.Name = "pnlSlipCardHeader"
        Me.pnlSlipCardHeader.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)

        Me.pnlSlipAvatar.BackColor = System.Drawing.Color.FromArgb(59, 125, 216)
        Me.pnlSlipAvatar.Location = New System.Drawing.Point(18, 16)
        Me.pnlSlipAvatar.Name = "pnlSlipAvatar"
        Me.pnlSlipAvatar.Size = New System.Drawing.Size(52, 52)

        Me.lblSlipEmpName.AutoSize = True : Me.lblSlipEmpName.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipEmpName.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240) : Me.lblSlipEmpName.Location = New System.Drawing.Point(80, 16) : Me.lblSlipEmpName.Name = "lblSlipEmpName" : Me.lblSlipEmpName.Text = "Nguyễn Văn An"
        Me.lblSlipEmpSub.AutoSize = True : Me.lblSlipEmpSub.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!) : Me.lblSlipEmpSub.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblSlipEmpSub.Location = New System.Drawing.Point(82, 44) : Me.lblSlipEmpSub.Name = "lblSlipEmpSub" : Me.lblSlipEmpSub.Text = "Kỹ thuật  ·  Lập trình viên"

        Me.lblSlipPeriodInfo.AutoSize = True : Me.lblSlipPeriodInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipPeriodInfo.ForeColor = System.Drawing.Color.FromArgb(197, 213, 240) : Me.lblSlipPeriodInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles) : Me.lblSlipPeriodInfo.Location = New System.Drawing.Point(700, 16) : Me.lblSlipPeriodInfo.Name = "lblSlipPeriodInfo" : Me.lblSlipPeriodInfo.Text = "PP2026-03  —  Lương tháng 3/2026"
        Me.lblSlipPeriodDates.AutoSize = True : Me.lblSlipPeriodDates.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!) : Me.lblSlipPeriodDates.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178) : Me.lblSlipPeriodDates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles) : Me.lblSlipPeriodDates.Location = New System.Drawing.Point(700, 44) : Me.lblSlipPeriodDates.Name = "lblSlipPeriodDates" : Me.lblSlipPeriodDates.Text = "01/03/2026 → 31/03/2026  ·  176 giờ chuẩn"

        ' Slip body
        Me.pnlSlipBody.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlSlipBody.Controls.Add(Me.pnlSlipDeductSection)
        Me.pnlSlipBody.Controls.Add(Me.pnlSlipIncomeSection)
        Me.pnlSlipBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSlipBody.Name = "pnlSlipBody"

        ' Income section
        Me.pnlSlipIncomeSection.BackColor = System.Drawing.Color.Transparent
        Me.pnlSlipIncomeSection.Controls.Add(Me.flpSlipIncomeItems)
        Me.pnlSlipIncomeSection.Controls.Add(Me.lblSlipIncomeTotal)
        Me.pnlSlipIncomeSection.Controls.Add(Me.lblSlipIncomeTitle)
        Me.pnlSlipIncomeSection.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSlipIncomeSection.Name = "pnlSlipIncomeSection"
        Me.pnlSlipIncomeSection.Padding = New System.Windows.Forms.Padding(18, 12, 18, 8)
        Me.pnlSlipIncomeSection.Height = 260

        Me.lblSlipIncomeTitle.AutoSize = True : Me.lblSlipIncomeTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblSlipIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(61, 74, 114) : Me.lblSlipIncomeTitle.Location = New System.Drawing.Point(18, 12) : Me.lblSlipIncomeTitle.Name = "lblSlipIncomeTitle" : Me.lblSlipIncomeTitle.Text = "THU NHẬP"
        Me.lblSlipIncomeTotal.AutoSize = True : Me.lblSlipIncomeTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipIncomeTotal.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80) : Me.lblSlipIncomeTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles) : Me.lblSlipIncomeTotal.Location = New System.Drawing.Point(800, 12) : Me.lblSlipIncomeTotal.Name = "lblSlipIncomeTotal" : Me.lblSlipIncomeTotal.Text = "+17,500,000đ"

        Me.flpSlipIncomeItems.AutoScroll = False : Me.flpSlipIncomeItems.BackColor = System.Drawing.Color.Transparent : Me.flpSlipIncomeItems.Dock = System.Windows.Forms.DockStyle.Bottom : Me.flpSlipIncomeItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown : Me.flpSlipIncomeItems.Height = 230 : Me.flpSlipIncomeItems.Name = "flpSlipIncomeItems" : Me.flpSlipIncomeItems.WrapContents = False

        ' Deduct section
        Me.pnlSlipDeductSection.BackColor = System.Drawing.Color.Transparent
        Me.pnlSlipDeductSection.Controls.Add(Me.flpSlipDeductItems)
        Me.pnlSlipDeductSection.Controls.Add(Me.lblSlipDeductTotal)
        Me.pnlSlipDeductSection.Controls.Add(Me.lblSlipDeductTitle)
        Me.pnlSlipDeductSection.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSlipDeductSection.Name = "pnlSlipDeductSection"
        Me.pnlSlipDeductSection.Padding = New System.Windows.Forms.Padding(18, 12, 18, 8)
        Me.pnlSlipDeductSection.Height = 180

        Me.lblSlipDeductTitle.AutoSize = True : Me.lblSlipDeductTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold) : Me.lblSlipDeductTitle.ForeColor = System.Drawing.Color.FromArgb(61, 74, 114) : Me.lblSlipDeductTitle.Location = New System.Drawing.Point(18, 12) : Me.lblSlipDeductTitle.Name = "lblSlipDeductTitle" : Me.lblSlipDeductTitle.Text = "KHẤU TRỪ"
        Me.lblSlipDeductTotal.AutoSize = True : Me.lblSlipDeductTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipDeductTotal.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128) : Me.lblSlipDeductTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles) : Me.lblSlipDeductTotal.Location = New System.Drawing.Point(800, 12) : Me.lblSlipDeductTotal.Name = "lblSlipDeductTotal" : Me.lblSlipDeductTotal.Text = "-1,875,000đ"

        Me.flpSlipDeductItems.AutoScroll = False : Me.flpSlipDeductItems.BackColor = System.Drawing.Color.Transparent : Me.flpSlipDeductItems.Dock = System.Windows.Forms.DockStyle.Bottom : Me.flpSlipDeductItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown : Me.flpSlipDeductItems.Height = 148 : Me.flpSlipDeductItems.Name = "flpSlipDeductItems" : Me.flpSlipDeductItems.WrapContents = False

        ' Slip footer
        Me.pnlSlipFooter.BackColor = System.Drawing.Color.FromArgb(15, 74, 158, 255)
        Me.pnlSlipFooter.Controls.Add(Me.lblSlipNetVal)
        Me.pnlSlipFooter.Controls.Add(Me.lblSlipNetLabel)
        Me.pnlSlipFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSlipFooter.Height = 64
        Me.pnlSlipFooter.Name = "pnlSlipFooter"
        Me.pnlSlipFooter.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)

        Me.lblSlipNetLabel.AutoSize = True : Me.lblSlipNetLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipNetLabel.ForeColor = System.Drawing.Color.FromArgb(197, 213, 240) : Me.lblSlipNetLabel.Location = New System.Drawing.Point(18, 18) : Me.lblSlipNetLabel.Name = "lblSlipNetLabel" : Me.lblSlipNetLabel.Text = "Lương thực lãnh"
        Me.lblSlipNetVal.AutoSize = True : Me.lblSlipNetVal.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.0!, System.Drawing.FontStyle.Bold) : Me.lblSlipNetVal.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255) : Me.lblSlipNetVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles) : Me.lblSlipNetVal.Location = New System.Drawing.Point(750, 10) : Me.lblSlipNetVal.Name = "lblSlipNetVal" : Me.lblSlipNetVal.Text = "15,625,000đ"

        ' ╔══════════════════════════════════════╗
        '  FORM
        ' ╚══════════════════════════════════════╝
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.Controls.Add(Me.pnlRoot)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "formPayroll"
        Me.Text = "Bảng lương"

        Me.pnlRoot.ResumeLayout(False)
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.pnlTabBar.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlTab1.ResumeLayout(False)
        Me.pnlT1Left.ResumeLayout(False)
        Me.pnlT1AddBtn.ResumeLayout(False)
        Me.pnlT1Right.ResumeLayout(False)
        Me.pnlPeriodHeader.ResumeLayout(False)
        Me.pnlPeriodHdrLeft.ResumeLayout(False)
        Me.pnlPeriodHdrLeft.PerformLayout()
        Me.pnlKpiRow.ResumeLayout(False)
        Me.pnlKpi1.ResumeLayout(False) : Me.pnlKpi1.PerformLayout()
        Me.pnlKpi2.ResumeLayout(False) : Me.pnlKpi2.PerformLayout()
        Me.pnlKpi3.ResumeLayout(False) : Me.pnlKpi3.PerformLayout()
        Me.pnlKpi4.ResumeLayout(False) : Me.pnlKpi4.PerformLayout()
        Me.pnlPeriodFormScroll.ResumeLayout(False)
        Me.tlpPeriodForm.ResumeLayout(False)
        Me.tlpPeriodForm.PerformLayout()
        Me.pnlPeriodFooter.ResumeLayout(False)
        Me.pnlTab2.ResumeLayout(False)
        Me.pnlPayrollHeader.ResumeLayout(False)
        Me.pnlPayrollHeader.PerformLayout()
        Me.pnlSummaryChips.ResumeLayout(False)
        Me.pnlSummaryChips.PerformLayout()
        CType(Me.dgvPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPayFooter.ResumeLayout(False)
        Me.pnlPayFooter.PerformLayout()
        Me.pnlPayPageBtns.ResumeLayout(False)
        Me.pnlTab3.ResumeLayout(False)
        Me.pnlSlipLeft.ResumeLayout(False)
        Me.pnlSlipRight.ResumeLayout(False)
        Me.pnlSlipScroll.ResumeLayout(False)
        Me.pnlSlipCard.ResumeLayout(False)
        Me.pnlSlipCardHeader.ResumeLayout(False)
        Me.pnlSlipCardHeader.PerformLayout()
        Me.pnlSlipBody.ResumeLayout(False)
        Me.pnlSlipIncomeSection.ResumeLayout(False)
        Me.pnlSlipIncomeSection.PerformLayout()
        Me.pnlSlipDeductSection.ResumeLayout(False)
        Me.pnlSlipDeductSection.PerformLayout()
        Me.pnlSlipFooter.ResumeLayout(False)
        Me.pnlSlipFooter.PerformLayout()
        Me.pnlSlipActions.ResumeLayout(False)
        Me.ResumeLayout(False)

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