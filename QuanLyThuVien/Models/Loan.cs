namespace QuanLyThuVien.Models;

public class Loan : EntityBase
{
    public int MemberId { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly DueDate { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Borrowing;

    // Trường hiển thị, lấy từ JOIN
    public string MemberName { get; set; } = "";
}
