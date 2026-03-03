Public Class EmployeeService
    Inherits BaseService(Of Employee)

    ' Constructor:  Service sử dụng EmpolyeeRepository chuyên biệt thay vì GenericRepository
    Private _repoEmp As EmployeeRepository = New EmployeeRepository()
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Ghi đè (Override) lại hàm Execute nếu bạn muốn thêm logic kiểm tra (Validation)
    ''' trước khi gọi các lệnh gốc ở BaseService.
    ''' </summary>
    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        ' 1. Bổ sung logic Kiểm tra (Validation) riêng cho Job

        Try
            Select Case intent
                Case DataIntent.GetEmployeesWithoutAccount
                    Dim list = _repoEmp.GetEmployeesWithoutAccount()
                    Return ServiceResponse(Of Object).Success(list)

                Case DataIntent.GetEmployeesWithoutContract
                    Dim list = _repoEmp.GetEmployeesWithoutContract()
                    Return ServiceResponse(Of Object).Success(list)

                Case Else
                    ' 2. Sau khi kiểm tra xong, gọi MyBase.Execute để thực hiện các lệnh gốc.
                    ' LƯU Ý: Tại đây, khi MyBase gọi _repo.GetAll(), 
                    ' nó sẽ TỰ ĐỘNG gọi hàm GetAll() có JOIN (Snap) mà bạn đã viết ở JobRepository.
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try


    End Function
End Class
