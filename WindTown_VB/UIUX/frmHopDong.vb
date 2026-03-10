Imports System.Linq

Public Class frmHopDong
    Private ReadOnly _service As New ContractService()
    Private _contracts As New List(Of Contract)()
    Private ReadOnly _binding As New BindingSource()

    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        InitFilters()
        InitGrid()
        LoadData()
        ApplyFilters()
    End Sub

    Private Sub InitFilters()
        btnSearch.Image = ResizeImage(My.Resources.search, 20, 20)

        cbbxTrangThai.DataSource = New List(Of KeyValuePair(Of Integer, String)) From {
            New KeyValuePair(Of Integer, String)(-1, "Tất cả"),
            New KeyValuePair(Of Integer, String)(1, "Đang hoạt động"),
            New KeyValuePair(Of Integer, String)(0, "Ngừng hoạt động")
        }
        cbbxTrangThai.DisplayMember = "Value"
        cbbxTrangThai.ValueMember = "Key"
        cbbxTrangThai.SelectedValue = -1

        cbbxThoiGianHD.DataSource = New List(Of KeyValuePair(Of Integer, String)) From {
            New KeyValuePair(Of Integer, String)(0, "Không lọc ngày"),
            New KeyValuePair(Of Integer, String)(1, "Theo ngày bắt đầu"),
            New KeyValuePair(Of Integer, String)(2, "Theo ngày kết thúc")
        }
        cbbxThoiGianHD.DisplayMember = "Value"
        cbbxThoiGianHD.ValueMember = "Key"
        cbbxThoiGianHD.SelectedValue = 0

        AddHandler btnSearch.Click, Sub() ApplyFilters()
        AddHandler tbxSearch.KeyDown, AddressOf tbxSearch_KeyDown
        AddHandler cbbxTrangThai.SelectedIndexChanged, Sub() ApplyFilters()
        AddHandler dtpkTuNgay.ValueChanged, Sub() ApplyFilters()
        AddHandler btnThemHD.Click, AddressOf btnThemHD_Click
    End Sub

    Private Sub tbxSearch_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ApplyFilters()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Function ResizeImage(img As Image, newWidth As Integer, newHeight As Integer) As Image
        Dim bmp As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return bmp
    End Function

    Private Sub InitGrid()
        With dtgvDSHopDong
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .ColumnHeadersHeight = 40
            .RowTemplate.Height = 48
        End With

        BuildColumns()
        dtgvDSHopDong.DataSource = _binding

        AddHandler dtgvDSHopDong.CellClick, AddressOf dtgvDSHopDong_CellClick
    End Sub

    Private Sub BuildColumns()
        dtgvDSHopDong.Columns.Clear()

        Dim colChon As New DataGridViewCheckBoxColumn() With {
            .Name = "colChon",
            .HeaderText = "",
            .Width = 40,
            .Frozen = True
        }
        dtgvDSHopDong.Columns.Add(colChon)

        Dim colCode As New DataGridViewTextBoxColumn() With {
            .Name = "colCode",
            .HeaderText = "Mã hợp đồng",
            .DataPropertyName = "code",
            .Width = 140,
            .Frozen = True
        }
        dtgvDSHopDong.Columns.Add(colCode)

        Dim colNhanVien As New DataGridViewTextBoxColumn() With {
            .Name = "colNhanVien",
            .HeaderText = "Nhân viên",
            .DataPropertyName = "Employee_UI",
            .Width = 180
        }
        dtgvDSHopDong.Columns.Add(colNhanVien)

        Dim colStart As New DataGridViewTextBoxColumn() With {
            .Name = "colStart",
            .HeaderText = "Ngày bắt đầu",
            .DataPropertyName = "start_date",
            .Width = 120
        }
        colStart.DefaultCellStyle.Format = "dd-MM-yyyy"
        dtgvDSHopDong.Columns.Add(colStart)

        Dim colEnd As New DataGridViewTextBoxColumn() With {
            .Name = "colEnd",
            .HeaderText = "Ngày kết thúc",
            .DataPropertyName = "end_date",
            .Width = 120
        }
        colEnd.DefaultCellStyle.Format = "dd-MM-yyyy"
        dtgvDSHopDong.Columns.Add(colEnd)

        Dim colSalary As New DataGridViewTextBoxColumn() With {
            .Name = "colSalary",
            .HeaderText = "Lương cơ bản",
            .DataPropertyName = "base_salary",
            .Width = 140
        }
        colSalary.DefaultCellStyle.Format = "N0"
        dtgvDSHopDong.Columns.Add(colSalary)

        Dim colStatus As New DataGridViewTextBoxColumn() With {
            .Name = "colStatus",
            .HeaderText = "Trạng thái",
            .DataPropertyName = "status_UI",
            .Width = 140
        }
        dtgvDSHopDong.Columns.Add(colStatus)

        Dim colNote As New DataGridViewTextBoxColumn() With {
            .Name = "colNote",
            .HeaderText = "Ghi chú",
            .DataPropertyName = "note",
            .Width = 220
        }
        dtgvDSHopDong.Columns.Add(colNote)

        Dim colExport As New DataGridViewImageColumn() With {
            .Name = "colExport",
            .HeaderText = "",
            .Image = My.Resources.word,
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        dtgvDSHopDong.Columns.Add(colExport)

        Dim colEdit As New DataGridViewImageColumn() With {
            .Name = "colEdit",
            .HeaderText = "",
            .Image = My.Resources.compose,
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        dtgvDSHopDong.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewImageColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Image = My.Resources.bin,
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        dtgvDSHopDong.Columns.Add(colDelete)

        For Each col As DataGridViewColumn In dtgvDSHopDong.Columns
            col.ReadOnly = True
        Next
        dtgvDSHopDong.Columns("colChon").ReadOnly = False
        dtgvDSHopDong.Columns("colExport").ReadOnly = False
        dtgvDSHopDong.Columns("colEdit").ReadOnly = False
        dtgvDSHopDong.Columns("colDelete").ReadOnly = False
    End Sub

    Private Sub LoadData()
        Dim response = _service.Execute(DataIntent.GetList)
        _contracts = TryCast(response?.Data, IEnumerable(Of Contract))?.Where(Function(c) c IsNot Nothing).ToList()
        If _contracts Is Nothing Then _contracts = New List(Of Contract)()
    End Sub

    Private Sub ApplyFilters()
        If _contracts Is Nothing Then Return

        Dim query = If(tbxSearch.Text, String.Empty).Trim()
        Dim statusFilter = Convert.ToInt32(cbbxTrangThai.SelectedValue)
        Dim dateMode = Convert.ToInt32(cbbxThoiGianHD.SelectedValue)

        Dim fromDate = dtpkTuNgay.Value.Date
        Dim toDate = dtpkDenNgay.Value.Date
        If fromDate > toDate Then
            Dim tmp = fromDate
            fromDate = toDate
            toDate = tmp
        End If

        Dim filtered = _contracts.Where(
            Function(c)
                If c Is Nothing Then Return False

                If statusFilter <> -1 AndAlso c.status <> statusFilter Then Return False

                If Not String.IsNullOrWhiteSpace(query) Then
                    Dim code = If(c.code, String.Empty)
                    Dim empName = If(c.Employee?.name, String.Empty)
                    Dim empCode = If(c.Employee?.code, String.Empty)
                    If code.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       empName.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       empCode.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 Then
                        Return False
                    End If
                End If

                If dateMode = 1 Then
                    If Not c.start_date.HasValue Then Return False
                    If c.start_date.Value.Date < fromDate OrElse c.start_date.Value.Date > toDate Then Return False
                ElseIf dateMode = 2 Then
                    If Not c.end_date.HasValue Then Return False
                    If c.end_date.Value.Date < fromDate OrElse c.end_date.Value.Date > toDate Then Return False
                End If

                Return True
            End Function).ToList()

        _binding.DataSource = filtered
    End Sub

    Private Sub btnThemHD_Click(sender As Object, e As EventArgs)
        Dim data As New Contract()
        Using crud As New frmHopDongEdit(data, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _service.Execute(DataIntent.Insert, data)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Thêm hợp đồng không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilters()
    End Sub

    Private Sub dtgvDSHopDong_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dtgvDSHopDong.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Contract)
        If data Is Nothing Then Return

        Dim colName = dtgvDSHopDong.Columns(e.ColumnIndex).Name

        If colName = "colExport" Then
            MessageBox.Show("Xuất hợp đồng đang được chuẩn bị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If colName = "colEdit" Then
            Dim clone = Utils.DeepClone(data)
            Using crud As New frmHopDongEdit(clone)
                If crud.ShowDialog(Me) <> DialogResult.OK Then Return
            End Using

            Dim result = _service.Execute(DataIntent.Update, clone)
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Cập nhật hợp đồng không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilters()
            Return
        End If

        If colName = "colDelete" Then
            If MessageBox.Show("Xác nhận xóa hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim result = _service.Execute(DataIntent.SoftDeleteMany, New List(Of Contract) From {data})
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Xóa hợp đồng không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilters()
        End If
    End Sub
End Class
