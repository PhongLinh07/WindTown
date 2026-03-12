<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Salary_Mult_CRUD_Frm
    Inherits BaseACRUDForm

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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ui_level = New System.Windows.Forms.ComboBox()
        Me.sf = New System.Windows.Forms.Label()
        Me.ui_job = New System.Windows.Forms.ComboBox()
        Me.ui_mult = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ui_mult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(392, 165)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Ghi chú:"
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(396, 188)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(313, 117)
        Me.ui_note.TabIndex = 15
        Me.ui_note.Text = ""
        '
        'ui_status
        '
        Me.ui_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_status.FormattingEnabled = True
        Me.ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_status.Location = New System.Drawing.Point(396, 100)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(313, 28)
        Me.ui_status.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(392, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Trạng thái:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(42, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Chức danh công việc:"
        '
        'ui_level
        '
        Me.ui_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_level.FormattingEnabled = True
        Me.ui_level.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_level.Location = New System.Drawing.Point(46, 188)
        Me.ui_level.Name = "ui_level"
        Me.ui_level.Size = New System.Drawing.Size(288, 28)
        Me.ui_level.TabIndex = 18
        '
        'sf
        '
        Me.sf.AutoSize = True
        Me.sf.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.sf.Location = New System.Drawing.Point(42, 165)
        Me.sf.Margin = New System.Windows.Forms.Padding(0)
        Me.sf.Name = "sf"
        Me.sf.Size = New System.Drawing.Size(143, 19)
        Me.sf.TabIndex = 17
        Me.sf.Text = "Cấp bậc kỹ năng:"
        '
        'ui_job
        '
        Me.ui_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_job.FormattingEnabled = True
        Me.ui_job.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_job.Location = New System.Drawing.Point(46, 100)
        Me.ui_job.Name = "ui_job"
        Me.ui_job.Size = New System.Drawing.Size(288, 28)
        Me.ui_job.TabIndex = 19
        '
        'ui_mult
        '
        Me.ui_mult.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_mult.Location = New System.Drawing.Point(46, 279)
        Me.ui_mult.Name = "ui_mult"
        Me.ui_mult.Size = New System.Drawing.Size(291, 26)
        Me.ui_mult.TabIndex = 67
        Me.ui_mult.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(43, 256)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Hệ số:"
        '
        'Salary_Mult_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 414)
        Me.Controls.Add(Me.ui_mult)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ui_job)
        Me.Controls.Add(Me.ui_level)
        Me.Controls.Add(Me.sf)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_note)
        Me.Controls.Add(Me.ui_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Salary_Mult_CRUD_Frm"
        Me.Text = "Job_CRUD_Frm"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_status, 0)
        Me.Controls.SetChildIndex(Me.ui_note, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.sf, 0)
        Me.Controls.SetChildIndex(Me.ui_level, 0)
        Me.Controls.SetChildIndex(Me.ui_job, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ui_mult, 0)
        CType(Me.ui_mult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_level As ComboBox
    Friend WithEvents sf As Label
    Friend WithEvents ui_job As ComboBox
    Friend WithEvents ui_mult As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
