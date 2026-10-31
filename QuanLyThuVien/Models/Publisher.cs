namespace QuanLyThuVien.Models;

public class Publisher : EntityBase
{
    public string Name { get; set; } = "";
    public string? Address { get; set; }
    public string? Phone { get; set; }
}
