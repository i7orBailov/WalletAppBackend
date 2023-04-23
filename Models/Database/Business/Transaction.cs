namespace WalletAppBackend.Models.Database.Business
{
    public class Transaction : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset Date { get; set; }

        public int? IconId { get; set; }
        public virtual Icon? Icon { get; set; }

        public int? OwnerId { get; set; }
        public virtual User? Owner { get; set; }

        public int? AuthorizedUserId { get; set; }
        public virtual User? AuthorizedUser { get; set; }

        public int? StatusId { get; set; }
        public virtual TransactionStatus? Status { get; set; }

        public string? TypeTitle { get; set; }
        public virtual TransactionType? Type { get; set; }
    }
}
