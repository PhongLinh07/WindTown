Public Class StandardHoursCalculator

    ''' <summary>
    ''' Trả về tổng số ngày giữa hai mốc (bao gồm cả ngày bắt đầu và kết thúc).
    ''' </summary>
    Public Shared Function DayDiff(startDate As DateTime, endDate As DateTime) As Integer

        If endDate < startDate Then
            Throw New ArgumentException("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.")
        End If

        Return (endDate - startDate).Days + 1

    End Function


    ''' <summary>
    ''' Tính số ngày công chuẩn giữa hai mốc thời gian,
    ''' loại trừ Chủ nhật và các ngày lễ nếu có.
    ''' </summary>
    ''' <param name="startDate">Ngày bắt đầu</param>
    ''' <param name="endDate">Ngày kết thúc</param>
    ''' <param name="holidays">Danh sách ngày lễ cần loại trừ (tùy chọn)</param>
    ''' <returns>Số ngày công chuẩn</returns>
    Public Shared Function StdWorkingDays(startDate As DateTime, endDate As DateTime, Optional holidays As IEnumerable(Of DateTime) = Nothing) As Integer

        If endDate < startDate Then
            Throw New ArgumentException("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.")
        End If

        ' HashSet ngày lễ
        Dim holidaySet As HashSet(Of DateTime)

        If holidays IsNot Nothing Then
            holidaySet = holidays.Select(Function(h) h.Date).ToHashSet()
        Else
            holidaySet = New HashSet(Of DateTime)
        End If

        ' Tạo danh sách ngày trong khoảng
        Dim days = Enumerable.
        Range(0, (endDate.Date - startDate.Date).Days + 1).
        Select(Function(offset) startDate.Date.AddDays(offset)).
        ToList()

        ' Đếm Chủ nhật
        Dim sundayCount As Integer = Enumerable.Count(days, Function(d) d.DayOfWeek = DayOfWeek.Sunday)

        ' Đếm ngày lễ
        Dim holidayCount As Integer = Enumerable.Count(days, Function(d) holidaySet.Contains(d))

        ' Đếm ngày làm việc
        Dim workingDays As Integer = Enumerable.Count(days, Function(d) d.DayOfWeek <> DayOfWeek.Sunday AndAlso Not holidaySet.Contains(d))

        Logger.Instance.Logging($"Chu kỳ {startDate:dd-MM-yyyy} -> {endDate:dd-MM-yyyy} có:", Logger.Information)
        Logger.Instance.Logging($"Số Chủ nhật: {sundayCount}", Logger.Information)
        Logger.Instance.Logging($"Số ngày lễ: {holidayCount}", Logger.Information)
        Logger.Instance.Logging($"Số ngày làm việc chuẩn: {workingDays}", Logger.Information)

        Return workingDays

    End Function

End Class