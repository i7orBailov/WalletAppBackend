namespace WalletAppBackend.Models.Api.Response
{
    public class ResponseMessageBase
    {
        public ResponseMessageBase(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        public ResponseMessageBase(bool isSuccessful, ExceptionData exception)
            : this(isSuccessful)
        {
            Details = exception;
        }

        public bool IsSuccessful { get; set; }
        public ExceptionData? Details { get; set; }
    }
}
