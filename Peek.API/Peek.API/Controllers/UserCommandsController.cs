using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Errors;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.UserService.Commands;
using Peek.Models.Interfaces;

namespace Peek.API.Controllers
{
    [ApiController]
    [Route("userCommands")]
    public class UserCommandsController : BaseController
    {

        private readonly ILogger<UserCommandsController> _logger;
        private readonly IUserCommandRepository _userCommandRepository;

        public UserCommandsController(ILogger<UserCommandsController> logger, IUserCommandRepository userCommandRepository)
        {
            _logger = logger;
            _userCommandRepository = userCommandRepository;

        }

        [HttpPost]
        [Route("user", Name = "CreateUserCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> CreateUserCommand([FromBody] CreateUserCommand createUserCommand)
        {
            var result = await _userCommandRepository.Create(createUserCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("follow", Name = "FollowCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> FollowCommand([FromBody] FollowCommand followCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - FollowCommand received in API controller : {followCommand}");
            var result = await _userCommandRepository.Create(followCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("unfollow", Name = "UnfollowCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> UnfollowCommand([FromBody] UnfollowCommand followCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - UnfollowCommand received in API controller : {followCommand}");
            var result = await _userCommandRepository.Delete(followCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("login", Name = "LoginCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> LoginCommand([FromBody] LoginCommand loginCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - LoginCommand received in API controller : {loginCommand}");
            var result = await _userCommandRepository.Create(loginCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("refresh", Name = "RefreshTokenCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> RefreshTokenCommand([FromBody] RefreshTokenCommand refreshTokenCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - RefreshTokenCommand received in API controller : {refreshTokenCommand}");
            var result = await _userCommandRepository.RefreshToken(refreshTokenCommand);
            return CustomResponse(result);
        }
    }
}
