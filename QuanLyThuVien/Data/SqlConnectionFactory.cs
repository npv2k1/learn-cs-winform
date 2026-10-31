using Microsoft.Data.SqlClient;

namespace QuanLyThuVien.Data;

/// <summary>Tạo các kết nối SQL Server từ một connection string dùng chung.</summary>
/// <param name="connectionString">Connection string tới database của ứng dụng.</param>
public class SqlConnectionFactory(string connectionString)
{
    /// <summary>Tạo và mở một kết nối mới.</summary>
    /// <returns>Kết nối đã mở. Bên gọi có trách nhiệm giải phóng kết nối.</returns>
    /// <exception cref="SqlException">Không kết nối được tới SQL Server.</exception>
    public SqlConnection Open()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}
