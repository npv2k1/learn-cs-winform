# Quản lý sách, thư viện

Database: `LibraryDb`. Script tạo bảng: [init.sql](init.sql).

## Quan hệ

- `Category` 1-n `Book`
- `Publisher` 1-n `Book`
- `Book` n-n `Author`, qua `BookAuthor`
- `Member` 1-n `Loan`
- `Loan` 1-n `LoanItem`
- `Book` 1-n `LoanItem`

## Thực thể

Dấu `?` là được phép null. Mỗi class ứng với một bảng tên số nhiều (`Book` → `Books`).

### Category — Thể loại

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | Duy nhất |
| Description | string? | |

### Author — Tác giả

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| FullName | string | |
| BirthYear | short? | |
| Biography | string? | |

### Publisher — Nhà xuất bản

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | Duy nhất |
| Address | string? | |
| Phone | string? | |

### Book — Đầu sách

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Isbn | string? | Duy nhất nếu có |
| Title | string | |
| CategoryId | int | Khóa ngoại tới `Category` |
| PublisherId | int? | Khóa ngoại tới `Publisher` |
| PublishedYear | short? | |
| TotalCopies | int | Tổng số bản |
| AvailableCopies | int | Số bản còn trong kho, từ 0 đến `TotalCopies` |

### BookAuthor — Sách và tác giả

| Property | Type | Ghi chú |
|---|---|---|
| BookId | int | Khóa chính, khóa ngoại tới `Book` |
| AuthorId | int | Khóa chính, khóa ngoại tới `Author` |

### Member — Độc giả

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| MemberCode | string | Mã thẻ, duy nhất |
| FullName | string | |
| Phone | string? | |
| Email | string? | |
| Address | string? | |
| JoinedDate | DateOnly | Ngày cấp thẻ |
| ExpiryDate | DateOnly | Ngày hết hạn thẻ |
| IsActive | bool | |

### Loan — Phiếu mượn

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| MemberId | int | Khóa ngoại tới `Member` |
| LoanDate | DateOnly | Ngày mượn |
| DueDate | DateOnly | Hạn trả |
| Status | LoanStatus | `Borrowing`, `Returned` |

Quá hạn được suy ra từ `DueDate`, không lưu thành trạng thái riêng.

### LoanItem — Chi tiết phiếu mượn

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| LoanId | int | Khóa ngoại tới `Loan` |
| BookId | int | Khóa ngoại tới `Book`, không trùng trong một phiếu |
| ReturnedDate | DateOnly? | Null là chưa trả |
| FineAmount | decimal | Tiền phạt, mặc định 0 |

## Tạo database

Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLyThuVien/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
