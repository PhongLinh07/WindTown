<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Job_CRUD_Frm
    Inherits BaseACRUDForm

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
        Label4 = New Label()
        ui_note = New RichTextBox()
        ui_status = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        ui_name = New TextBox()
        Label1 = New Label()
        ui_code = New TextBox()
        ui_department = New ComboBox()
        Label5 = New Label()
        grb_salary_mult = New GroupBox()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(49, 500)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 16
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(54, 526)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(335, 134)
        ui_note.TabIndex = 15
        ui_note.Text = ""
        ' 
        ' ui_status
        ' 
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(54, 425)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(335, 28)
        ui_status.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(49, 398)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 13
        Label3.Text = "Trạng thái:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(49, 190)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 19)
        Label2.TabIndex = 12
        Label2.Text = "Tên công việc:"
        ' 
        ' ui_name
        ' 
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(54, 217)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(335, 26)
        ui_name.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(49, 91)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(202, 19)
        Label1.TabIndex = 10
        Label1.Text = "Mã chức danh công việc:"
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(54, 118)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(335, 26)
        ui_code.TabIndex = 9
        ' 
        ' ui_department
        ' 
        ui_department.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_department.FormattingEnabled = True
        ui_department.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_department.Location = New Point(54, 320)
        ui_department.Margin = New Padding(4, 3, 4, 3)
        ui_department.Name = "ui_department"
        ui_department.Size = New Size(335, 28)
        ui_department.TabIndex = 18
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(49, 293)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(169, 19)
        Label5.TabIndex = 17
        Label5.Text = "Phòng ban thuộc về:"
        ' 
        ' grb_salary_mult
        ' 
        grb_salary_mult.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grb_salary_mult.Location = New Point(518, 91)
        grb_salary_mult.Margin = New Padding(4, 3, 4, 3)
        grb_salary_mult.Name = "grb_salary_mult"
        grb_salary_mult.Padding = New Padding(4, 3, 4, 3)
        grb_salary_mult.Size = New Size(662, 570)
        grb_salary_mult.TabIndex = 19
        grb_salary_mult.TabStop = False
        grb_salary_mult.Text = "Giải hệ số lương theo cấp bậc"
        ' 
        ' Job_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1239, 730)
        Controls.Add(grb_salary_mult)
        Controls.Add(ui_department)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ui_name)
        Controls.Add(Label1)
        Controls.Add(ui_code)
        Name = "Job_CRUD_Frm"
        Text = "Job_CRUD_Frm"
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(ui_name, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_department, 0)
        Controls.SetChildIndex(grb_salary_mult, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents ui_department As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grb_salary_mult As GroupBox
End Class
