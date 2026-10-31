using Microsoft.Data.SqlClient;

namespace QuanLyThuVien.Data;

/// <summary>Các hàm đọc giá trị từ <see cref="SqlDataReader"/> theo tên cột.</summary>
public static class SqlDataReaderExtensions
{
    /// <summary>Đọc một cột chuỗi không null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột.</returns>
    public static string ReadString(this SqlDataReader reader, string column) =>
        reader.GetString(reader.GetOrdinal(column));

    /// <summary>Đọc một cột chuỗi có thể null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột, hoặc <see langword="null"/> nếu cột không có dữ liệu.</returns>
    public static string? ReadNullableString(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    /// <summary>Đọc một cột <c>INT</c> không null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột.</returns>
    public static int ReadInt(this SqlDataReader reader, string column) =>
        reader.GetInt32(reader.GetOrdinal(column));

    /// <summary>Đọc một cột <c>INT</c> có thể null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột, hoặc <see langword="null"/> nếu cột không có dữ liệu.</returns>
    public static int? ReadNullableInt(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetInt32(ordinal);
    }

    /// <summary>Đọc một cột <c>SMALLINT</c> có thể null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột, hoặc <see langword="null"/> nếu cột không có dữ liệu.</returns>
    public static short? ReadNullableShort(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetInt16(ordinal);
    }

    /// <summary>Đọc một cột <c>BIT</c> không null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột.</returns>
    public static bool ReadBool(this SqlDataReader reader, string column) =>
        reader.GetBoolean(reader.GetOrdinal(column));

    /// <summary>Đọc một cột <c>DECIMAL</c> không null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột.</returns>
    public static decimal ReadDecimal(this SqlDataReader reader, string column) =>
        reader.GetDecimal(reader.GetOrdinal(column));

    /// <summary>Đọc một cột <c>DATE</c> không null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột.</returns>
    public static DateOnly ReadDate(this SqlDataReader reader, string column) =>
        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal(column)));

    /// <summary>Đọc một cột <c>DATE</c> có thể null.</summary>
    /// <param name="reader">Reader đang đứng ở dòng cần đọc.</param>
    /// <param name="column">Tên cột trong kết quả truy vấn.</param>
    /// <returns>Giá trị của cột, hoặc <see langword="null"/> nếu cột không có dữ liệu.</returns>
    public static DateOnly? ReadNullableDate(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : DateOnly.FromDateTime(reader.GetDateTime(ordinal));
    }
}
