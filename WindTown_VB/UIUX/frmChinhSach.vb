Public Class frmChinhSach
    Inherits Form

    Private _khung As TableLayoutPanel
    Private _tieuDe As Label
    Private _moTa As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Chính sách"
        Me.Dock = DockStyle.Fill
        Me.FormBorderStyle = FormBorderStyle.None

        _khung = New TableLayoutPanel()
        _khung.ColumnCount = 1
        _khung.RowCount = 2
        _khung.Dock = DockStyle.Fill
        _khung.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0!))
        _khung.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

        _tieuDe = New Label()
        _tieuDe.Text = "Chính sách"
        _tieuDe.Dock = DockStyle.Fill
        _tieuDe.TextAlign = ContentAlignment.MiddleLeft
        _tieuDe.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)

        _moTa = New Label()
        _moTa.Text = "Chức năng đang phát triển."
        _moTa.Dock = DockStyle.Fill
        _moTa.TextAlign = ContentAlignment.TopLeft

        _khung.Controls.Add(_tieuDe, 0, 0)
        _khung.Controls.Add(_moTa, 0, 1)

        Me.Controls.Add(_khung)
    End Sub
End Class
