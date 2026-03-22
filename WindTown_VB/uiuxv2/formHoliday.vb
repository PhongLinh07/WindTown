Imports System.Drawing

Public Class formHoliday
    Private Class HolidayItem
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property HolidayDate As Date
        Public Property Factor As Decimal
        Public Property Year As Integer
        Public Property Note As String
    End Class

    Private _holidays As List(Of HolidayItem)
    Private _filtered As List(Of HolidayItem)
    Private _selectedId As Integer = -1

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMockData()
        InitFilters()
        InitTooltips()
        BindList(_holidays)
        If _holidays.Count > 0 Then
            SelectHoliday(_holidays(0).Id)
        Else
            ClearForm()
        End If
    End Sub

    Private Sub InitMockData()
        _holidays = New List(Of HolidayItem) From {
            New HolidayItem With {.Id = 1, .Code = "HL-0101", .Name = "Tết Dương lịch", .HolidayDate = New Date(2026, 1, 1), .Factor = 2D, .Year = 2026, .Note = "Nghỉ 1 ngày."},
            New HolidayItem With {.Id = 2, .Code = "HL-0430", .Name = "Giải phóng miền Nam", .HolidayDate = New Date(2026, 4, 30), .Factor = 2D, .Year = 2026, .Note = ""},
            New HolidayItem With {.Id = 3, .Code = "HL-0501", .Name = "Quốc tế Lao động", .HolidayDate = New Date(2026, 5, 1), .Factor = 2D, .Year = 2026, .Note = ""},
            New HolidayItem With {.Id = 4, .Code = "HL-0902", .Name = "Quốc khánh", .HolidayDate = New Date(2026, 9, 2), .Factor = 3D, .Year = 2026, .Note = "Nghỉ 2 ngày."}
        }
        _filtered = New List(Of HolidayItem)(_holidays)
    End Sub

    Private Sub InitFilters()
        cboYearFilter.Items.Clear()
        cboYearFilter.Items.AddRange(New Object() {"Tất cả năm", "2025", "2026"})
        cboYearFilter.SelectedIndex = 0
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(txtCode, "Bắt buộc")
        toolTip1.SetToolTip(txtName, "Bắt buộc")
        toolTip1.SetToolTip(dtpDate, "Bắt buộc")
        toolTip1.SetToolTip(txtFactor, "Bắt buộc")
    End Sub

    Private Sub BindList(data As List(Of HolidayItem))
        dgvHoliday.Rows.Clear()
        For Each item In data
            dgvHoliday.Rows.Add(item.Code, item.Name, item.HolidayDate.ToString("dd/MM/yyyy"), "x" & item.Factor.ToString("0.#"), item.Year)
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count}"
    End Sub

    Private Sub BindDetail(item As HolidayItem)
        txtCode.Text = item.Code
        txtName.Text = item.Name
        dtpDate.Value = item.HolidayDate
        txtFactor.Text = item.Factor.ToString("0.#")
        txtYear.Text = item.Year.ToString()
        txtNote.Text = item.Note
    End Sub

    Private Sub SelectHoliday(id As Integer)
        _selectedId = id
        Dim item = _holidays.FirstOrDefault(Function(x) x.Id = id)
        If item Is Nothing Then
            ClearForm()
            Return
        End If
        BindDetail(item)
    End Sub

    Private Sub ClearForm()
        txtCode.Text = ""
        txtName.Text = ""
        dtpDate.Value = Date.Today
        txtFactor.Text = ""
        txtYear.Text = Date.Today.Year.ToString()
        txtNote.Text = ""
        ResetValidation()
    End Sub

    Private Sub ResetValidation()
        SetInvalid(txtCode, False)
        SetInvalid(txtName, False)
        SetInvalid(dtpDate, False)
        SetInvalid(txtFactor, False)
    End Sub

    Private Sub SetInvalid(ctrl As Control, isInvalid As Boolean)
        If TypeOf ctrl Is TextBox Then
            ctrl.BackColor = If(isInvalid, _invalidBack, _inputBack)
        ElseIf TypeOf ctrl Is DateTimePicker Then
            Dim dtp = CType(ctrl, DateTimePicker)
            dtp.CalendarMonthBackground = If(isInvalid, _invalidBack, _inputBack)
            dtp.BackColor = If(isInvalid, _invalidBack, _inputBack)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _selectedId = -1
        ClearForm()
    End Sub

    Private Sub dgvHoliday_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHoliday.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvHoliday.Rows.Count Then Return
        Dim code = Convert.ToString(dgvHoliday.Rows(e.RowIndex).Cells(0).Value)
        Dim item = _holidays.FirstOrDefault(Function(x) x.Code = code)
        If item IsNot Nothing Then
            SelectHoliday(item.Id)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboYearFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYearFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim keyword = txtSearch.Text.Trim().ToLower()
        Dim yearFilter = cboYearFilter.SelectedItem?.ToString()

        _filtered = _holidays.Where(Function(h)
                                        Dim matchKeyword = String.IsNullOrWhiteSpace(keyword) OrElse h.Code.ToLower().Contains(keyword) OrElse h.Name.ToLower().Contains(keyword)
                                        Dim matchYear = True
                                        If Not String.IsNullOrWhiteSpace(yearFilter) AndAlso yearFilter <> "Tất cả năm" Then
                                            matchYear = h.Year.ToString() = yearFilter
                                        End If
                                        Return matchKeyword AndAlso matchYear
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
        If dtpDate.Value = Date.MinValue Then
            SetInvalid(dtpDate, True)
            invalid = True
        End If
        If String.IsNullOrWhiteSpace(txtFactor.Text) Then
            SetInvalid(txtFactor, True)
            invalid = True
        End If

        If invalid Then
            MessageBox.Show("Vui lòng nhập đủ: Mã ngày lễ, Tên ngày lễ, Ngày, Hệ số lương", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("✓ Đã lưu (mock)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
