using AutoMapper;
using WalletAppBackend.Models.Api;
using WalletAppBackend.Models.Database;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Models.Api.Response;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Repositories.Interfaces;

namespace WalletAppBackend.Services.Business
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessage<IEnumerable<UserApi>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Any() is false)
            {
                throw new BusinessException("Currently, list of users is empty.");
            }
            var userApiModel = _mapper.Map<IEnumerable<User>, IEnumerable<UserApi>>(users);
            return new ResponseMessage<IEnumerable<UserApi>>(isSuccessful: true, userApiModel);
        }

        public async Task<ResponseMessage<int>> CreateNewUser(CreateUserApi userApiModel)
        {
            var salt = PasswordService.GenerateSalt();
            var generatedPasswordHash = PasswordService.GeneratePasswordHash(
                userApiModel.Password ?? throw new BusinessException("Password should not be null"),
                salt);
            var userDbModel = _mapper.Map<CreateUserApi, User>(userApiModel);
            userDbModel.PasswordHash = generatedPasswordHash;
            userDbModel.PasswordSalt = salt;
            var savedUserDbModel = await _userRepository.AddAsync(userDbModel);
            return new ResponseMessage<int>(isSuccessful: true, savedUserDbModel.Id);
        }
    }
}
