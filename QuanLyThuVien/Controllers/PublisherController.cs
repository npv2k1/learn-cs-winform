using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class PublisherController(IRepository<Publisher> repository) : CrudController<Publisher>(repository)
{
    protected override void Validate(Publisher item) => Require(item.Name, "Vui lòng nhập tên nhà xuất bản.");
}
