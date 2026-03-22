Imports System.Drawing
Imports System.Linq

Partial Public Class formPayroll
    ' ── Toolbar buttons ───────────────────────────────────────
    Private Sub btnCalcPayroll_Click(sender As Object, e As EventArgs) Handles btnCalcPayroll.Click
        Dim r = MessageBox.Show("Tính lương cho toàn bộ nhân viên trong kỳ này?",
                                "Xác nhận tính lương",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã tính lương xong (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnManagePeriod_Click(sender As Object, e As EventArgs) Handles btnManagePeriod.Click
        ShowTab(1)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp khi kết nối DB.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrintSlip_Click(sender As Object, e As EventArgs) Handles btnPrintSlip.Click
        ShowTab(3)
    End Sub

    Private Sub btnPrintOne_Click(sender As Object, e As EventArgs) Handles btnPrintOne.Click
        MessageBox.Show("Tính năng in phiếu sẽ được tích hợp.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportOne_Click(sender As Object, e As EventArgs) Handles btnExportOne.Click
        MessageBox.Show("Tính năng xuất PDF sẽ được tích hợp.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE HANDLERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnTab2Resize(s As Object, e As EventArgs)
        dgvPayroll.Size = New Size(
            pnlTab2.Width,
            pnlTab2.Height - pnlPayrollHeader.Height - pnlPayFooter.Height)
    End Sub

    Private Sub OnSlipCardResize(s As Object, e As EventArgs)
        lblSlipNetVal.Left = pnlSlipFooter.Width - lblSlipNetVal.Width - 20
    End Sub

    Private Sub OnToolbarResize(s As Object, e As EventArgs)
        Dim right = pnlToolbar.Width - 14
        btnCalcPayroll.Left = right - btnCalcPayroll.Width
        btnManagePeriod.Left = btnCalcPayroll.Left - btnManagePeriod.Width - 10
        btnPrintSlip.Left = btnManagePeriod.Left - btnPrintSlip.Width - 10
        btnExportExcel.Left = btnPrintSlip.Left - btnExportExcel.Width - 10
    End Sub

    Private Sub OnPeriodFooterResize(s As Object, e As EventArgs)
        btnSavePeriod.Left = pnlPeriodFooter.Width - btnSavePeriod.Width - 14
        btnClosePeriod.Left = btnSavePeriod.Left - btnClosePeriod.Width - 10
    End Sub

    Private Sub OnChipsResize(s As Object, e As EventArgs)
        lblChipIncome.Left = 0
        lblChipDeduct.Left = lblChipIncome.Width + 8
        lblChipNet.Left = lblChipDeduct.Left + lblChipDeduct.Width + 8
    End Sub

    Private Sub OnKpiRowResize(s As Object, e As EventArgs)
        Dim w = (pnlKpiRow.Width - 6) \ 4
        pnlKpi1.Width = w : pnlKpi1.Left = 0
        pnlKpi2.Width = w : pnlKpi2.Left = w + 2
        pnlKpi3.Width = w : pnlKpi3.Left = (w + 2) * 2
        pnlKpi4.Width = w : pnlKpi4.Left = (w + 2) * 3
    End Sub

    Private Sub OnSlipActionsResize(s As Object, e As EventArgs)
        btnExportOne.Left = pnlSlipActions.Width - btnExportOne.Width - 14
        btnPrintOne.Left = btnExportOne.Left - btnPrintOne.Width - 10
    End Sub

    Private Sub OnSlipHeaderResize(s As Object, e As EventArgs)
        lblSlipPeriodInfo.Left = pnlSlipCardHeader.Width - lblSlipPeriodInfo.Width - 20
        lblSlipPeriodDates.Left = pnlSlipCardHeader.Width - lblSlipPeriodDates.Width - 20
    End Sub
End Class
