Imports Microsoft.EntityFrameworkCore

' sử dụng file này  để tạo database nếu ko tìm được "
Public Class AppDbContext
    Inherits DbContext

#Region "DbSet — mỗi bảng 1 dòng"
    ' Module Tổ chức
    Public Property Departments As DbSet(Of Department)
    Public Property Jobs As DbSet(Of Job)
    Public Property Levels As DbSet(Of Level)
    Public Property Salary_Mults As DbSet(Of Salary_Mult)

    ' Module Nhân sự
    Public Property Employees As DbSet(Of Employee)
    Public Property Contracts As DbSet(Of Contract)
    Public Property Positions As DbSet(Of Position)

    ' Module Vận hành
    Public Property Projects As DbSet(Of Project)
    Public Property Assignments As DbSet(Of Assignment)
    Public Property Attendances As DbSet(Of Attendance)
    Public Property Holidays As DbSet(Of Holiday)
    Public Property Leave_Cats As DbSet(Of Leave_Cat)
    Public Property Leaves As DbSet(Of Leave)

    ' Module Quy tắc
    Public Property Policies As DbSet(Of Policy)

    ' Module Tài chính
    Public Property Pay_Periods As DbSet(Of Pay_Period)
    Public Property Payrolls As DbSet(Of Payroll)
    Public Property Pay_Items As DbSet(Of Pay_Item)

    ' Module Hệ thống
    Public Property Accounts As DbSet(Of Account)
#End Region

    Protected Overrides Sub OnConfiguring(builder As DbContextOptionsBuilder)
        ' ✅ Luôn đọc từ _runtimeConfig — đồng bộ với DatabaseBootstrapService
        builder.UseSqlServer(DatabaseConfig.Database.ConnectionString)
    End Sub

    Protected Overrides Sub OnModelCreating(model As ModelBuilder)

#Region "Tên bảng"
        ' Module Tổ chức
        model.Entity(Of Department)().ToTable("department")
        model.Entity(Of Job)().ToTable("job")
        model.Entity(Of Level)().ToTable("level")
        model.Entity(Of Salary_Mult)().ToTable("salary_mult")

        ' Module Nhân sự
        model.Entity(Of Employee)().ToTable("employee")
        model.Entity(Of Contract)().ToTable("contract")
        model.Entity(Of Position)().ToTable("position")

        ' Module Vận hành
        model.Entity(Of Project)().ToTable("project")
        model.Entity(Of Assignment)().ToTable("assignment")
        model.Entity(Of Attendance)().ToTable("attendance")
        model.Entity(Of Holiday)().ToTable("holiday")
        model.Entity(Of Leave_Cat)().ToTable("leave_cat")
        model.Entity(Of Leave)().ToTable("leave")

        ' Module Quy tắc
        model.Entity(Of Policy)().ToTable("policy")

        ' Module Tài chính
        model.Entity(Of Pay_Period)().ToTable("pay_period")
        model.Entity(Of Payroll)().ToTable("payroll")
        model.Entity(Of Pay_Item)().ToTable("pay_item")

        ' Module Hệ thống
        model.Entity(Of Account)().ToTable("account")
#End Region

#Region "Quan hệ (Foreign Key)"
        ' Job -> Department
        model.Entity(Of Job)() _
            .HasOne(Function(j) j.Department) _
            .WithMany(Function(d) d.Jobs) _
            .HasForeignKey(Function(j) j.department_id)

        ' Salary_Mult -> Job
        model.Entity(Of Salary_Mult)() _
            .HasOne(Function(sm) sm.Job) _
            .WithMany() _
            .HasForeignKey(Function(sm) sm.job_id)

        ' Salary_Mult -> Level
        model.Entity(Of Salary_Mult)() _
            .HasOne(Function(sm) sm.Level) _
            .WithMany() _
            .HasForeignKey(Function(sm) sm.level_id)

        ' Contract -> Employee
        model.Entity(Of Contract)() _
            .HasOne(Function(c) c.Employee) _
            .WithMany(Function(e) e.Contracts) _
            .HasForeignKey(Function(c) c.employee_id)

        ' Position -> Contract
        model.Entity(Of Position)() _
            .HasOne(Function(p) p.Contract) _
            .WithMany() _
            .HasForeignKey(Function(p) p.contract_id)

        ' Position -> Salary_Mult
        model.Entity(Of Position)() _
            .HasOne(Function(p) p.Salary_Mult) _
            .WithMany() _
            .HasForeignKey(Function(p) p.salary_mult_id)

        ' Assignment -> Position
        model.Entity(Of Assignment)() _
            .HasOne(Function(a) a.Position) _
            .WithMany() _
            .HasForeignKey(Function(a) a.position_id)

        ' Assignment -> Project
        model.Entity(Of Assignment)() _
            .HasOne(Function(a) a.Project) _
            .WithMany() _
            .HasForeignKey(Function(a) a.project_id)

        ' Attendance -> Employee
        model.Entity(Of Attendance)() _
            .HasOne(Function(a) a.Employee) _
            .WithMany() _
            .HasForeignKey(Function(a) a.employee_id)

        ' Leave -> Employee (người nghỉ)
        model.Entity(Of Leave)() _
            .HasOne(Function(l) l.Employee) _
            .WithMany() _
            .HasForeignKey(Function(l) l.employee_id) _
            .OnDelete(DeleteBehavior.Restrict)  ' tránh xung đột 2 FK cùng bảng

        ' Leave -> Employee (người duyệt)
        model.Entity(Of Leave)() _
            .HasOne(Function(l) l.Approved) _
            .WithMany() _
            .HasForeignKey(Function(l) l.approved_id) _
            .IsRequired(False) _ ' Xác định đây là mối quan hệ không bắt buộc '
            .OnDelete(DeleteBehavior.Restrict)

        ' Leave -> Leave_Cat
        model.Entity(Of Leave)() _
            .HasOne(Function(l) l.Leave_Cat) _
            .WithMany() _
            .HasForeignKey(Function(l) l.leave_cat_id)

        ' Payroll -> Pay_Period
        model.Entity(Of Payroll)() _
            .HasOne(Function(p) p.Pay_Period) _
            .WithMany() _
            .HasForeignKey(Function(p) p.period_id)

        ' Payroll -> Position
        model.Entity(Of Payroll)() _
            .HasOne(Function(p) p.Position) _
            .WithMany() _
            .HasForeignKey(Function(p) p.position_id)

        ' Pay_Item -> Payroll
        model.Entity(Of Pay_Item)() _
            .HasOne(Function(pi) pi.Payroll) _
            .WithMany(Function(p) p.Pay_Items) _
            .HasForeignKey(Function(pi) pi.payroll_id)

        ' Account -> Employee
        model.Entity(Of Account)() _
            .HasOne(Function(a) a.Employee) _
            .WithMany() _
            .HasForeignKey(Function(a) a.employee_id)
#End Region

    End Sub

End Class