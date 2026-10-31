using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Hộp thoại tạo phiếu mượn. Trả về <see cref="DialogResult.OK"/> khi tạo thành công.</summary>
public class LoanCreateForm : Form
{
    private readonly LoanController controller;
    private readonly ComboBox memberInput = new() { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
    private readonly DateTimePicker dueDateInput = new() { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
    private readonly CheckedListBox booksInput = new() { CheckOnClick = true, Dock = DockStyle.Fill };

    /// <summary>Tạo hộp thoại tạo phiếu mượn.</summary>
    /// <param name="controller">Controller mượn trả.</param>
    public LoanCreateForm(LoanController controller)
    {
        this.controller = controller;

        Text = "Tạo phiếu mượn";
        Width = 520;
        Height = 480;
        StartPosition = FormStartPosition.CenterParent;
        dueDateInput.SetDate(DateOnly.FromDateTime(DateTime.Today).AddDays(LoanController.DefaultLoanDays));

        var saveButton = new Button { Text = "Lưu", Dock = DockStyle.Right, Width = 90 };
        var cancelButton = new Button { Text = "Hủy", Dock = DockStyle.Right, Width = 90, DialogResult = DialogResult.Cancel };
        saveButton.Click += (_, _) => Ui.Run(this, Save);
        CancelButton = cancelButton;

        var buttons = new Panel { Dock = DockStyle.Fill };
        buttons.Controls.Add(saveButton);
        buttons.Controls.Add(cancelButton);

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 4, Padding = new Padding(8) };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        layout.Controls.Add(new Label { Text = "Độc giả", AutoSize = true }, 0, 0);
        layout.Controls.Add(memberInput, 1, 0);
        layout.Controls.Add(new Label { Text = "Hạn trả", AutoSize = true }, 0, 1);
        layout.Controls.Add(dueDateInput, 1, 1);
        layout.Controls.Add(new Label { Text = "Sách", AutoSize = true }, 0, 2);
        layout.Controls.Add(booksInput, 1, 2);
        layout.Controls.Add(buttons, 1, 3);
        Controls.Add(layout);
    }

    /// <summary>Nạp danh sách độc giả và sách khi hộp thoại mở.</summary>
    /// <param name="e">Dữ liệu sự kiện.</param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Ui.Run(this, LoadLookups);
    }

    /// <summary>Nạp dữ liệu cho ô chọn độc giả và danh sách sách còn bản.</summary>
    private void LoadLookups()
    {
        memberInput.DisplayMember = nameof(Member.FullName);
        memberInput.DataSource = controller.GetMembers();

        booksInput.DisplayMember = nameof(Book.Title);
        booksInput.Items.AddRange(controller.GetAvailableBooks().ToArray<object>());
    }

    /// <summary>Tạo phiếu từ dữ liệu đã chọn rồi đóng hộp thoại.</summary>
    private void Save()
    {
        var bookIds = booksInput.CheckedItems.Cast<Book>().Select(book => book.Id).ToList();
        controller.Create(memberInput.SelectedItem as Member, dueDateInput.DateValue(), bookIds);
        DialogResult = DialogResult.OK;
    }
}
