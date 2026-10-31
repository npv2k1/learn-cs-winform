using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class CategoryController(IRepository<Category> repository) : CrudController<Category>(repository)
{
    protected override void Validate(Category item) => Require(item.Name, "Vui lòng nhập tên thể loại.");
}
