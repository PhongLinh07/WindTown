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