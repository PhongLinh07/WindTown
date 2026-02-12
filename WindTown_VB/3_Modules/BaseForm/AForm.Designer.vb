<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim tool_refresh As System.Windows.Forms.ToolStripButton
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.tool_new = New System.Windows.Forms.ToolStripButton()
        Me.tool_delete = New System.Windows.Forms.ToolStripButton()
        Me.viewSelected = New System.Windows.Forms.Label()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        tool_refresh = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tool_refresh
        '
        tool_refresh.BackColor = System.Drawing.Color.Transparent
        tool_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        tool_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        tool_refresh.Image = Global.WindTown_VB.My.Resources.Resources.cloud_sync
        tool_refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        tool_refresh.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        tool_refresh.Name = "tool_refresh"
        tool_refresh.Size = New System.Drawing.Size(28, 28)
        tool_refresh.Text = "ToolStripButton1"
        AddHandler tool_refresh.Click, AddressOf Me.tool_refresh_Click
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.toolStrip, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.viewSelected, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Dgv, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.03921!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.82596!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.19258!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 701)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'toolStrip
        '
        Me.toolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.toolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_new, tool_refresh, Me.tool_delete})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip.Size = New System.Drawing.Size(1232, 34)
        Me.toolStrip.TabIndex = 0
        Me.toolStrip.Text = "ToolStrip1"
        '
        'tool_new
        '
        Me.tool_new.BackColor = System.Drawing.Color.Transparent
        Me.tool_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tool_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_new.Image = Global.WindTown_VB.My.Resources.Resources.new_data
        Me.tool_new.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_new.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_new.Name = "tool_new"
        Me.tool_new.Size = New System.Drawing.Size(28, 28)
        Me.tool_new.Text = "ToolStripButton1"
        '
        'tool_delete
        '
        Me.tool_delete.BackColor = System.Drawing.Color.Transparent
        Me.tool_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tool_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_delete.Image = Global.WindTown_VB.My.Resources.Resources.delete
        Me.tool_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_delete.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_delete.Name = "tool_delete"
        Me.tool_delete.Size = New System.Drawing.Size(28, 28)
        Me.tool_delete.Text = "ToolStripButton1"
        '
        'viewSelected
        '
        Me.viewSelected.AutoSize = True
        Me.viewSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewSelected.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.viewSelected.Location = New System.Drawing.Point(3, 91)
        Me.viewSelected.Name = "viewSelected"
        Me.viewSelected.Size = New System.Drawing.Size(1226, 152)
        Me.viewSelected.TabIndex = 2
        Me.viewSelected.Text = "Rows selected:  0"
        Me.viewSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv.ColumnHeadersHeight = 50
        Me.Dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv.GridColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Dgv.Location = New System.Drawing.Point(3, 246)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.ReadOnly = True
        Me.Dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.Dgv.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv.RowTemplate.DefaultCellStyle.Format = "N0"
        Me.Dgv.RowTemplate.DefaultCellStyle.NullValue = Nothing
        Me.Dgv.RowTemplate.Height = 40
        Me.Dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv.Size = New System.Drawing.Size(1226, 452)
        Me.Dgv.TabIndex = 1
        '
        'AForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindTown_VB.My.Resources.Resources.Background_2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1232, 701)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "AForm"
        Me.Text = "AForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents toolStrip As ToolStrip
    Friend WithEvents viewSelected As Label
    Protected WithEvents tool_delete As ToolStripButton
    Protected WithEvents tool_new As ToolStripButton
    Protected WithEvents Dgv As DataGridView
End Class
