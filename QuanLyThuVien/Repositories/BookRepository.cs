using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy cập bảng <c>dbo.Books</c> và quan hệ tác giả trong <c>dbo.BookAuthors</c>.</summary>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public class BookRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Book>
{
    /// <inheritdoc/>
    public List<Book> GetAll(string? keyword = null) => Query(
        """
        SELECT b.Id, b.Isbn, b.Title, b.CategoryId, b.PublisherId, b.PublishedYear,
               b.TotalCopies, b.AvailableCopies,
               c.Name AS CategoryName,
               p.Name AS PublisherName,
               (SELECT STRING_AGG(a.FullName, ', ')
                FROM dbo.BookAuthors ba
                JOIN dbo.Authors a ON a.Id = ba.AuthorId
                WHERE ba.BookId = b.Id) AS AuthorNames,
               (SELECT STRING_AGG(CAST(ba.AuthorId AS VARCHAR(11)), ',')
                FROM dbo.BookAuthors ba
                WHERE ba.BookId = b.Id) AS AuthorIds
        FROM dbo.Books b
        JOIN dbo.Categories c ON c.Id = b.CategoryId
        LEFT JOIN dbo.Publishers p ON p.Id = b.PublisherId
        WHERE @Keyword IS NULL OR b.Title LIKE @Keyword OR b.Isbn LIKE @Keyword
        ORDER BY b.Title
        """,
        Map,
        KeywordParam(keyword));

    /// <summary>Thêm sách cùng danh sách tác giả. Số bản còn lại ban đầu bằng tổng số bản.</summary>
    /// <param name="item">Sách cần thêm.</param>
    /// <exception cref="BusinessException">Dữ liệu bị trùng hoặc vi phạm ràng buộc.</exception>
    public void Add(Book item) => InTransaction(transaction =>
    {
        var bookId = InsertAndGetId(
            transaction,
            """
            INSERT INTO dbo.Books (Isbn, Title, CategoryId, PublisherId, PublishedYear, TotalCopies, AvailableCopies)
            OUTPUT INSERTED.Id
            VALUES (@Isbn, @Title, @CategoryId, @PublisherId, @PublishedYear, @TotalCopies, @TotalCopies)
            """,
            ToParams(item));

        InsertAuthors(transaction, bookId, item.AuthorIds);
    });

    /// <summary>Cập nhật sách và thay toàn bộ danh sách tác giả.</summary>
    /// <remarks>
    /// Số bản còn lại được điều chỉnh theo chênh lệch tổng số bản,
    /// nên số bản đang cho mượn không thay đổi.
    /// </remarks>
    /// <param name="item">Sách chứa dữ liệu mới.</param>
    /// <exception cref="BusinessException">Tổng số bản nhỏ hơn số bản đang cho mượn, hoặc dữ liệu vi phạm ràng buộc.</exception>
    public void Update(Book item) => InTransaction(transaction =>
    {
        // Số bản còn lại thay đổi theo tổng số bản, số bản đang cho mượn giữ nguyên
        var updatedRows = Execute(
            transaction,
            """
            UPDATE dbo.Books
            SET Isbn = @Isbn, Title = @Title, CategoryId = @CategoryId, PublisherId = @PublisherId,
                PublishedYear = @PublishedYear,
                AvailableCopies = AvailableCopies + @TotalCopies - TotalCopies,
                TotalCopies = @TotalCopies
            WHERE Id = @Id AND TotalCopies - AvailableCopies <= @TotalCopies
            """,
            [Param("@Id", item.Id), .. ToParams(item)]);

        if (updatedRows == 0)
            throw new BusinessException("Tổng số bản không được nhỏ hơn số bản đang cho mượn.");

        Execute(transaction, "DELETE FROM dbo.BookAuthors WHERE BookId = @BookId", Param("@BookId", item.Id));
        InsertAuthors(transaction, item.Id, item.AuthorIds);
    });

    /// <inheritdoc/>
    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Books WHERE Id = @Id",
        Param("@Id", id));

    /// <summary>Thêm các dòng liên kết sách với tác giả.</summary>
    /// <param name="transaction">Transaction đang mở.</param>
    /// <param name="bookId">Khóa chính của sách.</param>
    /// <param name="authorIds">Khóa chính của các tác giả.</param>
    private static void InsertAuthors(SqlTransaction transaction, int bookId, IEnumerable<int> authorIds)
    {
        foreach (var authorId in authorIds)
        {
            Execute(
                transaction,
                "INSERT INTO dbo.BookAuthors (BookId, AuthorId) VALUES (@BookId, @AuthorId)",
                Param("@BookId", bookId),
                Param("@AuthorId", authorId));
        }
    }

    /// <summary>Tạo các tham số chung của câu lệnh thêm và sửa <see cref="Book"/>.</summary>
    /// <param name="item">Bản ghi nguồn.</param>
    /// <returns>Danh sách tham số, chưa gồm <c>@Id</c>.</returns>
    private static SqlParameter[] ToParams(Book item) =>
    [
        Param("@Isbn", item.Isbn),
        Param("@Title", item.Title),
        Param("@CategoryId", item.CategoryId),
        Param("@PublisherId", item.PublisherId),
        Param("@PublishedYear", item.PublishedYear),
        Param("@TotalCopies", item.TotalCopies)
    ];

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="Book"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static Book Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        Isbn = reader.ReadNullableString("Isbn"),
        Title = reader.ReadString("Title"),
        CategoryId = reader.ReadInt("CategoryId"),
        PublisherId = reader.ReadNullableInt("PublisherId"),
        PublishedYear = reader.ReadNullableShort("PublishedYear"),
        TotalCopies = reader.ReadInt("TotalCopies"),
        AvailableCopies = reader.ReadInt("AvailableCopies"),
        CategoryName = reader.ReadString("CategoryName"),
        PublisherName = reader.ReadNullableString("PublisherName"),
        AuthorNames = reader.ReadNullableString("AuthorNames"),
        AuthorIds = ParseIds(reader.ReadNullableString("AuthorIds"))
    };

    /// <summary>Tách chuỗi khóa chính nối bằng dấu phẩy từ <c>STRING_AGG</c>.</summary>
    /// <param name="ids">Chuỗi khóa chính, có thể null.</param>
    /// <returns>Danh sách khóa chính, rỗng nếu đầu vào là null.</returns>
    private static List<int> ParseIds(string? ids) =>
        ids is null ? [] : ids.Split(',').Select(int.Parse).ToList();
}
