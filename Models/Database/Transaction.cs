namespace WalletAppBackend.Models.Database
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public string? Desctiption { get; set; }
        public DateTimeOffset Date { get; set; }

        public int? IconId { get; set; }
        public virtual Icon? Icon { get; set; }

        public int? OwnerId { get; set; }
        public virtual User? Owner { get; set; }

        public int? AuthorizedUserId { get; set; }
        public virtual User? AuthorizedUser { get; set; }

        public string? StatusTitle { get; set; }
        public virtual TransactionStatus? Status { get; set; }

        public string? TypeTitle { get; set; }
        public virtual TransactionType? Type { get; set; }
    }
}
