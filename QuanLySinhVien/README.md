# Quản lý sinh viên

Database: `StudentDb`. Script tạo bảng: [init.sql](init.sql).

## Quan hệ

- `Faculty` 1-n `StudentClass`
- `Faculty` 1-n `Lecturer`
- `Faculty` 1-n `Course`
- `StudentClass` 1-n `Student`
- `Course` 1-n `CourseSection`
- `Lecturer` 1-n `CourseSection`
- `Student` n-n `CourseSection`, qua `Enrollment`

Class hành chính đặt tên `StudentClass` vì `class` là từ khóa của C#.

## Thực thể

Dấu `?` là được phép null. Mỗi class ứng với một bảng tên số nhiều (`Student` → `Students`).

### Faculty — Khoa

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Code | string | Duy nhất |
| Name | string | Duy nhất |

### StudentClass — Lớp hành chính

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Code | string | Duy nhất |
| Name | string | |
| FacultyId | int | Khóa ngoại tới `Faculty` |
| IntakeYear | short | Năm nhập học |

### Student — Sinh viên

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| StudentCode | string | Mã sinh viên, duy nhất |
| FullName | string | |
| DateOfBirth | DateOnly | |
| Gender | Gender | `Male`, `Female`, `Other` |
| Email | string? | |
| Phone | string? | |
| Address | string? | |
| StudentClassId | int | Khóa ngoại tới `StudentClass` |
| Status | StudentStatus | `Studying`, `Suspended`, `Graduated`, `Dropped` |

### Lecturer — Giảng viên

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| LecturerCode | string | Duy nhất |
| FullName | string | |
| Email | string? | |
| Phone | string? | |
| FacultyId | int | Khóa ngoại tới `Faculty` |

### Course — Môn học

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Code | string | Duy nhất |
| Name | string | |
| Credits | byte | Số tín chỉ, lớn hơn 0 |
| FacultyId | int | Khóa ngoại tới `Faculty` |

### CourseSection — Lớp học phần

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Code | string | Duy nhất |
| CourseId | int | Khóa ngoại tới `Course` |
| LecturerId | int? | Null là chưa phân công |
| AcademicYear | string | Dạng `2026-2027` |
| Semester | byte | Từ 1 đến 3 |
| MaxStudents | int | Sĩ số tối đa |

### Enrollment — Đăng ký học phần và điểm

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| StudentId | int | Khóa ngoại tới `Student` |
| CourseSectionId | int | Khóa ngoại tới `CourseSection`; không đăng ký trùng |
| EnrolledDate | DateOnly | |
| ProcessScore | decimal? | Điểm quá trình, từ 0 đến 10 |
| FinalScore | decimal? | Điểm thi, từ 0 đến 10 |

Điểm tổng kết không lưu trong bảng, vì tỉ lệ quá trình và thi chưa được xác định.

## Tạo database

Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLySinhVien/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
