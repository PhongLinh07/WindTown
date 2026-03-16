Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq

Public Class NgayLeModel
    Public Property Id As Integer
    Public Property MaNgay As String
    Public Property TenNgay As String
    Public Property Ngay As String
    Public Property DayMult As Decimal
    Public Property NightMult As Decimal
    Public Property OtMult As Decimal
    Public Property TrangThai As Integer
    Public Property GhiChu As String
End Class

Public Class NgayLeRepository
    Public Function LayDanhSach() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("MaNgay", GetType(String))
        dt.Columns.Add("TenNgay", GetType(String))
        dt.Columns.Add("Ngay", GetType(String))
        dt.Columns.Add("DayMult", GetType(Decimal))
        dt.Columns.Add("NightMult", GetType(Decimal))
        dt.Columns.Add("OtMult", GetType(Decimal))
        dt.Columns.Add("TrangThai", GetType(Integer))
        dt.Columns.Add("GhiChu", GetType(String))

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, datas FROM holiday"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = Convert.ToInt32(reader("id"))
                        Dim json = If(reader("datas") Is DBNull.Value, "", reader("datas").ToString())
                        Dim obj = JsonDuLieuHelper.TaiJson(json)
                        dt.Rows.Add(
                            id,
                            JsonDuLieuHelper.LayChuoi(obj, "code"),
                            JsonDuLieuHelper.LayChuoi(obj, "name"),
                            JsonDuLieuHelper.LayChuoi(obj, "of_date"),
                            LaySoThapPhan(obj, "day_mult"),
                            LaySoThapPhan(obj, "night_mult"),
                            LaySoThapPhan(obj, "ot_mult"),
                            JsonDuLieuHelper.LaySo(obj, "status"),
                            JsonDuLieuHelper.LayChuoi(obj, "note")
                        )
                    End While
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Sub Them(model As NgayLeModel)
        Dim obj As New JObject()
        obj("code") = model.MaNgay
        obj("name") = model.TenNgay
        obj("of_date") = model.Ngay
        obj("day_mult") = model.DayMult
        obj("night_mult") = model.NightMult
        obj("ot_mult") = model.OtMult
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO holiday (datas) VALUES (@datas)"
                cmd.Parameters.Add(New SqlParameter("@datas", obj.ToString()))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CapNhat(model As NgayLeModel)
        Dim obj As New JObject()
        obj("code") = model.MaNgay
        obj("name") = model.TenNgay
        obj("of_date") = model.Ngay
        obj("day_mult") = model.DayMult
        obj("night_mult") = model.NightMult
        obj("ot_mult") = model.OtMult
        obj("note") = model.GhiChu
        obj("status") = model.TrangThai

        Using conn = DatabaseConfig.Database.GetConnection()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE holiday SET datas = @datas WHERE id = @id"
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
                cmd.CommandText = "DELETE FROM holiday WHERE id = @id"
                cmd.Parameters.Add(New SqlParameter("@id", id))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function LaySoThapPhan(obj As JObject, khoa As String) As Decimal
        Dim raw = JsonDuLieuHelper.LayChuoi(obj, khoa)
        Dim giaTri As Decimal
        If Decimal.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0D
    End Function
End Class
