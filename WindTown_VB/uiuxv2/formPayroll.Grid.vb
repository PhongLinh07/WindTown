Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

Partial Public Class formPayroll
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 2 — BẢNG LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPayrollTable(data As List(Of PayrollRow))
        dgvPayroll.Rows.Clear()

        For Each p In data
            dgvPayroll.Rows.Add(
                False,
                p.EmpName,
                p.Dept,
                p.Job,
                FmtM(p.BaseSalary),
                "+" & FmtM(p.TotalIncome),
                "-" & FmtM(p.TotalDeduct),
                FmtM(p.NetSalary),
                If(p.IsDone, "Đã tính", "Chờ xử lý"),
                "Xem →")

            Dim row = dgvPayroll.Rows(dgvPayroll.Rows.Count - 1)
            row.Tag = p.Id

            If p.IsDone Then
                row.Cells("colPayStatus").Style.ForeColor = Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colPayStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
            End If
        Next

        ' Update summary chips
        Dim totalIncome = data.Where(Function(x) x.IsDone).Sum(Function(x) x.TotalIncome)
        Dim totalDeduct = data.Where(Function(x) x.IsDone).Sum(Function(x) x.TotalDeduct)
        Dim totalNet = data.Where(Function(x) x.IsDone).Sum(Function(x) x.NetSalary)

        lblChipIncome.Text = "  Thu nhập:  " & FmtM(totalIncome) & "  "
        lblChipDeduct.Text = "  Khấu trừ:  -" & FmtM(totalDeduct) & "  "
        lblChipNet.Text = "  Thực lãnh:  " & FmtM(totalNet) & "  "
        lblChipIncome.ForeColor = Color.FromArgb(76, 175, 80)
        lblChipDeduct.ForeColor = Color.FromArgb(240, 128, 128)
        lblChipNet.ForeColor = Color.FromArgb(74, 158, 255)

        Dim doneCount As Integer = data.Where(Function(x) x.IsDone).Count()
        lblPayInfo.Text = String.Format("Hiển thị {0} / {1} nhân viên · {2} đã tính",
                                         data.Count,
                                         _allPayrolls.Count,
                                         doneCount)

        dgvPayroll.Size = New Size(
            pnlTab2.Width,
            pnlTab2.Height - pnlPayrollHeader.Height - pnlPayFooter.Height)
    End Sub

    ' ── DGV CellPaint — avatar circle in EmpName column ──────
    Private Sub dgvPayroll_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvPayroll.CellPainting
        If e.ColumnIndex <> dgvPayroll.Columns("colEmpName").Index OrElse e.RowIndex < 0 Then Return

        e.PaintBackground(e.ClipBounds, True)

        Dim row = dgvPayroll.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim empId = CInt(row.Tag)
        Dim pr = _allPayrolls.FirstOrDefault(Function(x) x.Id = empId)
        If pr.Id = 0 Then Return

        Dim g = e.Graphics
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim sz = 34
        Dim ax = e.CellBounds.X + 8
        Dim ay = e.CellBounds.Y + (e.CellBounds.Height - sz) \ 2

        Using br = New SolidBrush(pr.AvatarColor)
            g.FillEllipse(br, ax, ay, sz, sz)
        End Using
        Using f = New Font("Microsoft YaHei UI", 10!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim ini = GetInitials(pr.EmpName)
                Dim s = g.MeasureString(ini, f)
                g.DrawString(ini, f, br, ax + (sz - s.Width) / 2, ay + (sz - s.Height) / 2)
            End Using : End Using

        ' Draw employee name to the right of avatar
        Using f = New Font("Microsoft YaHei UI", 10!, FontStyle.Bold)
            Using br = New SolidBrush(Color.FromArgb(232, 236, 240))
                g.DrawString(pr.EmpName, f, CType(br, Brush), CSng(ax + sz + 8), CSng(e.CellBounds.Y + (e.CellBounds.Height - f.Height) / 2))
            End Using : End Using

        e.Handled = True
    End Sub

    Private Sub dgvPayroll_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPayroll.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvPayroll.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim id = CInt(row.Tag)
        SelectEmployee(id)
        If e.ColumnIndex = dgvPayroll.Columns("colView").Index Then
            ShowTab(3)
        End If
    End Sub

    ' ── Toolbar filter ────────────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDept.SelectedIndex <= 0, "", cboDept.SelectedItem.ToString())

        _filteredPayrolls = New List(Of PayrollRow)()
        For Each p In _allPayrolls
            Dim mQ = q = "" OrElse p.EmpName.ToLower().Contains(q) OrElse p.EmpCode.ToLower().Contains(q)
            Dim mD = dept = "" OrElse p.Dept = dept
            If mQ AndAlso mD Then _filteredPayrolls.Add(p)
        Next
        RenderPayrollTable(_filteredPayrolls)
    End Sub

    Private Sub cboPeriodSel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriodSel.SelectedIndexChanged
        ' Switch period (mock: just update badge)
        If cboPeriodSel.SelectedIndex < _allPeriods.Count Then
            Dim p = _allPeriods(cboPeriodSel.SelectedIndex)
            lblPayPeriodBadge.Text = p.Code & "  —  " & p.Name
        End If
    End Sub
End Class
