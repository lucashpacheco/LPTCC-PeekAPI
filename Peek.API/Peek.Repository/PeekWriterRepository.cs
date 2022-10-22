using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekWriter.Commands;
using Peek.Models.Interfaces;

namespace Peek.Repository
{
    public class PeekWriterRepository : IPeekWriterRepository
    {
        private readonly IHttp http;
        private readonly string uri;
        public PeekWriterRepository(IConfiguration _configuration, IHttp _http)
        {
            http = _http;
            uri = _configuration.GetSection("Urls:PeekWriterService").Value;
        }

        public async Task<ResponseBase<string>> Create(CreatePeekCommand createPeekCommand)
        {

            var result = await http.Post<ResponseBase<string>, CreatePeekCommand>(uri, "/Peek", createPeekCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(CreateCommentCommand createCommentCommand)
        {
            var result = await http.Post<ResponseBase<string>, CreateCommentCommand>(uri, "/Comments", createCommentCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(CreateLikeCommand createLikeCommand)
        {
            var result = await http.Post<ResponseBase<string>, CreateLikeCommand>(uri, "/Likes", createLikeCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Delete(DeletePeekCommand deletePeekCommand)
        {

            var result = await http.Delete<ResponseBase<string>>(uri, $"/Peek/{deletePeekCommand.Id.ToString()}");

            return result;
        }

        public async Task<ResponseBase<string>> Delete(DeleteCommentCommand deleteCommentCommand)
        {
            var result = await http.Delete<ResponseBase<string>>(uri, $"/Comments/{deleteCommentCommand.CommentId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<string>> Delete(DeleteLikeCommand deleteLikeCommand)
        {
            var result = await http.Delete<ResponseBase<string>>(uri, $"/Likes?PeekId={deleteLikeCommand.PeekId.ToString()}&UserId={deleteLikeCommand.UserId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<string>> Update(UpdatePeekCommand updatePeekCommand)
        {
            var result = await http.Put<ResponseBase<string>, UpdatePeekCommand>(uri, "/Peek", updatePeekCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Update(UpdateCommentCommand updateCommentCommand)
        {
            var result = await http.Put<ResponseBase<string>, UpdateCommentCommand>(uri, "/Comments", updateCommentCommand);

            return result;
        }


    }
}