using QuanLyThuVien.Controllers;

namespace QuanLyThuVien.Views;

public class MainForm : Form
{
    public MainForm(AppControllers controllers)
    {
        Text = "Quản lý thư viện";
        Width = 800;
        Height = 500;
        StartPosition = FormStartPosition.CenterScreen;

        var catalogMenu = new ToolStripMenuItem("Danh mục");
        catalogMenu.DropDownItems.Add(CreateMenuItem("Sách", () => new BookForm(controllers.Books)));
        catalogMenu.DropDownItems.Add(CreateMenuItem("Thể loại", () => new CategoryForm(controllers.Categories)));
        catalogMenu.DropDownItems.Add(CreateMenuItem("Tác giả", () => new AuthorForm(controllers.Authors)));
        catalogMenu.DropDownItems.Add(CreateMenuItem("Nhà xuất bản", () => new PublisherForm(controllers.Publishers)));

        var menu = new MenuStrip();
        menu.Items.Add(catalogMenu);
        menu.Items.Add(CreateMenuItem("Độc giả", () => new MemberForm(controllers.Members)));
        menu.Items.Add(CreateMenuItem("Mượn trả", () => new LoanForm(controllers.Loans)));

        MainMenuStrip = menu;
        Controls.Add(menu);
    }

    private ToolStripMenuItem CreateMenuItem(string text, Func<Form> createForm)
    {
        var item = new ToolStripMenuItem(text);
        item.Click += (_, _) =>
        {
            using var form = createForm();
            form.ShowDialog(this);
        };
        return item;
    }
}
