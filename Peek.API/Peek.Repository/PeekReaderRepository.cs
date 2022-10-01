using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Models.Interfaces;

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

        public async Task<ResponseBase<PagedResult<PeekDocument>>> Get(GetPeeksRequest getUserByIdRequest)
        {
            var result = await http.Get<ResponseBase<PagedResult<PeekDocument>>>(uri, $"/Peek?{getUserByIdRequest.UserId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<LikesDocument>>> Get(GetLikesRequest getUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<LikesDocument>>>(uri, $"/Likes?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<CommentsDocument>>> Get(GetCommentsRequest getFollowedUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getFollowedUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<CommentsDocument>>>(uri, $"/Comments?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest)
        {
            var result = await http.Get<ResponseBase<int>>(uri, $"/SOON?{getPeeksRequest}");

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