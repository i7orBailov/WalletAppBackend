using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Configurations.Middlewares
{
    public class DatabaseDataSeederMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseDataSeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
            await seeder.SeedDataAsync();

            await _next(context);
        }
    }
}
