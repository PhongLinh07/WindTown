Imports System.Linq
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices.ComTypes
Imports Azure

Public Class PayrollService
    Inherits BaseService(Of Payroll)

    Private _repoPayroll As PayrollRepository = New PayrollRepository()
    Public Sub New()

        _repo = New PayrollRepository()
    End Sub


    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)


        Try
            Select Case intent
                Case DataIntent.Init_Payrolls
                    Dim period = TryCast(data, Pay_Period)

                    ' 1. Kiểm tra đối tượng có tồn tại không
                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    ' 2. Kiểm tra ngày tháng (Sửa lỗi Is Nothing cho kiểu Date)
                    ' Nếu start_date là DateTime?, dùng IsNothing. Nếu là DateTime, so sánh với DateTime.MinValue
                    If period.start_date = DateTime.MinValue OrElse period.end_date = DateTime.MinValue Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc.")
                    End If

                    ' 3. Kiểm tra logic ngày (Ngày bắt đầu phải trước ngày kết thúc)
                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If

                    ' 4. Gọi hàm thực thi logic
                    Return Init_Payrolls(period)

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


    ' Khởi tạo tất cả bảng lương của chu kỳ lương cho các nhân viên đang hoạt động | lấy theo hợp đồng   
    Private Function Init_Payrolls(ByVal period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Khởi tạo bảng lương của kỳ lương: {period.name}_____", Logger.Error)
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

    '1. Hàm tính lương cho tất cả bảng lương trong chu kỳ
    Private Function Calculator_Salary_for_All_Payroll(period As Pay_Period) As ServiceResponse(Of Object)
        Logger.Instance.Logging($"____Tính lương của kỳ lương: {period.name}_____", Logger.Information)
        Try
            'Khởi tạo các Service
            Dim attendanceSV = New AttendanceService()
            Dim policySV = New BaseService(Of Policy)


            '--- LOAD DỮ LIỆU ---
            '1. Load Payrol
            Dim response = Me.Execute(DataIntent.GetPayrollByPeriod, period)
            If Not response.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy bảng lương: {response.Message}")
            Dim payrollList As List(Of Payroll) = response.Data

            Logger.Instance.Logging($"Tìm thấy {payrollList.Count} bảng lương.", Logger.Success)

            '2. Load Attendance
            response = Me.Execute(DataIntent.GetAttendanceByPeriod, period)
            Dim attendancelList As List(Of Attendance) = response.Data
            Logger.Instance.Logging($"Tìm thấy {attendancelList.Count} dữ liệu chấm công.", Logger.Success)


            '2. Load Policy
            response = policySV.Execute(DataIntent.GetList, period)
            Dim policyList As List(Of Policy) = response.Data
            Logger.Instance.Logging($"Tìm thấy {policyList.Count} chính sách.", Logger.Success)


            ' --- TÍNH TOÁN ---
            For Each payroll In payrollList

                Dim maps As New Dictionary(Of String, Double)() ' Lưu biến luân chuyển
                Dim ITEMs As New Dictionary(Of String, Pay_Item)() ' Lưu kết quả cuối cùng để Insert

                ' Period
                maps(PolicyParameter.STD_HOURS) = period.std_hours

                ' EMployee
                maps(PolicyParameter.BASE_SALARY) = payroll.Position.Contract.base_salary
                maps(PolicyParameter.SALARY_MULT) = payroll.Position.Salary_Mult.mult


                ' 3. công thức theo chấm công mỗi ngày 
                Dim attendancePolicy = policyList.Where(Function(p) p.frequency = 1).OrderBy(Function(p) p.priority).ToList()

                ' Tổng hợp dữ liệu chấm công của từng nhân viên
                For Each row In attendancelList.Where(Function(x) x.employee_id = payroll.Position.Contract.employee_id).ToList()
                    Dim snap As New Dictionary(Of String, Double) From {
                        {PolicyParameter.OFFICE_HOURS, row.office_hours},
                        {PolicyParameter.OVERTIME_HOURS, row.overtime_hours},
                        {PolicyParameter.LATE_HOURS, row.late_hours},
                        {PolicyParameter.EARLY_LEAVE_HOURS, row.early_hours},
                        {PolicyParameter.SHIFT, row.shift},
                        {PolicyParameter.HOURLY_RATE, maps(PolicyParameter.HOURLY_RATE)}
                    }

                    ' Eval từng công thức ngày
                    For Each policy In attendancePolicy
                        If policy Is Nothing OrElse String.IsNullOrEmpty(policy.rule) Then Continue For

                        Dim value As Double = FormulaHelper.EvalFormula(policy.rule, snap)
                        Dim amount = If(policy.category = 1, value, -value)

                        If Not maps.ContainsKey(policy.code) Then maps(policy.code) = 0
                        maps(policy.code) += amount

                        UpdatePayItemDict(ITEMs, policy, maps(policy.code))
                    Next
                Next




                ' 4. CHẠY CÔNG THỨC THEO KỲ (scope = False)
                Dim periodPolicy = policyList.Where(Function(p) p.frequency = 2).OrderBy(Function(p) p.priority).ToList()

                For Each policy In periodPolicy
                    If policy Is Nothing OrElse String.IsNullOrEmpty(policy.rule) Then Continue For

                    Dim value As Double = FormulaHelper.EvalFormula(policy.rule, maps)
                    Dim finalValue = If(policy.category = 1, value, -value)

                    maps(policy.code) = finalValue
                    UpdatePayItemDict(ITEMs, policy, CSng(finalValue))
                Next

                ' 5. LƯU DATABASE
                Dim itemSV As Pay_ItemService = New Pay_ItemService()

                For Each item In ITEMs.Values
                    item.Payroll = payroll
                    itemSV.Execute(DataIntent.Insert, item)
                Next


            Next


        Catch ex As Exception
            Logger.Instance.Logging($"Tổng hợp lương lỗi: {ex.Message}", Logger.Error)
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
        End Try

        Logger.Instance.Logging($"Tổng hợp lương hoàn tất:", Logger.Success)
        Return ServiceResponse(Of Object).Success("ổng hợp lương hoàn tất")
    End Function

    'Hàm bổ trợ để tránh lặp code và lỗi Null
    Private Sub UpdatePayItemDict(dict As Dictionary(Of String, Pay_Item), policy As Policy, value As Decimal)
        If Not dict.ContainsKey(policy.code) Then
            dict(policy.code) = New Pay_Item With {.code = policy.code}
        End If

        dict(policy.code).name = policy.name
        dict(policy.code).value = value

    End Sub
End Class