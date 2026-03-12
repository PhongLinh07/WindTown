<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhongBan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlpnlMainChucVu = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.tvChucVu = New System.Windows.Forms.TreeView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbxSearch = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnThemPhongBan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlpnlMainChucVu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpnlMainChucVu
        '
        Me.tlpnlMainChucVu.ColumnCount = 2
        Me.tlpnlMainChucVu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpnlMainChucVu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpnlMainChucVu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpnlMainChucVu.Controls.Add(Me.Panel1, 1, 1)
        Me.tlpnlMainChucVu.Controls.Add(Me.pnlBody, 0, 1)
        Me.tlpnlMainChucVu.Controls.Add(Me.pnlHeader, 0, 0)
        Me.tlpnlMainChucVu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpnlMainChucVu.Location = New System.Drawing.Point(0, 0)
        Me.tlpnlMainChucVu.Name = "tlpnlMainChucVu"
        Me.tlpnlMainChucVu.RowCount = 2
        Me.tlpnlMainChucVu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpnlMainChucVu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpnlMainChucVu.Size = New System.Drawing.Size(1040, 665)
        Me.tlpnlMainChucVu.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(523, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(514, 579)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 27)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mô tả Phong ban:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(743, 20)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(180, 31)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "+ Thêm chức vụ"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.White
        Me.pnlBody.Controls.Add(Me.tvChucVu)
        Me.pnlBody.Controls.Add(Me.btnSearch)
        Me.pnlBody.Controls.Add(Me.tbxSearch)
        Me.pnlBody.Controls.Add(Me.Button2)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(3, 83)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(514, 579)
        Me.pnlBody.TabIndex = 2
        '
        'tvChucVu
        '
        Me.tvChucVu.Location = New System.Drawing.Point(10, 57)
        Me.tvChucVu.Name = "tvChucVu"
        Me.tvChucVu.Size = New System.Drawing.Size(457, 503)
        Me.tvChucVu.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(316, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Tìm"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tbxSearch
        '
        Me.tbxSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxSearch.Location = New System.Drawing.Point(10, 21)
        Me.tbxSearch.Name = "tbxSearch"
        Me.tbxSearch.Size = New System.Drawing.Size(300, 29)
        Me.tbxSearch.TabIndex = 2
        Me.tbxSearch.Text = "Tìm kiếm"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(743, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(180, 31)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "+ Thêm chức vụ"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.tlpnlMainChucVu.SetColumnSpan(Me.pnlHeader, 2)
        Me.pnlHeader.Controls.Add(Me.btnXoa)
        Me.pnlHeader.Controls.Add(Me.btnSua)
        Me.pnlHeader.Controls.Add(Me.btnThemPhongBan)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1034, 74)
        Me.pnlHeader.TabIndex = 1
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa.BackColor = System.Drawing.Color.Red
        Me.btnXoa.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.ForeColor = System.Drawing.Color.White
        Me.btnXoa.Location = New System.Drawing.Point(628, 20)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(109, 34)
        Me.btnXoa.TabIndex = 3
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = False
        '
        'btnSua
        '
        Me.btnSua.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua.BackColor = System.Drawing.Color.Yellow
        Me.btnSua.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.Color.Black
        Me.btnSua.Location = New System.Drawing.Point(743, 20)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(109, 34)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = False
        '
        'btnThemPhongBan
        '
        Me.btnThemPhongBan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemPhongBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnThemPhongBan.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemPhongBan.ForeColor = System.Drawing.Color.White
        Me.btnThemPhongBan.Location = New System.Drawing.Point(869, 20)
        Me.btnThemPhongBan.Name = "btnThemPhongBan"
        Me.btnThemPhongBan.Size = New System.Drawing.Size(156, 34)
        Me.btnThemPhongBan.TabIndex = 1
        Me.btnThemPhongBan.Text = "+ Thêm phòng ban"
        Me.btnThemPhongBan.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Phòng ban"
        '
        'frmPhongBan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1040, 665)
        Me.Controls.Add(Me.tlpnlMainChucVu)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmPhongBan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phòng ban"
        Me.tlpnlMainChucVu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpnlMainChucVu As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnThemPhongBan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents tbxSearch As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents tvChucVu As TreeView
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnSua As Button
End Class
