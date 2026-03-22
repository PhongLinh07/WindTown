<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contract_CRUD_Frm
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
        ui_note = New RichTextBox()
        Label4 = New Label()
        ui_employee = New ComboBox()
        ui_start_date = New DateTimePicker()
        Label6 = New Label()
        Label7 = New Label()
        ui_end_date = New DateTimePicker()
        Label8 = New Label()
        ui_code = New TextBox()
        ui_base_salary = New NumericUpDown()
        CType(ui_base_salary, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(69, 175)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 19)
        Label1.TabIndex = 1
        Label1.Text = "Mã nhân viên:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(70, 275)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(125, 19)
        Label2.TabIndex = 3
        Label2.Text = "Lương cơ bản:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(472, 89)
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
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(477, 115)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(308, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(477, 207)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(307, 316)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(472, 180)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_employee
        ' 
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_employee.Location = New Point(74, 202)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(308, 28)
        ui_employee.TabIndex = 9
        ' 
        ' ui_start_date
        ' 
        ui_start_date.CustomFormat = "dd-MM-yyyy"
        ui_start_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_start_date.Format = DateTimePickerFormat.Custom
        ui_start_date.Location = New Point(74, 402)
        ui_start_date.Margin = New Padding(4, 3, 4, 3)
        ui_start_date.Name = "ui_start_date"
        ui_start_date.Size = New Size(308, 26)
        ui_start_date.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(69, 375)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(116, 19)
        Label6.TabIndex = 13
        Label6.Text = "Ngày bắt đầu:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(69, 466)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(120, 19)
        Label7.TabIndex = 15
        Label7.Text = "Ngày kết thúc:"
        ' 
        ' ui_end_date
        ' 
        ui_end_date.CustomFormat = "dd-MM-yyyy"
        ui_end_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_end_date.Format = DateTimePickerFormat.Custom
        ui_end_date.Location = New Point(74, 493)
        ui_end_date.Margin = New Padding(4, 3, 4, 3)
        ui_end_date.Name = "ui_end_date"
        ui_end_date.Size = New Size(308, 26)
        ui_end_date.TabIndex = 14
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(69, 87)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(116, 19)
        Label8.TabIndex = 17
        Label8.Text = "Mã hợp đồng:"
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(74, 113)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(308, 26)
        ui_code.TabIndex = 16
        ' 
        ' ui_base_salary
        ' 
        ui_base_salary.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_base_salary.Increment = New Decimal(New Integer() {-1486618624, 232830643, 0, 0})
        ui_base_salary.Location = New Point(75, 300)
        ui_base_salary.Margin = New Padding(4, 3, 4, 3)
        ui_base_salary.Maximum = New Decimal(New Integer() {-1486618624, 232830643, 0, 0})
        ui_base_salary.Name = "ui_base_salary"
        ui_base_salary.Size = New Size(308, 26)
        ui_base_salary.TabIndex = 66
        ui_base_salary.ThousandsSeparator = True
        ' 
        ' Contract_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(875, 588)
        Controls.Add(ui_base_salary)
        Controls.Add(Label8)
        Controls.Add(ui_code)
        Controls.Add(Label7)
        Controls.Add(ui_end_date)
        Controls.Add(Label6)
        Controls.Add(ui_start_date)
        Controls.Add(ui_employee)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Contract_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Account_CRUD"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_employee, 0)
        Controls.SetChildIndex(ui_start_date, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_end_date, 0)
        Controls.SetChildIndex(Label7, 0)
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(ui_base_salary, 0)
        CType(ui_base_salary, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents ui_start_date As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ui_end_date As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents ui_base_salary As NumericUpDown
End Class
