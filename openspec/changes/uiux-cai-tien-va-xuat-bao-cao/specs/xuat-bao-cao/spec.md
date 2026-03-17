## ADDED Requirements

### Requirement: Xuat bao cao tu du lieu hien thi
He thong SHALL cho phep xuat bao cao tu du lieu dang hien thi tren form.

#### Scenario: Xuat bao cao thanh cong
- **WHEN** nguoi dung bam nut "Xuat bao cao"
- **THEN** he thong tao tep bao cao dua tren bo loc hien tai va thong bao thanh cong

#### Scenario: Khong co du lieu de xuat
- **WHEN** du lieu hien thi dang rong
- **THEN** he thong thong bao khong co du lieu de xuat va khong tao tep

### Requirement: Tich hop nut xuat bao cao tren cac form
He thong SHALL tich hop nut xuat bao cao tren tat ca form UI co du lieu danh sach.

#### Scenario: Nut xuat bao cao xuat hien
- **WHEN** mo cac form UI co bang du lieu
- **THEN** he thong hien thi nut xuat bao cao o khu vuc header cua form
