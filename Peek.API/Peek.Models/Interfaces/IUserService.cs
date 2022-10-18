using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.UserService.Consults;
using Peek.Models.Output;

namespace Peek.Models.Interfaces
{
    public interface IUserService
    {
        Task<ResponseBase<PagedResult<User>>> Get(GetUsersRequest getUsersRequest);
    }
}
