using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

internal static class Ui
{
    /// <summary>Chạy một thao tác của người dùng và báo lỗi lên màn hình.</summary>
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

    public static DataGridView CreateGrid() => new()
    {
        Dock = DockStyle.Fill,
        AutoGenerateColumns = false,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        MultiSelect = false,
        RowHeadersVisible = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    public static void AddColumn(this DataGridView grid, string propertyName, string header) =>
        grid.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = header
        });

    public static string? TextOrNull(this TextBox textBox) =>
        string.IsNullOrWhiteSpace(textBox.Text) ? null : textBox.Text.Trim();

    public static DateOnly DateValue(this DateTimePicker picker) => DateOnly.FromDateTime(picker.Value);

    public static void SetDate(this DateTimePicker picker, DateOnly date) =>
        picker.Value = date.ToDateTime(TimeOnly.MinValue);

    /// <summary>Ô năm dùng giá trị 0 cho trường hợp không có dữ liệu.</summary>
    public static NumericUpDown CreateYearInput() => new() { Minimum = 0, Maximum = 9999 };

    public static short? YearOrNull(this NumericUpDown input) => input.Value == 0 ? null : (short)input.Value;
}
