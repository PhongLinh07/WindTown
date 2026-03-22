Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

' ============================================================
'  formSalaryMult.vb — Hệ số lương  (.NET 8 · DB qua Salary_MultSV)
' ============================================================
Public Class formSalaryMult

    Private Class IdNameItem
        Public Id As Integer
        Public Caption As String
        Public Sub New(id As Integer, caption As String)
            Me.Id = id
            Me.Caption = caption
        End Sub
        Public Overrides Function ToString() As String
            Return Caption
        End Function
    End Class

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

    Private ReadOnly _salaryMultSv = AppServices.Instance.Salary_MultSV
    Private ReadOnly _jobSv = AppServices.Instance.JobSV
    Private ReadOnly _levelSv = AppServices.Instance.LevelSV
    Private ReadOnly _deptSv = AppServices.Instance.DepartmentSV

    Private _jobsList As New List(Of Job)()
    Private _levelsOrdered As New List(Of Level)()
    Private _levels() As String = {}
    Private _levelRanks() As Integer = {}

    Private _all As New List(Of MultRow)()
    Private _filtered As New List(Of MultRow)()
    Private _selId As Integer = -1
    Private _sampleBase As Decimal = 15000000D

    Private Sub formSalaryMult_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        UiTextBoxHints.SetCueBanner(txtFCode, "SM-JOB01-LV02")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú hệ số...")

        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        AddHandler pnlTab1.Resize, AddressOf OnTab1Resize
        AddHandler pnlMatrixHeader.Resize, AddressOf OnMatrixHeaderResize
        AddHandler txtFMult.TextChanged, AddressOf OnMultChanged
        AddHandler dgvMatrix.CellClick, AddressOf Matrix_CellClick

        RefreshMasterData()
        LoadFromDb()
        _filtered = New List(Of MultRow)(_all)

        BuildMatrixColumns()
        RenderMatrix()
        RenderDetail(_filtered)

        If _all.Count > 0 Then SelectItem(_all(0).Id)

        ShowTab(1)
    End Sub

    Private Sub RefreshMasterData()
        Dim jr = _jobSv.GetList()
        _jobsList = If(jr.IsSuccess,
                       CType(jr.Data, IEnumerable(Of Job)).ToList(),
                       New List(Of Job)())

        Dim lr = _levelSv.GetList()
        If lr.IsSuccess Then
            _levelsOrdered = CType(lr.Data, IEnumerable(Of Level)).OrderBy(Function(x) x.rank).ToList()
        Else
            _levelsOrdered = New List(Of Level)()
        End If
        _levels = _levelsOrdered.Select(Function(x) x.name).ToArray()
        _levelRanks = _levelsOrdered.Select(Function(x) x.rank).ToArray()

        cboFJob.Items.Clear()
        cboFJob.Items.Add(New IdNameItem(0, "— Chọn chức danh —"))
        For Each j In _jobsList.OrderBy(Function(x) x.name)
            cboFJob.Items.Add(New IdNameItem(j.id, j.name))
        Next
        cboFJob.SelectedIndex = 0

        cboFLevel.Items.Clear()
        cboFLevel.Items.Add(New IdNameItem(0, "— Chọn cấp bậc —"))
        For Each lv In _levelsOrdered
            cboFLevel.Items.Add(New IdNameItem(lv.id, lv.name))
        Next
        cboFLevel.SelectedIndex = 0

        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.Add("Tất cả phòng ban")
        Dim dr = _deptSv.GetList()
        If dr.IsSuccess Then
            For Each d In CType(dr.Data, IEnumerable(Of Department)).OrderBy(Function(x) x.name)
                cboDeptFilter.Items.Add(d.name)
            Next
        End If
        cboDeptFilter.SelectedIndex = 0
    End Sub

    Private Function MapToMultRow(sm As Salary_Mult) As MultRow
        Dim r As New MultRow()
        r.Id = sm.id
        r.JobId = sm.job_id
        r.LevelId = sm.level_id
        r.JobName = If(sm.Job IsNot Nothing, sm.Job.name, "?")
        r.LevelName = If(sm.Level IsNot Nothing, sm.Level.name, "?")
        r.LevelRank = If(sm.Level IsNot Nothing, sm.Level.rank, 0)
        r.Mult = sm.mult
        r.Code = "SM-" & sm.job_id.ToString("00") & "-L" & sm.level_id.ToString("00")
        r.Note = sm.note
        r.Status = sm.status
        Return r
    End Function

    Private Sub LoadFromDb()
        _all.Clear()
        Dim res = _salaryMultSv.GetList()
        If Not res.IsSuccess Then
            MessageBox.Show(res.Message, "Lỗi tải hệ số lương", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        For Each sm In CType(res.Data, IEnumerable(Of Salary_Mult))
            _all.Add(MapToMultRow(sm))
        Next
    End Sub

    Private Sub ReloadAfterSave()
        RefreshMasterData()
        LoadFromDb()
        _filtered = New List(Of MultRow)(_all)
        BuildMatrixColumns()
        RenderMatrix()
        RenderDetail(_filtered)
        If _selId > 0 AndAlso _all.Any(Function(x) x.Id = _selId) Then
            SelectItem(_selId)
        ElseIf _all.Count > 0 Then
            SelectItem(_all(0).Id)
        Else
            NewItem()
        End If
    End Sub

    Private Function ExistsPair(jobId As Integer, levelId As Integer, excludeMultId As Integer) As Boolean
        Return _all.Any(Function(x) x.JobId = jobId AndAlso x.LevelId = levelId AndAlso x.Id <> excludeMultId)
    End Function

    Private Sub SetComboById(cbo As ComboBox, entityId As Integer)
        For i = 0 To cbo.Items.Count - 1
            Dim it = TryCast(cbo.Items(i), IdNameItem)
            If it IsNot Nothing AndAlso it.Id = entityId Then
                cbo.SelectedIndex = i
                Return
            End If
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

        If _levels Is Nothing OrElse _levels.Length = 0 Then Return

        ' Add one column per level (ordered by rank)
        Dim lvIdx As Integer
        For lvIdx = 0 To _levels.Length - 1
            Dim col As New DataGridViewTextBoxColumn()
            col.HeaderText = _levels(lvIdx) & vbCrLf & "(Rank " & _levelRanks(lvIdx) & ")"
            col.Name = "colLv" & (lvIdx + 1).ToString()
            col.Width = 110
            col.ReadOnly = True
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            col.DefaultCellStyle.Font = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
            dgvMatrix.Columns.Add(col)
        Next
    End Sub

    Private Sub RenderMatrix()
        dgvMatrix.Rows.Clear()
        If _levels Is Nothing OrElse _levels.Length = 0 Then Return

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
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
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
        If e.ColumnIndex - 1 < 0 OrElse e.ColumnIndex - 1 >= _levels.Length Then Return
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
        Dim jOb = _jobsList.FirstOrDefault(Function(j) j.name = jobName)
        Dim lOb = _levelsOrdered.FirstOrDefault(Function(l) l.name = levelName)
        If jOb IsNot Nothing Then SetComboById(cboFJob, jOb.id)
        If lOb IsNot Nothing Then SetComboById(cboFLevel, lOb.id)
        If jOb IsNot Nothing AndAlso lOb IsNot Nothing Then
            txtFCode.Text = "SM-" & jOb.id.ToString("00") & "-L" & lOb.id.ToString("00")
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 2 — DETAIL
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderDetail(data As List(Of MultRow))
        dgvDetail.Rows.Clear()
        For Each r In data
            dgvDetail.Rows.Add(r.Code, r.JobName, r.LevelName,
                               r.Mult.ToString("0.0#"),
                               If(r.Status = 1, "Đang dùng", "Ngừng"))
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
        Dim found As Boolean = False
        For Each x In _all
            If x.Id = id Then r = x : found = True : Exit For
        Next
        If Not found Then Return

        lblHdrTitle.Text = r.JobName & "  ×  " & r.LevelName
        lblHdrSub.Text = r.Code & "  ·  Hệ số: " & r.Mult.ToString("0.0#")

        txtFCode.Text = r.Code
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)

        SetComboById(cboFJob, r.JobId)
        SetComboById(cboFLevel, r.LevelId)

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
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        _filtered = New List(Of MultRow)()
        For Each r In _all
            Dim match = dept = ""
            If Not match Then
                Dim j = _jobsList.FirstOrDefault(Function(x) x.id = r.JobId)
                Dim dn = If(j IsNot Nothing AndAlso j.Department IsNot Nothing, j.Department.name, "")
                match = (dn = dept)
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
        MessageBox.Show("Tính năng xuất Excel (dự kiến).",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── Footer buttons ────────────────────────────────────────
    Private Sub btnSave_Click(s As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã hiển thị (hoặc chọn job + level để tự sinh).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        Dim ji = TryCast(cboFJob.SelectedItem, IdNameItem)
        Dim li = TryCast(cboFLevel.SelectedItem, IdNameItem)
        If ji Is Nothing OrElse li Is Nothing OrElse ji.Id <= 0 OrElse li.Id <= 0 Then Return

        Dim mult As Decimal = 0
        If Not Decimal.TryParse(txtFMult.Text.Trim(), mult) OrElse mult <= 0 Then
            MessageBox.Show("Hệ số phải là số thực dương. Ví dụ: 1.5",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFMult.Focus() : Return
        End If

        If _selId <= 0 Then
            If ExistsPair(ji.Id, li.Id, 0) Then
                MessageBox.Show("Đã tồn tại hệ số cho cặp chức danh + cấp bậc này.", "Trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim sm As New Salary_Mult()
            sm.job_id = ji.Id
            sm.level_id = li.Id
            sm.mult = mult
            sm.note = txtFNote.Text.Trim()
            sm.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _salaryMultSv.Insert(sm)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã thêm hệ số.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _selId = sm.id
                ReloadAfterSave()
            Else
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If ExistsPair(ji.Id, li.Id, _selId) Then
                MessageBox.Show("Đã tồn tại hệ số cho cặp chức danh + cấp bậc này.", "Trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim existing As New Salary_Mult()
            existing.id = _selId
            existing.job_id = ji.Id
            existing.level_id = li.Id
            existing.mult = mult
            existing.note = txtFNote.Text.Trim()
            existing.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _salaryMultSv.Update(existing)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã cập nhật hệ số.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ReloadAfterSave()
            Else
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnClear_Click(s As Object, e As EventArgs) Handles btnClear.Click
        NewItem()
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        If Not _all.Any(Function(x) x.Id = _selId) Then Return
        Dim ask = MessageBox.Show("Ngừng sử dụng hệ số lương này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ask <> DialogResult.Yes Then Return
        Dim sm As New Salary_Mult()
        sm.id = _selId
        Dim res = _salaryMultSv.Delete(New List(Of Salary_Mult) From {sm})
        If res.IsSuccess Then
            MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã xóa.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1
            ReloadAfterSave()
        Else
            MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Dim ji = TryCast(cboFJob.SelectedItem, IdNameItem)
        Dim li = TryCast(cboFLevel.SelectedItem, IdNameItem)
        If ji IsNot Nothing AndAlso li IsNot Nothing AndAlso ji.Id > 0 AndAlso li.Id > 0 Then
            txtFCode.Text = "SM-" & ji.Id.ToString("00") & "-L" & li.Id.ToString("00")
            lblHdrTitle.Text = ji.Caption & "  ×  " & li.Caption
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