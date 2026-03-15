Public Class AttendanceService
    Inherits BaseService(Of Attendance)

    Private _repoAtt As AttendanceRepository = New AttendanceRepository
    Public Sub New()
        _repo = New AttendanceRepository()
    End Sub


    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
        Try
            Select Case intent
                Case DataIntent.GetAttendanceByPeriod
                    Dim period = TryCast(data, Pay_Period)

                    ' 1. Kiểm tra đối tượng có tồn tại không
                    If period Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công: Dữ liệu kỳ lương không hợp lệ.")
                    End If

                    ' 2. Kiểm tra ngày tháng (Sửa lỗi Is Nothing cho kiểu Date)
                    ' Nếu start_date là DateTime?, dùng IsNothing. Nếu là DateTime, so sánh với DateTime.MinValue
                    If period.start_date = DateTime.MinValue OrElse period.end_date = DateTime.MinValue Then
                        Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công:: Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc.")
                    End If

                    ' 3. Kiểm tra logic ngày (Ngày bắt đầu phải trước ngày kết thúc)
                    If period.start_date > period.end_date Then
                        Return ServiceResponse(Of Object).Fail("Lỗi lấy chấm công:: Ngày bắt đầu không được lớn hơn ngày kết thúc.")
                    End If

                    ' 4. Gọi hàm thực thi logic
                    Return _repoAtt.GetAttendanceByPeriod(period)
                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try
    End Function
End Class