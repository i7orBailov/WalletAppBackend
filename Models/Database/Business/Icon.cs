namespace WalletAppBackend.Models.Database.Business
{
    public class Icon : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
    }
}
