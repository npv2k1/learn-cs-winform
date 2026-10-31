namespace QuanLyThuVien.Models;

/// <summary>Trạng thái của phiếu mượn. Tên giá trị được lưu nguyên văn vào cột <c>Status</c>.</summary>
public enum LoanStatus
{
    /// <summary>Phiếu còn ít nhất một cuốn chưa trả.</summary>
    Borrowing,
    /// <summary>Toàn bộ sách trong phiếu đã được trả.</summary>
    Returned
}
