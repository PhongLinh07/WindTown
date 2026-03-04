Public Class frmNhanSu

    Private phongBan As New List(Of Department)
    Private jobList As New List(Of Job)
    Private nhanVien As New List(Of Employee)

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

        Dim menuXuLyNhanh = New ContextMenuStrip()

        menuXuLyNhanh.Items.Add("Cập nhật bộ phận")
        menuXuLyNhanh.Items.Add("Cho nghỉ việc")
        menuXuLyNhanh.Items.Add("Xóa nhân viên")

        btnXuLyNhanh.ContextMenuStrip = menuXuLyNhanh

    End Sub

    ' ================= LOAD DATA =================
    Private Sub loadData()

        Dim departmentSV = New BaseService(Of Department)().Execute(DataIntent.GetList)
        Dim jobSV = New JobService().Execute(DataIntent.GetList)
        Dim employeeSV = New EmployeeService().Execute(DataIntent.GetList)

        If departmentSV.IsSuccess Then
            phongBan = CType(departmentSV.Data, List(Of Department))
        End If

        If jobSV.IsSuccess Then
            jobList = CType(jobSV.Data, List(Of Job))
        End If

        If employeeSV.IsSuccess Then
            nhanVien = CType(employeeSV.Data, List(Of Employee))
        End If

    End Sub

    ' ================= TREEVIEW =================
    Private Sub loadBoPhan()

        tvBoPhan.Nodes.Clear()
        If phongBan Is Nothing OrElse phongBan.Count = 0 Then Exit Sub

        For Each pb In phongBan

            Dim parentNode As New TreeNode(pb.name) With {
                .Tag = "D_" & pb.id,
                .ForeColor = Color.Blue
            }

            Dim dsJob = jobList.Where(Function(j) j.department_id = pb.id).ToList()

            For Each jb In dsJob
                Dim childNode As New TreeNode(jb.name) With {
                    .Tag = "J_" & jb.id
                }
                parentNode.Nodes.Add(childNode)
            Next

            tvBoPhan.Nodes.Add(parentNode)
        Next

        tvBoPhan.ExpandAll()

    End Sub

    ' ================= GRID DATA =================
    Private Sub addDataToGridView()

        Dim demoList As New List(Of NhanVien) From {
            New NhanVien With {.Code = "NV001", .Name = "Nguyễn Văn An", .Email = "an.nguyen@hrm.vn", .Status = "Active", .DepartmentName = "Phòng IT", .StartDate = "01-01-2023", .Phone = "0901234567", .Gender = "Male"},
            New NhanVien With {.Code = "NV002", .Name = "Trần Thị Bình", .Email = "binh.tran@hrm.vn", .Status = "Active", .DepartmentName = "Phòng Nhân sự", .StartDate = "15-03-2022", .Phone = "0912345678", .Gender = "Female"},
            New NhanVien With {.Code = "NV003", .Name = "Lê Minh Hoàng", .Email = "hoang.le@hrm.vn", .Status = "Inactive", .DepartmentName = "Phòng Kế toán", .StartDate = "10-05-2021", .Phone = "0987654321", .Gender = "Male"},
            New NhanVien With {.Code = "NV004", .Name = "Phạm Thị Lan", .Email = "lan.pham@hrm.vn", .Status = "Active", .DepartmentName = "Phòng Marketing", .StartDate = "20-07-2020", .Phone = "0934567890", .Gender = "Female"}
        }

        dtgvDSNhanVien.DataSource = Nothing
        dtgvDSNhanVien.DataSource = demoList
        dtgvDSNhanVien.EndEdit()

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

            '.ReadOnly = True

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

            ' ================= CỘT CHECKBOX =================
            Dim colCheck As New DataGridViewCheckBoxColumn() With {
                .Name = "colChon",
                .HeaderText = "",
                .Width = 40,
                .Frozen = True
            }
            .Columns.Add(colCheck)

            ' ================= CỘT GHIM =================
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "colMaNV",
                .HeaderText = "Mã nhân viên",
                .DataPropertyName = "Code",
                .Frozen = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "colTenNV",
                .HeaderText = "Tên",
                .DataPropertyName = "Name",
                .Frozen = True
            })

            ' ================= CỘT KHÁC =================
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colEmail", .HeaderText = "Email", .DataPropertyName = "Email"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colTrangThai", .HeaderText = "Trạng thái", .DataPropertyName = "Status"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colBoPhan", .HeaderText = "Bộ phận", .DataPropertyName = "DepartmentName"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colNgayBatDau", .HeaderText = "Ngày bắt đầu", .DataPropertyName = "StartDate"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colSDT", .HeaderText = "Số điện thoại", .DataPropertyName = "Phone"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "colGioiTinh", .HeaderText = "Giới tính", .DataPropertyName = "Gender"})

            .Columns.Add(New DataGridViewButtonColumn() With {
                .Name = "colChiTiet",
                .HeaderText = "Chi tiết",
                .Text = "Xem",
                .UseColumnTextForButtonValue = True
            })

            ' ================= AUTOSIZE AN TOÀN =================
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            .Columns("colChon").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("colMaNV").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("colTenNV").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            ' Cho phép checkbox thao tác
            ' ===============================
            ' READONLY CHUẨN
            ' ===============================

            For Each col As DataGridViewColumn In dtgvDSNhanVien.Columns
                col.ReadOnly = True
            Next

            dtgvDSNhanVien.Columns("colChon").ReadOnly = False
            'MessageBox.Show(dtgvDSNhanVien.Columns("colChon").ReadOnly.ToString())

        End With

    End Sub

    ' ================= CHECKBOX COMMIT =================
    Private Sub dtgvDSNhanVien_CurrentCellDirtyStateChanged(
        sender As Object,
        e As EventArgs) Handles dtgvDSNhanVien.CurrentCellDirtyStateChanged

        If dtgvDSNhanVien.IsCurrentCellDirty Then
            dtgvDSNhanVien.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    ' ================= HIỆN / ẨN NÚT XỬ LÝ NHANH =================
    Private Sub dtgvDSNhanVien_CellValueChanged(
        sender As Object,
        e As DataGridViewCellEventArgs) _
        Handles dtgvDSNhanVien.CellValueChanged

        If e.ColumnIndex = dtgvDSNhanVien.Columns("colChon").Index Then

            Dim anyChecked = dtgvDSNhanVien.Rows.Cast(Of DataGridViewRow)().
                Any(Function(r) Convert.ToBoolean(r.Cells("colChon").Value))

            btnXuLyNhanh.Visible = anyChecked
        End If

    End Sub
    Private Sub dtgvDSNhanVien_CellContentClick(
    sender As Object,
    e As DataGridViewCellEventArgs) _
    Handles dtgvDSNhanVien.CellContentClick

        If e.ColumnIndex = dtgvDSNhanVien.Columns("colChon").Index Then
            dtgvDSNhanVien.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub


End Class