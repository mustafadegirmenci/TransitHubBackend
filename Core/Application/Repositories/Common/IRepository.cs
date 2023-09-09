using System.Linq.Expressions;

namespace Application.Repositories.Common;

public interface IRepository<T> where T : class
{
    public Task<T> GetByIdAsync(object id);
    public Task<IEnumerable<T>> GetAllAsync();
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    public Task AddAsync(T entity);
    public void Update(T entity);
    public void Remove(T entity);
    public Task SaveChangesAsync();
}