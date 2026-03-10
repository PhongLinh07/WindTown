Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class PayrollRepository
    Inherits GenericRepository(Of Payroll)

    Public Overrides Function GetAll() As IEnumerable(Of Payroll)

        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT
                pay.*,
                pos.*,
                ctr.*,
                emp.*,
                job.*,
                lvl.*,
                pp.*
            FROM payroll pay
            LEFT JOIN position    pos ON pay.position_id = pos.id
            LEFT JOIN contract    ctr ON pos.contract_id = ctr.id
            LEFT JOIN employee    emp ON ctr.employee_id = emp.id
            LEFT JOIN job         job ON pos.job_id      = job.id
            LEFT JOIN level       lvl ON pos.level_id    = lvl.id
            LEFT JOIN pay_period  pp  ON pay.period_id   = pp.id
            WHERE CAST(JSON_VALUE(pay.datas, '$.status') AS INT) <> @Status
            "

            Return db.Query(Of Payroll, Position, Contract, Employee, Job, Level, Pay_Period, Payroll)(
            sql,
            Function(pay, pos, ctr, emp, job, lvl, pp)

                pay.Position = pos
                pay.Pay_Period = pp

                If pos IsNot Nothing Then
                    pos.Contract = ctr
                    pos.Job = job
                    pos.Level = lvl
                End If

                If ctr IsNot Nothing Then
                    ctr.Employee = emp
                End If

                Return pay

            End Function,
            param:=New With {.Status = -1},
            splitOn:="id,id,id,id,id,id"
        )

        End Using

    End Function
End Class
