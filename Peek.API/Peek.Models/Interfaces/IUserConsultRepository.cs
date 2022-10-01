using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.UserService.Commands;

namespace Peek.Models.Interfaces
{
    public interface IUserCommandRepository
    {
        Task<ResponseBase<string>> Create(CreateUserCommand createUserCommand);
        Task<ResponseBase<string>> Create(FollowCommand followCommand);
        Task<ResponseBase<string>> Create(LoginCommand loginCommand);
        Task<ResponseBase<string>> RefreshToken(RefreshTokenCommand refreshTokenCommand);
    }
}
