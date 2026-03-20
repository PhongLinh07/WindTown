Imports Dapper
Imports System.Data
Imports WindTown_VB.DatabaseConfig

Public Class AssignmentRepository
    Inherits GenericRepository(Of Assignment)
    Public Overrides Function GetAll() As IEnumerable(Of Assignment)
        Using db As IDbConnection = Database.GetConnection()
            Dim sql As String = "
            SELECT
                ass.*,
                pr.*,
                p.*,
                c.*,
                e.*,
                sm.*,
                j.*,
                l.*
            FROM assignment ass
            LEFT JOIN project pr ON ass.project_id = pr.id
            LEFT JOIN position p ON ass.position_id = p.id
            LEFT JOIN contract c ON p.contract_id = c.id
            LEFT JOIN employee e ON c.employee_id = e.id
            LEFT JOIN salary_mult sm ON p.salary_mult_id = sm.id
            LEFT JOIN job j ON sm.job_id = j.id
            LEFT JOIN level l ON sm.level_id = l.id
            WHERE ass.status <> @Status"

            ' 1. Định nghĩa mảng các kiểu dữ liệu
            Dim types() As Type = {
            GetType(Assignment), GetType(Project), GetType(Position),
            GetType(Contract), GetType(Employee), GetType(Salary_Mult),
            GetType(Job), GetType(Level)
        }

            ' 2. Gọi hàm Query với đầy đủ tham số đặt tên (Named Arguments) để tránh nhầm lẫn overload
            Return db.Query(Of Assignment)(
            sql:=sql,
            types:=types,
            map:=Function(obj As Object()) ' Chỉ định rõ obj là mảng Object
                     Dim ass = DirectCast(obj(0), Assignment)
                     Dim pr = TryCast(obj(1), Project)
                     Dim pos = TryCast(obj(2), Position)
                     Dim ctr = TryCast(obj(3), Contract)
                     Dim emp = TryCast(obj(4), Employee)
                     Dim sm = TryCast(obj(5), Salary_Mult)
                     Dim job = TryCast(obj(6), Job)
                     Dim lvl = TryCast(obj(7), Level)

                     ' Gán Dự án
                     ass.Project = pr

                     ' Gán Vị trí
                     ass.Position = pos
                     If pos IsNot Nothing Then
                         pos.Contract = ctr
                         pos.Salary_Mult = sm

                         ' LƯU Ý: Đã xóa pos.Job và pos.Level vì class Position không có 2 trường này
                         ' Bạn chỉ có thể gán vào Salary_Mult (sm)
                         If sm IsNot Nothing Then
                             sm.Job = job
                             sm.Level = lvl
                         End If
                     End If

                     ' Gán Nhân viên vào Hợp đồng
                     If ctr IsNot Nothing Then
                         ctr.Employee = emp
                     End If

                     Return ass
                 End Function,
            param:=New With {.Status = -1},
            splitOn:="id,id,id,id,id,id,id"
        )
        End Using
    End Function
End Class