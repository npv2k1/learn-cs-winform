namespace QuanLyThuVien.Models;

/// <summary>Tác giả sách, ứng với bảng <c>dbo.Authors</c>.</summary>
public class Author : EntityBase
{
    /// <summary>Họ tên tác giả.</summary>
    public string FullName { get; set; } = "";
    /// <summary>Năm sinh, <see langword="null"/> nếu không rõ.</summary>
    public short? BirthYear { get; set; }
    /// <summary>Tiểu sử tóm tắt, có thể để trống.</summary>
    public string? Biography { get; set; }
}
