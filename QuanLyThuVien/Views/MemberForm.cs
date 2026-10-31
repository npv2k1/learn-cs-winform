using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình quản lý độc giả.</summary>
public partial class MemberForm : Form
{
    private readonly MemberController controller;

    /// <summary>Bản ghi đang chọn, <see langword="null"/> khi đang nhập mới.</summary>
    private Member? current;

    /// <summary>Tạo màn hình quản lý độc giả.</summary>
    /// <param name="controller">Controller độc giả.</param>
    public MemberForm(MemberController controller)
    {
        this.controller = controller;
        InitializeComponent();
        dgvMembers.AutoGenerateColumns = false;
    }

    /// <summary>Tải dữ liệu khi form mở.</summary>
    private void MemberForm_Load(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Tìm kiếm theo từ khóa đang nhập.</summary>
    private void btnSearch_Click(object sender, EventArgs e) => Ui.Run(this, Reload);

    /// <summary>Hiển thị dòng vừa chọn lên các ô nhập.</summary>
    private void dgvMembers_SelectionChanged(object sender, EventArgs e) => ShowCurrent();

    /// <summary>Bỏ chọn dòng hiện tại để nhập bản ghi mới.</summary>
    private void btnNew_Click(object sender, EventArgs e) => dgvMembers.ClearSelection();

    /// <summary>Lưu dữ liệu đang nhập.</summary>
    private void btnSave_Click(object sender, EventArgs e) => Ui.Run(this, Save);

    /// <summary>Xóa dòng đang chọn.</summary>
    private void btnDelete_Click(object sender, EventArgs e) => Ui.Run(this, Delete);

    /// <summary>Tải lại danh sách theo từ khóa hiện tại.</summary>
    private void Reload()
    {
        dgvMembers.DataSource = controller.GetAll(txtSearch.TextOrNull());
        ShowCurrent();
    }

    /// <summary>Cập nhật bản ghi đang chọn và hiển thị lên ô nhập.</summary>
    private void ShowCurrent()
    {
        current = dgvMembers.SelectedRows.Count > 0 ? dgvMembers.SelectedRows[0].DataBoundItem as Member : null;
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
    private void ShowItem(Member? item)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        txtMemberCode.Text = item?.MemberCode;
        txtFullName.Text = item?.FullName;
        txtPhone.Text = item?.Phone;
        txtEmail.Text = item?.Email;
        txtAddress.Text = item?.Address;
        dtpJoinedDate.SetDate(item?.JoinedDate ?? today);
        dtpExpiryDate.SetDate(item?.ExpiryDate ?? today.AddYears(1));
        chkIsActive.Checked = item?.IsActive ?? true;
    }

    /// <summary>Đọc các ô nhập thành model.</summary>
    /// <returns>Model chứa dữ liệu người dùng nhập.</returns>
    private Member ReadItem() => new()
    {
        MemberCode = txtMemberCode.Text.Trim(),
        FullName = txtFullName.Text.Trim(),
        Phone = txtPhone.TextOrNull(),
        Email = txtEmail.TextOrNull(),
        Address = txtAddress.TextOrNull(),
        JoinedDate = dtpJoinedDate.DateValue(),
        ExpiryDate = dtpExpiryDate.DateValue(),
        IsActive = chkIsActive.Checked
    };
}
