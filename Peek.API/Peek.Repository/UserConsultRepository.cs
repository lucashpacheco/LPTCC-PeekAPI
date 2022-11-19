using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Responses;
using Peek.Framework.Common.Utils;
using Peek.Framework.UserService.Commands;
using Peek.Framework.UserService.Consults;
using Peek.Framework.UserService.Domain;
using Peek.Models.Interfaces;
using Json = Newtonsoft.Json.JsonConvert;

namespace Peek.Repository
{
    public class UserConsultRepository : IUserConsultRepository
    {
        private readonly ILogger<UserConsultRepository> _logger;
        private readonly IHttp http;
        private readonly string uri;
        public UserConsultRepository(IConfiguration _configuration, IHttp _http , ILogger<UserConsultRepository> logger)
        {
            _logger = logger;
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
            _logger.Log(LogLevel.Information, $"[RequestingToService] - GetUserByIdRequest received in UserConsultRepository class: {Json.SerializeObject(getUsersRequest)}");
            var result = await http.Post<ResponseBase<PagedResult<User>>, GetUsersRequest>(uri, "/UserReader/getusers", getUsersRequest);
            _logger.Log(LogLevel.Information, $"[RequestingToService] - GetUserByIdRequest returned from service: {Json.SerializeObject(result)}");

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
            return $"PageInformation.Page={getLikesRequest.PageInformation.Page}&PageInformation.PageSize={getLikesRequest.PageInformation.PageSize}";
        }

        private string BootstrapQueryString(GetFollowedUsersRequest getLikesRequest)
        {
            return $"UserId={getLikesRequest.UserId.ToString()}&PageInformation.Page={getLikesRequest.PageInformation.Page}&PageInformation.PageSize={getLikesRequest.PageInformation.PageSize}";
        }

    }
}