Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class ChinhSachModel
    Public Property Id As Integer
    Public Property MaChinhSach As String
    Public Property TenChinhSach As String
    Public Property LoaiChinhSach As String
    Public Property NgayHieuLuc As String
    Public Property NgayHetHan As String
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class ChinhSachRepository
    Public Function TaoBangRong() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaChinhSach", GetType(String))
        dt.Columns.Add("TenChinhSach", GetType(String))
        dt.Columns.Add("LoaiChinhSach", GetType(String))
        dt.Columns.Add("NgayHieuLuc", GetType(String))
        dt.Columns.Add("NgayHetHan", GetType(String))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))
        Return dt
    End Function

    Public Function LayDanhSach() As DataTable
        Dim dt = TaoBangRong()

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, datas FROM policy"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            JsonDuLieuHelper.LayChuoi(obj, "name"),
                            JsonDuLieuHelper.LayChuoi(obj, "type"),
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

    Public Sub Them(model As ChinhSachModel)
        Dim obj As New JObject()
        obj("code") = model.MaChinhSach
        obj("name") = model.TenChinhSach
        obj("type") = model.LoaiChinhSach
        obj("start_date") = model.NgayHieuLuc
        obj("end_date") = model.NgayHetHan
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO policy (datas) VALUES (@datas)"
                Dim param = cmd.CreateParameter()
                param.ParameterName = "@datas"
                param.Value = obj.ToString()
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As ChinhSachModel)
        Dim obj As New JObject()
        obj("code") = model.MaChinhSach
        obj("name") = model.TenChinhSach
        obj("type") = model.LoaiChinhSach
        obj("start_date") = model.NgayHieuLuc
        obj("end_date") = model.NgayHetHan
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE policy SET datas = @datas WHERE id = @id"
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
                cmd.CommandText = "DELETE FROM policy WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
