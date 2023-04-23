namespace WalletAppBackend.Models.Database
{
    public class TransactionStatus : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
