namespace WalletAppBackend.Repositories.Interfaces
{
    public interface IExceptionRepository<T>
    {
        Task LogAsync(T entity);
    }
}
