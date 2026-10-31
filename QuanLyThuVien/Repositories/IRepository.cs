using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Các thao tác đọc và ghi cơ bản của một thực thể.</summary>
/// <typeparam name="T">Kiểu thực thể.</typeparam>
public interface IRepository<T> where T : EntityBase
{
    /// <summary>Lấy danh sách bản ghi, có thể lọc theo từ khóa.</summary>
    /// <param name="keyword">Từ khóa tìm kiếm; để trống để lấy tất cả.</param>
    /// <returns>Các bản ghi khớp với từ khóa.</returns>
    List<T> GetAll(string? keyword = null);
    /// <summary>Thêm một bản ghi mới.</summary>
    /// <param name="item">Bản ghi cần thêm.</param>
    /// <exception cref="BusinessException">Dữ liệu bị trùng hoặc vi phạm ràng buộc.</exception>
    void Add(T item);
    /// <summary>Cập nhật bản ghi theo <see cref="EntityBase.Id"/>.</summary>
    /// <param name="item">Bản ghi chứa dữ liệu mới.</param>
    /// <exception cref="BusinessException">Dữ liệu bị trùng hoặc vi phạm ràng buộc.</exception>
    void Update(T item);
    /// <summary>Xóa một bản ghi.</summary>
    /// <param name="id">Khóa chính của bản ghi cần xóa.</param>
    /// <exception cref="BusinessException">Bản ghi đang được dữ liệu khác tham chiếu.</exception>
    void Delete(int id);
}
