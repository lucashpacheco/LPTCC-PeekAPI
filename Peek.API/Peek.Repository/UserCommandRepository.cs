using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peek.Framework.Common.Responses;
using Peek.Framework.UserService.Commands;
using Peek.Models;
using Peek.Models.Interfaces;

namespace Peek.Repository
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly IHttp http;
        private readonly string uri;
        public UserCommandRepository(IConfiguration _configuration, IHttp _http)
        {
            http = _http;
            uri = _configuration.GetSection("Urls:UserService").Value;
        }

        public async Task<ResponseBase<string>> Create(CreateUserCommand createUserCommand)
        {

            var result = await http.Post<ResponseBase<string>, CreateUserCommand>(uri, "/usuario", createUserCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(FollowCommand followCommand)
        {
            var result = await http.Post<ResponseBase<string>, FollowCommand>(uri, "/usuario", followCommand);

            return result;
        }

        public async Task<ResponseBase<string>> Create(LoginCommand loginCommand)
        {
            var result = await http.Post<ResponseBase<string>, LoginCommand>(uri, "/usuario", loginCommand);

            return result;
        }

        public async Task<ResponseBase<string>> RefreshToken(RefreshTokenCommand refreshTokenCommand)
        {
            var result = await http.Post<ResponseBase<string>, RefreshTokenCommand>(uri, "/usuario", refreshTokenCommand);

            return result;
        }
    }
}