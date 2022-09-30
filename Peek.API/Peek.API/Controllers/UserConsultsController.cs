using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Models.Interfaces;
using UserService.Model.Commands;
using UserService.Model.Consults;
using UserService.Model.Responses.Common;

namespace Peek.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserConsultsController : ControllerBase
    {

        private readonly ILogger<UserConsultsController> _logger;
        private readonly IUserCommandRepository _userCommandRepository;

        public UserConsultsController(ILogger<UserConsultsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Task<ResponseBase<string>> Get(GetUserByIdRequest createUserCommand)
        {
            return null;
        }
        [HttpPost]
        public Task<ResponseBase<string>> Get(GetUsersRequest createUserCommand)
        {
            return null;
        }
        [HttpPost]
        public Task<ResponseBase<string>> Get(GetFollowedUsersRequest createUserCommand)
        {
            return null;
        }
    }
}
