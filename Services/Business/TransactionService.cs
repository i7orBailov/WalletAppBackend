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
        // initial task is to retrieve first 10 transactions, but it can be extended later to manually select amount of records.
        private const int TRANSACTIONS_AMOUNT_CRITETIA = 10;

        private readonly IBaseRepository<Transaction> _transactionRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public TransactionService(
            IBaseRepository<Transaction> transactionRepository, 
            IBaseRepository<User> userRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
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
            var filteredTransactions = transactions.OrderByDescending(t => t.Date)
                .Take(TRANSACTIONS_AMOUNT_CRITETIA)
                .ToList();
            var transactionsApiModel = _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionApi>>(filteredTransactions);
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
    }
}
