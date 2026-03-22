Imports System.Drawing

Public Class formReport
    Private Class ReportRow
        Public Property Code As String
        Public Property Name As String
        Public Property Dept As String
        Public Property Score As String
        Public Property Status As String
        Public Property Note As String
    End Class

    Private _rows As List(Of ReportRow)
    Private _chartValues As List(Of Integer)
    Private _chartLabels As List(Of String)

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMockData()
        InitFilters()
        InitTooltips()
        BindKpis()
        BindTable(_rows)
        RenderChart()
        If _rows.Count > 0 Then
            SelectRow(0)
        End If
    End Sub

    Private Sub InitMockData()
        _rows = New List(Of ReportRow) From {
            New ReportRow With {.Code = "ATD-0001", .Name = "Nguyễn Văn An", .Dept = "Kỹ thuật", .Score = "98%", .Status = "Tốt", .Note = "Không có"},
            New ReportRow With {.Code = "ATD-0002", .Name = "Trần Thị Bình", .Dept = "Kế toán", .Score = "95%", .Status = "Tốt", .Note = "Không có"},
            New ReportRow With {.Code = "ATD-0003", .Name = "Phạm Thị Dung", .Dept = "Marketing", .Score = "93%", .Status = "Ổn", .Note = "Cần theo dõi"},
            New ReportRow With {.Code = "ATD-0004", .Name = "Hoàng Văn Em", .Dept = "Kỹ thuật", .Score = "92%", .Status = "Ổn", .Note = "Không có"}
        }
        _chartValues = New List(Of Integer) From {60, 72, 68, 80, 74, 88, 83}
        _chartLabels = New List(Of String) From {"T1", "T2", "T3", "T4", "T5", "T6", "T7"}
    End Sub

    Private Sub InitFilters()
        cboReportType.Items.Clear()
        cboReportType.Items.Add("Chọn loại báo cáo")
        cboReportType.Items.AddRange(New Object() {"Chấm công", "Nghỉ phép", "Lương", "Dự án", "Phân công"})
        cboReportType.SelectedIndex = 0

        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Marketing", "Nhân sự"})
        cboDeptFilter.SelectedIndex = 0

        cboExportScope.Items.Clear()
        cboExportScope.Items.AddRange(New Object() {"Xuất từ report", "formAttendance", "formLeave", "formPayroll", "formProject", "formAssignment"})
        cboExportScope.SelectedIndex = 0

        dtpFrom.Value = Date.Today.AddDays(-7)
        dtpTo.Value = Date.Today
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(cboReportType, "Bắt buộc")
        toolTip1.SetToolTip(dtpFrom, "Bắt buộc")
        toolTip1.SetToolTip(dtpTo, "Bắt buộc")
        toolTip1.SetToolTip(cboExportScope, "Chọn phạm vi xuất")
    End Sub

    Private Sub BindKpis()
        lblKpi1Value.Text = "230"
        lblKpi2Value.Text = "92%"
        lblKpi3Value.Text = "18"
        lblKpi4Value.Text = "4.2 tỷ"
    End Sub

    Private Sub BindTable(data As List(Of ReportRow))
        dgvReport.Rows.Clear()
        For Each item In data
            dgvReport.Rows.Add(item.Code, item.Name, item.Dept, item.Score, item.Status)
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count} mục"
    End Sub

    Private Sub RenderChart()
        flpChart.Controls.Clear()
        Dim chartHeight As Integer = 160
        For i As Integer = 0 To _chartValues.Count - 1
            Dim value = _chartValues(i)
            Dim labelText = If(i < _chartLabels.Count, _chartLabels(i), $"T{i + 1}")

            Dim item As New Panel()
            item.Width = 46
            item.Height = chartHeight + 18
            item.Margin = New Padding(6, 0, 6, 0)
            item.BackColor = Color.Transparent

            Dim bar As New Panel()
            bar.Width = 36
            bar.Height = Math.Min(chartHeight, value + 40)
            bar.BackColor = Color.FromArgb(40, 74, 158, 255)
            bar.BorderStyle = BorderStyle.FixedSingle
            bar.Left = 5
            bar.Top = item.Height - 18 - bar.Height

            Dim lblValue As New Label()
            lblValue.Text = $"{value}%"
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
        If index < 0 OrElse index >= _rows.Count Then
            ClearDetail()
            Return
        End If

        Dim item = _rows(index)
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
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If Not ValidateRequired() Then
            lblError.Visible = True
            Return
        End If
        lblError.Visible = False
        MessageBox.Show("Đã áp dụng báo cáo (mock).", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportReport("Excel")
    End Sub

    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        ExportReport("PDF")
    End Sub

    Private Sub ExportReport(format As String)
        Dim scope = If(cboExportScope.SelectedItem Is Nothing, "report", cboExportScope.SelectedItem.ToString())
        MessageBox.Show($"Xuất {format} - {scope} (mock).", "Xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

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
