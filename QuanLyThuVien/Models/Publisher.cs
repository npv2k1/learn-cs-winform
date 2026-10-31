namespace QuanLyThuVien.Models;

/// <summary>Nhà xuất bản, ứng với bảng <c>dbo.Publishers</c>.</summary>
public class Publisher : EntityBase
{
    /// <summary>Tên nhà xuất bản, duy nhất trong database.</summary>
    public string Name { get; set; } = "";
    /// <summary>Địa chỉ, có thể để trống.</summary>
    public string? Address { get; set; }
    /// <summary>Số điện thoại, có thể để trống.</summary>
    public string? Phone { get; set; }
}
