<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formDashBoardV2
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        tmrRefresh = New Timer(components)
        tlpRoot = New TableLayoutPanel()
        tlpKpi = New TableLayoutPanel()
        pnlK1 = New Panel()
        pnlK2 = New Panel()
        pnlK3 = New Panel()
        tlpChartsUp = New TableLayoutPanel()
        pnlChartLine = New Panel()
        pnlChartBar = New Panel()
        tlpChartsDown = New TableLayoutPanel()
        pnlChartDonut = New Panel()
        pnlTableCard = New Panel()
        dgvLate = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        colEmpName = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colLateCount = New DataGridViewTextBoxColumn()
        colLateHours = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        pnlTableSub = New Label()
        lblTableTitle = New Label()
        tlpRoot.SuspendLayout()
        tlpKpi.SuspendLayout()
        tlpChartsUp.SuspendLayout()
        tlpChartsDown.SuspendLayout()
        pnlTableCard.SuspendLayout()
        CType(dgvLate, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tmrRefresh
        ' 
        tmrRefresh.Enabled = True
        tmrRefresh.Interval = 300000
        ' 
        ' tlpRoot
        ' 
        tlpRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        tlpRoot.ColumnCount = 1
        tlpRoot.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpRoot.Controls.Add(tlpKpi, 0, 0)
        tlpRoot.Controls.Add(tlpChartsUp, 0, 1)
        tlpRoot.Controls.Add(tlpChartsDown, 0, 2)
        tlpRoot.Dock = DockStyle.Fill
        tlpRoot.Location = New Point(0, 0)
        tlpRoot.Name = "tlpRoot"
        tlpRoot.Padding = New Padding(14, 12, 14, 10)
        tlpRoot.RowCount = 3
        tlpRoot.RowStyles.Add(New RowStyle(SizeType.Absolute, 118F))
        tlpRoot.RowStyles.Add(New RowStyle(SizeType.Absolute, 222F))
        tlpRoot.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpRoot.Size = New Size(1199, 622)
        tlpRoot.TabIndex = 0
        ' 
        ' tlpKpi
        ' 
        tlpKpi.BackColor = Color.Transparent
        tlpKpi.ColumnCount = 3
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
        tlpKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.34F))
        tlpKpi.Controls.Add(pnlK1, 0, 0)
        tlpKpi.Controls.Add(pnlK2, 1, 0)
        tlpKpi.Controls.Add(pnlK3, 2, 0)
        tlpKpi.Dock = DockStyle.Fill
        tlpKpi.Location = New Point(14, 12)
        tlpKpi.Margin = New Padding(0, 0, 0, 8)
        tlpKpi.Name = "tlpKpi"
        tlpKpi.RowCount = 1
        tlpKpi.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpKpi.Size = New Size(1171, 110)
        tlpKpi.TabIndex = 0
        ' 
        ' pnlK1
        ' 
        pnlK1.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlK1.Dock = DockStyle.Fill
        pnlK1.Location = New Point(0, 0)
        pnlK1.Margin = New Padding(0, 0, 8, 0)
        pnlK1.Name = "pnlK1"
        pnlK1.Size = New Size(382, 110)
        pnlK1.TabIndex = 0
        ' 
        ' pnlK2
        ' 
        pnlK2.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlK2.Dock = DockStyle.Fill
        pnlK2.Location = New Point(390, 0)
        pnlK2.Margin = New Padding(0, 0, 8, 0)
        pnlK2.Name = "pnlK2"
        pnlK2.Size = New Size(382, 110)
        pnlK2.TabIndex = 1
        ' 
        ' pnlK3
        ' 
        pnlK3.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlK3.Dock = DockStyle.Fill
        pnlK3.Location = New Point(780, 0)
        pnlK3.Margin = New Padding(0)
        pnlK3.Name = "pnlK3"
        pnlK3.Size = New Size(391, 110)
        pnlK3.TabIndex = 2
        ' 
        ' tlpChartsUp
        ' 
        tlpChartsUp.BackColor = Color.Transparent
        tlpChartsUp.ColumnCount = 2
        tlpChartsUp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58F))
        tlpChartsUp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 42F))
        tlpChartsUp.Controls.Add(pnlChartLine, 0, 0)
        tlpChartsUp.Controls.Add(pnlChartBar, 1, 0)
        tlpChartsUp.Dock = DockStyle.Fill
        tlpChartsUp.Location = New Point(14, 130)
        tlpChartsUp.Margin = New Padding(0, 0, 0, 8)
        tlpChartsUp.Name = "tlpChartsUp"
        tlpChartsUp.RowCount = 1
        tlpChartsUp.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpChartsUp.Size = New Size(1171, 214)
        tlpChartsUp.TabIndex = 1
        ' 
        ' pnlChartLine
        ' 
        pnlChartLine.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlChartLine.Dock = DockStyle.Fill
        pnlChartLine.Location = New Point(0, 0)
        pnlChartLine.Margin = New Padding(0, 0, 8, 0)
        pnlChartLine.Name = "pnlChartLine"
        pnlChartLine.Size = New Size(671, 214)
        pnlChartLine.TabIndex = 0
        ' 
        ' pnlChartBar
        ' 
        pnlChartBar.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlChartBar.Dock = DockStyle.Fill
        pnlChartBar.Location = New Point(679, 0)
        pnlChartBar.Margin = New Padding(0)
        pnlChartBar.Name = "pnlChartBar"
        pnlChartBar.Size = New Size(492, 214)
        pnlChartBar.TabIndex = 1
        ' 
        ' tlpChartsDown
        ' 
        tlpChartsDown.BackColor = Color.Transparent
        tlpChartsDown.ColumnCount = 2
        tlpChartsDown.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34F))
        tlpChartsDown.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 66F))
        tlpChartsDown.Controls.Add(pnlChartDonut, 0, 0)
        tlpChartsDown.Controls.Add(pnlTableCard, 1, 0)
        tlpChartsDown.Dock = DockStyle.Fill
        tlpChartsDown.Location = New Point(14, 352)
        tlpChartsDown.Margin = New Padding(0)
        tlpChartsDown.Name = "tlpChartsDown"
        tlpChartsDown.RowCount = 1
        tlpChartsDown.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpChartsDown.Size = New Size(1171, 260)
        tlpChartsDown.TabIndex = 2
        ' 
        ' pnlChartDonut
        ' 
        pnlChartDonut.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlChartDonut.Dock = DockStyle.Fill
        pnlChartDonut.Location = New Point(0, 0)
        pnlChartDonut.Margin = New Padding(0, 0, 8, 0)
        pnlChartDonut.Name = "pnlChartDonut"
        pnlChartDonut.Size = New Size(390, 260)
        pnlChartDonut.TabIndex = 0
        ' 
        ' pnlTableCard
        ' 
        pnlTableCard.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlTableCard.Controls.Add(dgvLate)
        pnlTableCard.Controls.Add(pnlTableSub)
        pnlTableCard.Controls.Add(lblTableTitle)
        pnlTableCard.Dock = DockStyle.Fill
        pnlTableCard.Location = New Point(398, 0)
        pnlTableCard.Margin = New Padding(0)
        pnlTableCard.Name = "pnlTableCard"
        pnlTableCard.Padding = New Padding(14, 12, 14, 8)
        pnlTableCard.Size = New Size(773, 260)
        pnlTableCard.TabIndex = 1
        ' 
        ' dgvLate
        ' 
        dgvLate.AllowUserToAddRows = False
        dgvLate.AllowUserToDeleteRows = False
        dgvLate.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        dgvLate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvLate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLate.BackgroundColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dgvLate.BorderStyle = BorderStyle.None
        dgvLate.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvLate.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvLate.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvLate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLate.Columns.AddRange(New DataGridViewColumn() {colNo, colEmpName, colDept, colLateCount, colLateHours, colStatus})
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        DataGridViewCellStyle7.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        DataGridViewCellStyle7.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.False
        dgvLate.DefaultCellStyle = DataGridViewCellStyle7
        dgvLate.Dock = DockStyle.Top
        dgvLate.EnableHeadersVisualStyles = False
        dgvLate.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvLate.Location = New Point(14, 48)
        dgvLate.MultiSelect = False
        dgvLate.Name = "dgvLate"
        dgvLate.ReadOnly = True
        dgvLate.RowHeadersVisible = False
        dgvLate.RowHeadersWidth = 51
        dgvLate.RowTemplate.Height = 36
        dgvLate.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLate.Size = New Size(745, 192)
        dgvLate.TabIndex = 0
        ' 
        ' colNo
        ' 
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        colNo.DefaultCellStyle = DataGridViewCellStyle3
        colNo.FillWeight = 6F
        colNo.HeaderText = "#"
        colNo.MinimumWidth = 6
        colNo.Name = "colNo"
        colNo.ReadOnly = True
        ' 
        ' colEmpName
        ' 
        colEmpName.FillWeight = 30F
        colEmpName.HeaderText = "Nhân viên"
        colEmpName.MinimumWidth = 6
        colEmpName.Name = "colEmpName"
        colEmpName.ReadOnly = True
        ' 
        ' colDept
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colDept.DefaultCellStyle = DataGridViewCellStyle4
        colDept.FillWeight = 20F
        colDept.HeaderText = "Phòng ban"
        colDept.MinimumWidth = 6
        colDept.Name = "colDept"
        colDept.ReadOnly = True
        ' 
        ' colLateCount
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        colLateCount.DefaultCellStyle = DataGridViewCellStyle5
        colLateCount.FillWeight = 14F
        colLateCount.HeaderText = "Số lần trễ"
        colLateCount.MinimumWidth = 6
        colLateCount.Name = "colLateCount"
        colLateCount.ReadOnly = True
        ' 
        ' colLateHours
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        colLateHours.DefaultCellStyle = DataGridViewCellStyle6
        colLateHours.FillWeight = 16F
        colLateHours.HeaderText = "Tổng giờ trễ"
        colLateHours.MinimumWidth = 6
        colLateHours.Name = "colLateHours"
        colLateHours.ReadOnly = True
        ' 
        ' colStatus
        ' 
        colStatus.FillWeight = 14F
        colStatus.HeaderText = "Mức độ"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        ' 
        ' pnlTableSub
        ' 
        pnlTableSub.AutoSize = True
        pnlTableSub.Dock = DockStyle.Top
        pnlTableSub.Font = New Font("Microsoft YaHei UI", 9F)
        pnlTableSub.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        pnlTableSub.Location = New Point(14, 31)
        pnlTableSub.Name = "pnlTableSub"
        pnlTableSub.Size = New Size(90, 17)
        pnlTableSub.TabIndex = 1
        pnlTableSub.Text = "Tháng hiện tại"
        ' 
        ' lblTableTitle
        ' 
        lblTableTitle.AutoSize = True
        lblTableTitle.Dock = DockStyle.Top
        lblTableTitle.Font = New Font("Microsoft YaHei UI", 11F, FontStyle.Bold)
        lblTableTitle.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblTableTitle.Location = New Point(14, 12)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Size = New Size(168, 19)
        lblTableTitle.TabIndex = 2
        lblTableTitle.Text = "Top đi trễ / vắng mặt"
        ' 
        ' formDashBoardV2
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1199, 622)
        Controls.Add(tlpRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "formDashBoardV2"
        Text = "Dashboard"
        tlpRoot.ResumeLayout(False)
        tlpKpi.ResumeLayout(False)
        tlpChartsUp.ResumeLayout(False)
        tlpChartsDown.ResumeLayout(False)
        pnlTableCard.ResumeLayout(False)
        pnlTableCard.PerformLayout()
        CType(dgvLate, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

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