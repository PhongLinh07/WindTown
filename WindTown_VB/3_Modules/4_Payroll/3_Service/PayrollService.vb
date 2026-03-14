Imports System.Linq
Imports Azure

Public Class PayrollService
    Inherits BaseService(Of Payroll)

    Private _repoPayroll As PayrollRepository = New PayrollRepository()
    Public Sub New()

        _repo = New PayrollRepository()
    End Sub


    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)


        Try
            Select Case intent
                Case DataIntent.Init_Payrolls
                    Dim period = TryCast(data, Pay_Period)

                    ' 1. Kiểm tra đối tượng có tồn tại không
                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    ' 2. Kiểm tra ngày tháng (Sửa lỗi Is Nothing cho kiểu Date)
                    ' Nếu start_date là DateTime?, dùng IsNothing. Nếu là DateTime, so sánh với DateTime.MinValue
                    If period.start_date = DateTime.MinValue OrElse period.end_date = DateTime.MinValue Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc.")
                    End If

                    ' 3. Kiểm tra logic ngày (Ngày bắt đầu phải trước ngày kết thúc)
                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi khởi tạo bảng lương: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If

                    ' 4. Gọi hàm thực thi logic
                    Return Init_Payrolls(period)

                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try

    End Function


    ' Khởi tại tất cả các bảng cho các nhân viên đang hoạt động lấy theo hoạt đồng  
    Private Function Init_Payrolls(ByVal period As Pay_Period) As ServiceResponse(Of Object)
        Try
            ' 1. Khởi tạo Services
            Dim contractService As New ContractService()
            Dim positionService As New PositionService()

            ' 2. Load và Lọc Hợp đồng (Lấy dữ liệu thô một lần để tối ưu máy B)
            Dim resContract = contractService.Execute(DataIntent.GetList)
            If Not resContract.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy hợp đồng: {resContract.Message}")

            Dim contractList = CType(resContract.Data, IEnumerable(Of Contract)).Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
            (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)).ToList()

            ' 3. Load và Lọc Chức vụ (Dùng GroupBy để tránh lỗi trùng Key nếu 1 Hợp đồng có nhiều chức vụ)
            Dim resPos = positionService.Execute(DataIntent.GetList)
            If Not resPos.IsSuccess Then Return ServiceResponse(Of Object).Fail($"Lỗi lấy chức vụ: {resPos.Message}")

            ' Lookup cho phép: contract_id -> List(Of Position)
            Dim positionLookup = CType(resPos.Data, IEnumerable(Of Position)).Where(Function(x) x.start_date.Date <= period.end_date.Date AndAlso
            (x.end_date Is Nothing OrElse x.end_date.Value.Date >= period.start_date.Date)).ToLookup(Function(x) x.contract_id)

            ' 4. Thực thi khởi tạo
            Dim countSucc As Integer = 0
            For Each ctr In contractList

                ' Lấy tất cả chức vụ thuộc hợp đồng này trong kỳ
                Dim positionsInPeriod = positionLookup(ctr.id)

                If Not positionsInPeriod.Any() Then
                    Logger.Instance.Logging($"Bỏ qua {ctr.employee_UI}: Không có chức vụ nào trong kỳ.", Logger.Error)
                    Continue For
                End If

                ' Lặp qua từng chức vụ để tạo bảng lương tương ứng
                For Each pos In positionsInPeriod
                    Dim pRow As New Payroll With {
                    .Pay_Period = period,
                    .Position = pos,
                    .status = 1}

                    ' Lưu từng dòng
                    If Me.Execute(DataIntent.Insert, pRow).IsSuccess Then
                        countSucc += 1
                    End If
                Next
            Next

            Dim msg = $"Khởi tạo thành công: {countSucc}/{contractList.Count}"
            Logger.Instance.Logging(msg, Logger.Success)
            Return ServiceResponse(Of Object).Success(msg)

    Catch ex As Exception
            Return ServiceResponse(Of Object).Fail($"Lỗi hệ thống: {ex.Message}")
        End Try
    End Function
End Class