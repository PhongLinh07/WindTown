Public Class PayrollService
    Inherits BaseService(Of Payroll)

    Public Sub New()

        _repo = New PayrollRepository()
    End Sub

    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)


        Return MyBase.Execute(intent, data)

    End Function
End Class