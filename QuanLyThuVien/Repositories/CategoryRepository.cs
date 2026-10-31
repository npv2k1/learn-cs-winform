using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public class CategoryRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Category>
{
    public List<Category> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, Name, Description
        FROM dbo.Categories
        WHERE @Keyword IS NULL OR Name LIKE @Keyword
        ORDER BY Name
        """,
        Map,
        KeywordParam(keyword));

    public void Add(Category item) => Execute(
        "INSERT INTO dbo.Categories (Name, Description) VALUES (@Name, @Description)",
        Param("@Name", item.Name),
        Param("@Description", item.Description));

    public void Update(Category item) => Execute(
        "UPDATE dbo.Categories SET Name = @Name, Description = @Description WHERE Id = @Id",
        Param("@Id", item.Id),
        Param("@Name", item.Name),
        Param("@Description", item.Description));

    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Categories WHERE Id = @Id",
        Param("@Id", id));

    private static Category Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        Name = reader.ReadString("Name"),
        Description = reader.ReadNullableString("Description")
    };
}
