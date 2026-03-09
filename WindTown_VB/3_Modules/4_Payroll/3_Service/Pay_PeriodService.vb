Public Class Pay_PeriodService
    Inherits BaseService(Of Pay_Period)

    Public Sub New()

        _repo = New Pay_PeriodRepository()
    End Sub

    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)


        Return MyBase.Execute(intent, data)

    End Function
End Class