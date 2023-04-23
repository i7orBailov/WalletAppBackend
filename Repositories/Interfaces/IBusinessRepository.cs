using System.Linq.Expressions;

namespace WalletAppBackend.Repositories.Interfaces
{
    public interface IBusinessRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize);
    }
}
