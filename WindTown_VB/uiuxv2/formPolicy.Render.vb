Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Partial Public Class formPolicy
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
                If(p.Status = 1, "Kích hoạt", "Tắt"),
                "Sửa")

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
            lblName.Font = New System.Drawing.Font("Microsoft YaHei UI", 10!, System.Drawing.FontStyle.Bold)
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
            lblDot.Text = If(p.Status = 1, "Bật", "Tắt")

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
                If(r.IsOk, "OK", "Tắt"))

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
End Class
