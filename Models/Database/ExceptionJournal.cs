namespace WalletAppBackend.Models.Database
{
    public class ExceptionJournal : IExceptionDbEntity
    {
        public string? EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public string? QueryParams { get; set; }
        public string? BodyParams { get; set; }
        public string? StackTrace { get; set; }
    }
}
