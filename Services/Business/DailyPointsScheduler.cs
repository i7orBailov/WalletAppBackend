using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Business
{
    public class DailyPointsScheduler : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public DailyPointsScheduler(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var usersService = scope.ServiceProvider.GetRequiredService<IUserService>();
                await usersService.UpdateDailyPointsForEachUser();

                var daysInterval = _configuration.GetValue<int>("Scheduler:DailyPointsDaysInterval");
                
                var now = DateTime.UtcNow;

                // add 1 Hour to ensure that task is run at 1:00 AM in the server's timezone.
                var nextRun = now.Date.AddDays(daysInterval).AddHours(1);

                var delay = nextRun - now;
                if (delay < TimeSpan.Zero)
                {
                    delay = TimeSpan.Zero;
                }

                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
