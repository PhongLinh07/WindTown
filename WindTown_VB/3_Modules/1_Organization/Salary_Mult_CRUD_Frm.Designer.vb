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
        Label4 = New Label()
        ui_note = New RichTextBox()
        ui_status = New ComboBox()
        Label3 = New Label()
        Label1 = New Label()
        ui_level = New ComboBox()
        sf = New Label()
        ui_job = New ComboBox()
        ui_mult = New NumericUpDown()
        Label2 = New Label()
        Label5 = New Label()
        ui_code = New TextBox()
        CType(ui_mult, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(457, 190)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 16
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(462, 217)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(364, 233)
        ui_note.TabIndex = 15
        ui_note.Text = ""
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(462, 115)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(364, 28)
        ui_status.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(457, 89)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 13
        Label3.Text = "Trạng thái:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(45, 193)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(179, 19)
        Label1.TabIndex = 10
        Label1.Text = "Chức danh công việc:"
        ' 
        ' ui_level
        ' 
        ui_level.DropDownStyle = ComboBoxStyle.DropDownList
        ui_level.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_level.FormattingEnabled = True
        ui_level.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_level.Location = New Point(50, 319)
        ui_level.Margin = New Padding(4, 3, 4, 3)
        ui_level.Name = "ui_level"
        ui_level.Size = New Size(335, 28)
        ui_level.TabIndex = 18
        ' 
        ' sf
        ' 
        sf.AutoSize = True
        sf.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        sf.ImageAlign = ContentAlignment.MiddleLeft
        sf.Location = New Point(45, 292)
        sf.Margin = New Padding(0)
        sf.Name = "sf"
        sf.Size = New Size(143, 19)
        sf.TabIndex = 17
        sf.Text = "Cấp bậc kỹ năng:"
        ' 
        ' ui_job
        ' 
        ui_job.DropDownStyle = ComboBoxStyle.DropDownList
        ui_job.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_job.FormattingEnabled = True
        ui_job.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_job.Location = New Point(50, 217)
        ui_job.Margin = New Padding(4, 3, 4, 3)
        ui_job.Name = "ui_job"
        ui_job.Size = New Size(335, 28)
        ui_job.TabIndex = 19
        ' 
        ' ui_mult
        ' 
        ui_mult.DecimalPlaces = 2
        ui_mult.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_mult.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_mult.Location = New Point(50, 424)
        ui_mult.Margin = New Padding(4, 3, 4, 3)
        ui_mult.Name = "ui_mult"
        ui_mult.Size = New Size(340, 26)
        ui_mult.TabIndex = 67
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(46, 397)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(59, 19)
        Label2.TabIndex = 66
        Label2.Text = "Hệ số:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(45, 88)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 19)
        Label5.TabIndex = 69
        Label5.Text = "Mã hệ số:"
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(50, 115)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(335, 26)
        ui_code.TabIndex = 68
        ' 
        ' Salary_Mult_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(881, 502)
        Controls.Add(Label5)
        Controls.Add(ui_code)
        Controls.Add(ui_mult)
        Controls.Add(Label2)
        Controls.Add(ui_job)
        Controls.Add(ui_level)
        Controls.Add(sf)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Name = "Salary_Mult_CRUD_Frm"
        Text = "Job_CRUD_Frm"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(sf, 0)
        Controls.SetChildIndex(ui_level, 0)
        Controls.SetChildIndex(ui_job, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(ui_mult, 0)
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label5, 0)
        CType(ui_mult, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

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
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_code As TextBox
End Class
