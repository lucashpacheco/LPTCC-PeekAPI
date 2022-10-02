using Peek.Models.Interfaces;

namespace Peek.Service
{
    public class UserService
    {
        private readonly IUserConsultRepository _userConsultRepository;
        public UserService(IUserConsultRepository userConsultRepository)
        {
            _userConsultRepository = userConsultRepository;
        }
    }
}
