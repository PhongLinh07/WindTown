Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Module ThongTinHeThongService
    Public Function LayTenCoSoDuLieu() As String
        Dim cauHinh = ConfigurationManager.ConnectionStrings("WindTownConnection")
        If cauHinh Is Nothing OrElse String.IsNullOrWhiteSpace(cauHinh.ConnectionString) Then Return ""
        Dim builder As New SqlConnectionStringBuilder(cauHinh.ConnectionString)
        Return builder.InitialCatalog
    End Function

    Public Function LayThongTinHienThi() As String
        Dim csdl = LayTenCoSoDuLieu()
        Dim taiKhoan = NguoiDungHienTaiService.LayTenDangNhap()

        If String.IsNullOrWhiteSpace(csdl) AndAlso String.IsNullOrWhiteSpace(taiKhoan) Then Return ""
        If String.IsNullOrWhiteSpace(csdl) Then Return $"Tài khoản: {taiKhoan}"
        If String.IsNullOrWhiteSpace(taiKhoan) Then Return $"CSDL: {csdl}"
        Return $"CSDL: {csdl} | Tài khoản: {taiKhoan}"
    End Function
End Module
