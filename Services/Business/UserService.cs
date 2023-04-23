using AutoMapper;
using WalletAppBackend.Models.Api.User;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Models.Api.Response;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Repositories.Interfaces;
using WalletAppBackend.Models.Database.Business;

namespace WalletAppBackend.Services.Business
{
    public class UserService : IUserService
    {
        private readonly IBusinessRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ISeasonService _seasonService;
        private readonly IConfiguration _configuration;

        public UserService(
            IBusinessRepository<User> userRepository, 
            IMapper mapper, 
            ISeasonService seasonService,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _seasonService = seasonService;
            _configuration = configuration;
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

        public async Task UpdateDailyPointsForEachUser()
        {
            var users = await _userRepository.GetAllAsync();
            foreach (var user in users)
            {
                int updatedDailyPoints = CalculateDailyPoints();
                user.DailyPoints = updatedDailyPoints;
                await _userRepository.UpdateAsync(user);
            }
        }

        private int CalculateDailyPoints()
        {
            int firstValue = _configuration.GetValue<int>("DailyPoints:FirstDayNewSeason");
            int secondValue = _configuration.GetValue<int>("DailyPoints:SecondDayNewSeason");
            double thirdCondition = _configuration.GetValue<double>("DailyPoints:ThirdValueCondition");
            double fourthCondition = _configuration.GetValue<double>("DailyPoints:FourthValueCondition");
            int dayNumber = _seasonService.GetDayNumberInSeason();

            if (dayNumber == 1)
            {
                return firstValue;
            }
            else if (dayNumber == 2)
            {
                return secondValue;
            }
            else
            {
                int prev = firstValue;
                int curr = secondValue;
                int sum = firstValue + secondValue;
                for (int i = 3; i <= dayNumber; i++)
                {
                    int next = (int)(thirdCondition * (fourthCondition * curr) + prev);
                    sum += next;
                    prev = curr;
                    curr = next;
                }
                return sum;
            }
        }
    }
}
