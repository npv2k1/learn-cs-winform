using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ của danh mục tác giả.</summary>
/// <param name="repository">Repository tác giả.</param>
public class AuthorController(IRepository<Author> repository) : CrudController<Author>(repository)
{
    /// <inheritdoc/>
    protected override void Validate(Author item) => Require(item.FullName, "Vui lòng nhập tên tác giả.");
}
