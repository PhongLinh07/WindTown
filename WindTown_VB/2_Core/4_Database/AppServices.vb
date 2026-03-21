Imports Microsoft.EntityFrameworkCore
Public Class AppServices

#Region "Service instances"
    Public ReadOnly DepartmentSV As DepartmentService
    Public ReadOnly JobSV As JobService
    Public ReadOnly LevelSV As LevelService
    Public ReadOnly Salary_MultSV As Salary_MultService
    Public ReadOnly EmployeeSV As EmployeeService
    Public ReadOnly ContractSV As ContractService
    Public ReadOnly PositionSV As PositionService
    Public ReadOnly ProjectSV As ProjectService
    Public ReadOnly AssigmentSV As AssignmentService
    Public ReadOnly AttendanceSV As AttendanceService
    Public ReadOnly HolidaySV As HolidayService
    Public ReadOnly Leave_CatSV As LeaveCatService
    Public ReadOnly LeaveSV As LeaveService
    Public ReadOnly PolicySV As PolicyService
    Public ReadOnly Pay_PeriodSV As Pay_PeriodService
    Public ReadOnly PayrollSV As PayrollService
    Public ReadOnly Pay_ItemSV As Pay_ItemService
    Public ReadOnly AccountSV As AccountService
#End Region

#Region "Singleton"
    Private Shared _instance As AppServices
    Public Shared ReadOnly Property Instance As AppServices
        Get
            If _instance Is Nothing Then _instance = New AppServices()
            Return _instance
        End Get
    End Property

    Private Sub New()
        DepartmentSV = New DepartmentService()
        JobSV = New JobService()
        LevelSV = New LevelService()
        Salary_MultSV = New Salary_MultService()

        EmployeeSV = New EmployeeService()
        ContractSV = New ContractService()
        PositionSV = New PositionService()

        ProjectSV = New ProjectService()
        AssigmentSV = New AssignmentService()
        AttendanceSV = New AttendanceService()
        HolidaySV = New HolidayService()
        Leave_CatSV = New LeaveCatService()
        LeaveSV = New LeaveService()

        PolicySV = New PolicyService()
        Pay_PeriodSV = New Pay_PeriodService()
        PayrollSV = New PayrollService()
        Pay_ItemSV = New Pay_ItemService()
        AccountSV = New AccountService()
    End Sub
#End Region

#Region "INTERFACE"
    Public Interface IBaseService
        Function GetList() As ServiceResponse(Of Object)
        Function Insert(data As Object) As ServiceResponse(Of Object)
        Function Update(data As Object) As ServiceResponse(Of Object)
        Function Delete(items As Object) As ServiceResponse(Of Object)
    End Interface
#End Region

#Region "BASE SERVICE"
    Public MustInherit Class BaseService(Of T As {BaseEntity, New})
        Implements IBaseService

        Protected _repo As GenericRepository(Of T)
        Protected _ctx As AppDbContext

        Public Overridable Function GetList() As ServiceResponse(Of Object) Implements IBaseService.GetList
            Try
                Return ServiceResponse(Of Object).Success(_repo.GetList())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi GetList: " & ex.Message, ex)
            End Try
        End Function

        Public Overridable Function Insert(data As Object) As ServiceResponse(Of Object) Implements IBaseService.Insert
            Try
                Dim result = _repo.Insert(DirectCast(data, T))
                Return ServiceResponse(Of Object).Success(result, "Thêm mới thành công!")
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Không thể thêm: " & ex.Message, ex)
            End Try
        End Function

        Public Overridable Function Update(data As Object) As ServiceResponse(Of Object) Implements IBaseService.Update
            Try
                Dim result = _repo.Update(DirectCast(data, T))
                Return ServiceResponse(Of Object).Success(result, "Cập nhật thành công!")
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Không thể cập nhật: " & ex.Message, ex)
            End Try
        End Function

        Public Overridable Function Delete(items As Object) As ServiceResponse(Of Object) Implements IBaseService.Delete
            Try
                Dim list = DirectCast(items, IEnumerable(Of T))
                For Each item In list
                    _repo.Delete(item.id)
                Next
                Return ServiceResponse(Of Object).Success(True, "Xóa thành công!")
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Không thể xóa: " & ex.Message, ex)
            End Try
        End Function

        Public MustOverride Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
    End Class
#End Region

#Region "MODULE TỔ CHỨC"
    Public Class DepartmentService
        Inherits BaseService(Of Department)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New DepartmentRepository(_ctx)
        End Sub

        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Departments.Any(Function(d) d.code = code AndAlso d.status <> -1 AndAlso d.id <> excludeId)
        End Function
    End Class

    Public Class JobService
        Inherits BaseService(Of Job)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New JobRepository(_ctx)
        End Sub

        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Jobs.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class

    Public Class LevelService
        Inherits BaseService(Of Level)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New LevelRepository(_ctx)
        End Sub

        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Levels.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class

    Public Class Salary_MultService
        Inherits BaseService(Of Salary_Mult)

        Private ReadOnly _repoMult As SalaryMultRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New SalaryMultRepository(_ctx)
            _repoMult = New SalaryMultRepository(_ctx)
        End Sub

        Public Function GetByJob(job As Job) As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoMult.GetByJob(job))
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("GetByJob thất bại " & ex.Message)
            End Try
        End Function

        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Salary_Mults.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class
#End Region

#Region "MODULE NHÂN SỰ"
    Public Class EmployeeService
        Inherits BaseService(Of Employee)

        Private ReadOnly _repoEmp As EmployeeRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New EmployeeRepository(_ctx)
            _repoEmp = New EmployeeRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Employees.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function

        Public Function GetWithoutAccount() As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoEmp.GetWithoutAccount())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi 195: " & ex.Message, ex)
            End Try
        End Function

        Public Function GetWithoutContract() As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoEmp.GetWithoutContract())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi 205: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Public Class ContractService
        Inherits BaseService(Of Contract)

        Private ReadOnly _repoCustom As ContractRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New ContractRepository(_ctx)
            _repoCustom = New ContractRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Contracts.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function IsConflictStatusActive(contraciID As Integer, excludeId As Integer) As Boolean
            Return _ctx.Contracts.Any(Function(x) x.employee_id = contraciID AndAlso x.status = 1 AndAlso x.id <> excludeId)
        End Function
        Public Function GetWithoutPosition() As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoCustom.GetWithoutPosition())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi 217: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Public Class PositionService
        Inherits BaseService(Of Position)

        Private ReadOnly _repoPos As PositionRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PositionRepository(_ctx)
            _repoPos = New PositionRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Positions.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function IsConflictStatusActive(contraciID As Integer, excludeId As Integer) As Boolean
            Return _ctx.Positions.Any(Function(x) x.contract_id = contraciID AndAlso x.status = 1 AndAlso x.id <> excludeId)
        End Function
        Public Function GetWithoutAssignment() As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoPos.GetWithoutAssignment())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi GetList: " & ex.Message, ex)
            End Try
        End Function
    End Class
#End Region

#Region "MODULE VẬN HÀNH"
    Public Class ProjectService
        Inherits BaseService(Of Project)

        Private ReadOnly _repoProj As ProjectRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New ProjectRepository(_ctx)
            _repoProj = New ProjectRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Projects.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function GetActive() As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoProj.GetActive())
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("GetActive thất bại " & ex.Message)
            End Try
        End Function
    End Class

    Public Class AssignmentService
        Inherits BaseService(Of Assignment)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AssignmentRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Assignments.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class

    Public Class AttendanceService
        Inherits BaseService(Of Attendance)

        Private ReadOnly _repoAtt As AttendanceRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AttendanceRepository(_ctx)
            _repoAtt = New AttendanceRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Attendances.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function GetByPeriod(period As Pay_Period) As ServiceResponse(Of Object)
            Try
                If period.start_date > period.end_date Then
                    Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                End If
                Return ServiceResponse(Of Object).Success(_repoAtt.GetByPeriod(period))
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class

    Public Class HolidayService
        Inherits BaseService(Of Holiday)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New HolidayRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Holidays.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class

    Public Class LeaveCatService
        Inherits BaseService(Of Leave_Cat)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New LeaveCatRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Leave_Cats.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class

    Public Class LeaveService
        Inherits BaseService(Of Leave)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New LeaveRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Leaves.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class
#End Region

#Region "MODULE QUY TẮC"
    Public Class PolicyService
        Inherits BaseService(Of Policy)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PolicyRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Policies.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
    End Class
#End Region

#Region "MODULE TÀI CHÍNH"
    Public Class Pay_PeriodService
        Inherits BaseService(Of Pay_Period)

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayPeriodRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Pay_Periods.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function CalcStdHours(period As Pay_Period) As ServiceResponse(Of Decimal)
            Try
                Dim holidayDates = AppServices.Instance.HolidaySV.GetList()
                Dim data = CType(holidayDates.Data, IEnumerable(Of Holiday)).ToList()
                Dim dates = data.Where(Function(x) x.of_date.Date >= period.start_date.Date AndAlso
                                                    x.of_date.Date <= period.end_date.Date) _
                                .Select(Function(x) x.of_date.Date).ToList()
                Dim stdDays = StandardHoursCalculator.StdWorkingDays(period.start_date, period.end_date, dates)
                Return ServiceResponse(Of Decimal).Success(stdDays * 8)
            Catch ex As Exception
                Return ServiceResponse(Of Decimal).Fail(0)
            End Try
        End Function
    End Class

    Public Class Pay_ItemService
        Inherits BaseService(Of Pay_Item)

        Private ReadOnly _repoPayItem As PayItemRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayItemRepository(_ctx)
            _repoPayItem = New PayItemRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Pay_Items.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function
        Public Function GetByPayroll(payroll As Payroll) As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoPayItem.GetByPayroll(payroll))
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi lấy Item " & ex.Message)
            End Try
        End Function
    End Class

    Public Class PayrollService
        Inherits BaseService(Of Payroll)

        Private ReadOnly _repoPayroll As PayrollRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New PayrollRepository(_ctx)
            _repoPayroll = New PayrollRepository(_ctx)
        End Sub

        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return _ctx.Payrolls.Any(Function(x) x.code = code AndAlso x.status <> -1 AndAlso x.id <> excludeId)
        End Function

        ' ✅ Override Insert — tạo pay_item mặc định sau khi insert
        Public Overrides Function Insert(data As Object) As ServiceResponse(Of Object)
            Dim payroll = TryCast(data, Payroll)
            If payroll Is Nothing Then Return ServiceResponse(Of Object).Fail("Dữ liệu bảng lương không hợp lệ.")

            Dim insertResult = MyBase.Insert(payroll)
            If Not insertResult.IsSuccess Then Return insertResult
            If payroll.id = 0 Then Return ServiceResponse(Of Object).Fail("Không lấy được id sau khi Insert Payroll.")

            Return Gen_Default_Pay_Item(payroll)
        End Function

        Public Function GetByPeriod(period As Pay_Period) As ServiceResponse(Of Object)
            Try
                Return ServiceResponse(Of Object).Success(_repoPayroll.GetByPeriod(period))
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi lấy Bảng lương " & ex.Message)
            End Try
        End Function

        Public Function Init_Payrolls(ByVal period As Pay_Period) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"____Khởi tạo bảng lương của kỳ lương: {period.name}_____", Logger.Information)
            Try
                If period.start_date > period.end_date Then
                    Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                End If

                Dim resContract = AppServices.Instance.ContractSV.GetList()
                If Not resContract.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy hợp đồng: {resContract.Message}")

                Dim contractList = CType(resContract.Data, IEnumerable(Of Contract)) _
                    .Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso x.end_date.Date >= period.start_date.Date) _
                    .ToList()

                Dim resPos = AppServices.Instance.PositionSV.GetList()
                If Not resPos.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy chức vụ: {resPos.Message}")

                Dim positionLookup = CType(resPos.Data, IEnumerable(Of Position)) _
                    .Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso x.end_date.Date >= period.start_date.Date) _
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
                            .period_id = period.id,
                            .position_id = pos.id,
                            .status = 1
                        }
                        If Me.Insert(pRow).IsSuccess Then countSucc += 1
                    Next
                Next

                Dim msg = $"Khởi tạo thành công: {countSucc}/{contractList.Count}"
                Logger.Instance.Logging(msg, Logger.Success)
                Return ServiceResponse(Of Object).Success(msg)
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
            End Try
        End Function

        Public Function CalcNetSalary(payroll As Payroll) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"____Tính lương: {payroll.code}_____", Logger.Information)
            Try
                Dim pItemSV = AppServices.Instance.Pay_ItemSV
                Dim response = pItemSV.GetByPayroll(payroll)
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
                                          pItemSV.Insert(item)
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

                pItemSV.Update(itemTotalIncome)
                pItemSV.Update(itemTotalDeduct)
                pItemSV.Update(itemNetSalary)

                Return ServiceResponse(Of Object).Success(payroll)
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
            End Try
        End Function

        Public Function CalcNetSalaryByPeriod(period As Pay_Period) As ServiceResponse(Of Object)
            Logger.Instance.Logging($"____Tính lương: {period.name}_____", Logger.Information)
            Dim payrollList As List(Of Payroll)
            Dim succ = 0
            Try
                Dim response = Me.GetByPeriod(period)
                payrollList = If(response.IsSuccess, CType(response.Data, IEnumerable(Of Payroll)).ToList(), New List(Of Payroll))
                Logger.Instance.Logging($"Đã tìm thấy {payrollList.Count()} bảng lương")

                If payrollList.Count = 0 Then Return ServiceResponse(Of Object).Success("")

                For Each Payroll In payrollList
                    Logger.Instance.Logging($"Tính lương cho bảng lương: {Payroll.code}", Logger.Warning)
                    Dim res = CalcNetSalary(Payroll)
                    If Not res.IsSuccess Then
                        Logger.Instance.Logging($"Lỗi lấy thành phần của {Payroll.code}: {res.Message}")
                        Continue For
                    End If
                    Logger.Instance.Logging($"Tính lương thành công: {Payroll.code}", Logger.Success)
                    succ += 1
                Next

            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
            End Try
            Logger.Instance.Logging($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương", Logger.Success)
            Return ServiceResponse(Of Object).Success($"Tính lương thành công cho {succ}/{payrollList.Count()} bảng lương")
        End Function

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

                Dim response = Me.GetByPeriod(period)
                payrollList = If(response.IsSuccess, CType(response.Data, IEnumerable(Of Payroll)).ToList(), New List(Of Payroll))
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

#Region "LOAD HELPERS"
        Private Function LoadPolicies() As List(Of Policy)
            Dim res = AppServices.Instance.PolicySV.GetList()
            Return If(res.IsSuccess, CType(res.Data, IEnumerable(Of Policy)).ToList(), New List(Of Policy)())
        End Function

        Private Function LoadAttendance(period As Pay_Period) As List(Of Attendance)
            Dim res = AppServices.Instance.AttendanceSV.GetByPeriod(period)
            Logger.Instance.Logging($"Load attendance: {If(res.IsSuccess, CType(res.Data, IEnumerable(Of Attendance)).Count(), 0)} bản ghi", Logger.Warning)
            Return If(res.IsSuccess, CType(res.Data, IEnumerable(Of Attendance)).ToList(), New List(Of Attendance)())
        End Function

        Private Function LoadHoliday(period As Pay_Period) As List(Of Holiday)
            Dim res = AppServices.Instance.HolidaySV.GetList()
            Dim holidays As List(Of Holiday) = If(res.IsSuccess, CType(res.Data, IEnumerable(Of Holiday)).ToList(), New List(Of Holiday)())
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

#Region "Payroll helpers"
        Private Function Gen_Default_Pay_Item(payroll As Payroll) As ServiceResponse(Of Object)
            Try
                Dim pItemSV = AppServices.Instance.Pay_ItemSV
                Dim total_income = System_Parameter.GetParameter(System_Parameter.ID.SYS_TOTAL_INCOME)
                Dim net_deduction = System_Parameter.GetParameter(System_Parameter.ID.SYS_DEDUCTION)
                Dim net_salary = System_Parameter.GetParameter(System_Parameter.ID.SYS_NET_SALARY)

                Dim itemDefault As New List(Of Pay_Item) From {
                    New Pay_Item With {.payroll_id = payroll.id, .code = total_income.code, .name = total_income.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = total_income.priority},
                    New Pay_Item With {.payroll_id = payroll.id, .code = net_deduction.code, .name = net_deduction.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_deduction.priority},
                    New Pay_Item With {.payroll_id = payroll.id, .code = net_salary.code, .name = net_salary.name, .value = 0, .category = total_income.category, .unit = total_income.unit, .priority = net_salary.priority}
                }

                For Each item In itemDefault
                    pItemSV.Insert(item)
                Next
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}", ex)
            End Try
            Return ServiceResponse(Of Object).Success("")
        End Function

        Private Function BatchInsert(itemsOfPayroll As Dictionary(Of Payroll, List(Of Pay_Item))) As ServiceResponse(Of Object)
            Try
                Dim pItemSV = AppServices.Instance.Pay_ItemSV

                For Each Payroll In itemsOfPayroll.Keys
                    Dim response = pItemSV.GetByPayroll(Payroll)
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
                            pItemSV.Update(item)
                        Else
                            pItemSV.Insert(item)
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

#End Region


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

    End Class

#End Region

#Region "MODULE HỆ THỐNG"
    Public Class AccountService
        Inherits BaseService(Of Account)

        Private ReadOnly _repoAcc As AccountRepository

        Public Sub New()
            _ctx = New AppDbContext()
            _repo = New AccountRepository(_ctx)
            _repoAcc = New AccountRepository(_ctx)
        End Sub
        Public Overrides Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
            Return False
        End Function
        Public Function Login(input As Account) As ServiceResponse(Of Object)
            Try
                If input Is Nothing Then Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Thiếu thông tin đăng nhập")

                Dim acc = _repoAcc.GetByUsername(input)
                If acc Is Nothing Then Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Tài khoản không tồn tại")

                If acc.user = input.user AndAlso acc.password = input.password Then
                    acc.last_active = DateTime.Now
                    Me.Update(acc)
                    Return ServiceResponse(Of Object).Success(acc)
                Else
                    Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Sai mật khẩu")
                End If
            Catch ex As Exception
                Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
            End Try
        End Function
    End Class
#End Region

End Class