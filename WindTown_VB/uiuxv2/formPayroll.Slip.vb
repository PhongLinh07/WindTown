Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

Partial Public Class formPayroll
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 3 — PHIẾU LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderSlipEmpList()
        flpSlipEmps.Controls.Clear()

        For Each p In _allPayrolls
            Dim pid = p.Id
            Dim item As New Panel()
            item.BackColor = If(_selEmpId = p.Id,
                                Color.FromArgb(25, 74, 158, 255),
                                Color.Transparent)
            item.Width = flpSlipEmps.ClientSize.Width - 16
            item.Height = 48
            item.Margin = New Padding(0, 0, 0, 2)
            item.Cursor = Cursors.Hand
            item.Tag = p.Id

            ' Avatar
            Dim avatar As New Panel()
            avatar.BackColor = p.AvatarColor
            avatar.Location = New Point(8, 8)
            avatar.Size = New Size(32, 32)
            AddHandler avatar.Paint, Sub(s, ev)
                                         Dim g = ev.Graphics
                                         g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                         Using br = New SolidBrush(p.AvatarColor)
                                             g.FillEllipse(br, 0, 0, 31, 31)
                                         End Using
                                         Using f = New Font("Microsoft YaHei UI", 9!, FontStyle.Bold)
                                             Using br = New SolidBrush(Color.White)
                                                 Dim ini = GetInitials(p.EmpName)
                                                 Dim sz = g.MeasureString(ini, f)
                                                 g.DrawString(ini, f, br, (32 - sz.Width) / 2, (32 - sz.Height) / 2)
                                             End Using : End Using
                                     End Sub

            ' Name
            Dim lblName As New Label()
            lblName.AutoSize = True
            lblName.Font = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Bold)
            lblName.ForeColor = Color.FromArgb(232, 236, 240)
            lblName.Location = New Point(48, 6)
            lblName.Text = p.EmpName

            ' Net value
            Dim lblNet As New Label()
            lblNet.AutoSize = True
            lblNet.Font = New Font("Microsoft YaHei UI", 9!, FontStyle.Bold)
            lblNet.ForeColor = Color.FromArgb(74, 158, 255)
            lblNet.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            lblNet.Location = New Point(item.Width - 80, 6)
            lblNet.Text = FmtM(p.NetSalary)

            ' Dept
            Dim lblDept As New Label()
            lblDept.AutoSize = True
            lblDept.Font = New Font("Microsoft YaHei UI", 9!)
            lblDept.ForeColor = Color.FromArgb(123, 139, 178)
            lblDept.Location = New Point(48, 26)
            lblDept.Text = p.Dept

            item.Controls.Add(avatar)
            item.Controls.Add(lblName)
            item.Controls.Add(lblNet)
            item.Controls.Add(lblDept)

            Dim clickH As EventHandler = Sub(s, ev) SelectEmployee(pid)
            AddHandler item.Click, clickH
            AddHandler lblName.Click, clickH
            AddHandler lblDept.Click, clickH
            AddHandler lblNet.Click, clickH

            flpSlipEmps.Controls.Add(item)
        Next
    End Sub

    Private Sub SelectEmployee(id As Integer)
        _selEmpId = id
        RenderSlipEmpList()

        Dim pr As PayrollRow = Nothing
        Dim found = False
        For Each x In _allPayrolls
            If x.Id = id Then : pr = x : found = True : Exit For
            End If
        Next
        If Not found Then Return

        ' Update slip header
        pnlSlipAvatar.BackColor = pr.AvatarColor
        pnlSlipAvatar.Tag = GetInitials(pr.EmpName)
        pnlSlipAvatar.Invalidate()
        lblSlipEmpName.Text = pr.EmpName
        lblSlipEmpSub.Text = pr.Dept & "  ·  " & pr.Job

        Dim per = _allPeriods.FirstOrDefault(Function(x) x.Id = _selPeriodId)
        If per.Id = 0 AndAlso _allPeriods.Count > 0 Then per = _allPeriods(0)
        If per.Id <> 0 Then
            lblSlipPeriodInfo.Text = per.Code & "  —  " & per.Name
            lblSlipPeriodDates.Text = per.StartDate.ToString("dd/MM/yyyy") & " → " &
                                      per.EndDate.ToString("dd/MM/yyyy") &
                                      "  ·  " & per.StdHours.ToString("0") & " giờ chuẩn"
        End If

        ' Build pay items
        Dim items As List(Of PayItemRow)
        If _payItems.ContainsKey(id) Then
            items = _payItems(id)
        Else
            ' Default items based on base salary
            items = New List(Of PayItemRow)()
            items.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = pr.BaseSalary, .Category = 0})
            items.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
            items.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -pr.BaseSalary * 0.08D, .Category = 4})
            items.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -pr.BaseSalary * 0.015D, .Category = 4})
        End If

        Dim incomeItems = items.Where(Function(x) x.Value > 0).ToList()
        Dim deductItems = items.Where(Function(x) x.Value < 0).ToList()
        Dim totalIncome = incomeItems.Sum(Function(x) x.Value)
        Dim totalDeduct = deductItems.Sum(Function(x) x.Value)
        Dim netVal = totalIncome + totalDeduct

        ' Render income rows
        flpSlipIncomeItems.Controls.Clear()
        For Each item In incomeItems
            flpSlipIncomeItems.Controls.Add(BuildPayItemRow(item))
        Next
        pnlSlipIncomeSection.Height = 36 + incomeItems.Count * 44 + 10
        flpSlipIncomeItems.Height = incomeItems.Count * 44

        ' Render deduct rows
        flpSlipDeductItems.Controls.Clear()
        For Each item In deductItems
            flpSlipDeductItems.Controls.Add(BuildPayItemRow(item))
        Next
        pnlSlipDeductSection.Height = 36 + deductItems.Count * 44 + 10
        flpSlipDeductItems.Height = deductItems.Count * 44

        ' Update totals
        lblSlipIncomeTotal.Text = "+" & FmtVND(totalIncome)
        lblSlipDeductTotal.Text = FmtVND(totalDeduct)
        lblSlipNetVal.Text = FmtVND(netVal)

        ' Resize slip card
        pnlSlipCard.Height = pnlSlipCardHeader.Height +
                             pnlSlipIncomeSection.Height +
                             pnlSlipDeductSection.Height +
                             pnlSlipFooter.Height + 20
    End Sub

    Private Function BuildPayItemRow(item As PayItemRow) As Panel
        Dim row As New Panel()
        row.BackColor = Color.Transparent
        row.Width = flpSlipIncomeItems.ClientSize.Width
        row.Height = 44
        row.Margin = New Padding(0, 0, 0, 0)

        Dim sep As New Panel()
        sep.BackColor = Color.FromArgb(42, 48, 80)
        sep.Dock = DockStyle.Bottom
        sep.Height = 1

        Dim lblName As New Label()
        lblName.AutoSize = True
        lblName.Font = New Font("Microsoft YaHei UI", 10!)
        lblName.ForeColor = Color.FromArgb(197, 213, 240)
        lblName.Location = New Point(18, 8)
        lblName.Text = item.Name

        Dim lblCode As New Label()
        lblCode.AutoSize = True
        lblCode.Font = New Font("Courier New", 9!)
        lblCode.ForeColor = Color.FromArgb(61, 74, 114)
        lblCode.Location = New Point(18, 26)
        lblCode.Text = item.Code

        Dim lblVal As New Label()
        lblVal.AutoSize = True
        lblVal.Font = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
        lblVal.ForeColor = If(item.Value >= 0,
                              Color.FromArgb(76, 175, 80),
                              Color.FromArgb(240, 128, 128))
        lblVal.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
        lblVal.Location = New Point(row.Width - 160, 12)
        lblVal.Text = If(item.Value >= 0, "+", "") & FmtVND(item.Value)

        row.Controls.Add(sep)
        row.Controls.Add(lblName)
        row.Controls.Add(lblCode)
        row.Controls.Add(lblVal)
        Return row
    End Function

    ' Avatar paint for slip header
    Private Sub SlipAvatar_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl = CType(sender, Panel)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Using br = New SolidBrush(pnl.BackColor)
            g.FillEllipse(br, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
        Dim initials = If(pnl.Tag IsNot Nothing, pnl.Tag.ToString(), "NV")
        Using f = New Font("Microsoft YaHei UI", 12.0!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim sz = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             (pnl.Width - sz.Width) / 2,
                             (pnl.Height - sz.Height) / 2)
            End Using : End Using
    End Sub
End Class
