Imports Dapper
Imports System.Data
Imports WindTown_VB.DatabaseConfig

Public Class PositionRepository
    Inherits GenericRepository(Of Position)

    Public Overrides Function GetAll() As IEnumerable(Of Position)
        Using db As IDbConnection = Database.GetConnection()

            ' SQL mới: p -> c -> e AND p -> sm -> j AND p -> sm -> l
            ' Lưu ý: p.status hiện tại là cột vật lý nên không dùng JSON_VALUE nữa
            Dim sql As String = "
                SELECT 
                    p.*, 
                    c.*, 
                    e.*,
                    sm.*,
                    j.*, 
                    l.*
                FROM position p
                LEFT JOIN contract c ON p.contract_id = c.id
                LEFT JOIN employee e ON c.employee_id = e.id
                LEFT JOIN salary_mult sm ON p.salary_mult_id = sm.id
                LEFT JOIN job j ON sm.job_id = j.id
                LEFT JOIN level l ON sm.level_id = l.id
               WHERE p.status <> @Status"

            Return db.Query(Of Position, Contract, Employee, Salary_Mult, Job, Level, Position)(
                sql,
                Function(posObj, conObj, empObj, smObj, jobObj, lvlObj)
                    ' Gán quan hệ Hợp đồng - Nhân viên
                    posObj.Contract = conObj
                    If conObj IsNot Nothing Then
                        conObj.Employee = empObj
                    End If

                    ' Gán quan hệ Hệ số - Công việc - Cấp bậc
                    posObj.Salary_Mult = smObj
                    If smObj IsNot Nothing Then
                        smObj.Job = jobObj
                        smObj.Level = lvlObj
                    End If

                    Return posObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id,id,id,id,id" ' 5 dấu phẩy cho 6 bảng
            )
        End Using
    End Function

    Public Function GetPositionsWithoutAssignment() As IEnumerable(Of Position)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
                SELECT 
                    p.*, 
                    c.*, 
                    e.*,
                    sm.*,
                    j.*, 
                    l.*
                FROM position p
                LEFT JOIN contract c ON p.contract_id = c.id
                LEFT JOIN employee e ON c.employee_id = e.id
                LEFT JOIN salary_mult sm ON p.salary_mult_id = sm.id
                LEFT JOIN job j ON sm.job_id = j.id
                LEFT JOIN level l ON sm.level_id = l.id
                WHERE p.status <> -1
                AND NOT EXISTS (
                    SELECT 1 
                    FROM assignment a
                    WHERE a.position_id = p.id
                    AND a.status = 1
                )"

            Return db.Query(Of Position, Contract, Employee, Salary_Mult, Job, Level, Position)(
                sql,
                Function(posObj, conObj, empObj, smObj, jobObj, lvlObj)
                    posObj.Contract = conObj
                    If conObj IsNot Nothing Then conObj.Employee = empObj

                    posObj.Salary_Mult = smObj
                    If smObj IsNot Nothing Then
                        smObj.Job = jobObj
                        smObj.Level = lvlObj
                    End If

                    Return posObj
                End Function,
                splitOn:="id,id,id,id,id"
            )
        End Using
    End Function
End Class