using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Xử lý nghiệp vụ mượn và trả sách.</summary>
/// <param name="loans">Repository phiếu mượn.</param>
/// <param name="members">Repository độc giả.</param>
/// <param name="books">Repository sách.</param>
public class LoanController(
    ILoanRepository loans,
    IRepository<Member> members,
    IRepository<Book> books)
{
    /// <summary>Số ngày mượn mặc định khi tạo phiếu.</summary>
    public const int DefaultLoanDays = 14;
    /// <summary>Tiền phạt cho mỗi ngày trễ của mỗi cuốn sách, tính bằng đồng.</summary>
    public const decimal FinePerLateDay = 2000;

    /// <summary>Lấy danh sách phiếu mượn.</summary>
    /// <param name="keyword">Từ khóa theo tên hoặc mã thẻ độc giả; để trống để lấy tất cả.</param>
    /// <returns>Các phiếu khớp với từ khóa.</returns>
    public List<Loan> GetLoans(string? keyword = null) => loans.GetAll(keyword);

    /// <summary>Lấy các cuốn sách trong một phiếu.</summary>
    /// <param name="loanId">Khóa chính của phiếu mượn.</param>
    /// <returns>Các dòng chi tiết của phiếu.</returns>
    public List<LoanItem> GetItems(int loanId) => loans.GetItems(loanId);

    /// <summary>Lấy các độc giả để chọn khi tạo phiếu.</summary>
    /// <returns>Tất cả độc giả.</returns>
    public List<Member> GetMembers() => members.GetAll();

    /// <summary>Lấy các đầu sách còn bản để cho mượn.</summary>
    /// <returns>Các sách có <see cref="Book.AvailableCopies"/> lớn hơn 0.</returns>
    public List<Book> GetAvailableBooks() =>
        books.GetAll().Where(book => book.AvailableCopies > 0).ToList();

    /// <summary>Tạo phiếu mượn với ngày mượn là hôm nay.</summary>
    /// <param name="member">Độc giả mượn sách.</param>
    /// <param name="dueDate">Hạn trả.</param>
    /// <param name="bookIds">Khóa chính của các cuốn sách được mượn.</param>
    /// <exception cref="BusinessException">Chưa chọn độc giả hoặc sách, thẻ bị khóa hoặc hết hạn, hạn trả không hợp lệ, hoặc sách đã hết bản.</exception>
    public void Create(Member? member, DateOnly dueDate, IReadOnlyCollection<int> bookIds)
    {
        var today = Today();

        if (member is null)
            throw new BusinessException("Vui lòng chọn độc giả.");

        if (!member.IsActive || member.ExpiryDate < today)
            throw new BusinessException("Thẻ của độc giả đã bị khóa hoặc hết hạn.");

        if (bookIds.Count == 0)
            throw new BusinessException("Vui lòng chọn ít nhất một cuốn sách.");

        if (dueDate < today)
            throw new BusinessException("Hạn trả không được trước ngày mượn.");

        loans.Create(new Loan { MemberId = member.Id, LoanDate = today, DueDate = dueDate }, bookIds);
    }

    /// <summary>Trả một cuốn sách với ngày trả là hôm nay và tính tiền phạt nếu trễ hạn.</summary>
    /// <param name="loan">Phiếu mượn chứa cuốn sách.</param>
    /// <param name="item">Cuốn sách được trả.</param>
    /// <returns>Tiền phạt của cuốn sách vừa trả, bằng 0 nếu trả đúng hạn.</returns>
    /// <exception cref="BusinessException">Cuốn sách đã được trả trước đó.</exception>
    public decimal Return(Loan loan, LoanItem item)
    {
        var today = Today();
        var fineAmount = CalculateFine(loan.DueDate, today);
        loans.ReturnItem(item, today, fineAmount);
        return fineAmount;
    }

    /// <summary>Tính tiền phạt theo số ngày trễ.</summary>
    /// <param name="dueDate">Hạn trả.</param>
    /// <param name="returnedDate">Ngày trả thực tế.</param>
    /// <returns>Tiền phạt, bằng 0 nếu không trễ.</returns>
    private static decimal CalculateFine(DateOnly dueDate, DateOnly returnedDate) =>
        Math.Max(0, returnedDate.DayNumber - dueDate.DayNumber) * FinePerLateDay;

    /// <summary>Lấy ngày hiện tại theo giờ máy.</summary>
    /// <returns>Ngày hôm nay.</returns>
    private static DateOnly Today() => DateOnly.FromDateTime(DateTime.Now);
}
