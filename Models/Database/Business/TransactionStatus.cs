namespace WalletAppBackend.Models.Database.Business
{
    public class TransactionStatus : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
