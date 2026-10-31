using QuanLyThuVien.Controllers;

namespace QuanLyThuVien.Views;

/// <summary>Cửa sổ chính: menu chức năng, số liệu thống kê và danh sách sách quá hạn.</summary>
public partial class MainForm : Form
{
    private readonly AppControllers controllers;

    /// <summary>Tạo cửa sổ chính.</summary>
    /// <param name="controllers">Các controller của ứng dụng.</param>
    public MainForm(AppControllers controllers)
    {
        this.controllers = controllers;
        InitializeComponent();
        dgvOverdue.AutoGenerateColumns = false;
    }

    /// <summary>Tải số liệu khi cửa sổ mở.</summary>
    private void MainForm_Load(object sender, EventArgs e) => Ui.Run(this, ReloadStatistics);

    /// <summary>Mở màn hình sách.</summary>
    private void mnuBooks_Click(object sender, EventArgs e) => Open(new BookForm(controllers.Books));

    /// <summary>Mở màn hình thể loại.</summary>
    private void mnuCategories_Click(object sender, EventArgs e) => Open(new CategoryForm(controllers.Categories));

    /// <summary>Mở màn hình tác giả.</summary>
    private void mnuAuthors_Click(object sender, EventArgs e) => Open(new AuthorForm(controllers.Authors));

    /// <summary>Mở màn hình nhà xuất bản.</summary>
    private void mnuPublishers_Click(object sender, EventArgs e) => Open(new PublisherForm(controllers.Publishers));

    /// <summary>Mở màn hình độc giả.</summary>
    private void mnuMembers_Click(object sender, EventArgs e) => Open(new MemberForm(controllers.Members));

    /// <summary>Mở màn hình mượn trả.</summary>
    private void mnuLoans_Click(object sender, EventArgs e) => Open(new LoanForm(controllers.Loans));

    /// <summary>Mở một form dạng hộp thoại, giải phóng khi đóng rồi cập nhật lại số liệu.</summary>
    /// <param name="form">Form cần mở.</param>
    private void Open(Form form)
    {
        using (form)
            form.ShowDialog(this);

        Ui.Run(this, ReloadStatistics);
    }

    /// <summary>Tải lại các số liệu tổng quan và danh sách sách quá hạn.</summary>
    private void ReloadStatistics()
    {
        var statistics = controllers.Statistics.GetStatistics();

        lblTotalTitles.Text = statistics.TotalTitles.ToString("N0");
        lblTotalCopies.Text = statistics.TotalCopies.ToString("N0");
        lblCopiesOnLoan.Text = statistics.CopiesOnLoan.ToString("N0");
        lblActiveMembers.Text = statistics.ActiveMembers.ToString("N0");
        lblOpenLoans.Text = statistics.OpenLoans.ToString("N0");
        lblOverdueLoans.Text = statistics.OverdueLoans.ToString("N0");

        dgvOverdue.DataSource = controllers.Statistics.GetOverdueItems();
    }
}
