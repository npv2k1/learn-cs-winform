using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình quản lý thể loại.</summary>
public partial class CategoryForm : Form
{
    private readonly CategoryController controller;

    /// <summary>Bản ghi đang chọn, <see langword="null"/> khi đang nhập mới.</summary>
    private Category? current;

    /// <summary>Tạo màn hình quản lý thể loại.</summary>
    /// <param name="controller">Controller thể loại.</param>
    public CategoryForm(CategoryController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dgvCategories.AutoGenerateColumns = false;
    }

    /// <summary>Tải dữ liệu khi form mở.</summary>
    private void CategoryForm_Load(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Tìm kiếm theo từ khóa đang nhập.</summary>
    private void btnSearch_Click(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Hiển thị dòng vừa chọn lên các ô nhập.</summary>
    private void dgvCategories_SelectionChanged(object sender, EventArgs e) => ShowCurrent();

    /// <summary>Bỏ chọn dòng hiện tại để nhập bản ghi mới.</summary>
    private void btnNew_Click(object sender, EventArgs e) => dgvCategories.ClearSelection();

    /// <summary>Lưu dữ liệu đang nhập.</summary>
    private void btnSave_Click(object sender, EventArgs e) => Ui.Run(this, Save);

    /// <summary>Xóa dòng đang chọn.</summary>
    private void btnDelete_Click(object sender, EventArgs e) => Ui.Run(this, Delete);

    /// <summary>Tải lại danh sách theo từ khóa hiện tại.</summary>
    private void Reload()
    {
        dgvCategories.DataSource = controller.GetAll(txtSearch.TextOrNull());
        ShowCurrent();
    }

    /// <summary>Cập nhật bản ghi đang chọn và hiển thị lên ô nhập.</summary>
    private void ShowCurrent()
    {
        current = dgvCategories.SelectedRows.Count > 0 ? dgvCategories.SelectedRows[0].DataBoundItem as Category : null;
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
    private void ShowItem(Category? item)
    {
        txtName.Text = item?.Name;
        txtDescription.Text = item?.Description;
    }

    /// <summary>Đọc các ô nhập thành model.</summary>
    /// <returns>Model chứa dữ liệu người dùng nhập.</returns>
    private Category ReadItem() => new()
    {
        Name = txtName.Text.Trim(),
        Description = txtDescription.TextOrNull()
    };
}
