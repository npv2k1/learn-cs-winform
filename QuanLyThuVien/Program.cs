using QuanLyThuVien.Controllers;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;
using QuanLyThuVien.Views;

namespace QuanLyThuVien;

static class Program
{
    private const string ConnectionStringVariable = "LIBRARY_DB_CONNECTION";
    private const string DefaultConnectionString =
        "Server=127.0.0.1,1433;Database=LibraryDb;User Id=sa;Password=Dev_Passw0rd!;TrustServerCertificate=True";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(CreateControllers()));
    }

    private static AppControllers CreateControllers()
    {
        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringVariable) ?? DefaultConnectionString;
        var connectionFactory = new SqlConnectionFactory(connectionString);

        var categories = new CategoryRepository(connectionFactory);
        var authors = new AuthorRepository(connectionFactory);
        var publishers = new PublisherRepository(connectionFactory);
        var books = new BookRepository(connectionFactory);
        var members = new MemberRepository(connectionFactory);
        var loans = new LoanRepository(connectionFactory);

        return new AppControllers(
            new CategoryController(categories),
            new AuthorController(authors),
            new PublisherController(publishers),
            new BookController(books, categories, publishers, authors),
            new MemberController(members),
            new LoanController(loans, members, books));
    }
}
