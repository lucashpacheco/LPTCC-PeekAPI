using System.Collections.Generic;
using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.UserService.Consults;
using Peek.Models.Interfaces;
using Peek.Models.Output;
using Output = Peek.Models.Output;

namespace Peek.Service
{
    public class PeekService : IPeekService
    {
        private readonly IPeekReaderRepository _peekReaderRepository;
        private readonly IUserConsultRepository _userConsultRepository;

        public PeekService(IPeekReaderRepository peekReaderRepository, IUserConsultRepository userConsultRepository)
        {
            _peekReaderRepository = peekReaderRepository;
            _userConsultRepository = userConsultRepository;
        }

        public async Task<ResponseBase<PagedResult<Output.Peek>>> Get(GetPeeksRequest getPeeksRequest)
        {
            var response = new ResponseBase<PagedResult<Output.Peek>>(success: true, errors: new List<string>(), data: null);

            var result = await _peekReaderRepository.Get(getPeeksRequest);

            var peekResponse = new PeeksResponse(result.Data);

            foreach (var peek in peekResponse.Peeks.Result)
            {
                var user = await _userConsultRepository.Get(new GetUserByIdRequest() { UserId = peek.AuthorId });
                peek.AuthorName = user.Data.Name;
                peek.AuthorProfilePhoto = user.Data.ProfilePhoto;
            }

            response.Success = true;
            response.Data = peekResponse.Peeks;
            return response;
        }
    }
}
