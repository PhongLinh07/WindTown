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



git fetch origin
git merge origin/main















work flow salary


tạo kỳ lương -> tính tổng giờ công chuẩn của chu kỳ -> khởi tạo tất cả các bảng lương thuộc chu kỳ -> tổng hoựp dữ liệu về bảng lương -> (Điều chỉnh) ->tính toán lương thực nhận