Imports System.Drawing

Public Class formLeaveCategory
    Private Class LeaveCategory
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property Paid As String
        Public Property Days As Integer
        Public Property Status As String
        Public Property Note As String
    End Class

    Private _categories As List(Of LeaveCategory)
    Private _filtered As List(Of LeaveCategory)
    Private _selectedId As Integer = -1

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formLeaveCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMockData()
        InitFilters()
        InitTooltips()
        BindList(_categories)
        If _categories.Count > 0 Then
            SelectCategory(_categories(0).Id)
        Else
            ClearForm()
        End If
    End Sub

    Private Sub InitMockData()
        _categories = New List(Of LeaveCategory) From {
            New LeaveCategory With {.Id = 1, .Code = "LC-AN", .Name = "Phép năm", .Paid = "Có", .Days = 12, .Status = "Active", .Note = "Áp dụng cho nhân viên chính thức."},
            New LeaveCategory With {.Id = 2, .Code = "LC-TS", .Name = "Thai sản", .Paid = "Có", .Days = 180, .Status = "Active", .Note = "Theo quy định bảo hiểm."},
            New LeaveCategory With {.Id = 3, .Code = "LC-KL", .Name = "Không lương", .Paid = "Không", .Days = 30, .Status = "Inactive", .Note = "Cần duyệt quản lý."},
            New LeaveCategory With {.Id = 4, .Code = "LC-OM", .Name = "Ốm đau", .Paid = "Có", .Days = 10, .Status = "Active", .Note = ""}
        }
        _filtered = New List(Of LeaveCategory)(_categories)
    End Sub

    Private Sub InitFilters()
        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang dùng", "Ngừng"})
        cboStatusFilter.SelectedIndex = 0

        cboPaid.Items.Clear()
        cboPaid.Items.AddRange(New Object() {"Có", "Không"})

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Đang dùng", "Ngừng"})
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(txtCode, "Bắt buộc")
        toolTip1.SetToolTip(txtName, "Bắt buộc")
        toolTip1.SetToolTip(cboPaid, "Bắt buộc")
    End Sub

    Private Sub BindList(data As List(Of LeaveCategory))
        dgvLeaveCat.Rows.Clear()
        For Each item In data
            Dim st = If(item.Status = "Active", "Đang dùng", "Ngừng")
            dgvLeaveCat.Rows.Add(item.Code, item.Name, item.Paid, item.Days, st)
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count}"
    End Sub

    Private Sub BindDetail(item As LeaveCategory)
        txtCode.Text = item.Code
        txtName.Text = item.Name
        cboPaid.SelectedItem = item.Paid
        cboStatus.SelectedItem = If(item.Status = "Active", "Đang dùng", "Ngừng")
        txtDays.Text = item.Days.ToString()
        txtNote.Text = item.Note
    End Sub

    Private Sub SelectCategory(id As Integer)
        _selectedId = id
        Dim item = _categories.FirstOrDefault(Function(x) x.Id = id)
        If item Is Nothing Then
            ClearForm()
            Return
        End If
        BindDetail(item)
    End Sub

    Private Sub ClearForm()
        txtCode.Text = ""
        txtName.Text = ""
        If cboPaid.Items.Count > 0 Then cboPaid.SelectedIndex = 0
        If cboStatus.Items.Count > 0 Then cboStatus.SelectedIndex = 0
        txtDays.Text = ""
        txtNote.Text = ""
        ResetValidation()
    End Sub

    Private Sub ResetValidation()
        SetInvalid(txtCode, False)
        SetInvalid(txtName, False)
        SetInvalid(cboPaid, False)
    End Sub

    Private Sub SetInvalid(ctrl As Control, isInvalid As Boolean)
        If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox Then
            ctrl.BackColor = If(isInvalid, _invalidBack, _inputBack)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _selectedId = -1
        ClearForm()
    End Sub

    Private Sub dgvLeaveCat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLeaveCat.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvLeaveCat.Rows.Count Then Return
        Dim code = Convert.ToString(dgvLeaveCat.Rows(e.RowIndex).Cells(0).Value)
        Dim item = _categories.FirstOrDefault(Function(x) x.Code = code)
        If item IsNot Nothing Then
            SelectCategory(item.Id)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim keyword = txtSearch.Text.Trim().ToLower()
        Dim statusFilter = cboStatusFilter.SelectedItem?.ToString()

        _filtered = _categories.Where(Function(c)
                                          Dim matchKeyword = String.IsNullOrWhiteSpace(keyword) OrElse c.Code.ToLower().Contains(keyword) OrElse c.Name.ToLower().Contains(keyword)
                                          Dim matchStatus = True
                                          If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter <> "Tất cả trạng thái" Then
                                              matchStatus = (statusFilter = "Đang dùng" AndAlso c.Status = "Active") OrElse (statusFilter = "Ngừng" AndAlso c.Status = "Inactive")
                                          End If
                                          Return matchKeyword AndAlso matchStatus
                                      End Function).ToList()

        BindList(_filtered)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResetValidation()
        Dim invalid = False

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            SetInvalid(txtCode, True)
            invalid = True
        End If
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            SetInvalid(txtName, True)
            invalid = True
        End If
        If cboPaid.SelectedIndex < 0 Then
            SetInvalid(cboPaid, True)
            invalid = True
        End If

        If invalid Then
            MessageBox.Show("Vui lòng nhập đủ: Mã loại, Tên loại, Hưởng lương", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("✓ Đã lưu (mock)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
