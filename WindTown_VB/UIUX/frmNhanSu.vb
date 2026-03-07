Imports System.ComponentModel

Public Class frmNhanSu
    Private phongBan As New List(Of Department)
    Private jobList As New List(Of Job)
    Private nhanVien As New List(Of Employee)

    Private menuXuLyNhanh As ContextMenuStrip
    ' ================= LOAD FORM =================
    Private Sub frmNhanSu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadData()
        loadBoPhan()
        ConfigDataGridView()
        loadControls()
        addDataToGridView()

        btnXuLyNhanh.Visible = False

    End Sub

    ' ================= LOAD CONTROLS =================
    Private Sub loadControls()

        menuXuLyNhanh = New ContextMenuStrip()

        menuXuLyNhanh.Items.Add("Cập nhật bộ phận", Nothing, AddressOf XuLy_CapNhatBoPhan)
        menuXuLyNhanh.Items.Add("Cho nghỉ việc", Nothing, AddressOf XuLy_NghiViec)
        menuXuLyNhanh.Items.Add("Xóa nhân viên", Nothing, AddressOf XuLy_XoaNhanVien)

    End Sub

    ' ================= LOAD DATA =================
    Private Sub loadData()

        ' Demo - sau này bạn thay bằng DB thật
        nhanVien = New List(Of Employee)

    End Sub

    ' ================= TREEVIEW =================
    Private Sub loadBoPhan()

        tvBoPhan.Nodes.Clear()

    End Sub

    ' ================= GRID DATA =================
    Private Sub addDataToGridView()

        Dim demoList As New BindingList(Of NhanVien) From {
            New NhanVien With {.Code = "NV001", .Name = "Nguyễn Văn An", .Email = "an.nguyen@hrm.vn", .Status = "Active", .DepartmentName = "Phòng IT", .StartDate = "01-01-2023", .Phone = "0901234567", .Gender = "Male"},
            New NhanVien With {.Code = "NV002", .Name = "Trần Thị Bình", .Email = "binh.tran@hrm.vn", .Status = "Active", .DepartmentName = "Phòng Nhân sự", .StartDate = "15-03-2022", .Phone = "0912345678", .Gender = "Female"},
            New NhanVien With {.Code = "NV003", .Name = "Lê Minh Hoàng", .Email = "hoang.le@hrm.vn", .Status = "Inactive", .DepartmentName = "Phòng Kế toán", .StartDate = "10-05-2021", .Phone = "0987654321", .Gender = "Male"}
        }

        dtgvDSNhanVien.DataSource = demoList

    End Sub

    ' ================= CONFIG GRID =================
    Private Sub ConfigDataGridView()

        With dtgvDSNhanVien

            .AutoGenerateColumns = False
            .Columns.Clear()

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False

            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = True
            .ScrollBars = ScrollBars.Horizontal
            .Dock = DockStyle.Fill

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            ' ===== CHECKBOX =====
            .Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = "colChon",
                .HeaderText = "",
                .Width = 40,
                .Frozen = True
            })

            ' ===== GHIM =====
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colMaNV", .HeaderText = "Mã", .DataPropertyName = "Code", .Frozen = True})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTenNV", .HeaderText = "Tên", .DataPropertyName = "Name", .Frozen = True})

            ' ===== CỘT KHÁC =====
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colEmail", .HeaderText = "Email", .DataPropertyName = "Email"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTrangThai", .HeaderText = "Trạng thái", .DataPropertyName = "Status"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colBoPhan", .HeaderText = "Bộ phận", .DataPropertyName = "DepartmentName"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNgayBatDau", .HeaderText = "Ngày bắt đầu", .DataPropertyName = "StartDate"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colSDT", .HeaderText = "SĐT", .DataPropertyName = "Phone"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colGioiTinh", .HeaderText = "Giới tính", .DataPropertyName = "Gender"})

            .Columns.Add(New DataGridViewButtonColumn With {
                .Name = "colChiTiet",
                .HeaderText = "Chi tiết",
                .Text = "Xem",
                .UseColumnTextForButtonValue = True
            })

            ' ===== READONLY CHUẨN =====
            For Each col As DataGridViewColumn In .Columns
                col.ReadOnly = True
            Next

            .Columns("colChon").ReadOnly = False

        End With

    End Sub

    ' ================= LẤY DANH SÁCH ĐÃ CHỌN =================
    Private Sub btnXuLyNhanh_Click(sender As Object, e As EventArgs) _
    Handles btnXuLyNhanh.Click

        menuXuLyNhanh.Show(btnXuLyNhanh, 0, btnXuLyNhanh.Height)

    End Sub
    Private Function GetSelected() As List(Of NhanVien)

        Dim list As New List(Of NhanVien)

        For Each row As DataGridViewRow In dtgvDSNhanVien.Rows
            If Convert.ToBoolean(row.Cells("colChon").Value) Then
                list.Add(CType(row.DataBoundItem, NhanVien))
            End If
        Next

        Return list

    End Function

    ' ================= MENU XỬ LÝ =================
    Private Sub XuLy_CapNhatBoPhan(sender As Object, e As EventArgs)

        Dim selected = GetSelected()
        If selected.Count = 0 Then Return

        MessageBox.Show("Cập nhật bộ phận cho " & selected.Count & " nhân viên")

        ClearCheckBox()

    End Sub

    Private Sub XuLy_NghiViec(sender As Object, e As EventArgs)

        Dim selected = GetSelected()
        If selected.Count = 0 Then Return

        For Each nv In selected
            nv.Status = "Inactive"
        Next

        dtgvDSNhanVien.Refresh()
        ClearCheckBox()

    End Sub

    Private Sub XuLy_XoaNhanVien(sender As Object, e As EventArgs)

        Dim selected = GetSelected()
        If selected.Count = 0 Then Return

        Dim source = CType(dtgvDSNhanVien.DataSource, BindingList(Of NhanVien))

        For Each nv In selected
            source.Remove(nv)
        Next

        ClearCheckBox()

    End Sub

    Private Sub ClearCheckBox()

        For Each row As DataGridViewRow In dtgvDSNhanVien.Rows
            row.Cells("colChon").Value = False
        Next

        btnXuLyNhanh.Visible = False

    End Sub

    ' ================= CHECKBOX COMMIT =================
    Private Sub dtgvDSNhanVien_CurrentCellDirtyStateChanged(
        sender As Object,
        e As EventArgs)

        If dtgvDSNhanVien.IsCurrentCellDirty Then
            dtgvDSNhanVien.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    ' ================= HIỆN / ẨN NÚT =================
    Private Sub dtgvDSNhanVien_CellValueChanged(
        sender As Object,
        e As DataGridViewCellEventArgs)

        If e.ColumnIndex = dtgvDSNhanVien.Columns("colChon").Index Then

            Dim anyChecked = dtgvDSNhanVien.Rows.Cast(Of DataGridViewRow)().
                Any(Function(r) Convert.ToBoolean(r.Cells("colChon").Value))

            btnXuLyNhanh.Visible = anyChecked

        End If

    End Sub

End Class