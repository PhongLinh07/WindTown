🔹 Bước 1: Kiểm tra đang ở nhánh nào
git branch

Nếu có dấu * feature/backend là đúng nhánh rồi 👍

🔹 Bước 2: Kéo dữ liệu mới nhất từ remote
git fetch origin
🔹 Bước 3: Merge main vào feature/backend
git merge origin/main

Nếu không có conflict → xong 🎉
Nếu có conflict → sửa file bị xung đột, sau đó:

git add .
git commit




















Cách chuẩn và đơn giản nhất để làm điều này mà không gây lỗi "treo tiến trình" hay rác bộ nhớ là sử dụng tính năng có sẵn trong Project Properties của Visual Studio.

Bạn không cần viết code phức tạp, chỉ cần thay đổi cấu hình khởi chạy như sau:

Bước 1: Cấu hình "Shutdown mode"
Chuột phải vào Project WindTown_VB trong Solution Explorer -> Chọn Properties.

Tại tab Application, hãy tìm mục Shutdown mode.

Chỉnh nó thành: When last form closes (Thay vì mặc định là When startup form closes).

Ý nghĩa: Ứng dụng sẽ chỉ thực sự tắt hẳn khi tất cả các Form đều đã đóng. Điều này cho phép bạn đóng Form chọn mà App vẫn không bị sập.

Bước 2: Viết code chuyển Form (Cực kỳ đơn giản)
Tại Form chọn của bạn (ví dụ có 2 nút bấm), hãy dùng lệnh Close() thay vì Hide().

Đoạn mã
' Tại Form Chọn (Startup Form)
Private Sub btnOpenForm1_Click(sender As Object, e As EventArgs) Handles btnOpenForm1.Click
    Dim f1 As New Form1()
    f1.Show() 
    Me.Close() ' Đóng hẳn Form chọn, giải phóng bộ nhớ ngay lập tức
End Sub

Private Sub btnOpenForm2_Click(sender As Object, e As EventArgs) Handles btnOpenForm2.Click
    Dim f2 As New Form2()
    f2.Show()
    Me.Close() ' Đóng hẳn Form chọn
End Sub
Tại sao đây là cách chuẩn và đơn giản?
Giải quyết triệt để lỗi "File lock": Vì Form chọn đã Close, nó không còn chạy ngầm. Khi bạn đóng nốt Form 1 hoặc Form 2, Windows sẽ thu hồi file .exe ngay lập tức, giúp bạn Build lại (F5) mà không bị báo lỗi "Used by another process".

Đúng bản chất WinForm: Bạn đang tận dụng cơ chế quản lý vòng đời (Lifecycle) của Microsoft thay vì cố gắng "lách" bằng cách ẩn đi.

Code sạch: Không cần tạo thêm Module hay Sub Main phức tạp nếu dự án của Gemi chưa quá lớn.