Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class NghiPhepModel
    Public Property Id As Integer
    Public Property MaNghiPhep As String
    Public Property EmployeeId As Integer
    Public Property ApprovedId As Integer
    Public Property LeaveCatId As Integer
    Public Property TuNgay As String
    Public Property DenNgay As String
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class NghiPhepRepository
    Public Function LayDanhSach() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaNghiPhep", GetType(String))
        dt.Columns.Add("EmployeeId", GetType(Integer))
        dt.Columns.Add("ApprovedId", GetType(Integer))
        dt.Columns.Add("LeaveCatId", GetType(Integer))
        dt.Columns.Add("TuNgay", GetType(String))
        dt.Columns.Add("DenNgay", GetType(String))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, employee_id, approved_id, leave_cat_id, datas FROM [leave]"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim employeeId = Convert.ToInt32(reader("employee_id"))
                        Dim approvedId = Convert.ToInt32(reader("approved_id"))
                        Dim leaveCatId = Convert.ToInt32(reader("leave_cat_id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            employeeId,
                            approvedId,
                            leaveCatId,
                            JsonDuLieuHelper.LayChuoi(obj, "start_date"),
                            JsonDuLieuHelper.LayChuoi(obj, "end_date"),
                            JsonDuLieuHelper.LaySo(obj, "status"),
                            JsonDuLieuHelper.LayChuoi(obj, "note")
                        )
                    End While
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Sub Them(model As NghiPhepModel)
        Dim obj As New JObject()
        obj("code") = model.MaNghiPhep
        obj("start_date") = model.TuNgay
        obj("end_date") = model.DenNgay
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO [leave] (employee_id, approved_id, leave_cat_id, datas) VALUES (@employee_id, @approved_id, @leave_cat_id, @datas)"
                cmd.Parameters.Add(New SqlParameter("@employee_id", model.EmployeeId))
                cmd.Parameters.Add(New SqlParameter("@approved_id", model.ApprovedId))
                cmd.Parameters.Add(New SqlParameter("@leave_cat_id", model.LeaveCatId))
                cmd.Parameters.Add(New SqlParameter("@datas", obj.ToString()))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As NghiPhepModel)
        Dim obj As New JObject()
        obj("code") = model.MaNghiPhep
        obj("start_date") = model.TuNgay
        obj("end_date") = model.DenNgay
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE [leave] SET employee_id = @employee_id, approved_id = @approved_id, leave_cat_id = @leave_cat_id, datas = @datas WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@employee_id", model.EmployeeId))
                cmd.Parameters.Add(New SqlParameter("@approved_id", model.ApprovedId))
                cmd.Parameters.Add(New SqlParameter("@leave_cat_id", model.LeaveCatId))
                cmd.Parameters.Add(New SqlParameter("@datas", obj.ToString()))
                cmd.Parameters.Add(New SqlParameter("@id", model.Id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Xoa(id As Integer)
        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [leave] WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
