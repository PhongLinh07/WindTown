<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BaseACRUDForm
    Inherits System.Windows.Forms.Form

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
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.tool_save = New System.Windows.Forms.ToolStripButton()
        Me.tool_init_payroll = New System.Windows.Forms.ToolStripButton()
        Me.tool_net_salary = New System.Windows.Forms.ToolStripButton()
        Me.tool_aggregate_payroll_data = New System.Windows.Forms.ToolStripButton()
        Me.toolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.BackColor = System.Drawing.Color.MediumTurquoise
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_save, Me.tool_init_payroll, Me.tool_aggregate_payroll_data, Me.tool_net_salary})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip.Size = New System.Drawing.Size(800, 34)
        Me.toolStrip.TabIndex = 0
        Me.toolStrip.Text = "ToolStrip1"
        '
        'tool_save
        '
        Me.tool_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_save.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tool_save.Image = Global.WindTown_VB.My.Resources.Resources.save
        Me.tool_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_save.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_save.Name = "tool_save"
        Me.tool_save.Size = New System.Drawing.Size(28, 28)
        Me.tool_save.Text = "Lưu kết quả"
        '
        'tool_init_payroll
        '
        Me.tool_init_payroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_init_payroll.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tool_init_payroll.Image = Global.WindTown_VB.My.Resources.Resources.calculator
        Me.tool_init_payroll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_init_payroll.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_init_payroll.Name = "tool_init_payroll"
        Me.tool_init_payroll.Size = New System.Drawing.Size(28, 28)
        Me.tool_init_payroll.Text = "Khởi tạo bảng lương"
        Me.tool_init_payroll.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'tool_net_salary
        '
        Me.tool_net_salary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_net_salary.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tool_net_salary.Image = Global.WindTown_VB.My.Resources.Resources.money
        Me.tool_net_salary.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_net_salary.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_net_salary.Name = "tool_net_salary"
        Me.tool_net_salary.Size = New System.Drawing.Size(28, 28)
        Me.tool_net_salary.Text = "Tính lương"
        Me.tool_net_salary.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'tool_aggregate_payroll_data
        '
        Me.tool_aggregate_payroll_data.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_aggregate_payroll_data.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.tool_aggregate_payroll_data.Image = Global.WindTown_VB.My.Resources.Resources.budget
        Me.tool_aggregate_payroll_data.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_aggregate_payroll_data.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tool_aggregate_payroll_data.Name = "tool_aggregate_payroll_data"
        Me.tool_aggregate_payroll_data.Size = New System.Drawing.Size(28, 28)
        Me.tool_aggregate_payroll_data.Text = "Tổng hợp dữ liệu"
        Me.tool_aggregate_payroll_data.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'BaseACRUDForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(800, 505)
        Me.Controls.Add(Me.toolStrip)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "BaseACRUDForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACRUDForm"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents tool_save As ToolStripButton
    Protected WithEvents toolStrip As ToolStrip
    Protected WithEvents tool_init_payroll As ToolStripButton
    Protected WithEvents tool_net_salary As ToolStripButton
    Protected WithEvents tool_aggregate_payroll_data As ToolStripButton
End Class
