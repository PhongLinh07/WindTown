Imports System.IO
Imports System.Text
Imports System.Drawing

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

    ' Gọi hàm này khi đăng nhập thành công để thiết lập form chính và panel chứa nội dung
    Public Sub Initialize(mainHostForm As Form, mainPanel As Panel)

        If mainHostForm Is Nothing OrElse mainPanel Is Nothing Then Return

        _mainHostForm = mainHostForm
        _mainPanel = mainPanel

        _history.Clear()
        _currentFormType = Nothing

    End Sub

    ' formType phải là một lớp kế thừa từ Form
    Public Sub NavigateInMain(formType As Type, Optional addToHistory As Boolean = True)

        If Not IsInitialized Then Return
        If formType Is Nothing Then Return
        If Not GetType(Form).IsAssignableFrom(formType) Then Return

        If addToHistory AndAlso _currentFormType IsNot Nothing AndAlso _currentFormType IsNot formType Then
            _history.Push(_currentFormType)
        End If

        ShowInMain(formType)

    End Sub

    ' Generic version để gọi dễ dàng hơn, ví dụ: NavigateInMain(Of frmDashboard)()
    Public Sub NavigateInMain(Of T As Form)(Optional addToHistory As Boolean = True)
        NavigateInMain(GetType(T), addToHistory)
    End Sub

    ' Trả về true nếu đã quay lại thành công, false nếu không thể quay lại (ví dụ: không có lịch sử)
    Public Function GoBackInMain() As Boolean

        If Not CanGoBack Then Return False

        Dim previousType As Type = _history.Pop()
        ShowInMain(previousType)

        Return True

    End Function

    ' Đóng form hiện tại và mở form mới ở cấp độ top-level (không trong panel)
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
            MessageBox.Show("Không thể chuyển form. Vui lòng thử lại. Chi tiết: " & ex.Message, "Lỗi chuyển form", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                If formDich IsNot Nothing AndAlso Not formDich.IsDisposed Then
                    formDich.Close()
                End If
            Catch
            End Try
        End Try

    End Sub

    ' Phiên bản generic để gọi dễ dàng hơn, ví dụ: SwitchTopLevel(Of frmLogin)(Me)
    Public Sub SwitchTopLevel(Of T As {Form, New})(currentForm As Form)
        Dim nextForm As New T()
        SwitchTopLevel(currentForm, nextForm)
    End Sub

    ' Đăng xuất về form đăng nhập, đồng thời đóng form chính nếu đang ở trong đó
    Public Sub LogoutToLogin(currentForm As Form)
        _isSwitchingFromMain = True
        NavigationService.SwitchTopLevel(Of frmLogin)(_mainHostForm)
    End Sub

    ' Khi form chính bị đóng, nếu đang chuyển từ form chính sang form khác thì không thoát ứng dụng
    Public Function ShouldTerminateWhenMainClosed() As Boolean

        If _isSwitchingFromMain Then
            _isSwitchingFromMain = False
            Return False
        End If

        Return True

    End Function

    ' Hàm nội bộ để hiển thị form trong panel chính, sẽ dispose form cũ nếu có
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
        ' Chuẩn hóa tiếng Việt cho tiêu đề/nhãn hiển thị trên form.
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

    'Danh sách mapping tiêu đề/nhãn không dấu sang có dấu để Việt hóa UI.
    Private ReadOnly _bangThayThe As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"Tim", "Tìm"},
        {"Tim kiem", "Tìm kiếm"},
        {"Tim kiem...", "Tìm kiếm..."},
        {"Dashboard", "Bảng điều khiển"},
        {"Refresh", "Làm mới"},
        {"Checkin", "Chấm công"},
        {"Approved Id", "Người duyệt"},
        {"Mo ta chuc vu:", "Mô tả chức vụ:"},
        {"Chuc vu", "Chức vụ"},
        {"Them chuc vu", "Thêm chức vụ"},
        {"+ Them chuc vu", "+ Thêm chức vụ"},
        {"Sua chuc vu", "Sửa chức vụ"},
        {"Xoa", "Xóa"},
        {"Sua", "Sửa"},
        {"Them", "Thêm"},
        {"Cap nhat", "Cập nhật"},
        {"Dang xuat", "Đăng xuất"},
        {"Dang nhap", "Đăng nhập"},
        {"Ket noi", "Kết nối"},
        {"Cau hinh", "Cấu hình"},
        {"Thong bao", "Thông báo"},
        {"Loi", "Lỗi"},
        {"Nhap lai", "Nhập lại"},
        {"Chi tiet:", "Chi tiết:"},
        {"Mo ta", "Mô tả"},
        {"Ma", "Mã"},
        {"Ten", "Tên"},
        {"Ngay", "Ngày"},
        {"Trang thai", "Trạng thái"},
        {"Ghi chu", "Ghi chú"},
        {"Code", "Mã"},
        {"Name", "Tên"},
        {"Gender", "Giới tính"},
        {"Phone", "Số điện thoại"},
        {"Status", "Trạng thái"},
        {"StartDate", "Ngày bắt đầu"},
        {"DepartmentName", "Phòng ban"},
        {"Position Id", "Chức vụ"},
        {"Project Id", "Dự án"},
        {"Employee Id", "Nhân viên"},
        {"LeaveCat Id", "Loại nghỉ"},
        {"LoaiChinhSach", "Loại chính sách"},
        {"Luu", "Lưu"},
        {"MaChinhSach", "Mã chính sách"},
        {"MaDuAn", "Mã dự án"},
        {"MaCapBac", "Mã cấp bậc"},
        {"MaNgay", "Mã ngày"},
        {"MaPhanCong", "Mã phân công"},
        {"TenChinhSach", "Tên chính sách"},
        {"TenCapBac", "Tên cấp bậc"},
        {"TenDuAn", "Tên dự án"},
        {"TenNgay", "Tên ngày"},
        {"Di muon (7 ngay)", "Đi muộn (7 ngày)"},
        {"Di muon 7 ngay gan nhat", "Đi muộn 7 ngày gần nhất"},
        {"Top dung gio trong thang", "Top đúng giờ trong tháng"},
        {"VaiTro", "Vai trò"},
        {"frmLogin", "Đăng nhập"},
        {"frmChucVu", "Chức vụ"},
        {"frmCapBac", "Cấp bậc"},
        {"Nhan vien", "Nhân viên"},
        {"Nhan su", "Nhân sự"},
        {"BoPhan", "Bộ phận"},
        {"CaLam", "Ca làm"},
        {"CongViec", "Công việc"},
        {"ChucNang", "Chức năng"},
        {"ChiTiet", "Chi tiết"},
        {"GioChuan", "Giờ chuẩn"},
        {"GioDiMuon", "Giờ đi muộn"},
        {"GioHanhChinh", "Giờ hành chính"},
        {"GioTangCa", "Giờ tăng ca"},
        {"GioVeSom", "Giờ về sớm"},
        {"HoTen", "Họ tên"},
        {"KyLuong", "Kỳ lương"},
        {"LuongCoBan", "Lương cơ bản"},
        {"GioiTinh", "Giới tính"},
        {"NhanVien", "Nhân viên"},
        {"DepartmentId", "Bộ phận"},
        {"JobId", "Công việc"},
        {"JobName", "Công việc"},
        {"PositionId", "Chức vụ"},
        {"ProjectId", "Dự án"},
        {"EmployeeCode", "Mã nhân viên"},
        {"EmployeeName", "Tên nhân viên"},
        {"TenNhanVien", "Tên nhân viên"},
        {"MaHopDong", "Mã hợp đồng"},
        {"TenHopDong", "Tên hợp đồng"},
        {"LoaiHopDong", "Loại hợp đồng"},
        {"NgayBatDau", "Ngày bắt đầu"},
        {"NgayKetThuc", "Ngày kết thúc"},
        {"NgayHieuLuc", "Ngày hiệu lực"},
        {"NgayHetHan", "Ngày hết hạn"},
        {"MaBangLuong", "Mã bảng lương"},
        {"MaChamCong", "Mã chấm công"},
        {"MaKyLuong", "Mã kỳ lương"},
        {"TenKyLuong", "Tên kỳ lương"},
        {"TrinhDo", "Trình độ"},
        {"SDT", "SĐT"},
        {"Title", "Tiêu đề"},
        {"DayMult", "Hệ số ngày"},
        {"NightMult", "Hệ số đêm"},
        {"OtMult", "Hệ số tăng ca"},
        {"ActiveEmployees", "Đang làm việc"},
        {"InactiveEmployees", "Đã nghỉ việc"},
        {"TotalEmployees", "Tổng nhân viên"},
        {"TotalDepartments", "Tổng bộ phận"},
        {"LateInWeekCount", "Số lần đi muộn tuần"},
        {"OnTimeTodayCount", "Đúng giờ hôm nay"},
        {"MissingCheckInTodayCount", "Thiếu checkin hôm nay"},
        {"TopLateInWeek", "Top đi muộn trong tuần"},
        {"TopOnTimeInMonth", "Top đúng giờ trong tháng"},
        {"CheDoLuong", "Chế độ lương"},
        {"HinhThucLuong", "Hình thức lương"},
        {"PhanTramLuong", "Phần trăm lương"},
        {"TaiKhoan", "Tài khoản"},
        {"MatKhau", "Mật khẩu"},
        {"NgonNgu", "Ngôn ngữ"},
        {"MayChu", "Máy chủ"},
        {"TenCSDL", "Tên CSDL"},
        {"MaNghiPhep", "Mã nghỉ phép"},
        {"EmployeeId", "Nhân viên"},
        {"ApprovedId", "Người duyệt"},
        {"LeaveCatId", "Loại nghỉ"},
        {"TuNgay", "Từ ngày"},
        {"DenNgay", "Đến ngày"},
        {"TrangThai", "Trạng thái"},
        {"GhiChu", "Ghi chú"},
        {"ThuHang", "Thứ hạng"}
    }

    Private ReadOnly _tuDienTu As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"them", "thêm"},
        {"sua", "sửa"},
        {"xoa", "xóa"},
        {"cap", "cập"},
        {"nhat", "nhật"},
        {"tim", "tìm"},
        {"kiem", "kiếm"},
        {"mo", "mô"},
        {"ta", "tả"},
        {"chuc", "chức"},
        {"vu", "vụ"},
        {"chi", "chi"},
        {"tiet", "tiết"},
        {"trang", "trạng"},
        {"thai", "thái"},
        {"ghi", "ghi"},
        {"chu", "chú"},
        {"tu", "từ"},
        {"den", "đến"},
        {"ngay", "ngày"},
        {"vien", "viên"},
        {"du", "dự"},
        {"an", "án"},
        {"hop", "hợp"},
        {"dong", "đồng"},
        {"luong", "lương"},
        {"co", "cơ"},
        {"ban", "bản"},
        {"dang", "đang"},
        {"hoat", "hoạt"},
        {"ngung", "ngưng"},
        {"he", "hệ"},
        {"thong", "thống"},
        {"cau", "cấu"},
        {"hinh", "hình"},
        {"bao", "báo"},
        {"cao", "cáo"},
        {"quan", "quản"},
        {"ly", "lý"},
        {"lam", "làm"},
        {"moi", "mới"},
        {"xac", "xác"},
        {"nhap", "nhập"},
        {"xuat", "xuất"},
        {"truoc", "trước"},
        {"sau", "sau"},
        {"tong", "tổng"},
        {"bo", "bộ"},
        {"phan", "phận"},
        {"nguoi", "người"},
        {"duyet", "duyệt"},
        {"loai", "loại"},
        {"nghi", "nghỉ"},
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

    ' Chuỗi hiển thị đã được chuẩn hóa UTF-8.
    Public Sub HienThiThanhCong(thongBao As String, Optional tieuDe As String = "Thông báo", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub HienThiLoi(thongBao As String, Optional tieuDe As String = "Lỗi", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub HienThiCanhBao(thongBao As String, Optional tieuDe As String = "Cảnh báo", Optional nhanTrangThai As Label = Nothing)
        If nhanTrangThai IsNot Nothing Then
            nhanTrangThai.Text = thongBao
        End If
        MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Module

Module UiTrangThai

    Public Sub BatLoading(formHienTai As Form, Optional danhSachKhoa As IEnumerable(Of Control) = Nothing, Optional nhanTrangThai As Label = Nothing, Optional thongBao As String = "Đang xử lý...")
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

        Dim dt As New DataTable()
        For Each col As DataGridViewColumn In dgv.Columns
            dt.Columns.Add(col.HeaderText)
        Next

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For
            Dim dr = dt.NewRow()
            For i As Integer = 0 To dgv.Columns.Count - 1
                dr(i) = If(row.Cells(i).Value, String.Empty)
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

        Using dlg As New SaveFileDialog()
            dlg.Filter = "CSV (*.csv)|*.csv"
            dlg.FileName = String.Concat(tieuDe, "_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".csv")
            If dlg.ShowDialog() <> DialogResult.OK Then Return False

            Dim sb As New StringBuilder()
            Dim cotTieuDe As String() = dt.Columns.Cast(Of DataColumn)().Select(Function(c) BaoCsv(c.ColumnName)).ToArray()
            sb.AppendLine(String.Join(",", cotTieuDe))

            For Each row As DataRow In dt.Rows
                Dim giaTri As String() = dt.Columns.Cast(Of DataColumn)().Select(Function(c) BaoCsv(Convert.ToString(row(c)))).ToArray()
                sb.AppendLine(String.Join(",", giaTri))
            Next

            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8)
        End Using

        UiThongBao.HienThiThanhCong("Đã xuất báo cáo thành công.")
        Return True
    End Function

    Private Function BaoCsv(giaTri As String) As String
        If giaTri Is Nothing Then Return ""
        Dim canBao = giaTri.Contains(",") OrElse giaTri.Contains("""") OrElse giaTri.Contains(vbCr) OrElse giaTri.Contains(vbLf)
        Dim ketQua = giaTri.Replace("""", """""")
        If canBao Then
            Return """" & ketQua & """"
        End If
        Return ketQua
    End Function

End Module
