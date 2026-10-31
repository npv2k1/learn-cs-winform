namespace QuanLyThuVien.Models;

/// <summary>Lỗi nghiệp vụ, thông điệp được hiển thị trực tiếp cho người dùng.</summary>
/// <param name="message">Thông điệp tiếng Việt hiển thị cho người dùng.</param>
/// <param name="innerException">Lỗi gốc nếu có, ví dụ lỗi từ SQL Server.</param>
public class BusinessException(string message, Exception? innerException = null)
    : Exception(message, innerException);
