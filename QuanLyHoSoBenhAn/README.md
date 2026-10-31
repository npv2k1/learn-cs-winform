# Quản lý hồ sơ bệnh án

Database: `MedicalRecordDb`. Script tạo bảng: [init.sql](init.sql).

## Quan hệ

- `Department` 1-n `Doctor`
- `Patient` 1-n `MedicalRecord`
- `Doctor` 1-n `MedicalRecord`
- `MedicalRecord` 1-n `Prescription`
- `Prescription` 1-n `PrescriptionItem`
- `Medicine` 1-n `PrescriptionItem`

Mỗi `MedicalRecord` là một lần khám. Khoa khám được suy ra từ bác sĩ, nên không lưu lại trong hồ sơ.

## Thực thể

Dấu `?` là được phép null. Mỗi class ứng với một bảng tên số nhiều (`Patient` → `Patients`).

### Department — Khoa

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | Duy nhất |
| Location | string? | Vị trí khoa |

### Doctor — Bác sĩ

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| DoctorCode | string | Duy nhất |
| FullName | string | |
| Specialty | string? | Chuyên môn |
| Phone | string? | |
| DepartmentId | int | Khóa ngoại tới `Department` |

### Patient — Bệnh nhân

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| PatientCode | string | Duy nhất |
| FullName | string | |
| DateOfBirth | DateOnly | |
| Gender | Gender | `Male`, `Female`, `Other` |
| IdentityNumber | string? | Số CCCD, duy nhất nếu có |
| HealthInsuranceNumber | string? | Số thẻ BHYT, duy nhất nếu có |
| Phone | string? | |
| Address | string? | |
| BloodType | string? | `A+`, `A-`, `B+`, `B-`, `AB+`, `AB-`, `O+`, `O-` |
| Allergies | string? | Dị ứng |

### MedicalRecord — Hồ sơ bệnh án

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| RecordCode | string | Duy nhất |
| PatientId | int | Khóa ngoại tới `Patient` |
| DoctorId | int | Khóa ngoại tới `Doctor` |
| VisitDate | DateTime | Thời điểm khám |
| Symptoms | string | Triệu chứng |
| Diagnosis | string? | Chẩn đoán |
| TreatmentPlan | string? | Hướng điều trị |
| Notes | string? | |
| Status | MedicalRecordStatus | `Open`, `Closed` |

### Medicine — Thuốc

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Code | string | Duy nhất |
| Name | string | |
| Unit | string | Viên, chai, ống... |
| UnitPrice | decimal | |

### Prescription — Đơn thuốc

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| MedicalRecordId | int | Khóa ngoại tới `MedicalRecord` |
| IssuedDate | DateOnly | Ngày kê đơn |
| Notes | string? | |

### PrescriptionItem — Chi tiết đơn thuốc

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| PrescriptionId | int | Khóa ngoại tới `Prescription` |
| MedicineId | int | Khóa ngoại tới `Medicine`; không trùng trong một đơn |
| Quantity | int | Lớn hơn 0 |
| Dosage | string | Liều dùng |

## Tạo database

Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLyHoSoBenhAn/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
