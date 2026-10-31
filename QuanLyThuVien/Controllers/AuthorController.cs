using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class AuthorController(IRepository<Author> repository) : CrudController<Author>(repository)
{
    protected override void Validate(Author item) => Require(item.FullName, "Vui lòng nhập tên tác giả.");
}
