<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DfrmDashBoard
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
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)

        ' ── Root layout ──────────────────────────────────────
        Me.tlpRoot = New System.Windows.Forms.TableLayoutPanel()

        ' ── Row 0: KPI cards ─────────────────────────────────
        Me.tlpKpi = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlK1 = New System.Windows.Forms.Panel()
        Me.pnlK2 = New System.Windows.Forms.Panel()
        Me.pnlK3 = New System.Windows.Forms.Panel()

        ' ── Row 1: Upper charts (Line + Bar) ─────────────────
        Me.tlpChartsUp = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlChartLine = New System.Windows.Forms.Panel()
        Me.pnlChartBar = New System.Windows.Forms.Panel()

        ' ── Row 2: Lower charts (Donut + Table) ──────────────
        Me.tlpChartsDown = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlChartDonut = New System.Windows.Forms.Panel()
        Me.pnlTableCard = New System.Windows.Forms.Panel()
        Me.lblTableTitle = New System.Windows.Forms.Label()
        Me.pnlTableSub = New System.Windows.Forms.Label()
        Me.dgvLate = New System.Windows.Forms.DataGridView()

        ' DGV Columns
        Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLateCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLateHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()

        Me.tlpRoot.SuspendLayout()
        Me.tlpKpi.SuspendLayout()
        Me.tlpChartsUp.SuspendLayout()
        Me.tlpChartsDown.SuspendLayout()
        Me.pnlTableCard.SuspendLayout()
        CType(Me.dgvLate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' ── Timer (auto-refresh every 5 min) ─────────────────
        Me.tmrRefresh.Interval = 300000
        Me.tmrRefresh.Enabled = True

        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        '  ROOT TABLE LAYOUT (1 col × 3 rows)
        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        Me.tlpRoot.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.tlpRoot.ColumnCount = 1
        Me.tlpRoot.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRoot.Controls.Add(Me.tlpKpi, 0, 0)
        Me.tlpRoot.Controls.Add(Me.tlpChartsUp, 0, 1)
        Me.tlpRoot.Controls.Add(Me.tlpChartsDown, 0, 2)
        Me.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRoot.Name = "tlpRoot"
        Me.tlpRoot.Padding = New System.Windows.Forms.Padding(14, 12, 14, 10)
        Me.tlpRoot.RowCount = 3
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRoot.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None

        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        '  ROW 0 — KPI (3 equal columns)
        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        Me.tlpKpi.BackColor = System.Drawing.Color.Transparent
        Me.tlpKpi.ColumnCount = 3
        Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34!))
        Me.tlpKpi.Controls.Add(Me.pnlK1, 0, 0)
        Me.tlpKpi.Controls.Add(Me.pnlK2, 1, 0)
        Me.tlpKpi.Controls.Add(Me.pnlK3, 2, 0)
        Me.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpKpi.Name = "tlpKpi"
        Me.tlpKpi.RowCount = 1
        Me.tlpKpi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpKpi.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)

        ' KPI card panels (Paint event handles all drawing)
        Me.pnlK1.BackColor = Color.FromArgb(30, 34, 53)
        Me.pnlK1.Dock = DockStyle.Fill
        Me.pnlK1.Margin = New Padding(0, 0, 8, 0)
        Me.pnlK1.Cursor = Cursors.Default

        Me.pnlK2.BackColor = Color.FromArgb(30, 34, 53)
        Me.pnlK2.Dock = DockStyle.Fill
        Me.pnlK2.Margin = New Padding(0, 0, 8, 0)
        Me.pnlK2.Cursor = Cursors.Default

        Me.pnlK3.BackColor = Color.FromArgb(30, 34, 53)
        Me.pnlK3.Dock = DockStyle.Fill
        Me.pnlK3.Margin = New Padding(0, 0, 0, 0)
        Me.pnlK3.Cursor = Cursors.Default

        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        '  ROW 1 — Upper Charts (Line 58% | Bar 42%)
        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        Me.tlpChartsUp.BackColor = System.Drawing.Color.Transparent
        Me.tlpChartsUp.ColumnCount = 2
        Me.tlpChartsUp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.0!))
        Me.tlpChartsUp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.tlpChartsUp.Controls.Add(Me.pnlChartLine, 0, 0)
        Me.tlpChartsUp.Controls.Add(Me.pnlChartBar, 1, 0)
        Me.tlpChartsUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpChartsUp.Name = "tlpChartsUp"
        Me.tlpChartsUp.RowCount = 1
        Me.tlpChartsUp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartsUp.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)

        Me.pnlChartLine.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlChartLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChartLine.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.pnlChartLine.Name = "pnlChartLine"

        Me.pnlChartBar.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlChartBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChartBar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlChartBar.Name = "pnlChartBar"

        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        '  ROW 2 — Lower Charts (Donut 34% | Table 66%)
        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        Me.tlpChartsDown.BackColor = System.Drawing.Color.Transparent
        Me.tlpChartsDown.ColumnCount = 2
        Me.tlpChartsDown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.tlpChartsDown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.0!))
        Me.tlpChartsDown.Controls.Add(Me.pnlChartDonut, 0, 0)
        Me.tlpChartsDown.Controls.Add(Me.pnlTableCard, 1, 0)
        Me.tlpChartsDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpChartsDown.Name = "tlpChartsDown"
        Me.tlpChartsDown.RowCount = 1
        Me.tlpChartsDown.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartsDown.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)

        Me.pnlChartDonut.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlChartDonut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChartDonut.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.pnlChartDonut.Name = "pnlChartDonut"

        ' ── Table Card (dark DGV) ─────────────────────────────
        Me.pnlTableCard.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.pnlTableCard.Controls.Add(Me.dgvLate)
        Me.pnlTableCard.Controls.Add(Me.pnlTableSub)
        Me.pnlTableCard.Controls.Add(Me.lblTableTitle)
        Me.pnlTableCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTableCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlTableCard.Name = "pnlTableCard"
        Me.pnlTableCard.Padding = New System.Windows.Forms.Padding(14, 12, 14, 8)

        Me.lblTableTitle.AutoSize = True
        Me.lblTableTitle.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.lblTableTitle.Location = New System.Drawing.Point(14, 12)
        Me.lblTableTitle.Name = "lblTableTitle"
        Me.lblTableTitle.Text = "Top đi trễ / vắng mặt"

        Me.pnlTableSub.AutoSize = True
        Me.pnlTableSub.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
        Me.pnlTableSub.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        Me.pnlTableSub.Location = New System.Drawing.Point(14, 34)
        Me.pnlTableSub.Name = "pnlTableSub"
        Me.pnlTableSub.Text = "Tháng hiện tại"

        ' ── DataGridView ─────────────────────────────────────
        Me.dgvLate.AllowUserToAddRows = False
        Me.dgvLate.AllowUserToDeleteRows = False
        Me.dgvLate.AllowUserToResizeRows = False
        Me.dgvLate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLate.BackgroundColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.dgvLate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLate.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvLate.GridColor = System.Drawing.Color.FromArgb(42, 48, 80)
        Me.dgvLate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvLate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLate.EnableHeadersVisualStyles = False
        Me.dgvLate.MultiSelect = False
        Me.dgvLate.ReadOnly = True
        Me.dgvLate.RowHeadersVisible = False
        Me.dgvLate.RowTemplate.Height = 36
        Me.dgvLate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLate.Location = New System.Drawing.Point(14, 54)
        Me.dgvLate.Name = "dgvLate"
        Me.dgvLate.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or
                                   System.Windows.Forms.AnchorStyles.Bottom Or
                                   System.Windows.Forms.AnchorStyles.Left Or
                                   System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)

        ' DGV Default cell style
        Me.dgvLate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        Me.dgvLate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(197, 213, 240)
        Me.dgvLate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(59, 125, 216)
        Me.dgvLate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgvLate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.dgvLate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)

        ' DGV Alternating row style
        Me.dgvLate.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        Me.dgvLate.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(197, 213, 240)

        ' DGV Column header style
        Me.dgvLate.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(21, 24, 36)
        Me.dgvLate.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Me.dgvLate.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.dgvLate.ColumnHeadersDefaultCellStyle.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)

        ' DGV Columns
        Me.colNo.HeaderText = "#"
        Me.colNo.Name = "colNo"
        Me.colNo.FillWeight = 6
        Me.colNo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colNo.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(61, 74, 114)

        Me.colEmpName.HeaderText = "Nhân viên"
        Me.colEmpName.Name = "colEmpName"
        Me.colEmpName.FillWeight = 30

        Me.colDept.HeaderText = "Phòng ban"
        Me.colDept.Name = "colDept"
        Me.colDept.FillWeight = 20
        Me.colDept.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)

        Me.colLateCount.HeaderText = "Số lần trễ"
        Me.colLateCount.Name = "colLateCount"
        Me.colLateCount.FillWeight = 14
        Me.colLateCount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colLateCount.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)

        Me.colLateHours.HeaderText = "Tổng giờ trễ"
        Me.colLateHours.Name = "colLateHours"
        Me.colLateHours.FillWeight = 16
        Me.colLateHours.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Me.colStatus.HeaderText = "Mức độ"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.FillWeight = 14

        Me.dgvLate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {
            Me.colNo, Me.colEmpName, Me.colDept,
            Me.colLateCount, Me.colLateHours, Me.colStatus
        })

        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        '  FORM
        ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(26, 29, 46)
        Me.Controls.Add(Me.tlpRoot)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "formDashBoard"
        Me.Text = "Dashboard"

        Me.tlpRoot.ResumeLayout(False)
        Me.tlpKpi.ResumeLayout(False)
        Me.tlpChartsUp.ResumeLayout(False)
        Me.tlpChartsDown.ResumeLayout(False)
        Me.pnlTableCard.ResumeLayout(False)
        Me.pnlTableCard.PerformLayout()
        CType(Me.dgvLate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ' ── Declarations ──────────────────────────────────────────
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents tlpRoot As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpKpi As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlK1 As System.Windows.Forms.Panel
    Friend WithEvents pnlK2 As System.Windows.Forms.Panel
    Friend WithEvents pnlK3 As System.Windows.Forms.Panel
    Friend WithEvents tlpChartsUp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlChartLine As System.Windows.Forms.Panel
    Friend WithEvents pnlChartBar As System.Windows.Forms.Panel
    Friend WithEvents tlpChartsDown As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlChartDonut As System.Windows.Forms.Panel
    Friend WithEvents pnlTableCard As System.Windows.Forms.Panel
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents pnlTableSub As System.Windows.Forms.Label
    Friend WithEvents dgvLate As System.Windows.Forms.DataGridView
    Friend WithEvents colNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLateCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLateHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class