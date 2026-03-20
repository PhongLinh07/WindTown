Imports Dapper
Imports System.Data
Imports WindTown_VB.DatabaseConfig

Public Class PayrollRepository
    Inherits GenericRepository(Of Payroll)

    Public Overrides Function GetAll() As IEnumerable(Of Payroll)
        Using db As IDbConnection = Database.GetConnection()
            ' 1. Cập nhật SQL: Join qua salary_mult để lấy Job và Level
            Dim sql As String = "
            SELECT
                pay.*,
                pos.*,
                ctr.*,
                emp.*,
                sm.*,
                job.*,
                lvl.*,
                pp.*
            FROM payroll pay
            LEFT JOIN position    pos ON pay.position_id = pos.id
            LEFT JOIN contract    ctr ON pos.contract_id = ctr.id
            LEFT JOIN employee    emp ON ctr.employee_id = emp.id
            LEFT JOIN salary_mult sm  ON pos.salary_mult_id = sm.id
            LEFT JOIN job         job ON sm.job_id = job.id
            LEFT JOIN level       lvl ON sm.level_id = lvl.id
            LEFT JOIN pay_period  pp  ON pay.period_id = pp.id
            WHERE pay.status <> @Status"

            ' 2. Danh sách 8 Class tương ứng (9 tham số Generic là quá giới hạn nên dùng mảng Type)
            Dim types() As Type = {
                GetType(Payroll), GetType(Position), GetType(Contract),
                GetType(Employee), GetType(Salary_Mult), GetType(Job),
                GetType(Level), GetType(Pay_Period)
            }

            Return db.Query(Of Payroll)(
                sql:=sql,
                types:=types,
                map:=Function(obj As Object())
                         Return MapPayrollLogic(obj)
                     End Function,
                param:=New With {.Status = -1},
                splitOn:="id,id,id,id,id,id,id" ' 7 dấu phẩy cho 8 bảng
            )
        End Using
    End Function

    Public Function GetPayrollByPeriod(period As Pay_Period) As IEnumerable(Of Payroll)
        Using db As IDbConnection = Database.GetConnection()
            Dim sql As String = "
            SELECT
                pay.*,
                pos.*,
                ctr.*,
                emp.*,
                sm.*,
                job.*,
                lvl.*,
                pp.*
            FROM payroll pay
            LEFT JOIN position    pos ON pay.position_id = pos.id
            LEFT JOIN contract    ctr ON pos.contract_id = ctr.id
            LEFT JOIN employee    emp ON ctr.employee_id = emp.id
            LEFT JOIN salary_mult sm  ON pos.salary_mult_id = sm.id
            LEFT JOIN job         job ON sm.job_id = job.id
            LEFT JOIN level       lvl ON sm.level_id = lvl.id
            LEFT JOIN pay_period  pp  ON pay.period_id = pp.id
            WHERE pay.period_id = @PeriodId 
            AND pay.status <> @Status"

            Dim types() As Type = {
                GetType(Payroll), GetType(Position), GetType(Contract),
                GetType(Employee), GetType(Salary_Mult), GetType(Job),
                GetType(Level), GetType(Pay_Period)
            }

            Return db.Query(Of Payroll)(
                sql:=sql,
                types:=types,
                map:=Function(obj As Object())
                         Return MapPayrollLogic(obj)
                     End Function,
                param:=New With {
                    .Status = -1,
                    .PeriodId = period.id
                },
                splitOn:="id,id,id,id,id,id,id"
            )
        End Using
    End Function

    ' Hàm Mapping dùng chung cho 8 bảng
    Private Function MapPayrollLogic(obj As Object()) As Payroll
        ' Ép kiểu theo đúng thứ tự trong mảng types
        Dim pay = DirectCast(obj(0), Payroll)
        Dim pos = TryCast(obj(1), Position)
        Dim ctr = TryCast(obj(2), Contract)
        Dim emp = TryCast(obj(3), Employee)
        Dim sm = TryCast(obj(4), Salary_Mult)
        Dim job = TryCast(obj(5), Job)
        Dim lvl = TryCast(obj(6), Level)
        Dim pp = TryCast(obj(7), Pay_Period)

        ' Gán các quan hệ cấp 1
        pay.Position = pos
        pay.Pay_Period = pp

        ' Gán quan hệ cho Position
        If pos IsNot Nothing Then
            pos.Contract = ctr
            pos.Salary_Mult = sm

            ' Gán Job/Level thông qua Salary_Mult
            If sm IsNot Nothing Then
                sm.Job = job
                sm.Level = lvl

                ' Nếu Class Position có sẵn property Job/Level để hiển thị lên UI cho nhanh:
                ' pos.Job = job
                ' pos.Level = lvl
            End If
        End If

        ' Gán Employee vào Contract
        If ctr IsNot Nothing Then
            ctr.Employee = emp
        End If

        Return pay
    End Function

End Class