using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy cập bảng <c>dbo.Categories</c> bằng SQL thuần.</summary>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public class CategoryRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Category>
{
    /// <inheritdoc/>
    public List<Category> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, Name, Description
        FROM dbo.Categories
        WHERE @Keyword IS NULL OR Name LIKE @Keyword
        ORDER BY Name
        """,
        Map,
        KeywordParam(keyword));

    /// <inheritdoc/>
    public void Add(Category item) => Execute(
        "INSERT INTO dbo.Categories (Name, Description) VALUES (@Name, @Description)",
        Param("@Name", item.Name),
        Param("@Description", item.Description));

    /// <inheritdoc/>
    public void Update(Category item) => Execute(
        "UPDATE dbo.Categories SET Name = @Name, Description = @Description WHERE Id = @Id",
        Param("@Id", item.Id),
        Param("@Name", item.Name),
        Param("@Description", item.Description));

    /// <inheritdoc/>
    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Categories WHERE Id = @Id",
        Param("@Id", id));

    /// <summary>Chuyển dòng hiện tại của reader thành <see cref="Category"/>.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <returns>Đối tượng được tạo từ dòng hiện tại.</returns>
    private static Category Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        Name = reader.ReadString("Name"),
        Description = reader.ReadNullableString("Description")
    };
}
