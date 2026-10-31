# Quản lý cửa hàng

Database: `StoreDb`. Script tạo bảng: [init.sql](init.sql).

## Quan hệ

- `Category` 1-n `Product`
- `Supplier` 1-n `Product`
- `Customer` 1-n `Order`; khách vãng lai để `CustomerId` null
- `Employee` 1-n `Order`
- `Order` 1-n `OrderItem`
- `Product` 1-n `OrderItem`
- `Supplier` 1-n `PurchaseReceipt`
- `Employee` 1-n `PurchaseReceipt`
- `PurchaseReceipt` 1-n `PurchaseReceiptItem`
- `Product` 1-n `PurchaseReceiptItem`

## Thực thể

Dấu `?` là được phép null. Mỗi class ứng với một bảng tên số nhiều (`Product` → `Products`).

### Category — Danh mục

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | Duy nhất |
| Description | string? | |

### Supplier — Nhà cung cấp

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Name | string | |
| Phone | string? | |
| Email | string? | |
| Address | string? | |

### Product — Sản phẩm

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| Sku | string | Mã hàng, duy nhất |
| Name | string | |
| CategoryId | int | Khóa ngoại tới `Category` |
| SupplierId | int? | Nhà cung cấp chính |
| Unit | string | Cái, hộp, kg... |
| PurchasePrice | decimal | Giá nhập gần nhất |
| SalePrice | decimal | Giá bán |
| StockQuantity | int | Tồn kho, không âm |
| IsActive | bool | Còn kinh doanh |

### Customer — Khách hàng

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| FullName | string | |
| Phone | string? | Duy nhất nếu có |
| Email | string? | |
| Address | string? | |

### Employee — Nhân viên

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| EmployeeCode | string | Duy nhất |
| FullName | string | |
| Phone | string? | |
| Position | string? | Chức vụ |
| HireDate | DateOnly | |
| IsActive | bool | |

### Order — Đơn bán hàng

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| OrderCode | string | Duy nhất |
| CustomerId | int? | Khóa ngoại tới `Customer` |
| EmployeeId | int | Khóa ngoại tới `Employee` |
| OrderDate | DateTime | |
| DiscountAmount | decimal | Mặc định 0 |
| TotalAmount | decimal | Tổng tiền sau giảm giá |
| PaymentMethod | PaymentMethod | `Cash`, `BankTransfer`, `Card` |
| Status | OrderStatus | `Pending`, `Completed`, `Cancelled` |

### OrderItem — Chi tiết đơn bán

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| OrderId | int | Khóa ngoại tới `Order` |
| ProductId | int | Khóa ngoại tới `Product`; không trùng trong một đơn |
| Quantity | int | Lớn hơn 0 |
| UnitPrice | decimal | Giá bán tại thời điểm tạo đơn |
| Amount | decimal | Cột tính sẵn: `Quantity * UnitPrice` |

### PurchaseReceipt — Phiếu nhập hàng

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| ReceiptCode | string | Duy nhất |
| SupplierId | int | Khóa ngoại tới `Supplier` |
| EmployeeId | int | Khóa ngoại tới `Employee` |
| ReceivedDate | DateOnly | |
| TotalAmount | decimal | |
| Note | string? | |

### PurchaseReceiptItem — Chi tiết phiếu nhập

| Property | Type | Ghi chú |
|---|---|---|
| Id | int | Khóa chính |
| PurchaseReceiptId | int | Khóa ngoại tới `PurchaseReceipt` |
| ProductId | int | Khóa ngoại tới `Product`; không trùng trong một phiếu |
| Quantity | int | Lớn hơn 0 |
| UnitCost | decimal | Giá nhập của lô này |
| Amount | decimal | Cột tính sẵn: `Quantity * UnitCost` |

## Tạo database

Chạy ở thư mục gốc của repo, khi container `sqlserver` đang chạy:

```bash
docker exec -i sqlserver bash -c '/opt/mssql-tools18/bin/sqlcmd -C -b -S localhost -U sa -P "$MSSQL_SA_PASSWORD"' < QuanLyCuaHang/init.sql
```

Script chạy lại nhiều lần được: database và bảng đã tồn tại thì bỏ qua.
