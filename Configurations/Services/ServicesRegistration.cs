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
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
