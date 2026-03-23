' ── 1 dòng lọc: [Field ▼] [Operator ▼] [Value] [đến Value2] [×] ─
Public Class FilterRow_UC
    Inherits Panel

    Private _cboField As New ComboBox()
    Private _cboOp As New ComboBox()
    Private _ctrl1 As Control        ' value control chính
    Private _ctrl2 As Control        ' value control "đến" (between)
    Private _lblDen As New Label()
    Private _btnX As New Button()

    Public Sub New(fields As List(Of FilterHelper.FieldInfo))
        Me.Height = 36
        Me.BackColor = Color.FromArgb(248, 250, 253)
        Me.BorderStyle = BorderStyle.FixedSingle

        ' ── Field ───────────────────────────────────────────
        With _cboField
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Font = New Font("Segoe UI", 9)
            .Location = New Point(4, 5)
            .Size = New Size(155, 26)
        End With
        _cboField.DataSource = fields.ToList()  ' ✅ copy riêng cho mỗi row
        _cboField.DisplayMember = "DisplayName"
        _cboField.ValueMember = "PropName"
        AddHandler _cboField.SelectedIndexChanged, AddressOf OnFieldChanged

        ' ── Operator ────────────────────────────────────────
        With _cboOp
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Font = New Font("Segoe UI", 9)
            .Location = New Point(165, 5)
            .Size = New Size(105, 26)
        End With
        AddHandler _cboOp.SelectedIndexChanged, AddressOf OnOpChanged

        ' ── Label "đến" ─────────────────────────────────────
        With _lblDen
            .Text = "đến"
            .Font = New Font("Segoe UI", 8.5)
            .Location = New Point(440, 9)
            .Size = New Size(28, 18)
            .Visible = False
        End With

        ' ── Nút xóa ─────────────────────────────────────────
        With _btnX
            .Text = "×"
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Location = New Point(640, 5)
            .Size = New Size(26, 26)
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.FromArgb(180, 50, 50)
            .BackColor = Color.Transparent
            .Cursor = Cursors.Hand
        End With
        _btnX.FlatAppearance.BorderSize = 0
        AddHandler _btnX.Click, Sub(s, e)
                                    Me.Parent?.Controls.Remove(Me)
                                    Me.Dispose()
                                End Sub

        Me.Controls.AddRange({_cboField, _cboOp, _lblDen, _btnX})

        ' Trigger lần đầu để sinh control value
        If fields.Count > 0 Then _cboField.SelectedIndex = -1
    End Sub

    Private Sub OnFieldChanged(sender As Object, e As EventArgs)
        Dim fi = TryCast(_cboField.SelectedItem, FilterHelper.FieldInfo)
        If fi Is Nothing Then Return

        ' Cập nhật operators
        _cboOp.Items.Clear()
        _cboOp.Items.AddRange(FilterHelper.GetOperators(fi.PropType))
        _cboOp.SelectedIndex = 0

        ' Tạo value controls
        If _ctrl1 IsNot Nothing Then Me.Controls.Remove(_ctrl1) : _ctrl1.Dispose()
        If _ctrl2 IsNot Nothing Then Me.Controls.Remove(_ctrl2) : _ctrl2.Dispose()

        _ctrl1 = MakeControl(fi.PropType, 276)
        _ctrl2 = MakeControl(fi.PropType, 472)
        _ctrl2.Visible = False

        Me.Controls.Add(_ctrl1)
        Me.Controls.Add(_ctrl2)
    End Sub

    Private Sub OnOpChanged(sender As Object, e As EventArgs)
        Dim isBetween = (_cboOp.SelectedItem?.ToString().ToLower() = "between")
        If _ctrl2 IsNot Nothing Then _ctrl2.Visible = isBetween
        _lblDen.Visible = isBetween
    End Sub

    ' Tạo input control phù hợp kiểu dữ liệu
    Private Function MakeControl(t As Type, left As Integer) As Control
        If t = GetType(String) Then
            Return New TextBox() With {.Font = New Font("Segoe UI", 9), .Location = New Point(left, 5), .Size = New Size(155, 26)}
        ElseIf t = GetType(DateTime) Then
            Return New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Font = New Font("Segoe UI", 9), .Location = New Point(left, 5), .Size = New Size(155, 26)}
        ElseIf t = GetType(Boolean) Then
            Dim c As New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 9), .Location = New Point(left, 5), .Size = New Size(155, 26)}
            c.Items.AddRange({"True", "False"}) : c.SelectedIndex = 0
            Return c
        Else
            Return New NumericUpDown() With {.Font = New Font("Segoe UI", 9), .Location = New Point(left, 5), .Size = New Size(155, 26), .Maximum = 999999999, .Minimum = -999999999}
        End If
    End Function

    ' Đọc giá trị từ control
    Private Function GetVal(c As Control) As Object
        If c Is Nothing OrElse Not c.Visible Then Return Nothing
        If TypeOf c Is TextBox Then Return CType(c, TextBox).Text
        If TypeOf c Is DateTimePicker Then Return CType(c, DateTimePicker).Value
        If TypeOf c Is NumericUpDown Then Return CType(c, NumericUpDown).Value
        If TypeOf c Is ComboBox Then Return (CType(c, ComboBox).SelectedItem?.ToString() = "True")
        Return Nothing
    End Function

    ' Public: xuất FilterModel
    Public Function GetFilter() As FilterModel
        Dim fi = TryCast(_cboField.SelectedItem, FilterHelper.FieldInfo)
        If fi Is Nothing Then Return Nothing
        Return New FilterModel With {
            .Field = fi.PropName,
            .Opera = _cboOp.SelectedItem?.ToString(),
            .Value1 = GetVal(_ctrl1),
            .Value2 = GetVal(_ctrl2)
        }
    End Function

End Class