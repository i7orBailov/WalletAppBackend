using AutoMapper;
using WalletAppBackend.Models.Api;
using WalletAppBackend.Models.Database;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Models.Api.Response;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Repositories.Interfaces;

namespace WalletAppBackend.Services.Business
{
    public class TransactionService : ITransactionService
    {
        private readonly IBaseRepository<Transaction> _transactionRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TransactionService(
            IBaseRepository<Transaction> transactionRepository, 
            IBaseRepository<User> userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResponseMessage<IEnumerable<TransactionApi>>> GetAll(int ownerId)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(u => u.Id == ownerId);
            if (user is null)
            {
                throw new BusinessException("Owner user does not exist");
            }
            var transactions = await _transactionRepository.GetFilteredAsync(t => t.OwnerId == ownerId);
            if (transactions.Any() is false)
            {
                throw new BusinessException("User has no transactions associated");
            }
            var transactionsApiModel = _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionApi>>(transactions);
            return new ResponseMessage<IEnumerable<TransactionApi>>(isSuccessful: true, transactionsApiModel);
        }

        public async Task<ResponseMessage<int>> CreateTransaction(CreateTransactionApi transaction)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(u => u.Id == transaction.OwnerId) ??
                throw new BusinessException("Owner user does not exist");

            if (user.Id == transaction.AuthorizedUserId)
            {
                throw new BusinessException("Transaction owner and authorized user should not be the same person.");
            }
            var transactionDatabaseModel = _mapper.Map<CreateTransactionApi, Transaction>(transaction);
            var createdTransaction = await _transactionRepository.AddAsync(transactionDatabaseModel);
            return new ResponseMessage<int>(isSuccessful: true, createdTransaction.Id);
        }

        public async Task<ResponseMessage<int>> DeleteTransaction(int transactionId)
        {
            var transaction = await _transactionRepository.GetFirstOrDefaultAsync(t => t.Id == transactionId) ?? 
                throw new BusinessException($"Transaction with id: {transactionId} does not exist.");

            await _transactionRepository.DeleteAsync(transaction);
            return new ResponseMessage<int>(isSuccessful: true, transaction.Id);
        }

        public async Task<ResponseMessage<TransactionsListDashboardApi>> GetTransactionsListScreen(int ownerId)
        {
            var transactionsResult = await GetAll(ownerId);
            var latestTransactions = transactionsResult.Data.OrderByDescending(t => t.Date)
                .Take(_configuration.GetValue<int>("Transactions:AmontCriteria"))
                .ToList();

            var user = await _userRepository.GetFirstOrDefaultAsync(u => u.Id == ownerId) ??
                throw new BusinessException("Owner user does not exist");
            var dashboard = _mapper.Map<User, TransactionsDashboardApi>(user);
            var responseModel = new TransactionsListDashboardApi
            {
                Dashboard = dashboard,
                LatestTransactions = latestTransactions
            };
            return new ResponseMessage<TransactionsListDashboardApi>(isSuccessful: true, responseModel);
        }

        public async Task<ResponseMessage<TransactionApi>> GetTransactionDetails(int transactionId)
        {
            var transaction = await _transactionRepository.GetFirstOrDefaultAsync(t => t.Id == transactionId)
                ?? throw new BusinessException("No transaction exists.");
            var transactionApiModel = _mapper.Map<Transaction, TransactionApi>(transaction);
            return new ResponseMessage<TransactionApi>(isSuccessful: true, transactionApiModel);
        }
    }
}
