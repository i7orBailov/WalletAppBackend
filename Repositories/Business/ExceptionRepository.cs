using WalletAppBackend.Repositories.Interfaces;
using WalletAppBackend.Models.Database.Exception;

namespace WalletAppBackend.Repositories.Business
{
    public class ExceptionRepository<T> : IExceptionRepository<T> where T : class, IExceptionDbEntity
    {
        private readonly ExceptionDbContext _context;

        public ExceptionRepository(ExceptionDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
