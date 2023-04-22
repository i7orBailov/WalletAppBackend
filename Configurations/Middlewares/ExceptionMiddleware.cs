using System.Text.Json;
using WalletAppBackend.Models.Database;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Models.Api.Response;
using WalletAppBackend.Repositories.Interfaces;

namespace WalletAppBackend.Configurations.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string stackTrace = ex.ToString();
                var repository = context.RequestServices.GetRequiredService<IBaseRepository<ExceptionJournal>>();
                var journalRecord = new ExceptionJournal
                {
                    EventId = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    QueryParams = context.Request.QueryString.ToString(),
                    BodyParams = await new StreamReader(context.Request.Body).ReadToEndAsync(),
                    StackTrace = stackTrace
                };

                await repository.AddAsync(journalRecord);

                Console.WriteLine($"Exception {journalRecord.EventId} occurred at {journalRecord.Timestamp}: {stackTrace}");
                Console.WriteLine(journalRecord.StackTrace);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";

                var responseContent = new ResponseMessageBase(isSuccessful: false, exception: new ExceptionData
                (
                    evenId: journalRecord.EventId,
                    exceptionMessage: ex is BusinessException ? ex.Message : $"Internal server error occurred."
                ));
                var responseContentJson = JsonSerializer.Serialize(responseContent.Details);
                await context.Response.WriteAsync(responseContentJson);
            }
        }
    }
}
