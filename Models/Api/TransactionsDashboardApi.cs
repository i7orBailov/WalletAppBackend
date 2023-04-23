﻿using WalletAppBackend.Models.Enums;

namespace WalletAppBackend.Models.Api
{
    public class TransactionsDashboardApi
    {
        public TransactionsDashboardApi()
        {
            Month month = (Month)DateTime.UtcNow.Month;
            NoPaymentDue = $"You`ve paid your {month} balance.";
        }

        public string? NoPaymentDue { get; set; }
        public int DailyPoints { get; set; }
        public decimal Balance { get; set; }
        public decimal CardLimit { get; set; }
    }
}
