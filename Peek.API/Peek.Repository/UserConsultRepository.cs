using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.UserService.Consults;
using Peek.Framework.UserService.Domain;
using Peek.Models.Interfaces;

namespace Peek.Repository
{
    public class UserConsultRepository : IUserConsultRepository
    {
        private readonly IHttp http;
        private readonly string uri;
        public UserConsultRepository(IConfiguration _configuration, IHttp _http)
        {
            http = _http;
            uri = _configuration.GetSection("Urls:UserService").Value;
        }

        public async Task<ResponseBase<User>> Get(GetUserByIdRequest getUserByIdRequest)
        {
            var result = await http.Get<ResponseBase<User>>(uri, $"/UserReader/getuser/{getUserByIdRequest.UserId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<User>>>(uri, $"/UserReader/getusers?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<User>>> Get(GetFollowedUsersRequest getFollowedUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getFollowedUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<User>>>(uri, $"/UserReader/getfollowedusers?{paramQueryString}");

            return result;
        }

        private string BootstrapQueryString(GetUsersRequest getLikesRequest)
        {
            return "";
        }

        private string BootstrapQueryString(GetFollowedUsersRequest getLikesRequest)
        {
            return "";
        }

    }
}