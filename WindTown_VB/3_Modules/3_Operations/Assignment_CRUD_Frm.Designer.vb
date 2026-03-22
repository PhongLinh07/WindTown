<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Assignment_CRUD_Frm
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
        ui_code = New TextBox()
        Label1 = New Label()
        Label3 = New Label()
        ui_status = New ComboBox()
        ui_note = New RichTextBox()
        Label4 = New Label()
        Label8 = New Label()
        ui_end_date = New DateTimePicker()
        Label12 = New Label()
        ui_start_date = New DateTimePicker()
        ui_project = New ComboBox()
        Label10 = New Label()
        ui_role = New ComboBox()
        Label11 = New Label()
        ui_level = New TextBox()
        ui_contract = New TextBox()
        Label9 = New Label()
        ui_position = New TextBox()
        Label5 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        ui_employee = New ComboBox()
        Label2 = New Label()
        ui_job = New TextBox()
        SuspendLayout()
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(70, 120)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(308, 26)
        ui_code.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(65, 93)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(123, 19)
        Label1.TabIndex = 1
        Label1.Text = "Mã phân công:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(891, 93)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái:"
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Location = New Point(896, 118)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(320, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(896, 222)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(320, 339)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(891, 195)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(65, 504)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(120, 19)
        Label8.TabIndex = 37
        Label8.Text = "Ngày kết thúc:"
        ' 
        ' ui_end_date
        ' 
        ui_end_date.CustomFormat = "dd-MM-yyyy"
        ui_end_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_end_date.Format = DateTimePickerFormat.Custom
        ui_end_date.Location = New Point(70, 531)
        ui_end_date.Margin = New Padding(4, 3, 4, 3)
        ui_end_date.Name = "ui_end_date"
        ui_end_date.Size = New Size(308, 26)
        ui_end_date.TabIndex = 36
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ImageAlign = ContentAlignment.MiddleLeft
        Label12.Location = New Point(65, 408)
        Label12.Margin = New Padding(0)
        Label12.Name = "Label12"
        Label12.Size = New Size(116, 19)
        Label12.TabIndex = 35
        Label12.Text = "Ngày bắt đầu:"
        ' 
        ' ui_start_date
        ' 
        ui_start_date.CustomFormat = "dd-MM-yyyy"
        ui_start_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_start_date.Format = DateTimePickerFormat.Custom
        ui_start_date.Location = New Point(70, 435)
        ui_start_date.Margin = New Padding(4, 3, 4, 3)
        ui_start_date.Name = "ui_start_date"
        ui_start_date.Size = New Size(308, 26)
        ui_start_date.TabIndex = 34
        ' 
        ' ui_project
        ' 
        ui_project.DropDownStyle = ComboBoxStyle.DropDownList
        ui_project.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_project.FormattingEnabled = True
        ui_project.Location = New Point(70, 223)
        ui_project.Margin = New Padding(4, 3, 4, 3)
        ui_project.Name = "ui_project"
        ui_project.Size = New Size(308, 28)
        ui_project.TabIndex = 51
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(65, 196)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(62, 19)
        Label10.TabIndex = 50
        Label10.Text = "Dự án:"
        ' 
        ' ui_role
        ' 
        ui_role.DropDownStyle = ComboBoxStyle.DropDownList
        ui_role.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_role.FormattingEnabled = True
        ui_role.Location = New Point(70, 325)
        ui_role.Margin = New Padding(4, 3, 4, 3)
        ui_role.Name = "ui_role"
        ui_role.Size = New Size(308, 28)
        ui_role.TabIndex = 53
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(65, 299)
        Label11.Margin = New Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New Size(159, 19)
        Label11.TabIndex = 52
        Label11.Text = "Quyền trong dự án:"
        ' 
        ' ui_level
        ' 
        ui_level.Enabled = False
        ui_level.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_level.Location = New Point(477, 531)
        ui_level.Margin = New Padding(4, 3, 4, 3)
        ui_level.Name = "ui_level"
        ui_level.ReadOnly = True
        ui_level.Size = New Size(339, 26)
        ui_level.TabIndex = 66
        ' 
        ' ui_contract
        ' 
        ui_contract.Enabled = False
        ui_contract.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_contract.Location = New Point(477, 328)
        ui_contract.Margin = New Padding(4, 3, 4, 3)
        ui_contract.Name = "ui_contract"
        ui_contract.ReadOnly = True
        ui_contract.Size = New Size(339, 26)
        ui_contract.TabIndex = 64
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Enabled = False
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.WindowText
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(472, 196)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(104, 19)
        Label9.TabIndex = 63
        Label9.Text = "Mã chức vụ:"
        ' 
        ' ui_position
        ' 
        ui_position.Enabled = False
        ui_position.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_position.Location = New Point(477, 223)
        ui_position.Margin = New Padding(4, 3, 4, 3)
        ui_position.Name = "ui_position"
        ui_position.ReadOnly = True
        ui_position.Size = New Size(339, 26)
        ui_position.TabIndex = 62
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Enabled = False
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.WindowText
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(472, 302)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 19)
        Label5.TabIndex = 61
        Label5.Text = "Mã hợp đồng:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Enabled = False
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.WindowText
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(472, 505)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(143, 19)
        Label7.TabIndex = 60
        Label7.Text = "Trình độ kỹ năng:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Enabled = False
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.WindowText
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(472, 410)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 19)
        Label6.TabIndex = 59
        Label6.Text = "Chức danh công việc:"
        ' 
        ' ui_employee
        ' 
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.DropDownWidth = 10
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.Location = New Point(477, 120)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(339, 28)
        ui_employee.TabIndex = 58
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(472, 93)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 19)
        Label2.TabIndex = 57
        Label2.Text = "Nhân viên:"
        ' 
        ' ui_job
        ' 
        ui_job.Enabled = False
        ui_job.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_job.Location = New Point(477, 435)
        ui_job.Margin = New Padding(4, 3, 4, 3)
        ui_job.Name = "ui_job"
        ui_job.ReadOnly = True
        ui_job.Size = New Size(339, 26)
        ui_job.TabIndex = 65
        ' 
        ' Assignment_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1302, 623)
        Controls.Add(ui_level)
        Controls.Add(ui_job)
        Controls.Add(ui_contract)
        Controls.Add(Label9)
        Controls.Add(ui_position)
        Controls.Add(Label5)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(ui_employee)
        Controls.Add(Label2)
        Controls.Add(ui_role)
        Controls.Add(Label11)
        Controls.Add(ui_project)
        Controls.Add(Label10)
        Controls.Add(Label8)
        Controls.Add(ui_end_date)
        Controls.Add(Label12)
        Controls.Add(ui_start_date)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(ui_code)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Assignment_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Department_CRUD"
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_start_date, 0)
        Controls.SetChildIndex(Label12, 0)
        Controls.SetChildIndex(ui_end_date, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(Label10, 0)
        Controls.SetChildIndex(ui_project, 0)
        Controls.SetChildIndex(Label11, 0)
        Controls.SetChildIndex(ui_role, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(ui_employee, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(Label7, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_position, 0)
        Controls.SetChildIndex(Label9, 0)
        Controls.SetChildIndex(ui_contract, 0)
        Controls.SetChildIndex(ui_job, 0)
        Controls.SetChildIndex(ui_level, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_end_date As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents ui_start_date As DateTimePicker
    Friend WithEvents ui_project As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ui_role As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_level As TextBox
    Friend WithEvents ui_contract As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ui_position As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_job As TextBox
End Class
