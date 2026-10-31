using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ của danh mục nhà xuất bản.</summary>
/// <param name="repository">Repository nhà xuất bản.</param>
public class PublisherController(IRepository<Publisher> repository) : CrudController<Publisher>(repository)
{
    /// <inheritdoc/>
    protected override void Validate(Publisher item) => Require(item.Name, "Vui lòng nhập tên nhà xuất bản.");
}
