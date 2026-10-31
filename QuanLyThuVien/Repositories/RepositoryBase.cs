using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Lớp cơ sở cung cấp các hàm chạy SQL có tham số cho repository.</summary>
/// <remarks>
/// Mọi thao tác ghi đi qua <see cref="InTransaction"/>, nơi các lỗi ràng buộc của
/// SQL Server được đổi thành <see cref="BusinessException"/>.
/// </remarks>
/// <param name="connectionFactory">Factory dùng để mở kết nối tới database.</param>
public abstract class RepositoryBase(SqlConnectionFactory connectionFactory)
{
    /// <summary>Mã lỗi SQL Server khi vi phạm khóa ngoại hoặc ràng buộc <c>CHECK</c>.</summary>
    private const int ConstraintViolation = 547;
    /// <summary>Mã lỗi SQL Server khi trùng giá trị trên unique index.</summary>
    private const int UniqueIndexViolation = 2601;
    /// <summary>Mã lỗi SQL Server khi trùng giá trị trên ràng buộc <c>UNIQUE</c> hoặc khóa chính.</summary>
    private const int UniqueConstraintViolation = 2627;

    /// <summary>Chạy câu truy vấn và chuyển từng dòng kết quả thành đối tượng.</summary>
    /// <typeparam name="T">Kiểu đối tượng kết quả.</typeparam>
    /// <param name="sql">Câu lệnh SQL có tham số.</param>
    /// <param name="map">Hàm chuyển một dòng thành đối tượng.</param>
    /// <param name="parameters">Tham số của câu lệnh.</param>
    /// <returns>Danh sách đối tượng theo thứ tự trả về từ SQL.</returns>
    protected List<T> Query<T>(string sql, Func<SqlDataReader, T> map, params SqlParameter[] parameters)
    {
        using var connection = connectionFactory.Open();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        using var reader = command.ExecuteReader();

        var items = new List<T>();
        while (reader.Read())
            items.Add(map(reader));
        return items;
    }

    /// <summary>Chạy một câu lệnh ghi trong transaction riêng.</summary>
    /// <param name="sql">Câu lệnh SQL có tham số.</param>
    /// <param name="parameters">Tham số của câu lệnh.</param>
    /// <exception cref="BusinessException">Câu lệnh vi phạm ràng buộc dữ liệu.</exception>
    protected void Execute(string sql, params SqlParameter[] parameters) =>
        InTransaction(transaction => Execute(transaction, sql, parameters));

    /// <summary>Chạy một nhóm thao tác trong cùng một transaction.</summary>
    /// <remarks>
    /// Transaction chỉ được commit khi <paramref name="work"/> chạy xong;
    /// nếu có lỗi, toàn bộ thay đổi được rollback khi giải phóng transaction.
    /// </remarks>
    /// <param name="work">Các thao tác cần chạy.</param>
    /// <exception cref="BusinessException">Thao tác vi phạm ràng buộc dữ liệu, hoặc do <paramref name="work"/> ném ra.</exception>
    protected void InTransaction(Action<SqlTransaction> work)
    {
        try
        {
            using var connection = connectionFactory.Open();
            using var transaction = connection.BeginTransaction();
            work(transaction);
            transaction.Commit();
        }
        catch (SqlException ex) when (ex.Number == ConstraintViolation)
        {
            throw new BusinessException("Dữ liệu không hợp lệ hoặc đang được sử dụng ở nơi khác.", ex);
        }
        catch (SqlException ex) when (ex.Number is UniqueIndexViolation or UniqueConstraintViolation)
        {
            throw new BusinessException("Dữ liệu đã tồn tại.", ex);
        }
    }

    /// <summary>Chạy một câu lệnh ghi trong transaction có sẵn.</summary>
    /// <param name="transaction">Transaction đang mở.</param>
    /// <param name="sql">Câu lệnh SQL có tham số.</param>
    /// <param name="parameters">Tham số của câu lệnh.</param>
    /// <returns>Số dòng bị ảnh hưởng.</returns>
    protected static int Execute(SqlTransaction transaction, string sql, params SqlParameter[] parameters)
    {
        using var command = CreateCommand(transaction, sql, parameters);
        return command.ExecuteNonQuery();
    }

    /// <summary>Chạy câu lệnh <c>INSERT</c> có <c>OUTPUT INSERTED.Id</c>.</summary>
    /// <param name="transaction">Transaction đang mở.</param>
    /// <param name="sql">Câu lệnh SQL có tham số.</param>
    /// <param name="parameters">Tham số của câu lệnh.</param>
    /// <returns>Khóa chính của dòng vừa thêm.</returns>
    protected static int InsertAndGetId(SqlTransaction transaction, string sql, params SqlParameter[] parameters)
    {
        using var command = CreateCommand(transaction, sql, parameters);
        return (int)command.ExecuteScalar()!;
    }

    /// <summary>Tạo tham số SQL, tự đổi <see langword="null"/> và <see cref="DateOnly"/> sang kiểu ADO.NET hỗ trợ.</summary>
    /// <param name="name">Tên tham số, có tiền tố <c>@</c>.</param>
    /// <param name="value">Giá trị của tham số.</param>
    /// <returns>Tham số đã sẵn sàng để gắn vào câu lệnh.</returns>
    protected static SqlParameter Param(string name, object? value)
    {
        object converted = value switch
        {
            null => DBNull.Value,
            DateOnly date => date.ToDateTime(TimeOnly.MinValue),
            _ => value
        };
        return new SqlParameter(name, converted);
    }

    /// <summary>Tạo tham số <c>@Keyword</c> cho điều kiện <c>LIKE</c>.</summary>
    /// <param name="keyword">Từ khóa người dùng nhập.</param>
    /// <returns>Tham số dạng <c>%từ khóa%</c>, hoặc mang giá trị null nếu từ khóa trống.</returns>
    protected static SqlParameter KeywordParam(string? keyword) =>
        Param("@Keyword", string.IsNullOrWhiteSpace(keyword) ? null : $"%{keyword.Trim()}%");

    /// <summary>Tạo command gắn với transaction và tham số đã cho.</summary>
    /// <param name="transaction">Transaction đang mở.</param>
    /// <param name="sql">Câu lệnh SQL có tham số.</param>
    /// <param name="parameters">Tham số của câu lệnh.</param>
    /// <returns>Command sẵn sàng chạy. Bên gọi có trách nhiệm giải phóng.</returns>
    private static SqlCommand CreateCommand(SqlTransaction transaction, string sql, SqlParameter[] parameters)
    {
        var command = new SqlCommand(sql, transaction.Connection, transaction);
        command.Parameters.AddRange(parameters);
        return command;
    }
}
