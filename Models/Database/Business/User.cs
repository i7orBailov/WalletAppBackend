namespace WalletAppBackend.Models.Database.Business
{
    public class User : IBusinessDbEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int DailyPoints { get; set; } = default;
        public decimal Balance { get; set; }
        public decimal CardLimit { get; set; } = 1500;
        public string? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
