Public Class BaoCaoXuatCot
    Public Property TenCot As String
    Public Property TieuDe As String
    Public Property DuocChon As Boolean

    Public Overrides Function ToString() As String
        Return If(String.IsNullOrWhiteSpace(TieuDe), TenCot, TieuDe)
    End Function
End Class
