Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports System.Text

Partial Public Class formPolicy
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  ENUM BUTTON GROUPS — xây dựng động
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub BuildEnumGroup(pnl As Panel, labels As String(),
                               defaultIdx As Integer,
                               onSelect As Action(Of Integer))
        pnl.Controls.Clear()
        Dim xPos As Integer = 0

        Dim i As Integer
        For i = 0 To labels.Length - 1
            Dim idx = i  ' closure capture
            Dim btn As New Button()
            btn.Text = labels(i)
            btn.Font = New System.Drawing.Font("Microsoft YaHei UI", 9!)
            btn.Size = New System.Drawing.Size(
                System.Windows.Forms.TextRenderer.MeasureText(labels(i), btn.Font).Width + 24, 30)
            btn.Location = New System.Drawing.Point(xPos, 0)
            btn.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
            btn.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80)
            btn.FlatAppearance.BorderSize = 1
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 74, 158, 255)
            btn.UseVisualStyleBackColor = False
            btn.Cursor = System.Windows.Forms.Cursors.Hand
            btn.Tag = i

            If i = defaultIdx Then
                ActivateEnumBtn(btn)
            End If

            AddHandler btn.Click, Sub(s, ev)
                                      Dim clicked = CType(s, Button)
                                      For Each c As Control In pnl.Controls
                                          Dim b = TryCast(c, Button)
                                          If b IsNot Nothing Then DeactivateEnumBtn(b)
                                      Next
                                      ActivateEnumBtn(clicked)
                                      onSelect(CInt(clicked.Tag))
                                  End Sub

            pnl.Controls.Add(btn)
            xPos += btn.Width + 6
        Next
    End Sub

    Private Sub ActivateEnumBtn(btn As Button)
        btn.BackColor = System.Drawing.Color.FromArgb(20, 74, 158, 255)
        btn.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(74, 158, 255)
    End Sub

    Private Sub DeactivateEnumBtn(btn As Button)
        btn.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        btn.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 48, 80)
    End Sub

    Private Sub SetEnum(pnl As Panel, idx As Integer)
        For Each c As Control In pnl.Controls
            Dim b = TryCast(c, Button)
            If b IsNot Nothing Then
                If CInt(b.Tag) = idx Then
                    ActivateEnumBtn(b)
                Else
                    DeactivateEnumBtn(b)
                End If
            End If
        Next
    End Sub

    Private Sub SetCat(v As Integer)
        _selCat = v
    End Sub
    Private Sub SetSrc(v As Integer)
        _selSrc = v
    End Sub
    Private Sub SetAgg(v As Integer)
        _selAgg = v
    End Sub
    Private Sub SetGen(v As Integer)
        _selGen = v
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  CONDITION BUILDER
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub AddCondRow(field As String, op As String, val As String)
        Dim row As New Panel()
        row.BackColor = System.Drawing.Color.FromArgb(30, 34, 53)
        row.Size = New Size(flpConditions.ClientSize.Width - 20, 36)
        row.Margin = New Padding(0, 4, 0, 0)

        ' Field combobox
        Dim cboField As New ComboBox()
        cboField.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        cboField.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        cboField.FlatStyle = FlatStyle.Flat
        cboField.DropDownStyle = ComboBoxStyle.DropDown
        cboField.Font = New System.Drawing.Font("Courier New", 9!)
        cboField.Items.AddRange(New Object() {
            "contract.status", "contract.end_date",
            "employee.status",
            "attendance.late_hours", "attendance.office_hours",
            "position.start_date", "position.end_date"})
        cboField.Text = field
        cboField.Location = New Point(4, 4)
        cboField.Size = New Size(240, 28)

        ' Operator combobox
        Dim cboOp As New ComboBox()
        cboOp.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        cboOp.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
        cboOp.FlatStyle = FlatStyle.Flat
        cboOp.DropDownStyle = ComboBoxStyle.DropDownList
        cboOp.Font = New System.Drawing.Font("Courier New", 9.0!)
        cboOp.Items.AddRange(New Object() {"=", "!=", ">", "<", ">=", "<="})
        cboOp.Text = op
        cboOp.Location = New Point(250, 4)
        cboOp.Size = New Size(70, 28)

        ' Value textbox
        Dim txtVal As New TextBox()
        txtVal.BackColor = System.Drawing.Color.FromArgb(38, 43, 66)
        txtVal.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
        txtVal.BorderStyle = BorderStyle.FixedSingle
        txtVal.Font = New System.Drawing.Font("Courier New", 9.0!)
        txtVal.Text = val
        txtVal.Location = New Point(326, 4)
        txtVal.Size = New Size(140, 28)

        ' Delete button
        Dim btnDel As New Button()
        btnDel.BackColor = System.Drawing.Color.FromArgb(25, 229, 62, 62)
        btnDel.FlatStyle = FlatStyle.Flat
        btnDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 229, 62, 62)
        btnDel.FlatAppearance.BorderSize = 1
        btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 229, 62, 62)
        btnDel.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
        btnDel.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.0!, System.Drawing.FontStyle.Bold)
        btnDel.Location = New Point(472, 4)
        btnDel.Size = New Size(28, 28)
        btnDel.Text = "×"
        btnDel.UseVisualStyleBackColor = False
        btnDel.Cursor = Cursors.Hand

        AddHandler btnDel.Click, Sub(s, ev)
                                     flpConditions.Controls.Remove(row)
                                     row.Dispose()
                                 End Sub

        row.Controls.Add(cboField)
        row.Controls.Add(cboOp)
        row.Controls.Add(txtVal)
        row.Controls.Add(btnDel)
        flpConditions.Controls.Add(row)

        UpdateFormulaPreview()
    End Sub

    Private Sub btnAddCond_Click(sender As Object, e As EventArgs) Handles btnAddCond.Click
        AddCondRow("contract.status", "=", "1")
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORMULA PREVIEW
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub UpdateFormulaPreview()
        Dim sb As New System.Text.StringBuilder()
        sb.Append("KẾT QUẢ  =  ROUND( ")
        If Not String.IsNullOrWhiteSpace(txtFormula.Text) Then
            sb.Append("formula")
        Else
            sb.Append("?")
        End If
        sb.Append(", 1000 )")

        Dim condCount = flpConditions.Controls.Count
        If condCount > 0 Then
            sb.Append(vbCrLf & "NẾU  ")
            Dim mode = If(cboCondMode.SelectedIndex = 0, " VÀ ", " HOẶC ")
            Dim first = True
            For Each c As Control In flpConditions.Controls
                Dim pnl = TryCast(c, Panel)
                If pnl Is Nothing Then Continue For
                If Not first Then sb.Append(mode)
                Dim fldCtrl = TryCast(pnl.Controls(0), ComboBox)
                Dim opCtrl = TryCast(pnl.Controls(1), ComboBox)
                Dim valCtrl = TryCast(pnl.Controls(2), TextBox)
                If fldCtrl IsNot Nothing AndAlso opCtrl IsNot Nothing AndAlso valCtrl IsNot Nothing Then
                    sb.Append(fldCtrl.Text & " " & opCtrl.Text & " " & valCtrl.Text)
                End If
                first = False
            Next
        End If

        lblFormulaPreview.Text = sb.ToString()
    End Sub

    Private Sub txtFormula_TextChanged(sender As Object, e As EventArgs) Handles txtFormula.TextChanged
        UpdateFormulaPreview()
    End Sub

    Private Sub cboCondMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCondMode.SelectedIndexChanged
        UpdateFormulaPreview()
    End Sub
End Class
