using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy cập các bảng <c>dbo.Loans</c> và <c>dbo.LoanItems</c>, đồng thời giữ <see cref="Book.AvailableCopies"/> khớp với việc mượn trả.</summary>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public class LoanRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), ILoanRepository
{
    /// <inheritdoc/>
    public List<Loan> GetAll(string? keyword = null) => Query(
        """
        SELECT l.Id, l.MemberId, l.LoanDate, l.DueDate, l.Status, m.FullName AS MemberName
        FROM dbo.Loans l
        JOIN dbo.Members m ON m.Id = l.MemberId
        WHERE @Keyword IS NULL OR m.FullName LIKE @Keyword OR m.MemberCode LIKE @Keyword
        ORDER BY l.LoanDate DESC, l.Id DESC
        """,
        MapLoan,
        KeywordParam(keyword));

    /// <inheritdoc/>
    public List<LoanItem> GetItems(int loanId) => Query(
        """
        SELECT li.Id, li.LoanId, li.BookId, li.ReturnedDate, li.FineAmount, b.Title AS BookTitle
        FROM dbo.LoanItems li
        JOIN dbo.Books b ON b.Id = li.BookId
        WHERE li.LoanId = @LoanId
        ORDER BY b.Title
        """,
        MapItem,
        Param("@LoanId", loanId));

    /// <inheritdoc/>
    public void Create(Loan loan, IReadOnlyCollection<int> bookIds) => InTransaction(transaction =>
    {
        var loanId = InsertAndGetId(
            transaction,
            """
            INSERT INTO dbo.Loans (MemberId, LoanDate, DueDate, Status)
            OUTPUT INSERTED.Id
            VALUES (@MemberId, @LoanDate, @DueDate, @Status)
            """,
            Param("@MemberId", loan.MemberId),
            Param("@LoanDate", loan.LoanDate),
            Param("@DueDate", loan.DueDate),
            Param("@Status", loan.Status.ToString()));

        foreach (var bookId in bookIds)
        {
            var updatedRows = Execute(
                transaction,
                "UPDATE dbo.Books SET AvailableCopies = AvailableCopies - 1 WHERE Id = @BookId AND AvailableCopies > 0",
                Param("@BookId", bookId));

            if (updatedRows == 0)
                throw new BusinessException("Có sách đã hết bản để cho mượn.");

            Execute(
                transaction,
                "INSERT INTO dbo.LoanItems (LoanId, BookId) VALUES (@LoanId, @BookId)",
                Param("@LoanId", loanId),
                Param("@BookId", bookId));
        }
    });

    /// <inheritdoc/>
    public void ReturnItem(LoanItem item, DateOnly returnedDate, decimal fineAmount) => InTransaction(transaction =>
    {
        var updatedRows = Execute(
            transaction,
            """
            UPDATE dbo.LoanItems
            SET ReturnedDate = @ReturnedDate, FineAmount = @FineAmount
            WHERE Id = @Id AND ReturnedDate IS NULL
            """,
            Param("@Id", item.Id),
            Param("@ReturnedDate", returnedDate),
            Param("@FineAmount", fineAmount));

        if (updatedRows == 0)
            throw new BusinessException("Sách này đã được trả.");

        Execute(
            transaction,
            "UPDATE dbo.Books SET AvailableCopies = AvailableCopies + 1 WHERE Id = @BookId",
            Param("@BookId", item.BookId));

        Execute(
            transaction,
            """
            UPDATE dbo.Loans
            SET Status = @Status
            WHERE Id = @LoanId
              AND NOT EXISTS (SELECT 1 FROM dbo.LoanItems WHERE LoanId = @LoanId AND ReturnedDate IS NULL)
            """,
            Param("@LoanId", item.LoanId),
            Param("@Status", LoanStatus.Returned.ToString()));
    });

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="Loan"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static Loan MapLoan(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        MemberId = reader.ReadInt("MemberId"),
        LoanDate = reader.ReadDate("LoanDate"),
        DueDate = reader.ReadDate("DueDate"),
        Status = Enum.Parse<LoanStatus>(reader.ReadString("Status")),
        MemberName = reader.ReadString("MemberName")
    };

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="LoanItem"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static LoanItem MapItem(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        LoanId = reader.ReadInt("LoanId"),
        BookId = reader.ReadInt("BookId"),
        ReturnedDate = reader.ReadNullableDate("ReturnedDate"),
        FineAmount = reader.ReadDecimal("FineAmount"),
        BookTitle = reader.ReadString("BookTitle")
    };
}
