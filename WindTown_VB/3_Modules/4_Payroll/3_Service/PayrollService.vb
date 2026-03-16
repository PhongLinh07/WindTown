Imports System.Linq
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices.ComTypes
Imports Azure
Imports WindTown_VB.PolicyParameter


Public Class PayrollService
    Inherits BaseService(Of Payroll)

    Private _repoPayroll As PayrollRepository = New PayrollRepository()
    Public Sub New()

        _repo = New PayrollRepository()
    End Sub


    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)


        Try
            Select Case intent
                Case DataIntent.Insert

                    Dim payroll = TryCast(data, Payroll)
                    payroll.id = MyBase.Execute(intent, payroll).Data

                    Dim pItemSV As Pay_ItemService = New Pay_ItemService()

                    Dim total_income = PolicyParameter.System_Parameter.GetParameter(PolicyParameter.System_Parameter.ID.SYS_TOTAL_INCOME)
                    Dim net_deduction = PolicyParameter.System_Parameter.GetParameter(PolicyParameter.System_Parameter.ID.SYS_DEDUCTION)
                    Dim net_salary = PolicyParameter.System_Parameter.GetParameter(PolicyParameter.System_Parameter.ID.SYS_NET_SALARY)

                    Dim itemDefault As List(Of Pay_Item) = New List(Of Pay_Item) From {
                        New Pay_Item With {.Payroll = payroll, .code = total_income.code, .name = total_income.name, .value = 0, .category = CInt(PolicyParameter.Category_Amount.ID.INCOME), .priority = 70},
                        New Pay_Item With {.Payroll = payroll, .code = net_deduction.code, .name = net_deduction.name, .value = 0, .category = CInt(PolicyParameter.Category_Amount.ID.DEDUCTION), .priority = 90},
                        New Pay_Item With {.Payroll = payroll, .code = net_salary.code, .name = net_salary.name, .value = 0, .category = CInt(PolicyParameter.Category_Amount.ID.INCOME), .priority = 100}
                    }

                    For Each item In itemDefault
                        pItemSV.Execute(DataIntent.Insert, item)
                    Next
                    Return ServiceResponse(Of Object).Success("")
                Case DataIntent.Cal_Net_Salary_One_Payroll
                    Dim payroll = TryCast(data, Payroll)
                    If payroll Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Dữ liệu bảng lương không hợp lệ.")
                    End If
                    Return Cal_Net_Salary_One_Payroll(payroll)
                Case DataIntent.Init_Payrolls
                    Dim period = TryCast(data, Pay_Period)

                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If

                    ' 4. Gọi hàm thực thi logic
                    Return Init_Payrolls(period)

                Case DataIntent.Calculate_for_All_Payroll_By_Period
                    Dim period = TryCast(data, Pay_Period)

                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If

                    ' 4. Gọi hàm thực thi logic
                    Return Calculate_for_All_Payroll_By_Period(period)

                Case DataIntent.GetPayrollByPeriod
                    Dim period = TryCast(data, Pay_Period)

                    ' 1. Kiểm tra đối tượng có tồn tại không
                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi lấy bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    ' 2. Gọi hàm thực thi logic
                    Return _repoPayroll.GetPayrollByPeriod(period)

                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try

    End Function


    Private Function Cal_Net_Salary_One_Payroll(payrol As Payroll) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Tính lương: {payrol.code}_____", Logger.Information)
        Try
            Dim pItemSV As New Pay_ItemService()
            Dim response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, payrol)
            If Not response.IsSuccess Then
                Return ServiceResponse(Of Object).Fail($"Lỗi lấy thành phần: {response.Message}")
            End If

            Dim items = CType(response.Data, IEnumerable(Of Pay_Item)).ToList()

            ' ── Hàm tìm hoặc tạo item hệ thống ──────────────
            Dim GetOrCreate = Function(sysId As System_Parameter.ID) As Pay_Item
                                  Dim param = System_Parameter.GetParameter(sysId)
                                  Dim item = items.FirstOrDefault(Function(x) x.code = param.code)
                                  If item Is Nothing Then
                                      item = New Pay_Item With {
                                        .Payroll = payrol,
                                        .code = param.code,
                                        .name = param.name,
                                        .value = 0,
                                        .category = CInt(Category_Amount.ID.INFORMATION),
                                        .priority = CInt(sysId)
                                    }
                                      pItemSV.Execute(DataIntent.Insert, item)
                                      items.Add(item)
                                      Logger.Instance.Logging(
                    $"Tạo Pay_Item hệ thống: {param.code}", Logger.Warning)
                                  End If
                                  Return item
                              End Function

            ' ── Tìm hoặc tạo 3 item ──────────────────────────
            Dim itemTotalIncome = GetOrCreate(System_Parameter.ID.SYS_TOTAL_INCOME)
            Dim itemTotalDeduct = GetOrCreate(System_Parameter.ID.SYS_DEDUCTION)
            Dim itemNetSalary = GetOrCreate(System_Parameter.ID.SYS_NET_SALARY)

            ' ── Tính theo sign ───────────────────────────────
            itemTotalIncome.value = items _
            .Where(Function(x) Category_Amount.GetSign(x.category) = 1) _
            .Sum(Function(x) x.value)

            itemTotalDeduct.value = items _
            .Where(Function(x) Category_Amount.GetSign(x.category) = -1) _
            .Sum(Function(x) x.value)

            itemNetSalary.value = itemTotalIncome.value - itemTotalDeduct.value

            ' ── Update 3 item ────────────────────────────────
            pItemSV.Execute(DataIntent.Update, itemTotalIncome)
            pItemSV.Execute(DataIntent.Update, itemTotalDeduct)
            pItemSV.Execute(DataIntent.Update, itemNetSalary)

            '' ── Snap vào payroll ─────────────────────────────
            'payrol.total_income = itemTotalIncome.value
            'payrol.net_salary = itemNetSalary.value

            Return ServiceResponse(Of Object).Success(payrol)

        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
        End Try
    End Function

    ' Khởi tạo tất cả bảng lương của chu kỳ lương cho các nhân viên đang hoạt động | lấy theo hợp đồng   
    Private Function Init_Payrolls(ByVal period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Khởi tạo bảng lương của kỳ lương: {period.name}_____", Logger.Information)
        Try
            ' 1. Khởi tạo Services
            Dim contractService As New ContractService()
            Dim positionService As New PositionService()

            ' 2. Load và Lọc Hợp đồng (Lấy dữ liệu thô một lần để tối ưu máy B)
            Dim resContract = contractService.Execute(DataIntent.GetList)
            If Not resContract.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy hợp đồng: {resContract.Message}")

            Dim contractList = CType(resContract.Data, IEnumerable(Of Contract)).Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
            (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)).ToList()

            ' 3. Load và Lọc Chức vụ (Dùng GroupBy để tránh lỗi trùng Key nếu 1 Hợp đồng có nhiều chức vụ)
            Dim resPos = positionService.Execute(DataIntent.GetList)
            If Not resPos.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy chức vụ: {resPos.Message}")

            ' Lookup cho phép: contract_id -> List(Of Position)
            Dim positionLookup = CType(resPos.Data, IEnumerable(Of Position)).Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
            (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)).ToLookup(Function(x) x.contract_id)

            ' 4. Thực thi khởi tạo
            Dim countSucc As Integer = 0
            For Each ctr In contractList

                ' Lấy tất cả chức vụ thuộc hợp đồng này trong kỳ
                Dim positionsInPeriod = positionLookup(ctr.id)

                If Not positionsInPeriod.Any() Then
                    Logger.Instance.Logging($"Bỏ qua {ctr.employee_UI}: Không có chức vụ nào trong kỳ.", Logger.Error)
                    Continue For
                End If

                ' Lặp qua từng chức vụ để tạo bảng lương tương ứng
                For Each pos In positionsInPeriod
                    Dim pRow As New Payroll With {
                    .Pay_Period = period,
                    .Position = pos,
                    .status = 1}

                    ' Lưu từng dòng
                    If Me.Execute(DataIntent.Insert, pRow).IsSuccess Then
                        countSucc += 1
                    End If
                Next
            Next

            Dim msg = $"Khởi tạo thành công: {countSucc}/{contractList.Count}"
            Logger.Instance.Logging(msg, Logger.Success)
            Return ServiceResponse(Of Object).Success(msg)

        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
        End Try
    End Function



#Region "LOAD HELPERS — gọi service/repo tương ứng"
    Private Function LoadPayrolls(period As Pay_Period) As List(Of Payroll)
        Dim sv As New PayrollService()
        Dim res = sv.Execute(DataIntent.GetPayrollByPeriod, period)
        Return If(res.IsSuccess, res.Data, New List(Of Payroll)())
    End Function

    Private Function LoadPolicies() As List(Of Policy)
        Dim sv As New BaseService(Of Policy)
        Dim res = sv.Execute(DataIntent.GetList, Nothing)
        Return If(res.IsSuccess, res.Data, New List(Of Policy)())
    End Function

    Private Function LoadAttendance(period As Pay_Period) As List(Of Attendance)
        Dim sv As New AttendanceService()
        Dim res = sv.Execute(DataIntent.GetAttendanceByPeriod, period)
        Return If(res.IsSuccess, res.Data, New List(Of Attendance)())
    End Function

    Private Function LoadHoliday(period As Pay_Period) As List(Of Holiday)
        Dim sv As New BaseService(Of Holiday)
        Dim res = sv.Execute(DataIntent.GetList, period)

        Dim holidays As List(Of Holiday) = If(res.IsSuccess, res.Data, New List(Of Holiday)())

        Return holidays.
        Where(Function(x) x.of_date.Date >= period.start_date AndAlso x.of_date.Date <= period.end_date).
        Select(Function(x) x).ToList()
    End Function
#End Region


#Region " LOAD ALL DATA"
    ' Load và chuẩn hóa tất cả nguồn dữ liệu thành Dictionary
    ' Key bắt đầu "_" là metadata (không đưa vào công thức)
    ' Muốn thêm nguồn dữ liệu mới (VD: sales, production)
    ' → thêm block ở đây, không đụng gì engine bên trên"
    ' ════════════════════════════════════════════════════════════════
    Private Function LoadAllData(period As Pay_Period) As Dictionary(Of String, List(Of Dictionary(Of String, Double)))

        Dim holidays = LoadHoliday(period)  ' load 1 lần

        Dim result As New Dictionary(Of String, List(Of Dictionary(Of String, Double)))(StringComparer.OrdinalIgnoreCase)

        ' ── Attendance ───────────────────────────────────────────
        result(PolicyParameter.Data_Source.ID.ATTENDANCE) = LoadAttendance(period) _
            .Select(Function(r)
                        ' Tìm xem ngày chấm công có trùng ngày lễ không
                        Dim hol = holidays.FirstOrDefault(Function(h) h.of_date = r.of_date)
                        Return New Dictionary(Of String, Double)(StringComparer.OrdinalIgnoreCase) From {
                            {"_employee_id", CDbl(r.employee_id)},
                            {PolicyParameter.System_Parameter.ID.SYS_OFFICE_HOURS, CDbl(r.office_hours)},
                            {PolicyParameter.System_Parameter.ID.SYS_OVERTIME_HOURS, CDbl(r.overtime_hours)},
                            {PolicyParameter.System_Parameter.ID.SYS_LATE_HOURS, CDbl(r.late_hours)},
                            {PolicyParameter.System_Parameter.ID.SYS_EARLY_LEAVE_HOURS, CDbl(r.early_hours)},
                            {PolicyParameter.System_Parameter.ID.SYS_SHIFT, CDbl(r.shift)},
                            {PolicyParameter.System_Parameter.ID.SYS_IS_HOLIDAY, If(hol IsNot Nothing, 1.0, 0.0)},
                            {PolicyParameter.System_Parameter.ID.SYS_MULT_HOLIDAY, If(hol IsNot Nothing, CDbl(hol.mult), 1.0)}
                        }
                    End Function).ToList()



        ' ── Thêm nguồn mới ở đây ─────────────────────────────────
        ' result("sales") = LoadSales(period).Select(...).ToList()

        Return result
    End Function

#End Region


#Region "SEED SYSTEM VARS"
    ' Biến hệ thống — lấy thẳng từ DB, không qua công thức
    ' Đây là "nguyên liệu đầu vào" của toàn bộ engine
    ' Muốn thêm biến hệ thống mới → thêm dòng ở đây

    Private Function SeedSystemVars(payroll As Payroll, period As Pay_Period) As Dictionary(Of String, Double)
        Return New Dictionary(Of String, Double)(StringComparer.OrdinalIgnoreCase) From {
            {PolicyParameter.System_Parameter.ID.SYS_BASE_SALARY, CDbl(payroll.Position.Contract.base_salary)},
            {PolicyParameter.System_Parameter.ID.SYS_SALARY_MULT, CDbl(payroll.Position.Salary_Mult.mult)},
            {PolicyParameter.System_Parameter.ID.SYS_STD_HOURS, CDbl(period.std_hours)}
        }
    End Function
#End Region


    ' ════════════════════════════════════════════════════════════════
    ' HÀM CHÍNH
    ' ════════════════════════════════════════════════════════════════
    Public Function Calculate_for_All_Payroll_By_Period(period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"Bắt đầu tính lương kỳ: {period.name}", Logger.Information)
        Try

            ' ── BƯỚC 1: LOAD DATA 1 LẦN ──────────────────────────
            Dim payrolls = LoadPayrolls(period)
            If payrolls Is Nothing OrElse payrolls.Count = 0 Then
                Return ServiceResponse(Of Object).Fail("Không có bảng lương nào.")
            End If

            ' Load và sort policy 1 lần — quan trọng: ASC theo priority
            Dim policies = LoadPolicies().Where(Function(p) p.status = 1) _
                                         .OrderBy(Function(p) p.priority) _
                                         .ToList()
            If policies.Count = 0 Then
                Return ServiceResponse(Of Object).Fail("Không có policy nào active.")
            End If

            ' Load tất cả data nguồn vào RAM, chuẩn hóa thành Dictionary
            Dim allData = LoadAllData(period)

            Dim allItems As New List(Of Pay_Item)()
            Logger.Instance.Logging($"Tìm thấy {payrolls.Count} bảng lương, {policies.Count} policy.", Logger.Information)


            ' ── BƯỚC 2: LOOP TỪNG NHÂN VIÊN ─────────────────────
            For Each payroll In payrolls
                Logger.Instance.Logging($"Đang tính: {payroll.Position.Contract.employee_id}", Logger.Information)

                ' maps = bộ nhớ biến của nhân viên này
                ' Tích lũy dần: HOURLY_RATE → SUM_* → SALARY_*
                Dim maps = SeedSystemVars(payroll, period)


                ' ── BƯỚC 3: LOOP TỪNG POLICY (đã sort theo priority)
                For Each p In policies

                    ' 3A. Lấy các dòng dữ liệu cần tính
                    '     data_source = null       → [{maps}]  (1 lần)
                    '     data_source = "attendance"→ [row1, row2, ...]
                    Dim rows = GetRows(p.data_source, payroll, maps, allData)

                    If rows.Count = 0 Then Continue For

                    ' 3B. Eval công thức cho từng dòng
                    Dim values As New List(Of Double)()
                    For Each row In rows
                        Dim v = FormulaHelper.EvalFormula(p.rule, row)
                        values.Add(v)
                    Next

                    ' 3C. Tổng hợp: sum / max / min / set / count
                    Dim result = Aggregate(values, p.aggregate)

                    ' 3D. Lưu vào maps để policy sau dùng được
                    '     VD: SUM_OFFICE_HOURS = 168.5
                    '         → SALARY_MAIN = SUM_OFFICE_HOURS * HOURLY_RATE dùng được
                    maps(p.code) = result

                    ' 3E. Tạo Pay_Item nếu là khoản tiền thực
                    If p.gen_item = 1 Then
                        allItems.Add(New Pay_Item With {
                            .Payroll = payroll,
                            .code = p.code,
                            .name = p.name,
                            .value = CDec(ApplySign(result, p.category)),
                            .note = p.note,
                            .status = 1
                        })
                    End If

                Next ' policy


            Next ' payroll


            ' ── BƯỚC 4: BATCH INSERT 1 LẦN ──────────────────────
            ' Không insert từng cái trong vòng lặp → rất chậm
            If allItems.Count > 0 Then
                BatchInsert(allItems)
            End If

            Logger.Instance.Logging($"Hoàn tất. Đã tạo {allItems.Count} Pay_Items.", Logger.Success)
            Return ServiceResponse(Of Object).Success("Tính lương hoàn tất")

        Catch ex As Exception
            Logger.Instance.Logging($"Lỗi engine: {ex.Message}", Logger.Error)
            Return ServiceResponse(Of Object).Fail($"Lỗi: {ex.Message}")
        End Try
    End Function





#Region "GET ROWS"
    ' Trả về list dòng dữ liệu cần tính cho policy này
    ' Mỗi dòng là Dictionary(tên_biến → số) — sẵn sàng để Eval
    '
    ' data_source = null        → [{maps}]         tính 1 lần
    ' data_source = "attendance"→ các dòng chấm công của nhân viên
    ' data_source = "leave"     → các đơn nghỉ phép của nhân viên
    ' data_source = "holiday"   → ngày lễ (áp dụng chung, không filter emp)
    ' ════════════════════════════════════════════════════════════════
    Private Function GetRows(source As String, payroll As Payroll,
                             maps As Dictionary(Of String, Double),
                             allData As Dictionary(Of String, List(Of Dictionary(Of String, Double)))
                             ) As List(Of Dictionary(Of String, Double))

        ' Null → không loop, tính 1 lần với maps hiện tại
        If String.IsNullOrEmpty(source) Then
            Return New List(Of Dictionary(Of String, Double)) From {
                New Dictionary(Of String, Double)(maps)
            }
        End If

        If Not allData.ContainsKey(source) Then
            Logger.Instance.Logging($"Không tìm thấy data_source: '{source}'", Logger.Warning)
            Return New List(Of Dictionary(Of String, Double))()
        End If

        Dim empId = CDbl(payroll.Position.Contract.employee_id)

        Return allData(source) _
            .Where(Function(r)
                       ' Holiday không có _emp_id → áp dụng cho tất cả
                       If Not r.ContainsKey("_employee_id") Then Return True
                       Return r("_employee_id") = empId
                   End Function) _
            .Select(Function(r)
                        ' Copy maps vào snap (để dùng HOURLY_RATE đã tính)
                        ' Ghi đè bằng biến của dòng hiện tại (OFFICE_HOURS...)
                        Dim snap = New Dictionary(Of String, Double)(maps, StringComparer.OrdinalIgnoreCase)
                        For Each kv In r
                            If Not kv.Key.StartsWith("_employee_id") Then
                                snap(kv.Key) = kv.Value
                            End If
                        Next
                        Return snap
                    End Function).ToList()
    End Function

#End Region


#Region "AGGREGATE TYPE"
    ' Làm gì với list kết quả Eval của tất cả dòng
    '
    ' 1_"set"   → giá trị đầu tiên  (dùng khi data_source = null)
    ' 2_"sum"   → tổng              (cộng dồn qua các ngày)
    ' 3_"max"   → lớn nhất          (VD: ngày đi muộn nhất)
    ' 4_"min"   → nhỏ nhất
    ' 5_"count" → đếm số dòng       (VD: số ngày đi làm)

    ' ════════════════════════════════════════════════════════════════
    Private Function Aggregate(values As List(Of Double),
                               aggregate_func As Integer) As Double
        If values Is Nothing OrElse values.Count = 0 Then Return 0

        Select Case aggregate_func
            Case PolicyParameter.Aggregate_Func.ID.SET_DATA : Return values.First()
            Case PolicyParameter.Aggregate_Func.ID.SUM : Return values.Sum()
            Case PolicyParameter.Aggregate_Func.ID.MAX : Return values.Max()
            Case PolicyParameter.Aggregate_Func.ID.MIN : Return values.Min()
            Case PolicyParameter.Aggregate_Func.ID.COUNT : Return CDbl(values.Count)
            Case Else
                Logger.Instance.Logging($"Kiêu tính toán không hợp lệ: '{PolicyParameter.Aggregate_Func.GetParameter(aggregate_func)}", Logger.Warning)
                Return values.First()
        End Select
    End Function
#End Region


    ' ════════════════════════════════════════════════════════════════
    ' APPLY SIGN
    ' "negative" → giá trị âm (khấu trừ, bảo hiểm)
    ' "positive" → giá trị dương (thu nhập, phụ cấp)
    ' ════════════════════════════════════════════════════════════════
    Private Function ApplySign(value As Double, category As Integer) As Double
        Return PolicyParameter.Category_Amount.GetParameter(category).sign * Math.Abs(value)
    End Function


    ' ════════════════════════════════════════════════════════════════
    ' BATCH INSERT
    ' Insert tất cả Pay_Items 1 lần thay vì từng cái trong vòng lặp
    ' ════════════════════════════════════════════════════════════════
    Private Sub BatchInsert(items As List(Of Pay_Item))
        Dim sv As New Pay_ItemService()
        For Each item In items
            sv.Execute(DataIntent.Insert, item)
        Next
    End Sub



End Class