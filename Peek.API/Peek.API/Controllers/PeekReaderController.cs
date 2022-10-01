using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Models.Interfaces;


namespace Peek.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeekReaderController : BaseController
    {

        private readonly ILogger<UserCommandsController> _logger;
        private readonly IPeekReaderRepository _peekReaderRepository;

        public PeekReaderController(ILogger<UserCommandsController> logger, IPeekReaderRepository peekReaderRepository)
        {
            _logger = logger;
            _peekReaderRepository = peekReaderRepository;
        }

        [HttpGet]
        [Route("peeks", Name = "GetPeeksRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetPeeksRequest([FromQuery] GetPeeksRequest getUserByIdRequest)
        {
            var result = await _peekReaderRepository.Get(getUserByIdRequest);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("likes", Name = "GetLikesRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetLikesRequest([FromQuery] GetLikesRequest getUsersRequest)
        {
            var result = await _peekReaderRepository.Get(getUsersRequest);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("comments", Name = "GetCommentsRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetCommentsRequest([FromQuery] GetCommentsRequest getFollowedUsersRequest)
        {
            var result = await _peekReaderRepository.Get(getFollowedUsersRequest);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("countLikes/{id}", Name = "GetLikesCountRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<ApplicationException>))]
        public async Task<ActionResult> GetLikesCountRequest([FromRoute] GetLikesCountRequest getPeeksRequest)
        {
            var result = await _peekReaderRepository.Get(getPeeksRequest);
            return CustomResponse(result);
        }
    }
}
