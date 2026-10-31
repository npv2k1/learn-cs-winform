namespace QuanLyThuVien.Models;

public class Book : EntityBase
{
    public string? Isbn { get; set; }
    public string Title { get; set; } = "";
    public int CategoryId { get; set; }
    public int? PublisherId { get; set; }
    public short? PublishedYear { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public List<int> AuthorIds { get; set; } = [];

    // Các trường hiển thị, lấy từ JOIN
    public string CategoryName { get; set; } = "";
    public string? PublisherName { get; set; }
    public string? AuthorNames { get; set; }
}
