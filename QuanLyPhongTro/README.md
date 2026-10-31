# Quản lý phòng trọ

Database: `RoomRentalDb`. Script tạo bảng: [init.sql](init.sql).

## Quan hệ

- `Room` 1-n `Contract`; mỗi phòng có tối đa một hợp đồng `Active`
- `Contract` n-n `Tenant`, qua `ContractTenant`; mỗi hợp đồng có tối đa một người đại diện
- `Room` 1-n `MeterReading`
- `Service` 1-n `MeterReading`
- `Contract` 1-n `Invoice`; mỗi tháng có một hóa đơn
- `Invoice` 1-n `InvoiceItem`
- `Service` 1-n `InvoiceItem`
- `Invoice` 1-n `Payment`

## Thực thể

Dấu `?` là được phép null. Mỗi class ứng với một bảng tên số nhiều (`Room` → `Rooms`).

### Room — Phòng

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| RoomNumber | string | Số phòng, duy nhất |
| Floor | int | Tầng |
| Area | decimal | Diện tích (m²) |
| MonthlyRent | decimal | Giá thuê niêm yết |
| MaxOccupants | int | Số người ở tối đa |
| Status | RoomStatus | `Available`, `Occupied`, `Maintenance` |

### Tenant — Người thuê

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| FullName | string | |
| IdentityNumber | string | Số CCCD, duy nhất |
| DateOfBirth | DateOnly? | |
| Phone | string | |
| Address | string? | Địa chỉ thường trú |

### Contract — Hợp đồng thuê

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| RoomId | int | Khóa ngoại tới `Room` |
| StartDate | DateOnly | |
| EndDate | DateOnly? | Null là chưa xác định ngày kết thúc |
| MonthlyRent | decimal | Giá chốt theo hợp đồng |
| Deposit | decimal | Tiền cọc |
| Status | ContractStatus | `Active`, `Ended` |

### ContractTenant — Người ở theo hợp đồng

| Property | Type | Ghi chú |
|---|---|---|
| ContractId | int | Khóa chính, khóa ngoại tới `Contract` |
| TenantId | int | Khóa chính, khóa ngoại tới `Tenant` |
| IsRepresentative | bool | Người đứng tên hợp đồng |
| MoveInDate | DateOnly | |
| MoveOutDate | DateOnly? | |

### Service — Dịch vụ

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | Điện, nước, internet... Duy nhất |
| Unit | string | kWh, m³, tháng... |
| UnitPrice | decimal | Đơn giá hiện tại |
| IsMetered | bool | Có tính theo chỉ số đồng hồ không |

### MeterReading — Chỉ số điện, nước

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| RoomId | int | Khóa ngoại tới `Room` |
| ServiceId | int | Khóa ngoại tới `Service` |
| BillingMonth | DateOnly | Ngày 1 của tháng; không trùng theo phòng và dịch vụ |
| PreviousReading | decimal | Chỉ số đầu kỳ |
| CurrentReading | decimal | Chỉ số cuối kỳ |

### Invoice — Hóa đơn tháng

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| ContractId | int | Khóa ngoại tới `Contract` |
| BillingMonth | DateOnly | Ngày 1 của tháng; không trùng theo hợp đồng |
| IssueDate | DateOnly | Ngày lập |
| DueDate | DateOnly | Hạn thanh toán |
| TotalAmount | decimal | Tổng tiền |
| Status | InvoiceStatus | `Unpaid`, `PartiallyPaid`, `Paid` |

### InvoiceItem — Dòng hóa đơn

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| InvoiceId | int | Khóa ngoại tới `Invoice` |
| ServiceId | int? | Null với dòng tiền phòng |
| Description | string | |
| Quantity | decimal | |
| UnitPrice | decimal | Đơn giá tại thời điểm lập hóa đơn |
| Amount | decimal | Cột tính sẵn: `Quantity * UnitPrice` |

### Payment — Lần thanh toán

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| InvoiceId | int | Khóa ngoại tới `Invoice` |
| PaymentDate | DateOnly | |
| Amount | decimal | Lớn hơn 0 |
| Method | PaymentMethod | `Cash`, `BankTransfer` |
| Note | string? | |

## Tạo database

Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLyPhongTro/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
