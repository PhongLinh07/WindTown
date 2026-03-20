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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ui_employee = New System.Windows.Forms.ComboBox()
        Me.ui_start_date = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ui_end_date = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ui_code = New System.Windows.Forms.TextBox()
        Me.ui_base_salary = New System.Windows.Forms.NumericUpDown()
        CType(Me.ui_base_salary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(59, 152)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mã nhân viên:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(60, 238)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Lương cơ bản:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(405, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Trạng thái:"
        '
        'ui_status
        '
        Me.ui_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_status.FormattingEnabled = True
        Me.ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_status.Location = New System.Drawing.Point(409, 100)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(265, 28)
        Me.ui_status.TabIndex = 6
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(409, 179)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(264, 274)
        Me.ui_note.TabIndex = 7
        Me.ui_note.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(405, 156)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ghi chú:"
        '
        'ui_employee
        '
        Me.ui_employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ui_employee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_employee.FormattingEnabled = True
        Me.ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_employee.Location = New System.Drawing.Point(63, 175)
        Me.ui_employee.Name = "ui_employee"
        Me.ui_employee.Size = New System.Drawing.Size(265, 28)
        Me.ui_employee.TabIndex = 9
        '
        'ui_start_date
        '
        Me.ui_start_date.CustomFormat = "dd-MM-yyyy"
        Me.ui_start_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ui_start_date.Location = New System.Drawing.Point(63, 348)
        Me.ui_start_date.Name = "ui_start_date"
        Me.ui_start_date.Size = New System.Drawing.Size(265, 26)
        Me.ui_start_date.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(59, 325)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Ngày bắt đầu:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(59, 404)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 19)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Ngày kết thúc:"
        '
        'ui_end_date
        '
        Me.ui_end_date.CustomFormat = "dd-MM-yyyy"
        Me.ui_end_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ui_end_date.Location = New System.Drawing.Point(63, 427)
        Me.ui_end_date.Name = "ui_end_date"
        Me.ui_end_date.Size = New System.Drawing.Size(265, 26)
        Me.ui_end_date.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(59, 75)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 19)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Mã hợp đồng:"
        '
        'ui_code
        '
        Me.ui_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_code.Location = New System.Drawing.Point(63, 98)
        Me.ui_code.Name = "ui_code"
        Me.ui_code.Size = New System.Drawing.Size(265, 26)
        Me.ui_code.TabIndex = 16
        '
        'ui_base_salary
        '
        Me.ui_base_salary.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_base_salary.Increment = New Decimal(New Integer() {-1486618624, 232830643, 0, 0})
        Me.ui_base_salary.Location = New System.Drawing.Point(64, 260)
        Me.ui_base_salary.Maximum = New Decimal(New Integer() {-1486618624, 232830643, 0, 0})
        Me.ui_base_salary.Name = "ui_base_salary"
        Me.ui_base_salary.Size = New System.Drawing.Size(264, 26)
        Me.ui_base_salary.TabIndex = 66
        Me.ui_base_salary.ThousandsSeparator = True
        '
        'Contract_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(750, 510)
        Me.Controls.Add(Me.ui_base_salary)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ui_code)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ui_end_date)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ui_start_date)
        Me.Controls.Add(Me.ui_employee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_note)
        Me.Controls.Add(Me.ui_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Contract_CRUD_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Account_CRUD"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_status, 0)
        Me.Controls.SetChildIndex(Me.ui_note, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ui_employee, 0)
        Me.Controls.SetChildIndex(Me.ui_start_date, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ui_end_date, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.ui_code, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.ui_base_salary, 0)
        CType(Me.ui_base_salary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
