using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.UserService.Consults;
using Peek.Framework.UserService.Domain;

namespace Peek.Models.Interfaces
{
    public interface IUserConsultRepository
    {
        Task<ResponseBase<User>> Get(GetUserByIdRequest getUserByIdRequest);
        Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUserByIdRequest);
        Task<ResponseBase<PagedResult<User>>> Get(GetFollowedUsersRequest getUserByIdRequest);
    }
}
