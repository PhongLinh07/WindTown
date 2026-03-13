## ADDED Requirements

### Requirement: Thong bao thao tac chuan hoa
He thong SHALL hien thi thong bao thanh cong/that bai theo mot mau chung tren cac form UI.

#### Scenario: Thanh cong khi luu
- **WHEN** nguoi dung thuc hien thao tac luu thanh cong
- **THEN** he thong hien thi thong bao thanh cong theo mau chung

#### Scenario: That bai khi luu
- **WHEN** thao tac luu bi loi
- **THEN** he thong hien thi thong bao loi theo mau chung va khong dong form

### Requirement: Trang thai loading
He thong SHALL hien thi trang thai loading va khoa cac nut chinh khi dang xu ly.

#### Scenario: Bat loading khi dang xu ly
- **WHEN** bat dau thao tac xu ly du lieu
- **THEN** he thong hien thi loading va khoa cac nut thao tac chinh

#### Scenario: Tat loading khi hoan tat
- **WHEN** thao tac ket thuc (thanh cong hoac that bai)
- **THEN** he thong tat loading va mo lai cac nut
