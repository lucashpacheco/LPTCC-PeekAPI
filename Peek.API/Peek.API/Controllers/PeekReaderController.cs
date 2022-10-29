using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Errors;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.UserService.Consults;
using Peek.Models.Interfaces;


namespace Peek.API.Controllers
{
    [ApiController]
    [Route("peekReader")]
    public class PeekReaderController : BaseController
    {

        private readonly ILogger<UserCommandsController> _logger;
        private readonly IPeekReaderRepository _peekReaderRepository;
        private readonly IPeekService _peekService;

        public PeekReaderController(ILogger<UserCommandsController> logger, IPeekReaderRepository peekReaderRepository, IPeekService peekService)
        {
            _logger = logger;
            _peekReaderRepository = peekReaderRepository;
            _peekService = peekService;
        }

        [HttpPost]
        [Route("peeks", Name = "GetPeeksRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> GetPeeksRequest([FromBody] GetPeeksRequest getUserByIdRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetPeeksRequest received in API controller : {getUserByIdRequest}");
            var result = await _peekService.Get(getUserByIdRequest);

            return CustomResponse(result);
        }

        [HttpGet]
        [Route("likes", Name = "GetLikesRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> GetLikesRequest([FromQuery] GetLikesRequest getUsersRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetLikesRequest received in API controller : {getUsersRequest}");
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
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> GetCommentsRequest([FromQuery] GetCommentsRequest getCommentsRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetCommentsRequest received in API controller : {getCommentsRequest}");
            var result = await _peekService.Get(getCommentsRequest);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("countLikes/{PeekId}", Name = "GetLikesCountRequest")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> GetLikesCountRequest([FromRoute] GetLikesCountRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetLikesCountRequest received in API controller : {getPeeksRequest}");
            var result = await _peekReaderRepository.Get(getPeeksRequest);
            return CustomResponse(result);
        }
    }
}
