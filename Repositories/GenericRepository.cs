using DataAccessLayer;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public abstract class GenericRepository<T, TKey>(DashboardContext dashboardContext) : IGenericRepository<T, TKey> where T : EntityBase<TKey>
  where TKey : IEquatable<TKey>
{

  private readonly DashboardContext _context = dashboardContext;

  protected DashboardContext Context { get => _context; }

  public async Task<T> Add(T entity)
  {
    _context.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<T?> GetById(TKey key)
  {
    var entity = await _context.Set<T>().FindAsync(key);
    return entity;
  }

  public async Task<IEnumerable<T>> GetAll()
  {
    var entities = await _context.Set<T>().ToListAsync();
    return entities;
  }

  //public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] inc)
  //{
  //  var entities = await _context.Set<T>().Where(predicate).ToListAsync();
  //  return entities;
  //}

  public async Task<bool> InsertOrUpdate(T entity)
  {
    _context.Entry(entity).State = entity.Id.Equals(default(TKey)) ? EntityState.Added : EntityState.Modified;
    var result = await _context.SaveChangesAsync();
    return result > 0;
  }



}
