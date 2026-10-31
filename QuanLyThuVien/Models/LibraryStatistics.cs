namespace QuanLyThuVien.Models;

/// <summary>Các số liệu tổng quan hiển thị trên cửa sổ chính.</summary>
public class LibraryStatistics
{
    /// <summary>Số đầu sách.</summary>
    public int TotalTitles { get; set; }

    /// <summary>Tổng số bản sách của thư viện.</summary>
    public int TotalCopies { get; set; }

    /// <summary>Số bản sách đang được cho mượn.</summary>
    public int CopiesOnLoan { get; set; }

    /// <summary>Số độc giả có thẻ còn hạn và không bị khóa.</summary>
    public int ActiveMembers { get; set; }

    /// <summary>Số phiếu còn sách chưa trả.</summary>
    public int OpenLoans { get; set; }

    /// <summary>Số phiếu còn sách chưa trả và đã qua hạn trả.</summary>
    public int OverdueLoans { get; set; }
}
