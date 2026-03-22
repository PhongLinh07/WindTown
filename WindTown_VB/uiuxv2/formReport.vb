Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text

Public Class formReport

    Private Enum ReportKind
        None = 0
        Attendance = 1
        Leave = 2
        Payroll = 3
        Project = 4
        Assignment = 5
    End Enum

    Private Class ReportRow
        Public Property Code As String
        Public Property Name As String
        Public Property Dept As String
        Public Property Score As String
        Public Property Status As String
        Public Property Note As String
    End Class

    Private _allRows As New List(Of ReportRow)()
    Private _displayRows As New List(Of ReportRow)()
    Private _chartValues As New List(Of Integer)()
    Private _chartLabels As New List(Of String)()

    Private _currentKind As ReportKind = ReportKind.None

    Private _btnExportCsv As Button

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPage.Visible = False
        InitFilters()
        InitTooltips()
        InitExportCsvButton()
        ApplyColumnLayout(ReportKind.Attendance)
        cboReportType.SelectedIndex = 1
        LoadReportFromDatabase()
        RefreshDepartmentFilter()
        BindKpisFromDisplay()
        RenderChart()
        If _displayRows.Count > 0 Then
            SelectRow(0)
        End If
    End Sub

    Private Sub InitFilters()
        cboReportType.Items.Clear()
        cboReportType.Items.Add("Chọn loại báo cáo")
        cboReportType.Items.AddRange(New Object() {"Chấm công", "Nghỉ phép", "Lương", "Dự án", "Phân công"})
        cboReportType.SelectedIndex = 0

        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.Add("Tất cả phòng ban")
        Dim rd = AppServices.Instance.DepartmentSV.GetList()
        If rd.IsSuccess AndAlso rd.Data IsNot Nothing Then
            For Each d In CType(rd.Data, List(Of Department)).OrderBy(Function(x) x.name)
                cboDeptFilter.Items.Add(d.name)
            Next
        End If
        cboDeptFilter.SelectedIndex = 0

        cboExportScope.Items.Clear()
        cboExportScope.Items.AddRange(New Object() {
            "Báo cáo hiện tại (màn hình này)",
            "Phạm vi: Chấm công",
            "Phạm vi: Nghỉ phép",
            "Phạm vi: Bảng lương",
            "Phạm vi: Dự án",
            "Phạm vi: Phân công"
        })
        cboExportScope.SelectedIndex = 0

        dtpFrom.Value = Date.Today.AddDays(-7)
        dtpTo.Value = Date.Today
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(cboReportType, "Bắt buộc")
        toolTip1.SetToolTip(dtpFrom, "Bắt buộc")
        toolTip1.SetToolTip(dtpTo, "Bắt buộc")
        toolTip1.SetToolTip(cboExportScope, "Chọn phạm vi xuất (ghi vào tên file / tiêu đề xuất)")
        toolTip1.SetToolTip(cboDeptFilter, "Lọc theo phòng ban (cột Phòng ban)")
    End Sub

    Private Sub InitExportCsvButton()
        _btnExportCsv = New Button() With {
            .Name = "btnExportCsv",
            .Text = "Xuất CSV",
            .Size = New Size(86, 30),
            .Anchor = btnExportExcel.Anchor,
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat,
            .Font = btnExportExcel.Font,
            .ForeColor = btnExportExcel.ForeColor,
            .BackColor = btnExportExcel.BackColor,
            .UseVisualStyleBackColor = False,
            .TabIndex = 7
        }
        _btnExportCsv.FlatAppearance.BorderColor = btnExportExcel.FlatAppearance.BorderColor
        _btnExportCsv.FlatAppearance.MouseOverBackColor = btnExportExcel.FlatAppearance.MouseOverBackColor
        _btnExportCsv.Left = btnExportExcel.Left - _btnExportCsv.Width - 10
        _btnExportCsv.Top = btnExportExcel.Top
        pnlToolbar.Controls.Add(_btnExportCsv)
        AddHandler _btnExportCsv.Click, Sub(s, ev) ExportReport("CSV")
        toolTip1.SetToolTip(_btnExportCsv, "Xuất lưới hiện tại ra CSV UTF-8 (dấu ;)")
    End Sub

    Private Function MapComboToKind(idx As Integer) As ReportKind
        Select Case idx
            Case 1 : Return ReportKind.Attendance
            Case 2 : Return ReportKind.Leave
            Case 3 : Return ReportKind.Payroll
            Case 4 : Return ReportKind.Project
            Case 5 : Return ReportKind.Assignment
            Case Else : Return ReportKind.None
        End Select
    End Function

    Private Sub ApplyColumnLayout(kind As ReportKind)
        Select Case kind
            Case ReportKind.Attendance
                colCode.HeaderText = "Mã"
                colName.HeaderText = "Nhân viên"
                colDept.HeaderText = "Phòng ban"
                colScore.HeaderText = "Ngày"
                colStatus.HeaderText = "Trạng thái"
            Case ReportKind.Leave
                colCode.HeaderText = "Mã"
                colName.HeaderText = "Nhân viên"
                colDept.HeaderText = "Loại nghỉ"
                colScore.HeaderText = "Từ — Đến"
                colStatus.HeaderText = "Trạng thái"
            Case ReportKind.Payroll
                colCode.HeaderText = "Mã bảng lương"
                colName.HeaderText = "Nhân viên"
                colDept.HeaderText = "Phòng ban"
                colScore.HeaderText = "Kỳ lương"
                colStatus.HeaderText = "Trạng thái"
            Case ReportKind.Project
                colCode.HeaderText = "Mã dự án"
                colName.HeaderText = "Tên dự án"
                colDept.HeaderText = "Thời gian"
                colScore.HeaderText = "Bắt đầu"
                colStatus.HeaderText = "Kết thúc"
            Case ReportKind.Assignment
                colCode.HeaderText = "Mã PC"
                colName.HeaderText = "Dự án"
                colDept.HeaderText = "Vị trí"
                colScore.HeaderText = "Nhân sự"
                colStatus.HeaderText = "Trạng thái"
            Case Else
                colCode.HeaderText = "Mã"
                colName.HeaderText = "Tên"
                colDept.HeaderText = "Phòng ban"
                colScore.HeaderText = "Giá trị"
                colStatus.HeaderText = "Trạng thái"
        End Select
    End Sub

    Private Sub LoadReportFromDatabase()
        _allRows.Clear()
        _currentKind = MapComboToKind(cboReportType.SelectedIndex)
        ApplyColumnLayout(_currentKind)

        Dim d0 = dtpFrom.Value.Date
        Dim d1 = dtpTo.Value.Date

        Select Case _currentKind
            Case ReportKind.Attendance
                Dim res = AppServices.Instance.AttendanceSV.GetList()
                If res.IsSuccess AndAlso res.Data IsNot Nothing Then
                    For Each a In CType(res.Data, List(Of Attendance))
                        Dim od = a.of_date.Date
                        If od < d0 OrElse od > d1 Then Continue For
                        _allRows.Add(New ReportRow With {
                            .Code = If(a.code, ""),
                            .Name = If(a.Employee?.name, "---"),
                            .Dept = "---",
                            .Score = od.ToString("dd/MM/yyyy"),
                            .Status = If(a.status_UI, ""),
                            .Note = If(a.note, "")
                        })
                    Next
                End If

            Case ReportKind.Leave
                Dim res = AppServices.Instance.LeaveSV.GetList()
                If res.IsSuccess AndAlso res.Data IsNot Nothing Then
                    For Each lv In CType(res.Data, List(Of Leave))
                        Dim s = lv.start_date.Date
                        Dim span = Math.Max(0, CInt(Math.Ceiling(CDbl(lv.total_days)))) - 1
                        Dim en = s.AddDays(span)
                        If en < d0 OrElse s > d1 Then Continue For
                        _allRows.Add(New ReportRow With {
                            .Code = If(lv.code, ""),
                            .Name = If(lv.Employee?.name, "---"),
                            .Dept = If(lv.Leave_Cat?.name, "---"),
                            .Score = s.ToString("dd/MM") & " — " & en.ToString("dd/MM/yyyy"),
                            .Status = If(lv.status_UI, ""),
                            .Note = If(lv.note, "")
                        })
                    Next
                End If

            Case ReportKind.Payroll
                Dim res = AppServices.Instance.PayrollSV.GetList()
                If res.IsSuccess AndAlso res.Data IsNot Nothing Then
                    For Each p In CType(res.Data, List(Of Payroll))
                        Dim pdStart = If(p.Pay_Period?.start_date, Date.MinValue).Date
                        Dim pdEnd = If(p.Pay_Period?.end_date, Date.MaxValue).Date
                        If pdEnd < d0 OrElse pdStart > d1 Then Continue For
                        _allRows.Add(New ReportRow With {
                            .Code = If(p.code, ""),
                            .Name = If(p.employee_UI, "---"),
                            .Dept = If(p.Position?.Salary_Mult?.Job?.Department?.name, "---"),
                            .Score = If(p.pay_period_UI, "---"),
                            .Status = If(p.status_UI, ""),
                            .Note = If(p.note, "")
                        })
                    Next
                End If

            Case ReportKind.Project
                Dim res = AppServices.Instance.ProjectSV.GetList()
                If res.IsSuccess AndAlso res.Data IsNot Nothing Then
                    For Each pr In CType(res.Data, List(Of Project))
                        Dim ps = pr.start_date.Date
                        Dim pe = pr.end_date.Date
                        If pe < d0 OrElse ps > d1 Then Continue For
                        _allRows.Add(New ReportRow With {
                            .Code = If(pr.code, ""),
                            .Name = If(pr.name, ""),
                            .Dept = ps.ToString("dd/MM/yyyy") & " — " & pe.ToString("dd/MM/yyyy"),
                            .Score = ps.ToString("dd/MM/yyyy"),
                            .Status = pe.ToString("dd/MM/yyyy"),
                            .Note = If(pr.note, "")
                        })
                    Next
                End If

            Case ReportKind.Assignment
                Dim res = AppServices.Instance.AssigmentSV.GetList()
                If res.IsSuccess AndAlso res.Data IsNot Nothing Then
                    For Each asn In CType(res.Data, List(Of Assignment))
                        _allRows.Add(New ReportRow With {
                            .Code = If(asn.code, ""),
                            .Name = If(asn.Project?.name, "---"),
                            .Dept = If(asn.Position?.code, "---"),
                            .Score = If(asn.Position?.employee_UI, "---"),
                            .Status = If(asn.status_UI, ""),
                            .Note = If(asn.note, "")
                        })
                    Next
                End If
        End Select

        BuildChartFromRows()
        RefreshDepartmentFilter()
        BindKpisFromDisplay()
        RenderChart()
        If _displayRows.Count > 0 Then
            SelectRow(0)
        Else
            ClearDetail()
        End If
    End Sub

    Private Sub BuildChartFromRows()
        _chartValues.Clear()
        _chartLabels.Clear()
        If _currentKind = ReportKind.Attendance AndAlso _allRows.Count > 0 Then
            Dim groups = _allRows.GroupBy(Function(r) r.Score).OrderBy(Function(g) g.Key).Take(12).ToList()
            For Each g In groups
                _chartLabels.Add(g.Key)
                _chartValues.Add(Math.Min(100, g.Count() * 8 + 20))
            Next
        End If
        If _chartValues.Count = 0 Then
            _chartLabels = New List(Of String) From {"1", "2", "3", "4", "5", "6", "7"}
            _chartValues = New List(Of Integer) From {10, 20, 15, 25, 18, 30, 22}
        End If
    End Sub

    Private Sub RefreshDepartmentFilter()
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, Nothing, cboDeptFilter.SelectedItem.ToString())
        _displayRows = _allRows.Where(Function(r) dept Is Nothing OrElse r.Dept = dept).ToList()
        BindTable(_displayRows)
    End Sub

    Private Sub BindKpisFromDisplay()
        lblKpi1Value.Text = _displayRows.Count.ToString()
        lblKpi2Value.Text = If(_allRows.Count > 0, Math.Min(100, CInt(100 * _displayRows.Count / Math.Max(1, _allRows.Count))).ToString() & "%", "—")
        lblKpi3Value.Text = _allRows.Select(Function(r) r.Dept).Distinct().Count().ToString()
        lblKpi4Value.Text = If(_currentKind = ReportKind.Payroll,
                              _displayRows.Count.ToString() & " bản ghi",
                              "—")
    End Sub

    Private Sub BindTable(data As List(Of ReportRow))
        dgvReport.Rows.Clear()
        For Each item In data
            dgvReport.Rows.Add(item.Code, item.Name, item.Dept, item.Score, item.Status)
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count} / {_allRows.Count} mục · Phân trang: tắt"
    End Sub

    Private Sub RenderChart()
        flpChart.Controls.Clear()
        Dim chartHeight As Integer = 160
        Dim maxV = If(_chartValues.Count > 0, _chartValues.Max(), 1)
        maxV = Math.Max(maxV, 1)
        For i As Integer = 0 To _chartValues.Count - 1
            Dim value = _chartValues(i)
            Dim labelText = If(i < _chartLabels.Count, _chartLabels(i), $"T{i + 1}")

            Dim item As New Panel()
            item.Width = 46
            item.Height = chartHeight + 18
            item.Margin = New Padding(6, 0, 6, 0)
            item.BackColor = Color.Transparent

            Dim barH = CInt(Math.Round(chartHeight * (value / CDbl(maxV))))
            barH = Math.Min(chartHeight, Math.Max(8, barH))

            Dim bar As New Panel()
            bar.Width = 36
            bar.Height = barH
            bar.BackColor = Color.FromArgb(40, 74, 158, 255)
            bar.BorderStyle = BorderStyle.FixedSingle
            bar.Left = 5
            bar.Top = item.Height - 18 - bar.Height

            Dim lblValue As New Label()
            lblValue.Text = value.ToString()
            lblValue.AutoSize = True
            lblValue.ForeColor = Color.FromArgb(232, 236, 240)
            lblValue.Font = New Font("Microsoft YaHei UI", 7.5F, FontStyle.Regular)
            lblValue.Location = New Point(6, bar.Top + 4)

            Dim lblAxis As New Label()
            lblAxis.Text = labelText
            lblAxis.TextAlign = ContentAlignment.MiddleCenter
            lblAxis.ForeColor = Color.FromArgb(123, 139, 178)
            lblAxis.Font = New Font("Microsoft YaHei UI", 7.5F, FontStyle.Regular)
            lblAxis.AutoSize = False
            lblAxis.Width = item.Width
            lblAxis.Height = 16
            lblAxis.Left = 0
            lblAxis.Top = item.Height - 16

            item.Controls.Add(bar)
            item.Controls.Add(lblValue)
            item.Controls.Add(lblAxis)
            flpChart.Controls.Add(item)
        Next
    End Sub

    Private Sub SelectRow(index As Integer)
        If index < 0 OrElse index >= _displayRows.Count Then
            ClearDetail()
            Return
        End If

        Dim item = _displayRows(index)
        txtDetailCode.Text = item.Code
        txtDetailName.Text = item.Name
        txtDetailDept.Text = item.Dept
        txtDetailScore.Text = item.Score
        txtDetailStatus.Text = item.Status
        txtDetailNote.Text = item.Note
    End Sub

    Private Sub ClearDetail()
        txtDetailCode.Text = ""
        txtDetailName.Text = ""
        txtDetailDept.Text = ""
        txtDetailScore.Text = ""
        txtDetailStatus.Text = ""
        txtDetailNote.Text = ""
    End Sub

    Private Sub dgvReport_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvReport.Rows.Count Then Return
        SelectRow(e.RowIndex)
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged
        ResetValidation()
    End Sub

    Private Sub cboDeptFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDeptFilter.SelectedIndexChanged
        RefreshDepartmentFilter()
        BindKpisFromDisplay()
        If _displayRows.Count > 0 Then
            SelectRow(0)
        Else
            ClearDetail()
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        ResetValidation()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        ResetValidation()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cboReportType.SelectedIndex = 0
        cboDeptFilter.SelectedIndex = 0
        cboExportScope.SelectedIndex = 0
        dtpFrom.Value = Date.Today.AddDays(-7)
        dtpTo.Value = Date.Today
        lblError.Visible = False
        ResetValidation()
        _allRows.Clear()
        _displayRows.Clear()
        BindTable(_displayRows)
        ClearDetail()
        BindKpisFromDisplay()
        RenderChart()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If Not ValidateRequired() Then
            lblError.Visible = True
            Return
        End If
        lblError.Visible = False
        LoadReportFromDatabase()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportReport("Excel")
    End Sub

    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        ExportReport("PDF")
    End Sub

    Private Sub ExportReport(format As String)
        Dim suffix = ExportScopeSuffix()
        Select Case format
            Case "Excel"
                If dgvReport.Rows.Count = 0 Then
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất.", "Xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                BaoCaoXuat.XuatTuDataGridView(dgvReport, "WindTown_report_" & suffix)
            Case "CSV"
                ExportCurrentGridToCsv(suffix)
            Case "PDF"
                ExportCurrentGridToPdf(suffix)
            Case Else
                MessageBox.Show("Định dạng không hỗ trợ.", "Xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
    End Sub

    Private Function ExportScopeSuffix() As String
        Dim idx = cboExportScope.SelectedIndex
        Select Case idx
            Case 1 : Return "cham_cong"
            Case 2 : Return "nghi_phep"
            Case 3 : Return "bang_luong"
            Case 4 : Return "du_an"
            Case 5 : Return "phan_cong"
            Case Else : Return "man_hinh"
        End Select
    End Function

    Private Sub ExportCurrentGridToPdf(scopeSuffix As String)
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu trên lưới để xuất.", "Xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using dlg As New SaveFileDialog()
            dlg.Title = "Lưu PDF"
            dlg.Filter = "PDF (*.pdf)|*.pdf"
            dlg.FileName = "WindTown_report_" & scopeSuffix & "_" & Date.Now.ToString("yyyyMMdd_HHmm")
            dlg.DefaultExt = "pdf"
            dlg.AddExtension = True
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            Dim t = "WindTown — " & If(cboReportType.SelectedItem Is Nothing, "Báo cáo", cboReportType.SelectedItem.ToString())
            ReportPdfExport.ExportDataGridViewToPdf(dgvReport, dlg.FileName, t, Me)
        End Using
    End Sub

    Private Sub ExportCurrentGridToCsv(scopeSuffix As String)
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu trên lưới để xuất.", "Xuất CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using dlg As New SaveFileDialog()
            dlg.Title = "Lưu CSV"
            dlg.Filter = "CSV UTF-8 (*.csv)|*.csv"
            dlg.FileName = "WindTown_report_" & scopeSuffix & "_" & Date.Now.ToString("yyyyMMdd_HHmm")
            dlg.DefaultExt = "csv"
            dlg.AddExtension = True
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Dim sep = ";"c
            Using sw As New StreamWriter(dlg.FileName, False, New UTF8Encoding(True))
                Dim headers = dgvReport.Columns.Cast(Of DataGridViewColumn)().
                    Where(Function(c) c.Visible).
                    Select(Function(c) CsvEscape(c.HeaderText, sep)).
                    ToList()
                sw.WriteLine(String.Join(sep, headers))

                For Each row As DataGridViewRow In dgvReport.Rows
                    If row.IsNewRow Then Continue For
                    Dim cells = dgvReport.Columns.Cast(Of DataGridViewColumn)().
                        Where(Function(c) c.Visible).
                        Select(Function(c) CsvEscape(If(row.Cells(c.Index).Value, String.Empty).ToString(), sep)).
                        ToList()
                    sw.WriteLine(String.Join(sep, cells))
                Next
            End Using

            MessageBox.Show("Đã lưu: " & dlg.FileName, "Xuất CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Shared Function CsvEscape(value As String, sep As Char) As String
        If value Is Nothing Then value = String.Empty
        Dim needQuote = value.IndexOfAny(New Char() {sep, """"c, ControlChars.Cr, ControlChars.Lf, ControlChars.Tab}) >= 0
        value = value.Replace("""", """""")
        If needQuote Then
            Return """" & value & """"
        End If
        Return value
    End Function

    Private Function ValidateRequired() As Boolean
        ResetValidation()
        Dim invalid As Boolean = False

        If cboReportType.SelectedIndex <= 0 Then
            SetInvalid(cboReportType, True)
            invalid = True
        End If

        If dtpFrom.Value > dtpTo.Value Then
            SetInvalid(dtpFrom, True)
            SetInvalid(dtpTo, True)
            invalid = True
        End If

        Return Not invalid
    End Function

    Private Sub ResetValidation()
        SetInvalid(cboReportType, False)
        SetInvalid(dtpFrom, False)
        SetInvalid(dtpTo, False)
    End Sub

    Private Sub SetInvalid(ctrl As Control, isInvalid As Boolean)
        If TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is TextBox Then
            ctrl.BackColor = If(isInvalid, _invalidBack, _inputBack)
        ElseIf TypeOf ctrl Is DateTimePicker Then
            Dim dtp = CType(ctrl, DateTimePicker)
            dtp.CalendarMonthBackground = If(isInvalid, _invalidBack, _inputBack)
            dtp.BackColor = If(isInvalid, _invalidBack, _inputBack)
        End If
    End Sub
End Class
