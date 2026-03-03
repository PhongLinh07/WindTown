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
        Me.toolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.BackColor = System.Drawing.Color.MediumTurquoise
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_save})
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
        Me.tool_save.Text = "Ssve"
        '
        'BaseACRUDForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(800, 505)
        Me.Controls.Add(Me.toolStrip)
        Me.Name = "BaseACRUDForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACRUDForm"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents toolStrip As ToolStrip
    Protected WithEvents tool_save As ToolStripButton
End Class
