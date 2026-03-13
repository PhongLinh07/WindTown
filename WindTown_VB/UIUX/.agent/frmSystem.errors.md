## Lỗi
- 2026-03-13: Build thất bại do file bị khóa.
  - Thông báo: `BC2012: can't open '...\\obj\\Debug\\WindTown_VB.exe' for writing (file đang bị process khác giữ).`
  - Repro:
    - Chạy: `msbuild WindTown_VB/WindTown_VB.vbproj /p:Configuration=Debug /nologo`
  - Ghi chú: Process giữ file là `vgc` (ID 19800), không thể dừng do thiếu quyền.
