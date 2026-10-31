using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình quản lý tác giả.</summary>
public partial class AuthorForm : Form
{
    private readonly AuthorController controller;

    /// <summary>Bản ghi đang chọn, <see langword="null"/> khi đang nhập mới.</summary>
    private Author? current;

    /// <summary>Tạo màn hình quản lý tác giả.</summary>
    /// <param name="controller">Controller tác giả.</param>
    public AuthorForm(AuthorController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dgvAuthors.AutoGenerateColumns = false;
    }

    /// <summary>Tải dữ liệu khi form mở.</summary>
    private void AuthorForm_Load(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Tìm kiếm theo từ khóa đang nhập.</summary>
    private void btnSearch_Click(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Hiển thị dòng vừa chọn lên các ô nhập.</summary>
    private void dgvAuthors_SelectionChanged(object sender, EventArgs e) => ShowCurrent();

    /// <summary>Bỏ chọn dòng hiện tại để nhập bản ghi mới.</summary>
    private void btnNew_Click(object sender, EventArgs e) => dgvAuthors.ClearSelection();

    /// <summary>Lưu dữ liệu đang nhập.</summary>
    private void btnSave_Click(object sender, EventArgs e) => Ui.Run(this, Save);

    /// <summary>Xóa dòng đang chọn.</summary>
    private void btnDelete_Click(object sender, EventArgs e) => Ui.Run(this, Delete);

    /// <summary>Tải lại danh sách theo từ khóa hiện tại.</summary>
    private void Reload()
    {
        dgvAuthors.DataSource = controller.GetAll(txtSearch.TextOrNull());
        ShowCurrent();
    }

    /// <summary>Cập nhật bản ghi đang chọn và hiển thị lên ô nhập.</summary>
    private void ShowCurrent()
    {
        current = dgvAuthors.SelectedRows.Count > 0 ? dgvAuthors.SelectedRows[0].DataBoundItem as Author : null;
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
    private void ShowItem(Author? item)
    {
        txtFullName.Text = item?.FullName;
        nudBirthYear.Value = item?.BirthYear ?? 0;
        txtBiography.Text = item?.Biography;
    }

    /// <summary>Đọc các ô nhập thành model.</summary>
    /// <returns>Model chứa dữ liệu người dùng nhập.</returns>
    private Author ReadItem() => new()
    {
        FullName = txtFullName.Text.Trim(),
        BirthYear = nudBirthYear.YearOrNull(),
        Biography = txtBiography.TextOrNull()
    };
}
