## ADDED Requirements

### Requirement: Kiem tra bat buoc truoc khi luu
He thong SHALL kiem tra cac truong bat buoc va dinh dang hop le truoc khi goi xu ly luu.

#### Scenario: Thieu truong bat buoc
- **WHEN** nguoi dung bam luu va co truong bat buoc dang trong
- **THEN** he thong thong bao loi va khong thuc hien luu

#### Scenario: Dinh dang khong hop le
- **WHEN** gia tri nhap vao khong dung dinh dang quy dinh
- **THEN** he thong thong bao loi va yeu cau sua truoc khi luu

#### Scenario: Hop le de luu
- **WHEN** tat ca truong bat buoc va dinh dang deu hop le
- **THEN** he thong cho phep thuc hien luu
