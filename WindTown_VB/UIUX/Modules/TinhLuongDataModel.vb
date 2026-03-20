Public Class TinhLuongDataModel

    Private ReadOnly _bangLuongService = AppServices.Instance.PayrollSV
    Private ReadOnly _kyLuongService = AppServices.Instance.Pay_PeriodSV
    Private ReadOnly _viTriService = AppServices.Instance.PositionSV

    Public Function TaiDanhSachBangLuong() As List(Of Payroll)
        Dim response = _bangLuongService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Payroll))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Payroll)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaiDanhSachKyLuong() As List(Of Pay_Period)
        Dim response = _kyLuongService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Pay_Period))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Pay_Period)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaiDanhSachViTri() As List(Of Position)
        Dim response = _viTriService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Position))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Position)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaoBangLuong(data As Payroll) As ServiceResponse(Of Object)
        Return _bangLuongService.Execute(DataIntent.Insert, data)
    End Function

    Public Function CapNhatBangLuong(data As Payroll) As ServiceResponse(Of Object)
        Return _bangLuongService.Execute(DataIntent.Update, data)
    End Function

    Public Function XoaBangLuong(items As List(Of Payroll)) As ServiceResponse(Of Object)
        Return _bangLuongService.Execute(DataIntent.SoftDeleteMany, items)
    End Function

End Class
