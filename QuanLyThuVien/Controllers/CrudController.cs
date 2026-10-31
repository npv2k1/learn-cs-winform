using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Controller chung cho các màn hình danh mục: liệt kê, lưu và xóa.</summary>
/// <typeparam name="T">Kiểu thực thể được quản lý.</typeparam>
/// <param name="repository">Repository của thực thể.</param>
public abstract class CrudController<T>(IRepository<T> repository) where T : EntityBase
{
    /// <summary>Lấy danh sách bản ghi.</summary>
    /// <param name="keyword">Từ khóa tìm kiếm; để trống để lấy tất cả.</param>
    /// <returns>Các bản ghi khớp với từ khóa.</returns>
    public List<T> GetAll(string? keyword = null) => repository.GetAll(keyword);

    /// <summary>Kiểm tra rồi lưu bản ghi: thêm mới nếu <see cref="EntityBase.Id"/> bằng 0, ngược lại thì cập nhật.</summary>
    /// <param name="item">Bản ghi cần lưu.</param>
    /// <exception cref="BusinessException">Dữ liệu không hợp lệ hoặc vi phạm ràng buộc.</exception>
    public void Save(T item)
    {
        Validate(item);

        if (item.Id == 0)
            repository.Add(item);
        else
            repository.Update(item);
    }

    /// <summary>Xóa một bản ghi.</summary>
    /// <param name="item">Bản ghi cần xóa.</param>
    /// <exception cref="BusinessException">Bản ghi đang được dữ liệu khác tham chiếu.</exception>
    public void Delete(T item) => repository.Delete(item.Id);

    /// <summary>Kiểm tra dữ liệu trước khi lưu.</summary>
    /// <param name="item">Bản ghi cần kiểm tra.</param>
    /// <exception cref="BusinessException">Dữ liệu không hợp lệ.</exception>
    protected abstract void Validate(T item);

    /// <summary>Yêu cầu một chuỗi bắt buộc phải có nội dung.</summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <param name="message">Thông báo khi giá trị trống.</param>
    /// <exception cref="BusinessException">Giá trị trống hoặc chỉ gồm khoảng trắng.</exception>
    protected static void Require(string? value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new BusinessException(message);
    }
}
