namespace WalletAppBackend.Configurations.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseDataSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseDataSeederMiddleware>();
        }

        public static IApplicationBuilder UseException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
