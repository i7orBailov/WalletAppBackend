using AutoMapper;
using WalletAppBackend.Services.Business;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Repositories.Business;
using WalletAppBackend.Repositories.Interfaces;

namespace WalletAppBackend.Configurations.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

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
    }
}
