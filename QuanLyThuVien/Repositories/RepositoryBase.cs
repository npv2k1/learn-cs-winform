using Microsoft.Data.SqlClient;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public abstract class RepositoryBase(SqlConnectionFactory connectionFactory)
{
    private const int ConstraintViolation = 547;
    private const int UniqueIndexViolation = 2601;
    private const int UniqueConstraintViolation = 2627;

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

    protected void Execute(string sql, params SqlParameter[] parameters) =>
        InTransaction(transaction => Execute(transaction, sql, parameters));

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

    protected static int Execute(SqlTransaction transaction, string sql, params SqlParameter[] parameters)
    {
        using var command = CreateCommand(transaction, sql, parameters);
        return command.ExecuteNonQuery();
    }

    protected static int InsertAndGetId(SqlTransaction transaction, string sql, params SqlParameter[] parameters)
    {
        using var command = CreateCommand(transaction, sql, parameters);
        return (int)command.ExecuteScalar()!;
    }

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

    protected static SqlParameter KeywordParam(string? keyword) =>
        Param("@Keyword", string.IsNullOrWhiteSpace(keyword) ? null : $"%{keyword.Trim()}%");

    private static SqlCommand CreateCommand(SqlTransaction transaction, string sql, SqlParameter[] parameters)
    {
        var command = new SqlCommand(sql, transaction.Connection, transaction);
        command.Parameters.AddRange(parameters);
        return command;
    }
}
