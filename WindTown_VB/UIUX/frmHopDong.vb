Imports System.Data
Imports System.Linq

Public Class frmHopDong

    Private ReadOnly _model As New HopDongDataModel()
    Private _contracts As List(Of Contract) = New List(Of Contract)()
    Private _employees As List(Of Employee) = New List(Of Employee)()
    Private _departments As List(Of Department) = New List(Of Department)()
    Private _contractDeptMap As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

    Private Class ComboItem(Of T)
        Public Property Display As String
        Public Property Value As T
        Public Overrides Function ToString() As String
            Return Display
        End Function
    End Class

    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)

        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Không thể kết nối database: " & bootstrap.Message, "Lỗi kết nối DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisableUi()
            Return
        End If

        LoadControls()
        ConfigureFilters()
        ConfigureGrid()
        LoadLookups()
        LoadData()
    End Sub

    Private Sub DisableUi()
        btnThemHD.Enabled = False
        btnXuatHD.Enabled = False
        btnSuaHD.Enabled = False
        btnXoaHD.Enabled = False
        btnSuaHangLoat.Enabled = False
        btnSearch.Enabled = False
        tbxSearch.Enabled = False
        dtgvDSHopDong.Enabled = False
        cbbxBoPhan.Enabled = False
        cbbxTrangThai.Enabled = False
        cbbxThoiGianHD.Enabled = False
        dtpkTuNgay.Enabled = False
        dtpkDenNgay.Enabled = False
    End Sub

    Private Sub LoadControls()
        btnSearch.Image = ResizeImage(My.Resources.search, 20, 20)
    End Sub

    Private Sub ConfigureFilters()
        Dim statusItems As New List(Of ComboItem(Of Integer)) From {
            New ComboItem(Of Integer) With {.Display = "Tất cả", .Value = -999}
        }
        For Each kv In Contract.status_Dict
            statusItems.Add(New ComboItem(Of Integer) With {.Display = kv.Value, .Value = kv.Key})
        Next
        cbbxTrangThai.DataSource = statusItems
        cbbxTrangThai.DisplayMember = "Display"
        cbbxTrangThai.ValueMember = "Value"

        cbbxThoiGianHD.Items.Clear()
        cbbxThoiGianHD.Items.AddRange(New Object() {"Tất cả", "Theo khoảng"})
        cbbxThoiGianHD.SelectedIndex = 0

        UiDinhDang.ApDungDinhDangNgayPicker(dtpkTuNgay)
        UiDinhDang.ApDungDinhDangNgayPicker(dtpkDenNgay)

        cbbxBoPhan.Enabled = True
    End Sub

    Private Function ResizeImage(img As Image, newWidth As Integer, newHeight As Integer) As Image
        Dim bmp As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return bmp
    End Function

    Private Sub ConfigureGrid()
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

        CreateContractColumns()
        ConfigureColumnReadOnly()
    End Sub

    Private Sub ConfigureColumnReadOnly()
        For Each col As DataGridViewColumn In dtgvDSHopDong.Columns
            col.ReadOnly = True
        Next

        dtgvDSHopDong.Columns("colChon").ReadOnly = False
    End Sub

    Private Sub CreateContractColumns()
        dtgvDSHopDong.Columns.Clear()

        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        dtgvDSHopDong.Columns.Add(colChon)

        Dim colMaHopDong As New DataGridViewTextBoxColumn()
        colMaHopDong.Name = "colMaHopDong"
        colMaHopDong.HeaderText = "Mã hợp đồng"
        colMaHopDong.Width = 140
        colMaHopDong.Frozen = True
        dtgvDSHopDong.Columns.Add(colMaHopDong)

        Dim colNhanVien As New DataGridViewTextBoxColumn()
        colNhanVien.Name = "colNhanVien"
        colNhanVien.HeaderText = "Nhân viên"
        colNhanVien.Width = 200
        dtgvDSHopDong.Columns.Add(colNhanVien)

        Dim colNgayBatDau As New DataGridViewTextBoxColumn()
        colNgayBatDau.Name = "colNgayBatDau"
        colNgayBatDau.HeaderText = "Ngày bắt đầu"
        colNgayBatDau.Width = 130
        dtgvDSHopDong.Columns.Add(colNgayBatDau)

        Dim colNgayKetThuc As New DataGridViewTextBoxColumn()
        colNgayKetThuc.Name = "colNgayKetThuc"
        colNgayKetThuc.HeaderText = "Ngày kết thúc"
        colNgayKetThuc.Width = 130
        dtgvDSHopDong.Columns.Add(colNgayKetThuc)

        Dim colLuongCoBan As New DataGridViewTextBoxColumn()
        colLuongCoBan.Name = "colLuongCoBan"
        colLuongCoBan.HeaderText = "Lương cơ bản"
        colLuongCoBan.Width = 130
        dtgvDSHopDong.Columns.Add(colLuongCoBan)

        Dim colTrangThai As New DataGridViewTextBoxColumn()
        colTrangThai.Name = "colTrangThai"
        colTrangThai.HeaderText = "Trạng thái"
        colTrangThai.Width = 140
        dtgvDSHopDong.Columns.Add(colTrangThai)

        Dim colGhiChu As New DataGridViewTextBoxColumn()
        colGhiChu.Name = "colGhiChu"
        colGhiChu.HeaderText = "Ghi chú"
        colGhiChu.Width = 200
        dtgvDSHopDong.Columns.Add(colGhiChu)

        UiDinhDang.ApDungDinhDangCotNgay(colNgayBatDau)
        UiDinhDang.ApDungDinhDangCotNgay(colNgayKetThuc)
        UiDinhDang.ApDungDinhDangCotSo(colLuongCoBan, "N0")
    End Sub

    Private Sub LoadLookups()
        Try
            _employees = _model.LoadEmployees()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách nhân viên: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _employees = New List(Of Employee)()
        End Try

        Try
            _departments = _model.LoadDepartments()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách phòng ban: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _departments = New List(Of Department)()
        End Try

        Try
            _contractDeptMap = _model.LoadContractDepartmentMap()
        Catch ex As Exception
            _contractDeptMap = New Dictionary(Of Integer, Integer)()
        End Try

        Dim deptItems As New List(Of ComboItem(Of Integer)) From {
            New ComboItem(Of Integer) With {.Display = "Tất cả", .Value = -999}
        }
        For Each dept In _departments
            deptItems.Add(New ComboItem(Of Integer) With {.Display = $"{dept.code} - {dept.name}", .Value = dept.id})
        Next
        cbbxBoPhan.DataSource = deptItems
        cbbxBoPhan.DisplayMember = "Display"
        cbbxBoPhan.ValueMember = "Value"
    End Sub

    Private Sub LoadData()
        Dim danhSachKhoa As Control() = {btnThemHD, btnXuatHD, btnSuaHD, btnXoaHD, btnSuaHangLoat, btnSearch, dtgvDSHopDong}
        UiTrangThai.BatLoading(Me, danhSachKhoa)
        Try
            _contracts = _model.LoadContracts()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách hợp đồng: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _contracts = New List(Of Contract)()
        Finally
            UiTrangThai.TatLoading(Me, danhSachKhoa)
        End Try

        RenderRows(ApplyFilters(_contracts))
    End Sub

    Private Function ApplyFilters(source As List(Of Contract)) As List(Of Contract)
        If source Is Nothing Then Return New List(Of Contract)()

        Dim query = source.AsEnumerable()
        Dim keyword = If(tbxSearch.Text, String.Empty).Trim().ToLowerInvariant()
        If keyword <> "" Then
            query = query.Where(Function(x)
                                    Dim hay = ($"{x.code} {x.employee_UI} {x.note}").ToLowerInvariant()
                                    Return hay.Contains(keyword)
                                End Function)
        End If

        If cbbxTrangThai.SelectedValue IsNot Nothing Then
            Dim statusValue = CInt(cbbxTrangThai.SelectedValue)
            If statusValue >= 0 Then
                query = query.Where(Function(x) x.status = statusValue)
            End If
        End If

        If cbbxBoPhan.SelectedValue IsNot Nothing Then
            Dim deptId = CInt(cbbxBoPhan.SelectedValue)
            If deptId > 0 Then
                query = query.Where(Function(x)
                                        Return _contractDeptMap.ContainsKey(x.id) AndAlso _contractDeptMap(x.id) = deptId
                                    End Function)
            End If
        End If

        If cbbxThoiGianHD.SelectedItem IsNot Nothing AndAlso cbbxThoiGianHD.SelectedItem.ToString() = "Theo khoảng" Then
            Dim fromDate = dtpkTuNgay.Value.Date
            Dim toDate = dtpkDenNgay.Value.Date
            query = query.Where(Function(x)
                                    Dim startDate = If(x.start_date, DateTime.MinValue)
                                    Dim endDate = If(x.end_date, DateTime.MaxValue)
                                    Return startDate.Date >= fromDate AndAlso endDate.Date <= toDate
                                End Function)
        End If

        Return query.ToList()
    End Function

    Private Sub RenderRows(list As List(Of Contract))
        dtgvDSHopDong.Rows.Clear()

        For Each hd In list
            Dim rowIndex = dtgvDSHopDong.Rows.Add(
                False,
                hd.code,
                hd.employee_UI,
                If(hd.start_date, DateTime.MinValue).ToString("dd/MM/yyyy"),
                If(hd.end_date, DateTime.MinValue).ToString("dd/MM/yyyy"),
                If(hd.base_salary, 0D).ToString("N0"),
                hd.status_UI,
                hd.note
            )

            Dim row = dtgvDSHopDong.Rows(rowIndex)
            row.Tag = hd
        Next
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        RenderRows(ApplyFilters(_contracts))
    End Sub

    Private Sub btnThemHD_Click(sender As Object, e As EventArgs) Handles btnThemHD.Click
        Dim data As New Contract()
        If Not ShowContractDialog(data, True) Then Return

        Dim result = _model.CreateContract(data)
        If result.IsSuccess Then
            MessageBox.Show("Thêm hợp đồng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSuaHD_Click(sender As Object, e As EventArgs) Handles btnSuaHD.Click
        Dim selected = GetCheckedContracts()
        If selected.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hợp đồng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If selected.Count > 1 Then
            MessageBox.Show("Vui lòng dùng chức năng sửa hàng loạt cho nhiều hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        EditContract(selected(0))
    End Sub

    Private Sub btnXoaHD_Click(sender As Object, e As EventArgs) Handles btnXoaHD.Click
        Dim selected = GetCheckedContracts()
        If selected.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hợp đồng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Xác nhận xóa {selected.Count} hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim result = _model.DeleteContracts(selected)
        If result.IsSuccess Then
            MessageBox.Show("Xóa hợp đồng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnXuatHD_Click(sender As Object, e As EventArgs) Handles btnXuatHD.Click
        Dim selected = GetCheckedContracts()
        Dim dsXuat = If(selected.Count > 0, selected, ApplyFilters(_contracts))
        If dsXuat Is Nothing OrElse dsXuat.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return
        End If

        Dim bang = TaoBangHopDong(dsXuat)
        BaoCaoXuat.XuatTuDataTable(bang, "hop_dong")
    End Sub

    Private Sub btnSuaHangLoat_Click(sender As Object, e As EventArgs) Handles btnSuaHangLoat.Click
        Dim selected = GetCheckedContracts()
        If selected.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hợp đồng cần sửa hàng loạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        BulkEditContracts(selected)
    End Sub

    Private Function GetCheckedContracts() As List(Of Contract)
        Dim result As New List(Of Contract)()
        For Each row As DataGridViewRow In dtgvDSHopDong.Rows
            Dim isChecked = False
            If row.Cells("colChon").Value IsNot Nothing Then
                Boolean.TryParse(row.Cells("colChon").Value.ToString(), isChecked)
            End If
            If isChecked Then
                Dim data = TryCast(row.Tag, Contract)
                If data IsNot Nothing Then result.Add(data)
            End If
        Next
        Return result
    End Function

    Private Sub dtgvDSHopDong_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtgvDSHopDong.CurrentCellDirtyStateChanged
        If dtgvDSHopDong.IsCurrentCellDirty Then
            dtgvDSHopDong.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub EditContract(contractData As Contract)
        Dim data = Utils.DeepClone(contractData)
        If Not ShowContractDialog(data, False) Then Return

        Dim result = _model.UpdateContract(data)
        If result.IsSuccess Then
            MessageBox.Show("Cập nhật hợp đồng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BulkEditContracts(items As List(Of Contract))
        Dim formTitle = "Sửa hàng loạt"
        Using frm As New Form()
            frm.Text = formTitle
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(460, 320)
            HoTroPhongChu.ApDungPhongChu(frm)

            Dim chkStatus As New CheckBox() With {.Text = "Cập nhật trạng thái", .Location = New Point(20, 20), .AutoSize = True}
            Dim cboStatus As New ComboBox() With {.Location = New Point(220, 18), .Width = 210, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboStatus.DataSource = New BindingSource(Contract.status_Dict, Nothing)
            cboStatus.DisplayMember = "Value"
            cboStatus.ValueMember = "Key"
            cboStatus.Enabled = False

            Dim chkEnd As New CheckBox() With {.Text = "Cập nhật ngày kết thúc", .Location = New Point(20, 60), .AutoSize = True}
            Dim dtEnd As New DateTimePicker() With {.Location = New Point(220, 58), .Width = 210, .Enabled = False}

            Dim chkSalary As New CheckBox() With {.Text = "Cập nhật lương cơ bản", .Location = New Point(20, 100), .AutoSize = True}
            Dim numSalary As New NumericUpDown() With {.Location = New Point(220, 98), .Width = 210, .Maximum = Decimal.MaxValue, .DecimalPlaces = 0, .Enabled = False}

            Dim chkNote As New CheckBox() With {.Text = "Cập nhật ghi chú", .Location = New Point(20, 140), .AutoSize = True}
            Dim txtNote As New TextBox() With {.Location = New Point(220, 138), .Width = 210, .Enabled = False}

            AddHandler chkStatus.CheckedChanged, Sub() cboStatus.Enabled = chkStatus.Checked
            AddHandler chkEnd.CheckedChanged, Sub() dtEnd.Enabled = chkEnd.Checked
            AddHandler chkSalary.CheckedChanged, Sub() numSalary.Enabled = chkSalary.Checked
            AddHandler chkNote.CheckedChanged, Sub() txtNote.Enabled = chkNote.Checked

            Dim btnOk As New Button() With {.Text = "Lưu", .Location = New Point(260, 260), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Hủy", .Location = New Point(345, 260), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {chkStatus, cboStatus, chkEnd, dtEnd, chkSalary, numSalary, chkNote, txtNote, btnOk, btnCancel})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return

            If Not chkStatus.Checked AndAlso Not chkEnd.Checked AndAlso Not chkSalary.Checked AndAlso Not chkNote.Checked Then
                MessageBox.Show("Vui lòng chọn ít nhất một trường để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            For Each item In items
                Dim data = Utils.DeepClone(item)

                If chkStatus.Checked Then data.status = CInt(cboStatus.SelectedValue)
                If chkEnd.Checked Then data.end_date = dtEnd.Value
                If chkSalary.Checked Then data.base_salary = numSalary.Value
                If chkNote.Checked Then data.note = txtNote.Text.Trim()

                If data.start_date.HasValue AndAlso data.end_date.HasValue AndAlso data.start_date.Value.Date > data.end_date.Value.Date Then
                    MessageBox.Show($"Hợp đồng {data.code}: ngày bắt đầu lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim result = _model.UpdateContract(data)
                If Not result.IsSuccess Then
                    MessageBox.Show("Cập nhật thất bại: " & result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Next

            MessageBox.Show("Cập nhật hàng loạt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        End Using
    End Sub

    Private Function ShowContractDialog(data As Contract, isCreate As Boolean) As Boolean
        Dim formTitle = If(isCreate, "Thêm hợp đồng", "Sửa hợp đồng")
        Using frm As New Form()
            frm.Text = formTitle
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(460, 340)
            HoTroPhongChu.ApDungPhongChu(frm)

            Dim lblCode As New Label() With {.Text = "Mã hợp đồng", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(180, 18), .Width = 240, .Text = data.code}

            Dim lblEmp As New Label() With {.Text = "Nhân viên", .Location = New Point(20, 60), .AutoSize = True}
            Dim cboEmp As New ComboBox() With {.Location = New Point(180, 58), .Width = 240, .DropDownStyle = ComboBoxStyle.DropDownList}
            Dim empItems = _employees.Select(Function(e) New ComboItem(Of Employee) With {.Display = e.employee_UI, .Value = e}).ToList()
            cboEmp.DataSource = empItems
            cboEmp.DisplayMember = "Display"
            cboEmp.ValueMember = "Value"
            If data.Employee IsNot Nothing Then
                cboEmp.SelectedItem = empItems.FirstOrDefault(Function(x) x.Value.id = data.Employee.id)
            End If

            Dim lblStart As New Label() With {.Text = "Ngày bắt đầu", .Location = New Point(20, 100), .AutoSize = True}
            Dim dtStart As New DateTimePicker() With {.Location = New Point(180, 98), .Width = 240}
            dtStart.Value = If(data.start_date, DateTime.Now)

            Dim lblEnd As New Label() With {.Text = "Ngày kết thúc", .Location = New Point(20, 140), .AutoSize = True}
            Dim dtEnd As New DateTimePicker() With {.Location = New Point(180, 138), .Width = 240}
            dtEnd.Value = If(data.end_date, DateTime.Now)

            Dim lblSalary As New Label() With {.Text = "Lương cơ bản", .Location = New Point(20, 180), .AutoSize = True}
            Dim numSalary As New NumericUpDown() With {.Location = New Point(180, 178), .Width = 240, .Maximum = Decimal.MaxValue, .DecimalPlaces = 0}
            numSalary.Value = If(data.base_salary, 0D)

            Dim lblStatus As New Label() With {.Text = "Trạng thái", .Location = New Point(20, 220), .AutoSize = True}
            Dim cboStatus As New ComboBox() With {.Location = New Point(180, 218), .Width = 240, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboStatus.DataSource = New BindingSource(Contract.status_Dict, Nothing)
            cboStatus.DisplayMember = "Value"
            cboStatus.ValueMember = "Key"
            cboStatus.SelectedValue = data.status

            Dim lblNote As New Label() With {.Text = "Ghi chú", .Location = New Point(20, 260), .AutoSize = True}
            Dim txtNote As New TextBox() With {.Location = New Point(180, 258), .Width = 240, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "Lưu", .Location = New Point(265, 300), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Hủy", .Location = New Point(345, 300), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblEmp, cboEmp, lblStart, dtStart, lblEnd, dtEnd, lblSalary, numSalary, lblStatus, cboStatus, lblNote, txtNote, btnOk, btnCancel})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) Then
                MessageBox.Show("Vui lòng nhập mã hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim selectedEmp = TryCast(cboEmp.SelectedItem, ComboItem(Of Employee))
            If selectedEmp Is Nothing Then
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If dtStart.Value.Date > dtEnd.Value.Date Then
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = txtCode.Text.Trim()
            data.Employee = selectedEmp.Value
            data.start_date = dtStart.Value
            data.end_date = dtEnd.Value
            data.base_salary = numSalary.Value
            data.status = CInt(cboStatus.SelectedValue)
            data.note = txtNote.Text.Trim()
            Return True
        End Using
    End Function

    Private Function TaoBangHopDong(ds As IEnumerable(Of Contract)) As DataTable
        Dim bang As New DataTable()
        bang.Columns.Add("Mã hợp đồng")
        bang.Columns.Add("Nhân viên")
        bang.Columns.Add("Ngày bắt đầu")
        bang.Columns.Add("Ngày kết thúc")
        bang.Columns.Add("Lương cơ bản")
        bang.Columns.Add("Trạng thái")
        bang.Columns.Add("Ghi chú")

        If ds Is Nothing Then Return bang
        For Each hd In ds
            bang.Rows.Add(
                hd.code,
                hd.employee_UI,
                If(hd.start_date, DateTime.MinValue).ToString(UiDinhDang.DinhDangNgayMacDinh),
                If(hd.end_date, DateTime.MinValue).ToString(UiDinhDang.DinhDangNgayMacDinh),
                If(hd.base_salary, 0D).ToString("N0"),
                hd.status_UI,
                hd.note
            )
        Next

        Return bang
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class

