<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Attendance_CRUD_Frm
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
        Panel1 = New Panel()
        ui_early_hours = New NumericUpDown()
        ui_late_hours = New NumericUpDown()
        ui_overtime_hours = New NumericUpDown()
        ui_office_hours = New NumericUpDown()
        Label10 = New Label()
        Label9 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        ui_code = New TextBox()
        Label6 = New Label()
        ui_of_date = New DateTimePicker()
        ui_shift = New ComboBox()
        Label5 = New Label()
        ui_employee = New ComboBox()
        Label4 = New Label()
        ui_note = New RichTextBox()
        ui_status = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(ui_early_hours, ComponentModel.ISupportInitialize).BeginInit()
        CType(ui_late_hours, ComponentModel.ISupportInitialize).BeginInit()
        CType(ui_overtime_hours, ComponentModel.ISupportInitialize).BeginInit()
        CType(ui_office_hours, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ui_early_hours)
        Panel1.Controls.Add(ui_late_hours)
        Panel1.Controls.Add(ui_overtime_hours)
        Panel1.Controls.Add(ui_office_hours)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(ui_code)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(ui_of_date)
        Panel1.Controls.Add(ui_shift)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(ui_employee)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(ui_note)
        Panel1.Controls.Add(ui_status)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 34)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1260, 486)
        Panel1.TabIndex = 28
        ' 
        ' ui_early_hours
        ' 
        ui_early_hours.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_early_hours.DecimalPlaces = 2
        ui_early_hours.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_early_hours.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_early_hours.Location = New Point(483, 391)
        ui_early_hours.Margin = New Padding(4, 3, 4, 3)
        ui_early_hours.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        ui_early_hours.Name = "ui_early_hours"
        ui_early_hours.Size = New Size(308, 26)
        ui_early_hours.TabIndex = 47
        ' 
        ' ui_late_hours
        ' 
        ui_late_hours.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_late_hours.DecimalPlaces = 2
        ui_late_hours.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_late_hours.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_late_hours.Location = New Point(483, 290)
        ui_late_hours.Margin = New Padding(4, 3, 4, 3)
        ui_late_hours.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        ui_late_hours.Name = "ui_late_hours"
        ui_late_hours.Size = New Size(308, 26)
        ui_late_hours.TabIndex = 46
        ' 
        ' ui_overtime_hours
        ' 
        ui_overtime_hours.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_overtime_hours.DecimalPlaces = 2
        ui_overtime_hours.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_overtime_hours.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_overtime_hours.Location = New Point(483, 186)
        ui_overtime_hours.Margin = New Padding(4, 3, 4, 3)
        ui_overtime_hours.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        ui_overtime_hours.Name = "ui_overtime_hours"
        ui_overtime_hours.Size = New Size(308, 26)
        ui_overtime_hours.TabIndex = 45
        ' 
        ' ui_office_hours
        ' 
        ui_office_hours.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_office_hours.DecimalPlaces = 2
        ui_office_hours.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_office_hours.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_office_hours.Location = New Point(483, 85)
        ui_office_hours.Margin = New Padding(4, 3, 4, 3)
        ui_office_hours.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        ui_office_hours.Name = "ui_office_hours"
        ui_office_hours.Size = New Size(308, 26)
        ui_office_hours.TabIndex = 44
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(478, 268)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(150, 19)
        Label10.TabIndex = 43
        Label10.Text = "Tổng giờ đi muộn:"
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(478, 369)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(144, 19)
        Label9.TabIndex = 42
        Label9.Text = "Tổng giờ về sớm:"
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(478, 164)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(144, 19)
        Label7.TabIndex = 41
        Label7.Text = "Tổng giờ tăng ca:"
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(75, 67)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(126, 19)
        Label8.TabIndex = 40
        Label8.Text = "Mã chấm công:"
        ' 
        ' ui_code
        ' 
        ui_code.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(80, 89)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(308, 26)
        ui_code.TabIndex = 39
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(75, 268)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(144, 19)
        Label6.TabIndex = 38
        Label6.Text = "Ngày chấm công:"
        ' 
        ' ui_of_date
        ' 
        ui_of_date.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_of_date.CustomFormat = "dd-MM-yyyy"
        ui_of_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_of_date.Format = DateTimePickerFormat.Custom
        ui_of_date.Location = New Point(80, 290)
        ui_of_date.Margin = New Padding(4, 3, 4, 3)
        ui_of_date.Name = "ui_of_date"
        ui_of_date.Size = New Size(308, 26)
        ui_of_date.TabIndex = 37
        ' 
        ' ui_shift
        ' 
        ui_shift.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_shift.DropDownStyle = ComboBoxStyle.DropDownList
        ui_shift.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_shift.FormattingEnabled = True
        ui_shift.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_shift.Location = New Point(80, 389)
        ui_shift.Margin = New Padding(4, 3, 4, 3)
        ui_shift.Name = "ui_shift"
        ui_shift.Size = New Size(308, 28)
        ui_shift.TabIndex = 36
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(75, 369)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(67, 19)
        Label5.TabIndex = 35
        Label5.Text = "Ca làm:"
        ' 
        ' ui_employee
        ' 
        ui_employee.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_employee.DropDownHeight = 200
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.DropDownWidth = 10
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.IntegralHeight = False
        ui_employee.ItemHeight = 20
        ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_employee.Location = New Point(80, 186)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(308, 28)
        ui_employee.TabIndex = 34
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(873, 164)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 33
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_note
        ' 
        ui_note.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(878, 182)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(308, 237)
        ui_note.TabIndex = 32
        ui_note.Text = ""
        ' 
        ' ui_status
        ' 
        ui_status.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(878, 87)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(308, 28)
        ui_status.TabIndex = 31
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(873, 67)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 30
        Label3.Text = "Trạng thái:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(478, 67)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(174, 19)
        Label2.TabIndex = 29
        Label2.Text = "Tổng giờ hành chính:"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(75, 164)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 19)
        Label1.TabIndex = 28
        Label1.Text = "Nhân viên:"
        ' 
        ' Attendance_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1260, 520)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        Name = "Attendance_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Account_CRUD"
        Controls.SetChildIndex(Panel1, 0)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(ui_early_hours, ComponentModel.ISupportInitialize).EndInit()
        CType(ui_late_hours, ComponentModel.ISupportInitialize).EndInit()
        CType(ui_overtime_hours, ComponentModel.ISupportInitialize).EndInit()
        CType(ui_office_hours, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ui_early_hours As NumericUpDown
    Friend WithEvents ui_late_hours As NumericUpDown
    Friend WithEvents ui_overtime_hours As NumericUpDown
    Friend WithEvents ui_office_hours As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_of_date As DateTimePicker
    Friend WithEvents ui_shift As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
