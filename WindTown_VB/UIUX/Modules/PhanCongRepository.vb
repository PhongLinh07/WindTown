Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class PhanCongModel
    Public Property Id As Integer
    Public Property MaPhanCong As String
    Public Property ProjectId As Integer
    Public Property PositionId As Integer
    Public Property VaiTro As String
    Public Property NgayBatDau As String
    Public Property NgayKetThuc As String
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class PhanCongRepository
    Public Function LayDanhSach() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaPhanCong", GetType(String))
        dt.Columns.Add("ProjectId", GetType(Integer))
        dt.Columns.Add("PositionId", GetType(Integer))
        dt.Columns.Add("VaiTro", GetType(String))
        dt.Columns.Add("NgayBatDau", GetType(String))
        dt.Columns.Add("NgayKetThuc", GetType(String))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, project_id, position_id, datas FROM assignment"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim projectId = Convert.ToInt32(reader("project_id"))
                        Dim positionId = Convert.ToInt32(reader("position_id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            projectId,
                            positionId,
                            JsonDuLieuHelper.LayChuoi(obj, "role"),
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

    Public Sub Them(model As PhanCongModel)
        Dim obj As New JObject()
        obj("code") = model.MaPhanCong
        obj("role") = model.VaiTro
        obj("start_date") = model.NgayBatDau
        obj("end_date") = model.NgayKetThuc
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO assignment (position_id, project_id, datas) VALUES (@position_id, @project_id, @datas)"
                cmd.Parameters.Add(New SqlParameter("@position_id", model.PositionId))
                cmd.Parameters.Add(New SqlParameter("@project_id", model.ProjectId))
                cmd.Parameters.Add(New SqlParameter("@datas", obj.ToString()))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As PhanCongModel)
        Dim obj As New JObject()
        obj("code") = model.MaPhanCong
        obj("role") = model.VaiTro
        obj("start_date") = model.NgayBatDau
        obj("end_date") = model.NgayKetThuc
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE assignment SET position_id = @position_id, project_id = @project_id, datas = @datas WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@position_id", model.PositionId))
                cmd.Parameters.Add(New SqlParameter("@project_id", model.ProjectId))
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
                cmd.CommandText = "DELETE FROM assignment WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
