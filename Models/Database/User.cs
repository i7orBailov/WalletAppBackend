﻿namespace WalletAppBackend.Models.Database
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int DailyPoints { get; set; }
        public decimal Balance { get; set; }
        public decimal CardLimit { get; set; } = 1500;
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set;}
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
