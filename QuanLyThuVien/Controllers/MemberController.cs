using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ của danh mục độc giả.</summary>
/// <param name="repository">Repository độc giả.</param>
public class MemberController(IRepository<Member> repository) : CrudController<Member>(repository)
{
    /// <inheritdoc/>
    protected override void Validate(Member item)
    {
        Require(item.MemberCode, "Vui lòng nhập mã thẻ.");
        Require(item.FullName, "Vui lòng nhập họ tên.");

        if (item.ExpiryDate < item.JoinedDate)
            throw new BusinessException("Ngày hết hạn phải sau ngày cấp thẻ.");
    }
}
