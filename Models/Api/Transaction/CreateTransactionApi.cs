namespace WalletAppBackend.Models.Api.Transaction
{
    public class CreateTransactionApi
    {
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public int? IconId { get; set; }
        public int? OwnerId { get; set; }
        public int? AuthorizedUserId { get; set; }
        public int? StatusId { get; set; }
        public string? TypeTitle { get; set; }
    }
}
