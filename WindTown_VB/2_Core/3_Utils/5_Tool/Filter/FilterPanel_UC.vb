' ── Panel lọc động — nhúng vào BaseList_UC ──────────────────
Public Class FilterPanel_UC
    Inherits Panel

    Private ReadOnly _fields As List(Of FilterHelper.FieldInfo)
    Private _pnlRows As New Panel()
    Private _lblStatus As New Label()

    Public Event FilterApplied(filters As List(Of FilterModel))
    Public Event FilterCleared()

    Private Const ROW_H = 40

    Public Sub New(modelType As Type)
        _fields = FilterHelper.GetFields(modelType)

        Me.Dock = DockStyle.Top
        Me.Visible = False
        Me.Height = 0
        Me.BackColor = Color.FromArgb(238, 243, 252)
        Me.Padding = New Padding(4, 2, 4, 4)

        ' ── Toolbar ─────────────────────────────────────────
        Dim toolbar As New Panel() With {.Dock = DockStyle.Top, .Height = 34, .BackColor = Color.Transparent}

        Dim btnAdd = MakeBtn("+ Thêm", 4)
        Dim btnApply = MakeBtn("✓ Áp dụng", 100)
        Dim btnClear = MakeBtn("× Xóa lọc", 196)
        btnApply.BackColor = Color.FromArgb(33, 115, 220)
        btnApply.ForeColor = Color.White

        With _lblStatus
            .Font = New Font("Segoe UI", 8.5, FontStyle.Italic)
            .Location = New Point(290, 9)
            .AutoSize = True
            .ForeColor = Color.FromArgb(50, 100, 180)
        End With

        AddHandler btnAdd.Click, Sub(s, e)
                                     Dim row As New FilterRow_UC(_fields.ToList())
                                     row.Width = _pnlRows.Width - 4 : row.Left = 2
                                     row.Top = _pnlRows.Controls.Count * ROW_H
                                     _pnlRows.Controls.Add(row)
                                     Me.Height = 34 + (_pnlRows.Controls.Count * ROW_H) + 6
                                 End Sub

        AddHandler btnApply.Click, Sub(s, e)
                                       Dim filters = _pnlRows.Controls.OfType(Of FilterRow_UC)() _
                                           .Select(Function(r) r.GetFilter()) _
                                           .Where(Function(f) f IsNot Nothing) _
                                           .ToList()
                                       _lblStatus.Text = If(filters.Count > 0, $"Lọc: {filters.Count} điều kiện", "")
                                       RaiseEvent FilterApplied(filters)
                                   End Sub

        AddHandler btnClear.Click, Sub(s, e)
                                       _pnlRows.Controls.Clear()
                                       _lblStatus.Text = ""
                                       Me.Height = 34 + 6
                                       RaiseEvent FilterCleared()
                                   End Sub

        toolbar.Controls.AddRange({btnAdd, btnApply, btnClear, _lblStatus})

        ' ── Row panel ───────────────────────────────────────
        With _pnlRows
            .Dock = DockStyle.Fill
            .BackColor = Color.Transparent
        End With

        Me.Controls.Add(_pnlRows)
        Me.Controls.Add(toolbar)
        _pnlRows.BringToFront()
    End Sub

    Private Function MakeBtn(text As String, left As Integer) As Button
        Dim b As New Button() With {
            .Text = text,
            .Font = New Font("Segoe UI", 9),
            .Size = New Size(88, 26),
            .Location = New Point(left, 4),
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
        b.FlatAppearance.BorderColor = Color.FromArgb(160, 180, 220)
        Return b
    End Function

    Public Sub Toggle()
        If Me.Visible Then
            Me.Visible = False
            Me.Height = 0
        Else
            Me.Visible = True
            If _pnlRows.Controls.Count = 0 Then
                ' Tự thêm 1 row khi mở lần đầu
                Dim row As New FilterRow_UC(_fields.ToList())
                row.Width = _pnlRows.Width - 4 : row.Left = 2 : row.Top = 0
                _pnlRows.Controls.Add(row)
            End If
            Me.Height = 34 + (_pnlRows.Controls.Count * ROW_H) + 6
        End If
    End Sub

End Class