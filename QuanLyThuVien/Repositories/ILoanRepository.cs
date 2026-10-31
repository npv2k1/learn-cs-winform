using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy cập dữ liệu phiếu mượn và các cuốn sách trong phiếu.</summary>
public interface ILoanRepository
{
    /// <summary>Lấy danh sách phiếu mượn, phiếu mới nhất đứng trước.</summary>
    /// <param name="keyword">Từ khóa theo tên hoặc mã thẻ độc giả; để trống để lấy tất cả.</param>
    /// <returns>Các phiếu khớp với từ khóa.</returns>
    List<Loan> GetAll(string? keyword = null);
    /// <summary>Lấy các cuốn sách trong một phiếu.</summary>
    /// <param name="loanId">Khóa chính của phiếu mượn.</param>
    /// <returns>Các dòng chi tiết của phiếu.</returns>
    List<LoanItem> GetItems(int loanId);
    /// <summary>Tạo phiếu mượn và trừ số bản còn lại của từng cuốn trong cùng một transaction.</summary>
    /// <param name="loan">Thông tin phiếu mượn.</param>
    /// <param name="bookIds">Khóa chính của các cuốn sách được mượn.</param>
    /// <exception cref="BusinessException">Có cuốn sách đã hết bản để cho mượn; toàn bộ phiếu bị hủy.</exception>
    void Create(Loan loan, IReadOnlyCollection<int> bookIds);
    /// <summary>Ghi nhận trả một cuốn sách, cộng lại số bản còn lại và đóng phiếu nếu đã trả hết.</summary>
    /// <param name="item">Dòng chi tiết của cuốn sách được trả.</param>
    /// <param name="returnedDate">Ngày trả.</param>
    /// <param name="fineAmount">Tiền phạt của cuốn sách.</param>
    /// <exception cref="BusinessException">Cuốn sách đã được trả trước đó.</exception>
    void ReturnItem(LoanItem item, DateOnly returnedDate, decimal fineAmount);
}
