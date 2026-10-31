using Microsoft.Data.SqlClient;
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

        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringVariable) ?? DefaultConnectionString;
        if (!TryInitializeDatabase(connectionString))
            return;

        Application.Run(new MainForm(CreateControllers(connectionString)));
    }

    /// <summary>Khởi tạo database, báo lỗi lên màn hình nếu không thành công.</summary>
    /// <param name="connectionString">Connection string của ứng dụng.</param>
    /// <returns><see langword="true"/> nếu database đã sẵn sàng để sử dụng.</returns>
    private static bool TryInitializeDatabase(string connectionString)
    {
        try
        {
            new DatabaseInitializer(connectionString).Run();
            return true;
        }
        catch (SqlException ex)
        {
            MessageBox.Show(
                $"Không khởi tạo được database. Hãy kiểm tra SQL Server đã chạy chưa.\n\n{ex.Message}",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
    }

    /// <summary>Tạo repository và controller từ connection string đã cho.</summary>
    /// <param name="connectionString">Connection string của ứng dụng.</param>
    /// <returns>Các controller đã sẵn sàng sử dụng.</returns>
    private static AppControllers CreateControllers(string connectionString)
    {
        var connectionFactory = new SqlConnectionFactory(connectionString);

        var categories = new CategoryRepository(connectionFactory);
        var authors = new AuthorRepository(connectionFactory);
        var publishers = new PublisherRepository(connectionFactory);
        var books = new BookRepository(connectionFactory);
        var members = new MemberRepository(connectionFactory);
        var loans = new LoanRepository(connectionFactory);
        var statistics = new StatisticsRepository(connectionFactory);

        return new AppControllers(
            new CategoryController(categories),
            new AuthorController(authors),
            new PublisherController(publishers),
            new BookController(books, categories, publishers, authors),
            new MemberController(members),
            new LoanController(loans, members, books),
            new StatisticsController(statistics));
    }
}
