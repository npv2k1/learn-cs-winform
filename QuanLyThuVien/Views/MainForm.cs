using QuanLyThuVien.Controllers;

namespace QuanLyThuVien.Views;

/// <summary>Cửa sổ chính, mở các màn hình chức năng từ menu.</summary>
public partial class MainForm : Form
{
    private readonly AppControllers controllers;

    /// <summary>Tạo cửa sổ chính.</summary>
    /// <param name="controllers">Các controller của ứng dụng.</param>
    public MainForm(AppControllers controllers)
    {
        this.controllers = controllers;
        InitializeComponent();
    }

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

    /// <summary>Mở một form dạng hộp thoại và giải phóng khi đóng.</summary>
    /// <param name="form">Form cần mở.</param>
    private void Open(Form form)
    {
        using (form)
            form.ShowDialog(this);
    }
}
