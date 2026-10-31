using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public class LoanController(
    ILoanRepository loans,
    IRepository<Member> members,
    IRepository<Book> books)
{
    public const int DefaultLoanDays = 14;
    public const decimal FinePerLateDay = 2000;

    public List<Loan> GetLoans(string? keyword = null) => loans.GetAll(keyword);

    public List<LoanItem> GetItems(int loanId) => loans.GetItems(loanId);

    public List<Member> GetMembers() => members.GetAll();

    public List<Book> GetAvailableBooks() =>
        books.GetAll().Where(book => book.AvailableCopies > 0).ToList();

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

    /// <returns>Tiền phạt của cuốn sách vừa trả.</returns>
    public decimal Return(Loan loan, LoanItem item)
    {
        var today = Today();
        var fineAmount = CalculateFine(loan.DueDate, today);
        loans.ReturnItem(item, today, fineAmount);
        return fineAmount;
    }

    private static decimal CalculateFine(DateOnly dueDate, DateOnly returnedDate) =>
        Math.Max(0, returnedDate.DayNumber - dueDate.DayNumber) * FinePerLateDay;

    private static DateOnly Today() => DateOnly.FromDateTime(DateTime.Now);
}
