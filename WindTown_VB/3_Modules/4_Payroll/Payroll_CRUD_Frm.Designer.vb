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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ui_level = New System.Windows.Forms.TextBox()
        Me.ui_job = New System.Windows.Forms.TextBox()
        Me.ui_contract = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ui_position = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ui_employee = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ui_pay_period = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ui_code = New System.Windows.Forms.TextBox()
        Me.grb_pay_item = New System.Windows.Forms.GroupBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 34)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grb_pay_item)
        Me.SplitContainer1.Size = New System.Drawing.Size(1521, 664)
        Me.SplitContainer1.SplitterDistance = 669
        Me.SplitContainer1.TabIndex = 68
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ui_level)
        Me.Panel1.Controls.Add(Me.ui_job)
        Me.Panel1.Controls.Add(Me.ui_contract)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.ui_position)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ui_employee)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ui_pay_period)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ui_note)
        Me.Panel1.Controls.Add(Me.ui_status)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ui_code)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(669, 664)
        Me.Panel1.TabIndex = 85
        '
        'ui_level
        '
        Me.ui_level.Enabled = False
        Me.ui_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_level.Location = New System.Drawing.Point(30, 593)
        Me.ui_level.Name = "ui_level"
        Me.ui_level.ReadOnly = True
        Me.ui_level.Size = New System.Drawing.Size(272, 26)
        Me.ui_level.TabIndex = 102
        '
        'ui_job
        '
        Me.ui_job.Enabled = False
        Me.ui_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_job.Location = New System.Drawing.Point(30, 510)
        Me.ui_job.Name = "ui_job"
        Me.ui_job.ReadOnly = True
        Me.ui_job.Size = New System.Drawing.Size(272, 26)
        Me.ui_job.TabIndex = 101
        '
        'ui_contract
        '
        Me.ui_contract.Enabled = False
        Me.ui_contract.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_contract.Location = New System.Drawing.Point(30, 417)
        Me.ui_contract.Name = "ui_contract"
        Me.ui_contract.ReadOnly = True
        Me.ui_contract.Size = New System.Drawing.Size(272, 26)
        Me.ui_contract.TabIndex = 100
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(26, 303)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 19)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Mã chức vụ:"
        '
        'ui_position
        '
        Me.ui_position.Enabled = False
        Me.ui_position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_position.Location = New System.Drawing.Point(30, 326)
        Me.ui_position.Name = "ui_position"
        Me.ui_position.ReadOnly = True
        Me.ui_position.Size = New System.Drawing.Size(272, 26)
        Me.ui_position.TabIndex = 98
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(26, 395)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 19)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Mã hợp đồng:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(26, 571)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 19)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Trình độ kỹ năng:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(26, 488)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 19)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Chức danh công việc:"
        '
        'ui_employee
        '
        Me.ui_employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ui_employee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_employee.FormattingEnabled = True
        Me.ui_employee.IntegralHeight = False
        Me.ui_employee.Location = New System.Drawing.Point(30, 237)
        Me.ui_employee.MaxDropDownItems = 10
        Me.ui_employee.Name = "ui_employee"
        Me.ui_employee.Size = New System.Drawing.Size(272, 28)
        Me.ui_employee.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(26, 214)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 19)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Nhân viên:"
        '
        'ui_pay_period
        '
        Me.ui_pay_period.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ui_pay_period.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_pay_period.FormattingEnabled = True
        Me.ui_pay_period.Location = New System.Drawing.Point(30, 146)
        Me.ui_pay_period.Name = "ui_pay_period"
        Me.ui_pay_period.Size = New System.Drawing.Size(272, 28)
        Me.ui_pay_period.TabIndex = 92
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(26, 123)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 19)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Chu kỳ lương:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(380, 123)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Ghi chú:"
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(384, 146)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(271, 119)
        Me.ui_note.TabIndex = 89
        Me.ui_note.Text = ""
        '
        'ui_status
        '
        Me.ui_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_status.FormattingEnabled = True
        Me.ui_status.Location = New System.Drawing.Point(384, 56)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(271, 28)
        Me.ui_status.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(380, 35)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Trạng thái:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 19)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Mã bảng lương:"
        '
        'ui_code
        '
        Me.ui_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_code.Location = New System.Drawing.Point(30, 57)
        Me.ui_code.Name = "ui_code"
        Me.ui_code.Size = New System.Drawing.Size(272, 26)
        Me.ui_code.TabIndex = 85
        '
        'grb_pay_item
        '
        Me.grb_pay_item.AutoSize = True
        Me.grb_pay_item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grb_pay_item.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_pay_item.Location = New System.Drawing.Point(0, 0)
        Me.grb_pay_item.Name = "grb_pay_item"
        Me.grb_pay_item.Size = New System.Drawing.Size(848, 664)
        Me.grb_pay_item.TabIndex = 68
        Me.grb_pay_item.TabStop = False
        Me.grb_pay_item.Text = "Chi tiết các khoản tiền:"
        '
        'Payroll_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1521, 698)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Payroll_CRUD_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Department_CRUD"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
