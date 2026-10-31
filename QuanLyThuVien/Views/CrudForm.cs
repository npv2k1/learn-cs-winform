using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Khung chung của màn hình danh mục: tìm kiếm, danh sách bên trái, form nhập bên phải.</summary>
/// <remarks>
/// Lớp con khai báo cột, ô nhập và cách chuyển đổi giữa ô nhập với model.
/// Form được dựng bằng code nên không mở được trong Form Designer.
/// </remarks>
/// <typeparam name="T">Kiểu thực thể hiển thị trên form.</typeparam>
public abstract class CrudForm<T> : Form where T : EntityBase
{
    private readonly CrudController<T> controller;
    private readonly DataGridView grid = Ui.CreateGrid();
    private readonly TextBox searchBox = new() { Dock = DockStyle.Fill };
    private readonly TableLayoutPanel fields = new()
    {
        Dock = DockStyle.Fill,
        ColumnCount = 2,
        AutoScroll = true,
        Padding = new Padding(8)
    };

    /// <summary>Bản ghi đang chọn, <see langword="null"/> khi đang nhập mới.</summary>
    private T? current;

    /// <summary>Tạo khung màn hình danh mục.</summary>
    /// <param name="controller">Controller xử lý nghiệp vụ của thực thể.</param>
    /// <param name="title">Tiêu đề cửa sổ.</param>
    protected CrudForm(CrudController<T> controller, string title)
    {
        this.controller = controller;

        Text = title;
        Width = 1000;
        Height = 600;
        StartPosition = FormStartPosition.CenterParent;

        fields.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        Controls.Add(CreateListPanel());
        Controls.Add(CreateEditPanel());

        grid.SelectionChanged += (_, _) => OnSelectionChanged();
    }

    /// <summary>Bảng danh sách, để lớp con khai báo cột.</summary>
    protected DataGridView Grid => grid;

    /// <summary>Nạp danh sách chọn và dữ liệu khi form mở.</summary>
    /// <param name="e">Dữ liệu sự kiện.</param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Ui.Run(this, () =>
        {
            LoadLookups();
            Reload();
        });
    }

    /// <summary>Nạp dữ liệu cho các ô chọn. Mặc định không làm gì.</summary>
    protected virtual void LoadLookups()
    {
    }

    /// <summary>Đưa dữ liệu của bản ghi lên các ô nhập.</summary>
    /// <param name="item">Bản ghi cần hiển thị; <see langword="null"/> để xóa trắng và nhập mới.</param>
    protected abstract void ShowItem(T? item);

    /// <summary>Đọc các ô nhập thành model.</summary>
    /// <remarks>
    /// Lớp con không cần gán <see cref="EntityBase.Id"/>; lớp cơ sở sẽ gán khi lưu.
    /// </remarks>
    /// <returns>Model chứa dữ liệu người dùng nhập.</returns>
    protected abstract T ReadItem();

    /// <summary>Thêm một dòng nhãn và ô nhập vào form.</summary>
    /// <param name="label">Nội dung nhãn.</param>
    /// <param name="input">Ô nhập.</param>
    protected void AddField(string label, Control input)
    {
        input.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

        var row = fields.RowCount++;
        fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        fields.Controls.Add(new Label { Text = label, AutoSize = true, Margin = new Padding(3, 6, 8, 3) }, 0, row);
        fields.Controls.Add(input, 1, row);
    }

    /// <summary>Dựng khu vực tìm kiếm và danh sách.</summary>
    /// <returns>Panel chứa khu vực danh sách.</returns>
    private Panel CreateListPanel()
    {
        var searchButton = new Button { Text = "Tìm", Dock = DockStyle.Right, Width = 80 };
        searchButton.Click += (_, _) => Ui.Run(this, Reload);

        var searchPanel = new Panel { Dock = DockStyle.Top, Height = 32, Padding = new Padding(0, 0, 0, 6) };
        searchPanel.Controls.Add(searchBox);
        searchPanel.Controls.Add(searchButton);

        var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(8) };
        panel.Controls.Add(grid);
        panel.Controls.Add(searchPanel);
        return panel;
    }

    /// <summary>Dựng khu vực ô nhập và các nút thao tác.</summary>
    /// <returns>Panel chứa khu vực nhập liệu.</returns>
    private Panel CreateEditPanel()
    {
        var newButton = new Button { Text = "Thêm mới", AutoSize = true };
        var saveButton = new Button { Text = "Lưu", AutoSize = true };
        var deleteButton = new Button { Text = "Xóa", AutoSize = true };

        newButton.Click += (_, _) => grid.ClearSelection();
        saveButton.Click += (_, _) => Ui.Run(this, Save);
        deleteButton.Click += (_, _) => Ui.Run(this, Delete);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 44, Padding = new Padding(8, 4, 8, 4) };
        buttons.Controls.AddRange([newButton, saveButton, deleteButton]);

        var panel = new Panel { Dock = DockStyle.Right, Width = 400 };
        panel.Controls.Add(fields);
        panel.Controls.Add(buttons);
        return panel;
    }

    /// <summary>Cập nhật bản ghi đang chọn và hiển thị lên ô nhập.</summary>
    private void OnSelectionChanged()
    {
        current = grid.SelectedRows.Count > 0 ? grid.SelectedRows[0].DataBoundItem as T : null;
        ShowItem(current);
    }

    /// <summary>Tải lại danh sách theo từ khóa hiện tại.</summary>
    private void Reload()
    {
        grid.DataSource = controller.GetAll(searchBox.TextOrNull());
        OnSelectionChanged();
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
}
