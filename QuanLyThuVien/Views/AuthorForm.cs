using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

public class AuthorForm : CrudForm<Author>
{
    private readonly TextBox fullNameInput = new();
    private readonly NumericUpDown birthYearInput = Ui.CreateYearInput();
    private readonly TextBox biographyInput = new() { Multiline = true, Height = 120 };

    public AuthorForm(AuthorController controller) : base(controller, "Tác giả")
    {
        Grid.AddColumn(nameof(Author.FullName), "Họ tên");
        Grid.AddColumn(nameof(Author.BirthYear), "Năm sinh");

        AddField("Họ tên", fullNameInput);
        AddField("Năm sinh", birthYearInput);
        AddField("Tiểu sử", biographyInput);
    }

    protected override void ShowItem(Author? item)
    {
        fullNameInput.Text = item?.FullName;
        birthYearInput.Value = item?.BirthYear ?? 0;
        biographyInput.Text = item?.Biography;
    }

    protected override Author ReadItem() => new()
    {
        FullName = fullNameInput.Text.Trim(),
        BirthYear = birthYearInput.YearOrNull(),
        Biography = biographyInput.TextOrNull()
    };
}
