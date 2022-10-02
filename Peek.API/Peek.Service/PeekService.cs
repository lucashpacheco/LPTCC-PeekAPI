using System.Threading.Tasks;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.UserService.Consults;
using Peek.Models.Interfaces;
using Peek.Models.Output;

namespace Peek.Service
{
    public class PeekService
    {
        private readonly IPeekReaderRepository _peekReaderRepository;
        private readonly IUserConsultRepository _userConsultRepository;

        public PeekService(IPeekReaderRepository peekReaderRepository)
        {
            _peekReaderRepository = peekReaderRepository;
        }

        public async Task<PeeksResponse> Get(GetPeeksRequest getPeeksRequest)
        {
            var result = await _peekReaderRepository.Get(getPeeksRequest);

            var response = new PeeksResponse(result.Data);

            foreach (var peek in response.Peeks)
            {
                var user = await _userConsultRepository.Get(new GetUserByIdRequest() { UserId = peek.AuthorId });
                peek.AuthorName = user.Data.Name;

            }

            return response;
        }
    }
}
