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
        Label3 = New Label()
        ui_status = New ComboBox()
        ui_note = New RichTextBox()
        Label4 = New Label()
        Label6 = New Label()
        Label8 = New Label()
        ui_user = New TextBox()
        ui_role = New ComboBox()
        Label5 = New Label()
        ui_employee = New ComboBox()
        Label2 = New Label()
        Label1 = New Label()
        ui_password = New TextBox()
        ui_last_active = New TextBox()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(435, 182)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(85, 19)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái"
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(440, 209)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(298, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(440, 306)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(298, 137)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(435, 280)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(435, 84)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(163, 19)
        Label6.TabIndex = 13
        Label6.Text = "Lần cuối hoạt động:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(69, 182)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(118, 19)
        Label8.TabIndex = 17
        Label8.Text = "Tên tài khoản:"
        ' 
        ' ui_user
        ' 
        ui_user.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_user.Location = New Point(74, 209)
        ui_user.Margin = New Padding(4, 3, 4, 3)
        ui_user.Name = "ui_user"
        ui_user.Size = New Size(300, 26)
        ui_user.TabIndex = 16
        ' 
        ' ui_role
        ' 
        ui_role.DropDownStyle = ComboBoxStyle.DropDownList
        ui_role.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_role.FormattingEnabled = True
        ui_role.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_role.Location = New Point(74, 411)
        ui_role.Margin = New Padding(4, 3, 4, 3)
        ui_role.Name = "ui_role"
        ui_role.Size = New Size(300, 28)
        ui_role.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(69, 384)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(170, 19)
        Label5.TabIndex = 10
        Label5.Text = "Quyền hạn hệ thống:"
        ' 
        ' ui_employee
        ' 
        ui_employee.DropDownStyle = ComboBoxStyle.DropDownList
        ui_employee.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_employee.FormattingEnabled = True
        ui_employee.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_employee.Location = New Point(74, 111)
        ui_employee.Margin = New Padding(4, 3, 4, 3)
        ui_employee.Name = "ui_employee"
        ui_employee.Size = New Size(300, 28)
        ui_employee.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(69, 279)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(84, 19)
        Label2.TabIndex = 3
        Label2.Text = "Mật khẩu:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(69, 84)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 19)
        Label1.TabIndex = 1
        Label1.Text = "Nhân viên:"
        ' 
        ' ui_password
        ' 
        ui_password.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_password.Location = New Point(74, 306)
        ui_password.Margin = New Padding(4, 3, 4, 3)
        ui_password.Name = "ui_password"
        ui_password.Size = New Size(300, 26)
        ui_password.TabIndex = 2
        ' 
        ' ui_last_active
        ' 
        ui_last_active.Enabled = False
        ui_last_active.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_last_active.Location = New Point(440, 111)
        ui_last_active.Margin = New Padding(4, 3, 4, 3)
        ui_last_active.Name = "ui_last_active"
        ui_last_active.Size = New Size(298, 26)
        ui_last_active.TabIndex = 18
        ' 
        ' Account_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(830, 504)
        Controls.Add(ui_last_active)
        Controls.Add(Label8)
        Controls.Add(ui_user)
        Controls.Add(Label6)
        Controls.Add(ui_role)
        Controls.Add(Label5)
        Controls.Add(ui_employee)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ui_password)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Account_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Account_CRUD"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(ui_password, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_employee, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_role, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_user, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(ui_last_active, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_user As TextBox
    Friend WithEvents ui_role As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_employee As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_password As TextBox
    Friend WithEvents ui_last_active As TextBox
End Class
