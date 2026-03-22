<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pay_Item_CRUD_Frm
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
        Label10 = New Label()
        Label9 = New Label()
        ui_name = New TextBox()
        Label2 = New Label()
        ui_payroll = New TextBox()
        ui_priority = New NumericUpDown()
        Label5 = New Label()
        ui_category = New ComboBox()
        Label6 = New Label()
        ui_unit = New ComboBox()
        Label11 = New Label()
        ui_source = New ComboBox()
        Label7 = New Label()
        ui_value = New TextBox()
        CType(ui_priority, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(70, 120)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(339, 26)
        ui_code.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(65, 93)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(121, 19)
        Label1.TabIndex = 1
        Label1.Text = "Mã khoản tiền:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(919, 95)
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
        ui_status.Location = New Point(924, 119)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(331, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(924, 223)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(331, 227)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(919, 196)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(65, 196)
        Label10.Margin = New Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New Size(131, 19)
        Label10.TabIndex = 50
        Label10.Text = "Mã bảng lương:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.InactiveCaptionText
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(65, 294)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(128, 19)
        Label9.TabIndex = 63
        Label9.Text = "Tên khoản tiền:"
        ' 
        ' ui_name
        ' 
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(70, 321)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(339, 26)
        ui_name.TabIndex = 62
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(478, 96)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(59, 19)
        Label2.TabIndex = 64
        Label2.Text = "Giá trị:"
        ' 
        ' ui_payroll
        ' 
        ui_payroll.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_payroll.Location = New Point(70, 223)
        ui_payroll.Margin = New Padding(4, 3, 4, 3)
        ui_payroll.Name = "ui_payroll"
        ui_payroll.Size = New Size(339, 26)
        ui_payroll.TabIndex = 66
        ' 
        ' ui_priority
        ' 
        ui_priority.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_priority.Location = New Point(482, 420)
        ui_priority.Margin = New Padding(4, 3, 4, 3)
        ui_priority.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        ui_priority.Name = "ui_priority"
        ui_priority.Size = New Size(340, 26)
        ui_priority.TabIndex = 71
        ui_priority.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(478, 393)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 19)
        Label5.TabIndex = 70
        Label5.Text = "Độ ưu tiên:"
        ' 
        ' ui_category
        ' 
        ui_category.DropDownStyle = ComboBoxStyle.DropDownList
        ui_category.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_category.FormattingEnabled = True
        ui_category.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_category.Location = New Point(70, 418)
        ui_category.Margin = New Padding(4, 3, 4, 3)
        ui_category.Name = "ui_category"
        ui_category.Size = New Size(339, 28)
        ui_category.TabIndex = 69
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(69, 392)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(93, 19)
        Label6.TabIndex = 68
        Label6.Text = "Danh mục:"
        ' 
        ' ui_unit
        ' 
        ui_unit.DropDownStyle = ComboBoxStyle.DropDownList
        ui_unit.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_unit.FormattingEnabled = True
        ui_unit.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_unit.Location = New Point(482, 223)
        ui_unit.Margin = New Padding(4, 3, 4, 3)
        ui_unit.Name = "ui_unit"
        ui_unit.Size = New Size(339, 28)
        ui_unit.TabIndex = 80
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(481, 197)
        Label11.Margin = New Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New Size(115, 19)
        Label11.TabIndex = 79
        Label11.Text = "Đơn vị  giá trị:"
        ' 
        ' ui_source
        ' 
        ui_source.DropDownStyle = ComboBoxStyle.DropDownList
        ui_source.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_source.FormattingEnabled = True
        ui_source.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_source.Location = New Point(483, 321)
        ui_source.Margin = New Padding(4, 3, 4, 3)
        ui_source.Name = "ui_source"
        ui_source.Size = New Size(339, 28)
        ui_source.TabIndex = 82
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(482, 295)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(67, 19)
        Label7.TabIndex = 81
        Label7.Text = "Nguồn:"
        ' 
        ' ui_value
        ' 
        ui_value.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_value.Location = New Point(482, 121)
        ui_value.Margin = New Padding(4, 3, 4, 3)
        ui_value.Name = "ui_value"
        ui_value.Size = New Size(339, 26)
        ui_value.TabIndex = 72
        ' 
        ' Pay_Item_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1335, 530)
        Controls.Add(ui_source)
        Controls.Add(Label7)
        Controls.Add(ui_unit)
        Controls.Add(Label11)
        Controls.Add(ui_value)
        Controls.Add(ui_priority)
        Controls.Add(Label5)
        Controls.Add(ui_category)
        Controls.Add(Label6)
        Controls.Add(ui_payroll)
        Controls.Add(Label2)
        Controls.Add(Label9)
        Controls.Add(ui_name)
        Controls.Add(Label10)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(ui_code)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Pay_Item_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Department_CRUD"
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(Label10, 0)
        Controls.SetChildIndex(ui_name, 0)
        Controls.SetChildIndex(Label9, 0)
        Controls.SetChildIndex(Label2, 0)
        Controls.SetChildIndex(ui_payroll, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_category, 0)
        Controls.SetChildIndex(Label5, 0)
        Controls.SetChildIndex(ui_priority, 0)
        Controls.SetChildIndex(ui_value, 0)
        Controls.SetChildIndex(Label11, 0)
        Controls.SetChildIndex(ui_unit, 0)
        Controls.SetChildIndex(Label7, 0)
        Controls.SetChildIndex(ui_source, 0)
        CType(ui_priority, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_payroll As TextBox
    Friend WithEvents ui_priority As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents ui_category As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ui_unit As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_source As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ui_value As TextBox
End Class
