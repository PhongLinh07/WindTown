Public Enum DataIntent
    GetList        ' Lấy danh sách tất cả bản ghi chưa bị xóa | status != -1
    GetById        ' Lấy 1 bản ghi
    Insert         ' Thêm mới
    Update         ' Cập nhật
    'SoftDelete     ' Xóa tạm
    SoftDeleteMany ' Xóa tạm nhiều bản ghi

#Region "'Employee Custom Intent"
    GetEmployeesWithoutContract ' Những nhân viên đang ko có hợp đồng nào Active
    GetEmployeesWithoutAccount  ' Những nhân viên đang ko có tài khoản nào Active
    GetContractsWithoutPosition  ' Những Hợp đồng Active đang ko có vị trí nào Active 
#End Region

#Region "'Position Custom Intent"
    GetProjectsIsActive ' Những dự án đang trong tiến trình hoạt động | status != (-1.delete, 0.jected,3.complete )
    GetPositionsWithoutAssignment ' Những Position đang ko có Phân công nào Active
#End Region

#Region "'Account Custom Intent"
    Login
    GetAccountByUsername 'lấy thông tin tài khoản bằng user
#End Region

#Region "'Pay_Item Custom Intent"
    GetPayItemByPayroll 'lấy các khoản tiền theo payroll
#End Region

#Region "'Pay_Period Custom Intent"
    StandardHoursCalculator 'Tính số giờ hành chính của chu kỳ
#End Region
#Region "'Pay_Period Custom Intent"
    Init_Payrolls 'Khởi tạo các bảng lương theo hợp đòng đang hạot động
#End Region

#Region "'Salary_Mult Custom Intent"
    GetSalaryMultItemByJob 'lấy dải hệ số theo công việc
#End Region


End Enum

Public Class Display_Field
    Public Enum Status
        Active = 1
        Inactive = 0
        Deleted = -1
    End Enum
End Class