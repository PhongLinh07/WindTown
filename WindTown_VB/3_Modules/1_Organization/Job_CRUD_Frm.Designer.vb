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
        ui_status = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        ui_name = New TextBox()
        Label1 = New Label()
        ui_code = New TextBox()
        ui_department = New ComboBox()
        Label5 = New Label()
        grb_salary_mult = New GroupBox()
        ui_note = New RichTextBox()
        SplitContainer1 = New SplitContainer()
        Panel1 = New Panel()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(64, 460)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 16
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_status
        ' 
        ui_status.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(69, 385)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(369, 28)
        ui_status.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(64, 358)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 13
        Label3.Text = "Trạng thái:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(64, 150)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 19)
        Label2.TabIndex = 12
        Label2.Text = "Tên công việc:"
        ' 
        ' ui_name
        ' 
        ui_name.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(69, 177)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(369, 26)
        ui_name.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(64, 51)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(202, 19)
        Label1.TabIndex = 10
        Label1.Text = "Mã chức danh công việc:"
        ' 
        ' ui_code
        ' 
        ui_code.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(69, 78)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(369, 26)
        ui_code.TabIndex = 9
        ' 
        ' ui_department
        ' 
        ui_department.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_department.DropDownStyle = ComboBoxStyle.DropDownList
        ui_department.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_department.FormattingEnabled = True
        ui_department.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_department.Location = New Point(69, 280)
        ui_department.Margin = New Padding(4, 3, 4, 3)
        ui_department.Name = "ui_department"
        ui_department.Size = New Size(369, 28)
        ui_department.TabIndex = 18
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(64, 253)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(169, 19)
        Label5.TabIndex = 17
        Label5.Text = "Phòng ban thuộc về:"
        ' 
        ' grb_salary_mult
        ' 
        grb_salary_mult.Dock = DockStyle.Fill
        grb_salary_mult.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grb_salary_mult.Location = New Point(0, 0)
        grb_salary_mult.Margin = New Padding(4, 3, 4, 3)
        grb_salary_mult.Name = "grb_salary_mult"
        grb_salary_mult.Padding = New Padding(4, 3, 4, 3)
        grb_salary_mult.Size = New Size(743, 696)
        grb_salary_mult.TabIndex = 19
        grb_salary_mult.TabStop = False
        grb_salary_mult.Text = "Giải hệ số lương theo cấp bậc"
        ' 
        ' ui_note
        ' 
        ui_note.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(69, 486)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(369, 134)
        ui_note.TabIndex = 15
        ui_note.Text = ""
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 34)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(Panel1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(grb_salary_mult)
        SplitContainer1.Size = New Size(1239, 696)
        SplitContainer1.SplitterDistance = 492
        SplitContainer1.TabIndex = 20
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(ui_note)
        Panel1.Controls.Add(ui_department)
        Panel1.Controls.Add(ui_code)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(ui_name)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(ui_status)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(492, 696)
        Panel1.TabIndex = 19
        ' 
        ' Job_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1239, 730)
        Controls.Add(SplitContainer1)
        Name = "Job_CRUD_Frm"
        Text = "Job_CRUD_Frm"
        Controls.SetChildIndex(SplitContainer1, 0)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents ui_department As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grb_salary_mult As GroupBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
End Class
