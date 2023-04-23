namespace WalletAppBackend.Models.Api.Transaction
{
    public class TransactionsListDashboardApi
    {
        public TransactionsDashboardApi? Dashboard { get; set; }
        public List<TransactionApi>? LatestTransactions { get; set; }
    }
}
