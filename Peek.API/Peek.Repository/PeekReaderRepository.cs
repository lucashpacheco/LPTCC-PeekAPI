using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.UserService.Consults;
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

        public async Task<ResponseBase<PagedResult<Domain.Like>>> Get(GetLikesRequest getLikesRequest)
        {

            var result = await http.Post<ResponseBase<PagedResult<Domain.Like>>, GetLikesRequest>(uri, $"/Likes", getLikesRequest);

            return result;
        }

        public async Task<ResponseBase<PagedResult<Domain.Comment>>> Get(GetCommentsRequest getFollowedUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getFollowedUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<Domain.Comment>>>(uri, $"/Comments?{paramQueryString}");

            return result;
        }

        //public async Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest)
        //{
        //    var result = await http.Get<ResponseBase<int>>(uri, $"/Likes/count?PeekId={getPeeksRequest.PeekId.ToString()}");

        //    return result;
        //}

        public async Task<ResponseBase<int>> Get(GetCommentsCountRequest getPeeksRequest)
        {
            var result = await http.Get<ResponseBase<int>>(uri, $"/Comments/count?PeekId={getPeeksRequest.PeekId.ToString()}");

            return result;
        }

        private string BootstrapQueryString(GetCommentsRequest getLikesRequest)
        {
            return $"PeekId={getLikesRequest.PeekId}&PageInformation.Page={getLikesRequest.PageInformation.Page}&PageInformation.PageSize={getLikesRequest.PageInformation.PageSize}";
        }

        private string BootstrapQueryString(GetLikesRequest getLikesRequest)
        {
            return $"PeeksIds=[\"{string.Join("\",\"", getLikesRequest.PeeksIds)}\"]&PageInformation.Page={getLikesRequest.PageInformation.Page}&PageInformation.PageSize={getLikesRequest.PageInformation.PageSize}";
        }
    }
}