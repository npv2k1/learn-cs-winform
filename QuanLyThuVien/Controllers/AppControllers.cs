namespace QuanLyThuVien.Controllers;

/// <summary>Gom các controller của ứng dụng để truyền cho các form.</summary>
/// <param name="Categories">Controller thể loại.</param>
/// <param name="Authors">Controller tác giả.</param>
/// <param name="Publishers">Controller nhà xuất bản.</param>
/// <param name="Books">Controller sách.</param>
/// <param name="Members">Controller độc giả.</param>
/// <param name="Loans">Controller mượn trả.</param>
/// <param name="Statistics">Controller thống kê.</param>
public record AppControllers(
    CategoryController Categories,
    AuthorController Authors,
    PublisherController Publishers,
    BookController Books,
    MemberController Members,
    LoanController Loans,
    StatisticsController Statistics);
