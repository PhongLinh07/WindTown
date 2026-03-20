Imports System.Data
Imports System.Data.SqlClient
Imports WindTown_VB.DatabaseConfig

Public Class BaoCaoTongHopRepository

    Public Function TaiDanhSachPhongBan() As List(Of LuaChonPhongBan)
        Dim danhSach As New List(Of LuaChonPhongBan)()
        Using conn = Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, datas FROM department"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        Dim ma = JsonDuLieuHelper.LayChuoi(obj, "code")
                        Dim ten = JsonDuLieuHelper.LayChuoi(obj, "name")
                        Dim hienThi = If(String.IsNullOrWhiteSpace(ma), ten, $"{ma} - {ten}")
                        If String.IsNullOrWhiteSpace(hienThi) Then
                            hienThi = $"PB #{id}"
                        End If
                        danhSach.Add(New LuaChonPhongBan With {.Id = id, .Ten = hienThi})
                    End While
                End Using
            End Using
        End Using
        Return danhSach
    End Function

    Public Function TaiMapNhanVienPhongBan() As Dictionary(Of Integer, Integer)
        Dim ketQua As New Dictionary(Of Integer, Integer)()
        Using conn = Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
SELECT
    emp.id AS employee_id,
    d.id AS department_id
FROM employee emp
LEFT JOIN contract c
    ON c.employee_id = emp.id
    AND ISNULL(CAST(JSON_VALUE(c.datas, '$.status') AS INT), 0) <> -1
LEFT JOIN position p
    ON p.contract_id = c.id
    AND ISNULL(CAST(JSON_VALUE(p.datas, '$.status') AS INT), 0) <> -1
LEFT JOIN salary_mult sm ON p.salary_mult_id = sm.id
LEFT JOIN job j ON sm.job_id = j.id
LEFT JOIN department d ON j.department_id = d.id
WHERE ISNULL(CAST(JSON_VALUE(emp.datas, '$.status') AS INT), 0) <> -1
"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim empId = If(reader("employee_id") Is DBNull.Value, 0, Convert.ToInt32(reader("employee_id")))
                        Dim deptId = If(reader("department_id") Is DBNull.Value, 0, Convert.ToInt32(reader("department_id")))
                        If empId <= 0 OrElse deptId <= 0 Then Continue While
                        If ketQua.ContainsKey(empId) Then Continue While
                        ketQua(empId) = deptId
                    End While
                End Using
            End Using
        End Using
        Return ketQua
    End Function
End Class
