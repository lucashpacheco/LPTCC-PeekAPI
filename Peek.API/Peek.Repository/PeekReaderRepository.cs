using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Models.Interfaces;
using Domain = Peek.Framework.PeekServices.Domain;


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

        public async Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getUserByIdRequest)
        {
            var result = await http.Post<ResponseBase<PagedResult<Domain.Peek>>, GetPeeksRequest>(uri, $"/Peek", getUserByIdRequest);

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
            var result = await http.Get<ResponseBase<int>>(uri, $"/Likes/count?PeekId={getPeeksRequest.PeekId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<int>> Get(GetCommentsCountRequest getPeeksRequest)
        {
            var result = await http.Get<ResponseBase<int>>(uri, $"/Comments/count?PeekId={getPeeksRequest.PeekId.ToString()}");

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