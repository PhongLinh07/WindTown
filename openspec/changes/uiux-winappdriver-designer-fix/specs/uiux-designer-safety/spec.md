## ADDED Requirements

### Requirement: Designer MUST initialize components container
Các file `.Designer.vb` có sử dụng `ContextMenuStrip` MUST khởi tạo `components` trước khi tạo control để tránh `ArgumentNullException`.

#### Scenario: ContextMenuStrip được tạo với container hợp lệ
- **WHEN** `InitializeComponent` chạy và tạo `ContextMenuStrip`
- **THEN** `components` đã được khởi tạo và không bị null
