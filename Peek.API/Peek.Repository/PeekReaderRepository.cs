using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Models;
using Peek.Models.Interfaces;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using WriterModels = PeekWriterService.Models;

namespace Peek.Repository
{
    public class PeekReaderRepository : IPeekReaderRepository
    {
        private readonly IHttp http;
        private readonly string uri;
        public PeekReaderRepository(IConfiguration _configuration, IHttp _http)
        {
            http = _http;
            uri = _configuration.GetSection("Urls:PeekReaderService").Value;
        }

        public async Task<ResponseBase<PagedResult<WriterModels.Domain.PeekDocument>>> Get(GetPeeksRequest getUserByIdRequest)
        {
            var result = await http.Get<ResponseBase<PagedResult<WriterModels.Domain.PeekDocument>>>(uri, $"/clinica/laboratorio/{getUserByIdRequest.UserId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<WriterModels.Domain.LikesDocument>>> Get(GetLikesRequest getUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<WriterModels.Domain.LikesDocument>>>(uri, $"/clinica/laboratorio?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<WriterModels.Domain.CommentsDocument>>> Get(GetCommentsRequest getFollowedUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getFollowedUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<WriterModels.Domain.CommentsDocument>>>(uri, $"/clinica/laboratorio?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest)
        {
            var result = await http.Get<ResponseBase<int>>(uri, $"/clinica/laboratorio?{getPeeksRequest}");

            return result;
        }

        private string BootstrapQueryString(GetCommentsRequest getLikesRequest)
        {
            return "";
        }

        private string BootstrapQueryString(GetLikesRequest getLikesRequest)
        {
            return "";
        }
    }
}