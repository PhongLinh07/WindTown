Imports System.Linq
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices.ComTypes
Imports Azure
Imports Microsoft.Identity.Client.Cache


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
                    Return Gen_Default_Pay_Item(payroll)

                Case DataIntent.Cal_Net_Salary_One_Payroll
                    Dim payroll = TryCast(data, Payroll)
                    If payroll Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Dữ liệu bảng lương không hợp lệ.")
                    End If
                    Return Cal_Net_Salary_One_Payroll(payroll)

                Case DataIntent.Cal_Net_Salary_One_Period
                    Dim period = TryCast(data, Pay_Period)

                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If
                    Return Cal_Net_Salary_One_Period(period)

                Case DataIntent.Aggregation_Data_One_Payroll
                    Dim payroll = TryCast(data, Payroll)
                    If payroll Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tổng hợp dữ liệu : Dữ liệu bảng lương không hợp lệ.")
                    End If
                    Return Aggregation_Data_One_Payroll(payroll)

                Case DataIntent.Aggregation_Data_One_Period
                    Dim period = TryCast(data, Pay_Period)

                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi tính lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If
                    Return Aggregation_Data_One_Period(period)

                Case DataIntent.Init_Payrolls
                    Dim period = TryCast(data, Pay_Period)

                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If
                    Return Init_Payrolls(period)

                Case DataIntent.GetPayrollByPeriod
                    Dim period = TryCast(data, Pay_Period)

                    ' 1. Kiểm tra đối tượng có tồn tại không
                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi lấy bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    Dim result = _repoPayroll.GetPayrollByPeriod(period)
                    Return ServiceResponse(Of Object).Success(result)

                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {101}" & ex.Message, ex)
        End Try

    End Function

    Private Function Gen_Default_Pay_Item(payroll As Payroll) As ServiceResponse(Of Object)

        Try
            Dim payItemService As Pay_ItemService = New Pay_ItemService()

            Dim total_income = System_Parameter.GetParameter(System_Parameter.ID.SYS_TOTAL_INCOME)
            Dim net_deduction = System_Parameter.GetParameter(System_Parameter.ID.SYS_DEDUCTION)
            Dim net_salary = System_Parameter.GetParameter(System_Parameter.ID.SYS_NET_SALARY)

            Dim itemDefault As List(Of Pay_Item) = New List(Of Pay_Item) From {
                New Pay_Item With {.Payroll = payroll, .code = total_income.code, .name = total_income.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = total_income.priority},
                New Pay_Item With {.Payroll = payroll, .code = net_deduction.code, .name = net_deduction.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_deduction.priority},
                New Pay_Item With {.Payroll = payroll, .code = net_salary.code, .name = net_salary.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_salary.priority}
            }

            For Each item In itemDefault
                payItemService.Execute(DataIntent.Insert, item)
            Next

        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {101}" & ex.Message, ex)
        End Try
        Return ServiceResponse(Of Object).Success("")
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
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message} {225}")
        End Try
    End Function

#Region "Net salary"
    Private Function Cal_Net_Salary_One_Payroll(payroll As Payroll) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Tính lương: {payroll.code}_____", Logger.Information)
        Try
            Dim pItemSV As New Pay_ItemService()
            Dim response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, payroll)
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
                                        .Payroll = payroll,
                                        .code = param.code,
                                        .name = param.name,
                                        .value = 0,
                                        .category = param.category,
                                        .unit = param.unit,
                                        .priority = param.priority
                                      }
                                      pItemSV.Execute(DataIntent.Insert, item)
                                      items.Add(item)
                                      Logger.Instance.Logging($"Tạo Pay_Item hệ thống: {param.code}", Logger.Warning)
                                  End If
                                  Return item
                              End Function


            ' ── Tìm hoặc tạo 3 item ──────────────────────────
            Dim itemTotalIncome = GetOrCreate(System_Parameter.ID.SYS_TOTAL_INCOME)
            Dim itemTotalDeduct = GetOrCreate(System_Parameter.ID.SYS_DEDUCTION)
            Dim itemNetSalary = GetOrCreate(System_Parameter.ID.SYS_NET_SALARY)

            ' ── Tính theo sign ───────────────────────────────
            itemTotalIncome.value = items _
            .Where(Function(x) Category_PayItem.GetSign(x.category) = 1) _
            .Sum(Function(x) x.value)

            itemTotalDeduct.value = items _
            .Where(Function(x) Category_PayItem.GetSign(x.category) = -1) _
            .Sum(Function(x) x.value)

            itemNetSalary.value = itemTotalIncome.value - itemTotalDeduct.value

            ' ── Update 3 item ────────────────────────────────
            pItemSV.Execute(DataIntent.Update, itemTotalIncome)
            pItemSV.Execute(DataIntent.Update, itemTotalDeduct)
            pItemSV.Execute(DataIntent.Update, itemNetSalary)

            '' ── Snap vào payroll ─────────────────────────────
            'payrol.total_income = itemTotalIncome.value
            'payrol.net_salary = itemNetSalary.value

            Return ServiceResponse(Of Object).Success(payroll)

        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message} {167}")
        End Try
    End Function

    Private Function Cal_Net_Salary_One_Period(period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Tính lương: {period.name}_____", Logger.Information)
        Dim payrollList As List(Of Payroll)
        Dim succ = 0
        Try


            Dim response = Me.Execute(DataIntent.GetPayrollByPeriod, period)
            payrollList = If(response.IsSuccess, response.Data, New List(Of Payroll))

            Logger.Instance.Logging($"Đã tìm thấy {payrollList.Count()} bảng lương của kỳ: {response.Message}")

            If payrollList.Count = 0 Then
                Return ServiceResponse(Of Object).Success("")
            End If



            Dim pItemSV As New Pay_ItemService()

            For Each payroll In payrollList

                Logger.Instance.Logging($"Tính lương cho bảng lương: {payroll.code}", Logger.Warning)
                response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, payroll)

                If Not response.IsSuccess Then
                    Logger.Instance.Logging($"Lỗi lấy thành phần của bảng lương {payroll.code}: {response.Message}")
                    Continue For
                End If

                Dim items = CType(response.Data, IEnumerable(Of Pay_Item)).ToList()

                ' ── Hàm tìm hoặc tạo item hệ thống ──────────────
                Dim GetOrCreate = Function(sysId As System_Parameter.ID) As Pay_Item
                                      Dim param = System_Parameter.GetParameter(sysId)
                                      Dim item = items.FirstOrDefault(Function(x) x.code = param.code)
                                      If item Is Nothing Then
                                          item = New Pay_Item With {
                                        .Payroll = payroll,
                                        .code = param.code,
                                        .name = param.name,
                                        .value = 0,
                                        .category = param.category,
                                        .unit = param.unit,
                                        .priority = param.priority
                                    }
                                          pItemSV.Execute(DataIntent.Insert, item)
                                          items.Add(item)
                                          Logger.Instance.Logging($"Tạo Pay_Item hệ thống: {param.code} cho bảng lương {payroll.code}", Logger.Warning)
                                      End If
                                      Return item
                                  End Function

                ' ── Tìm hoặc tạo 3 item ──────────────────────────
                Dim itemTotalIncome = GetOrCreate(System_Parameter.ID.SYS_TOTAL_INCOME)
                Dim itemTotalDeduct = GetOrCreate(System_Parameter.ID.SYS_DEDUCTION)
                Dim itemNetSalary = GetOrCreate(System_Parameter.ID.SYS_NET_SALARY)

                ' ── Tính theo sign ───────────────────────────────
                itemTotalIncome.value = items _
                .Where(Function(x) Category_PayItem.GetSign(x.category) = 1) _
                .Sum(Function(x) x.value)

                itemTotalDeduct.value = items _
                .Where(Function(x) Category_PayItem.GetSign(x.category) = -1) _
                .Sum(Function(x) x.value)

                itemNetSalary.value = itemTotalIncome.value - itemTotalDeduct.value

                ' ── Update 3 item ────────────────────────────────
                pItemSV.Execute(DataIntent.Update, itemTotalIncome)
                pItemSV.Execute(DataIntent.Update, itemTotalDeduct)
                pItemSV.Execute(DataIntent.Update, itemNetSalary)

                '' ── Snap vào payroll ─────────────────────────────
                'payrol.total_income = itemTotalIncome.value
                'payrol.net_salary = itemNetSalary.value

                Logger.Instance.Logging($"Tính lương thành công cho bảng lương: {payroll.code}", Logger.Success)
                succ += 1

            Next

        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message} {167}")
        End Try
        Logger.Instance.Logging($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương:", Logger.Success)
        Return ServiceResponse(Of Object).Success($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương:")
    End Function

#End Region

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
        Dim che As List(Of Attendance) = res.Data

        Logger.Instance.Logging($"Load : { che.Count() } {res.Message}", Logger.Warning)
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
    Private Function LoadAllData(period As Pay_Period) As Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))

        Dim holidays = LoadHoliday(period)  ' load 1 lần
        Dim result As New Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))

        ' ── Attendance ───────────────────────────────────────────
        result(CInt(Data_Source.ID.ATTENDANCE)) = LoadAttendance(period) _
            .Select(Function(r)
                        ' Tìm xem ngày chấm công có trùng ngày lễ không
                        Dim hol = holidays.FirstOrDefault(Function(h) h.of_date = r.of_date)
                        Return New Dictionary(Of String, Double)(StringComparer.OrdinalIgnoreCase) From {
                            {"_employee_id", CDbl(r.employee_id)},
                            {System_Parameter.ID.SYS_OFFICE_HOURS.ToString(), CDbl(r.office_hours)},
                            {System_Parameter.ID.SYS_OVERTIME_HOURS.ToString(), CDbl(r.overtime_hours)},
                            {System_Parameter.ID.SYS_LATE_HOURS.ToString(), CDbl(r.late_hours)},
                            {System_Parameter.ID.SYS_EARLY_LEAVE_HOURS.ToString(), CDbl(r.early_hours)},
                            {System_Parameter.ID.SYS_SHIFT.ToString(), CDbl(r.shift)},
                            {System_Parameter.ID.SYS_IS_HOLIDAY.ToString(), If(hol IsNot Nothing, 1.0, 0.0)},
                            {System_Parameter.ID.SYS_MULT_HOLIDAY.ToString(), If(hol IsNot Nothing, CDbl(hol.mult), 1.0)}
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
            {System_Parameter.ID.SYS_BASE_SALARY.ToString(), CDbl(payroll.Position.Contract.base_salary)},
            {System_Parameter.ID.SYS_SALARY_MULT.ToString(), CDbl(payroll.Position.Salary_Mult.mult)},
            {System_Parameter.ID.SYS_STD_HOURS.ToString(), CDbl(period.std_hours)}
        }
    End Function
#End Region


    Public Function Aggregation_Data_One_Payroll(payroll As Payroll) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"Bắt đầu tổng hợp dữ liệu cho bảng lương: {payroll.code}", Logger.Information)
        Try


            ' Load và sort policy 1 lần — quan trọng: ASC theo priority
            Dim policies = LoadPolicies().Where(Function(p) p.status = 1) _
                                         .OrderBy(Function(p) p.priority) _
                                         .ToList()
            If policies.Count = 0 Then
                Return ServiceResponse(Of Object).Fail("Không có policy nào active.")
            End If

            ' Load tất cả data nguồn vào RAM, chuẩn hóa thành Dictionary
            Dim allData = LoadAllData(payroll.Pay_Period)

            Dim itemsOfPayroll As New Dictionary(Of Payroll, List(Of Pay_Item))
            Logger.Instance.Logging($"Tìm thấy {policies.Count} policy.", Logger.Information)


            ' ── BƯỚC 2: LOOP TỪNG NHÂN VIÊN ─────────────────────
            Logger.Instance.Logging($"Đang tính: {payroll.Position.Contract.employee_id}", Logger.Information)

            ' maps = bộ nhớ biến của nhân viên này
            ' Tích lũy dần: HOURLY_RATE → SUM_* → SALARY_*
            Dim maps = SeedSystemVars(payroll, payroll.Pay_Period)


            ' ── BƯỚC 3: LOOP TỪNG POLICY (đã sort theo priority)
            For Each p In policies

                ' 3A. Lấy các dòng dữ liệu cần tính
                '     data_source = null       → [{maps}]  (1 lần)
                '     data_source = "attendance"→ [row1, row2, ...]
                Dim rows = GetRows(p, payroll, maps, allData)
                If rows.Count = 0 Then
                    maps(p.code) = 0.0
                    Continue For
                End If


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

                    If Not itemsOfPayroll.ContainsKey(payroll) Then
                        itemsOfPayroll(payroll) = New List(Of Pay_Item)
                    End If

                    itemsOfPayroll(payroll).Add(New Pay_Item With {
                    .Payroll = payroll,
                    .code = p.code,
                    .name = p.name,
                    .category = p.category,
                    .priority = p.priority,
                    .unit = p.unit,
                    .value = result,
                    .note = p.note,
                    .status = 0})
                End If


            Next ' policy


            ' ── BƯỚC 4: BATCH INSERT 1 LẦN ──────────────────────
            ' Không insert từng cái trong vòng lặp → rất chậm
            If itemsOfPayroll(payroll).Count > 0 Then
                Dim reponse = BatchInsert(itemsOfPayroll)
                If Not reponse.IsSuccess Then
                    Logger.Instance.Logging(reponse.Message, Logger.Error)
                    Return ServiceResponse(Of Object).Fail(reponse.Message)
                End If
            End If

            Logger.Instance.Logging($"Hoàn tất. Đã tạo {itemsOfPayroll(payroll).Count} Pay_Items.", Logger.Success)
            Return ServiceResponse(Of Object).Success("Tổng hợp lương hoàn tất")

        Catch ex As Exception
            Logger.Instance.Logging($"Lỗi engine: {ex.Message}", Logger.Error)
            Return ServiceResponse(Of Object).Fail($"Lỗi: {ex.Message}")
        End Try
    End Function

    Public Function Aggregation_Data_One_Period(period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"Bắt đầu tổng hợp dữ liệu cho các bảng lưuong của kỳ: {period.name}", Logger.Information)
        Dim payrollList As List(Of Payroll)
        Dim succ = 0
        Try

            ' Load và sort policy 1 lần — quan trọng: ASC theo priority
            Dim policies = LoadPolicies().Where(Function(p) p.status = 1) _
                                         .OrderBy(Function(p) p.priority) _
                                         .ToList()
            If policies.Count = 0 Then
                Return ServiceResponse(Of Object).Fail("Không có policy nào active.")
            End If
            ' Load tất cả data nguồn vào RAM, chuẩn hóa thành Dictionary
            Dim allData = LoadAllData(period)

            Dim itemsOfPayroll As New Dictionary(Of Payroll, List(Of Pay_Item))
            Logger.Instance.Logging($"Tìm thấy {policies.Count} policy.", Logger.Information)
            Dim pItemSV As New Pay_ItemService()

            Dim response = Me.Execute(DataIntent.GetPayrollByPeriod, period)
            payrollList = If(response.IsSuccess, response.Data, New List(Of Payroll))

            Logger.Instance.Logging($"Đã tìm thấy {payrollList.Count()} bảng lương của kỳ: {response.Message}")

            If payrollList.Count = 0 Then
                Return ServiceResponse(Of Object).Success("")
            End If


            For Each payroll In payrollList


                ' ── BƯỚC 2: LOOP TỪNG NHÂN VIÊN ─────────────────────
                Logger.Instance.Logging($"Đang tính: {payroll.Position.Contract.employee_id}", Logger.Information)

                ' maps = bộ nhớ biến của nhân viên này
                ' Tích lũy dần: HOURLY_RATE → SUM_* → SALARY_*
                Dim maps = SeedSystemVars(payroll, payroll.Pay_Period)

                ' ── BƯỚC 3: LOOP TỪNG POLICY (đã sort theo priority)
                For Each p In policies

                    ' 3A. Lấy các dòng dữ liệu cần tính
                    '     data_source = null       → [{maps}]  (1 lần)
                    '     data_source = "attendance"→ [row1, row2, ...]
                    Dim rows = GetRows(p, payroll, maps, allData)
                    If rows.Count = 0 Then
                        maps(p.code) = 0.0
                        Continue For
                    End If


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

                        If Not itemsOfPayroll.ContainsKey(payroll) Then
                            itemsOfPayroll(payroll) = New List(Of Pay_Item)
                        End If

                        itemsOfPayroll(payroll).Add(New Pay_Item With {
                        .Payroll = payroll,
                        .code = p.code,
                        .name = p.name,
                        .category = p.category,
                        .priority = p.priority,
                        .unit = p.unit,
                        .value = result,
                        .note = p.note,
                        .status = 0})
                    End If


                Next ' policy


                succ += 1
            Next

            ' ── BƯỚC 4: BATCH INSERT 1 LẦN ──────────────────────
            ' Không insert từng cái trong vòng lặp → rất chậm
            If itemsOfPayroll.Count() > 0 Then
                Dim reponse = BatchInsert(itemsOfPayroll)
                If Not reponse.IsSuccess Then
                    Logger.Instance.Logging(reponse.Message, Logger.Error)
                    Return ServiceResponse(Of Object).Fail(reponse.Message)
                End If
            End If

            Logger.Instance.Logging($"Tổng hợp hoàn tất: {succ}/{payrollList.Count()} bảng lương.", Logger.Success)
            Return ServiceResponse(Of Object).Success($"Tổng hợp hoàn tất: {succ}/{payrollList.Count()} bảng lương.")

        Catch ex As Exception
            Logger.Instance.Logging($"Lỗi engine: {ex.Message}", Logger.Error)
            Return ServiceResponse(Of Object).Fail($"Lỗi: {ex.Message}")
        End Try
    End Function


#Region "GET ROWS"
    Private Function GetRows(policy As Policy, payroll As Payroll, maps As Dictionary(Of String, Double), allData As Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))) As List(Of Dictionary(Of String, Double))

        ' Null → không loop, tính 1 lần với maps hiện tại
        If policy.data_source = 1 Then
            Return New List(Of Dictionary(Of String, Double)) From {maps}
        End If

        If Not allData.ContainsKey(policy.data_source) Then
            Logger.Instance.Logging($"Không tìm thấy data_source: '{policy.data_source}' của policy {policy.code}", Logger.Warning)
            Return New List(Of Dictionary(Of String, Double))
        End If

        Dim empId = CDbl(payroll.Position.Contract.employee_id)

        Return allData(policy.data_source) _
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
    Private Function Aggregate(values As List(Of Double), func As Integer) As Double
        If values Is Nothing OrElse values.Count = 0 Then Return 0

        Select Case CType(func, Aggregate_Func.ID)
            Case Aggregate_Func.ID.SET_DATA : Return values.First()
            Case Aggregate_Func.ID.SUM : Return values.Sum()
            Case Aggregate_Func.ID.MAX : Return values.Max()
            Case Aggregate_Func.ID.MIN : Return values.Min()
            Case Aggregate_Func.ID.COUNT : Return CDbl(values.Count)
            Case Else
                Logger.Instance.Logging($"Hàm tính toán không hợp lệ!: '{Aggregate_Func.GetParameter(func)}", Logger.Warning)
                Return values.First()
        End Select
    End Function
#End Region



    ' ════════════════════════════════════════════════════════════════
    ' BATCH INSERT
    ' Insert tất cả Pay_Items 1 lần thay vì từng cái trong vòng lặp
    ' ════════════════════════════════════════════════════════════════
    Private Function BatchInsert(itemsOfPayroll As Dictionary(Of Payroll, List(Of Pay_Item))) As ServiceResponse(Of Object)
        Try
            Dim pItemSV As New Pay_ItemService()

            For Each payroll In itemsOfPayroll.Keys
                Dim response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, payroll)
                If Not response.IsSuccess Then
                    Return ServiceResponse(Of Object).Fail($"Lỗi lấy thành phần: {response.Message}")
                End If

                Dim existingItems = CType(response.Data, IEnumerable(Of Pay_Item)) _
                    .ToDictionary(Function(x) x.code, StringComparer.OrdinalIgnoreCase)

                For Each item In itemsOfPayroll(payroll)
                    If existingItems.ContainsKey(item.code) Then
                        Dim existing = existingItems(item.code)

                        ' Bảo vệ custom item
                        If existing.source = Pay_Item.source_custum Then
                            Logger.Instance.Logging($"Bỏ qua [{item.code}] — source: {existing.source_UI}", Logger.Warning)
                            Continue For
                        End If
                        item.id = existing.id
                        pItemSV.Execute(DataIntent.Update, item)
                    Else
                        pItemSV.Execute(DataIntent.Insert, item)
                    End If
                Next
            Next

            Logger.Instance.Logging(
                $"BatchInsert thành công: {itemsOfPayroll.Count} bảng lương", Logger.Success)
            Return ServiceResponse(Of Object).Success("")

        Catch ex As Exception
            Logger.Instance.Logging($"Lỗi BatchInsert: {ex.Message}", Logger.Error)
            Return ServiceResponse(Of Object).Fail($"Lỗi BatchInsert: {ex.Message}")
        End Try
    End Function


End Class