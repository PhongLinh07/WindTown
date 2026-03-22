<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Leave_CRUD_Frm
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        ui_status = New ComboBox()
        ui_reason = New RichTextBox()
        Label4 = New Label()
        ui_employee = New ComboBox()
        ui_start_date = New DateTimePicker()
        Label6 = New Label()
        Label8 = New Label()
        ui_code = New TextBox()
        Label11 = New Label()
        ui_leave_type = New ComboBox()
        Label12 = New Label()
        Label5 = New Label()
        ui_note = New RichTextBox()
        ui_total_days = New NumericUpDown()
        ui_approved = New ComboBox()
        CType(ui_total_days, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(70, 193)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(81, 16)
        Label1.TabIndex = 1
        Label1.Text = "Nhân viên:"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(514, 193)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 16)
        Label2.TabIndex = 3
        Label2.Text = "Tổng ngày nghỉ:"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(913, 91)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 16)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái:"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(917, 113)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(308, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_reason
        ' 
        ui_reason.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_reason.Location = New Point(518, 325)
        ui_reason.Margin = New Padding(4, 3, 4, 3)
        ui_reason.Name = "ui_reason"
        ui_reason.Size = New Size(308, 140)
        ui_reason.TabIndex = 7
        ui_reason.Text = "Việc cá nhân."
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(514, 303)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(80, 16)
        Label4.TabIndex = 8
        Label4.Text = "Lí do nghỉ:"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_employee
        ' 
        ui_employee.DropDownHeight = 200
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.DropDownWidth = 10
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.IntegralHeight = False
        ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_employee.Location = New Point(74, 215)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(345, 28)
        ui_employee.TabIndex = 9
        ' 
        ' ui_start_date
        ' 
        ui_start_date.CustomFormat = "dd-MM-yyyy"
        ui_start_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_start_date.Format = DateTimePickerFormat.Custom
        ui_start_date.Location = New Point(518, 115)
        ui_start_date.Margin = New Padding(4, 3, 4, 3)
        ui_start_date.Name = "ui_start_date"
        ui_start_date.Size = New Size(308, 26)
        ui_start_date.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(514, 93)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(101, 16)
        Label6.TabIndex = 13
        Label6.Text = "Ngày bắt đầu:"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(70, 93)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(71, 16)
        Label8.TabIndex = 19
        Label8.Text = "Mã phép:"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(74, 115)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(345, 26)
        ui_code.TabIndex = 18
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(70, 303)
        Label11.Margin = New Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New Size(127, 16)
        Label11.TabIndex = 24
        Label11.Text = "Người phê duyệt:"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_leave_type
        ' 
        ui_leave_type.DropDownStyle = ComboBoxStyle.DropDownList
        ui_leave_type.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_leave_type.FormattingEnabled = True
        ui_leave_type.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_leave_type.Location = New Point(74, 434)
        ui_leave_type.Margin = New Padding(4, 3, 4, 3)
        ui_leave_type.Name = "ui_leave_type"
        ui_leave_type.Size = New Size(345, 28)
        ui_leave_type.TabIndex = 27
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ImageAlign = ContentAlignment.MiddleLeft
        Label12.Location = New Point(70, 414)
        Label12.Margin = New Padding(0)
        Label12.Name = "Label12"
        Label12.Size = New Size(79, 16)
        Label12.TabIndex = 26
        Label12.Text = "Loại phép:"
        Label12.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(913, 193)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(65, 16)
        Label5.TabIndex = 29
        Label5.Text = "Ghi chú:"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(917, 215)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(308, 251)
        ui_note.TabIndex = 28
        ui_note.Text = ""
        ' 
        ' ui_total_days
        ' 
        ui_total_days.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_total_days.Location = New Point(518, 215)
        ui_total_days.Margin = New Padding(4, 3, 4, 3)
        ui_total_days.Name = "ui_total_days"
        ui_total_days.Size = New Size(308, 29)
        ui_total_days.TabIndex = 31
        ' 
        ' ui_approved
        ' 
        ui_approved.DropDownHeight = 200
        ui_approved.DropDownStyle = ComboBoxStyle.DropDownList
        ui_approved.DropDownWidth = 10
        ui_approved.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_approved.FormattingEnabled = True
        ui_approved.IntegralHeight = False
        ui_approved.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_approved.Location = New Point(74, 325)
        ui_approved.Margin = New Padding(4, 3, 4, 3)
        ui_approved.Name = "ui_approved"
        ui_approved.Size = New Size(345, 28)
        ui_approved.TabIndex = 32
        ' 
        ' Leave_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1296, 539)
        Controls.Add(ui_approved)
        Controls.Add(ui_total_days)
        Controls.Add(Label5)
        Controls.Add(ui_note)
        Controls.Add(ui_leave_type)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label8)
        Controls.Add(ui_code)
        Controls.Add(Label6)
        Controls.Add(ui_start_date)
        Controls.Add(ui_employee)
        Controls.Add(Label4)
        Controls.Add(ui_reason)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Leave_CRUD_Frm"
        Text = "Account_CRUD"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_reason, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_employee, 0)
        Controls.SetChildIndex(ui_start_date, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(Label11, 0)
        Controls.SetChildIndex(Label12, 0)
        Controls.SetChildIndex(ui_leave_type, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_total_days, 0)
        Controls.SetChildIndex(ui_approved, 0)
        CType(ui_total_days, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_reason As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents ui_start_date As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_leave_type As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents ui_total_days As NumericUpDown
    Friend WithEvents ui_approved As ComboBox
End Class
