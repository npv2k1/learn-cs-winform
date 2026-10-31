namespace QuanLyThuVien.Models;

/// <summary>Lớp cơ sở của các thực thể có khóa chính tự tăng.</summary>
public abstract class EntityBase
{
    /// <summary>Khóa chính. Giá trị 0 nghĩa là bản ghi chưa được lưu vào database.</summary>
    public int Id { get; set; }
}
