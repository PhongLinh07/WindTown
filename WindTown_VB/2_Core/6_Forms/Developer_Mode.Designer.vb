<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Developer_Mode
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_backend = New System.Windows.Forms.Button()
        Me.btn_fontend = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(190, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chọn chế độ UI !"
        '
        'btn_backend
        '
        Me.btn_backend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_backend.Location = New System.Drawing.Point(123, 135)
        Me.btn_backend.Name = "btn_backend"
        Me.btn_backend.Size = New System.Drawing.Size(112, 37)
        Me.btn_backend.TabIndex = 1
        Me.btn_backend.Text = "Backend"
        Me.btn_backend.UseVisualStyleBackColor = True
        '
        'btn_fontend
        '
        Me.btn_fontend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_fontend.Location = New System.Drawing.Point(302, 135)
        Me.btn_fontend.Name = "btn_fontend"
        Me.btn_fontend.Size = New System.Drawing.Size(112, 37)
        Me.btn_fontend.TabIndex = 2
        Me.btn_fontend.Text = "Fontend"
        Me.btn_fontend.UseVisualStyleBackColor = True
        '
        'Developer_Mode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(549, 271)
        Me.Controls.Add(Me.btn_fontend)
        Me.Controls.Add(Me.btn_backend)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Developer_Mode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Developer_Mode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btn_backend As Button
    Friend WithEvents btn_fontend As Button
End Class
