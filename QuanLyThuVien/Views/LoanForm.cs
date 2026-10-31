using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình mượn trả: danh sách phiếu ở trên, sách của phiếu đang chọn ở dưới.</summary>
public class LoanForm : Form
{
    private readonly LoanController controller;
    private readonly DataGridView loansGrid = Ui.CreateGrid();
    private readonly DataGridView itemsGrid = Ui.CreateGrid();
    private readonly TextBox searchBox = new() { Dock = DockStyle.Fill };

    /// <summary>Tạo màn hình mượn trả.</summary>
    /// <param name="controller">Controller mượn trả.</param>
    public LoanForm(LoanController controller)
    {
        this.controller = controller;

        Text = "Mượn trả sách";
        Width = 1000;
        Height = 650;
        StartPosition = FormStartPosition.CenterParent;

        loansGrid.AddColumn(nameof(Loan.Id), "Số phiếu");
        loansGrid.AddColumn(nameof(Loan.MemberName), "Độc giả");
        loansGrid.AddColumn(nameof(Loan.LoanDate), "Ngày mượn");
        loansGrid.AddColumn(nameof(Loan.DueDate), "Hạn trả");
        loansGrid.AddColumn(nameof(Loan.Status), "Trạng thái");

        itemsGrid.AddColumn(nameof(LoanItem.BookTitle), "Tên sách");
        itemsGrid.AddColumn(nameof(LoanItem.ReturnedDate), "Ngày trả");
        itemsGrid.AddColumn(nameof(LoanItem.FineAmount), "Tiền phạt");

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 4, Padding = new Padding(8) };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
        layout.Controls.Add(CreateToolbar(), 0, 0);
        layout.Controls.Add(loansGrid, 0, 1);
        layout.Controls.Add(CreateItemsToolbar(), 0, 2);
        layout.Controls.Add(itemsGrid, 0, 3);
        Controls.Add(layout);

        loansGrid.SelectionChanged += (_, _) => Ui.Run(this, ReloadItems);
    }

    /// <summary>Phiếu mượn đang chọn, nếu có.</summary>
    private Loan? SelectedLoan =>
        loansGrid.SelectedRows.Count > 0 ? loansGrid.SelectedRows[0].DataBoundItem as Loan : null;

    /// <summary>Cuốn sách đang chọn trong phiếu, nếu có.</summary>
    private LoanItem? SelectedItem =>
        itemsGrid.SelectedRows.Count > 0 ? itemsGrid.SelectedRows[0].DataBoundItem as LoanItem : null;

    /// <summary>Nạp danh sách phiếu mượn khi form mở.</summary>
    /// <param name="e">Dữ liệu sự kiện.</param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Ui.Run(this, ReloadLoans);
    }

    /// <summary>Dựng thanh tìm kiếm và nút tạo phiếu.</summary>
    /// <returns>Panel chứa thanh công cụ.</returns>
    private Panel CreateToolbar()
    {
        var searchButton = new Button { Text = "Tìm", Dock = DockStyle.Right, Width = 80 };
        var createButton = new Button { Text = "Tạo phiếu mượn", Dock = DockStyle.Right, Width = 130 };

        searchButton.Click += (_, _) => Ui.Run(this, ReloadLoans);
        createButton.Click += (_, _) => CreateLoan();

        var panel = new Panel { Dock = DockStyle.Fill };
        panel.Controls.Add(searchBox);
        panel.Controls.Add(searchButton);
        panel.Controls.Add(createButton);
        return panel;
    }

    /// <summary>Dựng thanh công cụ của danh sách sách trong phiếu.</summary>
    /// <returns>Panel chứa thanh công cụ.</returns>
    private Panel CreateItemsToolbar()
    {
        var returnButton = new Button { Text = "Trả sách đã chọn", Dock = DockStyle.Right, Width = 130 };
        returnButton.Click += (_, _) => Ui.Run(this, ReturnSelectedItem);

        var panel = new Panel { Dock = DockStyle.Fill };
        panel.Controls.Add(new Label { Text = "Sách trong phiếu", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft });
        panel.Controls.Add(returnButton);
        return panel;
    }

    /// <summary>Mở hộp thoại tạo phiếu và tải lại danh sách nếu tạo thành công.</summary>
    private void CreateLoan()
    {
        using var form = new LoanCreateForm(controller);
        if (form.ShowDialog(this) == DialogResult.OK)
            Ui.Run(this, ReloadLoans);
    }

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
        loansGrid.DataSource = controller.GetLoans(searchBox.TextOrNull());
        ReloadItems();
    }

    /// <summary>Tải lại các cuốn sách của phiếu đang chọn.</summary>
    private void ReloadItems() =>
        itemsGrid.DataSource = SelectedLoan is { } loan ? controller.GetItems(loan.Id) : null;
}
