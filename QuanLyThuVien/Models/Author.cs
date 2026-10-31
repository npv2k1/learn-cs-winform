namespace QuanLyThuVien.Models;

public class Author : EntityBase
{
    public string FullName { get; set; } = "";
    public short? BirthYear { get; set; }
    public string? Biography { get; set; }
}
