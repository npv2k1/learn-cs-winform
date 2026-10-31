using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public class AuthorRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Author>
{
    public List<Author> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, FullName, BirthYear, Biography
        FROM dbo.Authors
        WHERE @Keyword IS NULL OR FullName LIKE @Keyword
        ORDER BY FullName
        """,
        Map,
        KeywordParam(keyword));

    public void Add(Author item) => Execute(
        "INSERT INTO dbo.Authors (FullName, BirthYear, Biography) VALUES (@FullName, @BirthYear, @Biography)",
        Param("@FullName", item.FullName),
        Param("@BirthYear", item.BirthYear),
        Param("@Biography", item.Biography));

    public void Update(Author item) => Execute(
        "UPDATE dbo.Authors SET FullName = @FullName, BirthYear = @BirthYear, Biography = @Biography WHERE Id = @Id",
        Param("@Id", item.Id),
        Param("@FullName", item.FullName),
        Param("@BirthYear", item.BirthYear),
        Param("@Biography", item.Biography));

    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Authors WHERE Id = @Id",
        Param("@Id", id));

    private static Author Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        FullName = reader.ReadString("FullName"),
        BirthYear = reader.ReadNullableShort("BirthYear"),
        Biography = reader.ReadNullableString("Biography")
    };
}
