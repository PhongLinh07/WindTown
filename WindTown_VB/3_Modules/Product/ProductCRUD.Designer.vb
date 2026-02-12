<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductCRUD
    Inherits ACRUDForm

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
        Me.ui_name = New System.Windows.Forms.TextBox()
        Me.ui_unit_price = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ui_quantity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ui_id = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(75, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'ui_name
        '
        Me.ui_name.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ui_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_name.Location = New System.Drawing.Point(79, 184)
        Me.ui_name.Name = "ui_name"
        Me.ui_name.Size = New System.Drawing.Size(342, 26)
        Me.ui_name.TabIndex = 2
        '
        'ui_unit_price
        '
        Me.ui_unit_price.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ui_unit_price.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_unit_price.Location = New System.Drawing.Point(79, 269)
        Me.ui_unit_price.Name = "ui_unit_price"
        Me.ui_unit_price.Size = New System.Drawing.Size(342, 26)
        Me.ui_unit_price.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(75, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Unit Price:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ui_quantity
        '
        Me.ui_quantity.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ui_quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_quantity.Location = New System.Drawing.Point(79, 359)
        Me.ui_quantity.Name = "ui_quantity"
        Me.ui_quantity.Size = New System.Drawing.Size(342, 26)
        Me.ui_quantity.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(75, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Quantity:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ui_id
        '
        Me.ui_id.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ui_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_id.Location = New System.Drawing.Point(79, 109)
        Me.ui_id.Name = "ui_id"
        Me.ui_id.ReadOnly = True
        Me.ui_id.Size = New System.Drawing.Size(342, 26)
        Me.ui_id.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(75, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductCRUD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 465)
        Me.Controls.Add(Me.ui_id)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ui_quantity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ui_unit_price)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ui_name)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ProductCRUD"
        Me.Text = "ProductCRUD"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ui_name, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ui_unit_price, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ui_quantity, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ui_id, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ui_name As TextBox
    Friend WithEvents ui_unit_price As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ui_quantity As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_id As TextBox
    Friend WithEvents Label4 As Label
End Class
