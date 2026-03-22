<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Policy_CRUD_Frm
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
        Label3 = New Label()
        ui_status = New ComboBox()
        ui_note = New RichTextBox()
        Label4 = New Label()
        Label8 = New Label()
        ui_name = New TextBox()
        ui_priority = New NumericUpDown()
        Label2 = New Label()
        Label6 = New Label()
        ui_rule = New TextBox()
        ui_aggregate = New ComboBox()
        Label9 = New Label()
        ui_gen_item = New ComboBox()
        Label10 = New Label()
        ui_unit = New ComboBox()
        Label11 = New Label()
        ui_code = New TextBox()
        GroupBox1 = New GroupBox()
        ui_num = New NumericUpDown()
        btn_add_num = New Button()
        Label14 = New Label()
        btn_add_sym = New Button()
        btn_add_var_cust = New Button()
        btn_add_var_sys = New Button()
        ui_var_cust = New ComboBox()
        Label13 = New Label()
        ui_sym = New ComboBox()
        Label12 = New Label()
        ui_var_sys = New ComboBox()
        Label7 = New Label()
        Label5 = New Label()
        ui_category = New ComboBox()
        ui_data_source = New TextBox()
        Label15 = New Label()
        CType(ui_priority, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(ui_num, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(65, 85)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(125, 19)
        Label1.TabIndex = 1
        Label1.Text = "Mã chính sách:"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(890, 85)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(85, 19)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_status
        ' 
        ui_status.DropDownStyle = ComboBoxStyle.DropDownList
        ui_status.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_status.FormattingEnabled = True
        ui_status.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_status.Location = New Point(895, 107)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(375, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(895, 202)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(367, 213)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(890, 180)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(64, 180)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(132, 19)
        Label8.TabIndex = 17
        Label8.Text = "Tên chính sách:"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_name
        ' 
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(69, 202)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(348, 26)
        ui_name.TabIndex = 16
        ' 
        ' ui_priority
        ' 
        ui_priority.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_priority.Location = New Point(67, 296)
        ui_priority.Margin = New Padding(4, 3, 4, 3)
        ui_priority.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        ui_priority.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        ui_priority.Name = "ui_priority"
        ui_priority.Size = New Size(349, 26)
        ui_priority.TabIndex = 67
        ui_priority.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(65, 274)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 19)
        Label2.TabIndex = 66
        Label2.Text = "Độ ưu tiên:"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(26, 45)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 19)
        Label6.TabIndex = 69
        Label6.Text = "Quy tắc:"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_rule
        ' 
        ui_rule.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_rule.Location = New Point(31, 71)
        ui_rule.Margin = New Padding(4, 3, 4, 3)
        ui_rule.Name = "ui_rule"
        ui_rule.Size = New Size(1139, 26)
        ui_rule.TabIndex = 68
        ' 
        ' ui_aggregate
        ' 
        ui_aggregate.DropDownStyle = ComboBoxStyle.DropDownList
        ui_aggregate.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_aggregate.FormattingEnabled = True
        ui_aggregate.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_aggregate.Location = New Point(485, 199)
        ui_aggregate.Margin = New Padding(4, 3, 4, 3)
        ui_aggregate.Name = "ui_aggregate"
        ui_aggregate.Size = New Size(355, 28)
        ui_aggregate.TabIndex = 73
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(484, 177)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(124, 19)
        Label9.TabIndex = 72
        Label9.Text = "Hàm tổng hợp:"
        Label9.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_gen_item
        ' 
        ui_gen_item.DropDownStyle = ComboBoxStyle.DropDownList
        ui_gen_item.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_gen_item.FormattingEnabled = True
        ui_gen_item.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_gen_item.Location = New Point(484, 294)
        ui_gen_item.Margin = New Padding(4, 3, 4, 3)
        ui_gen_item.Name = "ui_gen_item"
        ui_gen_item.Size = New Size(355, 28)
        ui_gen_item.TabIndex = 75
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(483, 272)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(167, 19)
        Label10.TabIndex = 74
        Label10.Text = "Ghi vào bảng lương:"
        Label10.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_unit
        ' 
        ui_unit.DropDownStyle = ComboBoxStyle.DropDownList
        ui_unit.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_unit.FormattingEnabled = True
        ui_unit.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_unit.Location = New Point(484, 388)
        ui_unit.Margin = New Padding(4, 3, 4, 3)
        ui_unit.Name = "ui_unit"
        ui_unit.Size = New Size(352, 28)
        ui_unit.TabIndex = 78
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(483, 366)
        Label11.Margin = New Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New Size(115, 19)
        Label11.TabIndex = 77
        Label11.Text = "Đơn vị  giá trị:"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(69, 107)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(349, 26)
        ui_code.TabIndex = 79
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ui_num)
        GroupBox1.Controls.Add(btn_add_num)
        GroupBox1.Controls.Add(Label14)
        GroupBox1.Controls.Add(btn_add_sym)
        GroupBox1.Controls.Add(btn_add_var_cust)
        GroupBox1.Controls.Add(btn_add_var_sys)
        GroupBox1.Controls.Add(ui_var_cust)
        GroupBox1.Controls.Add(Label13)
        GroupBox1.Controls.Add(ui_sym)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(ui_var_sys)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(ui_rule)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(66, 460)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1203, 301)
        GroupBox1.TabIndex = 80
        GroupBox1.TabStop = False
        GroupBox1.Text = "Xây dựng công thức:"
        ' 
        ' ui_num
        ' 
        ui_num.DecimalPlaces = 2
        ui_num.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_num.Location = New Point(917, 126)
        ui_num.Maximum = New Decimal(New Integer() {-1304428545, 434162106, 542, 0})
        ui_num.Minimum = New Decimal(New Integer() {-1304428545, 434162106, 542, Integer.MinValue})
        ui_num.Name = "ui_num"
        ui_num.Size = New Size(174, 26)
        ui_num.TabIndex = 82
        ' 
        ' btn_add_num
        ' 
        btn_add_num.AutoSize = True
        btn_add_num.Location = New Point(1097, 123)
        btn_add_num.Name = "btn_add_num"
        btn_add_num.Size = New Size(73, 29)
        btn_add_num.TabIndex = 81
        btn_add_num.Text = "Thêm"
        btn_add_num.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ImageAlign = ContentAlignment.MiddleLeft
        Label14.Location = New Point(803, 133)
        Label14.Margin = New Padding(0)
        Label14.Name = "Label14"
        Label14.Size = New Size(111, 19)
        Label14.TabIndex = 79
        Label14.Text = "Số tùy chỉnh:"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btn_add_sym
        ' 
        btn_add_sym.AutoSize = True
        btn_add_sym.Location = New Point(702, 183)
        btn_add_sym.Name = "btn_add_sym"
        btn_add_sym.Size = New Size(73, 29)
        btn_add_sym.TabIndex = 78
        btn_add_sym.Text = "Thêm"
        btn_add_sym.UseVisualStyleBackColor = True
        ' 
        ' btn_add_var_cust
        ' 
        btn_add_var_cust.AutoSize = True
        btn_add_var_cust.Location = New Point(702, 233)
        btn_add_var_cust.Name = "btn_add_var_cust"
        btn_add_var_cust.Size = New Size(73, 29)
        btn_add_var_cust.TabIndex = 77
        btn_add_var_cust.Text = "Thêm"
        btn_add_var_cust.UseVisualStyleBackColor = True
        ' 
        ' btn_add_var_sys
        ' 
        btn_add_var_sys.AutoSize = True
        btn_add_var_sys.Location = New Point(702, 132)
        btn_add_var_sys.Name = "btn_add_var_sys"
        btn_add_var_sys.Size = New Size(71, 29)
        btn_add_var_sys.TabIndex = 76
        btn_add_var_sys.Text = "Thêm"
        btn_add_var_sys.UseVisualStyleBackColor = True
        ' 
        ' ui_var_cust
        ' 
        ui_var_cust.DropDownStyle = ComboBoxStyle.DropDownList
        ui_var_cust.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_var_cust.FormattingEnabled = True
        ui_var_cust.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_var_cust.Location = New Point(160, 233)
        ui_var_cust.Margin = New Padding(4, 3, 4, 3)
        ui_var_cust.Name = "ui_var_cust"
        ui_var_cust.Size = New Size(535, 28)
        ui_var_cust.TabIndex = 75
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ImageAlign = ContentAlignment.MiddleLeft
        Label13.Location = New Point(25, 243)
        Label13.Margin = New Padding(0)
        Label13.Name = "Label13"
        Label13.Size = New Size(125, 19)
        Label13.TabIndex = 74
        Label13.Text = "Biến tùy chỉnh:"
        Label13.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_sym
        ' 
        ui_sym.DropDownStyle = ComboBoxStyle.DropDownList
        ui_sym.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_sym.FormattingEnabled = True
        ui_sym.Items.AddRange(New Object() {"IF", "ABS", "MIN", "MAX", "POW", "ROUND", "FLOOR", "CEIL", "CEILING", "+", "-", "*", "/", "%", ">", ">=", "<=", "=", "!=", "(", ")", ","})
        ui_sym.Location = New Point(158, 184)
        ui_sym.Margin = New Padding(4, 3, 4, 3)
        ui_sym.Name = "ui_sym"
        ui_sym.Size = New Size(537, 28)
        ui_sym.TabIndex = 73
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ImageAlign = ContentAlignment.MiddleLeft
        Label12.Location = New Point(25, 194)
        Label12.Margin = New Padding(0)
        Label12.Name = "Label12"
        Label12.Size = New Size(107, 19)
        Label12.TabIndex = 72
        Label12.Text = "Dấu và Hàm:"
        Label12.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_var_sys
        ' 
        ui_var_sys.DropDownStyle = ComboBoxStyle.DropDownList
        ui_var_sys.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_var_sys.FormattingEnabled = True
        ui_var_sys.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_var_sys.Location = New Point(158, 133)
        ui_var_sys.Margin = New Padding(4, 3, 4, 3)
        ui_var_sys.Name = "ui_var_sys"
        ui_var_sys.Size = New Size(537, 28)
        ui_var_sys.TabIndex = 71
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(25, 143)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(122, 19)
        Label7.TabIndex = 70
        Label7.Text = "Biến hệ thống:"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(66, 365)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(93, 19)
        Label5.TabIndex = 10
        Label5.Text = "Danh mục:"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ui_category
        ' 
        ui_category.DropDownStyle = ComboBoxStyle.DropDownList
        ui_category.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_category.FormattingEnabled = True
        ui_category.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_category.Location = New Point(68, 387)
        ui_category.Margin = New Padding(4, 3, 4, 3)
        ui_category.Name = "ui_category"
        ui_category.Size = New Size(348, 28)
        ui_category.TabIndex = 11
        ' 
        ' ui_data_source
        ' 
        ui_data_source.Enabled = False
        ui_data_source.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_data_source.Location = New Point(485, 107)
        ui_data_source.Margin = New Padding(4, 3, 4, 3)
        ui_data_source.Name = "ui_data_source"
        ui_data_source.Size = New Size(351, 26)
        ui_data_source.TabIndex = 82
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.ImageAlign = ContentAlignment.MiddleLeft
        Label15.Location = New Point(484, 85)
        Label15.Margin = New Padding(0)
        Label15.Name = "Label15"
        Label15.Size = New Size(124, 19)
        Label15.TabIndex = 81
        Label15.Text = "Nguồn dữ liệu:"
        ' 
        ' Policy_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1348, 790)
        Controls.Add(ui_data_source)
        Controls.Add(GroupBox1)
        Controls.Add(Label15)
        Controls.Add(ui_code)
        Controls.Add(ui_unit)
        Controls.Add(Label11)
        Controls.Add(ui_gen_item)
        Controls.Add(Label10)
        Controls.Add(ui_aggregate)
        Controls.Add(Label9)
        Controls.Add(ui_priority)
        Controls.Add(Label2)
        Controls.Add(Label8)
        Controls.Add(ui_name)
        Controls.Add(ui_category)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Policy_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Account_CRUD"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_category, 0)
        Controls.SetChildIndex(ui_name, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(ui_priority, 0)
        Controls.SetChildIndex(Label9, 0)
        Controls.SetChildIndex(ui_aggregate, 0)
        Controls.SetChildIndex(Label10, 0)
        Controls.SetChildIndex(ui_gen_item, 0)
        Controls.SetChildIndex(Label11, 0)
        Controls.SetChildIndex(ui_unit, 0)
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label15, 0)
        Controls.SetChildIndex(GroupBox1, 0)
        Controls.SetChildIndex(ui_data_source, 0)
        CType(ui_priority, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(ui_num, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents ui_priority As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_rule As TextBox
    Friend WithEvents ui_aggregate As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ui_gen_item As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ui_unit As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_category As ComboBox
    Friend WithEvents ui_var_cust As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ui_sym As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ui_var_sys As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_add_sym As Button
    Friend WithEvents btn_add_var_cust As Button
    Friend WithEvents btn_add_var_sys As Button
    Friend WithEvents btn_add_num As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents ui_num As NumericUpDown
    Friend WithEvents ui_data_source As TextBox
    Friend WithEvents Label15 As Label
End Class
