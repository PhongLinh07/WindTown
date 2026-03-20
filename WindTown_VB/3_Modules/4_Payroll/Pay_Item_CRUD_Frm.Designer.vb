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
        Me.ui_code = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ui_name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ui_payroll = New System.Windows.Forms.TextBox()
        Me.ui_priority = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ui_category = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ui_value = New System.Windows.Forms.TextBox()
        Me.ui_unit = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ui_source = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ui_priority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ui_code
        '
        Me.ui_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_code.Location = New System.Drawing.Point(60, 104)
        Me.ui_code.Name = "ui_code"
        Me.ui_code.Size = New System.Drawing.Size(291, 26)
        Me.ui_code.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(56, 81)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mã khoản tiền:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(788, 82)
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
        Me.ui_status.Location = New System.Drawing.Point(792, 103)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(284, 28)
        Me.ui_status.TabIndex = 6
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(792, 193)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(284, 197)
        Me.ui_note.TabIndex = 7
        Me.ui_note.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(788, 170)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ghi chú:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(56, 170)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 19)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Mã bảng lương:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(56, 255)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 19)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Tên khoản tiền:"
        '
        'ui_name
        '
        Me.ui_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_name.Location = New System.Drawing.Point(60, 278)
        Me.ui_name.Name = "ui_name"
        Me.ui_name.Size = New System.Drawing.Size(291, 26)
        Me.ui_name.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(410, 83)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Giá trị:"
        '
        'ui_payroll
        '
        Me.ui_payroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_payroll.Location = New System.Drawing.Point(60, 193)
        Me.ui_payroll.Name = "ui_payroll"
        Me.ui_payroll.Size = New System.Drawing.Size(291, 26)
        Me.ui_payroll.TabIndex = 66
        '
        'ui_priority
        '
        Me.ui_priority.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_priority.Location = New System.Drawing.Point(413, 364)
        Me.ui_priority.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.ui_priority.Name = "ui_priority"
        Me.ui_priority.Size = New System.Drawing.Size(291, 26)
        Me.ui_priority.TabIndex = 71
        Me.ui_priority.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(410, 341)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 19)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Độ ưu tiên:"
        '
        'ui_category
        '
        Me.ui_category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_category.FormattingEnabled = True
        Me.ui_category.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_category.Location = New System.Drawing.Point(60, 362)
        Me.ui_category.Name = "ui_category"
        Me.ui_category.Size = New System.Drawing.Size(291, 28)
        Me.ui_category.TabIndex = 69
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(59, 340)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 19)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Danh mục:"
        '
        'ui_value
        '
        Me.ui_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_value.Location = New System.Drawing.Point(413, 105)
        Me.ui_value.Name = "ui_value"
        Me.ui_value.Size = New System.Drawing.Size(291, 26)
        Me.ui_value.TabIndex = 72
        '
        'ui_unit
        '
        Me.ui_unit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_unit.FormattingEnabled = True
        Me.ui_unit.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_unit.Location = New System.Drawing.Point(413, 193)
        Me.ui_unit.Name = "ui_unit"
        Me.ui_unit.Size = New System.Drawing.Size(291, 28)
        Me.ui_unit.TabIndex = 80
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(412, 171)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 19)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Đơn vị  giá trị:"
        '
        'ui_source
        '
        Me.ui_source.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_source.FormattingEnabled = True
        Me.ui_source.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.ui_source.Location = New System.Drawing.Point(414, 278)
        Me.ui_source.Name = "ui_source"
        Me.ui_source.Size = New System.Drawing.Size(291, 28)
        Me.ui_source.TabIndex = 82
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(413, 256)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 19)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Nguồn:"
        '
        'Pay_Item_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1144, 459)
        Me.Controls.Add(Me.ui_source)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ui_unit)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ui_value)
        Me.Controls.Add(Me.ui_priority)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ui_category)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ui_payroll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ui_name)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_note)
        Me.Controls.Add(Me.ui_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ui_code)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Pay_Item_CRUD_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Department_CRUD"
        Me.Controls.SetChildIndex(Me.ui_code, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_status, 0)
        Me.Controls.SetChildIndex(Me.ui_note, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.ui_name, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ui_payroll, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ui_category, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ui_priority, 0)
        Me.Controls.SetChildIndex(Me.ui_value, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.ui_unit, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.ui_source, 0)
        CType(Me.ui_priority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents ui_value As TextBox
    Friend WithEvents ui_unit As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ui_source As ComboBox
    Friend WithEvents Label7 As Label
End Class
