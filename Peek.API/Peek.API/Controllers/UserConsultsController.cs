﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.UserService.Consults;
using Peek.Models.Interfaces;

namespace Peek.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserConsultsController : BaseController
    {

        private readonly ILogger<UserConsultsController> _logger;
        private readonly IUserConsultRepository _userConsultRepository;

        public UserConsultsController(ILogger<UserConsultsController> logger, IUserConsultRepository userConsultRepository)
        {
            _logger = logger;
            _userConsultRepository = userConsultRepository;

        }

        [HttpGet]
        [Route("user/{id}", Name = "GetUserByIdRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetUserByIdRequest([FromRoute] GetUserByIdRequest getUserByIdRequest)
        {
            var result = await _userConsultRepository.Get(getUserByIdRequest);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("users", Name = "GetUsersRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetUsersRequest([FromQuery] GetUsersRequest getUsersRequest)
        {
            var result = await _userConsultRepository.Get(getUsersRequest);
            return CustomResponse(result);

        }

        [HttpGet]
        [Route("followedUsers", Name = "GetFollowedUsersRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetFollowedUsersRequest([FromQuery] GetFollowedUsersRequest getFollowedUsersRequest)
        {
            var result = await _userConsultRepository.Get(getFollowedUsersRequest);
            return CustomResponse(result);
        }
    }
}