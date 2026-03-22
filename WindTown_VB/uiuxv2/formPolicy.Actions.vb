Imports System.Linq
Imports System.Windows.Forms

Partial Public Class formPolicy
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
