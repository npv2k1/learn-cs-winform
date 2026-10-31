using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình quản lý sách.</summary>
public partial class BookForm : Form
{
    private readonly BookController controller;

    /// <summary>Bản ghi đang chọn, <see langword="null"/> khi đang nhập mới.</summary>
    private Book? current;

    /// <summary>Tạo màn hình quản lý sách.</summary>
    /// <param name="controller">Controller sách.</param>
    public BookForm(BookController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dgvBooks.AutoGenerateColumns = false;
    }

    /// <summary>Tải dữ liệu khi form mở.</summary>
    private void BookForm_Load(object sender, EventArgs e)
    {
        Ui.Run(this, () =>
        {
            LoadLookups();
            Reload();
        });
    }

    /// <summary>Tìm kiếm theo từ khóa đang nhập.</summary>
    private void btnSearch_Click(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Hiển thị dòng vừa chọn lên các ô nhập.</summary>
    private void dgvBooks_SelectionChanged(object sender, EventArgs e) => ShowCurrent();

    /// <summary>Bỏ chọn dòng hiện tại để nhập bản ghi mới.</summary>
    private void btnNew_Click(object sender, EventArgs e) => dgvBooks.ClearSelection();

    /// <summary>Lưu dữ liệu đang nhập.</summary>
    private void btnSave_Click(object sender, EventArgs e) => Ui.Run(this, Save);

    /// <summary>Xóa dòng đang chọn.</summary>
    private void btnDelete_Click(object sender, EventArgs e) => Ui.Run(this, Delete);

    /// <summary>Nạp dữ liệu cho các ô chọn thể loại, nhà xuất bản và tác giả.</summary>
    private void LoadLookups()
    {
        cboCategory.DisplayMember = nameof(Category.Name);
        cboCategory.ValueMember = nameof(Category.Id);
        cboCategory.DataSource = controller.GetCategories();

        // Dòng Id = 0 ứng với sách không có nhà xuất bản
        cboPublisher.DisplayMember = nameof(Publisher.Name);
        cboPublisher.ValueMember = nameof(Publisher.Id);
        cboPublisher.DataSource = controller.GetPublishers().Prepend(new Publisher { Name = "(Không có)" }).ToList();

        clbAuthors.DisplayMember = nameof(Author.FullName);
        clbAuthors.Items.Clear();
        clbAuthors.Items.AddRange(controller.GetAuthors().ToArray<object>());
    }

    /// <summary>Tải lại danh sách theo từ khóa hiện tại.</summary>
    private void Reload()
    {
        dgvBooks.DataSource = controller.GetAll(txtSearch.TextOrNull());
        ShowCurrent();
    }

    /// <summary>Cập nhật bản ghi đang chọn và hiển thị lên ô nhập.</summary>
    private void ShowCurrent()
    {
        current = dgvBooks.SelectedRows.Count > 0 ? dgvBooks.SelectedRows[0].DataBoundItem as Book : null;
        ShowItem(current);
    }

    /// <summary>Lưu dữ liệu đang nhập rồi tải lại danh sách.</summary>
    private void Save()
    {
        var item = ReadItem();
        item.Id = current?.Id ?? 0;
        controller.Save(item);
        Reload();
    }

    /// <summary>Xóa bản ghi đang chọn sau khi người dùng xác nhận.</summary>
    /// <exception cref="BusinessException">Chưa chọn bản ghi.</exception>
    private void Delete()
    {
        if (current is null)
            throw new BusinessException("Vui lòng chọn dòng cần xóa.");

        var answer = MessageBox.Show(this, "Bạn có chắc muốn xóa dòng này?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        controller.Delete(current);
        Reload();
    }

    /// <summary>Đưa dữ liệu của bản ghi lên các ô nhập.</summary>
    /// <param name="item">Bản ghi cần hiển thị; <see langword="null"/> để xóa trắng và nhập mới.</param>
    private void ShowItem(Book? item)
    {
        txtTitle.Text = item?.Title;
        txtIsbn.Text = item?.Isbn;
        nudPublishedYear.Value = item?.PublishedYear ?? 0;
        nudTotalCopies.Value = item?.TotalCopies ?? 0;
        cboPublisher.SelectedValue = item?.PublisherId ?? 0;

        if (item is not null)
            cboCategory.SelectedValue = item.CategoryId;

        for (var i = 0; i < clbAuthors.Items.Count; i++)
        {
            var author = (Author)clbAuthors.Items[i];
            clbAuthors.SetItemChecked(i, item?.AuthorIds.Contains(author.Id) == true);
        }
    }

    /// <summary>Đọc các ô nhập thành model.</summary>
    /// <returns>Model chứa dữ liệu người dùng nhập.</returns>
    private Book ReadItem() => new()
    {
        Title = txtTitle.Text.Trim(),
        Isbn = txtIsbn.TextOrNull(),
        CategoryId = cboCategory.SelectedValue as int? ?? 0,
        PublisherId = cboPublisher.SelectedValue is int and not 0 ? (int)cboPublisher.SelectedValue : null,
        PublishedYear = nudPublishedYear.YearOrNull(),
        TotalCopies = (int)nudTotalCopies.Value,
        AuthorIds = clbAuthors.CheckedItems.Cast<Author>().Select(author => author.Id).ToList()
    };
}
