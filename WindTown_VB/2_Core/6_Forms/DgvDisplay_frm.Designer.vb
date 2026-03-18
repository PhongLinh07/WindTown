<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DgvDisplay_frm
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
        Me.clbColumns = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'clbColumns
        '
        Me.clbColumns.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.clbColumns.ColumnWidth = 10000
        Me.clbColumns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbColumns.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbColumns.FormattingEnabled = True
        Me.clbColumns.HorizontalScrollbar = True
        Me.clbColumns.Items.AddRange(New Object() {"Cloumn1", "Cloumn4", "Cloumn7", "Column2", "Column3", "Column5", "Column6", "Column8", "Column9"})
        Me.clbColumns.Location = New System.Drawing.Point(0, 0)
        Me.clbColumns.MultiColumn = True
        Me.clbColumns.Name = "clbColumns"
        Me.clbColumns.Size = New System.Drawing.Size(464, 281)
        Me.clbColumns.TabIndex = 0
        '
        'DgvDisplay_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(464, 281)
        Me.Controls.Add(Me.clbColumns)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DgvDisplay_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DgvDisplay_frm"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents clbColumns As CheckedListBox
End Class
