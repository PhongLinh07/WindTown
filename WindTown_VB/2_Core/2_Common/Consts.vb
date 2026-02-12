Public Class Consts
    Public Enum Intent
        GetList        ' Lấy danh sách tất cả bản ghi chưa bị xóa | status != -1
        GetById        ' Lấy 1 bản ghi
        Insert         ' Thêm mới
        Update         ' Cập nhật
        SoftDelete     ' Xóa tạm
    End Enum

End Class
