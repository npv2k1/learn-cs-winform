using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public class MemberRepository(SqlConnectionFactory connectionFactory)
    : RepositoryBase(connectionFactory), IRepository<Member>
{
    public List<Member> GetAll(string? keyword = null) => Query(
        """
        SELECT Id, MemberCode, FullName, Phone, Email, Address, JoinedDate, ExpiryDate, IsActive
        FROM dbo.Members
        WHERE @Keyword IS NULL OR FullName LIKE @Keyword OR MemberCode LIKE @Keyword
        ORDER BY FullName
        """,
        Map,
        KeywordParam(keyword));

    public void Add(Member item) => Execute(
        """
        INSERT INTO dbo.Members (MemberCode, FullName, Phone, Email, Address, JoinedDate, ExpiryDate, IsActive)
        VALUES (@MemberCode, @FullName, @Phone, @Email, @Address, @JoinedDate, @ExpiryDate, @IsActive)
        """,
        ToParams(item));

    public void Update(Member item) => Execute(
        """
        UPDATE dbo.Members
        SET MemberCode = @MemberCode, FullName = @FullName, Phone = @Phone, Email = @Email,
            Address = @Address, JoinedDate = @JoinedDate, ExpiryDate = @ExpiryDate, IsActive = @IsActive
        WHERE Id = @Id
        """,
        [Param("@Id", item.Id), .. ToParams(item)]);

    public void Delete(int id) => Execute(
        "DELETE FROM dbo.Members WHERE Id = @Id",
        Param("@Id", id));

    private static SqlParameter[] ToParams(Member item) =>
    [
        Param("@MemberCode", item.MemberCode),
        Param("@FullName", item.FullName),
        Param("@Phone", item.Phone),
        Param("@Email", item.Email),
        Param("@Address", item.Address),
        Param("@JoinedDate", item.JoinedDate),
        Param("@ExpiryDate", item.ExpiryDate),
        Param("@IsActive", item.IsActive)
    ];

    private static Member Map(SqlDataReader reader) => new()
    {
        Id = reader.ReadInt("Id"),
        MemberCode = reader.ReadString("MemberCode"),
        FullName = reader.ReadString("FullName"),
        Phone = reader.ReadNullableString("Phone"),
        Email = reader.ReadNullableString("Email"),
        Address = reader.ReadNullableString("Address"),
        JoinedDate = reader.ReadDate("JoinedDate"),
        ExpiryDate = reader.ReadDate("ExpiryDate"),
        IsActive = reader.ReadBool("IsActive")
    };
}
