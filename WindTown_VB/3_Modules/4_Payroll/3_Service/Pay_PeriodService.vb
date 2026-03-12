
Public Class Pay_PeriodService
    Inherits BaseService(Of Pay_Period)

    Private _repoPeriod As Pay_PeriodRepository = New Pay_PeriodRepository()
    Public Sub New()

        _repo = New Pay_PeriodRepository()
    End Sub

    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        Try
            Select Case intent
                Case DataIntent.StandardHoursCalculator
                    Dim period As Pay_Period = TryCast(data, Pay_Period)

                    Dim stdHours = Std_Hours_Calculator(period.start_date, period.end_date)
                    Return ServiceResponse(Of Object).Success(stdHours)


                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try
    End Function


    Private Function Std_Hours_Calculator(startDate As Date, endDate As Date) As Decimal

        Dim holidays As New List(Of Holiday)
        Dim holidayService As New BaseService(Of Holiday)

        ' Chuẩn hóa chỉ lấy ngày
        Dim startD As Date = startDate.Date
        Dim endD As Date = endDate.Date

        Logger.Instance.Logging("<----------------------- Tính ngày công chuẩn ---------------------->", Logger.Information)

        Dim response = holidayService.Execute(DataIntent.GetList)

        If Not response.IsSuccess Then
            Logger.Instance.Logging($"Tải ngày lễ thất bại: {response.Message}", Logger.Error)
        Else
            Logger.Instance.Logging($"Tải ngày lễ thành công: {response.Message}", Logger.Success)
            holidays = response.Data
        End If

        ' Lọc ngày lễ trong chu kỳ
        Dim holidayDates = holidays.
        Where(Function(x) x.of_date.Date >= startD AndAlso x.of_date.Date <= endD).
        Select(Function(x) x.of_date.Date).
        ToList()

        Dim stdDays As Integer = StandardHoursCalculator.StdWorkingDays(startD, endD, holidayDates)

        Dim stdHours As Decimal = stdDays * 8 'try

        Logger.Instance.Logging($"Số giờ làm việc chuẩn: {stdHours} giờ.", Logger.Information)

        Return stdHours

    End Function



End Class