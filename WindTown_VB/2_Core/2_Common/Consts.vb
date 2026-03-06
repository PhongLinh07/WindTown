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
    GetContractWithoutPosition  ' Những Hợp đồng Active đang ko có vị trí nào Active 
#End Region


End Enum

Public Class Display_Field
    Public Enum Status
        Active = 1
        Inactive = 0
        Deleted = -1
    End Enum
End Class