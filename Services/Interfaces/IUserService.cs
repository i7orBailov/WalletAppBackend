using WalletAppBackend.Models.Api;
using WalletAppBackend.Models.Api.Response;

namespace WalletAppBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseMessage<IEnumerable<UserApi>>> GetAll();
        Task<ResponseMessage<int>> CreateNewUser(CreateUserApi userApiModel);
    }
}
