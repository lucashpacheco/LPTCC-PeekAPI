using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Models.Interfaces;
using UserService.Model.Commands;
using UserService.Model.Responses.Common;

namespace Peek.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCommandsController : ControllerBase
    {

        private readonly ILogger<UserCommandsController> _logger;
        private readonly IUserCommandRepository _userCommandRepository;

        public UserCommandsController(ILogger<UserCommandsController> logger, IUserCommandRepository _userCommandRepository)
        {
            _logger = logger;

        }

        [HttpPost]
        public Task<ResponseBase<string>> Create(CreateUserCommand createUserCommand)
        {
            return null;
        }
        [HttpPost]
        public Task<ResponseBase<string>> Create(FollowCommand createUserCommand)
        {
            return null;
        }
        [HttpPost]
        public Task<ResponseBase<string>> Create(LoginCommand createUserCommand)
        {
            return null;
        }
        [HttpPost]
        public Task<ResponseBase<string>> RefreshToken(RefreshTokenCommand createUserCommand)
        {
            return null;
        }
    }
}
