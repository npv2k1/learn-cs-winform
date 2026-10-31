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

## Cấu trúc code

Luồng xử lý: View → Controller → Repository → SQL Server.

| Thư mục | Vai trò |
|---|---|
| `Models/` | Class dữ liệu và `BusinessException` |
| `Views/` | Các form, chỉ lo hiển thị và nhận thao tác |
| `Controllers/` | Kiểm tra dữ liệu và quy tắc nghiệp vụ, không phụ thuộc WinForms |
| `Repositories/` | SQL thuần có tham số, thao tác ghi chạy trong transaction |
| `Data/` | Mở kết nối, đọc giá trị từ `SqlDataReader` |

`Program.cs` khởi tạo các lớp và truyền vào nhau. Mỗi form gồm `X.cs` chứa xử lý sự kiện và `X.Designer.cs` do Form Designer quản lý, nên có thể xem và chỉnh giao diện bằng kéo thả trong Visual Studio.

Quy tắc nghiệp vụ:

- Thời hạn mượn mặc định 14 ngày, phạt 2.000 đồng cho mỗi ngày trễ của mỗi cuốn (`LoanController`).
- Thẻ bị khóa hoặc hết hạn thì không tạo được phiếu mượn.
- Mượn sách giảm `AvailableCopies`, trả sách tăng lại. Trả hết sách thì phiếu chuyển sang `Returned`.
- `BookAuthor` không có class riêng: quan hệ nằm trong `Book.AuthorIds`.

## Chạy ứng dụng

Bật SQL Server, rồi chạy trên Windows: `dotnet run --project QuanLyThuVien`. Khi khởi động, app tự chạy [init.sql](init.sql) nên không cần tạo database bằng tay. Nếu không kết nối được, app báo lỗi rồi thoát.

Mặc định app kết nối `127.0.0.1,1433`. Nếu SQL Server ở máy khác, đặt biến môi trường `LIBRARY_DB_CONNECTION`.

## Tạo database bằng tay

Chỉ cần khi muốn tạo database mà không mở app. Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLyThuVien/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
