<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Employee_CRUD_Frm
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
        Label2 = New Label()
        ui_name = New TextBox()
        Label3 = New Label()
        ui_status = New ComboBox()
        ui_note = New RichTextBox()
        Label4 = New Label()
        ui_birth_date = New DateTimePicker()
        ui_gender = New ComboBox()
        d = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label10 = New Label()
        ui_email = New TextBox()
        Label11 = New Label()
        ui_cccd = New TextBox()
        Label7 = New Label()
        ui_phone = New TextBox()
        Label9 = New Label()
        ui_bank = New TextBox()
        ui_address = New ComboBox()
        SuspendLayout()
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(70, 112)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(297, 26)
        ui_code.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(70, 92)
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
        Label2.Location = New Point(65, 170)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 19)
        Label2.TabIndex = 3
        Label2.Text = "Tên nhân viên:"
        ' 
        ' ui_name
        ' 
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(70, 192)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(297, 26)
        ui_name.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(763, 86)
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
        ui_status.Location = New Point(767, 108)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(277, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(767, 192)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(277, 317)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(767, 168)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_birth_date
        ' 
        ui_birth_date.CustomFormat = "dd-MM-yyyy"
        ui_birth_date.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_birth_date.Format = DateTimePickerFormat.Custom
        ui_birth_date.Location = New Point(70, 381)
        ui_birth_date.Margin = New Padding(4, 3, 4, 3)
        ui_birth_date.Name = "ui_birth_date"
        ui_birth_date.Size = New Size(297, 26)
        ui_birth_date.TabIndex = 15
        ' 
        ' ui_gender
        ' 
        ui_gender.DropDownStyle = ComboBoxStyle.DropDownList
        ui_gender.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_gender.FormattingEnabled = True
        ui_gender.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_gender.Location = New Point(70, 283)
        ui_gender.Margin = New Padding(4, 3, 4, 3)
        ui_gender.Name = "ui_gender"
        ui_gender.Size = New Size(297, 28)
        ui_gender.TabIndex = 17
        ' 
        ' d
        ' 
        d.AutoSize = True
        d.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        d.ImageAlign = ContentAlignment.MiddleLeft
        d.Location = New Point(65, 261)
        d.Margin = New Padding(0)
        d.Name = "d"
        d.Size = New Size(79, 19)
        d.TabIndex = 16
        d.Text = "Giới tính:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(65, 459)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(67, 19)
        Label5.TabIndex = 19
        Label5.Text = "Địa chỉ:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(65, 359)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(92, 19)
        Label6.TabIndex = 20
        Label6.Text = "Ngày sinh:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(415, 168)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(57, 19)
        Label10.TabIndex = 24
        Label10.Text = "Email:"
        ' 
        ' ui_email
        ' 
        ui_email.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_email.Location = New Point(419, 190)
        ui_email.Margin = New Padding(4, 3, 4, 3)
        ui_email.Name = "ui_email"
        ui_email.Size = New Size(277, 26)
        ui_email.TabIndex = 23
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(414, 90)
        Label11.Margin = New Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New Size(116, 19)
        Label11.TabIndex = 22
        Label11.Text = "CMND/CCCD:"
        ' 
        ' ui_cccd
        ' 
        ui_cccd.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_cccd.Location = New Point(419, 110)
        ui_cccd.Margin = New Padding(4, 3, 4, 3)
        ui_cccd.Name = "ui_cccd"
        ui_cccd.Size = New Size(277, 26)
        ui_cccd.TabIndex = 21
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(415, 259)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(115, 19)
        Label7.TabIndex = 31
        Label7.Text = "Số điện thoại:"
        ' 
        ' ui_phone
        ' 
        ui_phone.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_phone.Location = New Point(419, 281)
        ui_phone.Margin = New Padding(4, 3, 4, 3)
        ui_phone.Name = "ui_phone"
        ui_phone.Size = New Size(277, 26)
        ui_phone.TabIndex = 30
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(415, 359)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(176, 19)
        Label9.TabIndex = 33
        Label9.Text = "Tài khoản ngân hàng:"
        ' 
        ' ui_bank
        ' 
        ui_bank.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_bank.Location = New Point(419, 381)
        ui_bank.Margin = New Padding(4, 3, 4, 3)
        ui_bank.Name = "ui_bank"
        ui_bank.Size = New Size(277, 26)
        ui_bank.TabIndex = 32
        ' 
        ' ui_address
        ' 
        ui_address.DropDownHeight = 300
        ui_address.DropDownWidth = 10
        ui_address.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_address.FormattingEnabled = True
        ui_address.IntegralHeight = False
        ui_address.Items.AddRange(New Object() {"Hà Giang  ", "Cao Bằng  ", "Tuyên Quang  ", "Lào Cai  ", "Lai Châu  ", "Điện Biên  ", "Sơn La  ", "Lạng Sơn  ", "Bắc Ninh  ", "Thái Nguyên  ", "Phú Thọ  ", "Quảng Ninh  ", "Hà Nội  ", "Hưng Yên  ", "Hải Phòng  ", "Ninh Bình  ", "Thanh Hóa  ", "Nghệ An  ", "Hà Tĩnh  ", "Quảng Trị  ", "Huế  ", "Đà Nẵng  ", "Quảng Ngãi  ", "Gia Lai  ", "Khánh Hòa  ", "Đắk Lắk  ", "Lâm Đồng  ", "Đồng Nai  ", "TP. Hồ Chí Minh  ", "Tây Ninh  ", "Đồng Tháp  ", "Cần Thơ  ", "An Giang  ", "Cà Mau"})
        ui_address.Location = New Point(70, 481)
        ui_address.Margin = New Padding(4, 3, 4, 3)
        ui_address.MaxDropDownItems = 5
        ui_address.Name = "ui_address"
        ui_address.Size = New Size(297, 28)
        ui_address.TabIndex = 34
        ' 
        ' Employee_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1260, 572)
        Controls.Add(ui_address)
        Controls.Add(Label9)
        Controls.Add(ui_bank)
        Controls.Add(Label7)
        Controls.Add(ui_phone)
        Controls.Add(Label10)
        Controls.Add(ui_email)
        Controls.Add(Label11)
        Controls.Add(ui_cccd)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(ui_gender)
        Controls.Add(d)
        Controls.Add(ui_birth_date)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ui_name)
        Controls.Add(Label1)
        Controls.Add(ui_code)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Employee_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Department_CRUD"
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(ui_name, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_birth_date, 0)
        Controls.SetChildIndex(d, 0)
        Controls.SetChildIndex(ui_gender, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_cccd, 0)
        Controls.SetChildIndex(Label11, 0)
        Controls.SetChildIndex(ui_email, 0)
        Controls.SetChildIndex(Label10, 0)
        Controls.SetChildIndex(ui_phone, 0)
        Controls.SetChildIndex(Label7, 0)
        Controls.SetChildIndex(ui_bank, 0)
        Controls.SetChildIndex(Label9, 0)
        Controls.SetChildIndex(ui_address, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_birth_date As DateTimePicker
    Friend WithEvents ui_gender As ComboBox
    Friend WithEvents d As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ui_email As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_cccd As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ui_phone As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ui_bank As TextBox
    Friend WithEvents ui_address As ComboBox
End Class
