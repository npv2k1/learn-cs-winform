using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

public class MemberForm : CrudForm<Member>
{
    private readonly TextBox memberCodeInput = new();
    private readonly TextBox fullNameInput = new();
    private readonly TextBox phoneInput = new();
    private readonly TextBox emailInput = new();
    private readonly TextBox addressInput = new();
    private readonly DateTimePicker joinedDateInput = new() { Format = DateTimePickerFormat.Short };
    private readonly DateTimePicker expiryDateInput = new() { Format = DateTimePickerFormat.Short };
    private readonly CheckBox isActiveInput = new() { Text = "Đang hoạt động" };

    public MemberForm(MemberController controller) : base(controller, "Độc giả")
    {
        Grid.AddColumn(nameof(Member.MemberCode), "Mã thẻ");
        Grid.AddColumn(nameof(Member.FullName), "Họ tên");
        Grid.AddColumn(nameof(Member.Phone), "Điện thoại");
        Grid.AddColumn(nameof(Member.ExpiryDate), "Hết hạn");

        AddField("Mã thẻ", memberCodeInput);
        AddField("Họ tên", fullNameInput);
        AddField("Điện thoại", phoneInput);
        AddField("Email", emailInput);
        AddField("Địa chỉ", addressInput);
        AddField("Ngày cấp thẻ", joinedDateInput);
        AddField("Ngày hết hạn", expiryDateInput);
        AddField("Trạng thái", isActiveInput);
    }

    protected override void ShowItem(Member? item)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        memberCodeInput.Text = item?.MemberCode;
        fullNameInput.Text = item?.FullName;
        phoneInput.Text = item?.Phone;
        emailInput.Text = item?.Email;
        addressInput.Text = item?.Address;
        joinedDateInput.SetDate(item?.JoinedDate ?? today);
        expiryDateInput.SetDate(item?.ExpiryDate ?? today.AddYears(1));
        isActiveInput.Checked = item?.IsActive ?? true;
    }

    protected override Member ReadItem() => new()
    {
        MemberCode = memberCodeInput.Text.Trim(),
        FullName = fullNameInput.Text.Trim(),
        Phone = phoneInput.TextOrNull(),
        Email = emailInput.TextOrNull(),
        Address = addressInput.TextOrNull(),
        JoinedDate = joinedDateInput.DateValue(),
        ExpiryDate = expiryDateInput.DateValue(),
        IsActive = isActiveInput.Checked
    };
}
