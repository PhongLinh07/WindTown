Imports Microsoft.EntityFrameworkCore


#Region "Module Tổ chức"

Public Class DepartmentRepository
    Inherits GenericRepository(Of Department)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Department)
        Return ctx.Departments.Include(Function(d) d.Jobs).AsNoTracking()
    End Function
End Class

Public Class JobRepository
    Inherits GenericRepository(Of Job)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Job)
        Return ctx.Jobs.Include(Function(j) j.Department).AsNoTracking()
    End Function
End Class

Public Class LevelRepository
    Inherits GenericRepository(Of Level)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
End Class

Public Class SalaryMultRepository
    Inherits GenericRepository(Of Salary_Mult)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Salary_Mult)
        Return ctx.Salary_Mults _
            .Include(Function(sm) sm.Job) _
            .Include(Function(sm) sm.Level) _
            .AsNoTracking()
    End Function

    ' dùng _ctx vì Search dùng BaseQuery/_ctx
    Public Function GetByJob(job As Job) As List(Of Salary_Mult)
        Using ctx As New AppDbContext()
            Return ctx.Salary_Mults _
            .Include(Function(sm) sm.Job) _
            .Include(Function(sm) sm.Level) _
            .Where(Function(sm) sm.status <> -1 AndAlso sm.job_id = job.id) _
            .AsNoTracking() _
            .ToList()
        End Using
    End Function
End Class

#End Region

#Region "Module Nhan su"

Public Class EmployeeRepository
    Inherits GenericRepository(Of Employee)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub

    Public Function GetWithoutAccount() As List(Of Employee)
        Return _ctx.Employees _
            .Where(Function(e) e.status <> -1 AndAlso e.status <> 0) _
            .Where(Function(e) Not _ctx.Accounts.Any(
                Function(a) a.employee_id = e.id AndAlso a.status <> -1)) _
            .ToList()
    End Function

    Public Function GetWithoutContract() As List(Of Employee)
        Return _ctx.Employees _
            .Where(Function(e) e.status <> -1) _
            .Where(Function(e) Not _ctx.Contracts.Any(Function(c) c.employee_id = e.id AndAlso c.status = 1)).ToList()
    End Function
End Class

Public Class ContractRepository
    Inherits GenericRepository(Of Contract)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Contract)
        Return ctx.Contracts.Include(Function(c) c.Employee).AsNoTracking()
    End Function

    Public Function GetWithoutPosition() As List(Of Contract)
        Return _ctx.Contracts _
            .Include(Function(c) c.Employee) _
            .Where(Function(c) c.status <> -1 AndAlso c.status <> 0) _
            .Where(Function(c) Not _ctx.Positions.Any(Function(p) p.contract_id = c.id AndAlso p.status <> -1 AndAlso p.status = 1)).ToList()
    End Function
End Class

Public Class PositionRepository
    Inherits GenericRepository(Of Position)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Position)
        Return ctx.Positions _
            .Include(Function(p) p.Contract) _
                .ThenInclude(Function(c) c.Employee) _
            .Include(Function(p) p.Salary_Mult) _
                .ThenInclude(Function(sm) sm.Job) _
                    .ThenInclude(Function(j) j.Department) _
            .Include(Function(p) p.Salary_Mult) _
                .ThenInclude(Function(sm) sm.Level) _
            .AsNoTracking()
    End Function

    Public Function GetWithoutAssignment() As List(Of Position)
        Return BuildQuery(_ctx) _
        .Where(Function(p) p.status <> -1) _
        .Where(Function(p) Not _ctx.Assignments.Any(
            Function(a) a.position_id = p.id AndAlso a.status = 1)) _
        .ToList()

    End Function
End Class

#End Region

#Region "Module Van hanh"

Public Class ProjectRepository
    Inherits GenericRepository(Of Project)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub

    Public Function GetActive() As List(Of Project)
        Dim f = SqlFilter(Of Project).Default() _
            .Add(Function(p) p.status = 1 OrElse p.status = 2)
        Return Search(f)
    End Function
End Class

Public Class AssignmentRepository
    Inherits GenericRepository(Of Assignment)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Assignment)
        Return ctx.Assignments _
            .Include(Function(a) a.Project) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Contract) _
                    .ThenInclude(Function(c) c.Employee) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Job) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Level) _
            .AsNoTracking()
    End Function
End Class

Public Class AttendanceRepository
    Inherits GenericRepository(Of Attendance)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Attendance)
        Return ctx.Attendances.Include(Function(a) a.Employee).AsNoTracking()
    End Function

    Public Function GetByPeriod(period As Pay_Period) As List(Of Attendance)
        Dim f = SqlFilter(Of Attendance).Default() _
            .Add(Function(a) a.status <> -1) _
            .Add(Function(a) a.of_date >= period.start_date.Date) _
            .Add(Function(a) a.of_date <= period.end_date.Date)
        Return Search(f)
    End Function
End Class

Public Class HolidayRepository
    Inherits GenericRepository(Of Holiday)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
End Class

Public Class LeaveCatRepository
    Inherits GenericRepository(Of Leave_Cat)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
End Class

Public Class LeaveRepository
    Inherits GenericRepository(Of Leave)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Leave)
        Return ctx.Leaves _
            .Include(Function(l) l.Employee) _
            .Include(Function(l) l.Approved) _
            .Include(Function(l) l.Leave_Cat) _
            .AsNoTracking()
    End Function
End Class

#End Region

#Region "Module Tai chinh"

Public Class PayPeriodRepository
    Inherits GenericRepository(Of Pay_Period)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
End Class

Public Class PayrollRepository
    Inherits GenericRepository(Of Payroll)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Payroll)
        Return ctx.Payrolls _
            .Include(Function(p) p.Pay_Period) _
            .Include(Function(p) p.Pay_Items) _
            .Include(Function(p) p.Position) _
                .ThenInclude(Function(pos) pos.Contract) _
                    .ThenInclude(Function(c) c.Employee) _
            .Include(Function(p) p.Position) _
                .ThenInclude(Function(pos) pos.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Job) _
            .Include(Function(p) p.Position) _
                .ThenInclude(Function(pos) pos.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Level) _
            .AsNoTracking()
    End Function

    Public Function GetByPeriod(period As Pay_Period) As List(Of Payroll)
        Dim f = SqlFilter(Of Payroll).Default() _
            .Add(Function(p) p.status <> -1) _
            .Add(Function(p) p.period_id = period.id)
        Return Search(f)
    End Function
End Class

Public Class PayItemRepository
    Inherits GenericRepository(Of Pay_Item)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Pay_Item)
        Return ctx.Pay_Items.Include(Function(pi) pi.Payroll).AsNoTracking()
    End Function

    Public Function GetByPayroll(payroll As Payroll) As List(Of Pay_Item)
        Dim f = SqlFilter(Of Pay_Item).Default() _
            .Add(Function(pi) pi.status <> -1) _
            .Add(Function(pi) pi.payroll_id = payroll.id)
        Return Search(f)
    End Function
End Class

#End Region

#Region "Module Quy tac & He thong"

Public Class PolicyRepository
    Inherits GenericRepository(Of Policy)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
End Class

Public Class AccountRepository
    Inherits GenericRepository(Of Account)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BuildQuery(ctx As AppDbContext) As IQueryable(Of Account)
        Return ctx.Accounts.Include(Function(a) a.Employee).AsNoTracking()
    End Function

    Public Function GetByUsername(data As Account) As Account
        Dim f = SqlFilter(Of Account).Default() _
            .Add(Function(a) a.status <> -1) _
            .Add(Function(a) a.user = data.user)
        Return Search(f).FirstOrDefault()
    End Function
End Class

#End Region