using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class BookController(
    IRepository<Book> books,
    IRepository<Category> categories,
    IRepository<Publisher> publishers,
    IRepository<Author> authors) : CrudController<Book>(books)
{
    public List<Category> GetCategories() => categories.GetAll();

    public List<Publisher> GetPublishers() => publishers.GetAll();

    public List<Author> GetAuthors() => authors.GetAll();

    protected override void Validate(Book item)
    {
        Require(item.Title, "Vui lòng nhập tên sách.");

        if (item.CategoryId == 0)
            throw new BusinessException("Vui lòng chọn thể loại.");

        if (item.TotalCopies < 0)
            throw new BusinessException("Tổng số bản không được âm.");
    }
}
