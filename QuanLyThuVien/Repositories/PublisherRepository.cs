using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public class PublisherRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Publisher>
{
    public List<Publisher> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, Name, Address, Phone
        FROM dbo.Publishers
        WHERE @Keyword IS NULL OR Name LIKE @Keyword
        ORDER BY Name
        """,
        Map,
        KeywordParam(keyword));

    public void Add(Publisher item) => Execute(
        "INSERT INTO dbo.Publishers (Name, Address, Phone) VALUES (@Name, @Address, @Phone)",
        Param("@Name", item.Name),
        Param("@Address", item.Address),
        Param("@Phone", item.Phone));

    public void Update(Publisher item) => Execute(
        "UPDATE dbo.Publishers SET Name = @Name, Address = @Address, Phone = @Phone WHERE Id = @Id",
        Param("@Id", item.Id),
        Param("@Name", item.Name),
        Param("@Address", item.Address),
        Param("@Phone", item.Phone));

    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Publishers WHERE Id = @Id",
        Param("@Id", id));

    private static Publisher Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        Name = reader.ReadString("Name"),
        Address = reader.ReadNullableString("Address"),
        Phone = reader.ReadNullableString("Phone")
    };
}
