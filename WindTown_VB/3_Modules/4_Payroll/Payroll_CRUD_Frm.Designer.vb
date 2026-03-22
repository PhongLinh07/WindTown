<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Payroll_CRUD_Frm
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
        SplitContainer1 = New SplitContainer()
        Panel1 = New Panel()
        ui_level = New TextBox()
        ui_job = New TextBox()
        ui_contract = New TextBox()
        Label9 = New Label()
        ui_position = New TextBox()
        Label5 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        ui_employee = New ComboBox()
        Label2 = New Label()
        ui_pay_period = New ComboBox()
        Label10 = New Label()
        Label4 = New Label()
        ui_note = New RichTextBox()
        ui_status = New ComboBox()
        Label3 = New Label()
        Label1 = New Label()
        ui_code = New TextBox()
        grb_pay_item = New GroupBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 34)
        SplitContainer1.Margin = New Padding(4, 3, 4, 3)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(Panel1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(grb_pay_item)
        SplitContainer1.Size = New Size(1774, 771)
        SplitContainer1.SplitterDistance = 780
        SplitContainer1.SplitterWidth = 5
        SplitContainer1.TabIndex = 68
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ui_level)
        Panel1.Controls.Add(ui_job)
        Panel1.Controls.Add(ui_contract)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(ui_position)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(ui_employee)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(ui_pay_period)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(ui_note)
        Panel1.Controls.Add(ui_status)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(ui_code)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 3, 4, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(780, 771)
        Panel1.TabIndex = 85
        ' 
        ' ui_level
        ' 
        ui_level.Enabled = False
        ui_level.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_level.Location = New Point(35, 684)
        ui_level.Margin = New Padding(4, 3, 4, 3)
        ui_level.Name = "ui_level"
        ui_level.ReadOnly = True
        ui_level.Size = New Size(317, 26)
        ui_level.TabIndex = 102
        ' 
        ' ui_job
        ' 
        ui_job.Enabled = False
        ui_job.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_job.Location = New Point(35, 588)
        ui_job.Margin = New Padding(4, 3, 4, 3)
        ui_job.Name = "ui_job"
        ui_job.ReadOnly = True
        ui_job.Size = New Size(317, 26)
        ui_job.TabIndex = 101
        ' 
        ' ui_contract
        ' 
        ui_contract.Enabled = False
        ui_contract.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_contract.Location = New Point(35, 481)
        ui_contract.Margin = New Padding(4, 3, 4, 3)
        ui_contract.Name = "ui_contract"
        ui_contract.ReadOnly = True
        ui_contract.Size = New Size(317, 26)
        ui_contract.TabIndex = 100
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Enabled = False
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.WindowText
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(30, 350)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(104, 19)
        Label9.TabIndex = 99
        Label9.Text = "Mã chức vụ:"
        ' 
        ' ui_position
        ' 
        ui_position.Enabled = False
        ui_position.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_position.Location = New Point(35, 376)
        ui_position.Margin = New Padding(4, 3, 4, 3)
        ui_position.Name = "ui_position"
        ui_position.ReadOnly = True
        ui_position.Size = New Size(317, 26)
        ui_position.TabIndex = 98
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Enabled = False
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.WindowText
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(30, 456)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 19)
        Label5.TabIndex = 97
        Label5.Text = "Mã hợp đồng:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Enabled = False
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.WindowText
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(30, 659)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(143, 19)
        Label7.TabIndex = 96
        Label7.Text = "Trình độ kỹ năng:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Enabled = False
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.WindowText
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(30, 563)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 19)
        Label6.TabIndex = 95
        Label6.Text = "Chức danh công việc:"
        ' 
        ' ui_employee
        ' 
        ui_employee.DropDownHeight = 200
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.DropDownWidth = 10
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.IntegralHeight = False
        ui_employee.Location = New Point(35, 273)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.MaxDropDownItems = 10
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(317, 28)
        ui_employee.TabIndex = 94
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(30, 247)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 19)
        Label2.TabIndex = 93
        Label2.Text = "Nhân viên:"
        ' 
        ' ui_pay_period
        ' 
        ui_pay_period.DropDownHeight = 200
        ui_pay_period.DropDownStyle = ComboBoxStyle.DropDownList
        ui_pay_period.DropDownWidth = 10
        ui_pay_period.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_pay_period.FormattingEnabled = True
        ui_pay_period.IntegralHeight = False
        ui_pay_period.Location = New Point(35, 168)
        ui_pay_period.Margin = New Padding(4, 3, 4, 3)
        ui_pay_period.Name = "ui_pay_period"
        ui_pay_period.Size = New Size(317, 28)
        ui_pay_period.TabIndex = 92
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(30, 142)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(120, 19)
        Label10.TabIndex = 91
        Label10.Text = "Chu kỳ lương:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(443, 142)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 90
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(448, 168)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(316, 137)
        ui_note.TabIndex = 89
        ui_note.Text = ""
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Location = New Point(448, 65)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(316, 28)
        ui_status.TabIndex = 88
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(443, 40)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 87
        Label3.Text = "Trạng thái:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(30, 39)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 19)
        Label1.TabIndex = 86
        Label1.Text = "Mã bảng lương:"
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(35, 66)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(317, 26)
        ui_code.TabIndex = 85
        ' 
        ' grb_pay_item
        ' 
        grb_pay_item.AutoSize = True
        grb_pay_item.Dock = DockStyle.Fill
        grb_pay_item.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grb_pay_item.Location = New Point(0, 0)
        grb_pay_item.Margin = New Padding(4, 3, 4, 3)
        grb_pay_item.Name = "grb_pay_item"
        grb_pay_item.Padding = New Padding(4, 3, 4, 3)
        grb_pay_item.Size = New Size(989, 771)
        grb_pay_item.TabIndex = 68
        grb_pay_item.TabStop = False
        grb_pay_item.Text = "Chi tiết các khoản tiền:"
        ' 
        ' Payroll_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1774, 805)
        Controls.Add(SplitContainer1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Payroll_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Department_CRUD"
        Controls.SetChildIndex(SplitContainer1, 0)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grb_pay_item As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ui_level As TextBox
    Friend WithEvents ui_job As TextBox
    Friend WithEvents ui_contract As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ui_position As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_pay_period As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_code As TextBox
End Class
