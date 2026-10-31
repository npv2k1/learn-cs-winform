namespace QuanLyThuVien.Models;

/// <summary>Phiếu mượn sách, ứng với bảng <c>dbo.Loans</c>.</summary>
/// <remarks>
/// Trạng thái quá hạn không được lưu mà suy ra từ <see cref="DueDate"/>.
/// </remarks>
public class Loan : EntityBase
{
    /// <summary>Khóa ngoại tới <see cref="Member"/>.</summary>
    public int MemberId { get; set; }
    /// <summary>Ngày mượn.</summary>
    public DateOnly LoanDate { get; set; }
    /// <summary>Hạn trả, không được trước <see cref="LoanDate"/>.</summary>
    public DateOnly DueDate { get; set; }
    /// <summary>Trạng thái hiện tại của phiếu.</summary>
    public LoanStatus Status { get; set; } = LoanStatus.Borrowing;

    // Trường hiển thị, lấy từ JOIN
    /// <summary>Họ tên độc giả, chỉ dùng để hiển thị.</summary>
    public string MemberName { get; set; } = "";
}
