namespace QuanLyThuVien.Models;

/// <summary>Độc giả có thẻ thư viện, ứng với bảng <c>dbo.Members</c>.</summary>
public class Member : EntityBase
{
    /// <summary>Mã thẻ, duy nhất trong database.</summary>
    public string MemberCode { get; set; } = "";
    /// <summary>Họ tên độc giả.</summary>
    public string FullName { get; set; } = "";
    /// <summary>Số điện thoại, có thể để trống.</summary>
    public string? Phone { get; set; }
    /// <summary>Địa chỉ email, có thể để trống.</summary>
    public string? Email { get; set; }
    /// <summary>Địa chỉ liên hệ, có thể để trống.</summary>
    public string? Address { get; set; }
    /// <summary>Ngày cấp thẻ.</summary>
    public DateOnly JoinedDate { get; set; }
    /// <summary>Ngày hết hạn thẻ, không được trước <see cref="JoinedDate"/>.</summary>
    public DateOnly ExpiryDate { get; set; }
    /// <summary>Cho biết thẻ còn hoạt động. Thẻ bị khóa thì không mượn được sách.</summary>
    public bool IsActive { get; set; } = true;
}
