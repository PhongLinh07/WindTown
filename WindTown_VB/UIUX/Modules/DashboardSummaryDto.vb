Public Class DashboardSummaryDto
    Public Property TotalEmployees As Integer
    Public Property ActiveEmployees As Integer
    Public Property InactiveEmployees As Integer
    Public Property TotalDepartments As Integer

    Public Property OnTimeTodayCount As Integer
    Public Property MissingCheckInTodayCount As Integer
    Public Property LateInWeekCount As Integer

    Public Property TopOnTimeInMonth As New List(Of DashboardTopItem)
    Public Property TopLateInWeek As New List(Of DashboardTopItem)
End Class

Public Class DashboardTopItem
    Public Property EmployeeCode As String
    Public Property EmployeeName As String
    Public Property MetricValue As Decimal
End Class
