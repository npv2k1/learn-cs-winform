using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy cập bảng <c>dbo.Authors</c> bằng SQL thuần.</summary>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public class AuthorRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Author>
{
    /// <inheritdoc/>
    public List<Author> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, FullName, BirthYear, Biography
        FROM dbo.Authors
        WHERE @Keyword IS NULL OR FullName LIKE @Keyword
        ORDER BY FullName
        """,
        Map,
        KeywordParam(keyword));

    /// <inheritdoc/>
    public void Add(Author item) => Execute(
        "INSERT INTO dbo.Authors (FullName, BirthYear, Biography) VALUES (@FullName, @BirthYear, @Biography)",
        Param("@FullName", item.FullName),
        Param("@BirthYear", item.BirthYear),
        Param("@Biography", item.Biography));

    /// <inheritdoc/>
    public void Update(Author item) => Execute(
        "UPDATE dbo.Authors SET FullName = @FullName, BirthYear = @BirthYear, Biography = @Biography WHERE Id = @Id",
        Param("@Id", item.Id),
        Param("@FullName", item.FullName),
        Param("@BirthYear", item.BirthYear),
        Param("@Biography", item.Biography));

    /// <inheritdoc/>
    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Authors WHERE Id = @Id",
        Param("@Id", id));

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="Author"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static Author Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        FullName = reader.ReadString("FullName"),
        BirthYear = reader.ReadNullableShort("BirthYear"),
        Biography = reader.ReadNullableString("Biography")
    };
}
