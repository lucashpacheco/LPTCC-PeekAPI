using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Errors;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekWriter.Commands;
using Peek.Models.Interfaces;

namespace Peek.API.Controllers
{
    [ApiController]
    [Route("peekWriter")]
    public class PeekWriterController : BaseController
    {

        private readonly ILogger<PeekWriterController> _logger;
        private readonly IPeekWriterRepository _peekWriterRepository;

        public PeekWriterController(ILogger<PeekWriterController> logger, IPeekWriterRepository peekWriterRepository)
        {
            _logger = logger;
            _peekWriterRepository = peekWriterRepository;
        }

        [HttpPost]
        [Route("peek", Name = "CreateUser")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> CreatePeekCommand([FromBody] CreatePeekCommand createPeekCommand)
        {
            var result = await _peekWriterRepository.Create(createPeekCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("like", Name = "CreateLikeCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> CreateLikeCommand([FromBody] CreateLikeCommand createLikeCommand)
        {
            var result = await _peekWriterRepository.Create(createLikeCommand);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("comment", Name = "CreateCommentCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> CreateCommentCommand([FromBody] CreateCommentCommand createCommentCommand)
        {
            var result = await _peekWriterRepository.Create(createCommentCommand);
            return CustomResponse(result);
        }
    }
}
