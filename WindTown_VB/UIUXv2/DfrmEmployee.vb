Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Runtime.InteropServices



' ============================================================
'  formEmployee.vb — Quản lý nhân viên (mock data)
'  Khi cần DB thật: thay các Sub LoadMock* bằng LoadDB*
' ============================================================
Public Class formEmployee
    ' ── Win32: hint text cho TextBox (.NET 4.8 không có PlaceholderText) ──
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function

    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Const CB_SETCUEBANNER As Integer = &H1703

    Private Sub SetPlaceholder(tb As TextBox, hint As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), hint)
    End Sub

    Private Sub SetPlaceholder(cb As ComboBox, hint As String)
        SendMessage(cb.Handle, CB_SETCUEBANNER, IntPtr.Zero, hint)
    End Sub

    ' ── Mock data structures ─────────────────────────────────
    Private Structure EmpRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Gender As Integer   ' 1=Nam 0=Nữ 2=Khác
        Dim Dept As String
        Dim Job As String
        Dim Email As String
        Dim Phone As String
        Dim Cccd As String
        Dim Birth As Date
        Dim Address As String
        Dim Bank As String
        Dim ContractType As String
        Dim Status As Integer   ' 1=active 0=inactive
        Dim Note As String
    End Structure

    Private Structure ContractRow
        Dim EmpId As Integer
        Dim Code As String
        Dim StartDate As Date
        Dim EndDate As Date
        Dim BaseSalary As Decimal
        Dim ContractType As String
        Dim Position As String
        Dim Dept As String
        Dim Active As Boolean
    End Structure

    Private _allEmps As New List(Of EmpRow)
    Private _allContracts As New List(Of ContractRow)
    Private _filtered As New List(Of EmpRow)
    Private _selectedId As Integer = -1

    ' Avatar colors — one per employee id mod 8
    Private ReadOnly _avatarColors() As Color = {
        Color.FromArgb(74, 158, 255),
        Color.FromArgb(123, 97, 255),
        Color.FromArgb(76, 175, 80),
        Color.FromArgb(245, 158, 11),
        Color.FromArgb(224, 85, 85),
        Color.FromArgb(38, 198, 218),
        Color.FromArgb(236, 72, 153),
        Color.FromArgb(249, 115, 22)
    }

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholder(txtSearch, "🔍  Tìm kiếm chính sách...")
        SetPlaceholder(cboDept, "Phòng ban")
        SetPlaceholder(cboStatus, "Trạng thái công việc")

        DoubleBuffered = True
        LoadMockData()
        LoadMockContracts()
        _filtered = New List(Of EmpRow)(_allEmps)
        RenderTable()
        ShowTab(1)

        ' Paint avatar circle
        AddHandler pnlAvatarCircle.Paint, AddressOf AvatarCircle_Paint

        ' Resize: anchor footer buttons
        AddHandler pnlDetailFooter.Resize, Sub(s, ev) RepositionFooterBtns()
        AddHandler pnlContractFooter.Resize, Sub(s, ev) RepositionContractBtn()
        AddHandler pnlToolbar.Resize, Sub(s, ev) RepositionToolbarBtns()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockData()
        _allEmps.Clear()
        _allEmps.Add(New EmpRow With {.Id = 1, .Code = "EMP001", .Name = "Nguyễn Văn An", .Gender = 1, .Dept = "Kỹ thuật", .Job = "Lập trình viên", .Email = "emp001@windtown.com", .Phone = "0211532090", .Cccd = "047636216680", .Birth = #3/2/2002#, .Address = "Phú Thọ", .Bank = "ACB_0211532090", .ContractType = "Toàn thời gian", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 2, .Code = "EMP002", .Name = "Trần Thị Bình", .Gender = 0, .Dept = "Kế toán", .Job = "Kế toán trưởng", .Email = "emp002@windtown.com", .Phone = "0987654321", .Cccd = "012345678901", .Birth = #7/15/1990#, .Address = "Hà Nội", .Bank = "VCB_9876543210", .ContractType = "Toàn thời gian", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 3, .Code = "EMP003", .Name = "Lê Văn Cường", .Gender = 1, .Dept = "Nhân sự", .Job = "Chuyên viên NS", .Email = "emp003@windtown.com", .Phone = "0912345678", .Cccd = "023456789012", .Birth = #11/20/1995#, .Address = "TP.HCM", .Bank = "TCB_1234567890", .ContractType = "Thời vụ", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 4, .Code = "EMP004", .Name = "Phạm Thị Dung", .Gender = 0, .Dept = "Marketing", .Job = "Marketing Manager", .Email = "emp004@windtown.com", .Phone = "0931234567", .Cccd = "034567890123", .Birth = #4/5/1988#, .Address = "Đà Nẵng", .Bank = "MB_0987654321", .ContractType = "Toàn thời gian", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 5, .Code = "EMP005", .Name = "Hoàng Văn Em", .Gender = 1, .Dept = "Kinh doanh", .Job = "Sales Executive", .Email = "emp005@windtown.com", .Phone = "0945678901", .Cccd = "045678901234", .Birth = #9/12/1997#, .Address = "Cần Thơ", .Bank = "ACB_2345678901", .ContractType = "Part-time", .Status = 0})
        _allEmps.Add(New EmpRow With {.Id = 6, .Code = "EMP006", .Name = "Vũ Thị Phương", .Gender = 0, .Dept = "Kỹ thuật", .Job = "QA Engineer", .Email = "emp006@windtown.com", .Phone = "0956789012", .Cccd = "056789012345", .Birth = #2/28/1993#, .Address = "Hải Phòng", .Bank = "VCB_3456789012", .ContractType = "Toàn thời gian", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 7, .Code = "EMP007", .Name = "Đặng Văn Giang", .Gender = 1, .Dept = "Vận hành", .Job = "Ops Manager", .Email = "emp007@windtown.com", .Phone = "0967890123", .Cccd = "067890123456", .Birth = #6/18/1985#, .Address = "Bình Dương", .Bank = "TCB_4567890123", .ContractType = "Toàn thời gian", .Status = 1})
        _allEmps.Add(New EmpRow With {.Id = 8, .Code = "EMP008", .Name = "Bùi Thị Hoa", .Gender = 0, .Dept = "Kỹ thuật", .Job = "Frontend Dev", .Email = "emp008@windtown.com", .Phone = "0978901234", .Cccd = "078901234567", .Birth = #12/1/2000#, .Address = "Hà Nội", .Bank = "MB_5678901234", .ContractType = "Thực tập", .Status = 1})
    End Sub

    Private Sub LoadMockContracts()
        _allContracts.Clear()
        _allContracts.Add(New ContractRow With {.EmpId = 1, .Code = "CTR2024001", .StartDate = #1/1/2024#, .EndDate = #12/31/2025#, .BaseSalary = 15000000, .ContractType = "Toàn thời gian", .Position = "Lập trình viên", .Dept = "Kỹ thuật", .Active = True})
        _allContracts.Add(New ContractRow With {.EmpId = 2, .Code = "CTR2023001", .StartDate = #6/1/2023#, .EndDate = #5/31/2024#, .BaseSalary = 25000000, .ContractType = "Toàn thời gian", .Position = "Kế toán trưởng", .Dept = "Kế toán", .Active = False})
        _allContracts.Add(New ContractRow With {.EmpId = 2, .Code = "CTR2024002", .StartDate = #6/1/2024#, .EndDate = #5/31/2025#, .BaseSalary = 28000000, .ContractType = "Toàn thời gian", .Position = "Kế toán trưởng", .Dept = "Kế toán", .Active = True})
        _allContracts.Add(New ContractRow With {.EmpId = 4, .Code = "CTR2024003", .StartDate = #3/1/2024#, .EndDate = #2/28/2025#, .BaseSalary = 22000000, .ContractType = "Toàn thời gian", .Position = "Marketing Manager", .Dept = "Marketing", .Active = True})
        _allContracts.Add(New ContractRow With {.EmpId = 6, .Code = "CTR2024004", .StartDate = #1/15/2024#, .EndDate = #1/14/2026#, .BaseSalary = 18000000, .ContractType = "Toàn thời gian", .Position = "QA Engineer", .Dept = "Kỹ thuật", .Active = True})
        _allContracts.Add(New ContractRow With {.EmpId = 8, .Code = "CTR2025001", .StartDate = #3/1/2025#, .EndDate = #8/31/2025#, .BaseSalary = 5000000, .ContractType = "Thực tập", .Position = "Frontend Intern", .Dept = "Kỹ thuật", .Active = True})
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private _currentTab As Integer = 1

    Private Sub ShowTab(tab As Integer)
        _currentTab = tab
        ' Chỉ giữ đúng một panel trong pnlContent để tránh bị chồng lấp.
        Dim panelDangChon As Panel = Nothing
        Select Case tab
            Case 1
                panelDangChon = pnlTab1
            Case 2
                panelDangChon = pnlTab2
            Case 3
                panelDangChon = pnlTab3
        End Select

        pnlTab1.Visible = False
        pnlTab2.Visible = False
        pnlTab3.Visible = False

        pnlContent.SuspendLayout()

        If pnlContent.Controls.Contains(pnlTab1) Then pnlContent.Controls.Remove(pnlTab1)
        If pnlContent.Controls.Contains(pnlTab2) Then pnlContent.Controls.Remove(pnlTab2)
        If pnlContent.Controls.Contains(pnlTab3) Then pnlContent.Controls.Remove(pnlTab3)

        If panelDangChon IsNot Nothing Then
            panelDangChon.Visible = True
            pnlContent.Controls.Add(panelDangChon)
            panelDangChon.BringToFront()
        End If

        pnlContent.ResumeLayout()

        ' Reset tab button colors
        btnTabList.ForeColor = Color.FromArgb(123, 139, 178)
        btnTabDetail.ForeColor = Color.FromArgb(123, 139, 178)
        btnTabContract.ForeColor = Color.FromArgb(123, 139, 178)

        ' Activate selected
        Select Case tab
            Case 1
                btnTabList.ForeColor = Color.FromArgb(74, 158, 255)
                pnlTabIndicator.Left = 0
            Case 2
                btnTabDetail.ForeColor = Color.FromArgb(74, 158, 255)
                pnlTabIndicator.Left = 160
            Case 3
                btnTabContract.ForeColor = Color.FromArgb(74, 158, 255)
                pnlTabIndicator.Left = 320
        End Select
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
            Dim genderStr = If(emp.Gender = 1, "Nam", If(emp.Gender = 0, "Nữ", "Khác"))
            Dim statusStr = If(emp.Status = 1, "● Làm việc", "○ Nghỉ")
            Dim avatarStr = GetInitials(emp.Name)

            dgvEmployee.Rows.Add(
                False,
                avatarStr,
                emp.Name,
                emp.Code,
                genderStr,
                emp.Dept,
                emp.Job,
                emp.Email,
                emp.Phone,
                emp.ContractType,
                statusStr,
                "✎  Sửa")

            Dim row = dgvEmployee.Rows(dgvEmployee.Rows.Count - 1)
            row.Tag = emp.Id

            ' Status color
            If emp.Status = 1 Then
                row.Cells("colStatusDgv").Style.ForeColor = Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colStatusDgv").Style.ForeColor = Color.FromArgb(123, 139, 178)
            End If

            ' Contract type color
            Select Case emp.ContractType
                Case "Toàn thời gian"
                    row.Cells("colContractType").Style.ForeColor = Color.FromArgb(74, 158, 255)
                Case "Thực tập"
                    row.Cells("colContractType").Style.ForeColor = Color.FromArgb(76, 175, 80)
                Case "Thời vụ", "Part-time"
                    row.Cells("colContractType").Style.ForeColor = Color.FromArgb(245, 158, 11)
            End Select

            ' Action cell color
            row.Cells("colActions").Style.ForeColor = Color.FromArgb(74, 158, 255)
        Next

        ' Update dgvEmployee size to fill tab
        dgvEmployee.Size = New Size(pnlTab1.Width, pnlTab1.Height - pnlTableFooter.Height)

        lblRowInfo.Text = $"Hiển thị {_filtered.Count} nhân viên (tổng {_allEmps.Count})"
    End Sub

    ' ── DGV CellPaint — vẽ avatar circle ─────────────────────
    Private Sub dgvEmployee_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEmployee.CellPainting
        If e.ColumnIndex <> dgvEmployee.Columns("colAvatar").Index OrElse e.RowIndex < 0 Then Return

        e.PaintBackground(e.ClipBounds, True)

        Dim row = dgvEmployee.Rows(e.RowIndex)
        Dim empId = If(row.Tag IsNot Nothing, CInt(row.Tag), 0)
        Dim clr = _avatarColors(empId Mod _avatarColors.Length)
        Dim initials = modDB.SafeStr(e.Value)

        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim size = 34
        Dim x = e.CellBounds.X + (e.CellBounds.Width - size) \ 2
        Dim y = e.CellBounds.Y + (e.CellBounds.Height - size) \ 2

        Using br = New SolidBrush(clr)
            g.FillEllipse(br, x, y, size, size)
        End Using

        Using f = New Font("Microsoft YaHei UI", 9.5!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim sz = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             x + (size - sz.Width) / 2,
                             y + (size - sz.Height) / 2)
            End Using : End Using

        e.Handled = True
    End Sub

    ' ── DGV CellClick — chọn nhân viên ───────────────────────
    Private Sub dgvEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellClick
        If e.RowIndex < 0 Then Return
        ' Không chuyển tab khi người dùng chỉ tích chọn checkbox.
        Dim chiSoCotCheck As Integer = dgvEmployee.Columns("colChk").Index
        If e.ColumnIndex = chiSoCotCheck Then Return
        Dim row = dgvEmployee.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim id = CInt(row.Tag)
        SelectEmployee(id)
        ShowTab(2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SELECT EMPLOYEE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub SelectEmployee(id As Integer)
        _selectedId = id
        Dim emp = _allEmps.FirstOrDefault(Function(x) x.Id = id)
        If emp.Id = 0 Then Return

        ' Fill header
        Dim clr = _avatarColors(emp.Id Mod _avatarColors.Length)
        pnlAvatarCircle.Tag = GetInitials(emp.Name)
        pnlAvatarCircle.BackColor = clr
        pnlAvatarCircle.Invalidate()

        lblDetailName.Text = emp.Name
        lblDetailCode.Text = $"{emp.Code}  ·  {emp.Dept}  ·  {emp.Job}"

        If emp.Status = 1 Then
            lblDetailStatus.Text = "● Đang làm việc"
            lblDetailStatus.ForeColor = Color.FromArgb(76, 175, 80)
            lblDetailStatus.BackColor = Color.FromArgb(20, 76, 175, 80)
        Else
            lblDetailStatus.Text = "○ Nghỉ việc"
            lblDetailStatus.ForeColor = Color.FromArgb(123, 139, 178)
            lblDetailStatus.BackColor = Color.FromArgb(20, 123, 139, 178)
        End If

        ' Fill form fields
        txtCode.Text = emp.Code
        txtFName.Text = emp.Name
        cboGender.SelectedIndex = If(emp.Gender = 1, 0, If(emp.Gender = 0, 1, 2))
        dtpBirth.Value = If(emp.Birth = Date.MinValue, Date.Now, emp.Birth)
        txtCccd.Text = emp.Cccd
        cboFStatus.SelectedIndex = If(emp.Status = 1, 0, 1)
        txtAddress.Text = emp.Address
        txtEmail.Text = emp.Email
        txtPhone.Text = emp.Phone
        txtBank.Text = emp.Bank
        txtNote.Text = emp.Note

        ' Load contracts for tab 3
        LoadContractCards(id, emp.Name)
    End Sub

    ' ── Avatar circle paint ───────────────────────────────────
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
                             (pnl.Width - sz.Width) / 2,
                             (pnl.Height - sz.Height) / 2)
            End Using : End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  CONTRACT CARDS (Tab 3)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadContractCards(empId As Integer, empName As String)
        lblContractEmp.Text = $"Hợp đồng của:  {empName}"
        pnlContractScroll.Controls.Clear()

        Dim contracts = _allContracts.Where(Function(c) c.EmpId = empId).ToList()

        If contracts.Count = 0 Then
            Dim lblEmpty = New Label() With {
                .Text = "Nhân viên chưa có hợp đồng nào",
                .ForeColor = Color.FromArgb(45, 55, 85),
                .Font = New Font("Microsoft YaHei UI", 10.0!),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Dock = DockStyle.Fill
            }
            pnlContractScroll.Controls.Add(lblEmpty)
            Return
        End If

        ' Build cards top-to-bottom (last contract on top = most recent)
        Dim yPos = 0
        For i = contracts.Count - 1 To 0 Step -1
            Dim c = contracts(i)
            Dim card = BuildContractCard(c, yPos)
            pnlContractScroll.Controls.Add(card)
            yPos += card.Height + 10
        Next
    End Sub

    Private Function BuildContractCard(c As ContractRow, y As Integer) As Panel
        Dim card = New Panel() With {
            .BackColor = Color.FromArgb(30, 34, 53),
            .Location = New Point(0, y),
            .Padding = New Padding(16, 12, 16, 12),
            .Size = New Size(pnlContractScroll.ClientSize.Width - 32, 140),
            .Cursor = Cursors.Hand
        }

        ' Code + status
        Dim lblCode = New Label() With {
            .Text = c.Code,
            .Font = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold),
            .ForeColor = Color.FromArgb(232, 236, 240),
            .AutoSize = True,
            .Location = New Point(16, 14)
        }

        Dim lblStatus = New Label() With {
            .Text = If(c.Active, "● Hiện hành", "○ Hết hạn"),
            .Font = New Font("Microsoft YaHei UI", 8.5!),
            .ForeColor = If(c.Active, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178)),
            .BackColor = If(c.Active, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178)),
            .AutoSize = True,
            .Padding = New Padding(6, 2, 6, 2),
            .Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles),
            .Location = New Point(card.Width - 140, 14)
        }

        ' Dates + type
        Dim lblDates = New Label() With {
            .Text = $"{c.StartDate:dd/MM/yyyy}  →  {c.EndDate:dd/MM/yyyy}  ·  {c.ContractType}",
            .Font = New Font("Microsoft YaHei UI", 8.5!),
            .ForeColor = Color.FromArgb(123, 139, 178),
            .AutoSize = True,
            .Location = New Point(16, 40)
        }

        ' Divider line
        Dim divider = New Panel() With {
            .BackColor = Color.FromArgb(42, 48, 80),
            .Location = New Point(16, 64),
            .Size = New Size(card.Width - 32, 1)
        }

        ' Info grid: 3 columns
        Dim lblS1 = New Label() With {.Text = "Lương cơ bản", .Font = New Font("Microsoft YaHei UI", 8.0!), .ForeColor = Color.FromArgb(123, 139, 178), .AutoSize = True, .Location = New Point(16, 74)}
        Dim lblV1 = New Label() With {.Text = modDB.FormatVND(c.BaseSalary), .Font = New Font("Microsoft YaHei UI", 10.0!, FontStyle.Bold), .ForeColor = Color.FromArgb(74, 158, 255), .AutoSize = True, .Location = New Point(16, 92)}

        Dim lblS2 = New Label() With {.Text = "Vị trí", .Font = New Font("Microsoft YaHei UI", 8.0!), .ForeColor = Color.FromArgb(123, 139, 178), .AutoSize = True, .Location = New Point(200, 74)}
        Dim lblV2 = New Label() With {.Text = c.Position, .Font = New Font("Microsoft YaHei UI", 9.5!, FontStyle.Bold), .ForeColor = Color.FromArgb(232, 236, 240), .AutoSize = True, .Location = New Point(200, 92)}

        Dim lblS3 = New Label() With {.Text = "Phòng ban", .Font = New Font("Microsoft YaHei UI", 8.0!), .ForeColor = Color.FromArgb(123, 139, 178), .AutoSize = True, .Location = New Point(420, 74)}
        Dim lblV3 = New Label() With {.Text = c.Dept, .Font = New Font("Microsoft YaHei UI", 9.5!, FontStyle.Bold), .ForeColor = Color.FromArgb(232, 236, 240), .AutoSize = True, .Location = New Point(420, 92)}

        card.Controls.Add(lblCode)
        card.Controls.Add(lblStatus)
        card.Controls.Add(lblDates)
        card.Controls.Add(divider)
        card.Controls.Add(lblS1)
        card.Controls.Add(lblV1)
        card.Controls.Add(lblS2)
        card.Controls.Add(lblV2)
        card.Controls.Add(lblS3)
        card.Controls.Add(lblV3)

        Return card
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TOOLBAR EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _selectedId = -1
        ClearForm()
        ShowTab(2)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDept.SelectedIndex <= 0, "", cboDept.SelectedItem.ToString())
        Dim status = cboStatus.SelectedIndex  ' 0=all 1=active 2=inactive

        _filtered = _allEmps.Where(Function(emp)
                                       Dim matchQ = q = "" OrElse
                                                    emp.Name.ToLower().Contains(q) OrElse
                                                    emp.Code.ToLower().Contains(q) OrElse
                                                    emp.Email.ToLower().Contains(q)
                                       Dim matchDept = dept = "" OrElse emp.Dept = dept
                                       Dim matchStatus = status = 0 OrElse
                                                         (status = 1 AndAlso emp.Status = 1) OrElse
                                                         (status = 2 AndAlso emp.Status = 0)
                                       Return matchQ AndAlso matchDept AndAlso matchStatus
                                   End Function).ToList()

        RenderTable()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp khi kết nối DB.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM ACTIONS (Tab 2)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập họ tên nhân viên.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus()
            Return
        End If

        ' Trong thực tế: gọi modDB.ExecScalar() INSERT/UPDATE
        MessageBox.Show($"Đã lưu thông tin nhân viên: {txtFName.Text}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        _selectedId = -1
        ClearForm()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId < 0 Then
            MessageBox.Show("Chưa chọn nhân viên.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim emp = _allEmps.FirstOrDefault(Function(x) x.Id = _selectedId)
        Dim result = MessageBox.Show(
            $"Bạn có chắc muốn xóa nhân viên ""{emp.Name}""?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            ' Trong thực tế: gọi DELETE hoặc set status=0
            MessageBox.Show("Đã xóa (mock data).", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selectedId = -1
            ClearForm()
            ShowTab(1)
        End If
    End Sub

    Private Sub btnAddContract_Click(sender As Object, e As EventArgs) Handles btnAddContract.Click
        If _selectedId < 0 Then
            MessageBox.Show("Vui lòng chọn nhân viên từ tab Danh sách trước.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        MessageBox.Show("Tính năng thêm hợp đồng sẽ được phát triển tiếp.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── txtFName live-update header ───────────────────────────
    Private Sub txtFName_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged
        If Not String.IsNullOrWhiteSpace(txtFName.Text) Then
            lblDetailName.Text = txtFName.Text
            pnlAvatarCircle.Tag = GetInitials(txtFName.Text)
            pnlAvatarCircle.Invalidate()
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub ClearForm()
        txtCode.Clear()
        txtFName.Clear()
        cboGender.SelectedIndex = 0
        dtpBirth.Value = Date.Now.AddYears(-25)
        txtCccd.Clear()
        cboFStatus.SelectedIndex = 0
        txtAddress.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtBank.Clear()
        txtNote.Clear()

        lblDetailName.Text = "Thêm nhân viên mới"
        lblDetailCode.Text = "Điền thông tin bên dưới"
        lblDetailStatus.Text = "● Đang làm việc"
        lblDetailStatus.ForeColor = Color.FromArgb(76, 175, 80)
        lblDetailStatus.BackColor = Color.FromArgb(20, 76, 175, 80)
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

    Private Sub RepositionFooterBtns()
        btnClear.Left = pnlDetailFooter.Width - btnSave.Width - btnClear.Width - 20
        btnSave.Left = pnlDetailFooter.Width - btnSave.Width - 14
    End Sub

    Private Sub RepositionContractBtn()
        btnAddContract.Left = pnlContractFooter.Width - btnAddContract.Width - 14
    End Sub

    Private Sub RepositionToolbarBtns()
        btnExport.Left = pnlToolbar.Width - btnAdd.Width - btnExport.Width - 20
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
    End Sub

    ' ── Resize: keep DGV filling tab ─────────────────────────
    Private Sub pnlTab1_Resize(sender As Object, e As EventArgs) Handles pnlTab1.Resize
        dgvEmployee.Size = New Size(pnlTab1.Width, pnlTab1.Height - pnlTableFooter.Height)
    End Sub

End Class
