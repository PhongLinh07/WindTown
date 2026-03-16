## 2026-03-16

- Lỗi runtime tại `frmLogin`: `System.IO.FileLoadException` không tải được `System.Resources.Extensions, Version=4.0.0.0` do mismatch manifest. Đã thêm bindingRedirect về 4.0.1.0 trong `WindTown_VB/App.config`.
## 2026-03-16

- Build thất bại do file `WindTown_VB.exe` bị khóa bởi `Visual Studio 2026 Remote Debugger` và tiến trình `WindTown_VB` khi copy output.
## 2026-03-16

- Lỗi cấu hình chuỗi kết nối: `Keyword not supported: 'trust server certificate'` gây lỗi tải cấu hình hệ thống. Đã chuẩn hóa khóa `TrustServerCertificate` trong `WindTown_VB/App.config`.
## 2026-03-16

- Lỗi `System.InvalidOperationException`: `SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize` vẫn xuất hiện khi thao tác các form có `splitNoiDung`. Đã bổ sung clamp khi resize và khi form hiển thị.
