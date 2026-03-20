<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BaseList_UC

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        tool_refresh = New ToolStripButton()
        TableLayoutPanel1 = New TableLayoutPanel()
        toolStrip = New ToolStrip()
        tool_new = New ToolStripButton()
        tool_delete = New ToolStripButton()
        tool_hide_column = New ToolStripButton()
        viewSelected = New Label()
        _dgv = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        TableLayoutPanel1.SuspendLayout()
        toolStrip.SuspendLayout()
        CType(_dgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tool_refresh
        ' 
        tool_refresh.BackColor = Color.Transparent
        tool_refresh.BackgroundImageLayout = ImageLayout.Stretch
        tool_refresh.DisplayStyle = ToolStripItemDisplayStyle.Image
        tool_refresh.Image = My.Resources.Resources.cloud_sync
        tool_refresh.ImageTransparentColor = Color.Magenta
        tool_refresh.Margin = New Padding(3, 3, 20, 3)
        tool_refresh.Name = "tool_refresh"
        tool_refresh.Size = New Size(28, 28)
        tool_refresh.Text = "Tải lại dữ liệu"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.Transparent
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Controls.Add(toolStrip, 0, 0)
        TableLayoutPanel1.Controls.Add(viewSelected, 0, 1)
        TableLayoutPanel1.Controls.Add(_dgv, 0, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 13.03921F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 21.82596F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 65.19258F))
        TableLayoutPanel1.Size = New Size(1437, 809)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' toolStrip
        ' 
        toolStrip.BackColor = SystemColors.GradientInactiveCaption
        toolStrip.GripStyle = ToolStripGripStyle.Hidden
        toolStrip.ImageScalingSize = New Size(24, 24)
        toolStrip.Items.AddRange(New ToolStripItem() {tool_new, tool_refresh, tool_delete, tool_hide_column})
        toolStrip.Location = New Point(0, 0)
        toolStrip.Name = "toolStrip"
        toolStrip.RenderMode = ToolStripRenderMode.System
        toolStrip.Size = New Size(1437, 34)
        toolStrip.TabIndex = 0
        toolStrip.Text = "ToolStrip1"
        ' 
        ' tool_new
        ' 
        tool_new.BackColor = Color.Transparent
        tool_new.BackgroundImageLayout = ImageLayout.Stretch
        tool_new.DisplayStyle = ToolStripItemDisplayStyle.Image
        tool_new.Image = My.Resources.Resources.new_data
        tool_new.ImageTransparentColor = Color.Magenta
        tool_new.Margin = New Padding(3, 3, 20, 3)
        tool_new.Name = "tool_new"
        tool_new.Size = New Size(28, 28)
        tool_new.Text = "Thêm mới"
        tool_new.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tool_delete
        ' 
        tool_delete.BackColor = Color.Transparent
        tool_delete.BackgroundImageLayout = ImageLayout.Stretch
        tool_delete.DisplayStyle = ToolStripItemDisplayStyle.Image
        tool_delete.Image = My.Resources.Resources.delete
        tool_delete.ImageTransparentColor = Color.Magenta
        tool_delete.Margin = New Padding(3, 3, 20, 3)
        tool_delete.Name = "tool_delete"
        tool_delete.Size = New Size(28, 28)
        tool_delete.Text = "Xóa dòng đã chọn"
        ' 
        ' tool_hide_column
        ' 
        tool_hide_column.DisplayStyle = ToolStripItemDisplayStyle.Image
        tool_hide_column.Image = My.Resources.Resources.hidden_32px
        tool_hide_column.ImageTransparentColor = Color.Magenta
        tool_hide_column.Name = "tool_hide_column"
        tool_hide_column.Size = New Size(28, 31)
        tool_hide_column.Text = "Ẩn cột dữ liệu"
        ' 
        ' viewSelected
        ' 
        viewSelected.AutoSize = True
        viewSelected.Dock = DockStyle.Fill
        viewSelected.Font = New Font("Arial", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        viewSelected.ForeColor = SystemColors.ActiveCaptionText
        viewSelected.Location = New Point(4, 105)
        viewSelected.Margin = New Padding(4, 0, 4, 0)
        viewSelected.Name = "viewSelected"
        viewSelected.Size = New Size(1429, 176)
        viewSelected.TabIndex = 2
        viewSelected.Text = "Rows selected:  0"
        viewSelected.TextAlign = ContentAlignment.BottomRight
        ' 
        ' _dgv
        ' 
        _dgv.AllowUserToAddRows = False
        _dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        _dgv.BackgroundColor = SystemColors.InactiveCaption
        _dgv.BorderStyle = BorderStyle.Fixed3D
        _dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.ButtonHighlight
        DataGridViewCellStyle2.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        _dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        _dgv.ColumnHeadersHeight = 40
        _dgv.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6})
        _dgv.Dock = DockStyle.Fill
        _dgv.GridColor = SystemColors.InactiveCaptionText
        _dgv.Location = New Point(4, 284)
        _dgv.Margin = New Padding(4, 3, 4, 3)
        _dgv.Name = "_dgv"
        _dgv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.ButtonHighlight
        DataGridViewCellStyle3.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        _dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        DataGridViewCellStyle4.SelectionForeColor = Color.Black
        _dgv.RowsDefaultCellStyle = DataGridViewCellStyle4
        _dgv.RowTemplate.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _dgv.RowTemplate.DefaultCellStyle.NullValue = Nothing
        _dgv.RowTemplate.Height = 40
        _dgv.RowTemplate.Resizable = DataGridViewTriState.True
        _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        _dgv.Size = New Size(1429, 522)
        _dgv.TabIndex = 5
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Column1"
        Column1.Name = "Column1"
        Column1.ReadOnly = True
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Column2"
        Column2.Name = "Column2"
        Column2.ReadOnly = True
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Column3"
        Column3.Name = "Column3"
        Column3.ReadOnly = True
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Column4"
        Column4.Name = "Column4"
        Column4.ReadOnly = True
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "Column5"
        Column5.Name = "Column5"
        Column5.ReadOnly = True
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Column6"
        Column6.Name = "Column6"
        Column6.ReadOnly = True
        ' 
        ' BaseList_UC
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientInactiveCaption
        Controls.Add(TableLayoutPanel1)
        DoubleBuffered = True
        Margin = New Padding(4, 3, 4, 3)
        Name = "BaseList_UC"
        Size = New Size(1437, 809)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        toolStrip.ResumeLayout(False)
        toolStrip.PerformLayout()
        CType(_dgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents viewSelected As Label
    Friend WithEvents toolStrip As ToolStrip
    Protected WithEvents tool_new As ToolStripButton
    Protected WithEvents tool_delete As ToolStripButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Protected WithEvents _dgv As DataGridView
    Friend WithEvents tool_hide_column As ToolStripButton
    Protected WithEvents tool_refresh As ToolStripButton
End Class
