<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Position_CRUD_Frm
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
        ui_employee = New ComboBox()
        Label2 = New Label()
        Label6 = New Label()
        ui_job = New ComboBox()
        Label7 = New Label()
        ui_level = New ComboBox()
        ui_contract = New ComboBox()
        Label5 = New Label()
        ui_mult = New NumericUpDown()
        Label9 = New Label()
        CType(ui_mult, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(70, 112)
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
        Label1.Location = New Point(65, 85)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 19)
        Label1.TabIndex = 1
        Label1.Text = "Mã chức vụ:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(477, 278)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái:"
        ' 
        ' ui_status
        ' 
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(482, 307)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(308, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(482, 414)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(308, 228)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(477, 388)
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
        Label8.Location = New Point(477, 179)
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
        ui_end_date.Location = New Point(482, 205)
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
        Label12.Location = New Point(477, 88)
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
        ui_start_date.Location = New Point(482, 114)
        ui_start_date.Margin = New Padding(4, 3, 4, 3)
        ui_start_date.Name = "ui_start_date"
        ui_start_date.Size = New Size(308, 26)
        ui_start_date.TabIndex = 34
        ' 
        ' ui_employee
        ' 
        ui_employee.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.Location = New Point(70, 307)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(308, 28)
        ui_employee.TabIndex = 39
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(65, 280)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 19)
        Label2.TabIndex = 38
        Label2.Text = "Nhân viên:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(65, 388)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 19)
        Label6.TabIndex = 42
        Label6.Text = "Chức danh công việc:"
        ' 
        ' ui_job
        ' 
        ui_job.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ui_job.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_job.FormattingEnabled = True
        ui_job.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_job.Location = New Point(70, 414)
        ui_job.Margin = New Padding(4, 3, 4, 3)
        ui_job.Name = "ui_job"
        ui_job.Size = New Size(308, 28)
        ui_job.TabIndex = 43
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(65, 480)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(143, 19)
        Label7.TabIndex = 44
        Label7.Text = "Cấp bậc kỹ năng:"
        ' 
        ' ui_level
        ' 
        ui_level.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ui_level.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_level.FormattingEnabled = True
        ui_level.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_level.Location = New Point(70, 507)
        ui_level.Margin = New Padding(4, 3, 4, 3)
        ui_level.Name = "ui_level"
        ui_level.Size = New Size(308, 28)
        ui_level.TabIndex = 45
        ' 
        ' ui_contract
        ' 
        ui_contract.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ui_contract.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_contract.FormattingEnabled = True
        ui_contract.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_contract.Location = New Point(70, 205)
        ui_contract.Margin = New Padding(4, 3, 4, 3)
        ui_contract.Name = "ui_contract"
        ui_contract.Size = New Size(308, 28)
        ui_contract.TabIndex = 47
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(65, 179)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(92, 19)
        Label5.TabIndex = 46
        Label5.Text = "Hợp đồng:"
        ' 
        ' ui_mult
        ' 
        ui_mult.DecimalPlaces = 2
        ui_mult.Enabled = False
        ui_mult.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_mult.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        ui_mult.Location = New Point(70, 613)
        ui_mult.Margin = New Padding(4, 3, 4, 3)
        ui_mult.Name = "ui_mult"
        ui_mult.ReadOnly = True
        ui_mult.Size = New Size(309, 26)
        ui_mult.TabIndex = 69
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(66, 586)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(59, 19)
        Label9.TabIndex = 68
        Label9.Text = "Hệ số:"
        ' 
        ' Position_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(868, 719)
        Controls.Add(ui_mult)
        Controls.Add(Label9)
        Controls.Add(ui_contract)
        Controls.Add(Label5)
        Controls.Add(ui_level)
        Controls.Add(Label7)
        Controls.Add(ui_job)
        Controls.Add(Label6)
        Controls.Add(ui_employee)
        Controls.Add(Label2)
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
        Name = "Position_CRUD_Frm"
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
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(ui_employee, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_job, 0)
        Controls.SetChildIndex(Label7, 0)
        Controls.SetChildIndex(ui_level, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_contract, 0)
        Controls.SetChildIndex(Label9, 0)
        Controls.SetChildIndex(ui_mult, 0)
        CType(ui_mult, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_job As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ui_level As ComboBox
    Friend WithEvents ui_contract As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_mult As NumericUpDown
    Friend WithEvents Label9 As Label
End Class
