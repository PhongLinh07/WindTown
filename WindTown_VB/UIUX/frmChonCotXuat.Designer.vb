<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChonCotXuat
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlChinh = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTieuDe = New System.Windows.Forms.Panel()
        Me.lblTieuDe = New System.Windows.Forms.Label()
        Me.clbCot = New System.Windows.Forms.CheckedListBox()
        Me.pnlNut = New System.Windows.Forms.Panel()
        Me.btnHuy = New System.Windows.Forms.Button()
        Me.btnXacNhan = New System.Windows.Forms.Button()
        Me.chkChonTatCa = New System.Windows.Forms.CheckBox()
        Me.pnlChinh.SuspendLayout()
        Me.pnlTieuDe.SuspendLayout()
        Me.pnlNut.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlChinh
        '
        Me.pnlChinh.ColumnCount = 1
        Me.pnlChinh.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlChinh.Controls.Add(Me.pnlTieuDe, 0, 0)
        Me.pnlChinh.Controls.Add(Me.clbCot, 0, 1)
        Me.pnlChinh.Controls.Add(Me.pnlNut, 0, 2)
        Me.pnlChinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChinh.Location = New System.Drawing.Point(0, 0)
        Me.pnlChinh.Name = "pnlChinh"
        Me.pnlChinh.RowCount = 3
        Me.pnlChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.pnlChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.pnlChinh.Size = New System.Drawing.Size(520, 560)
        Me.pnlChinh.TabIndex = 0
        '
        'pnlTieuDe
        '
        Me.pnlTieuDe.BackColor = System.Drawing.Color.White
        Me.pnlTieuDe.Controls.Add(Me.chkChonTatCa)
        Me.pnlTieuDe.Controls.Add(Me.lblTieuDe)
        Me.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTieuDe.Location = New System.Drawing.Point(3, 3)
        Me.pnlTieuDe.Name = "pnlTieuDe"
        Me.pnlTieuDe.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.pnlTieuDe.Size = New System.Drawing.Size(514, 54)
        Me.pnlTieuDe.TabIndex = 0
        '
        'lblTieuDe
        '
        Me.lblTieuDe.AutoSize = True
        Me.lblTieuDe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.Location = New System.Drawing.Point(16, 12)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(196, 28)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "Chọn cột cần xuất"
        '
        'clbCot
        '
        Me.clbCot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbCot.FormattingEnabled = True
        Me.clbCot.Location = New System.Drawing.Point(3, 63)
        Me.clbCot.Name = "clbCot"
        Me.clbCot.Size = New System.Drawing.Size(514, 434)
        Me.clbCot.TabIndex = 1
        '
        'pnlNut
        '
        Me.pnlNut.BackColor = System.Drawing.Color.White
        Me.pnlNut.Controls.Add(Me.btnHuy)
        Me.pnlNut.Controls.Add(Me.btnXacNhan)
        Me.pnlNut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNut.Location = New System.Drawing.Point(3, 503)
        Me.pnlNut.Name = "pnlNut"
        Me.pnlNut.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlNut.Size = New System.Drawing.Size(514, 54)
        Me.pnlNut.TabIndex = 2
        '
        'btnHuy
        '
        Me.btnHuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHuy.BackColor = System.Drawing.Color.White
        Me.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHuy.Location = New System.Drawing.Point(286, 10)
        Me.btnHuy.Name = "btnHuy"
        Me.btnHuy.Size = New System.Drawing.Size(100, 34)
        Me.btnHuy.TabIndex = 1
        Me.btnHuy.Text = "Hủy"
        Me.btnHuy.UseVisualStyleBackColor = False
        '
        'btnXacNhan
        '
        Me.btnXacNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXacNhan.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXacNhan.ForeColor = System.Drawing.Color.White
        Me.btnXacNhan.Location = New System.Drawing.Point(398, 10)
        Me.btnXacNhan.Name = "btnXacNhan"
        Me.btnXacNhan.Size = New System.Drawing.Size(100, 34)
        Me.btnXacNhan.TabIndex = 0
        Me.btnXacNhan.Text = "Xuất"
        Me.btnXacNhan.UseVisualStyleBackColor = False
        '
        'chkChonTatCa
        '
        Me.chkChonTatCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkChonTatCa.AutoSize = True
        Me.chkChonTatCa.Location = New System.Drawing.Point(398, 14)
        Me.chkChonTatCa.Name = "chkChonTatCa"
        Me.chkChonTatCa.Size = New System.Drawing.Size(100, 24)
        Me.chkChonTatCa.TabIndex = 1
        Me.chkChonTatCa.Text = "Chọn tất cả"
        Me.chkChonTatCa.UseVisualStyleBackColor = True
        '
        'frmChonCotXuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 560)
        Me.Controls.Add(Me.pnlChinh)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonCotXuat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chọn cột xuất báo cáo"
        Me.pnlChinh.ResumeLayout(False)
        Me.pnlTieuDe.ResumeLayout(False)
        Me.pnlTieuDe.PerformLayout()
        Me.pnlNut.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlChinh As TableLayoutPanel
    Friend WithEvents pnlTieuDe As Panel
    Friend WithEvents lblTieuDe As Label
    Friend WithEvents clbCot As CheckedListBox
    Friend WithEvents pnlNut As Panel
    Friend WithEvents btnHuy As Button
    Friend WithEvents btnXacNhan As Button
    Friend WithEvents chkChonTatCa As CheckBox
End Class
