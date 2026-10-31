# CLAUDE.md

- Mỗi bài là một project độc lập trong folder riêng, có file `.sln` riêng; không dùng solution chung.
- Form phải mở được trong Form Designer của Visual Studio: mỗi form gồm `X.cs` và `X.Designer.cs`, kế thừa trực tiếp từ `Form`. Không dựng control bằng code, không dùng form generic. `InitializeComponent` chỉ chứa khai báo Designer hiểu được: không lambda, không helper; sự kiện gắn vào method có tên.
- Cấu trúc theo MVC: `Models/`, `Views/`, `Controllers/`, `Repositories/`, `Data/`. Dùng SQL thuần có tham số qua repository, không dùng ORM.
- Tên class và thuộc tính bằng tiếng Anh, XML doc comment và thông báo giao diện bằng tiếng Việt.
- WinForms không chạy được trên macOS: ở đây chỉ build được, giao diện cần kiểm tra trên Windows.
