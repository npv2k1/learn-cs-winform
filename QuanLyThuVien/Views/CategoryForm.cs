using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

/// <summary>Màn hình quản lý thể loại.</summary>
public class CategoryForm : CrudForm<Category>
{
    private readonly TextBox nameInput = new();
    private readonly TextBox descriptionInput = new() { Multiline = true, Height = 90 };

    /// <summary>Tạo màn hình quản lý thể loại.</summary>
    /// <param name="controller">Controller thể loại.</param>
    public CategoryForm(CategoryController controller) : base(controller, "Thể loại")
    {
        Grid.AddColumn(nameof(Category.Name), "Tên thể loại");
        Grid.AddColumn(nameof(Category.Description), "Mô tả");

        AddField("Tên thể loại", nameInput);
        AddField("Mô tả", descriptionInput);
    }

    /// <inheritdoc/>
    protected override void ShowItem(Category? item)
    {
        nameInput.Text = item?.Name;
        descriptionInput.Text = item?.Description;
    }

    /// <inheritdoc/>
    protected override Category ReadItem() => new()
    {
        Name = nameInput.Text.Trim(),
        Description = descriptionInput.TextOrNull()
    };
}
