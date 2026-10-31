namespace QuanLyThuVien.Models;

public class LoanItem : EntityBase
{
    public int LoanId { get; set; }
    public int BookId { get; set; }
    public DateOnly? ReturnedDate { get; set; }
    public decimal FineAmount { get; set; }

    // Trường hiển thị, lấy từ JOIN
    public string BookTitle { get; set; } = "";
}
