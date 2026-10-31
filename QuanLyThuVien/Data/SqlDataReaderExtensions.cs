using Microsoft.Data.SqlClient;

namespace QuanLyThuVien.Data;

public static class SqlDataReaderExtensions
{
    public static string ReadString(this SqlDataReader reader, string column) =>
        reader.GetString(reader.GetOrdinal(column));

    public static string? ReadNullableString(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    public static int ReadInt(this SqlDataReader reader, string column) =>
        reader.GetInt32(reader.GetOrdinal(column));

    public static int? ReadNullableInt(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetInt32(ordinal);
    }

    public static short? ReadNullableShort(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetInt16(ordinal);
    }

    public static bool ReadBool(this SqlDataReader reader, string column) =>
        reader.GetBoolean(reader.GetOrdinal(column));

    public static decimal ReadDecimal(this SqlDataReader reader, string column) =>
        reader.GetDecimal(reader.GetOrdinal(column));

    public static DateOnly ReadDate(this SqlDataReader reader, string column) =>
        DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal(column)));

    public static DateOnly? ReadNullableDate(this SqlDataReader reader, string column)
    {
        var ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : DateOnly.FromDateTime(reader.GetDateTime(ordinal));
    }
}
