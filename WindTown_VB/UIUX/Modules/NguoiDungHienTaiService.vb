Public Module NguoiDungHienTaiService
    Private _taiKhoanDangNhap As Account

    Public Sub GanTaiKhoanDangNhap(taiKhoan As Account)
        _taiKhoanDangNhap = taiKhoan
    End Sub

    Public ReadOnly Property TaiKhoanDangNhap As Account
        Get
            Return _taiKhoanDangNhap
        End Get
    End Property

    Public Function LayTenDangNhap() As String
        If _taiKhoanDangNhap IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_taiKhoanDangNhap.user) Then
            Return _taiKhoanDangNhap.user
        End If
        Return Environment.UserName
    End Function

    Public Function CoQuyenSua() As Boolean
        If _taiKhoanDangNhap Is Nothing Then Return False
        Return _taiKhoanDangNhap.role = 1
    End Function
End Module
