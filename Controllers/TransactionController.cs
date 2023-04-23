using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Models.Api;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private const string INCORRECT_INPUT_PARAMETERS = "Incorrect input parameters.";
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] int ownerId)
        {
            if (ownerId <= (int)default)
            {
                throw new BusinessException(INCORRECT_INPUT_PARAMETERS);
            }
            var records = await _transactionService.GetAll(ownerId);
            return Ok(records);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTransactionApi endpointModel)
        {
            if (endpointModel is null)
            {
                throw new BusinessException(INCORRECT_INPUT_PARAMETERS);
            }
            var createdRecord = await _transactionService.CreateTransaction(endpointModel);
            return Ok(createdRecord);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] int transactionId)
        {
            if (transactionId <= (int)default)
            {
                throw new BusinessException(INCORRECT_INPUT_PARAMETERS);
            }
            var serverResponse = await _transactionService.DeleteTransaction(transactionId);
            return Ok(serverResponse);
        }

        [HttpGet("transactionsList")]
        public async Task<IActionResult> TransactionsList([FromQuery] int ownerId)
        {
            var transactionsData = await _transactionService.GetTransactionsListScreen(ownerId);
            return Ok(transactionsData);
        }

        [HttpGet("transactionDetails")]
        public async Task<IActionResult> TransactionDetails([FromQuery] int transactionId)
        {
            var transactionDetails = await _transactionService.GetTransactionDetails(transactionId);
            return Ok(transactionDetails);
        }
    }
}
