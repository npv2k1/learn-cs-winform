using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

public class CategoryForm : CrudForm<Category>
{
    private readonly TextBox nameInput = new();
    private readonly TextBox descriptionInput = new() { Multiline = true, Height = 90 };

    public CategoryForm(CategoryController controller) : base(controller, "Thể loại")
    {
        Grid.AddColumn(nameof(Category.Name), "Tên thể loại");
        Grid.AddColumn(nameof(Category.Description), "Mô tả");

        AddField("Tên thể loại", nameInput);
        AddField("Mô tả", descriptionInput);
    }

    protected override void ShowItem(Category? item)
    {
        nameInput.Text = item?.Name;
        descriptionInput.Text = item?.Description;
    }

    protected override Category ReadItem() => new()
    {
        Name = nameInput.Text.Trim(),
        Description = descriptionInput.TextOrNull()
    };
}
