Public Class DashboardService

    Private ReadOnly _employeeService As New EmployeeService()
    Private ReadOnly _attendanceService As New AttendanceService()
    Private ReadOnly _departmentService As New BaseService(Of Department)()

    Public Function BuildSummary(selectedDate As DateTime) As DashboardSummaryDto

        Dim summary As New DashboardSummaryDto()

        ' LOAD DATA SONG SONG
        Dim empTask = Task.Run(Function() LoadEmployees())
        Dim attTask = Task.Run(Function() LoadAttendances())
        Dim depTask = Task.Run(Function() LoadDepartments())

        Task.WaitAll(empTask, attTask, depTask)

        Dim employees = empTask.Result
        Dim attendances = attTask.Result
        Dim departments = depTask.Result

        ' MAP EMPLOYEE
        Dim employeeMap = employees.ToDictionary(Function(x) x.id, Function(x) x)

        ' EMPLOYEE SUMMARY
        Dim activeEmployees = employees.Where(Function(x) x.status = CInt(Display_Field.Status.Active)).ToList()
        Dim inactiveEmployees = employees.Where(Function(x) x.status = CInt(Display_Field.Status.Inactive)).ToList()

        summary.TotalEmployees = employees.Count
        summary.ActiveEmployees = activeEmployees.Count
        summary.InactiveEmployees = inactiveEmployees.Count
        summary.TotalDepartments = departments.Count

        ' DATE RANGE
        Dim day = selectedDate.Date
        Dim weekStart = day.AddDays(-6)
        Dim monthStart = New DateTime(day.Year, day.Month, 1)
        Dim monthEndExclusive = monthStart.AddMonths(1)

        ' ATTENDANCE TODAY
        Dim dayAttendances = attendances.
            Where(Function(x) x.of_date.HasValue AndAlso x.of_date.Value.Date = day).
            ToList()

        summary.OnTimeTodayCount = dayAttendances.
            Where(Function(x) x.office_hours > 0D AndAlso x.late_hours <= 0D).
            Select(Function(x) x.employee_id).
            Distinct().
            Count()

        Dim checkedInIds = New HashSet(Of Integer)(dayAttendances.Select(Function(x) x.employee_id))

        summary.MissingCheckInTodayCount =
            activeEmployees.Where(Function(x) Not checkedInIds.Contains(x.id)).Count()

        ' LATE IN WEEK
        Dim weekLateAttendances = attendances.
            Where(Function(x)
                      If Not x.of_date.HasValue Then Return False
                      Dim d = x.of_date.Value.Date
                      Return d >= weekStart AndAlso d <= day AndAlso x.late_hours > 0D
                  End Function).
            ToList()

        summary.LateInWeekCount = weekLateAttendances.
            Select(Function(x) x.employee_id).
            Distinct().
            Count()

        ' TOP CHECKIN SOM
        summary.TopOnTimeInMonth =
            attendances.
            Where(Function(x)
                      If Not x.of_date.HasValue Then Return False
                      Dim d = x.of_date.Value.Date
                      Return d >= monthStart AndAlso
                             d < monthEndExclusive AndAlso
                             x.office_hours > 0D AndAlso
                             x.late_hours <= 0D
                  End Function).
            GroupBy(Function(x) x.employee_id).
            Select(Function(g)
                       Dim emp = GetEmployee(employeeMap, g.Key)

                       Return New DashboardTopItem With {
                           .EmployeeCode = String.Empty,
                           .EmployeeName = emp.name,
                           .MetricValue = g.Count()
                       }

                   End Function).
            OrderByDescending(Function(x) x.MetricValue).
            ThenBy(Function(x) x.EmployeeName).
            Take(10).
            ToList()

        ' TOP CHECKIN MUON
        summary.TopLateInWeek =
            weekLateAttendances.
            GroupBy(Function(x) x.employee_id).
            Select(Function(g)

                       Dim emp = GetEmployee(employeeMap, g.Key)

                       Return New DashboardTopItem With {
                           .EmployeeCode = String.Empty,
                           .EmployeeName = emp.name,
                           .MetricValue = g.Sum(Function(x) x.late_hours)
                       }

                   End Function).
            OrderByDescending(Function(x) x.MetricValue).
            ThenBy(Function(x) x.EmployeeName).
            Take(10).
            ToList()

        Return summary

    End Function

    Private Function LoadEmployees() As List(Of Employee)

        Dim response = _employeeService.Execute(DataIntent.GetList)

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Employee)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Employee))

        If list Is Nothing Then
            Return New List(Of Employee)
        End If

        Return list.ToList()

    End Function

    Private Function LoadAttendances() As List(Of Attendance)

        Dim response = _attendanceService.Execute(DataIntent.GetList)

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Attendance)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Attendance))

        If list Is Nothing Then
            Return New List(Of Attendance)
        End If

        Return list.ToList()

    End Function

    Private Function LoadDepartments() As List(Of Department)

        Dim response = _departmentService.Execute(DataIntent.GetList)

        If response Is Nothing OrElse Not response.IsSuccess Then
            Return New List(Of Department)
        End If

        Dim list = TryCast(response.Data, IEnumerable(Of Department))

        If list Is Nothing Then
            Return New List(Of Department)
        End If

        Return list.ToList()

    End Function

    Private Function GetEmployee(employeeMap As Dictionary(Of Integer, Employee), employeeId As Integer) As Employee

        If employeeMap.ContainsKey(employeeId) Then
            Return employeeMap(employeeId)
        End If

        Return New Employee With {
            .code = "",
            .name = "Khong xac dinh"
        }

    End Function

End Class
