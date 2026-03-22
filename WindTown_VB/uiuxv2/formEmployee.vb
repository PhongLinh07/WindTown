Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class formEmployee

    ' ── Services ─────────────────────────────────────────────
    Private ReadOnly _empSv = AppServices.Instance.EmployeeSV
    Private ReadOnly _ctrSv = AppServices.Instance.ContractSV

    ' ── Data ─────────────────────────────────────────────────
    Private _allEmps As New List(Of Employee)()
    Private _allContracts As New List(Of Contract)()
    Private _filtered As New List(Of Employee)()
    Private _selectedId As Integer = -1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiTextBoxHints.SetCueBanner(txtSearch, "🔍  Tìm kiếm nhân viên...")
        DoubleBuffered = True
        AddHandler pnlAvatarCircle.Paint, AddressOf AvatarCircle_Paint
        AddHandler pnlDetailFooter.Resize, AddressOf RepositionFooterBtns
        AddHandler pnlContractFooter.Resize, AddressOf RepositionContractBtn
        AddHandler pnlToolbar.Resize, AddressOf RepositionToolbarBtns
        LoadData()
        ShowTab(1)
    End Sub

    Private Sub LoadData()
        Dim resEmp = _empSv.GetList()
        _allEmps = If(resEmp.IsSuccess,
                      CType(resEmp.Data, IEnumerable(Of Employee)).ToList(),
                      New List(Of Employee)())

        Dim resCtr = _ctrSv.GetList()
        _allContracts = If(resCtr.IsSuccess,
                           CType(resCtr.Data, IEnumerable(Of Contract)).ToList(),
                           New List(Of Contract)())

        _filtered = New List(Of Employee)(_allEmps)
        RenderTable()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private _currentTab As Integer = 1

    Private Sub ShowTab(tab As Integer)
        _currentTab = tab
        pnlTab1.Visible = False
        pnlTab2.Visible = False
        pnlTab3.Visible = False
        pnlContent.SuspendLayout()
        pnlContent.Controls.Remove(pnlTab1)
        pnlContent.Controls.Remove(pnlTab2)
        pnlContent.Controls.Remove(pnlTab3)
        Dim target = If(tab = 1, pnlTab1, If(tab = 2, pnlTab2, pnlTab3))
        target.Visible = True
        pnlContent.Controls.Add(target)
        target.BringToFront()
        pnlContent.ResumeLayout()
        btnTabList.ForeColor = If(tab = 1, Color.FromArgb(74, 158, 255), Color.FromArgb(123, 139, 178))
        btnTabDetail.ForeColor = If(tab = 2, Color.FromArgb(74, 158, 255), Color.FromArgb(123, 139, 178))
        btnTabContract.ForeColor = If(tab = 3, Color.FromArgb(74, 158, 255), Color.FromArgb(123, 139, 178))
        pnlTabIndicator.Left = If(tab = 1, 0, If(tab = 2, 160, 320))
    End Sub

    Private Sub btnTabList_Click(sender As Object, e As EventArgs) Handles btnTabList.Click
        ShowTab(1)
    End Sub

    Private Sub btnTabDetail_Click(sender As Object, e As EventArgs) Handles btnTabDetail.Click
        ShowTab(2)
    End Sub

    Private Sub btnTabContract_Click(sender As Object, e As EventArgs) Handles btnTabContract.Click
        ShowTab(3)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER TABLE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderTable()
        dgvEmployee.Rows.Clear()
        For Each emp In _filtered
            Dim initials = GetInitials(emp.name)
            Dim statusStr = If(emp.status = 1, "● Làm việc", "○ Nghỉ")
            dgvEmployee.Rows.Add(False, initials, emp.name, emp.code,
                                 emp.gender_UI, "", "", emp.email, emp.phone,
                                 "", statusStr, "✎  Sửa")
            Dim row = dgvEmployee.Rows(dgvEmployee.Rows.Count - 1)
            row.Tag = emp.id
            row.Cells("colStatusDgv").Style.ForeColor =
                If(emp.status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            row.Cells("colActions").Style.ForeColor = Color.FromArgb(74, 158, 255)
        Next
        dgvEmployee.Size = New Size(pnlTab1.Width, pnlTab1.Height - pnlTableFooter.Height)
        lblRowInfo.Text = $"Hiển thị {_filtered.Count} nhân viên (tổng {_allEmps.Count})"
    End Sub

    Private Sub dgvEmployee_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEmployee.CellPainting
        If e.ColumnIndex <> dgvEmployee.Columns("colAvatar").Index OrElse e.RowIndex < 0 Then Return
        e.PaintBackground(e.ClipBounds, True)
        Dim empId = If(dgvEmployee.Rows(e.RowIndex).Tag IsNot Nothing,
                       CInt(dgvEmployee.Rows(e.RowIndex).Tag), 0)
        Dim pal = ThemeColors.AvatarPalette
        Dim clr = pal(empId Mod pal.Length)
        Dim initials = modDB.SafeStr(e.Value)
        Dim g = e.Graphics
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim sz = 34
        Dim x = e.CellBounds.X + (e.CellBounds.Width - sz) \ 2
        Dim y = e.CellBounds.Y + (e.CellBounds.Height - sz) \ 2
        Using br = New SolidBrush(clr)
            g.FillEllipse(br, x, y, sz, sz)
        End Using
        Using f = New Font("Microsoft YaHei UI", 10!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim s = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             CSng(x + (sz - s.Width) / 2),
                             CSng(y + (sz - s.Height) / 2))
            End Using
        End Using
        e.Handled = True
    End Sub

    Private Sub dgvEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvEmployee.Rows(e.RowIndex)
        If e.ColumnIndex = dgvEmployee.Columns("colChk").Index Then Return
        If row.Tag Is Nothing Then Return
        SelectEmployee(CInt(row.Tag))
        ShowTab(2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SELECT EMPLOYEE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub SelectEmployee(id As Integer)
        _selectedId = id
        Dim emp = _allEmps.FirstOrDefault(Function(x) x.id = id)
        If emp Is Nothing Then Return

        Dim pal = ThemeColors.AvatarPalette
        Dim clr = pal(emp.id Mod pal.Length)
        pnlAvatarCircle.Tag = GetInitials(emp.name)
        pnlAvatarCircle.BackColor = clr
        pnlAvatarCircle.Invalidate()

        lblDetailName.Text = emp.name
        lblDetailCode.Text = emp.code

        If emp.status = 1 Then
            lblDetailStatus.Text = "● Đang làm việc"
            lblDetailStatus.ForeColor = Color.FromArgb(76, 175, 80)
            lblDetailStatus.BackColor = Color.FromArgb(20, 76, 175, 80)
        Else
            lblDetailStatus.Text = "○ Nghỉ việc"
            lblDetailStatus.ForeColor = Color.FromArgb(123, 139, 178)
            lblDetailStatus.BackColor = Color.FromArgb(20, 123, 139, 178)
        End If

        txtCode.Text = emp.code
        txtFName.Text = emp.name
        If emp.birth_date.HasValue Then dtpBirth.Value = emp.birth_date.Value
        cboGender.SelectedIndex = emp.gender
        txtCccd.Text = emp.cccd
        txtAddress.Text = emp.address
        txtEmail.Text = emp.email
        txtPhone.Text = emp.phone
        txtBank.Text = emp.bank
        txtNote.Text = emp.note

        LoadContractCards(id, emp.name)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  CONTRACT CARDS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadContractCards(empId As Integer, empName As String)
        lblContractEmp.Text = $"Hợp đồng của:  {empName}"
        pnlContractScroll.Controls.Clear()
        Dim contracts = _allContracts.Where(Function(c) c.employee_id = empId).ToList()
        If contracts.Count = 0 Then
            Dim lbl = New Label() With {
                .Text = "Nhân viên chưa có hợp đồng nào",
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .ForeColor = Color.FromArgb(123, 139, 178)
            }
            pnlContractScroll.Controls.Add(lbl)
            Return
        End If
        Dim yPos = 0
        For i = contracts.Count - 1 To 0 Step -1
            Dim card = BuildContractCard(contracts(i), yPos)
            pnlContractScroll.Controls.Add(card)
            yPos += card.Height + 10
        Next
    End Sub

    Private Function BuildContractCard(c As Contract, y As Integer) As Panel
        Dim card = New Panel() With {
            .BackColor = Color.FromArgb(30, 34, 53),
            .Location = New Point(0, y),
            .Size = New Size(pnlContractScroll.ClientSize.Width - 32, 120),
            .Cursor = Cursors.Hand
        }
        Dim lblCode = New Label() With {
            .Text = c.code,
            .Font = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold),
            .ForeColor = Color.FromArgb(232, 236, 240),
            .AutoSize = True,
            .Location = New Point(16, 14)
        }
        Dim active = (c.status = 1)
        Dim lblStatus = New Label() With {
            .Text = If(active, "● Hiện hành", "○ Hết hạn"),
            .AutoSize = True,
            .ForeColor = If(active, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178)),
            .Location = New Point(card.Width - 140, 14)
        }
        Dim endStr = If(c.end_date.HasValue, c.end_date.Value.ToString("dd/MM/yyyy"), "Không thời hạn")
        Dim lblDates = New Label() With {
            .Text = $"{c.start_date:dd/MM/yyyy}  →  {endStr}",
            .AutoSize = True,
            .ForeColor = Color.FromArgb(123, 139, 178),
            .Location = New Point(16, 40)
        }
        Dim divider = New Panel() With {
            .BackColor = Color.FromArgb(42, 48, 80),
            .Location = New Point(16, 64),
            .Size = New Size(card.Width - 32, 1)
        }
        Dim lblS1 = New Label() With {
            .Text = "Lương cơ bản",
            .AutoSize = True,
            .ForeColor = Color.FromArgb(123, 139, 178),
            .Location = New Point(16, 74)
        }
        Dim lblV1 = New Label() With {
            .Text = modDB.FormatVND(c.base_salary),
            .AutoSize = True,
            .Font = New Font("Microsoft YaHei UI", 10.0!, FontStyle.Bold),
            .ForeColor = Color.FromArgb(74, 158, 255),
            .Location = New Point(16, 92)
        }
        card.Controls.AddRange({lblCode, lblStatus, lblDates, divider, lblS1, lblV1})
        Return card
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FILTER
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim statIdx = cboStatus.SelectedIndex
        _filtered = _allEmps.Where(Function(emp)
                                       Dim mQ = q = "" OrElse
                                                emp.name.ToLower().Contains(q) OrElse
                                                emp.code.ToLower().Contains(q)
                                       Dim mS = statIdx = 0 OrElse
                                                (statIdx = 1 AndAlso emp.status = 1) OrElse
                                                (statIdx = 2 AndAlso emp.status <> 1)
                                       Return mQ AndAlso mS
                                   End Function).ToList()
        RenderTable()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TOOLBAR & FORM ACTIONS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _selectedId = -1
        ClearForm()
        ShowTab(2)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập họ tên nhân viên.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _selectedId < 0 Then
            Dim emp As New Employee() With {
                .code = txtCode.Text.Trim(),
                .name = txtFName.Text.Trim(),
                .birth_date = dtpBirth.Value,
                .gender = cboGender.SelectedIndex,
                .cccd = txtCccd.Text.Trim(),
                .address = txtAddress.Text.Trim(),
                .email = txtEmail.Text.Trim(),
                .phone = txtPhone.Text.Trim(),
                .bank = txtBank.Text.Trim(),
                .note = txtNote.Text.Trim(),
                .status = 1
            }
            Dim res = _empSv.Insert(emp)
            MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK,
                            If(res.IsSuccess, MessageBoxIcon.Information, MessageBoxIcon.Error))
        Else
            Dim emp = _allEmps.FirstOrDefault(Function(x) x.id = _selectedId)
            If emp Is Nothing Then Return
            emp.code = txtCode.Text.Trim()
            emp.name = txtFName.Text.Trim()
            emp.birth_date = dtpBirth.Value
            emp.gender = cboGender.SelectedIndex
            emp.cccd = txtCccd.Text.Trim()
            emp.address = txtAddress.Text.Trim()
            emp.email = txtEmail.Text.Trim()
            emp.phone = txtPhone.Text.Trim()
            emp.bank = txtBank.Text.Trim()
            emp.note = txtNote.Text.Trim()
            Dim res = _empSv.Update(emp)
            MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK,
                            If(res.IsSuccess, MessageBoxIcon.Information, MessageBoxIcon.Error))
        End If
        LoadData()
        ShowTab(1)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId < 0 Then Return
        Dim emp = _allEmps.FirstOrDefault(Function(x) x.id = _selectedId)
        If emp Is Nothing Then Return
        If MessageBox.Show($"Xóa nhân viên ""{emp.name}""?", "Xác nhận",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            _empSv.Delete(New List(Of Employee) From {emp})
            _selectedId = -1
            ClearForm()
            LoadData()
            ShowTab(1)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        _selectedId = -1
        ClearForm()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAddContract_Click(sender As Object, e As EventArgs) Handles btnAddContract.Click
        MessageBox.Show("Tính năng thêm hợp đồng sẽ được phát triển tiếp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtFName_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged
        lblDetailName.Text = If(String.IsNullOrWhiteSpace(txtFName.Text), "Thêm nhân viên mới", txtFName.Text)
        pnlAvatarCircle.Tag = GetInitials(txtFName.Text)
        pnlAvatarCircle.Invalidate()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub ClearForm()
        txtCode.Clear()
        txtFName.Clear()
        dtpBirth.Value = Date.Now.AddYears(-25)
        cboGender.SelectedIndex = 0
        txtCccd.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtBank.Clear()
        txtNote.Clear()
        lblDetailName.Text = "Thêm nhân viên mới"
        lblDetailCode.Text = "Điền thông tin bên dưới"
        pnlAvatarCircle.Tag = "NV"
        pnlAvatarCircle.BackColor = Color.FromArgb(59, 125, 216)
        pnlAvatarCircle.Invalidate()
    End Sub

    Private Function GetInitials(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "NV"
        Dim parts = name.Trim().Split(" "c)
        If parts.Length >= 2 Then
            Return (parts(0)(0).ToString() & parts(parts.Length - 1)(0).ToString()).ToUpper()
        End If
        Return name.Substring(0, Math.Min(2, name.Length)).ToUpper()
    End Function

    Private Sub AvatarCircle_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl = CType(sender, Panel)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Using br = New SolidBrush(pnl.BackColor)
            g.FillEllipse(br, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
        Dim initials = If(pnl.Tag IsNot Nothing, pnl.Tag.ToString(), "NV")
        Using f = New Font("Microsoft YaHei UI", 13.0!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim sz = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             CSng((pnl.Width - sz.Width) / 2),
                             CSng((pnl.Height - sz.Height) / 2))
            End Using
        End Using
    End Sub

    Private Sub RepositionFooterBtns(sender As Object, e As EventArgs)
        btnClear.Left = pnlDetailFooter.Width - btnSave.Width - btnClear.Width - 20
        btnSave.Left = pnlDetailFooter.Width - btnSave.Width - 14
    End Sub

    Private Sub RepositionContractBtn(sender As Object, e As EventArgs)
        btnAddContract.Left = pnlContractFooter.Width - btnAddContract.Width - 14
    End Sub

    Private Sub RepositionToolbarBtns(sender As Object, e As EventArgs)
        btnExport.Left = pnlToolbar.Width - btnAdd.Width - btnExport.Width - 20
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
    End Sub

    Private Sub pnlTab1_Resize(sender As Object, e As EventArgs) Handles pnlTab1.Resize
        dgvEmployee.Size = New Size(pnlTab1.Width, pnlTab1.Height - pnlTableFooter.Height)
    End Sub

End Class