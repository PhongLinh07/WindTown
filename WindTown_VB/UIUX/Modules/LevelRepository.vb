Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class LevelModel
    Public Property Id As Integer
    Public Property MaCapBac As String
    Public Property TenCapBac As String
    Public Property ThuHang As Integer
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class LevelRepository
    Public Function LayDanhSach() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaCapBac", GetType(String))
        dt.Columns.Add("TenCapBac", GetType(String))
        dt.Columns.Add("ThuHang", GetType(Integer))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, datas FROM level"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        'Ánh xạ dữ liệu JSON của cấp bậc sang DataTable để hiển thị UI.
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            JsonDuLieuHelper.LayChuoi(obj, "name"),
                            JsonDuLieuHelper.LaySo(obj, "rank"),
                            JsonDuLieuHelper.LaySo(obj, "status"),
                            JsonDuLieuHelper.LayChuoi(obj, "note")
                        )
                    End While
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Sub Them(model As LevelModel)
        Dim obj As New JObject()
        obj("code") = model.MaCapBac
        obj("name") = model.TenCapBac
        obj("rank") = model.ThuHang
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO level (datas) VALUES (@datas)"
                Dim param = cmd.CreateParameter()
                param.ParameterName = "@datas"
                param.Value = obj.ToString()
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As LevelModel)
        Dim obj As New JObject()
        obj("code") = model.MaCapBac
        obj("name") = model.TenCapBac
        obj("rank") = model.ThuHang
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE level SET datas = @datas WHERE id = @id"
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
                cmd.CommandText = "DELETE FROM level WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
