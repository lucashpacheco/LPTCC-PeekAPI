using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Errors;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekWriter.Commands;
using Peek.Framework.UserService.Commands;
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
        [Route("peek", Name = "CreatePeekCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> CreatePeekCommand([FromBody] CreatePeekCommand createPeekCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - FollowCommand received in API controller : {createPeekCommand}");
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
            _logger.Log(LogLevel.Information, $"[CommandReceived] - FollowCommand received in API controller : {createLikeCommand}");
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
            _logger.Log(LogLevel.Information, $"[CommandReceived] - CreateCommentCommand received in API controller : {createCommentCommand}");
            var result = await _peekWriterRepository.Create(createCommentCommand);
            return CustomResponse(result);
        }

        [HttpDelete]
        [Route("peek/{PeekId}", Name = "DeletePeekCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> DeletePeekCommand([FromRoute] DeletePeekCommand deletePeekCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - DeletePeekCommand received in API controller : {deletePeekCommand}");
            var result = await _peekWriterRepository.Delete(deletePeekCommand);
            return CustomResponse(result);
        }

        [HttpDelete]
        [Route("like", Name = "DeleteLikeCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> DeleteLikeCommand([FromQuery] DeleteLikeCommand deleteLikeCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - DeleteLikeCommand received in API controller : {deleteLikeCommand}");
            var result = await _peekWriterRepository.Delete(deleteLikeCommand);
            return CustomResponse(result);
        }

        [HttpDelete]
        [Route("comment/{CommentId}", Name = "DeleteCommentCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> DeleteCommentCommand([FromRoute] DeleteCommentCommand deleteCommentCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - DeleteCommentCommand received in API controller : {deleteCommentCommand}");
            var result = await _peekWriterRepository.Delete(deleteCommentCommand);
            return CustomResponse(result);
        }

        [HttpPut]
        [Route("like", Name = "UpadtePeekCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> UpadtePeekCommand([FromBody] UpdatePeekCommand updatePeekCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - UpdatePeekCommand received in API controller : {updatePeekCommand}");
            var result = await _peekWriterRepository.Update(updatePeekCommand);
            return CustomResponse(result);
        }

        [HttpPut]
        [Route("comment", Name = "UpdateCommentCommand")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<string>))]
        [ProducesResponseType(400, Type = typeof(ResponseBase<BadRequestResult>))]
        [ProducesResponseType(401, Type = typeof(ResponseBase<UnauthorizedResult>))]
        [ProducesResponseType(403, Type = typeof(ResponseBase<ForbidResult>))]
        [ProducesResponseType(404, Type = typeof(ResponseBase<NotFoundResult>))]
        [ProducesResponseType(500, Type = typeof(ResponseBase<GenericError>))]
        public async Task<ActionResult> UpdateCommentCommand([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            _logger.Log(LogLevel.Information, $"[CommandReceived] - UpdateCommentCommand received in API controller : {updateCommentCommand}");
            var result = await _peekWriterRepository.Update(updateCommentCommand);
            return CustomResponse(result);
        }
    }
}
