Imports Dapper
Imports System.Data
Imports WindTown_VB.DatabaseConfig

Public Class PayrollRepository
    Inherits GenericRepository(Of Payroll)

    Public Overrides Function GetAll() As IEnumerable(Of Payroll)
        Using db As IDbConnection = Database.GetConnection()
            Dim sql As String = "
                SELECT 
                    pr.*,
                    pp.*,
                    pos.*,
                    c.*,
                    e.*,
                    j.*,
                    l.*
                FROM payroll pr
                LEFT JOIN pay_period pp ON pr.period_id = pp.id
                LEFT JOIN position pos ON pr.position_id = pos.id
                LEFT JOIN contract c ON pos.contract_id = c.id
                LEFT JOIN employee e ON c.employee_id = e.id
                LEFT JOIN job j ON pos.job_id = j.id
                LEFT JOIN level l ON pos.level_id = l.id
                WHERE ISNULL(CAST(JSON_VALUE(pr.datas, '$.status') AS INT), 0) <> @Status"

            Return db.Query(Of Payroll, Pay_Period, Position, Contract, Employee, Job, Level, Payroll)(
                sql,
                Function(payrollObj, periodObj, positionObj, contractObj, employeeObj, jobObj, levelObj)
                    payrollObj.Period = periodObj
                    payrollObj.Position = positionObj

                    If positionObj IsNot Nothing Then
                        positionObj.Contract = contractObj
                        positionObj.Job = jobObj
                        positionObj.Level = levelObj
                    End If

                    If contractObj IsNot Nothing Then
                        contractObj.Employee = employeeObj
                    End If

                    Return payrollObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id,id,id,id,id,id"
            )
        End Using
    End Function
End Class
