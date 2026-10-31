using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

/// <summary>Cung cấp số liệu thống kê cho cửa sổ chính.</summary>
/// <param name="statistics">Repository thống kê.</param>
public class StatisticsController(IStatisticsRepository statistics)
{
    /// <summary>Lấy các số liệu tổng quan tính đến hôm nay.</summary>
    /// <returns>Số liệu tổng quan.</returns>
    public LibraryStatistics GetStatistics() => statistics.GetStatistics(Today());

    /// <summary>Lấy các cuốn sách đang quá hạn tính đến hôm nay.</summary>
    /// <returns>Danh sách sách quá hạn.</returns>
    public List<OverdueItem> GetOverdueItems() => statistics.GetOverdueItems(Today());

    /// <summary>Lấy ngày hiện tại theo giờ máy.</summary>
    /// <returns>Ngày hôm nay.</returns>
    private static DateOnly Today() => DateOnly.FromDateTime(DateTime.Now);
}
