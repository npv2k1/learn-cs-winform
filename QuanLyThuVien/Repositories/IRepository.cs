using QuanLyThuVien.Models;

namespace QuanLyThuVien.Repositories;

public interface IRepository<T> where T : EntityBase
{
    List<T> GetAll(string? keyword = null);
    void Add(T item);
    void Update(T item);
    void Delete(int id);
}
