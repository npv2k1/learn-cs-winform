namespace QuanLyThuVien.Models;

/// <summary>Đầu sách, ứng với bảng <c>dbo.Books</c>.</summary>
/// <remarks>
/// Một đầu sách có nhiều bản. Quan hệ nhiều-nhiều với tác giả lưu ở bảng
/// <c>dbo.BookAuthors</c> và được thể hiện qua <see cref="AuthorIds"/>.
/// </remarks>
public class Book : EntityBase
{
    /// <summary>Mã ISBN, duy nhất nếu có giá trị.</summary>
    public string? Isbn { get; set; }
    /// <summary>Tên sách.</summary>
    public string Title { get; set; } = "";
    /// <summary>Khóa ngoại tới <see cref="Category"/>.</summary>
    public int CategoryId { get; set; }
    /// <summary>Khóa ngoại tới <see cref="Publisher"/>, <see langword="null"/> nếu không có nhà xuất bản.</summary>
    public int? PublisherId { get; set; }
    /// <summary>Năm xuất bản, <see langword="null"/> nếu không rõ.</summary>
    public short? PublishedYear { get; set; }
    /// <summary>Tổng số bản thư viện sở hữu.</summary>
    public int TotalCopies { get; set; }
    /// <summary>Số bản còn trong kho, nằm trong khoảng từ 0 đến <see cref="TotalCopies"/>.</summary>
    public int AvailableCopies { get; set; }
    /// <summary>Danh sách khóa chính của các tác giả viết sách này.</summary>
    public List<int> AuthorIds { get; set; } = [];

    // Các trường hiển thị, lấy từ JOIN
    /// <summary>Tên thể loại, chỉ dùng để hiển thị.</summary>
    public string CategoryName { get; set; } = "";
    /// <summary>Tên nhà xuất bản, chỉ dùng để hiển thị.</summary>
    public string? PublisherName { get; set; }
    /// <summary>Tên các tác giả nối bằng dấu phẩy, chỉ dùng để hiển thị.</summary>
    public string? AuthorNames { get; set; }
}
