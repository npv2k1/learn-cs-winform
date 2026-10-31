namespace QuanLyThuVien.Models;

public class Member : EntityBase
{
    public string MemberCode { get; set; } = "";
    public string FullName { get; set; } = "";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateOnly JoinedDate { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
}
