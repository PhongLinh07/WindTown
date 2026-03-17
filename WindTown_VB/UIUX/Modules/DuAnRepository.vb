Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class DuAnModel
    Public Property Id As Integer
    Public Property MaDuAn As String
    Public Property TenDuAn As String
    Public Property NgayBatDau As String
    Public Property NgayKetThuc As String
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class DuAnRepository
    Public Function LayDanhSach() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaDuAn", GetType(String))
        dt.Columns.Add("TenDuAn", GetType(String))
        dt.Columns.Add("NgayBatDau", GetType(String))
        dt.Columns.Add("NgayKetThuc", GetType(String))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, datas FROM project"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            JsonDuLieuHelper.LayChuoi(obj, "name"),
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

    Public Sub Them(model As DuAnModel)
        Dim obj As New JObject()
        obj("code") = model.MaDuAn
        obj("name") = model.TenDuAn
        obj("start_date") = model.NgayBatDau
        obj("end_date") = model.NgayKetThuc
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO project (datas) VALUES (@datas)"
                Dim param = cmd.CreateParameter()
                param.ParameterName = "@datas"
                param.Value = obj.ToString()
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As DuAnModel)
        Dim obj As New JObject()
        obj("code") = model.MaDuAn
        obj("name") = model.TenDuAn
        obj("start_date") = model.NgayBatDau
        obj("end_date") = model.NgayKetThuc
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE project SET datas = @datas WHERE id = @id"
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
                cmd.CommandText = "DELETE FROM project WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
