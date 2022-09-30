using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PeekReaderController : ControllerBase
    {

        private readonly ILogger<UserCommandsController> _logger;
        private readonly IPeekReaderRepository _peekReaderRepository;

        public PeekReaderController(ILogger<UserCommandsController> logger, IPeekReaderRepository peekReaderRepository)
        {
            _logger = logger;
            _peekReaderRepository = peekReaderRepository;
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
