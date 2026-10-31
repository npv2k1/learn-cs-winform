using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers;

public abstract class CrudController<T>(IRepository<T> repository) where T : EntityBase
{
    public List<T> GetAll(string? keyword = null) => repository.GetAll(keyword);

    public void Save(T item)
    {
        Validate(item);

        if (item.Id == 0)
            repository.Add(item);
        else
            repository.Update(item);
    }

    public void Delete(T item) => repository.Delete(item.Id);

    protected abstract void Validate(T item);

    protected static void Require(string? value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new BusinessException(message);
    }
}
