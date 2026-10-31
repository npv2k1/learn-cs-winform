using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ của danh mục sách.</summary>
/// <param name="books">Repository sách.</param>
/// <param name="categories">Repository thể loại.</param>
/// <param name="publishers">Repository nhà xuất bản.</param>
/// <param name="authors">Repository tác giả.</param>
public class BookController(
    IRepository<Book> books,
    IRepository<Category> categories,
    IRepository<Publisher> publishers,
    IRepository<Author> authors) : CrudController<Book>(books)
{
    /// <summary>Lấy các thể loại để chọn trên form sách.</summary>
    /// <returns>Tất cả thể loại.</returns>
    public List<Category> GetCategories() => categories.GetAll();

    /// <summary>Lấy các nhà xuất bản để chọn trên form sách.</summary>
    /// <returns>Tất cả nhà xuất bản.</returns>
    public List<Publisher> GetPublishers() => publishers.GetAll();

    /// <summary>Lấy các tác giả để chọn trên form sách.</summary>
    /// <returns>Tất cả tác giả.</returns>
    public List<Author> GetAuthors() => authors.GetAll();

    /// <inheritdoc/>
    protected override void Validate(Book item)
    {
        Require(item.Title, "Vui lòng nhập tên sách.");

        if (item.CategoryId == 0)
            throw new BusinessException("Vui lòng chọn thể loại.");

        if (item.TotalCopies < 0)
            throw new BusinessException("Tổng số bản không được âm.");
    }
}
