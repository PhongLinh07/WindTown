Imports System.Drawing
Imports System.Linq

Partial Public Class formPayroll
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 1 — KỲ LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPeriodCards()
        flpPeriods.Controls.Clear()

        For Each p In _allPeriods
            Dim pid = p.Id
            Dim card As New Panel()
            card.BackColor = If(_selPeriodId = p.Id,
                                Color.FromArgb(30, 34, 53),
                                Color.FromArgb(26, 30, 48))
            card.Width = flpPeriods.ClientSize.Width - 20
            card.Height = 96
            card.Margin = New Padding(0, 0, 0, 8)
            card.Cursor = Cursors.Hand
            card.Tag = p.Id

            ' Accent left bar
            Dim bar As New Panel()
            bar.BackColor = GetPeriodStatusColor(p.Status)
            bar.Location = New Point(0, 0)
            bar.Size = New Size(3, 96)

            ' Code label
            Dim lblCode As New Label()
            lblCode.AutoSize = True
            lblCode.Font = New Font("Courier New", 10!, FontStyle.Bold)
            lblCode.ForeColor = Color.FromArgb(232, 236, 240)
            lblCode.Location = New Point(12, 10)
            lblCode.Text = p.Code

            ' Status badge
            Dim lblBadge As New Label()
            lblBadge.AutoSize = True
            lblBadge.BackColor = Color.FromArgb(If(p.Status = 1, 20, 15),
                                                GetPeriodStatusColor(p.Status))
            lblBadge.Font = New Font("Microsoft YaHei UI", 9!)
            lblBadge.ForeColor = GetPeriodStatusColor(p.Status)
            lblBadge.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            lblBadge.Location = New Point(card.Width - 90, 8)
            lblBadge.Padding = New Padding(5, 2, 5, 2)
            lblBadge.Text = GetPeriodStatusText(p.Status)

            ' Name
            Dim lblName As New Label()
            lblName.AutoSize = True
            lblName.Font = New Font("Microsoft YaHei UI", 9.0!)
            lblName.ForeColor = Color.FromArgb(197, 213, 240)
            lblName.Location = New Point(12, 32)
            lblName.Text = p.Name

            ' Dates
            Dim lblDates As New Label()
            lblDates.AutoSize = True
            lblDates.Font = New Font("Microsoft YaHei UI", 9!)
            lblDates.ForeColor = Color.FromArgb(61, 74, 114)
            lblDates.Location = New Point(12, 54)
            lblDates.Text = p.StartDate.ToString("dd/MM") & " → " &
                            p.EndDate.ToString("dd/MM") & " · " &
                            p.StdHours.ToString("0") & " giờ"

            ' Progress bar background
            Dim barBg As New Panel()
            barBg.BackColor = Color.FromArgb(38, 43, 66)
            barBg.Location = New Point(12, 76)
            barBg.Size = New Size(card.Width - 24, 3)

            ' Progress fill
            Dim barFill As New Panel()
            barFill.BackColor = GetPeriodStatusColor(p.Status)
            Dim fillPct = If(p.Status = 2, 1.0, 0.6)
            barFill.Location = New Point(0, 0)
            barFill.Size = New Size(CInt(barBg.Width * fillPct), 3)
            barBg.Controls.Add(barFill)

            card.Controls.Add(bar)
            card.Controls.Add(lblCode)
            card.Controls.Add(lblBadge)
            card.Controls.Add(lblName)
            card.Controls.Add(lblDates)
            card.Controls.Add(barBg)

            Dim clickH As EventHandler = Sub(s, ev) SelectPeriod(pid)
            AddHandler card.Click, clickH
            AddHandler lblCode.Click, clickH
            AddHandler lblName.Click, clickH
            AddHandler lblDates.Click, clickH

            flpPeriods.Controls.Add(card)
        Next
    End Sub

    Private Function GetPeriodStatusColor(status As Integer) As Color
        Select Case status
            Case 1 : Return Color.FromArgb(245, 158, 11)  ' processing
            Case 2 : Return Color.FromArgb(74, 158, 255)  ' closed
            Case Else : Return Color.FromArgb(123, 139, 178) ' draft
        End Select
    End Function

    Private Function GetPeriodStatusText(status As Integer) As String
        Select Case status
            Case 1 : Return "Đang xử lý"
            Case 2 : Return "Đã chốt"
            Case Else : Return "Nháp"
        End Select
    End Function

    Private Sub SelectPeriod(id As Integer)
        _selPeriodId = id
        RenderPeriodCards()

        Dim p As PeriodRow = Nothing
        Dim found = False
        For Each x In _allPeriods
            If x.Id = id Then : p = x : found = True : Exit For
            End If
        Next
        If Not found Then Return

        lblPeriodCode.Text = p.Code & "  —  " & p.Name
        lblPeriodSub.Text = p.StartDate.ToString("dd/MM/yyyy") & " → " & p.EndDate.ToString("dd/MM/yyyy")
        lblPeriodBadge.Text = GetPeriodStatusText(p.Status)
        lblPeriodBadge.ForeColor = GetPeriodStatusColor(p.Status)
        lblPeriodBadge.BackColor = Color.FromArgb(20, GetPeriodStatusColor(p.Status))

        txtPCode.Text = p.Code
        txtPName.Text = p.Name
        dtpStart.Value = p.StartDate
        dtpEnd.Value = p.EndDate
        dtpMonth.Value = p.Month
        txtStdHours.Text = p.StdHours.ToString("0")
        txtPNote.Text = p.Note

        ' Update badge on Tab2
        lblPayPeriodBadge.Text = p.Code & "  —  " & p.Name

        If _useDatabase Then
            LoadPayrollsForCurrentPeriodFromDatabase()
        End If
    End Sub

    Private Sub btnAddPeriod_Click(sender As Object, e As EventArgs) Handles btnAddPeriod.Click
        txtPCode.Clear() : txtPName.Clear() : txtPNote.Clear()
        txtStdHours.Text = "176"
        dtpStart.Value = Date.Today
        dtpEnd.Value = Date.Today.AddDays(30)
        dtpMonth.Value = Date.Today
        lblPeriodCode.Text = "Kỳ lương mới"
        lblPeriodSub.Text = "Điền thông tin bên dưới"
    End Sub

    Private Sub btnSavePeriod_Click(sender As Object, e As EventArgs) Handles btnSavePeriod.Click
        If String.IsNullOrWhiteSpace(txtPCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã kỳ lương.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        MessageBox.Show("Đã lưu kỳ lương: " & txtPCode.Text,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClosePeriod_Click(sender As Object, e As EventArgs) Handles btnClosePeriod.Click
        Dim r = MessageBox.Show("Chốt kỳ lương sẽ khóa toàn bộ dữ liệu. Tiếp tục?",
                                "Xác nhận chốt kỳ lương",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Kỳ lương đã được chốt (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDeletePeriod_Click(sender As Object, e As EventArgs) Handles btnDeletePeriod.Click
        Dim r = MessageBox.Show("Xóa kỳ lương này và toàn bộ bảng lương liên quan?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
