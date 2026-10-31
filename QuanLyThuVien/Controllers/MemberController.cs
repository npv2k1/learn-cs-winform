using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class MemberController(IRepository<Member> repository) : CrudController<Member>(repository)
{
    protected override void Validate(Member item)
    {
        Require(item.MemberCode, "Vui lòng nhập mã thẻ.");
        Require(item.FullName, "Vui lòng nhập họ tên.");

        if (item.ExpiryDate < item.JoinedDate)
            throw new BusinessException("Ngày hết hạn phải sau ngày cấp thẻ.");
    }
}
