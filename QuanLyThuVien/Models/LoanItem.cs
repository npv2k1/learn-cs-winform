namespace QuanLyThuVien.Models;

/// <summary>Một cuốn sách trong phiếu mượn, ứng với bảng <c>dbo.LoanItems</c>.</summary>
public class LoanItem : EntityBase
{
    /// <summary>Khóa ngoại tới <see cref="Loan"/>.</summary>
    public int LoanId { get; set; }
    /// <summary>Khóa ngoại tới <see cref="Book"/>, không trùng trong cùng một phiếu.</summary>
    public int BookId { get; set; }
    /// <summary>Ngày trả, <see langword="null"/> nếu sách chưa được trả.</summary>
    public DateOnly? ReturnedDate { get; set; }
    /// <summary>Tiền phạt trả trễ, tính bằng đồng.</summary>
    public decimal FineAmount { get; set; }

    // Trường hiển thị, lấy từ JOIN
    /// <summary>Tên sách, chỉ dùng để hiển thị.</summary>
    public string BookTitle { get; set; } = "";
}
