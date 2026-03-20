Imports Microsoft.EntityFrameworkCore


#Region "Module Tổ chức"

Public Class DepartmentRepository
    Inherits GenericRepository(Of Department)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    ' ✅ Override BaseQuery — load kèm Jobs
    Protected Overrides Function BaseQuery() As IQueryable(Of Department)
        Return _ctx.Departments _
                   .Include(Function(d) d.Jobs) _
                   .AsNoTracking()
    End Function
End Class

Public Class JobRepository
    Inherits GenericRepository(Of Job)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BaseQuery() As IQueryable(Of Job)
        Return _ctx.Jobs.Include(Function(j) j.Department)
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
    Protected Overrides Function BaseQuery() As IQueryable(Of Salary_Mult)
        Return _ctx.Salary_Mults _
            .Include(Function(sm) sm.Job) _
                .ThenInclude(Function(j) j.Department) _
            .Include(Function(sm) sm.Level)
    End Function

    ' ✅ Giữ lại — lọc theo Job cụ thể
    Public Function GetByJob(job As Job) As List(Of Salary_Mult)
        Dim f = SqlFilter(Of Salary_Mult).Default() _
            .Add(Function(sm) sm.status <> -1) _
            .Add(Function(sm) sm.job_id = job.id)
        Return Search(f)
    End Function
End Class

#End Region

#Region "Module Nhân sự"

Public Class EmployeeRepository
    Inherits GenericRepository(Of Employee)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub

    ' ✅ Giữ lại — NOT EXISTS: nhân viên chưa có tài khoản
    Public Function GetWithoutAccount() As List(Of Employee)
        Return _ctx.Employees _
            .Where(Function(e) e.status <> -1 AndAlso e.status <> 0) _
            .Where(Function(e) Not _ctx.Accounts.Any(
                Function(a) a.employee_id = e.id AndAlso a.status <> -1)) _
            .ToList()
    End Function

    ' ✅ Giữ lại — NOT EXISTS: nhân viên chưa có hợp đồng active
    Public Function GetWithoutContract() As List(Of Employee)
        Return _ctx.Employees _
            .Where(Function(e) e.status <> -1) _
            .Where(Function(e) Not _ctx.Contracts.Any(
                Function(c) c.employee_id = e.id AndAlso c.status = 1)) _
            .ToList()
    End Function
End Class

Public Class ContractRepository
    Inherits GenericRepository(Of Contract)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BaseQuery() As IQueryable(Of Contract)
        Return _ctx.Contracts.Include(Function(c) c.Employee)
    End Function

    ' ✅ Giữ lại — NOT EXISTS: hợp đồng chưa có position active
    Public Function GetWithoutPosition() As List(Of Contract)
        Return _ctx.Contracts _
            .Include(Function(c) c.Employee) _
            .Where(Function(c) c.status <> -1 AndAlso c.status <> 0) _
            .Where(Function(c) Not _ctx.Positions.Any(
                Function(p) p.contract_id = c.id AndAlso p.status <> -1)) _
            .ToList()
    End Function
End Class

Public Class PositionRepository
    Inherits GenericRepository(Of Position)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BaseQuery() As IQueryable(Of Position)
        Return _ctx.Positions _
            .Include(Function(p) p.Contract) _
                .ThenInclude(Function(c) c.Employee) _
            .Include(Function(p) p.Salary_Mult) _
                .ThenInclude(Function(sm) sm.Job) _
                    .ThenInclude(Function(j) j.Department) _
            .Include(Function(p) p.Salary_Mult) _
                .ThenInclude(Function(sm) sm.Level)
    End Function

    ' ✅ Giữ lại — NOT EXISTS: position chưa được phân công
    Public Function GetWithoutAssignment() As List(Of Position)
        Return BaseQuery() _
            .Where(Function(p) p.status <> -1) _
            .Where(Function(p) Not _ctx.Assignments.Any(
                Function(a) a.position_id = p.id AndAlso a.status = 1)) _
            .ToList()
    End Function
End Class

#End Region

#Region "Module Vận hành"

Public Class ProjectRepository
    Inherits GenericRepository(Of Project)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub

    ' ✅ Giữ lại — lọc status IN (1, 2): đang lập kế hoạch hoặc đang thực hiện
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
    Protected Overrides Function BaseQuery() As IQueryable(Of Assignment)
        Return _ctx.Assignments _
            .Include(Function(a) a.Project) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Contract) _
                    .ThenInclude(Function(c) c.Employee) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Job) _
            .Include(Function(a) a.Position) _
                .ThenInclude(Function(p) p.Salary_Mult) _
                    .ThenInclude(Function(sm) sm.Level)
    End Function
End Class

Public Class AttendanceRepository
    Inherits GenericRepository(Of Attendance)
    Sub New(ctx As AppDbContext)
        MyBase.New(ctx)
    End Sub
    Protected Overrides Function BaseQuery() As IQueryable(Of Attendance)
        Return _ctx.Attendances.Include(Function(a) a.Employee)
    End Function

    ' ✅ Giữ lại — lọc chấm công theo kỳ lương
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
    Protected Overrides Function BaseQuery() As IQueryable(Of Leave)
        Return _ctx.Leaves _
            .Include(Function(l) l.Employee) _
            .Include(Function(l) l.Approved) _
            .Include(Function(l) l.Leave_Cat)
    End Function
End Class

#End Region

#Region "Module Tài chính"

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
    Protected Overrides Function BaseQuery() As IQueryable(Of Payroll)
        Return _ctx.Payrolls _
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
                    .ThenInclude(Function(sm) sm.Level)
    End Function

    ' ✅ Giữ lại — lọc bảng lương theo kỳ
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
    Protected Overrides Function BaseQuery() As IQueryable(Of Pay_Item)
        Return _ctx.Pay_Items.Include(Function(pi) pi.Payroll)
    End Function

    ' ✅ Giữ lại — lọc pay item theo payroll cụ thể
    Public Function GetByPayroll(payroll As Payroll) As List(Of Pay_Item)
        Dim f = SqlFilter(Of Pay_Item).Default() _
            .Add(Function(pi) pi.status <> -1) _
            .Add(Function(pi) pi.payroll_id = payroll.id)
        Return Search(f)
    End Function
End Class

#End Region

#Region "Module Quy tắc & Hệ thống"

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
    Protected Overrides Function BaseQuery() As IQueryable(Of Account)
        Return _ctx.Accounts.Include(Function(a) a.Employee)
    End Function

    ' ✅ Giữ lại — login: tìm theo username
    Public Function GetByUsername(data As Account) As Account
        Dim f = SqlFilter(Of Account).Default() _
            .Add(Function(a) a.status <> -1) _
            .Add(Function(a) a.user = data.user)
        Return Search(f).FirstOrDefault()
    End Function
End Class

#End Region