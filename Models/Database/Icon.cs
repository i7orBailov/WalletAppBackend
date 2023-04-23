namespace WalletAppBackend.Models.Database
{
    public class Icon : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
    }
}
