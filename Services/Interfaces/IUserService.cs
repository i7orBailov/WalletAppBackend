using WalletAppBackend.Models.Api.User;
using WalletAppBackend.Models.Api.Response;

namespace WalletAppBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseMessage<IEnumerable<UserApi>>> GetAll();
        Task<ResponseMessage<int>> CreateNewUser(CreateUserApi userApiModel);
        Task UpdateDailyPointsForEachUser();
    }
}
