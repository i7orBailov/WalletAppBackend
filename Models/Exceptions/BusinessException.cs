namespace WalletAppBackend.Models.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message) : base(message)
        { }
    }
}
