Imports System.Linq

Public Class DashboardService

    Private ReadOnly _employeeService = AppServices.Instance.EmployeeSV
    Private ReadOnly _attendanceService = AppServices.Instance.AttendanceSV
    Private ReadOnly _departmentService = AppServices.Instance.DepartmentSV
    Private ReadOnly _leaveService = AppServices.Instance.LeaveSV
    Private ReadOnly _payrollService = AppServices.Instance.PayrollSV
    Private ReadOnly _payItemService = AppServices.Instance.Pay_ItemSV
    Private ReadOnly _baoCaoRepo As New BaoCaoTongHopRepository()

    Public Function BuildSummary(selectedDate As DateTime) As DashboardSummaryDto

        Dim summary As New DashboardSummaryDto()

        ' LOAD DATA SONG SONG
        Dim empTask = Task.Run(Function() LoadEmployees())
        Dim attTask = Task.Run(Function() LoadAttendances())
        Dim depTask = Task.Run(Function() LoadDepartments())

        Task.WaitAll(empTask, attTask, depTask)

        Dim employees = empTask.Result
        Dim attendances = attTask.Result
        Dim departments = depTask.Result

        ' MAP EMPLOYEE
        Dim employeeMap = employees.ToDictionary(Function(x) x.id, Function(x) x)

        ' EMPLOYEE SUMMARY
        Dim activeEmployees = employees.Where(Function(x) x.status = CInt(Display_Field.Status.Active)).ToList()
        Dim inactiveEmployees = employees.Where(Function(x) x.status = CInt(Display_Field.Status.Inactive)).ToList()

        summary.TotalEmployees = employees.Count
        summary.ActiveEmployees = activeEmployees.Count
        summary.InactiveEmployees = inactiveEmployees.Count
        summary.TotalDepartments = departments.Count

        ' DATE RANGE
        Dim day = selectedDate.Date
        Dim weekStart = day.AddDays(-6)
        Dim monthStart = New DateTime(day.Year, day.Month, 1)
        Dim monthEndExclusive = monthStart.AddMonths(1)

        ' ATTENDANCE TODAY
        Dim dayAttendances = attendances.
            Where(Function(x) x.of_date.Date = day).
            ToList()

        summary.OnTimeTodayCount = dayAttendances.
            Where(Function(x) x.office_hours > 0D AndAlso x.late_hours <= 0D).
            Select(Function(x) x.employee_id).
            Distinct().
            Count()

        Dim checkedInIds = New HashSet(Of Integer)(dayAttendances.Select(Function(x) x.employee_id))

        summary.MissingCheckInTodayCount =
            activeEmployees.Where(Function(x) Not checkedInIds.Contains(x.id)).Count()

        ' LATE IN WEEK
        Dim weekLateAttendances = attendances.
            Where(Function(x)
                      Dim d = x.of_date.Date
                      Return d >= weekStart AndAlso d <= day AndAlso x.late_hours > 0D
                  End Function).
            ToList()

        summary.LateInWeekCount = weekLateAttendances.
            Select(Function(x) x.employee_id).
            Distinct().
            Count()

        ' TOP CHECKIN SOM
        summary.TopOnTimeInMonth =
            attendances.
            Where(Function(x)
                      Dim d = x.of_date.Date
                      Return d >= monthStart AndAlso
                             d < monthEndExclusive AndAlso
                             x.office_hours > 0D AndAlso
                             x.late_hours <= 0D
                  End Function).
            GroupBy(Function(x) x.employee_id).
            Select(Function(g)
                       Dim emp = GetEmployee(employeeMap, g.Key)

                       Return New DashboardTopItem With {
                           .EmployeeCode = emp.code,
                           .EmployeeName = emp.name,
                           .MetricValue = g.Count()
                       }

                   End Function).
            OrderByDescending(Function(x) x.MetricValue).
            ThenBy(Function(x) x.EmployeeCode).
            Take(10).
            ToList()

        ' TOP CHECKIN MUON
        summary.TopLateInWeek =
            weekLateAttendances.
            GroupBy(Function(x) x.employee_id).
            Select(Function(g)

                       Dim emp = GetEmployee(employeeMap, g.Key)

                       Return New DashboardTopItem With {
                           .EmployeeCode = emp.code,
                           .EmployeeName = emp.name,
                           .MetricValue = g.Sum(Function(x) x.late_hours)
                       }

                   End Function).
            OrderByDescending(Function(x) x.MetricValue).
            ThenBy(Function(x) x.EmployeeCode).
            Take(10).
            ToList()

        Return summary

    End Function

    Private Function LoadEmployees() As List(Of Employee)

        Dim response = _employeeService.GetList()

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Employee)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Employee))

        If list Is Nothing Then
            Return New List(Of Employee)
        End If

        Return list.ToList()

    End Function

    Private Function LoadAttendances() As List(Of Attendance)

        Dim response = _attendanceService.GetList()

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Attendance)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Attendance))

        If list Is Nothing Then
            Return New List(Of Attendance)
        End If

        Return list.ToList()

    End Function

    Private Function LoadDepartments() As List(Of Department)

        Dim response = _departmentService.GetList()

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Department)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Department))

        If list Is Nothing Then
            Return New List(Of Department)
        End If

        Return list.ToList()

    End Function

    Private Function GetEmployee(employeeMap As Dictionary(Of Integer, Employee), employeeId As Integer) As Employee

        If employeeMap.ContainsKey(employeeId) Then
            Return employeeMap(employeeId)
        End If

        Return New Employee With {
            .code = "EMP-NA",
            .name = "Khong xac dinh"
        }

    End Function

    Public Function TaiBaoCaoTongHop(boLoc As BaoCaoBoLoc) As BaoCaoTongHopDto
        Dim ketQua As New BaoCaoTongHopDto()
        Dim ngayHienTai = DateTime.Today
        Dim thang = If(boLoc IsNot Nothing AndAlso boLoc.Thang > 0, boLoc.Thang, ngayHienTai.Month)
        Dim nam = If(boLoc IsNot Nothing AndAlso boLoc.Nam > 0, boLoc.Nam, ngayHienTai.Year)
        Dim phongBanId = If(boLoc IsNot Nothing, boLoc.PhongBanId, 0)

        Dim tuNgay = New DateTime(nam, thang, 1)
        Dim denNgay = tuNgay.AddMonths(1)

        Dim employees = LoadEmployees()
        Dim attendances = LoadAttendances()
        Dim leaves = LoadLeaves()
        Dim payrolls = LoadPayrolls()
        Dim payItems = LoadPayItems()
        Dim departments = LoadDepartments()

        Dim mapNhanVienPhongBan = _baoCaoRepo.TaiMapNhanVienPhongBan()
        Dim employeeIds = New HashSet(Of Integer)(
            If(phongBanId > 0,
               employees.Where(Function(x) mapNhanVienPhongBan.ContainsKey(x.id) AndAlso mapNhanVienPhongBan(x.id) = phongBanId).Select(Function(x) x.id),
               employees.Select(Function(x) x.id))
        )

        Dim attendancesLoc = attendances.
            Where(Function(x) x.of_date.Date >= tuNgay AndAlso x.of_date.Date < denNgay).
            Where(Function(x) employeeIds.Contains(x.employee_id)).
            ToList()

        Dim leavesLoc = leaves.
            Where(Function(x) x.start_date.Date >= tuNgay AndAlso x.start_date.Date < denNgay).
            Where(Function(x) employeeIds.Contains(x.employee_id)).
            ToList()

        Dim payrollLoc = payrolls.
            Where(Function(x) KiemTraKyLuong(x, nam, thang)).
            Where(Function(x) KiemTraNhanVienTheoPhongBan(x, mapNhanVienPhongBan, phongBanId)).
            ToList()

        Dim payrollIdLoc = New HashSet(Of Integer)(payrollLoc.Select(Function(x) x.id))
        Dim payItemsLoc = payItems.
            Where(Function(x) x.Payroll IsNot Nothing AndAlso payrollIdLoc.Contains(x.Payroll.id)).
            ToList()
        Dim payrollMap = payrollLoc.ToDictionary(Function(x) x.id, Function(x) x)

        ' Tổng hợp KPI
        ketQua.TongNhanVien = employeeIds.Count
        ketQua.TongGioTangCa = attendancesLoc.Sum(Function(x) x.overtime_hours)
        ketQua.TongNgayNghi = leavesLoc.Sum(Function(x) x.total_days)
        ketQua.TongChiPhiLuong = TinhTongLuong(payItemsLoc)

        ' Biểu đồ nhân sự theo phòng ban
        ketQua.NhanSuTheoPhongBan = TaoBieuDoNhanSuPhongBan(employees, departments, mapNhanVienPhongBan, phongBanId)

        ' Biểu đồ lương theo tháng
        ketQua.LuongTheoThang = TaoBieuDoLuongTheoThang(payrolls, payItems, mapNhanVienPhongBan, phongBanId, nam)

        ' Biểu đồ tổng quan chấm công
        ketQua.ChamCongTongQuan = New List(Of BaoCaoDuLieuBieuDo) From {
            New BaoCaoDuLieuBieuDo With {.Nhan = "Đi làm", .GiaTri = attendancesLoc.Sum(Function(x) x.office_hours)},
            New BaoCaoDuLieuBieuDo With {.Nhan = "Tăng ca", .GiaTri = attendancesLoc.Sum(Function(x) x.overtime_hours)},
            New BaoCaoDuLieuBieuDo With {.Nhan = "Đi muộn", .GiaTri = attendancesLoc.Sum(Function(x) x.late_hours)}
        }

        ' Bảng Top 10 theo lương
        ketQua.TopLuong = TaoTopLuong(payrollMap, payItemsLoc)

        Return ketQua
    End Function

    Private Function LoadLeaves() As List(Of Leave)
        Dim response = _leaveService.GetList()
        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Leave)()
        End If
        Dim list = TryCast(response.Data, IEnumerable(Of Leave))
        Return If(list IsNot Nothing, list.ToList(), New List(Of Leave)())
    End Function

    Private Function LoadPayrolls() As List(Of Payroll)
        Dim response = _payrollService.GetList()
        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Payroll)()
        End If
        Dim list = TryCast(response.Data, IEnumerable(Of Payroll))
        Return If(list IsNot Nothing, list.ToList(), New List(Of Payroll)())
    End Function

    Private Function LoadPayItems() As List(Of Pay_Item)
        Dim response = _payItemService.GetList()
        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Pay_Item)()
        End If
        Dim list = TryCast(response.Data, IEnumerable(Of Pay_Item))
        Return If(list IsNot Nothing, list.ToList(), New List(Of Pay_Item)())
    End Function

    Private Function KiemTraKyLuong(payroll As Payroll, nam As Integer, thang As Integer) As Boolean
        Dim pp = payroll?.Pay_Period
        If pp Is Nothing Then Return False
        Dim ngay = If(pp.month, pp.start_date)
        Return ngay.Year = nam AndAlso ngay.Month = thang
    End Function

    Private Function KiemTraNhanVienTheoPhongBan(payroll As Payroll, mapNhanVienPhongBan As Dictionary(Of Integer, Integer), phongBanId As Integer) As Boolean
        If phongBanId <= 0 Then Return True
        Dim empId = payroll?.Position?.Contract?.Employee?.id
        If empId Is Nothing OrElse empId <= 0 Then Return False
        Return mapNhanVienPhongBan.ContainsKey(empId) AndAlso mapNhanVienPhongBan(empId) = phongBanId
    End Function

    Private Function TinhTongLuong(payItems As IEnumerable(Of Pay_Item)) As Decimal
        If payItems Is Nothing Then Return 0D
        Dim maNet = System_Parameter.GetParameter(System_Parameter.ID.SYS_NET_SALARY)?.code
        Dim netItems = If(String.IsNullOrWhiteSpace(maNet),
                          New List(Of Pay_Item)(),
                          payItems.Where(Function(x) String.Equals(x.code, maNet, StringComparison.OrdinalIgnoreCase)).ToList())
        If netItems.Count > 0 Then
            Return netItems.Sum(Function(x) x.value)
        End If
        Dim tongThu = payItems.Where(Function(x) Category_PayItem.GetSign(x.category) = 1).Sum(Function(x) x.value)
        Dim tongTru = payItems.Where(Function(x) Category_PayItem.GetSign(x.category) = -1).Sum(Function(x) x.value)
        Return tongThu - tongTru
    End Function

    Private Function TaoBieuDoNhanSuPhongBan(employees As List(Of Employee),
                                            departments As List(Of Department),
                                            mapNhanVienPhongBan As Dictionary(Of Integer, Integer),
                                            phongBanId As Integer) As List(Of BaoCaoDuLieuBieuDo)
        Dim ketQua As New List(Of BaoCaoDuLieuBieuDo)()
        Dim deptMap = departments.ToDictionary(Function(x) x.id, Function(x) If(String.IsNullOrWhiteSpace(x.name), $"PB #{x.id}", x.name))

        Dim nhom = employees.
            Where(Function(x) mapNhanVienPhongBan.ContainsKey(x.id)).
            GroupBy(Function(x) mapNhanVienPhongBan(x.id)).
            Select(Function(g) New With {.PhongBanId = g.Key, .SoLuong = g.Count()}).
            ToList()

        For Each item In nhom
            If phongBanId > 0 AndAlso item.PhongBanId <> phongBanId Then Continue For
            Dim ten = If(deptMap.ContainsKey(item.PhongBanId), deptMap(item.PhongBanId), $"PB #{item.PhongBanId}")
            ketQua.Add(New BaoCaoDuLieuBieuDo With {.Nhan = ten, .GiaTri = item.SoLuong})
        Next

        If ketQua.Count = 0 Then
            ketQua.Add(New BaoCaoDuLieuBieuDo With {.Nhan = "Chưa có dữ liệu", .GiaTri = 0})
        End If

        Return ketQua
    End Function

    Private Function TaoBieuDoLuongTheoThang(payrolls As List(Of Payroll),
                                             payItems As List(Of Pay_Item),
                                             mapNhanVienPhongBan As Dictionary(Of Integer, Integer),
                                             phongBanId As Integer,
                                             nam As Integer) As List(Of BaoCaoDuLieuBieuDo)
        Dim ketQua As New List(Of BaoCaoDuLieuBieuDo)()
        For thang As Integer = 1 To 12
            Dim thangHienTai = thang
            Dim payrollLoc = payrolls.
                Where(Function(x) KiemTraKyLuong(x, nam, thangHienTai)).
                Where(Function(x) KiemTraNhanVienTheoPhongBan(x, mapNhanVienPhongBan, phongBanId)).
                ToList()

            Dim payrollIdLoc = New HashSet(Of Integer)(payrollLoc.Select(Function(x) x.id))
            Dim payItemsLoc = payItems.Where(Function(x) x.Payroll IsNot Nothing AndAlso payrollIdLoc.Contains(x.Payroll.id)).ToList()
            Dim tongLuong = TinhTongLuong(payItemsLoc)
            ketQua.Add(New BaoCaoDuLieuBieuDo With {.Nhan = thang.ToString("00"), .GiaTri = tongLuong})
        Next
        Return ketQua
    End Function

    Private Function TaoTopLuong(payrollMap As Dictionary(Of Integer, Payroll), payItems As List(Of Pay_Item)) As List(Of BaoCaoTopLuongItem)
        Dim ketQua As New List(Of BaoCaoTopLuongItem)()
        Dim empMap As New Dictionary(Of Integer, Employee)()
        For Each payroll In payrollMap.Values
            Dim emp = payroll?.Position?.Contract?.Employee
            If emp Is Nothing Then Continue For
            If Not empMap.ContainsKey(emp.id) Then
                empMap(emp.id) = emp
            End If
        Next

        Dim tongLuongTheoNhanVien As New Dictionary(Of Integer, Decimal)()
        For Each item In payItems
            Dim payrollId = If(item?.Payroll IsNot Nothing, item.Payroll.id, 0)
            If payrollId <= 0 Then Continue For
            If Not payrollMap.ContainsKey(payrollId) Then Continue For
            Dim emp = payrollMap(payrollId)?.Position?.Contract?.Employee
            If emp Is Nothing Then Continue For

            Dim giaTri = Category_PayItem.GetSign(item.category) * item.value
            If tongLuongTheoNhanVien.ContainsKey(emp.id) Then
                tongLuongTheoNhanVien(emp.id) += giaTri
            Else
                tongLuongTheoNhanVien(emp.id) = giaTri
            End If
        Next

        Dim nhom = tongLuongTheoNhanVien.
            Select(Function(kv) New With {.EmployeeId = kv.Key, .TongLuong = kv.Value}).
            OrderByDescending(Function(x) x.TongLuong).
            Take(10).
            ToList()

        For Each item In nhom
            Dim emp As Employee = Nothing
            empMap.TryGetValue(item.EmployeeId, emp)
            Dim ma = If(emp?.code, $"EMP-{item.EmployeeId}")
            Dim ten = If(emp?.name, "Không xác định")
            ketQua.Add(New BaoCaoTopLuongItem With {
                .MaNhanVien = ma,
                .TenNhanVien = ten,
                .TongLuong = item.TongLuong
            })
        Next

        Return ketQua
    End Function

End Class
