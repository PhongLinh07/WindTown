' 1
Public Class AppServices
    ' Định nghĩa các ReadOnly Service cho toàn bộ hệ thống
    Public ReadOnly DepartmentSV
    Public ReadOnly JobSV
    Public ReadOnly LevelSV
    Public ReadOnly Salary_MultSV
    Public ReadOnly EmployeeSV
    Public ReadOnly ContractSV
    Public ReadOnly PositionSV
    Public ReadOnly ProjectSV
    Public ReadOnly AssigmentSV
    Public ReadOnly AttendanceSV
    Public ReadOnly HolidaySV
    Public ReadOnly Leave_CatSV
    Public ReadOnly LeaveSV
    Public ReadOnly PolicySV
    Public ReadOnly Pay_PeriodSV
    Public ReadOnly PayrollSV
    Public ReadOnly Pay_ItemSV
    Public ReadOnly AccountSV

    ' Singleton pattern - Chỉ duy nhất 1 instance trong suốt vòng đời ứng dụng
    Private Shared _instance As AppServices
    Public Shared ReadOnly Property Instance As AppServices
        Get
            If _instance Is Nothing Then
                _instance = New AppServices()
            End If
            Return _instance
        End Get
    End Property

    ' Constructor Private: Khởi tạo các Service
    Private Sub New()

        DepartmentSV = New BaseService(Of Department)()
        JobSV = New JobService()
        LevelSV = New BaseService(Of Level)()
        Salary_MultSV = New Salary_MultService()

        EmployeeSV = New EmployeeService()
        ContractSV = New ContractService()
        PositionSV = New PositionService()

        ProjectSV = New ProjectService()
        AssigmentSV = New AssignmentService()
        AttendanceSV = New AttendanceService()
        HolidaySV = New BaseService(Of Holiday)()
        Leave_CatSV = New BaseService(Of Leave_Cat)()
        LeaveSV = New LeaveService()

        PolicySV = New BaseService(Of Policy)()
        Pay_PeriodSV = New Pay_PeriodService()
        PayrollSV = New PayrollService()
        Pay_ItemSV = New Pay_ItemService()
        AccountSV = New BaseService(Of Account)()

    End Sub

#Region "Base Service"
    Public Interface IBaseService
        Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
    End Interface

    Private Class BaseService(Of T As {BaseEntity, New})
        Implements IBaseService

        Protected _repo As GenericRepository(Of T)
        Protected _ctx As AppDbContext

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New GenericRepository(Of T)(_ctx)
        End Sub

        Public Overridable Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object) Implements IBaseService.Execute
            Try
                Select Case intent

                    Case DataIntent.GetList
                        Return ServiceResponse(Of Object).Success(_repo.GetList())

                    Case DataIntent.Insert
                        Try
                            Dim result = _repo.Insert(DirectCast(data, T))
                            Return ServiceResponse(Of Object).Success(result, "Thêm mới thành công!")
                        Catch ex As Exception
                            Return ServiceResponse(Of Object).Fail("Không thể thêm: " & ex.Message, ex)
                        End Try

                    Case DataIntent.Update
                        Try
                            Dim result = _repo.Update(DirectCast(data, T))
                            Return ServiceResponse(Of Object).Success(result, "Cập nhật thành công!")
                        Catch ex As Exception
                            Return ServiceResponse(Of Object).Fail("Không thể cập nhật: " & ex.Message, ex)
                        End Try

                    Case DataIntent.SoftDeleteMany
                        Try
                            Dim items = DirectCast(data, IEnumerable(Of T))
                            For Each item In items
                                _repo.Delete(item.id)
                            Next
                            Return ServiceResponse(Of Object).Success(True, "Xóa thành công!")
                        Catch ex As Exception
                            Return ServiceResponse(Of Object).Fail("Không thể xóa: " & ex.Message, ex)
                        End Try

                    Case Else
                        Return ServiceResponse(Of Object).Fail("Yêu cầu không hợp lệ")

                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function

    End Class
#End Region



#Region "Module Tổ chức"

    Private Class JobService
        Inherits BaseService(Of Job)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New JobRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Return MyBase.Execute(intent, data)
        End Function
    End Class

    Private Class Salary_MultService
        Inherits BaseService(Of Salary_Mult)

        Private _repoMult As SalaryMultRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New SalaryMultRepository(_ctx)
            _repoMult = New SalaryMultRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetSalaryMultItemByJob
                        Dim job As Job = TryCast(data, Job)
                        If job Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Dữ liệu Job không hợp lệ.")
                        End If
                        Return ServiceResponse(Of Object).Success(_repoMult.GetByJob(job))

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

#End Region

#Region "Module Nhân sự"

    Private Class EmployeeService
        Inherits BaseService(Of Employee)

        Private _repoEmp As EmployeeRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New EmployeeRepository(_ctx)
            _repoEmp = New EmployeeRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetEmployeesWithoutAccount
                        Return ServiceResponse(Of Object).Success(_repoEmp.GetWithoutAccount())

                    Case DataIntent.GetEmployeesWithoutContract
                        Return ServiceResponse(Of Object).Success(_repoEmp.GetWithoutContract())

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Private Class ContractService
        Inherits BaseService(Of Contract)

        Private _repoCustom As ContractRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New ContractRepository(_ctx)
            _repoCustom = New ContractRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetContractsWithoutPosition
                        Return ServiceResponse(Of Object).Success(_repoCustom.GetWithoutPosition())

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Private Class PositionService
        Inherits BaseService(Of Position)

        Private _repoPos As PositionRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PositionRepository(_ctx)
            _repoPos = New PositionRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetPositionsWithoutAssignment
                        Return ServiceResponse(Of Object).Success(_repoPos.GetWithoutAssignment())

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class
#End Region

#Region "Module Vận hành"

    Private Class ProjectService
        Inherits BaseService(Of Project)

        Private _repoProj As ProjectRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New ProjectRepository(_ctx)
            _repoProj = New ProjectRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetProjectsIsActive
                        Return ServiceResponse(Of Object).Success(_repoProj.GetActive())

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Private Class AssignmentService
        Inherits BaseService(Of Assignment)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AssignmentRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Return MyBase.Execute(intent, data)
        End Function
    End Class

    Private Class AttendanceService
        Inherits BaseService(Of Attendance)

        Private _repoAtt As AttendanceRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AttendanceRepository(_ctx)
            _repoAtt = New AttendanceRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetAttendanceByPeriod
                        Dim period = TryCast(data, Pay_Period)
                        If period Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công: Dữ liệu kỳ lương không hợp lệ.")
                        End If
                        If period.start_date > period.end_date Then
                            Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                        End If
                        Return ServiceResponse(Of Object).Success(_repoAtt.GetByPeriod(period))

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Private Class LeaveService
        Inherits BaseService(Of Leave)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New LeaveRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Return MyBase.Execute(intent, data)
        End Function
    End Class

#End Region

#Region "Module Tài chính"

    Private Class Pay_PeriodService
        Inherits BaseService(Of Pay_Period)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayPeriodRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.StandardHoursCalculator
                        Dim period As Pay_Period = TryCast(data, Pay_Period)
                        If period Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Dữ liệu kỳ lương không hợp lệ.")
                        End If
                        Dim stdHours = Std_Hours_Calculator(period.start_date, period.end_date)
                        Return ServiceResponse(Of Object).Success(stdHours)

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function

        Private Function Std_Hours_Calculator(startDate As Date, endDate As Date) As Decimal
            Dim startD As Date = startDate.Date
            Dim endD As Date = endDate.Date

            Logger.Instance.Logging("<----------------------- Tính ngày công chuẩn ---------------------->", Logger.Information)

            Dim holidayService As New BaseService(Of Holiday)
            Dim response = holidayService.Execute(DataIntent.GetList)

            Dim holidays As New List(Of Holiday)
            If Not response.IsSuccess Then
                Logger.Instance.Logging($"Tải ngày lễ thất bại: {response.Message}", Logger.Error)
            Else
                Logger.Instance.Logging($"Tải ngày lễ thành công", Logger.Success)
                holidays = response.Data
            End If

            Dim holidayDates = holidays _
            .Where(Function(x) x.of_date.Date >= startD AndAlso x.of_date.Date <= endD) _
            .Select(Function(x) x.of_date.Date) _
            .ToList()

            Dim stdDays As Integer = StandardHoursCalculator.StdWorkingDays(startD, endD, holidayDates)
            Dim stdHours As Decimal = stdDays * 8

            Logger.Instance.Logging($"Số giờ làm việc chuẩn: {stdHours} giờ.", Logger.Information)
            Return stdHours
        End Function
    End Class

    Private Class Pay_ItemService
        Inherits BaseService(Of Pay_Item)

        Private _repoPayItem As PayItemRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayItemRepository(_ctx)
            _repoPayItem = New PayItemRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.GetPayItemByPayroll
                        Dim payroll As Payroll = TryCast(data, Payroll)
                        If payroll Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Dữ liệu bảng lương không hợp lệ.")
                        End If
                        Return ServiceResponse(Of Object).Success(_repoPayItem.GetByPayroll(payroll))

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Private Class PayrollService
        Inherits BaseService(Of Payroll)

        Private _repoPayroll As PayrollRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayrollRepository(_ctx)
            _repoPayroll = New PayrollRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.Insert
                        Dim payroll = TryCast(data, Payroll)
                        If payroll Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Dữ liệu bảng lương không hợp lệ.")
                        End If

                        ' ✅ Insert Payroll trước
                        Dim insertResult = MyBase.Execute(intent, payroll)
                        If Not insertResult.IsSuccess Then
                            Return insertResult
                        End If

                        ' ✅ payroll.id đã được GenericRepository.Insert copy về rồi
                        ' Kiểm tra chắc chắn
                        If payroll.id = 0 Then
                            Return ServiceResponse(Of Object).Fail("Không lấy được id sau khi Insert Payroll.")
                        End If

                        ' ✅ Tạo Pay_Item mặc định với payroll.id thật
                        Return Gen_Default_Pay_Item(payroll)

                    Case DataIntent.GetPayrollByPeriod
                        Dim period = TryCast(data, Pay_Period)
                        If period Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Lỗi lấy bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                        End If
                        Return ServiceResponse(Of Object).Success(_repoPayroll.GetByPeriod(period))

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
                            Return ServiceResponse(Of Object).Fail("Lỗi tổng hợp dữ liệu: Dữ liệu bảng lương không hợp lệ.")
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

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}", ex)
            End Try
        End Function

        Private Function Gen_Default_Pay_Item(payroll As Payroll) As ServiceResponse(Of Object)
            Try
                Dim payItemService As New Pay_ItemService()

                Dim total_income = System_Parameter.GetParameter(System_Parameter.ID.SYS_TOTAL_INCOME)
                Dim net_deduction = System_Parameter.GetParameter(System_Parameter.ID.SYS_DEDUCTION)
                Dim net_salary = System_Parameter.GetParameter(System_Parameter.ID.SYS_NET_SALARY)

                Dim itemDefault As New List(Of Pay_Item) From {
                New Pay_Item With {.payroll_id = payroll.id, .code = total_income.code, .name = total_income.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = total_income.priority},
                New Pay_Item With {.payroll_id = payroll.id, .code = net_deduction.code, .name = net_deduction.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_deduction.priority},
                New Pay_Item With {.payroll_id = payroll.id, .code = net_salary.code, .name = net_salary.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_salary.priority}
            }

                For Each item In itemDefault
                    payItemService.Execute(DataIntent.Insert, item)
                Next

            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}", ex)
            End Try
            Return ServiceResponse(Of Object).Success("")
        End Function

        Private Function Init_Payrolls(ByVal period As Pay_Period) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"____Khởi tạo bảng lương của kỳ lương: {period.name}_____", Logger.Information)
            Try
                Dim contractService As New ContractService()
                Dim positionService As New PositionService()

                Dim resContract = contractService.Execute(DataIntent.GetList)
                If Not resContract.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy hợp đồng: {resContract.Message}")

                Dim contractList = CType(resContract.Data, IEnumerable(Of Contract)) _
                .Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
                    (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)) _
                .ToList()

                Dim resPos = positionService.Execute(DataIntent.GetList)
                If Not resPos.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy chức vụ: {resPos.Message}")

                Dim positionLookup = CType(resPos.Data, IEnumerable(Of Position)) _
                .Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
                    (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)) _
                .ToLookup(Function(x) x.contract_id)

                Dim countSucc As Integer = 0
                For Each ctr In contractList
                    Dim positionsInPeriod = positionLookup(ctr.id)
                    If Not positionsInPeriod.Any() Then
                        Logger.Instance.Logging($"Bỏ qua {ctr.employee_UI}: Không có chức vụ nào trong kỳ.", Logger.Error)
                        Continue For
                    End If

                    For Each pos In positionsInPeriod
                        Dim pRow As New Payroll With {
                        .period_id = period.id,    ' ✅ FK
                        .position_id = pos.id,     ' ✅ FK
                        .status = 1
                    }
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

                Dim GetOrCreate = Function(sysId As System_Parameter.ID) As Pay_Item
                                      Dim param = System_Parameter.GetParameter(sysId)
                                      Dim item = items.FirstOrDefault(Function(x) x.code = param.code)
                                      If item Is Nothing Then
                                          item = New Pay_Item With {
                                          .payroll_id = payroll.id, .code = param.code, .name = param.name,
                                          .value = 0, .category = param.category, .unit = param.unit, .priority = param.priority
                                      }
                                          pItemSV.Execute(DataIntent.Insert, item)
                                          items.Add(item)
                                          Logger.Instance.Logging($"Tạo Pay_Item hệ thống: {param.code}", Logger.Warning)
                                      End If
                                      Return item
                                  End Function

                Dim itemTotalIncome = GetOrCreate(System_Parameter.ID.SYS_TOTAL_INCOME)
                Dim itemTotalDeduct = GetOrCreate(System_Parameter.ID.SYS_DEDUCTION)
                Dim itemNetSalary = GetOrCreate(System_Parameter.ID.SYS_NET_SALARY)

                itemTotalIncome.value = items.Where(Function(x) Category_PayItem.GetSign(x.category) = 1).Sum(Function(x) x.value)
                itemTotalDeduct.value = items.Where(Function(x) Category_PayItem.GetSign(x.category) = -1).Sum(Function(x) x.value)
                itemNetSalary.value = itemTotalIncome.value - itemTotalDeduct.value

                pItemSV.Execute(DataIntent.Update, itemTotalIncome)
                pItemSV.Execute(DataIntent.Update, itemTotalDeduct)
                pItemSV.Execute(DataIntent.Update, itemNetSalary)

                Return ServiceResponse(Of Object).Success(payroll)
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
            End Try
        End Function

        Private Function Cal_Net_Salary_One_Period(period As Pay_Period) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"____Tính lương: {period.name}_____", Logger.Information)
            Dim payrollList As List(Of Payroll)
            Dim succ = 0
            Try
                Dim response = Me.Execute(DataIntent.GetPayrollByPeriod, period)
                payrollList = If(response.IsSuccess, response.Data, New List(Of Payroll))
                Logger.Instance.Logging($"Đã tìm thấy {payrollList.Count()} bảng lương")

                If payrollList.Count = 0 Then Return ServiceResponse(Of Object).Success("")

                Dim pItemSV As New Pay_ItemService()

                For Each Payroll In payrollList
                    Logger.Instance.Logging($"Tính lương cho bảng lương: {Payroll.code}", Logger.Warning)
                    response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, Payroll)
                    If Not response.IsSuccess Then
                        Logger.Instance.Logging($"Lỗi lấy thành phần của {Payroll.code}: {response.Message}")
                        Continue For
                    End If

                    Dim items = CType(response.Data, IEnumerable(Of Pay_Item)).ToList()

                    Dim GetOrCreate = Function(sysId As System_Parameter.ID) As Pay_Item
                                          Dim param = System_Parameter.GetParameter(sysId)
                                          Dim item = items.FirstOrDefault(Function(x) x.code = param.code)
                                          If item Is Nothing Then
                                              item = New Pay_Item With {
                                              .payroll_id = Payroll.id, .code = param.code, .name = param.name,
                                              .value = 0, .category = param.category, .unit = param.unit, .priority = param.priority
                                          }
                                              pItemSV.Execute(DataIntent.Insert, item)
                                              items.Add(item)
                                          End If
                                          Return item
                                      End Function

                    Dim itemTotalIncome = GetOrCreate(System_Parameter.ID.SYS_TOTAL_INCOME)
                    Dim itemTotalDeduct = GetOrCreate(System_Parameter.ID.SYS_DEDUCTION)
                    Dim itemNetSalary = GetOrCreate(System_Parameter.ID.SYS_NET_SALARY)

                    itemTotalIncome.value = items.Where(Function(x) Category_PayItem.GetSign(x.category) = 1).Sum(Function(x) x.value)
                    itemTotalDeduct.value = items.Where(Function(x) Category_PayItem.GetSign(x.category) = -1).Sum(Function(x) x.value)
                    itemNetSalary.value = itemTotalIncome.value - itemTotalDeduct.value

                    pItemSV.Execute(DataIntent.Update, itemTotalIncome)
                    pItemSV.Execute(DataIntent.Update, itemTotalDeduct)
                    pItemSV.Execute(DataIntent.Update, itemNetSalary)

                    Logger.Instance.Logging($"Tính lương thành công: {Payroll.code}", Logger.Success)
                    succ += 1
                Next

            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
            End Try
            Logger.Instance.Logging($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương", Logger.Success)
            Return ServiceResponse(Of Object).Success($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương")
        End Function
#End Region

#Region "LOAD HELPERS"
        Private Function LoadPayrolls(period As Pay_Period) As List(Of Payroll)
            Dim res = Me.Execute(DataIntent.GetPayrollByPeriod, period)
            Return If(res.IsSuccess, res.Data, New List(Of Payroll)())
        End Function

        Private Function LoadPolicies() As List(Of Policy)
            Dim sv As New BaseService(Of Policy)
            Dim res = sv.Execute(DataIntent.GetList)
            Return If(res.IsSuccess, res.Data, New List(Of Policy)())
        End Function

        Private Function LoadAttendance(period As Pay_Period) As List(Of Attendance)
            Dim sv As New AttendanceService()
            Dim res = sv.Execute(DataIntent.GetAttendanceByPeriod, period)
            Logger.Instance.Logging($"Load attendance: {If(res.IsSuccess, res.Data?.Count, 0)} bản ghi", Logger.Warning)
            Return If(res.IsSuccess, res.Data, New List(Of Attendance)())
        End Function

        Private Function LoadHoliday(period As Pay_Period) As List(Of Holiday)
            Dim sv As New BaseService(Of Holiday)
            Dim res = sv.Execute(DataIntent.GetList)
            Dim holidays As List(Of Holiday) = If(res.IsSuccess, res.Data, New List(Of Holiday)())
            Return holidays _
            .Where(Function(x) x.of_date.Date >= period.start_date AndAlso x.of_date.Date <= period.end_date) _
            .ToList()
        End Function
#End Region

#Region "LOAD ALL DATA"
        Private Function LoadAllData(period As Pay_Period) As Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))
            Dim holidays = LoadHoliday(period)
            Dim result As New Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))

            result(CInt(Data_Source.ID.ATTENDANCE)) = LoadAttendance(period) _
            .Select(Function(r)
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

            Return result
        End Function
#End Region

#Region "SEED SYSTEM VARS"
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
                Dim policies = LoadPolicies() _
                .Where(Function(p) p.status = 1) _
                .OrderBy(Function(p) p.priority) _
                .ToList()

                If policies.Count = 0 Then Return ServiceResponse(Of Object).Fail("Không có policy nào active.")

                Dim allData = LoadAllData(payroll.Pay_Period)
                Dim itemsOfPayroll As New Dictionary(Of Payroll, List(Of Pay_Item))

                Logger.Instance.Logging($"Tìm thấy {policies.Count} policy.", Logger.Information)
                Logger.Instance.Logging($"Đang tính: {payroll.Position.Contract.employee_id}", Logger.Information)

                Dim maps = SeedSystemVars(payroll, payroll.Pay_Period)

                For Each p In policies
                    Dim rows = GetRows(p, payroll, maps, allData)
                    If rows.Count = 0 Then
                        maps(p.code) = 0.0
                        Continue For
                    End If

                    Dim values As New List(Of Double)()
                    For Each row In rows
                        values.Add(FormulaHelper.EvalFormula(p.rule, row))
                    Next

                    Dim result = Aggregate(values, p.aggregate)
                    maps(p.code) = result

                    If p.gen_item = 1 Then
                        If Not itemsOfPayroll.ContainsKey(payroll) Then
                            itemsOfPayroll(payroll) = New List(Of Pay_Item)
                        End If
                        itemsOfPayroll(payroll).Add(New Pay_Item With {
                        .payroll_id = payroll.id, .code = p.code, .name = p.name,
                        .category = p.category, .priority = p.priority,
                        .unit = p.unit, .value = result, .note = p.note, .status = 0})
                    End If
                Next

                If itemsOfPayroll.ContainsKey(payroll) AndAlso itemsOfPayroll(payroll).Count > 0 Then
                    Dim reponse = BatchInsert(itemsOfPayroll)
                    If Not reponse.IsSuccess Then
                        Logger.Instance.Logging(reponse.Message, Logger.Error)
                        Return ServiceResponse(Of Object).Fail(reponse.Message)
                    End If
                End If

                Logger.Instance.Logging($"Hoàn tất. Đã tạo {itemsOfPayroll.GetValueOrDefault(payroll)?.Count} Pay_Items.", Logger.Success)
                Return ServiceResponse(Of Object).Success("Tổng hợp lương hoàn tất")

            Catch ex As Exception
                Logger.Instance.Logging($"Lỗi engine: {ex.Message}", Logger.Error)
                Return ServiceResponse(Of Object).Fail($"Lỗi: {ex.Message}")
            End Try
        End Function

        Public Function Aggregation_Data_One_Period(period As Pay_Period) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"Bắt đầu tổng hợp dữ liệu cho kỳ: {period.name}", Logger.Information)
            Dim payrollList As List(Of Payroll)
            Dim succ = 0
            Try
                Dim policies = LoadPolicies() _
                .Where(Function(p) p.status = 1) _
                .OrderBy(Function(p) p.priority) _
                .ToList()

                If policies.Count = 0 Then Return ServiceResponse(Of Object).Fail("Không có policy nào active.")

                Dim allData = LoadAllData(period)
                Dim itemsOfPayroll As New Dictionary(Of Payroll, List(Of Pay_Item))

                Dim response = Me.Execute(DataIntent.GetPayrollByPeriod, period)
                payrollList = If(response.IsSuccess, response.Data, New List(Of Payroll))
                Logger.Instance.Logging($"Tìm thấy {payrollList.Count()} bảng lương")

                If payrollList.Count = 0 Then Return ServiceResponse(Of Object).Success("")

                For Each Payroll In payrollList
                    Logger.Instance.Logging($"Đang tính: {Payroll.Position.Contract.employee_id}", Logger.Information)
                    Dim maps = SeedSystemVars(Payroll, Payroll.Pay_Period)

                    For Each p In policies
                        Dim rows = GetRows(p, Payroll, maps, allData)
                        If rows.Count = 0 Then
                            maps(p.code) = 0.0
                            Continue For
                        End If

                        Dim values As New List(Of Double)()
                        For Each row In rows
                            values.Add(FormulaHelper.EvalFormula(p.rule, row))
                        Next

                        Dim result = Aggregate(values, p.aggregate)
                        maps(p.code) = result

                        If p.gen_item = 1 Then
                            If Not itemsOfPayroll.ContainsKey(Payroll) Then
                                itemsOfPayroll(Payroll) = New List(Of Pay_Item)
                            End If
                            itemsOfPayroll(Payroll).Add(New Pay_Item With {
                            .payroll_id = Payroll.id, .code = p.code, .name = p.name,
                            .category = p.category, .priority = p.priority,
                            .unit = p.unit, .value = result, .note = p.note, .status = 0})
                        End If
                    Next

                    succ += 1
                Next

                If itemsOfPayroll.Count > 0 Then
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
        Private Function GetRows(policy As Policy, payroll As Payroll, maps As Dictionary(Of String, Double),
                             allData As Dictionary(Of Integer, List(Of Dictionary(Of String, Double)))) As List(Of Dictionary(Of String, Double))
            If policy.source = 1 Then
                Return New List(Of Dictionary(Of String, Double)) From {maps}
            End If

            If Not allData.ContainsKey(policy.source) Then
                Logger.Instance.Logging($"Không tìm thấy data_source: '{policy.source}' của policy {policy.code}", Logger.Warning)
                Return New List(Of Dictionary(Of String, Double))
            End If

            Dim empId = CDbl(payroll.Position.Contract.employee_id)

            Return allData(policy.source) _
            .Where(Function(r)
                       If Not r.ContainsKey("_employee_id") Then Return True
                       Return r("_employee_id") = empId
                   End Function) _
            .Select(Function(r)
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
                    Logger.Instance.Logging($"Hàm tính toán không hợp lệ: '{Aggregate_Func.GetParameter(func)}", Logger.Warning)
                    Return values.First()
            End Select
        End Function
#End Region

        Private Function BatchInsert(itemsOfPayroll As Dictionary(Of Payroll, List(Of Pay_Item))) As ServiceResponse(Of Object)
            Try
                Dim pItemSV As New Pay_ItemService()

                For Each Payroll In itemsOfPayroll.Keys
                    Dim response = pItemSV.Execute(DataIntent.GetPayItemByPayroll, Payroll)
                    If Not response.IsSuccess Then
                        Return ServiceResponse(Of Object).Fail($"Lỗi lấy thành phần: {response.Message}")
                    End If

                    Dim existingItems = CType(response.Data, IEnumerable(Of Pay_Item)) _
                    .ToDictionary(Function(x) x.code, StringComparer.OrdinalIgnoreCase)

                    For Each item In itemsOfPayroll(Payroll)
                        If existingItems.ContainsKey(item.code) Then
                            Dim existing = existingItems(item.code)
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

                Logger.Instance.Logging($"BatchInsert thành công: {itemsOfPayroll.Count} bảng lương", Logger.Success)
                Return ServiceResponse(Of Object).Success("")

            Catch ex As Exception
                Logger.Instance.Logging($"Lỗi BatchInsert: {ex.Message}", Logger.Error)
                Return ServiceResponse(Of Object).Fail($"Lỗi BatchInsert: {ex.Message}")
            End Try
        End Function

    End Class
#End Region

#Region "Module Hệ thống"
    Private Class AccountService
        Inherits BaseService(Of Account)

        Private _repoAcc As AccountRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AccountRepository(_ctx)
            _repoAcc = New AccountRepository(_ctx)
        End Sub

        Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
            Try
                Select Case intent
                    Case DataIntent.Login
                        Dim accInput As Account = TryCast(data, Account)
                        If accInput Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Thiếu thông tin đăng nhập")
                        End If

                        Dim acc = _repoAcc.GetByUsername(accInput)
                        If acc Is Nothing Then
                            Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Tài khoản không tồn tại")
                        End If

                        If acc.user = accInput.user AndAlso acc.password = accInput.password Then
                            acc.last_active = DateTime.Now
                            Me.Execute(DataIntent.Update, acc)
                            Return ServiceResponse(Of Object).Success(acc)
                        Else
                            Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Sai mật khẩu")
                        End If

                    Case Else
                        Return MyBase.Execute(intent, data)
                End Select
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

#End Region
End Class

