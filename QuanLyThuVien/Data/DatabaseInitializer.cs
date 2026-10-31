using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace QuanLyThuVien.Data;

/// <summary>Tạo database và các bảng từ file <c>init.sql</c> đi kèm ứng dụng.</summary>
/// <remarks>
/// Script có kiểm tra tồn tại trước khi tạo, nên chạy lại ở mỗi lần khởi động không làm mất dữ liệu.
/// </remarks>
/// <param name="connectionString">Connection string của ứng dụng.</param>
public partial class DatabaseInitializer(string connectionString)
{
    /// <summary>Tên file script nằm cạnh file chạy của ứng dụng.</summary>
    private const string ScriptFileName = "init.sql";

    /// <summary>Database hệ thống để kết nối, vì database của ứng dụng có thể chưa tồn tại.</summary>
    private const string SystemDatabase = "master";

    /// <summary>Chạy toàn bộ script khởi tạo trên cùng một kết nối.</summary>
    /// <exception cref="SqlException">Không kết nối được tới SQL Server hoặc script bị lỗi.</exception>
    public void Run()
    {
        var script = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, ScriptFileName));
        var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = SystemDatabase };

        using var connection = new SqlConnection(builder.ConnectionString);
        connection.Open();

        foreach (var batch in BatchSeparator().Split(script).Where(batch => !string.IsNullOrWhiteSpace(batch)))
        {
            using var command = new SqlCommand(batch, connection);
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Khớp dòng <c>GO</c>. <c>GO</c> là lệnh của công cụ như sqlcmd, SQL Server không hiểu lệnh này,
    /// nên script phải được tách thành từng batch trước khi gửi đi.
    /// </summary>
    [GeneratedRegex(@"^\s*GO\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline)]
    private static partial Regex BatchSeparator();
}
