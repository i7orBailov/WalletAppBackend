namespace WalletAppBackend.Models.Api
{
    public class TransactionsListDashboardApi
    {
        public TransactionsDashboardApi? Dashboard { get; set; }
        public List<TransactionApi>? LatestTransactions { get; set; }
    }
}
