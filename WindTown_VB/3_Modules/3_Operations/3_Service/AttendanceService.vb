Public Class AttendanceService
    Inherits BaseService(Of Attendance)

    ' Constructor: Ép Service sử dụng AttendanceRepository chuyên biệt thay vì GenericRepository
    Public Sub New()
        ' Vì AttendanceRepository kế thừa từ GenericRepository(Of Attendance), 
        ' nên việc gán này là hoàn toàn hợp lệ (Tính đa hình).
        _repo = New AttendanceRepository()
    End Sub

    ''' <summary>
    ''' Ghi đè (Override) lại hàm Execute nếu bạn muốn thêm logic kiểm tra (Validation)
    ''' trước khi gọi các lệnh gốc ở BaseService.
    ''' </summary>
    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        ' 1. Bổ sung logic Kiểm tra (Validation) riêng cho Attendance


        ' 2. Sau khi kiểm tra xong, gọi MyBase.Execute để thực hiện các lệnh gốc.
        ' LƯU Ý: Tại đây, khi MyBase gọi _repo.GetAll(), 
        ' nó sẽ TỰ ĐỘNG gọi hàm GetAll() có JOIN (Snap) mà bạn đã viết ở JobRepository.
        Return MyBase.Execute(intent, data)

    End Function
End Class