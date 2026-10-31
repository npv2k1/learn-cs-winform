using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình mượn trả: danh sách phiếu ở trên, sách của phiếu đang chọn ở dưới.</summary>
public partial class LoanForm : Form
{
    private readonly LoanController controller;

    /// <summary>Tạo màn hình mượn trả.</summary>
    /// <param name="controller">Controller mượn trả.</param>
    public LoanForm(LoanController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dgvLoans.AutoGenerateColumns = false;
        dgvItems.AutoGenerateColumns = false;
    }

    /// <summary>Phiếu mượn đang chọn, nếu có.</summary>
    private Loan? SelectedLoan =>
        dgvLoans.SelectedRows.Count > 0 ? dgvLoans.SelectedRows[0].DataBoundItem as Loan : null;

    /// <summary>Cuốn sách đang chọn trong phiếu, nếu có.</summary>
    private LoanItem? SelectedItem =>
        dgvItems.SelectedRows.Count > 0 ? dgvItems.SelectedRows[0].DataBoundItem as LoanItem : null;

    /// <summary>Nạp danh sách phiếu mượn khi form mở.</summary>
    private void LoanForm_Load(object sender, EventArgs e) => Ui.Run(this, ReloadLoans);

    /// <summary>Tìm phiếu theo từ khóa đang nhập.</summary>
    private void btnSearch_Click(object sender, EventArgs e) => Ui.Run(this, ReloadLoans);

    /// <summary>Tải sách của phiếu vừa chọn.</summary>
    private void dgvLoans_SelectionChanged(object sender, EventArgs e) => Ui.Run(this, ReloadItems);

    /// <summary>Mở hộp thoại tạo phiếu và tải lại danh sách nếu tạo thành công.</summary>
    private void btnCreateLoan_Click(object sender, EventArgs e)
    {
        using var form = new LoanCreateForm(controller);
        if (form.ShowDialog(this) == DialogResult.OK)
            Ui.Run(this, ReloadLoans);
    }

    /// <summary>Trả cuốn sách đang chọn.</summary>
    private void btnReturn_Click(object sender, EventArgs e) => Ui.Run(this, ReturnSelectedItem);

    /// <summary>Trả cuốn sách đang chọn và báo tiền phạt nếu có.</summary>
    /// <exception cref="BusinessException">Chưa chọn phiếu hoặc sách, hoặc sách đã được trả.</exception>
    private void ReturnSelectedItem()
    {
        var loan = SelectedLoan ?? throw new BusinessException("Vui lòng chọn phiếu mượn.");
        var item = SelectedItem ?? throw new BusinessException("Vui lòng chọn sách cần trả.");

        var fineAmount = controller.Return(loan, item);
        ReloadLoans();

        if (fineAmount > 0)
            MessageBox.Show(this, $"Trả sách quá hạn. Tiền phạt: {fineAmount:N0} đồng.", Text);
    }

    /// <summary>Tải lại danh sách phiếu theo từ khóa hiện tại.</summary>
    private void ReloadLoans()
    {
        dgvLoans.DataSource = controller.GetLoans(txtSearch.TextOrNull());
        ReloadItems();
    }

    /// <summary>Tải lại các cuốn sách của phiếu đang chọn.</summary>
    private void ReloadItems() =>
        dgvItems.DataSource = SelectedLoan is { } loan ? controller.GetItems(loan.Id) : null;
}
