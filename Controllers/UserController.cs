using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Models.Api.User;
using WalletAppBackend.Models.Exceptions;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var records = await _userService.GetAll();
            return Ok(records);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserApi userApiModel)
        {
            if (userApiModel is null)
            {
                throw new BusinessException("Incorrect input parameters");
            }
            var serverResponse = await _userService.CreateNewUser(userApiModel);
            return Ok(serverResponse);
        }
    }
}
