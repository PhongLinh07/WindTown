Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class EmployeeRepository
    Inherits GenericRepository(Of Employee)

    ' Mỗi nhân viên chỉ có thể có 1 tài khoản, nhưng không phải tất cả nhân viên đều có tài khoản   
    Public Function GetEmployeesWithoutAccount() As IEnumerable(Of Employee)
        Using db As IDbConnection = Database.GetConnection()
            ' Câu lệnh SQL: Lấy nhân viên mà KHÔNG CÓ dòng tương ứng trong bảng account
            ' Giả sử bảng employee có cột id và bảng account có cột employee_id (hoặc id nếu dùng chung)
            Dim tableEmp As String = GetType(Employee).Name.ToLower()
            Dim tableAcc As String = GetType(Account).Name.ToLower()
            Dim sql As String = $"
            SELECT e.*
            FROM [{tableEmp}] e
            LEFT JOIN [{tableAcc}] a ON e.id = a.employee_id AND CAST(JSON_VALUE(a.datas, '$.status') AS INT) <> -1
            WHERE a.id IS NULL"

            ' Vì chỉ lấy thông tin Employee, không cần Multi-Mapping phức tạp
            Return db.Query(Of Employee)(sql)
        End Using
    End Function
End Class
