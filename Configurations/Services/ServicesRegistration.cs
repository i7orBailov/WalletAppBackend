using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WalletAppBackend.Services.Business;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Repositories.Business;
using WalletAppBackend.Repositories.Interfaces;
using WalletAppBackend.Models.Database.Business;
using WalletAppBackend.Models.Database.Exception;

namespace WalletAppBackend.Configurations.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped(typeof(IBusinessRepository<>), typeof(BusinessRepository<>));
            services.AddScoped(typeof(IExceptionRepository<>), typeof(ExceptionRepository<>));

            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BusinessDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BusinessDb"));
                options.UseLazyLoadingProxies();
            });

            services.AddDbContext<ExceptionDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ExceptionDb"),
                    sqlOptions => sqlOptions.MigrationsHistoryTable(tableName: "__ExceptionMigrationsHistory", schema: "Exception")
                                            .MigrationsAssembly(typeof(ExceptionDbContext).Assembly.FullName));
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IDatabaseSeeder, DatabaseDataSeeder>();

            return services;
        }

        public static IServiceCollection RegisterSchedulers(this IServiceCollection services)
        {
            services.AddHostedService<DailyPointsScheduler>();

            return services;
        }
    }
}
