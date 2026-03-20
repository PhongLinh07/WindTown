<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Holiday_CRUD_Frm
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ui_status = New System.Windows.Forms.ComboBox()
        Me.ui_note = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ui_of_date = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ui_code = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ui_name = New System.Windows.Forms.TextBox()
        Me.ui_mult = New System.Windows.Forms.NumericUpDown()
        CType(Me.ui_mult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(59, 325)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hệ số:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(397, 75)
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
        Me.ui_status.Location = New System.Drawing.Point(401, 98)
        Me.ui_status.Name = "ui_status"
        Me.ui_status.Size = New System.Drawing.Size(275, 28)
        Me.ui_status.TabIndex = 6
        '
        'ui_note
        '
        Me.ui_note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_note.Location = New System.Drawing.Point(401, 180)
        Me.ui_note.Name = "ui_note"
        Me.ui_note.Size = New System.Drawing.Size(275, 193)
        Me.ui_note.TabIndex = 7
        Me.ui_note.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(397, 157)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ghi chú:"
        '
        'ui_of_date
        '
        Me.ui_of_date.CustomFormat = "dd-MM-yyyy"
        Me.ui_of_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_of_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ui_of_date.Location = New System.Drawing.Point(63, 263)
        Me.ui_of_date.Name = "ui_of_date"
        Me.ui_of_date.Size = New System.Drawing.Size(265, 26)
        Me.ui_of_date.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(59, 240)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Thời gian:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(59, 77)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 19)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Mã ngày lễ:"
        '
        'ui_code
        '
        Me.ui_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_code.Location = New System.Drawing.Point(63, 100)
        Me.ui_code.Name = "ui_code"
        Me.ui_code.Size = New System.Drawing.Size(265, 26)
        Me.ui_code.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(59, 157)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Tên ngày lễ:"
        '
        'ui_name
        '
        Me.ui_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_name.Location = New System.Drawing.Point(63, 180)
        Me.ui_name.Name = "ui_name"
        Me.ui_name.Size = New System.Drawing.Size(265, 26)
        Me.ui_name.TabIndex = 24
        '
        'ui_mult
        '
        Me.ui_mult.DecimalPlaces = 1
        Me.ui_mult.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_mult.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.ui_mult.Location = New System.Drawing.Point(64, 347)
        Me.ui_mult.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.ui_mult.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ui_mult.Name = "ui_mult"
        Me.ui_mult.Size = New System.Drawing.Size(264, 26)
        Me.ui_mult.TabIndex = 67
        Me.ui_mult.ThousandsSeparator = True
        Me.ui_mult.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Holiday_CRUD_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(751, 433)
        Me.Controls.Add(Me.ui_mult)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ui_name)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ui_code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ui_of_date)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_note)
        Me.Controls.Add(Me.ui_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Holiday_CRUD_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hệ số lương ngày lễ"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_status, 0)
        Me.Controls.SetChildIndex(Me.ui_note, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ui_of_date, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ui_code, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.ui_name, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ui_mult, 0)
        CType(Me.ui_mult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_of_date As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents ui_mult As NumericUpDown
End Class
