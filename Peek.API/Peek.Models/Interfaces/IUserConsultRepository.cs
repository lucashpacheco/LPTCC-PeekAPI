using System.Threading.Tasks;
using UserService.Model.Commands;
using UserService.Model.Consults;
using UserService.Model.Domain;
using UserService.Model.Responses.Common;

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
