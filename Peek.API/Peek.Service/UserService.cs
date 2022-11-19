using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Request;
using Peek.Framework.Common.Responses;
using Peek.Framework.UserService.Consults;
using Peek.Models.Interfaces;
using Peek.Models.Output;
using Json = Newtonsoft.Json.JsonConvert;

namespace Peek.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        private readonly IUserConsultRepository _userConsultRepository;
        public UserService(ILogger<UserService> logger  , IUserConsultRepository userConsultRepository)
        {
            _logger = logger;
            _userConsultRepository = userConsultRepository;
        }

        public async Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUsersRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetUserByIdRequest received in UserService class: {Json.SerializeObject(getUsersRequest)}");

            var response = new ResponseBase<PagedResult<User>>(success: true, errors: new List<string>(), data: null);

            var gambiarra = new PageInformation() { Page = 1, PageSize = 2000 };

            var followedUsers = await _userConsultRepository.Get(new GetFollowedUsersRequest() { UserId = getUsersRequest.UsersIds[0], PageInformation = gambiarra });

            var users = await _userConsultRepository.Get(getUsersRequest);

            var result = new List<User>();

            foreach (var user in users.Data.Result)
            {
                var responseUser = new User(user);
                responseUser.Followed = followedUsers.Data.Result.Where(x => x.Id == user.Id).Any();
                result.Add(responseUser);
            }

            response.Success = true;
            response.Data = new PagedResult<User>() { Result = result, TotalItems = users.Data.TotalItems };

            return response;
        }
    }
}
