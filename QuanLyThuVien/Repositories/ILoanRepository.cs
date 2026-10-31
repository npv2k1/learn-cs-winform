using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public interface ILoanRepository
{
    List<Loan> GetAll(string? keyword = null);
    List<LoanItem> GetItems(int loanId);
    void Create(Loan loan, IReadOnlyCollection<int> bookIds);
    void ReturnItem(LoanItem item, DateOnly returnedDate, decimal fineAmount);
}
