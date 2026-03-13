Public Class KyLuongDataModel

    Private ReadOnly _kyLuongService As New Pay_PeriodService()

    Public Function TaiDanhSachKyLuong() As List(Of Pay_Period)
        Dim response = _kyLuongService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Pay_Period))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Pay_Period)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaoKyLuong(data As Pay_Period) As ServiceResponse(Of Object)
        Return _kyLuongService.Execute(DataIntent.Insert, data)
    End Function

    Public Function CapNhatKyLuong(data As Pay_Period) As ServiceResponse(Of Object)
        Return _kyLuongService.Execute(DataIntent.Update, data)
    End Function

    Public Function XoaKyLuong(items As List(Of Pay_Period)) As ServiceResponse(Of Object)
        Return _kyLuongService.Execute(DataIntent.SoftDeleteMany, items)
    End Function

End Class
