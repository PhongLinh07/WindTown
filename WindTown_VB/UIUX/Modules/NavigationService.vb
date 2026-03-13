Imports System.IO
Imports System.Text
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

        HoTroPhongChu.ApDungPhongChu(nextForm)
        nextForm.Show()

        If currentForm IsNot Nothing AndAlso Not currentForm.IsDisposed Then
            currentForm.Close()
        End If

    End Sub

    ' Phiên bản generic để gọi dễ dàng hơn, ví dụ: SwitchTopLevel(Of frmLogin)(Me)
    Public Sub SwitchTopLevel(Of T As {Form, New})(currentForm As Form)
        Dim nextForm As New T()
        SwitchTopLevel(currentForm, nextForm)
    End Sub

    ' Đăng xuất về form đăng nhập, đồng thời đóng form chính nếu đang ở trong đó
    Public Sub LogoutToLogin()

        Dim login As New frmLogin()
        HoTroPhongChu.ApDungPhongChu(login)
        login.Show()

        If _mainHostForm IsNot Nothing AndAlso Not _mainHostForm.IsDisposed Then
            _isSwitchingFromMain = True
            _mainHostForm.Close()
        End If

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

    Private ReadOnly _phongChuUngDung As New Font("Microsoft YaHei UI", 10.0!, FontStyle.Regular, GraphicsUnit.Point)

    Public Sub ApDungPhongChu(root As Control)
        If root Is Nothing Then Return
        ApDungPhongChuDeQuy(root, _phongChuUngDung)
    End Sub

    Private Sub ApDungPhongChuDeQuy(ctrl As Control, phongChu As Font)
        ctrl.Font = phongChu
        For Each child As Control In ctrl.Controls
            ApDungPhongChuDeQuy(child, phongChu)
        Next
    End Sub

End Module
Module UiThongBao

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

