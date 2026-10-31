using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Tổng hợp số liệu từ các bảng sách, độc giả và phiếu mượn bằng SQL thuần.</summary>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public class StatisticsRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IStatisticsRepository
{
    /// <inheritdoc/>
    public LibraryStatistics GetStatistics(DateOnly today) => Query(
        """
        SELECT (SELECT COUNT(*) FROM dbo.Books) AS TotalTitles,
               (SELECT ISNULL(SUM(TotalCopies), 0) FROM dbo.Books) AS TotalCopies,
               (SELECT ISNULL(SUM(TotalCopies - AvailableCopies), 0) FROM dbo.Books) AS CopiesOnLoan,
               (SELECT COUNT(*) FROM dbo.Members WHERE IsActive = 1 AND ExpiryDate >= @Today) AS ActiveMembers,
               (SELECT COUNT(*) FROM dbo.Loans WHERE Status = @Status) AS OpenLoans,
               (SELECT COUNT(*) FROM dbo.Loans WHERE Status = @Status AND DueDate < @Today) AS OverdueLoans
        """,
        MapStatistics,
        Param("@Today", today),
        Param("@Status", LoanStatus.Borrowing.ToString())).Single();

    /// <inheritdoc/>
    public List<OverdueItem> GetOverdueItems(DateOnly today) => Query(
        """
        SELECT l.Id AS LoanId, m.FullName AS MemberName, b.Title AS BookTitle, l.DueDate,
               DATEDIFF(DAY, l.DueDate, @Today) AS DaysLate
        FROM dbo.LoanItems li
        JOIN dbo.Loans l ON l.Id = li.LoanId
        JOIN dbo.Members m ON m.Id = l.MemberId
        JOIN dbo.Books b ON b.Id = li.BookId
        WHERE li.ReturnedDate IS NULL AND l.DueDate < @Today
        ORDER BY l.DueDate, l.Id, b.Title
        """,
        MapOverdueItem,
        Param("@Today", today));

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="LibraryStatistics"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static LibraryStatistics MapStatistics(SqlDataReader reader) => new()
    {
        TotalTitles = reader.ReadInt("TotalTitles"),
        TotalCopies = reader.ReadInt("TotalCopies"),
        CopiesOnLoan = reader.ReadInt("CopiesOnLoan"),
        ActiveMembers = reader.ReadInt("ActiveMembers"),
        OpenLoans = reader.ReadInt("OpenLoans"),
        OverdueLoans = reader.ReadInt("OverdueLoans")
    };

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="OverdueItem"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static OverdueItem MapOverdueItem(SqlDataReader reader) => new()
    {
        LoanId = reader.ReadInt("LoanId"),
        MemberName = reader.ReadString("MemberName"),
        BookTitle = reader.ReadString("BookTitle"),
        DueDate = reader.ReadDate("DueDate"),
        DaysLate = reader.ReadInt("DaysLate")
    };
}
