Imports System.Linq
Imports System.Windows.Forms

Partial Public Class formPolicy
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

        If _usePolicyDb Then
            If SavePolicyToDatabase() Then
                MessageBox.Show(String.Format("Đã lưu chính sách: {0} — {1}", txtCode.Text, txtFName.Text),
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return
        End If

        MessageBox.Show(String.Format("Đã lưu chính sách (mock): {0} — {1}", txtCode.Text, txtFName.Text),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function SavePolicyToDatabase() As Boolean
        Dim pol As Policy
        If _selectedId > 0 AndAlso _policyEntityById.ContainsKey(_selectedId) Then
            pol = _policyEntityById(_selectedId)
        Else
            pol = New Policy()
        End If

        pol.code = txtCode.Text.Trim()
        pol.name = txtFName.Text.Trim()
        pol.note = txtFNote.Text.Trim()
        pol.rule = txtFormula.Text.Trim()
        pol.priority = _priority
        pol.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
        pol.category = UiCategoryToDb(_selCat)
        pol.source = UiSourceToDb(_selSrc)
        pol.aggregate = _selAgg + 1
        If _selectedId <= 0 Then
            pol.gen_item = 1
        End If

        pol.unit = CInt(UnitSuffix.ID.NONE)

        Dim result As ServiceResponse(Of Object)
        If _selectedId > 0 Then
            result = AppServices.Instance.PolicySV.Update(pol)
        Else
            result = AppServices.Instance.PolicySV.Insert(pol)
        End If

        If Not result.IsSuccess Then
            MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not TryLoadPoliciesFromDatabase() Then
            LoadMockPolicies()
        End If
        _filtered = New List(Of PolicyRow)(_allPolicies)
        ApplyFilter()
        RenderPolicyList(_allPolicies)
        Return True
    End Function

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
            If _usePolicyDb AndAlso _selectedId > 0 Then
                Dim toDel As New Policy With {.id = _selectedId}
                Dim dr = AppServices.Instance.PolicySV.Delete(New List(Of Policy) From {toDel})
                If Not dr.IsSuccess Then
                    MessageBox.Show(dr.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Not TryLoadPoliciesFromDatabase() Then
                    LoadMockPolicies()
                End If
                _filtered = New List(Of PolicyRow)(_allPolicies)
                ApplyFilter()
            Else
                MessageBox.Show("Đã xóa (mock data).", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
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

End Class
