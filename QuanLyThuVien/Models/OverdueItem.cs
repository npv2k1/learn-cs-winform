namespace QuanLyThuVien.Models;

/// <summary>Một cuốn sách quá hạn chưa trả, chỉ dùng để hiển thị.</summary>
public class OverdueItem
{
    /// <summary>Khóa chính của phiếu mượn.</summary>
    public int LoanId { get; set; }

    /// <summary>Họ tên độc giả.</summary>
    public string MemberName { get; set; } = "";

    /// <summary>Tên sách.</summary>
    public string BookTitle { get; set; } = "";

    /// <summary>Hạn trả.</summary>
    public DateOnly DueDate { get; set; }

    /// <summary>Số ngày đã trễ tính đến hôm nay.</summary>
    public int DaysLate { get; set; }
}
