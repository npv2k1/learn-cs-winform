using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>
/// Khung chung của màn hình danh mục: tìm kiếm, danh sách bên trái, form nhập bên phải.
/// Lớp con khai báo cột, ô nhập và cách chuyển đổi giữa ô nhập với model.
/// </summary>
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

    private T? current;

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

    protected DataGridView Grid => grid;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Ui.Run(this, () =>
        {
            LoadLookups();
            Reload();
        });
    }

    protected virtual void LoadLookups()
    {
    }

    /// <summary>Đưa dữ liệu của <paramref name="item"/> lên ô nhập; null là xóa trắng để nhập mới.</summary>
    protected abstract void ShowItem(T? item);

    protected abstract T ReadItem();

    protected void AddField(string label, Control input)
    {
        input.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

        var row = fields.RowCount++;
        fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        fields.Controls.Add(new Label { Text = label, AutoSize = true, Margin = new Padding(3, 6, 8, 3) }, 0, row);
        fields.Controls.Add(input, 1, row);
    }

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

    private void OnSelectionChanged()
    {
        current = grid.SelectedRows.Count > 0 ? grid.SelectedRows[0].DataBoundItem as T : null;
        ShowItem(current);
    }

    private void Reload()
    {
        grid.DataSource = controller.GetAll(searchBox.TextOrNull());
        OnSelectionChanged();
    }

    private void Save()
    {
        var item = ReadItem();
        item.Id = current?.Id ?? 0;
        controller.Save(item);
        Reload();
    }

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
