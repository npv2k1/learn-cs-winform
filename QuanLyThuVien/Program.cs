using QuanLyThuVien.Controllers;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;
using QuanLyThuVien.Views;

namespace QuanLyThuVien;

/// <summary>Điểm khởi động của ứng dụng, nơi ghép các lớp với nhau.</summary>
static class Program
{
    /// <summary>Tên biến môi trường dùng để đổi connection string.</summary>
    private const string ConnectionStringVariable = "LIBRARY_DB_CONNECTION";
    /// <summary>Connection string mặc định, trỏ tới SQL Server trong <c>docker-compose.yml</c>.</summary>
    private const string DefaultConnectionString =
        "Server=127.0.0.1,1433;Database=LibraryDb;User Id=sa;Password=Dev_Passw0rd!;TrustServerCertificate=True";

    /// <summary>Điểm vào của ứng dụng.</summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(CreateControllers()));
    }

    /// <summary>Tạo repository và controller từ connection string hiện tại.</summary>
    /// <returns>Các controller đã sẵn sàng sử dụng.</returns>
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
