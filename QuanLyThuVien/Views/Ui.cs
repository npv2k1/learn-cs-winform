using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Các hàm dùng chung cho tầng giao diện.</summary>
internal static class Ui
{
    /// <summary>Chạy một thao tác của người dùng và báo lỗi lên màn hình.</summary>
    /// <remarks>
    /// Đây là ranh giới cuối cùng của luồng xử lý, nên lỗi được hiển thị tại đây thay vì ném tiếp.
    /// </remarks>
    /// <param name="owner">Cửa sổ sở hữu hộp thoại thông báo.</param>
    /// <param name="action">Thao tác cần chạy.</param>
    public static void Run(IWin32Window owner, Action action)
    {
        try
        {
            action();
        }
        catch (BusinessException ex)
        {
            MessageBox.Show(owner, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(owner, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>Lấy nội dung đã bỏ khoảng trắng hai đầu của ô nhập.</summary>
    /// <param name="textBox">Ô nhập.</param>
    /// <returns>Nội dung ô nhập, hoặc <see langword="null"/> nếu ô trống.</returns>
    public static string? TextOrNull(this TextBox textBox) =>
        string.IsNullOrWhiteSpace(textBox.Text) ? null : textBox.Text.Trim();

    /// <summary>Lấy ngày đang chọn, bỏ phần giờ.</summary>
    /// <param name="picker">Ô chọn ngày.</param>
    /// <returns>Ngày đang chọn.</returns>
    public static DateOnly DateValue(this DateTimePicker picker) => DateOnly.FromDateTime(picker.Value);

    /// <summary>Đặt ngày cho ô chọn ngày.</summary>
    /// <param name="picker">Ô chọn ngày.</param>
    /// <param name="date">Ngày cần đặt.</param>
    public static void SetDate(this DateTimePicker picker, DateOnly date) =>
        picker.Value = date.ToDateTime(TimeOnly.MinValue);

    /// <summary>Đọc giá trị của ô nhập năm.</summary>
    /// <param name="input">Ô nhập năm.</param>
    /// <returns>Năm đã nhập, hoặc <see langword="null"/> nếu giá trị là 0.</returns>
    public static short? YearOrNull(this NumericUpDown input) => input.Value == 0 ? null : (short)input.Value;
}
