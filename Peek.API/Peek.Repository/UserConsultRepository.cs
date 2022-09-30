using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Models;
using Peek.Models.Interfaces;
using PeekReaderService.Models.Consults;
using UserService.Model.Consults;
using UserService.Model.Domain;
using UserService.Model.Responses.Common;

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
            var result = await http.Get<ResponseBase<User>>(uri, $"/clinica/laboratorio/{getUserByIdRequest.UserId.ToString()}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<User>>>(uri, $"/clinica/laboratorio?{paramQueryString}");

            return result;
        }

        public async Task<ResponseBase<PagedResult<User>>> Get(GetFollowedUsersRequest getFollowedUsersRequest)
        {
            var paramQueryString = BootstrapQueryString(getFollowedUsersRequest);

            var result = await http.Get<ResponseBase<PagedResult<User>>>(uri, $"/clinica/laboratorio?{paramQueryString}");

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