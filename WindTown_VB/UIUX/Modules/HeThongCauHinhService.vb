Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class HeThongCauHinhModel
    Public Property MayChu As String
    Public Property TenCSDL As String
    Public Property TaiKhoan As String
    Public Property MatKhau As String
    Public Property SuDungXacThucWindows As Boolean
    Public Property NgonNgu As String
    Public Property DinhDangNgay As String
End Class

Public NotInheritable Class HeThongCauHinhService
    Private Const TenChuoiKetNoi As String = "WindTownConnection"
    Private Const KhoaNgonNgu As String = "NgonNguHienThi"
    Private Const KhoaDinhDangNgay As String = "DinhDangNgay"

    Public Shared Function TaiCauHinh() As HeThongCauHinhModel
        Dim model As New HeThongCauHinhModel()
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim connSetting = config.ConnectionStrings.ConnectionStrings(TenChuoiKetNoi)
        Dim builder As New SqlConnectionStringBuilder()

        If connSetting IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(connSetting.ConnectionString) Then
            builder.ConnectionString = connSetting.ConnectionString
        End If

        model.MayChu = builder.DataSource
        model.TenCSDL = builder.InitialCatalog

        If builder.IntegratedSecurity OrElse String.IsNullOrWhiteSpace(builder.UserID) Then
            model.SuDungXacThucWindows = True
            model.TaiKhoan = ""
            model.MatKhau = ""
        Else
            model.SuDungXacThucWindows = False
            model.TaiKhoan = builder.UserID
            model.MatKhau = builder.Password
        End If

        model.NgonNgu = DocGiaTriAppSetting(config, KhoaNgonNgu, "Tiếng Việt")
        model.DinhDangNgay = DocGiaTriAppSetting(config, KhoaDinhDangNgay, "dd/MM/yyyy")

        Return model
    End Function

    Public Shared Sub LuuCauHinh(model As HeThongCauHinhModel)
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim connSetting = config.ConnectionStrings.ConnectionStrings(TenChuoiKetNoi)

        If connSetting Is Nothing Then
            connSetting = New ConnectionStringSettings(TenChuoiKetNoi, "", "System.Data.SqlClient")
            config.ConnectionStrings.ConnectionStrings.Add(connSetting)
        End If

        connSetting.ConnectionString = TaoChuoiKetNoi(model)

        CapNhatAppSetting(config, KhoaNgonNgu, model.NgonNgu)
        CapNhatAppSetting(config, KhoaDinhDangNgay, model.DinhDangNgay)

        config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("connectionStrings")
        ConfigurationManager.RefreshSection("appSettings")
    End Sub

    Public Shared Function KiemTraKetNoi(model As HeThongCauHinhModel, ByRef thongBao As String) As Boolean
        Dim connStr = TaoChuoiKetNoi(model)

        If String.IsNullOrWhiteSpace(model.MayChu) OrElse String.IsNullOrWhiteSpace(model.TenCSDL) Then
            thongBao = "Vui lòng nhập đầy đủ máy chủ và tên cơ sở dữ liệu."
            Return False
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
            End Using
            thongBao = "Kết nối cơ sở dữ liệu thành công."
            Return True
        Catch ex As Exception
            thongBao = "Kết nối thất bại: " & ex.Message
            Return False
        End Try
    End Function

    Private Shared Function TaoChuoiKetNoi(model As HeThongCauHinhModel) As String
        Dim builder As New SqlConnectionStringBuilder()
        builder.DataSource = model.MayChu
        builder.InitialCatalog = model.TenCSDL
        builder.ConnectTimeout = 5
        builder.TrustServerCertificate = True

        If model.SuDungXacThucWindows OrElse String.IsNullOrWhiteSpace(model.TaiKhoan) Then
            builder.IntegratedSecurity = True
        Else
            builder.IntegratedSecurity = False
            builder.UserID = model.TaiKhoan
            builder.Password = model.MatKhau
        End If

        Return builder.ConnectionString
    End Function

    Private Shared Function DocGiaTriAppSetting(config As Configuration, khoa As String, giaTriMacDinh As String) As String
        Dim setting = config.AppSettings.Settings(khoa)
        If setting Is Nothing OrElse String.IsNullOrWhiteSpace(setting.Value) Then
            Return giaTriMacDinh
        End If
        Return setting.Value
    End Function

    Private Shared Sub CapNhatAppSetting(config As Configuration, khoa As String, giaTri As String)
        Dim setting = config.AppSettings.Settings(khoa)
        If setting Is Nothing Then
            config.AppSettings.Settings.Add(khoa, giaTri)
        Else
            setting.Value = giaTri
        End If
    End Sub
End Class
