namespace QuanLyThuVien.Models;

/// <summary>Thể loại sách, ứng với bảng <c>dbo.Categories</c>.</summary>
public class Category : EntityBase
{
    /// <summary>Tên thể loại, duy nhất trong database.</summary>
    public string Name { get; set; } = "";
    /// <summary>Mô tả thể loại, có thể để trống.</summary>
    public string? Description { get; set; }
}
