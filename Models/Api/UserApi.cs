namespace WalletAppBackend.Models.Api
{
    public class UserApi
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int DailyPoints { get; set; }
        public decimal Balance { get; set; }
        public decimal CardLimit { get; set; }
    }
}
