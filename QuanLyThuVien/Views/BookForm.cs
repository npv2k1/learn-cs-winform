using QuanLyThuVien.Controllers;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Views;

public class BookForm : CrudForm<Book>
{
    private readonly BookController controller;
    private readonly TextBox isbnInput = new();
    private readonly TextBox titleInput = new();
    private readonly ComboBox categoryInput = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox publisherInput = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly NumericUpDown publishedYearInput = Ui.CreateYearInput();
    private readonly NumericUpDown totalCopiesInput = new() { Minimum = 0, Maximum = 100000 };
    private readonly CheckedListBox authorsInput = new() { Height = 130, CheckOnClick = true };

    public BookForm(BookController controller) : base(controller, "Sách")
    {
        this.controller = controller;

        Grid.AddColumn(nameof(Book.Title), "Tên sách");
        Grid.AddColumn(nameof(Book.AuthorNames), "Tác giả");
        Grid.AddColumn(nameof(Book.CategoryName), "Thể loại");
        Grid.AddColumn(nameof(Book.PublisherName), "Nhà xuất bản");
        Grid.AddColumn(nameof(Book.AvailableCopies), "Còn lại");
        Grid.AddColumn(nameof(Book.TotalCopies), "Tổng số");

        AddField("Tên sách", titleInput);
        AddField("ISBN", isbnInput);
        AddField("Thể loại", categoryInput);
        AddField("Nhà xuất bản", publisherInput);
        AddField("Năm xuất bản", publishedYearInput);
        AddField("Tổng số bản", totalCopiesInput);
        AddField("Tác giả", authorsInput);
    }

    protected override void LoadLookups()
    {
        categoryInput.DisplayMember = nameof(Category.Name);
        categoryInput.ValueMember = nameof(Category.Id);
        categoryInput.DataSource = controller.GetCategories();

        // Dòng Id = 0 ứng với sách không có nhà xuất bản
        publisherInput.DisplayMember = nameof(Publisher.Name);
        publisherInput.ValueMember = nameof(Publisher.Id);
        publisherInput.DataSource = controller.GetPublishers().Prepend(new Publisher { Name = "(Không có)" }).ToList();

        authorsInput.DisplayMember = nameof(Author.FullName);
        authorsInput.Items.Clear();
        authorsInput.Items.AddRange(controller.GetAuthors().ToArray<object>());
    }

    protected override void ShowItem(Book? item)
    {
        titleInput.Text = item?.Title;
        isbnInput.Text = item?.Isbn;
        publishedYearInput.Value = item?.PublishedYear ?? 0;
        totalCopiesInput.Value = item?.TotalCopies ?? 0;
        publisherInput.SelectedValue = item?.PublisherId ?? 0;

        if (item is not null)
            categoryInput.SelectedValue = item.CategoryId;

        for (var i = 0; i < authorsInput.Items.Count; i++)
        {
            var author = (Author)authorsInput.Items[i];
            authorsInput.SetItemChecked(i, item?.AuthorIds.Contains(author.Id) == true);
        }
    }

    protected override Book ReadItem() => new()
    {
        Title = titleInput.Text.Trim(),
        Isbn = isbnInput.TextOrNull(),
        CategoryId = categoryInput.SelectedValue as int? ?? 0,
        PublisherId = publisherInput.SelectedValue is int and not 0 ? (int)publisherInput.SelectedValue : null,
        PublishedYear = publishedYearInput.YearOrNull(),
        TotalCopies = (int)totalCopiesInput.Value,
        AuthorIds = authorsInput.CheckedItems.Cast<Author>().Select(author => author.Id).ToList()
    };
}
