using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ của danh mục thể loại.</summary>
/// <param name="repository">Repository thể loại.</param>
public class CategoryController(IRepository<Category> repository) : CrudController<Category>(repository)
{
    /// <inheritdoc/>
    protected override void Validate(Category item) => Require(item.Name, "Vui lòng nhập tên thể loại.");
}
