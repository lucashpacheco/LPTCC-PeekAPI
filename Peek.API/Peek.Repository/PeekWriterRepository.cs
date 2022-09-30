using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Models;
using Peek.Models.Interfaces;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Common.Responses;

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

            var result = await http.Post<ResponseBase<string>, CreatePeekCommand>(uri, "/usuario", createPeekCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(CreateCommentCommand createCommentCommand)
        {
            var result = await http.Post<ResponseBase<string>, CreateCommentCommand>(uri, "/usuario", createCommentCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(CreateLikeCommand createLikeCommand)
        {
            var result = await http.Post<ResponseBase<string>, CreateLikeCommand>(uri, "/usuario", createLikeCommand);

            return result;
        }
    }
}