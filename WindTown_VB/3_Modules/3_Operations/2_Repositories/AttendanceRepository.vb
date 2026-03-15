Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class AttendanceRepository
    Inherits GenericRepository(Of Attendance)

    Public Overrides Function GetAll() As IEnumerable(Of Attendance)
        Using db As IDbConnection = Database.GetConnection()

            ' a.* lấy toàn bộ cột của Attendance, e.* lấy toàn bộ cột của employee | nhưng trả về 1 đối tượng Attendance duy nhất (chứ không phải 2 đối tượng)
            Dim sql As String = $"
                SELECT a.*, e.* 
                FROM attendance a
                LEFT JOIN employee e ON a.employee_id = e.id
                WHERE CAST(JSON_VALUE(a.datas, '$.status') AS INT) <> @Status"

            ' 3. Thực thi Multi-Mapping
            ' Of Attendance, Empployee, Attendance -> Đọc Empolyee, đọc Employee, trả về Attendance
            Return db.Query(Of Attendance, Employee, Attendance)(
                sql,
                Function(attObj, empObj)
                    ' ĐÂY LÀ BƯỚC "SNAP": Gán đối tượng Employee vào Attendance
                    attObj.Employee = empObj
                    Return attObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id" ' Dấu hiệu để Dapper biết bắt đầu bảng thứ 2 từ cột "id"
            )
        End Using
    End Function

    Public Function GetAttendanceByPeriod(ByVal period As Pay_Period) As IEnumerable(Of Attendance)
        Using db As IDbConnection = Database.GetConnection()

            ' 1. Sửa SQL: Thêm điều kiện lọc ngày (off_date) nằm trong khoảng start_date và end_date của kỳ
            ' Lưu ý: Vì dữ liệu của Gemi nằm trong trường 'datas' (JSON), ta cần dùng JSON_VALUE để lấy off_date
            Dim sql As String = $"
            SELECT a.*, e.* FROM attendance a
            LEFT JOIN employee e ON a.employee_id = e.id
            WHERE CAST(JSON_VALUE(a.datas, '$.status') AS INT) <> @Status
            AND CAST(JSON_VALUE(a.datas, '$.off_date') AS DATE) >= @StartDate
            AND CAST(JSON_VALUE(a.datas, '$.off_date') AS DATE) <= @EndDate"

            ' 2. Thực thi với tham số từ period
            Return db.Query(Of Attendance, Employee, Attendance)(
                sql,
                Function(attObj, empObj)
                    attObj.Employee = empObj
                    Return attObj
                End Function,
                param:=New With {
                    .Status = -1,
                    .StartDate = period.start_date.Date,
                    .EndDate = period.end_date.Date
                },
                splitOn:="id"
            )
        End Using
    End Function
End Class