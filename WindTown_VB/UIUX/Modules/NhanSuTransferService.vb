Public Class NhanSuTransferRequest
    Public Property SelectedEmployees As List(Of Employee)
    Public Property Positions As List(Of Position)
    Public Property Jobs As List(Of Job)
    Public Property UseJob As Boolean
    Public Property TargetJob As Job
    Public Property TargetDepartmentId As Integer
    Public Property PreferNullJob As Boolean
End Class

Public Class NhanSuTransferResult
    Public Property UpdatedCount As Integer
    Public Property FailCount As Integer
End Class

Public Class NhanSuTransferService
    Private ReadOnly _positionService = AppServices.Instance.PositionSV

    Public Sub New()
    End Sub

    Public Function ExecuteTransfer(request As NhanSuTransferRequest) As NhanSuTransferResult
        Dim result As New NhanSuTransferResult()
        If request Is Nothing OrElse request.SelectedEmployees Is Nothing OrElse request.SelectedEmployees.Count = 0 Then
            Return result
        End If

        For Each emp In request.SelectedEmployees
            Dim activePosition = request.Positions.
                Where(Function(p) p IsNot Nothing AndAlso
                                  p.Contract IsNot Nothing AndAlso
                                  p.Contract.Employee IsNot Nothing AndAlso
                                  p.Contract.Employee.id = emp.id).
                OrderByDescending(Function(p) If(p.status = 1, 1, 0)).
                ThenByDescending(Function(p) p.start_date).
                FirstOrDefault()

            If activePosition Is Nothing Then
                result.FailCount += 1
                Continue For
            End If

            If request.UseJob Then
                activePosition.Salary_Mult.Job = request.TargetJob
                Dim response = _positionService.Execute(DataIntent.Update, activePosition)
                If response Is Nothing OrElse Not response.IsSuccess Then
                    result.FailCount += 1
                Else
                    result.UpdatedCount += 1
                End If
            Else
                Dim handled As Boolean = False

                If request.PreferNullJob Then
                    activePosition.Salary_Mult.Job = Nothing
                    Dim nullResponse = _positionService.Execute(DataIntent.Update, activePosition)
                    If nullResponse IsNot Nothing AndAlso nullResponse.IsSuccess Then
                        result.UpdatedCount += 1
                        handled = True
                    End If
                End If

                If Not handled Then
                    Dim fallbackJob = GetFirstJobInDepartment(request.Jobs, request.TargetDepartmentId)
                    If fallbackJob Is Nothing Then
                        result.FailCount += 1
                        Continue For
                    End If

                    activePosition.Salary_Mult.Job = fallbackJob
                    Dim fallbackResponse = _positionService.Execute(DataIntent.Update, activePosition)
                    If fallbackResponse Is Nothing OrElse Not fallbackResponse.IsSuccess Then
                        result.FailCount += 1
                    Else
                        result.UpdatedCount += 1
                    End If
                End If
            End If
        Next

        Return result
    End Function

    Private Function GetFirstJobInDepartment(allJobs As List(Of Job), departmentId As Integer) As Job
        Return allJobs.
            Where(Function(j) j IsNot Nothing AndAlso
                              j.Department IsNot Nothing AndAlso
                              j.Department.id = departmentId AndAlso
                              j.status <> -1).
            OrderBy(Function(j) j.code).
            FirstOrDefault()
    End Function
End Class
