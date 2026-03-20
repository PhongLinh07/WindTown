Imports System.Runtime.InteropServices

' ============================================================
'  formPolicy.vb — Chính sách lương (Rule Engine)
'  .NET Framework 4.8 — Mock data
'  Không dùng PlaceholderText → Win32 EM_SETCUEBANNER
' ============================================================
Public Class formPolicy

    ' ── Win32: hint text cho TextBox (.NET 4.8 không có PlaceholderText) ──
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501

    Private Sub SetPlaceholder(tb As TextBox, hint As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), hint)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  ENUM LABELS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private ReadOnly CAT_LABELS As String() = {"Thu nhập", "Khấu trừ", "Thưởng", "Phụ cấp"}
    Private ReadOnly SRC_LABELS As String() = {"Hợp đồng", "Chấm công", "Nghỉ phép", "Phân công", "Thủ công"}
    Private ReadOnly AGG_LABELS As String() = {"Cố định", "Tổng", "Trung bình", "Đếm", "Tỷ lệ"}
    Private ReadOnly GEN_LABELS As String() = {"Lương chính", "Phụ cấp", "Thưởng", "Khấu trừ", "Bảo hiểm"}

    ' Current enum selections
    Private _selCat As Integer = 0
    Private _selSrc As Integer = 0
    Private _selAgg As Integer = 0
    Private _selGen As Integer = 0
    Private _priority As Integer = 1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA STRUCTURE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure PolicyRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Category As Integer    ' 0=Thu nhập 1=Khấu trừ 2=Thưởng 3=Phụ cấp
        Dim DataSource As Integer  ' 0=HĐ 1=CC 2=NP 3=PD 4=Thủ công
        Dim Aggregate As Integer   ' 0=Cố định 1=Tổng 2=TB 3=Đếm 4=Tỷ lệ
        Dim GenItem As Integer     ' 0=Lương 1=Phụ cấp 2=Thưởng 3=Khấu trừ 4=BHXH
        Dim Priority As Integer
        Dim Status As Integer      ' 1=active 0=off
        Dim Note As String
        Dim Rule As String         ' JSON formula
    End Structure

    Private Structure PreviewRow
        Dim Name As String
        Dim Category As Integer
        Dim EmpCount As Integer
        Dim Total As String
        Dim MinVal As String
        Dim MaxVal As String
        Dim IsOk As Boolean
        Dim IsIncome As Boolean    ' True=positive, False=negative
    End Structure

    Private _allPolicies As New List(Of PolicyRow)()
    Private _allPreview As New List(Of PreviewRow)()
    Private _filtered As New List(Of PolicyRow)()
    Private _selectedId As Integer = -1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formPolicy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        ' Placeholder text (Win32, .NET 4.8 compatible)
        SetPlaceholder(txtSearch, "🔍  Tìm kiếm chính sách...")
        SetPlaceholder(txtEditorSearch, "Tìm trong danh sách...")
        SetPlaceholder(txtCode, "POL001")
        SetPlaceholder(txtFName, "Lương cơ bản")
        SetPlaceholder(txtFNote, "Mô tả chính sách...")

        ' Build dynamic enum button groups
        BuildEnumGroup(pnlCatGroup, CAT_LABELS, 0,
                       Sub(v) SetCat(v))
        BuildEnumGroup(pnlSrcGroup, SRC_LABELS, 0,
                       Sub(v) SetSrc(v))
        BuildEnumGroup(pnlAggGroup, AGG_LABELS, 0,
                       Sub(v) SetAgg(v))
        BuildEnumGroup(pnlGenGroup, GEN_LABELS, 0,
                       Sub(v) SetGen(v))

        ' Load data
        LoadMockPolicies()
        LoadMockPreview()
        _filtered = New List(Of PolicyRow)(_allPolicies)

        ' Render
        RenderPolicyTable(_filtered)
        RenderPolicyList(_allPolicies)
        RenderPreview()

        ' Add default condition rows
        AddCondRow("contract.status", "=", "1")
        AddCondRow("employee.status", "=", "1")

        ' Default formula
        txtFormula.Text = "{" & vbCrLf &
            "  ""formula"": ""base_salary * salary_mult.mult""," & vbCrLf &
            "  ""fields"": [""contract.base_salary"", ""salary_mult.mult""]," & vbCrLf &
            "  ""round"": 1000," & vbCrLf &
            "  ""min"": 0" & vbCrLf &
            "}"

        ' Resize handlers
        AddHandler pnlTab1.Resize, AddressOf OnTab1Resize
        AddHandler pnlPreviewResult.Resize, AddressOf OnPreviewResultResize
        AddHandler pnlEditorFooter.Resize, AddressOf OnEditorFooterResize
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlPreviewSummary.Resize, AddressOf OnSummaryResize
        AddHandler pnlPreviewCtrl.Resize, AddressOf OnPreviewCtrlResize

        ShowTab(1)

        ' Select first policy
        If _allPolicies.Count > 0 Then
            SelectPolicy(_allPolicies(0).Id)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockPolicies()
        _allPolicies.Clear()

        Dim p1 As New PolicyRow()
        p1.Id = 1 : p1.Code = "POL001" : p1.Name = "Lương cơ bản"
        p1.Category = 0 : p1.DataSource = 0 : p1.Aggregate = 0 : p1.GenItem = 0
        p1.Priority = 1 : p1.Status = 1
        p1.Note = "Lương cơ bản từ hợp đồng × hệ số cấp bậc"
        p1.Rule = "{""formula"":""base_salary * salary_mult.mult"",""round"":1000,""min"":0}"
        _allPolicies.Add(p1)

        Dim p2 As New PolicyRow()
        p2.Id = 2 : p2.Code = "POL002" : p2.Name = "Thưởng chuyên cần"
        p2.Category = 2 : p2.DataSource = 1 : p2.Aggregate = 1 : p2.GenItem = 2
        p2.Priority = 2 : p2.Status = 1
        p2.Note = "Thưởng nếu không đi trễ và không vắng trong tháng"
        p2.Rule = "{""formula"":""IF(late_count=0 AND absent_count=0, 500000, 0)"",""round"":0,""min"":0}"
        _allPolicies.Add(p2)

        Dim p3 As New PolicyRow()
        p3.Id = 3 : p3.Code = "POL003" : p3.Name = "Khấu trừ đi trễ"
        p3.Category = 1 : p3.DataSource = 1 : p3.Aggregate = 1 : p3.GenItem = 3
        p3.Priority = 3 : p3.Status = 1
        p3.Note = "Trừ tiền theo tổng số giờ đi trễ trong kỳ"
        p3.Rule = "{""formula"":""-1 * SUM(late_hours) * hourly_rate"",""round"":1000,""max"":0}"
        _allPolicies.Add(p3)

        Dim p4 As New PolicyRow()
        p4.Id = 4 : p4.Code = "POL004" : p4.Name = "Phụ cấp ăn trưa"
        p4.Category = 3 : p4.DataSource = 0 : p4.Aggregate = 0 : p4.GenItem = 1
        p4.Priority = 4 : p4.Status = 1
        p4.Note = "Phụ cấp cố định 30.000đ × số ngày làm việc"
        p4.Rule = "{""formula"":""30000 * work_days"",""round"":0,""min"":0}"
        _allPolicies.Add(p4)

        Dim p5 As New PolicyRow()
        p5.Id = 5 : p5.Code = "POL005" : p5.Name = "Phụ cấp điện thoại"
        p5.Category = 3 : p5.DataSource = 0 : p5.Aggregate = 0 : p5.GenItem = 1
        p5.Priority = 5 : p5.Status = 1
        p5.Note = "Phụ cấp điện thoại cố định theo vị trí công việc"
        p5.Rule = "{""formula"":""job.phone_allowance"",""round"":0,""min"":0}"
        _allPolicies.Add(p5)

        Dim p6 As New PolicyRow()
        p6.Id = 6 : p6.Code = "POL006" : p6.Name = "BHXH người lao động"
        p6.Category = 1 : p6.DataSource = 0 : p6.Aggregate = 4 : p6.GenItem = 4
        p6.Priority = 6 : p6.Status = 1
        p6.Note = "8% lương đóng BHXH phần người lao động chịu"
        p6.Rule = "{""formula"":""-0.08 * base_salary"",""round"":0,""max"":0}"
        _allPolicies.Add(p6)

        Dim p7 As New PolicyRow()
        p7.Id = 7 : p7.Code = "POL007" : p7.Name = "BHYT người lao động"
        p7.Category = 1 : p7.DataSource = 0 : p7.Aggregate = 4 : p7.GenItem = 4
        p7.Priority = 7 : p7.Status = 1
        p7.Note = "1.5% lương đóng BHYT phần người lao động chịu"
        p7.Rule = "{""formula"":""-0.015 * base_salary"",""round"":0,""max"":0}"
        _allPolicies.Add(p7)

        Dim p8 As New PolicyRow()
        p8.Id = 8 : p8.Code = "POL008" : p8.Name = "Thưởng dự án"
        p8.Category = 2 : p8.DataSource = 3 : p8.Aggregate = 1 : p8.GenItem = 2
        p8.Priority = 8 : p8.Status = 0
        p8.Note = "Thưởng theo số dự án hoàn thành trong kỳ (tắt)"
        p8.Rule = "{""formula"":""COUNT(completed_projects) * 1000000"",""round"":0,""min"":0}"
        _allPolicies.Add(p8)
    End Sub

    Private Sub LoadMockPreview()
        _allPreview.Clear()

        Dim r1 As New PreviewRow()
        r1.Name = "Lương cơ bản" : r1.Category = 0 : r1.EmpCount = 230
        r1.Total = "3.45 tỷ" : r1.MinVal = "8 tr" : r1.MaxVal = "45 tr"
        r1.IsOk = True : r1.IsIncome = True
        _allPreview.Add(r1)

        Dim r2 As New PreviewRow()
        r2.Name = "Thưởng chuyên cần" : r2.Category = 2 : r2.EmpCount = 198
        r2.Total = "99 tr" : r2.MinVal = "0" : r2.MaxVal = "500k"
        r2.IsOk = True : r2.IsIncome = True
        _allPreview.Add(r2)

        Dim r3 As New PreviewRow()
        r3.Name = "Khấu trừ đi trễ" : r3.Category = 1 : r3.EmpCount = 47
        r3.Total = "-23.5 tr" : r3.MinVal = "-2.5 tr" : r3.MaxVal = "-150k"
        r3.IsOk = True : r3.IsIncome = False
        _allPreview.Add(r3)

        Dim r4 As New PreviewRow()
        r4.Name = "Phụ cấp ăn trưa" : r4.Category = 3 : r4.EmpCount = 230
        r4.Total = "138 tr" : r4.MinVal = "600k" : r4.MaxVal = "660k"
        r4.IsOk = True : r4.IsIncome = True
        _allPreview.Add(r4)

        Dim r5 As New PreviewRow()
        r5.Name = "Phụ cấp điện thoại" : r5.Category = 3 : r5.EmpCount = 85
        r5.Total = "51 tr" : r5.MinVal = "300k" : r5.MaxVal = "1 tr"
        r5.IsOk = True : r5.IsIncome = True
        _allPreview.Add(r5)

        Dim r6 As New PreviewRow()
        r6.Name = "BHXH người lao động" : r6.Category = 1 : r6.EmpCount = 230
        r6.Total = "-276 tr" : r6.MinVal = "-2.2 tr" : r6.MaxVal = "-3.6 tr"
        r6.IsOk = True : r6.IsIncome = False
        _allPreview.Add(r6)

        Dim r7 As New PreviewRow()
        r7.Name = "BHYT người lao động" : r7.Category = 1 : r7.EmpCount = 230
        r7.Total = "-51.75 tr" : r7.MinVal = "-413k" : r7.MaxVal = "-675k"
        r7.IsOk = True : r7.IsIncome = False
        _allPreview.Add(r7)

        Dim r8 As New PreviewRow()
        r8.Name = "Thưởng dự án" : r8.Category = 2 : r8.EmpCount = 0
        r8.Total = "—" : r8.MinVal = "—" : r8.MaxVal = "—"
        r8.IsOk = False : r8.IsIncome = True
        _allPreview.Add(r8)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private _currentTab As Integer = 1

    Private Sub ShowTab(tab As Integer)
        _currentTab = tab
        pnlTab1.Visible = (tab = 1)
        pnlTab2.Visible = (tab = 2)
        pnlTab3.Visible = (tab = 3)

        Dim clrActive = System.Drawing.Color.FromArgb(74, 158, 255)
        Dim clrNormal = System.Drawing.Color.FromArgb(123, 139, 178)

        btnTab1.ForeColor = If(tab = 1, clrActive, clrNormal)
        btnTab2.ForeColor = If(tab = 2, clrActive, clrNormal)
        btnTab3.ForeColor = If(tab = 3, clrActive, clrNormal)

        Select Case tab
            Case 1 : pnlTabIndicator.Left = 0 : pnlTabIndicator.Width = 160
            Case 2 : pnlTabIndicator.Left = 160 : pnlTabIndicator.Width = 180
            Case 3 : pnlTabIndicator.Left = 340 : pnlTabIndicator.Width = 200
        End Select
    End Sub

    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        ShowTab(1)
    End Sub

    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        ShowTab(2)
    End Sub

    Private Sub btnTab3_Click(sender As Object, e As EventArgs) Handles btnTab3.Click
        ShowTab(3)
    End Sub

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
            btn.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.5!)
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
        cboField.Font = New System.Drawing.Font("Courier New", 8.5!)
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

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER — TAB 1 TABLE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPolicyTable(data As List(Of PolicyRow))
        dgvPolicy.Rows.Clear()

        For Each p In data
            dgvPolicy.Rows.Add(
                False,
                p.Name,
                p.Code,
                CAT_LABELS(p.Category),
                SRC_LABELS(p.DataSource),
                AGG_LABELS(p.Aggregate),
                GEN_LABELS(p.GenItem),
                p.Priority,
                If(p.Status = 1, "● Kích hoạt", "○ Tắt"),
                "✎  Sửa")

            Dim row = dgvPolicy.Rows(dgvPolicy.Rows.Count - 1)
            row.Tag = p.Id

            ' Category color
            Select Case p.Category
                Case 0 : row.Cells("colCat").Style.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
                Case 1 : row.Cells("colCat").Style.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
                Case 2 : row.Cells("colCat").Style.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
                Case 3 : row.Cells("colCat").Style.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11)
            End Select

            ' Status color
            If p.Status = 1 Then
                row.Cells("colStat").Style.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colStat").Style.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
            End If

            ' Priority badge color
            row.Cells("colPri").Style.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
        Next

        lblRowInfo.Text = String.Format("Hiển thị {0} / {1} chính sách",
                                         data.Count, _allPolicies.Count)
        dgvPolicy.Size = New System.Drawing.Size(
            pnlTab1.Width, pnlTab1.Height - pnlTblFooter.Height)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER — TAB 2 LEFT LIST
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPolicyList(data As List(Of PolicyRow))
        flpPolicyList.Controls.Clear()

        Dim catColors() As System.Drawing.Color = {
            System.Drawing.Color.FromArgb(74, 158, 255),
            System.Drawing.Color.FromArgb(240, 128, 128),
            System.Drawing.Color.FromArgb(76, 175, 80),
            System.Drawing.Color.FromArgb(245, 158, 11)
        }

        For Each p In data
            Dim pId = p.Id
            Dim card As New Panel()
            card.BackColor = If(_selectedId = p.Id,
                                System.Drawing.Color.FromArgb(25, 74, 158, 255),
                                System.Drawing.Color.Transparent)
            card.Width = flpPolicyList.ClientSize.Width - 20
            card.Height = 54
            card.Margin = New Padding(0, 0, 0, 2)
            card.Padding = New Padding(10, 8, 10, 8)
            card.Cursor = Cursors.Hand
            card.Tag = p.Id

            ' Accent bar
            Dim accentBar As New Panel()
            accentBar.BackColor = If(p.Status = 1, catColors(p.Category),
                                     System.Drawing.Color.FromArgb(61, 74, 114))
            accentBar.Location = New Point(0, 0)
            accentBar.Size = New Size(3, 54)

            ' Policy name label
            Dim lblName As New Label()
            lblName.AutoSize = True
            lblName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!, System.Drawing.FontStyle.Bold)
            lblName.ForeColor = System.Drawing.Color.FromArgb(232, 236, 240)
            lblName.Location = New Point(14, 8)
            lblName.Text = p.Name

            ' Sub info
            Dim lblSub As New Label()
            lblSub.AutoSize = True
            lblSub.Font = New System.Drawing.Font("Courier New", 8.0!)
            lblSub.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
            lblSub.Location = New Point(14, 30)
            lblSub.Text = p.Code & "  ·  P" & p.Priority & "  ·  " & CAT_LABELS(p.Category)

            ' Status dot
            Dim lblDot As New Label()
            lblDot.AutoSize = True
            lblDot.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.0!)
            lblDot.ForeColor = If(p.Status = 1,
                                  System.Drawing.Color.FromArgb(76, 175, 80),
                                  System.Drawing.Color.FromArgb(61, 74, 114))
            lblDot.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            lblDot.Location = New Point(card.Width - 60, 10)
            lblDot.Text = If(p.Status = 1, "●", "○")

            card.Controls.Add(accentBar)
            card.Controls.Add(lblName)
            card.Controls.Add(lblSub)
            card.Controls.Add(lblDot)

            ' Click handler on all sub-controls
            Dim clickHandler As EventHandler = Sub(s, ev)
                                                   SelectPolicy(pId)
                                               End Sub
            AddHandler card.Click, clickHandler
            AddHandler lblName.Click, clickHandler
            AddHandler lblSub.Click, clickHandler
            AddHandler lblDot.Click, clickHandler

            flpPolicyList.Controls.Add(card)
        Next
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SELECT POLICY
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub SelectPolicy(id As Integer)
        _selectedId = id
        RenderPolicyList(_allPolicies)

        Dim p As PolicyRow = Nothing
        Dim found = False
        For Each x In _allPolicies
            If x.Id = id Then
                p = x
                found = True
                Exit For
            End If
        Next
        If Not found Then Return

        ' Fill form
        txtCode.Text = p.Code
        txtFName.Text = p.Name
        txtFNote.Text = p.Note
        cboFStatus.SelectedIndex = If(p.Status = 1, 0, 1)
        _priority = p.Priority
        lblPriorityNum.Text = _priority.ToString()

        SetEnum(pnlCatGroup, p.Category)
        _selCat = p.Category
        SetEnum(pnlSrcGroup, p.DataSource)
        _selSrc = p.DataSource
        SetEnum(pnlAggGroup, p.Aggregate)
        _selAgg = p.Aggregate
        SetEnum(pnlGenGroup, p.GenItem)
        _selGen = p.GenItem

        ' Formula
        txtFormula.Text = p.Rule

        ' Reset conditions
        flpConditions.Controls.Clear()
        AddCondRow("contract.status", "=", "1")
        AddCondRow("employee.status", "=", "1")

        UpdateFormulaPreview()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER — TAB 3 PREVIEW
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPreview()
        dgvPreview.Rows.Clear()

        Dim totalIncome As Decimal = 0
        Dim totalDeduct As Decimal = 0
        Dim errorCount As Integer = 0

        For Each r In _allPreview
            dgvPreview.Rows.Add(
                r.Name,
                CAT_LABELS(r.Category),
                If(r.EmpCount > 0, r.EmpCount.ToString() & " NV", "—"),
                r.Total,
                r.MinVal,
                r.MaxVal,
                If(r.IsOk, "✓  OK", "○  Tắt"))

            Dim row = dgvPreview.Rows(dgvPreview.Rows.Count - 1)

            ' Category color
            Select Case r.Category
                Case 0 : row.Cells("colPrevCat").Style.ForeColor = System.Drawing.Color.FromArgb(74, 158, 255)
                Case 1 : row.Cells("colPrevCat").Style.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
                Case 2 : row.Cells("colPrevCat").Style.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
                Case 3 : row.Cells("colPrevCat").Style.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11)
            End Select

            ' Total color
            If r.IsIncome Then
                row.Cells("colPrevTotal").Style.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colPrevTotal").Style.ForeColor = System.Drawing.Color.FromArgb(240, 128, 128)
            End If

            ' Status color
            If r.IsOk Then
                row.Cells("colPrevStat").Style.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colPrevStat").Style.ForeColor = System.Drawing.Color.FromArgb(123, 139, 178)
                errorCount += 1
            End If

            If Not r.IsOk Then errorCount -= 1  ' tắt bởi người dùng, không phải lỗi
        Next

        ' Summary KPI
        lblSum1Val.Text = "230"
        lblSum2Val.Text = "1,840"
        lblSum3Val.Text = "4.2 tỷ"
        lblSum4Val.Text = "380 tr"
        lblSum5Val.Text = "0"
        lblPreviewResultTitle.Text = String.Format(
            "Chi tiết kết quả — {0} chính sách × 230 nhân viên", _allPreview.Count)
        lblRunTime.Text = "Chạy lúc: " & DateTime.Now.ToString("HH:mm  dd/MM/yyyy")
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DGV CLICK EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub dgvPolicy_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPolicy.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvPolicy.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim id = CInt(row.Tag)

        ' Click "Sửa" column → go to editor
        If e.ColumnIndex = dgvPolicy.Columns("colEdit").Index Then
            SelectPolicy(id)
            ShowTab(2)
        Else
            SelectPolicy(id)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TOOLBAR EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCat.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim catIdx = cboCat.SelectedIndex  ' 0=all, 1-4=category
        Dim statIdx = cboStatusFilter.SelectedIndex  ' 0=all 1=active 2=off

        _filtered = New List(Of PolicyRow)()
        For Each p In _allPolicies
            Dim matchQ = q = "" OrElse
                         p.Name.ToLower().Contains(q) OrElse
                         p.Code.ToLower().Contains(q)
            Dim matchCat = catIdx = 0 OrElse p.Category = catIdx - 1
            Dim matchStat = statIdx = 0 OrElse
                            (statIdx = 1 AndAlso p.Status = 1) OrElse
                            (statIdx = 2 AndAlso p.Status = 0)

            If matchQ AndAlso matchCat AndAlso matchStat Then
                _filtered.Add(p)
            End If
        Next

        RenderPolicyTable(_filtered)
    End Sub

    Private Sub btnAddPolicy_Click(sender As Object, e As EventArgs) Handles btnAddPolicy.Click
        NewPolicy()
        ShowTab(2)
    End Sub

    Private Sub btnRunAll_Click(sender As Object, e As EventArgs) Handles btnRunAll.Click
        ShowTab(3)
        RenderPreview()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  EDITOR EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnNewPolicy_Click(sender As Object, e As EventArgs) Handles btnNewPolicy.Click
        NewPolicy()
    End Sub

    Private Sub btnPriDec_Click(sender As Object, e As EventArgs) Handles btnPriDec.Click
        If _priority > 1 Then
            _priority -= 1
            lblPriorityNum.Text = _priority.ToString()
        End If
    End Sub

    Private Sub btnPriInc_Click(sender As Object, e As EventArgs) Handles btnPriInc.Click
        _priority += 1
        lblPriorityNum.Text = _priority.ToString()
    End Sub

    Private Sub btnSavePolicy_Click(sender As Object, e As EventArgs) Handles btnSavePolicy.Click
        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã chính sách.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên chính sách.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus()
            Return
        End If
        ' Validate JSON formula loosely
        Dim formula = txtFormula.Text.Trim()
        If Not formula.StartsWith("{") OrElse Not formula.EndsWith("}") Then
            MessageBox.Show("Công thức phải là JSON hợp lệ (bắt đầu { kết thúc }).",
                            "Lỗi công thức", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFormula.Focus()
            Return
        End If

        MessageBox.Show(String.Format("Đã lưu chính sách: {0} — {1}", txtCode.Text, txtFName.Text),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClearPolicy_Click(sender As Object, e As EventArgs) Handles btnClearPolicy.Click
        NewPolicy()
    End Sub

    Private Sub btnDelPolicy_Click(sender As Object, e As EventArgs) Handles btnDelPolicy.Click
        If _selectedId < 0 Then
            MessageBox.Show("Chưa chọn chính sách.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim polName = txtFName.Text
        Dim result = MessageBox.Show(
            String.Format("Bạn có chắc muốn xóa chính sách ""{0}""?", polName),
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock data).", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selectedId = -1
            NewPolicy()
            ShowTab(1)
        End If
    End Sub

    Private Sub btnRunTest_Click(sender As Object, e As EventArgs) Handles btnRunTest.Click
        ShowTab(3)
        RenderPreview()
    End Sub

    ' ── Preview tab events ────────────────────────────────────
    Private Sub btnRunPreview_Click(sender As Object, e As EventArgs) Handles btnRunPreview.Click
        lblPreviewResultTitle.Text = "Đang xử lý..."
        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(400)
        RenderPreview()
    End Sub

    Private Sub btnExportPreview_Click(sender As Object, e As EventArgs) Handles btnExportPreview.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp khi kết nối DB.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── Editor search ─────────────────────────────────────────
    Private Sub txtEditorSearch_TextChanged(sender As Object, e As EventArgs) Handles txtEditorSearch.TextChanged
        Dim q = txtEditorSearch.Text.Trim().ToLower()
        If q = "" Then
            RenderPolicyList(_allPolicies)
        Else
            Dim filtered As New List(Of PolicyRow)()
            For Each p In _allPolicies
                If p.Name.ToLower().Contains(q) OrElse p.Code.ToLower().Contains(q) Then
                    filtered.Add(p)
                End If
            Next
            RenderPolicyList(filtered)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub NewPolicy()
        _selectedId = -1
        txtCode.Clear()
        txtFName.Clear()
        txtFNote.Clear()
        cboFStatus.SelectedIndex = 0
        _priority = _allPolicies.Count + 1
        lblPriorityNum.Text = _priority.ToString()

        SetEnum(pnlCatGroup, 0) : _selCat = 0
        SetEnum(pnlSrcGroup, 0) : _selSrc = 0
        SetEnum(pnlAggGroup, 0) : _selAgg = 0
        SetEnum(pnlGenGroup, 0) : _selGen = 0

        flpConditions.Controls.Clear()
        AddCondRow("contract.status", "=", "1")
        txtFormula.Text = "{" & vbCrLf &
            "  ""formula"": ""base_salary""," & vbCrLf &
            "  ""round"": 1000," & vbCrLf &
            "  ""min"": 0" & vbCrLf &
            "}"

        RenderPolicyList(_allPolicies)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE HANDLERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnTab1Resize(sender As Object, e As EventArgs)
        dgvPolicy.Size = New System.Drawing.Size(
            pnlTab1.Width,
            pnlTab1.Height - pnlTblFooter.Height)
    End Sub

    Private Sub OnPreviewResultResize(sender As Object, e As EventArgs)
        dgvPreview.Size = New System.Drawing.Size(
            pnlPreviewResult.Width,
            pnlPreviewResult.Height - pnlPreviewResultHeader.Height)
    End Sub

    Private Sub OnEditorFooterResize(sender As Object, e As EventArgs)
        btnRunTest.Left = pnlEditorFooter.Width - btnSavePolicy.Width - btnClearPolicy.Width - btnRunTest.Width - 36
        btnClearPolicy.Left = pnlEditorFooter.Width - btnSavePolicy.Width - btnClearPolicy.Width - 22
        btnSavePolicy.Left = pnlEditorFooter.Width - btnSavePolicy.Width - 14
    End Sub

    Private Sub OnToolbarResize(sender As Object, e As EventArgs)
        btnRunAll.Left = pnlToolbar.Width - btnAddPolicy.Width - btnRunAll.Width - 20
        btnAddPolicy.Left = pnlToolbar.Width - btnAddPolicy.Width - 14
    End Sub

    Private Sub OnSummaryResize(sender As Object, e As EventArgs)
        Dim w = (pnlPreviewSummary.Width - 8) \ 5
        pnlSum1.Width = w : pnlSum1.Left = 0
        pnlSum2.Width = w : pnlSum2.Left = w + 2
        pnlSum3.Width = w : pnlSum3.Left = (w + 2) * 2
        pnlSum4.Width = w : pnlSum4.Left = (w + 2) * 3
        pnlSum5.Width = w : pnlSum5.Left = (w + 2) * 4
    End Sub

    Private Sub OnPreviewCtrlResize(sender As Object, e As EventArgs)
        lblRunTime.Left = pnlPreviewCtrl.Width - btnRunPreview.Width - lblRunTime.Width - 30
        btnRunPreview.Left = pnlPreviewCtrl.Width - btnRunPreview.Width - 14
    End Sub

End Class