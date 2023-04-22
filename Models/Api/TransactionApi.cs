namespace WalletAppBackend.Models.Api
{
    public class TransactionApi
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public byte[]? EncodedIconData { get; set; }
        public int? OwnerId { get; set; }
        public string? AuthorizedUserName { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
    }
}
