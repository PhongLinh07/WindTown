Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

' ============================================================
'  formSalaryMult.vb — Hệ số lương  (.NET 4.8 · Mock data)
'  table: salary_mult
'  datas: code, value (mult), note, status
'  FK: job_id, level_id
'  Tab 1 = Ma trận job × level (GDI+ CellPainting)
'  Tab 2 = Master-Detail chi tiết
' ============================================================
Public Class formSalaryMult

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Sub SetPH(tb As TextBox, h As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), h)
    End Sub

    ' ── Data structures ───────────────────────────────────────
    Private Structure MultRow
        Dim Id As Integer
        Dim Code As String
        Dim JobId As Integer
        Dim JobName As String
        Dim LevelId As Integer
        Dim LevelName As String
        Dim LevelRank As Integer
        Dim Mult As Decimal
        Dim Note As String
        Dim Status As Integer
    End Structure

    ' Master data — jobs và levels (từ formJob/formLevel)
    Private ReadOnly _jobs() As String = {
        "Lập trình viên", "Senior Developer", "QA Engineer",
        "DevOps Engineer", "Frontend Developer",
        "Kế toán trưởng", "Kế toán viên",
        "Chuyên viên NS", "Sales Executive", "Ops Manager"
    }
    Private ReadOnly _levels() As String = {
        "Thực tập sinh", "Nhân viên", "Nhân viên CK",
        "Senior", "Lead", "Manager"
    }
    Private ReadOnly _levelRanks() As Integer = {1, 2, 3, 4, 5, 6}

    Private _all As New List(Of MultRow)()
    Private _filtered As New List(Of MultRow)()
    Private _selId As Integer = -1
    Private _sampleBase As Decimal = 15000000D

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formSalaryMult_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        SetPH(txtFCode, "SM-JOB01-LV02")
        SetPH(txtFNote, "Ghi chú hệ số...")

        ' Populate combos
        cboFJob.Items.Clear()
        cboFJob.Items.Add("— Chọn chức danh —")
        For Each j In _jobs
            cboFJob.Items.Add(j)
        Next
        cboFJob.SelectedIndex = 0

        cboFLevel.Items.Clear()
        cboFLevel.Items.Add("— Chọn cấp bậc —")
        For Each l In _levels
            cboFLevel.Items.Add(l)
        Next
        cboFLevel.SelectedIndex = 0

        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        AddHandler pnlTab1.Resize, AddressOf OnTab1Resize
        AddHandler pnlMatrixHeader.Resize, AddressOf OnMatrixHeaderResize
        AddHandler txtFMult.TextChanged, AddressOf OnMultChanged
        AddHandler dgvMatrix.CellClick, AddressOf Matrix_CellClick

        LoadMock()
        _filtered = New List(Of MultRow)(_all)

        BuildMatrixColumns()
        RenderMatrix()
        RenderDetail(_filtered)

        If _all.Count > 0 Then SelectItem(_all(0).Id)

        ShowTab(1)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMock()
        _all.Clear()
        Dim id As Integer = 0

        ' Job 1: Lập trình viên — levels 1-5
        Dim multMap(,) As Object = {
            {1, "Lập trình viên",   1, "Thực tập sinh", 1, 0.6D},
            {2, "Lập trình viên",   2, "Nhân viên",     2, 1.0D},
            {3, "Lập trình viên",   3, "Nhân viên CK",  3, 1.3D},
            {4, "Lập trình viên",   4, "Senior",        4, 1.8D},
            {5, "Lập trình viên",   5, "Lead",          5, 2.4D},
            {6, "Senior Developer", 2, "Nhân viên",     2, 1.4D},
            {7, "Senior Developer", 3, "Nhân viên CK",  3, 1.8D},
            {8, "Senior Developer", 4, "Senior",        4, 2.2D},
            {9, "Senior Developer", 5, "Lead",          5, 2.8D},
            {10,"QA Engineer",      2, "Nhân viên",     2, 1.0D},
            {11,"QA Engineer",      3, "Nhân viên CK",  3, 1.3D},
            {12,"QA Engineer",      4, "Senior",        4, 1.7D},
            {13,"Kế toán trưởng",   4, "Senior",        4, 2.0D},
            {14,"Kế toán trưởng",   5, "Lead",          5, 2.5D},
            {15,"Kế toán trưởng",   6, "Manager",       6, 3.0D},
            {16,"Kế toán viên",     2, "Nhân viên",     2, 1.0D},
            {17,"Kế toán viên",     3, "Nhân viên CK",  3, 1.3D},
            {18,"Chuyên viên NS",   2, "Nhân viên",     2, 1.0D},
            {19,"Chuyên viên NS",   3, "Nhân viên CK",  3, 1.2D},
            {20,"Sales Executive",  2, "Nhân viên",     2, 1.0D},
            {21,"Sales Executive",  3, "Nhân viên CK",  3, 1.4D},
            {22,"Sales Executive",  4, "Senior",        4, 1.8D},
            {23,"Ops Manager",      5, "Lead",          5, 2.2D},
            {24,"Ops Manager",      6, "Manager",       6, 2.8D}
        }

        Dim i As Integer
        For i = 0 To multMap.GetUpperBound(0)
            Dim r As New MultRow()
            r.Id = CInt(multMap(i, 0))
            r.JobName = CStr(multMap(i, 1))
            r.JobId = Array.IndexOf(_jobs, r.JobName) + 1
            r.LevelRank = CInt(multMap(i, 2))
            r.LevelName = CStr(multMap(i, 3))
            r.LevelId = Array.IndexOf(_levels, r.LevelName) + 1
            r.Mult = CDec(multMap(i, 5))
            r.Code = "SM-" & r.JobId.ToString("00") & "-LV" & r.LevelRank.ToString("00")
            r.Note = "" : r.Status = 1
            _all.Add(r)
        Next
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub ShowTab(tab As Integer)
        pnlTab1.Visible = False
        pnlTab2.Visible = False

        If tab = 1 Then
            pnlTab1.Visible = True
            pnlTab1.BringToFront()
        Else
            pnlTab2.Visible = True
            pnlTab2.BringToFront()
        End If

        Dim clrActive = Color.FromArgb(74, 158, 255)
        Dim clrNormal = Color.FromArgb(123, 139, 178)
        btnTab1.ForeColor = If(tab = 1, clrActive, clrNormal)
        btnTab2.ForeColor = If(tab = 2, clrActive, clrNormal)
        pnlTabIndicator.Left = If(tab = 1, 0, 180)
    End Sub

    Private Sub btnTab1_Click(s As Object, e As EventArgs) Handles btnTab1.Click
        ShowTab(1)
    End Sub

    Private Sub btnTab2_Click(s As Object, e As EventArgs) Handles btnTab2.Click
        ShowTab(2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 1 — MA TRẬN
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub BuildMatrixColumns()
        ' Remove all columns except the frozen first one
        Do While dgvMatrix.Columns.Count > 1
            dgvMatrix.Columns.RemoveAt(dgvMatrix.Columns.Count - 1)
        Loop

        ' Add one column per level (ordered by rank)
        Dim lvIdx As Integer
        For lvIdx = 0 To _levels.Length - 1
            Dim col As New DataGridViewTextBoxColumn()
            col.HeaderText = _levels(lvIdx) & vbCrLf & "(Rank " & _levelRanks(lvIdx) & ")"
            col.Name = "colLv" & (lvIdx + 1).ToString()
            col.Width = 110
            col.ReadOnly = True
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            col.DefaultCellStyle.Font = New Font("Microsoft YaHei UI", 10.5!, FontStyle.Bold)
            dgvMatrix.Columns.Add(col)
        Next
    End Sub

    Private Sub RenderMatrix()
        dgvMatrix.Rows.Clear()

        ' Get unique jobs preserving order
        Dim jobsSeen As New List(Of String)()
        For Each r In _all
            If Not jobsSeen.Contains(r.JobName) Then
                jobsSeen.Add(r.JobName)
            End If
        Next

        For Each jobName In jobsSeen
            ' Build row values: one cell per level
            Dim vals(_levels.Length) As Object
            vals(0) = jobName

            Dim lvIdx As Integer
            For lvIdx = 0 To _levels.Length - 1
                Dim levelName = _levels(lvIdx)
                Dim found As MultRow = Nothing
                Dim hasVal = False
                For Each r In _all
                    If r.JobName = jobName AndAlso r.LevelName = levelName Then
                        found = r : hasVal = True : Exit For
                    End If
                Next
                vals(lvIdx + 1) = If(hasVal, found.Mult.ToString("0.0#"), "")
            Next

            dgvMatrix.Rows.Add(vals)
            Dim row = dgvMatrix.Rows(dgvMatrix.Rows.Count - 1)
            row.Tag = jobName
        Next

        ' Resize to fill tab
        dgvMatrix.Size = New Size(
            pnlTab1.Width,
            pnlTab1.Height - pnlMatrixHeader.Height)
    End Sub

    ' CellPainting — color cells by mult value
    Private Sub dgvMatrix_CellPainting(s As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMatrix.CellPainting
        If e.RowIndex < 0 OrElse e.ColumnIndex <= 0 Then Return
        If String.IsNullOrEmpty(TryCast(e.Value, String)) Then Return

        e.PaintBackground(e.ClipBounds, True)

        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim multVal As Decimal = 0
        If Decimal.TryParse(TryCast(e.Value, String), multVal) Then
            ' Heat map: green (low) → yellow → cyan (high)
            Dim cellClr As Color
            If multVal < 1.0D Then
                cellClr = Color.FromArgb(20, 123, 139, 178)
            ElseIf multVal < 1.5D Then
                cellClr = Color.FromArgb(25, 76, 175, 80)
            ElseIf multVal < 2.0D Then
                cellClr = Color.FromArgb(30, 74, 158, 255)
            ElseIf multVal < 2.5D Then
                cellClr = Color.FromArgb(35, 123, 97, 255)
            Else
                cellClr = Color.FromArgb(40, 245, 158, 11)
            End If

            Using br = New SolidBrush(cellClr)
                g.FillRectangle(br, e.CellBounds)
            End Using

            ' Draw value text
            Using f = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold)
            Using brT = New SolidBrush(Color.FromArgb(232, 236, 240))
                Dim sz = g.MeasureString(e.Value.ToString(), f)
                g.DrawString(e.Value.ToString(), f, brT,
                             e.CellBounds.X + (e.CellBounds.Width - sz.Width) / 2,
                             e.CellBounds.Y + (e.CellBounds.Height - sz.Height) / 2)
            End Using : End Using
        End If

        e.Handled = True
    End Sub

    Private Sub Matrix_CellClick(s As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex <= 0 Then Return
        Dim row = dgvMatrix.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return

        Dim jobName = row.Tag.ToString()
        Dim levelName = _levels(e.ColumnIndex - 1)

        ' Find matching record
        For Each r In _all
            If r.JobName = jobName AndAlso r.LevelName = levelName Then
                ShowTab(2)
                SelectItem(r.Id)
                Return
            End If
        Next

        ' No record → pre-fill new form
        ShowTab(2)
        NewItem()
        Dim jIdx = Array.IndexOf(_jobs, jobName)
        Dim lIdx = Array.IndexOf(_levels, levelName)
        If jIdx >= 0 Then cboFJob.SelectedIndex = jIdx + 1
        If lIdx >= 0 Then cboFLevel.SelectedIndex = lIdx + 1
        txtFCode.Text = "SM-" & (jIdx + 1).ToString("00") & "-LV" & (lIdx + 1).ToString("00")
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 2 — DETAIL
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderDetail(data As List(Of MultRow))
        dgvDetail.Rows.Clear()
        For Each r In data
            dgvDetail.Rows.Add(r.Code, r.JobName, r.LevelName,
                               r.Mult.ToString("0.0#"),
                               If(r.Status = 1, "● Đang dùng", "○ Ngừng"))
            Dim row = dgvDetail.Rows(dgvDetail.Rows.Count - 1)
            row.Tag = r.Id
            row.Cells("colStatus").Style.ForeColor = If(r.Status = 1,
                Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))

            ' Highlight by mult value
            Dim clr As Color
            If r.Mult < 1.0D Then
                clr = Color.FromArgb(123, 139, 178)
            ElseIf r.Mult < 1.5D Then
                clr = Color.FromArgb(76, 175, 80)
            ElseIf r.Mult < 2.0D Then
                clr = Color.FromArgb(74, 158, 255)
            ElseIf r.Mult < 2.5D Then
                clr = Color.FromArgb(123, 97, 255)
            Else
                clr = Color.FromArgb(245, 158, 11)
            End If
            row.Cells("colMult").Style.ForeColor = clr

            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next

        lblRowInfo.Text = String.Format("{0} hệ số  ·  {1} chức danh  ·  {2} cấp bậc",
                                         data.Count,
                                         data.Select(Function(x) x.JobName).Distinct().Count(),
                                         data.Select(Function(x) x.LevelName).Distinct().Count())

        dgvDetail.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id
        RenderDetail(_filtered)

        Dim r As MultRow = Nothing
        For Each x In _all
            If x.Id = id Then : r = x : Exit For
            End If
        Next
        If r.Id = 0 Then Return

        lblHdrTitle.Text = r.JobName & "  ×  " & r.LevelName
        lblHdrSub.Text = r.Code & "  ·  Hệ số: " & r.Mult.ToString("0.0#")

        txtFCode.Text = r.Code
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)

        Dim jIdx = Array.IndexOf(_jobs, r.JobName)
        Dim lIdx = Array.IndexOf(_levels, r.LevelName)
        cboFJob.SelectedIndex = If(jIdx >= 0, jIdx + 1, 0)
        cboFLevel.SelectedIndex = If(lIdx >= 0, lIdx + 1, 0)

        txtFMult.Text = r.Mult.ToString("0.0#")
        txtFNote.Text = r.Note
        UpdateMultPreview()
    End Sub

    Private Sub dgvDetail_CellClick(s As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellClick
        If e.RowIndex < 0 Then Return
        If dgvDetail.Rows(e.RowIndex).Tag IsNot Nothing Then
            SelectItem(CInt(dgvDetail.Rows(e.RowIndex).Tag))
        End If
    End Sub

    Private Sub cboDeptFilter_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboDeptFilter.SelectedIndexChanged
        ' Filter by dept — simplified: match job names containing dept keywords
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        _filtered = New List(Of MultRow)()
        For Each r In _all
            Dim match = dept = ""
            If Not match Then
                Select Case dept
                    Case "Kỹ thuật"
                        match = r.JobName.Contains("trình viên") OrElse r.JobName.Contains("Developer") OrElse
                                r.JobName.Contains("QA") OrElse r.JobName.Contains("DevOps") OrElse
                                r.JobName.Contains("Frontend")
                    Case "Kế toán"
                        match = r.JobName.Contains("Kế toán")
                    Case "Nhân sự"
                        match = r.JobName.Contains("NS")
                    Case "Kinh doanh"
                        match = r.JobName.Contains("Sales")
                    Case "Vận hành"
                        match = r.JobName.Contains("Ops")
                    Case Else
                        match = True
                End Select
            End If
            If match Then _filtered.Add(r)
        Next
        RenderMatrix()
        RenderDetail(_filtered)
    End Sub

    ' ── Mult live preview ─────────────────────────────────────
    Private Sub OnMultChanged(s As Object, e As EventArgs)
        UpdateMultPreview()
    End Sub

    Private Sub UpdateMultPreview()
        Dim mult As Decimal = 1D
        If Decimal.TryParse(txtFMult.Text.Trim(), mult) AndAlso mult > 0 Then
            Dim result = _sampleBase * mult
            lblMultPreviewVal.Text = String.Format("{0:N0} × {1} = {2:N0} đ",
                                                    _sampleBase, mult.ToString("0.0#"), result)
            lblMultPreviewVal.ForeColor = Color.FromArgb(76, 175, 80)
        Else
            lblMultPreviewVal.Text = "Nhập hệ số hợp lệ (VD: 1.5)"
            lblMultPreviewVal.ForeColor = Color.FromArgb(61, 74, 114)
        End If
    End Sub

    ' ── Toolbar buttons ───────────────────────────────────────
    Private Sub btnAdd_Click(s As Object, e As EventArgs) Handles btnAdd.Click
        ShowTab(2)
        NewItem()
    End Sub

    Private Sub btnExport_Click(s As Object, e As EventArgs) Handles btnExport.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp khi kết nối DB.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── Footer buttons ────────────────────────────────────────
    Private Sub btnSave_Click(s As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã hệ số.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus() : Return
        End If
        If cboFJob.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn chức danh.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFJob.Focus() : Return
        End If
        If cboFLevel.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn cấp bậc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFLevel.Focus() : Return
        End If
        Dim mult As Decimal = 0
        If Not Decimal.TryParse(txtFMult.Text.Trim(), mult) OrElse mult <= 0 Then
            MessageBox.Show("Hệ số phải là số thực dương. Ví dụ: 1.5",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFMult.Focus() : Return
        End If
        MessageBox.Show(String.Format("Đã lưu: {0}  ×  {1}  =  {2:0.0#}",
                                       cboFJob.SelectedItem, cboFLevel.SelectedItem, mult),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(s As Object, e As EventArgs) Handles btnClear.Click
        NewItem()
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim res = MessageBox.Show("Xóa hệ số lương này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1 : NewItem()
        End If
    End Sub

    ' ── Helpers ───────────────────────────────────────────────
    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear() : txtFNote.Clear()
        cboFJob.SelectedIndex = 0 : cboFLevel.SelectedIndex = 0
        cboFStatus.SelectedIndex = 0
        txtFMult.Text = "1.00"
        lblHdrTitle.Text = "Thêm hệ số lương mới"
        lblHdrSub.Text = "Chọn chức danh + cấp bậc → nhập hệ số"
        UpdateMultPreview()
        btnDelete.Enabled = False
        RenderDetail(_filtered)
        txtFCode.Focus()
    End Sub

    ' Tự động tạo mã khi đổi combo
    Private Sub cboFJob_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboFJob.SelectedIndexChanged
        AutoGenCode()
    End Sub

    Private Sub cboFLevel_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboFLevel.SelectedIndexChanged
        AutoGenCode()
    End Sub

    Private Sub AutoGenCode()
        If cboFJob.SelectedIndex > 0 AndAlso cboFLevel.SelectedIndex > 0 Then
            txtFCode.Text = "SM-" & cboFJob.SelectedIndex.ToString("00") &
                            "-LV" & cboFLevel.SelectedIndex.ToString("00")
            lblHdrTitle.Text = cboFJob.SelectedItem.ToString() &
                               "  ×  " & cboFLevel.SelectedItem.ToString()
            lblHdrSub.Text = txtFCode.Text
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnToolbarResize(s As Object, e As EventArgs)
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
        btnExport.Left = btnAdd.Left - btnExport.Width - 10
    End Sub

    Private Sub OnFootResize(s As Object, e As EventArgs)
        btnSave.Left = pnlFoot.Width - btnSave.Width - 14
        btnClear.Left = btnSave.Left - btnClear.Width - 10
    End Sub

    Private Sub OnLeftResize(s As Object, e As EventArgs)
        dgvDetail.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub OnTab1Resize(s As Object, e As EventArgs)
        dgvMatrix.Size = New Size(
            pnlTab1.Width,
            pnlTab1.Height - pnlMatrixHeader.Height)
    End Sub

    Private Sub OnMatrixHeaderResize(s As Object, e As EventArgs)
        lblLegend1.Left = pnlMatrixHeader.Width - lblLegend2.Width - lblLegend1.Width - 20
        lblLegend2.Left = pnlMatrixHeader.Width - lblLegend2.Width - 14
    End Sub

End Class