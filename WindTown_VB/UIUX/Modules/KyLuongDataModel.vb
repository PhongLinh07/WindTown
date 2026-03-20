Public Class KyLuongDataModel

    Private ReadOnly _kyLuongService = AppServices.Instance.Pay_PeriodSV

    Public Function TaiDanhSachKyLuong() As List(Of Pay_Period)
        Dim response = _kyLuongService.GetList()
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Pay_Period))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Pay_Period)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaoKyLuong(data As Pay_Period) As ServiceResponse(Of Object)
        Return _kyLuongService.Insert(data)
    End Function

    Public Function CapNhatKyLuong(data As Pay_Period) As ServiceResponse(Of Object)
        Return _kyLuongService.Update(data)
    End Function

    Public Function XoaKyLuong(items As List(Of Pay_Period)) As ServiceResponse(Of Object)
        Return _kyLuongService.Delete(items)
    End Function

End Class
