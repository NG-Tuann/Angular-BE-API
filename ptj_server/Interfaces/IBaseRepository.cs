using System.Linq.Expressions;

namespace ptj_server.Interfaces;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Entities { get; }

    Task<T> GetByIdAsync(object id);

    Task<T> GetByAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "");

    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetListByAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "");

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);
      
    Task DeleteAsync(object id);

    int Add(T entity);
}