namespace QuanLyThuVien.Models;

/// <summary>Lỗi nghiệp vụ, thông điệp được hiển thị trực tiếp cho người dùng.</summary>
public class BusinessException(string message, Exception? innerException = null)
    : Exception(message, innerException);
