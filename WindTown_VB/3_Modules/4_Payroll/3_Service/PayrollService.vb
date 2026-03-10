Public Class PayrollService
    Inherits BaseService(Of Payroll)

    Public Sub New()
        _repo = New PayrollRepository()
    End Sub
End Class
