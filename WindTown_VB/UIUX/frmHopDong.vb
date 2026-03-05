Public Class frmHopDong
    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        loadControls()
        CauHinhDTGV()
        TaoCotHopDong()
        TaoCotChucNang()
        CauHinhQuyenCot()

        LoadDuLieu()
    End Sub

    ' ============== Load ảnh cho các nút chức năng ==============
    Private Sub loadControls()
        btnSearch.ResizeImageButton() '.Image = ResizeImage(My.Resources.search, 26, 26)
    End Sub

    Private Function ResizeImage(img As Image, newWidth As Integer, newHeight As Integer) As Image
        Dim bmp As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return bmp
    End Function

    ' =============== Cấu hình chung cho DataGridView ===============
    Private Sub CauHinhDTGV()

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
            .RowTemplate.Height = 60
        End With

    End Sub
    Private Sub CauHinhQuyenCot()

        For Each col As DataGridViewColumn In dtgvDSHopDong.Columns
            col.ReadOnly = True
        Next

        dtgvDSHopDong.Columns("colChon").ReadOnly = False
        dtgvDSHopDong.Columns("colExport").ReadOnly = False
        dtgvDSHopDong.Columns("colEdit").ReadOnly = False
        dtgvDSHopDong.Columns("colDelete").ReadOnly = False

    End Sub

    ' ============= Tạo cột dữ liệu cho DataGridView ===============
    Private Sub TaoCotHopDong()

        dtgvDSHopDong.Columns.Clear()

        'Checkbox
        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        dtgvDSHopDong.Columns.Add(colChon)

        'Nhân viên
        Dim colNhanVien As New DataGridViewTextBoxColumn()
        colNhanVien.Name = "colNhanVien"
        colNhanVien.HeaderText = "Nhân viên"
        colNhanVien.Width = 180
        colNhanVien.Frozen = True
        dtgvDSHopDong.Columns.Add(colNhanVien)

        'Tên hợp đồng
        Dim colTenHopDong As New DataGridViewTextBoxColumn()
        colTenHopDong.Name = "colTenHopDong"
        colTenHopDong.HeaderText = "Tên hợp đồng"
        colTenHopDong.Width = 180
        dtgvDSHopDong.Columns.Add(colTenHopDong)

        'Loại hợp đồng
        Dim colLoaiHopDong As New DataGridViewTextBoxColumn()
        colLoaiHopDong.Name = "colLoaiHopDong"
        colLoaiHopDong.HeaderText = "Loại hợp đồng"
        colLoaiHopDong.Width = 200
        dtgvDSHopDong.Columns.Add(colLoaiHopDong)

        'Trạng thái
        Dim colTrangThai As New DataGridViewTextBoxColumn()
        colTrangThai.Name = "colTrangThai"
        colTrangThai.HeaderText = "Trạng thái hợp đồng"
        colTrangThai.Width = 160
        dtgvDSHopDong.Columns.Add(colTrangThai)

        'Chế độ lương
        Dim colCheDoLuong As New DataGridViewTextBoxColumn()
        colCheDoLuong.Name = "colCheDoLuong"
        colCheDoLuong.HeaderText = "Chế độ lương"
        colCheDoLuong.Width = 180
        dtgvDSHopDong.Columns.Add(colCheDoLuong)

        'Hình thức hưởng lương
        Dim colHinhThucLuong As New DataGridViewTextBoxColumn()
        colHinhThucLuong.Name = "colHinhThucLuong"
        colHinhThucLuong.HeaderText = "Hình thức hưởng lương"
        colHinhThucLuong.Width = 180
        dtgvDSHopDong.Columns.Add(colHinhThucLuong)

        '% Hưởng lương
        Dim colPhanTramLuong As New DataGridViewTextBoxColumn()
        colPhanTramLuong.Name = "colPhanTramLuong"
        colPhanTramLuong.HeaderText = "% Hưởng lương"
        colPhanTramLuong.Width = 120
        dtgvDSHopDong.Columns.Add(colPhanTramLuong)

        'Ngày bắt đầu
        Dim colNgayBatDau As New DataGridViewTextBoxColumn()
        colNgayBatDau.Name = "colNgayBatDau"
        colNgayBatDau.HeaderText = "Ngày bắt đầu"
        colNgayBatDau.Width = 130
        dtgvDSHopDong.Columns.Add(colNgayBatDau)

        'Ngày hết hạn
        Dim colNgayHetHan As New DataGridViewTextBoxColumn()
        colNgayHetHan.Name = "colNgayHetHan"
        colNgayHetHan.HeaderText = "Ngày hết hạn"
        colNgayHetHan.Width = 130
        dtgvDSHopDong.Columns.Add(colNgayHetHan)


    End Sub

    ' =============== Tạo cột chức năng (Xuất file, chỉnh sửa, xóa) ===============
    Private Sub TaoCotChucNang()

        'Xuất file
        Dim colExport As New DataGridViewImageColumn()
        colExport.Name = "colExport"
        colExport.HeaderText = ""
        colExport.Image = My.Resources.word
        colExport.Width = 40
        'colExport.ResizeImageCol()
        colExport.ImageLayout = DataGridViewImageCellLayout.Zoom
        dtgvDSHopDong.Columns.Add(colExport)

        'Chỉnh sửa
        Dim colEdit As New DataGridViewImageColumn()
        colEdit.Name = "colEdit"
        colEdit.HeaderText = ""
        colEdit.Image = My.Resources.compose
        colEdit.Width = 40
        'colEdit.ResizeImageCol()
        colEdit.ImageLayout = DataGridViewImageCellLayout.Zoom
        dtgvDSHopDong.Columns.Add(colEdit)

        'Xóa
        Dim colDelete As New DataGridViewImageColumn()
        colDelete.Name = "colDelete"
        colDelete.HeaderText = ""
        colDelete.Image = My.Resources.bin
        colDelete.Width = 40
        'colDelete.ResizeImageCol()
        colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom
        dtgvDSHopDong.Columns.Add(colDelete)

    End Sub

    ' ============ Sử lý sư kiện click vào các nút chức năng ============
    Private Sub dtgvDSHopDong_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgvDSHopDong.CellClick

        If e.RowIndex < 0 Then Exit Sub

        If dtgvDSHopDong.Columns(e.ColumnIndex).Name = "colExport" Then
            MessageBox.Show("Xuất hợp đồng")
        End If

        If dtgvDSHopDong.Columns(e.ColumnIndex).Name = "colEdit" Then
            MessageBox.Show("Chỉnh sửa hợp đồng")
        End If

        If dtgvDSHopDong.Columns(e.ColumnIndex).Name = "colDelete" Then
            MessageBox.Show("Xóa hợp đồng")
        End If

    End Sub
    '=========== Xử lý sự kiện khi checkbox được chọn để cập nhật trạng thái chọn =============
    Private Sub dtgvDSHopDong_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtgvDSHopDong.CurrentCellDirtyStateChanged
        If dtgvDSHopDong.IsCurrentCellDirty Then
            dtgvDSHopDong.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    ' =============== Load dữ liệu lên DataGridView ===============
    Private Sub LoadDuLieu()

        Dim ds = TaoDuLieuDemo()

        dtgvDSHopDong.Rows.Clear()

        For Each hd In ds

            dtgvDSHopDong.Rows.Add(
                False,
                hd.TenNhanVien,
                hd.TenHopDong,
                hd.LoaiHopDong,
                hd.TrangThai,
                hd.CheDoLuong,
                hd.HinhThucLuong,
                hd.PhanTramLuong,
                hd.NgayBatDau.ToString("dd/MM/yyyy"),
                hd.NgayHetHan
            )

        Next

    End Sub

    ' =============== Tạo dữ liệu demo để hiển thị lên DataGridView ===============
    Private Function TaoDuLieuDemo() As List(Of HopDong)

        Dim ds As New List(Of HopDong)

        ds.Add(New HopDong With {
            .MaHopDong = "HD001",
            .TenNhanVien = "Luong Thanh Tung",
            .TenHopDong = "Hợp đồng thử việc",
            .LoaiHopDong = "Không xác định thời hạn",
            .TrangThai = "Có hiệu lực",
            .CheDoLuong = "Chế độ lương mặc định",
            .HinhThucLuong = "Theo thỏa thuận",
            .PhanTramLuong = 1,
            .NgayBatDau = #03/03/2026#,
            .NgayHetHan = "Không thời hạn"
        })

        ds.Add(New HopDong With {
            .MaHopDong = "HD002",
            .TenNhanVien = "Nguyễn Văn A",
            .TenHopDong = "Hợp đồng chính thức",
            .LoaiHopDong = "12 tháng",
            .TrangThai = "Có hiệu lực",
            .CheDoLuong = "Lương cơ bản",
            .HinhThucLuong = "Theo KPI",
            .PhanTramLuong = 1,
            .NgayBatDau = #01/01/2026#,
            .NgayHetHan = "01/01/2027"
        })

        ds.Add(New HopDong With {
            .MaHopDong = "HD003",
            .TenNhanVien = "Trần Thị B",
            .TenHopDong = "Hợp đồng thời vụ",
            .LoaiHopDong = "6 tháng",
            .TrangThai = "Hết hạn",
            .CheDoLuong = "Lương thời vụ",
            .HinhThucLuong = "Theo ngày",
            .PhanTramLuong = 1,
            .NgayBatDau = #01/06/2025#,
            .NgayHetHan = "01/12/2025"
        })

        Return ds

    End Function


End Class