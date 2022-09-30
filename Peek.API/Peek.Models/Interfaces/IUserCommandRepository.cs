using System.Threading.Tasks;
using UserService.Model.Consults;
using UserService.Model.Domain;
using UserService.Model.Responses.Common;

namespace Peek.Models.Interfaces
{
    public interface IUserConsultRepository
    {
        Task<ResponseBase<User>> Get(GetUserByIdRequest getUserByIdRequest);
        Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUserByIdRequest);
        Task<ResponseBase<PagedResult<User>>> Get(GetFollowedUsersRequest getUserByIdRequest);
    }
}
