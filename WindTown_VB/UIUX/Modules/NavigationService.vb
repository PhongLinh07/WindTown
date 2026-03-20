Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.InteropServices

Module NavigationService

    Private _mainPanel As Panel
    Private _mainHostForm As Form

    Private ReadOnly _history As New Stack(Of Type)
    Private _currentFormType As Type

    Private _isSwitchingFromMain As Boolean = False

    Public ReadOnly Property IsInitialized As Boolean
        Get
            Return _mainPanel IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property CanGoBack As Boolean
        Get
            Return _history.Count > 0
        End Get
    End Property

    ' G?i hàm này khi dang nh?p thành công d? thi?t l?p form chính và panel ch?a n?i dung
    Public Sub Initialize(mainHostForm As Form, mainPanel As Panel)

        If mainHostForm Is Nothing OrElse mainPanel Is Nothing Then Return

        _mainHostForm = mainHostForm
        _mainPanel = mainPanel

        _history.Clear()
        _currentFormType = Nothing

    End Sub

    ' formType ph?i là m?t l?p k? th?a t? Form
    Public Sub NavigateInMain(formType As Type, Optional addToHistory As Boolean = True)

        If Not IsInitialized Then Return
        If formType Is Nothing Then Return
        If Not GetType(Form).IsAssignableFrom(formType) Then Return

        If addToHistory AndAlso _currentFormType IsNot Nothing AndAlso _currentFormType IsNot formType Then
            _history.Push(_currentFormType)
        End If

        ShowInMain(formType)

    End Sub

    ' Generic version d? g?i d? dàng hon, ví d?: NavigateInMain(Of frmDashboard)()
    Public Sub NavigateInMain(Of T As Form)(Optional addToHistory As Boolean = True)
        NavigateInMain(GetType(T), addToHistory)
    End Sub

    ' Tr? v? true n?u dă quay l?i thành công, false n?u không th? quay l?i (ví d?: không có l?ch s?)
    Public Function GoBackInMain() As Boolean

        If Not CanGoBack Then Return False

        Dim previousType As Type = _history.Pop()
        ShowInMain(previousType)

        Return True

    End Function

    ' Đóng form hi?n t?i và m? form m?i ? c?p d? top-level (không trong panel)
    Public Sub SwitchTopLevel(currentForm As Form, nextForm As Form)

        If nextForm Is Nothing Then Return

        If currentForm IsNot Nothing AndAlso currentForm.InvokeRequired Then
            currentForm.BeginInvoke(New Action(Of Form, Form)(AddressOf SwitchTopLevel), currentForm, nextForm)
            Return
        End If

        Dim formHienTai = currentForm
        Dim formDich = nextForm

        Try
            HoTroPhongChu.ApDungPhongChu(formDich)
            My.Application.DatMainFormMoi(formDich)
            formDich.Show()

            If formHienTai IsNot Nothing AndAlso Not formHienTai.IsDisposed AndAlso Not formHienTai.Equals(formDich) Then
                formHienTai.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Không th? chuy?n form. Vui ḷng th? l?i. Chi ti?t: " & ex.Message, "L?i chuy?n form", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                If formDich IsNot Nothing AndAlso Not formDich.IsDisposed Then
                    formDich.Close()
                End If
            Catch
            End Try
        End Try

    End Sub

    ' Phiên b?n generic d? g?i d? dàng hon, ví d?: SwitchTopLevel(Of frmLogin)(Me)
    Public Sub SwitchTopLevel(Of T As {Form, New})(currentForm As Form)
        Dim nextForm As New T()
        SwitchTopLevel(currentForm, nextForm)
    End Sub

    ' Đang xu?t v? form dang nh?p, d?ng th?i dóng form chính n?u dang ? trong dó
    Public Sub LogoutToLogin(currentForm As Form)
        _isSwitchingFromMain = True
        NavigationService.SwitchTopLevel(Of frmLogin)(_mainHostForm)
    End Sub

    ' Khi form chính b? dóng, n?u dang chuy?n t? form chính sang form khác th́ không thoát ?ng d?ng
    Public Function ShouldTerminateWhenMainClosed() As Boolean

        If _isSwitchingFromMain Then
            _isSwitchingFromMain = False
            Return False
        End If

        Return True

    End Function

    ' Hàm n?i b? d? hi?n th? form trong panel chính, s? dispose form cu n?u có
    Private Sub ShowInMain(formType As Type)

        If _mainPanel Is Nothing Then Return

        For i As Integer = _mainPanel.Controls.Count - 1 To 0 Step -1
            Dim oldCtrl As Control = _mainPanel.Controls(i)
            _mainPanel.Controls.RemoveAt(i)
            oldCtrl.Dispose()
        Next

        Dim frm As Form = CType(Activator.CreateInstance(formType), Form)
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        HoTroPhongChu.ApDungPhongChu(frm)

        _mainPanel.Controls.Add(frm)
        frm.Show()

        _currentFormType = formType

    End Sub

End Module

Module HoTroPhongChu

    Private ReadOnly _phongChuUngDung As New Font("Segoe UI", 10.0!, FontStyle.Regular, GraphicsUnit.Point)

    Public Sub ApDungPhongChu(root As Control)
        If root Is Nothing Then Return
        ApDungPhongChuDeQuy(root, _phongChuUngDung)
        ' Chu?n hóa ti?ng Vi?t cho tiêu d?/nhăn hi?n th? trên form.
        UiVietHoa.ApDungVietHoa(root)
    End Sub

    Private Sub ApDungPhongChuDeQuy(ctrl As Control, phongChu As Font)
        ctrl.Font = phongChu
        For Each child As Control In ctrl.Controls
            ApDungPhongChuDeQuy(child, phongChu)
        Next
    End Sub

End Module

Module UiVietHoa

    'Danh sách mapping tiêu d?/nhăn không d?u sang có d?u d? Vi?t hóa UI.
    Private ReadOnly _bangThayThe As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"Tim", "T́m"},
        {"Tim kiem", "T́m ki?m"},
        {"Tim kiem...", "T́m ki?m..."},
        {"Dashboard", "B?ng di?u khi?n"},
        {"Refresh", "Làm m?i"},
        {"Checkin", "Ch?m công"},
        {"Approved Id", "Ngu?i duy?t"},
        {"Mo ta chuc vu:", "Mô t? ch?c v?:"},
        {"Chuc vu", "Ch?c v?"},
        {"Them chuc vu", "Thêm ch?c v?"},
        {"+ Them chuc vu", "+ Thêm ch?c v?"},
        {"Sua chuc vu", "S?a ch?c v?"},
        {"Xoa", "Xóa"},
        {"Sua", "S?a"},
        {"Them", "Thêm"},
        {"Cap nhat", "C?p nh?t"},
        {"Dang xuat", "Đang xu?t"},
        {"Dang nhap", "Đang nh?p"},
        {"Ket noi", "K?t n?i"},
        {"Cau hinh", "C?u h́nh"},
        {"Thong bao", "Thông báo"},
        {"Loi", "L?i"},
        {"Nhap lai", "Nh?p l?i"},
        {"Chi tiet:", "Chi ti?t:"},
        {"Mo ta", "Mô t?"},
        {"Ma", "Mă"},
        {"Ten", "Tên"},
        {"Ngay", "Ngày"},
        {"Trang thai", "Tr?ng thái"},
        {"Ghi chu", "Ghi chú"},
        {"Code", "Mă"},
        {"Name", "Tên"},
        {"Gender", "Gi?i tính"},
        {"Phone", "S? di?n tho?i"},
        {"Status", "Tr?ng thái"},
        {"StartDate", "Ngày b?t d?u"},
        {"DepartmentName", "Pḥng ban"},
        {"Position Id", "Ch?c v?"},
        {"Project Id", "D? án"},
        {"Employee Id", "Nhân viên"},
        {"LeaveCat Id", "Lo?i ngh?"},
        {"LoaiChinhSach", "Lo?i chính sách"},
        {"Luu", "Luu"},
        {"MaChinhSach", "Mă chính sách"},
        {"MaDuAn", "Mă d? án"},
        {"MaCapBac", "Mă c?p b?c"},
        {"MaNgay", "Mă ngày"},
        {"MaPhanCong", "Mă phân công"},
        {"TenChinhSach", "Tên chính sách"},
        {"TenCapBac", "Tên c?p b?c"},
        {"TenDuAn", "Tên d? án"},
        {"TenNgay", "Tên ngày"},
        {"Di muon (7 ngay)", "Đi mu?n (7 ngày)"},
        {"Di muon 7 ngay gan nhat", "Đi mu?n 7 ngày g?n nh?t"},
        {"Top dung gio trong thang", "Top dúng gi? trong tháng"},
        {"VaiTro", "Vai tṛ"},
        {"frmLogin", "Đang nh?p"},
        {"frmChucVu", "Ch?c v?"},
        {"frmCapBac", "C?p b?c"},
        {"Nhan vien", "Nhân viên"},
        {"Nhan su", "Nhân s?"},
        {"BoPhan", "B? ph?n"},
        {"CaLam", "Ca làm"},
        {"CongViec", "Công vi?c"},
        {"ChucNang", "Ch?c nang"},
        {"ChiTiet", "Chi ti?t"},
        {"GioChuan", "Gi? chu?n"},
        {"GioDiMuon", "Gi? di mu?n"},
        {"GioHanhChinh", "Gi? hành chính"},
        {"GioTangCa", "Gi? tang ca"},
        {"GioVeSom", "Gi? v? s?m"},
        {"HoTen", "H? tên"},
        {"KyLuong", "K? luong"},
        {"LuongCoBan", "Luong co b?n"},
        {"GioiTinh", "Gi?i tính"},
        {"NhanVien", "Nhân viên"},
        {"DepartmentId", "B? ph?n"},
        {"JobId", "Công vi?c"},
        {"JobName", "Công vi?c"},
        {"PositionId", "Ch?c v?"},
        {"ProjectId", "D? án"},
        {"EmployeeCode", "Mă nhân viên"},
        {"EmployeeName", "Tên nhân viên"},
        {"TenNhanVien", "Tên nhân viên"},
        {"MaHopDong", "Mă h?p d?ng"},
        {"TenHopDong", "Tên h?p d?ng"},
        {"LoaiHopDong", "Lo?i h?p d?ng"},
        {"NgayBatDau", "Ngày b?t d?u"},
        {"NgayKetThuc", "Ngày k?t thúc"},
        {"NgayHieuLuc", "Ngày hi?u l?c"},
        {"NgayHetHan", "Ngày h?t h?n"},
        {"MaBangLuong", "Mă b?ng luong"},
        {"MaChamCong", "Mă ch?m công"},
        {"MaKyLuong", "Mă k? luong"},
        {"TenKyLuong", "Tên k? luong"},
        {"TrinhDo", "Tŕnh d?"},
        {"SDT", "SĐT"},
        {"Title", "Tiêu d?"},
        {"DayMult", "H? s? ngày"},
        {"NightMult", "H? s? dêm"},
        {"OtMult", "H? s? tang ca"},
        {"ActiveEmployees", "Đang làm vi?c"},
        {"InactiveEmployees", "Đă ngh? vi?c"},
        {"TotalEmployees", "T?ng nhân viên"},
        {"TotalDepartments", "T?ng b? ph?n"},
        {"LateInWeekCount", "S? l?n di mu?n tu?n"},
        {"OnTimeTodayCount", "Đúng gi? hôm nay"},
        {"MissingCheckInTodayCount", "Thi?u checkin hôm nay"},
        {"TopLateInWeek", "Top di mu?n trong tu?n"},
        {"TopOnTimeInMonth", "Top dúng gi? trong tháng"},
        {"CheDoLuong", "Ch? d? luong"},
        {"HinhThucLuong", "H́nh th?c luong"},
        {"PhanTramLuong", "Ph?n tram luong"},
        {"TaiKhoan", "Tài kho?n"},
        {"MatKhau", "M?t kh?u"},
        {"NgonNgu", "Ngôn ng?"},
        {"MayChu", "Máy ch?"},
        {"TenCSDL", "Tên CSDL"},
        {"MaNghiPhep", "Mă ngh? phép"},
        {"EmployeeId", "Nhân viên"},
        {"ApprovedId", "Ngu?i duy?t"},
        {"LeaveCatId", "Lo?i ngh?"},
        {"TuNgay", "T? ngày"},
        {"DenNgay", "Đ?n ngày"},
        {"TrangThai", "Tr?ng thái"},
        {"GhiChu", "Ghi chú"},
        {"ThuHang", "Th? h?ng"}
    }

    Private ReadOnly _tuDienTu As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"them", "thêm"},
        {"sua", "s?a"},
        {"xoa", "xóa"},
        {"cap", "c?p"},
        {"nhat", "nh?t"},
        {"tim", "t́m"},
        {"kiem", "ki?m"},
        {"mo", "mô"},
        {"ta", "t?"},
        {"chuc", "ch?c"},
        {"vu", "v?"},
        {"chi", "chi"},
        {"tiet", "ti?t"},
        {"trang", "tr?ng"},
        {"thai", "thái"},
        {"ghi", "ghi"},
        {"chu", "chú"},
        {"tu", "t?"},
        {"den", "d?n"},
        {"ngay", "ngày"},
        {"vien", "viên"},
        {"du", "d?"},
        {"an", "án"},
        {"hop", "h?p"},
        {"dong", "d?ng"},
        {"luong", "luong"},
        {"co", "co"},
        {"ban", "b?n"},
        {"dang", "dang"},
        {"hoat", "ho?t"},
        {"ngung", "ngung"},
        {"he", "h?"},
        {"thong", "th?ng"},
        {"cau", "c?u"},
        {"hinh", "h́nh"},
        {"bao", "báo"},
        {"cao", "cáo"},
        {"quan", "qu?n"},
        {"ly", "lư"},
        {"lam", "làm"},
        {"moi", "m?i"},
        {"xac", "xác"},
        {"nhap", "nh?p"},
        {"xuat", "xu?t"},
        {"truoc", "tru?c"},
        {"sau", "sau"},
        {"tong", "t?ng"},
        {"bo", "b?"},
        {"phan", "ph?n"},
        {"nguoi", "ngu?i"},
        {"duyet", "duy?t"},
        {"loai", "lo?i"},
        {"nghi", "ngh?"},
        {"phep", "phép"}
    }

    Public Sub ApDungVietHoa(root As Control)
        If root Is Nothing Then Return
        DuyetVaVietHoa(root)
    End Sub

    Private Sub DuyetVaVietHoa(ctrl As Control)
        If ctrl Is Nothing Then Return

        If Not String.IsNullOrWhiteSpace(ctrl.Text) Then
            Dim daChuanHoa = ChuanHoaText(ctrl.Text)
            If daChuanHoa <> ctrl.Text Then
                ctrl.Text = daChuanHoa
            End If
        End If

        Dim dgv = TryCast(ctrl, DataGridView)
        If dgv IsNot Nothing Then
            VietHoaCot(dgv)
        End If

        For Each child As Control In ctrl.Controls
            DuyetVaVietHoa(child)
        Next
    End Sub

    Private Sub VietHoaCot(dgv As DataGridView)
        If dgv Is Nothing Then Return
        For Each cot As DataGridViewColumn In dgv.Columns
            If cot Is Nothing OrElse String.IsNullOrWhiteSpace(cot.HeaderText) Then Continue For
            Dim daChuanHoa = ChuanHoaText(cot.HeaderText)
            If daChuanHoa <> cot.HeaderText Then
                cot.HeaderText = daChuanHoa
            End If
        Next
    End Sub

    Private Function ChuanHoaText(text As String) As String
        Dim giaTri = text.Trim()
        If _bangThayThe.ContainsKey(giaTri) Then
            Return _bangThayThe(giaTri)
        End If
        Dim theoTu = VietHoaTheoTu(giaTri)
        If String.IsNullOrWhiteSpace(theoTu) Then
            Return text
        End If
        Return theoTu
    End Function

    Private Function VietHoaTheoTu(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return text

        Dim sb As New StringBuilder()
        Dim token As New StringBuilder()

        For Each ch As Char In text
            If Char.IsLetter(ch) Then
                token.Append(ch)
            Else
                AppendToken(sb, token)
                sb.Append(ch)
            End If
        Next

        AppendToken(sb, token)
        Return sb.ToString()
    End Function

    Private Sub AppendToken(sb As StringBuilder, token As StringBuilder)
        If token.Length = 0 Then Return

        Dim goc = token.ToString()
        Dim key = goc.ToLowerInvariant()
        Dim thay = goc

        If _tuDienTu.ContainsKey(key) Then
            thay = _tuDienTu(key)
            thay = GiuKieuChu(goc, thay)
        End If

        sb.Append(thay)
        token.Clear()
    End Sub

    Private Function GiuKieuChu(goc As String, thay As String) As String
        If String.IsNullOrEmpty(goc) OrElse String.IsNullOrEmpty(thay) Then Return thay

        If goc.ToUpperInvariant() = goc Then
            Return thay.ToUpperInvariant()
        End If

        If Char.IsUpper(goc(0)) Then
            Return Char.ToUpperInvariant(thay(0)) & thay.Substring(1)
        End If

        Return thay
    End Function

End Module

Module UiThongBao

    ' Chu?i hi?n th? dă du?c chu?n hóa UTF-8.
    Public Sub HienThiThanhCong(thongBao As String, Optional tieuDe As String = "Thông báo", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub HienThiLoi(thongBao As String, Optional tieuDe As String = "L?i", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub HienThiCanhBao(thongBao As String, Optional tieuDe As String = "C?nh báo", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Module

Module UiTrangThai

    Public Sub BatLoading(formHienTai As Form, Optional danhSachKhoa As IEnumerable(Of Control) = Nothing, Optional nhanTrangThai As Label = Nothing, Optional thongBao As String = "Đang x? lư...")
        If formHienTai Is Nothing Then Return

        formHienTai.UseWaitCursor = True
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If

        If danhSachKhoa Is Nothing Then Return
        For Each ctrl In danhSachKhoa
            If ctrl Is Nothing Then Continue For
            ctrl.Enabled = False
        Next
    End Sub

    Public Sub TatLoading(formHienTai As Form, Optional danhSachMo As IEnumerable(Of Control) = Nothing, Optional nhanTrangThai As Label = Nothing, Optional thongBao As String = "")
        If formHienTai Is Nothing Then Return

        formHienTai.UseWaitCursor = False
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If

        If danhSachMo Is Nothing Then Return
        For Each ctrl In danhSachMo
            If ctrl Is Nothing Then Continue For
            ctrl.Enabled = True
        Next
    End Sub

End Module

Module UiDinhDang

    Public Const DinhDangNgayMacDinh As String = "dd/MM/yyyy"
    Public Const DinhDangSoMacDinh As String = "N0"

    Public Sub ApDungDinhDangCotNgay(cot As DataGridViewColumn, Optional dinhDang As String = Nothing)
        If cot Is Nothing Then Return
        Dim dinhDangSuDung = If(String.IsNullOrWhiteSpace(dinhDang), DinhDangNgayMacDinh, dinhDang)
        cot.DefaultCellStyle.Format = dinhDangSuDung
    End Sub

    Public Sub ApDungDinhDangCotSo(cot As DataGridViewColumn, Optional dinhDang As String = Nothing)
        If cot Is Nothing Then Return
        Dim dinhDangSuDung = If(String.IsNullOrWhiteSpace(dinhDang), DinhDangSoMacDinh, dinhDang)
        cot.DefaultCellStyle.Format = dinhDangSuDung
        cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Public Sub ApDungDinhDangNgayPicker(dtp As DateTimePicker, Optional dinhDang As String = Nothing)
        If dtp Is Nothing Then Return
        Dim dinhDangSuDung = If(String.IsNullOrWhiteSpace(dinhDang), DinhDangNgayMacDinh, dinhDang)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = dinhDangSuDung
    End Sub

    Public Sub ApDungDinhDangLuoiChamCong(dgv As DataGridView)
        If dgv Is Nothing Then Return
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.RowHeadersVisible = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.None
        dgv.ColumnHeadersHeight = 40
        dgv.RowTemplate.Height = 56
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

End Module

Module BaoCaoXuat

    Public Function XuatTuDataGridView(dgv As DataGridView, Optional tieuDe As String = "bao_cao") As Boolean
        If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return False
        End If
        Dim danhSachCot = TaoDanhSachCot(dgv.Columns.Cast(Of DataGridViewColumn)().
                                         Select(Function(c) New BaoCaoXuatCot With {
                                             .TenCot = c.Name,
                                             .TieuDe = c.HeaderText,
                                             .DuocChon = True
                                         }))
        ' Hiển thị dialog để người dùng chọn cột cần xuất.
        Dim cotDuocChon = HoiChonCot(danhSachCot)
        If cotDuocChon Is Nothing OrElse cotDuocChon.Count = 0 Then
            UiThongBao.HienThiCanhBao("Bạn chưa chọn cột để xuất.")
            Return False
        End If

        Dim dt As New DataTable()
        Dim cotHopLe = dgv.Columns.Cast(Of DataGridViewColumn)().
            Where(Function(c) cotDuocChon.Any(Function(chon) String.Equals(chon.TenCot, c.Name, StringComparison.OrdinalIgnoreCase))).
            ToList()

        For Each col As DataGridViewColumn In cotHopLe
            Dim tieuDeCot = cotDuocChon.First(Function(chon) String.Equals(chon.TenCot, col.Name, StringComparison.OrdinalIgnoreCase)).TieuDe
            dt.Columns.Add(tieuDeCot)
        Next

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For
            Dim dr = dt.NewRow()
            For i As Integer = 0 To cotHopLe.Count - 1
                dr(i) = If(row.Cells(cotHopLe(i).Index).Value, String.Empty)
            Next
            dt.Rows.Add(dr)
        Next

        Return XuatTuDataTable(dt, tieuDe)
    End Function

    Public Function XuatTuDataTable(dt As DataTable, Optional tieuDe As String = "bao_cao") As Boolean
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return False
        End If

        Dim danhSachCot = TaoDanhSachCot(dt.Columns.Cast(Of DataColumn)().
                                         Select(Function(c) New BaoCaoXuatCot With {
                                             .TenCot = c.ColumnName,
                                             .TieuDe = c.ColumnName,
                                             .DuocChon = True
                                         }))
        ' Hiển thị dialog để người dùng chọn cột cần xuất.
        Dim cotDuocChon = HoiChonCot(danhSachCot)
        If cotDuocChon Is Nothing OrElse cotDuocChon.Count = 0 Then
            UiThongBao.HienThiCanhBao("Bạn chưa chọn cột để xuất.")
            Return False
        End If

        Dim dtXuat = TaoBangTuLuaChon(dt, cotDuocChon)
        If dtXuat.Rows.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return False
        End If

        Return XuatExcelTuDataTable(dtXuat, tieuDe)
    End Function

    Private Function XuatExcelTuDataTable(dt As DataTable, tieuDe As String) As Boolean
        Using dlg As New SaveFileDialog()
            dlg.Filter = "Excel (*.xlsx)|*.xlsx"
            dlg.FileName = String.Concat(tieuDe, "_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".xlsx")
            If dlg.ShowDialog() <> DialogResult.OK Then Return False

            Dim excelApp As Object = Nothing
            Dim workbook As Object = Nothing
            Dim sheet As Object = Nothing
            Try
                excelApp = CreateObject("Excel.Application")
                workbook = excelApp.Workbooks.Add()
                sheet = workbook.Worksheets(1)

                ' Ghi tiêu đề cột
                For col As Integer = 0 To dt.Columns.Count - 1
                    sheet.Cells(1, col + 1).Value = dt.Columns(col).ColumnName
                Next

                ' Ghi dữ liệu
                For row As Integer = 0 To dt.Rows.Count - 1
                    For col As Integer = 0 To dt.Columns.Count - 1
                        sheet.Cells(row + 2, col + 1).Value = dt.Rows(row)(col)
                    Next
                Next

                ' Định dạng header
                Dim headerRange = sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, dt.Columns.Count))
                headerRange.Font.Bold = True
                headerRange.Font.Size = 11
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro)
                headerRange.HorizontalAlignment = -4108 ' xlCenter
                headerRange.VerticalAlignment = -4108 ' xlCenter

                ' Định dạng cột theo kiểu dữ liệu
                For col As Integer = 0 To dt.Columns.Count - 1
                    Dim dataType = dt.Columns(col).DataType
                    If dataType Is GetType(DateTime) OrElse dataType Is GetType(Date) Then
                        sheet.Columns(col + 1).NumberFormat = "dd/MM/yyyy"
                        sheet.Columns(col + 1).HorizontalAlignment = -4108 ' xlCenter
                    ElseIf LaSo(dataType) Then
                        sheet.Columns(col + 1).NumberFormat = "#,##0"
                        sheet.Columns(col + 1).HorizontalAlignment = -4152 ' xlRight
                    Else
                        sheet.Columns(col + 1).HorizontalAlignment = -4131 ' xlLeft
                    End If
                Next

                Dim vungDuLieu = sheet.Range(sheet.Cells(2, 1), sheet.Cells(dt.Rows.Count + 1, dt.Columns.Count))
                vungDuLieu.Font.Size = 10
                vungDuLieu.VerticalAlignment = -4108 ' xlCenter

                sheet.Columns.AutoFit()
                workbook.SaveAs(dlg.FileName, 51)
                workbook.Close(False)
                excelApp.Quit()

                UiThongBao.HienThiThanhCong("Đã xuất báo cáo thành công.")
                Return True
            Catch ex As Exception
                UiThongBao.HienThiCanhBao("Không thể xuất Excel: " & ex.Message)
                Return False
            Finally
                If sheet IsNot Nothing Then Marshal.ReleaseComObject(sheet)
                If workbook IsNot Nothing Then Marshal.ReleaseComObject(workbook)
                If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)
            End Try
        End Using
    End Function

    Private Function LaSo(dataType As Type) As Boolean
        Return dataType Is GetType(Integer) OrElse
               dataType Is GetType(Long) OrElse
               dataType Is GetType(Decimal) OrElse
               dataType Is GetType(Double) OrElse
               dataType Is GetType(Single)
    End Function

    Private Function TaoDanhSachCot(cotNguon As IEnumerable(Of BaoCaoXuatCot)) As List(Of BaoCaoXuatCot)
        If cotNguon Is Nothing Then Return New List(Of BaoCaoXuatCot)()
        Return cotNguon.Select(Function(x) New BaoCaoXuatCot With {
                               .TenCot = x.TenCot,
                               .TieuDe = x.TieuDe,
                               .DuocChon = x.DuocChon
                           }).ToList()
    End Function

    Private Function HoiChonCot(cotNguon As List(Of BaoCaoXuatCot)) As List(Of BaoCaoXuatCot)
        If cotNguon Is Nothing OrElse cotNguon.Count = 0 Then Return New List(Of BaoCaoXuatCot)()

        Using frm As New frmChonCotXuat(cotNguon)
            Dim ketQua = frm.ShowDialog()
            If ketQua <> DialogResult.OK Then Return New List(Of BaoCaoXuatCot)()
            If frm.CotDuocChon Is Nothing OrElse frm.CotDuocChon.Count = 0 Then Return New List(Of BaoCaoXuatCot)()
            Return frm.CotDuocChon
        End Using
    End Function

    Private Function TaoBangTuLuaChon(dtNguon As DataTable, cotDuocChon As List(Of BaoCaoXuatCot)) As DataTable
        Dim dt As New DataTable()
        Dim cotHopLe = dtNguon.Columns.Cast(Of DataColumn)().
            Where(Function(c) cotDuocChon.Any(Function(chon) String.Equals(chon.TenCot, c.ColumnName, StringComparison.OrdinalIgnoreCase))).
            ToList()

        For Each cot In cotHopLe
            Dim tieuDe = cotDuocChon.First(Function(chon) String.Equals(chon.TenCot, cot.ColumnName, StringComparison.OrdinalIgnoreCase)).TieuDe
            dt.Columns.Add(tieuDe, cot.DataType)
        Next

        For Each row As DataRow In dtNguon.Rows
            Dim dr = dt.NewRow()
            For i As Integer = 0 To cotHopLe.Count - 1
                dr(i) = row(cotHopLe(i))
            Next
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

End Module


