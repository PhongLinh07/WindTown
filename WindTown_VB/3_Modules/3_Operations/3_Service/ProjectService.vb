Public Class ProjectService
    Inherits BaseService(Of Project)

    Private _repoProj As ProjectRepository = New ProjectRepository()
    Public Sub New()

    End Sub


    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        ' 1. Bổ sung logic Kiểm tra (Validation) riêng cho Job

        Try
            Select Case intent
                Case DataIntent.GetProjectsIsActive
                    Dim list = _repoProj.GetProjectIsActive()
                    Return ServiceResponse(Of Object).Success(list)

                Case Else

                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try


    End Function
End Class
