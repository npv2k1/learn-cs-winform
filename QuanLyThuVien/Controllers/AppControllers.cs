namespace QuanLyThuVien.Controllers;

public record AppControllers(
    CategoryController Categories,
    AuthorController Authors,
    PublisherController Publishers,
    BookController Books,
    MemberController Members,
    LoanController Loans);
