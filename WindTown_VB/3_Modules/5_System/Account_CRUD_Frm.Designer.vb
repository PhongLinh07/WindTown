<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Account_CRUD_Frm
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ui_last_active = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ui_user = New System.Windows.Forms.TextBox()
        Me.ui_role = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ui_employee = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ui_password = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(373, 158)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Trạng thái"
        '
        'ui_status
        '
        Me.ui_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_status.FormattingEnabled = True
        Me.ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_status.Location = New System.Drawing.Point(377, 181)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(265, 28)
        Me.ui_status.TabIndex = 6
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(377, 265)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(265, 119)
        Me.ui_note.TabIndex = 7
        Me.ui_note.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(373, 243)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ghi chú:"
        '
        'ui_last_active
        '
        Me.ui_last_active.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        Me.ui_last_active.Enabled = False
        Me.ui_last_active.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_last_active.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ui_last_active.Location = New System.Drawing.Point(377, 96)
        Me.ui_last_active.Name = "ui_last_active"
        Me.ui_last_active.Size = New System.Drawing.Size(265, 26)
        Me.ui_last_active.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(373, 73)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Lần cuối hoạt động:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(59, 158)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 19)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Tên tài khoản:"
        '
        'ui_user
        '
        Me.ui_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_user.Location = New System.Drawing.Point(63, 181)
        Me.ui_user.Name = "ui_user"
        Me.ui_user.Size = New System.Drawing.Size(258, 26)
        Me.ui_user.TabIndex = 16
        '
        'ui_role
        '
        Me.ui_role.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_role.FormattingEnabled = True
        Me.ui_role.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_role.Location = New System.Drawing.Point(63, 356)
        Me.ui_role.Name = "ui_role"
        Me.ui_role.Size = New System.Drawing.Size(258, 28)
        Me.ui_role.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(59, 333)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Quyền hạn hệ thống:"
        '
        'ui_employee
        '
        Me.ui_employee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_employee.FormattingEnabled = True
        Me.ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_employee.Location = New System.Drawing.Point(63, 96)
        Me.ui_employee.Name = "ui_employee"
        Me.ui_employee.Size = New System.Drawing.Size(258, 28)
        Me.ui_employee.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(59, 242)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Mật khẩu:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(59, 73)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nhân viên:"
        '
        'ui_password
        '
        Me.ui_password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_password.Location = New System.Drawing.Point(63, 265)
        Me.ui_password.Name = "ui_password"
        Me.ui_password.Size = New System.Drawing.Size(258, 26)
        Me.ui_password.TabIndex = 2
        '
        'Account_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(711, 437)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ui_user)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ui_last_active)
        Me.Controls.Add(Me.ui_role)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ui_employee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_note)
        Me.Controls.Add(Me.ui_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ui_password)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Account_CRUD_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Account_CRUD"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ui_password, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_status, 0)
        Me.Controls.SetChildIndex(Me.ui_note, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ui_employee, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ui_role, 0)
        Me.Controls.SetChildIndex(Me.ui_last_active, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ui_user, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_last_active As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_user As TextBox
    Friend WithEvents ui_role As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_password As TextBox
End Class
