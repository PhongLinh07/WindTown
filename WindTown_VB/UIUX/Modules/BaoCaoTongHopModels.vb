Public Class BaoCaoBoLoc
    Public Property Thang As Integer
    Public Property Nam As Integer
    Public Property PhongBanId As Integer
End Class

Public Class BaoCaoDuLieuBieuDo
    Public Property Nhan As String
    Public Property GiaTri As Decimal
End Class

Public Class BaoCaoTopLuongItem
    Public Property MaNhanVien As String
    Public Property TenNhanVien As String
    Public Property PhongBan As String
    Public Property TongLuong As Decimal
End Class

Public Class BaoCaoTongHopDto
    Public Property TongNhanVien As Integer
    Public Property TongChiPhiLuong As Decimal
    Public Property TongGioTangCa As Decimal
    Public Property TongNgayNghi As Decimal
    Public Property NhanSuTheoPhongBan As List(Of BaoCaoDuLieuBieuDo) = New List(Of BaoCaoDuLieuBieuDo)()
    Public Property LuongTheoThang As List(Of BaoCaoDuLieuBieuDo) = New List(Of BaoCaoDuLieuBieuDo)()
    Public Property ChamCongTongQuan As List(Of BaoCaoDuLieuBieuDo) = New List(Of BaoCaoDuLieuBieuDo)()
    Public Property TopLuong As List(Of BaoCaoTopLuongItem) = New List(Of BaoCaoTopLuongItem)()
End Class

Public Class LuaChonPhongBan
    Public Property Id As Integer
    Public Property Ten As String
End Class
