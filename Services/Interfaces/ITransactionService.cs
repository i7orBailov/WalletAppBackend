﻿using WalletAppBackend.Models.Api.Response;
using WalletAppBackend.Models.Api.Transaction;

namespace WalletAppBackend.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ResponseMessage<IEnumerable<TransactionApi>>> GetAll(int ownerId);
        Task<ResponseMessage<int>> CreateTransaction(CreateTransactionApi transaction);
        Task<ResponseMessage<int>> DeleteTransaction(int transactionId);
        Task<ResponseMessage<TransactionsListDashboardApi>> GetTransactionsListScreen(int ownerId);
        Task<ResponseMessage<TransactionApi>> GetTransactionDetails(int transactionId);
    }
}
