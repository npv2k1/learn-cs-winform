using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Hộp thoại tạo phiếu mượn. Trả về <see cref="DialogResult.OK"/> khi tạo thành công.</summary>
public partial class LoanCreateForm : Form
{
    private readonly LoanController controller;

    /// <summary>Tạo hộp thoại tạo phiếu mượn.</summary>
    /// <param name="controller">Controller mượn trả.</param>
    public LoanCreateForm(LoanController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dtpDueDate.SetDate(DateOnly.FromDateTime(DateTime.Today).AddDays(LoanController.DefaultLoanDays));
    }

    /// <summary>Nạp danh sách độc giả và sách khi hộp thoại mở.</summary>
    private void LoanCreateForm_Load(object sender, EventArgs e) => Ui.Run(this, LoadLookups);

    /// <summary>Tạo phiếu từ dữ liệu đã chọn.</summary>
    private void btnSave_Click(object sender, EventArgs e) => Ui.Run(this, Save);

    /// <summary>Nạp dữ liệu cho ô chọn độc giả và danh sách sách còn bản.</summary>
    private void LoadLookups()
    {
        cboMember.DisplayMember = nameof(Member.FullName);
        cboMember.DataSource = controller.GetMembers();

        clbBooks.DisplayMember = nameof(Book.Title);
        clbBooks.Items.AddRange(controller.GetAvailableBooks().ToArray<object>());
    }

    /// <summary>Tạo phiếu từ dữ liệu đã chọn rồi đóng hộp thoại.</summary>
    private void Save()
    {
        var bookIds = clbBooks.CheckedItems.Cast<Book>().Select(book => book.Id).ToList();
        controller.Create(cboMember.SelectedItem as Member, dtpDueDate.DateValue(), bookIds);
        DialogResult = DialogResult.OK;
    }
}
