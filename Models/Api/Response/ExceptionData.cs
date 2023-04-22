namespace WalletAppBackend.Models.Api.Response
{
    public class ExceptionData
    {
        public ExceptionData(string evenId, string exceptionMessage)
        {
            EventId = evenId;
            Message = exceptionMessage;
        }

        public string EventId { get; set; }
        public string Message { get; set; }
    }
}
