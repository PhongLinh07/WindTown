Public Class Salary_MultService
    Inherits BaseService(Of Salary_Mult)

    Private _repoMult As Salary_MultRepository = New Salary_MultRepository()
    Public Sub New()

        _repo = New Salary_MultRepository()
    End Sub

    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        Try
            Select Case intent
                Case DataIntent.GetSalaryMultItemByJob
                    Dim job As Job = TryCast(data, Job)
                    Dim list = _repoMult.GetSalaryMultItemByJob(data)
                    Return ServiceResponse(Of Object).Success(list)

                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try

    End Function
End Class