<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Leave_Cat_CRUD_Frm
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
        ui_benefit = New ComboBox()
        Label6 = New Label()
        Label8 = New Label()
        ui_code = New TextBox()
        ui_name = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(69, 186)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 19)
        Label1.TabIndex = 1
        Label1.Text = "Tên danh mục:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(483, 87)
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
        ui_status.Location = New Point(488, 113)
        ui_status.Margin = New Padding(4, 3, 4, 3)
        ui_status.Name = "ui_status"
        ui_status.Size = New Size(308, 28)
        ui_status.TabIndex = 6
        ' 
        ' ui_note
        ' 
        ui_note.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_note.Location = New Point(488, 212)
        ui_note.Margin = New Padding(4, 3, 4, 3)
        ui_note.Name = "ui_note"
        ui_note.Size = New Size(308, 136)
        ui_note.TabIndex = 7
        ui_note.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(483, 186)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 19)
        Label4.TabIndex = 8
        Label4.Text = "Ghi chú:"
        ' 
        ' ui_benefit
        ' 
        ui_benefit.DropDownStyle = ComboBoxStyle.DropDownList
        ui_benefit.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_benefit.FormattingEnabled = True
        ui_benefit.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        ui_benefit.Location = New Point(74, 316)
        ui_benefit.Margin = New Padding(4, 3, 4, 3)
        ui_benefit.Name = "ui_benefit"
        ui_benefit.Size = New Size(293, 28)
        ui_benefit.TabIndex = 9
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(69, 290)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(88, 19)
        Label6.TabIndex = 13
        Label6.Text = "Quyền lợi:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(69, 89)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(117, 19)
        Label8.TabIndex = 19
        Label8.Text = "Mã danh mục:"
        ' 
        ' ui_code
        ' 
        ui_code.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_code.Location = New Point(74, 115)
        ui_code.Margin = New Padding(4, 3, 4, 3)
        ui_code.Name = "ui_code"
        ui_code.Size = New Size(293, 26)
        ui_code.TabIndex = 18
        ' 
        ' ui_name
        ' 
        ui_name.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ui_name.Location = New Point(74, 212)
        ui_name.Margin = New Padding(4, 3, 4, 3)
        ui_name.Name = "ui_name"
        ui_name.Size = New Size(293, 26)
        ui_name.TabIndex = 24
        ' 
        ' Leave_Cat_CRUD_Frm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(870, 412)
        Controls.Add(ui_name)
        Controls.Add(Label8)
        Controls.Add(ui_code)
        Controls.Add(Label6)
        Controls.Add(ui_benefit)
        Controls.Add(Label4)
        Controls.Add(ui_note)
        Controls.Add(ui_status)
        Controls.Add(Label3)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "Leave_Cat_CRUD_Frm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Account_CRUD"
        Controls.SetChildIndex(Label1, 0)
        Controls.SetChildIndex(Label3, 0)
        Controls.SetChildIndex(ui_status, 0)
        Controls.SetChildIndex(ui_note, 0)
        Controls.SetChildIndex(Label4, 0)
        Controls.SetChildIndex(ui_benefit, 0)
        Controls.SetChildIndex(Label6, 0)
        Controls.SetChildIndex(ui_code, 0)
        Controls.SetChildIndex(Label8, 0)
        Controls.SetChildIndex(ui_name, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_status As ComboBox
    Friend WithEvents ui_note As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ui_benefit As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ui_code As TextBox
    Friend WithEvents ui_name As TextBox
End Class
