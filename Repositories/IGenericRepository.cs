using DomainModels;

namespace Repositories
{
  public interface IGenericRepository<T, TKey>
    where T : EntityBase<TKey>
    where TKey : IEquatable<TKey>
  {
    Task<T> Add(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(TKey key);
    Task<bool> InsertOrUpdate(T entity);
  }
}