using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

public class PublisherForm : CrudForm<Publisher>
{
    private readonly TextBox nameInput = new();
    private readonly TextBox addressInput = new();
    private readonly TextBox phoneInput = new();

    public PublisherForm(PublisherController controller) : base(controller, "Nhà xuất bản")
    {
        Grid.AddColumn(nameof(Publisher.Name), "Tên nhà xuất bản");
        Grid.AddColumn(nameof(Publisher.Address), "Địa chỉ");
        Grid.AddColumn(nameof(Publisher.Phone), "Điện thoại");

        AddField("Tên", nameInput);
        AddField("Địa chỉ", addressInput);
        AddField("Điện thoại", phoneInput);
    }

    protected override void ShowItem(Publisher? item)
    {
        nameInput.Text = item?.Name;
        addressInput.Text = item?.Address;
        phoneInput.Text = item?.Phone;
    }

    protected override Publisher ReadItem() => new()
    {
        Name = nameInput.Text.Trim(),
        Address = addressInput.TextOrNull(),
        Phone = phoneInput.TextOrNull()
    };
}
