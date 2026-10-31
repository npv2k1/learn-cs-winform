using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

/// <summary>Truy vấn số liệu thống kê của thư viện.</summary>
public interface IStatisticsRepository
{
    /// <summary>Lấy các số liệu tổng quan.</summary>
    /// <param name="today">Ngày dùng để xét hạn thẻ và hạn trả.</param>
    /// <returns>Số liệu tổng quan tại ngày đã cho.</returns>
    LibraryStatistics GetStatistics(DateOnly today);

    /// <summary>Lấy các cuốn sách đã quá hạn mà chưa trả, trễ lâu nhất đứng trước.</summary>
    /// <param name="today">Ngày dùng để xét hạn trả.</param>
    /// <returns>Danh sách sách quá hạn.</returns>
    List<OverdueItem> GetOverdueItems(DateOnly today);
}
