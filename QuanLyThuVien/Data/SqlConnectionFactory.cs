using Microsoft.Data.SqlClient;

namespace QuanLyThuVien.Data;

public class SqlConnectionFactory(string connectionString)
{
    public SqlConnection Open()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}
