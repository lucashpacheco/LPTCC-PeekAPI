using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Peek.Framework.Common.Request;
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

            var userId = getPeeksRequest.UserId.FirstOrDefault();

            getPeeksRequest.UserId = new List<System.Guid>();

            var result = await _peekReaderRepository.Get(getPeeksRequest);

            var peekResponse = new PeeksResponse(result.Data);

            foreach (var peek in peekResponse.Peeks.Result)
            {
                var user = await _userConsultRepository.Get(new GetUserByIdRequest() { UserId = peek.AuthorId });
                var likes = await _peekReaderRepository.Get(new GetLikesRequest() { PeekId = peek.Id  , PageInformation = new PageInformation() { Page = 1 , PageSize = 2000} });
                peek.AuthorName = user.Data.Name;
                peek.AuthorProfilePhoto = user.Data.ProfilePhoto;
                peek.Likes = likes.Data != null ? likes.Data.Result : null;
                peek.Liked = likes.Data != null ? likes.Data.Result.Select(x => x.UserId).ToList().Contains(userId) : false;
                peek.LikesCount = _peekReaderRepository.Get(new GetLikesCountRequest() { PeekId = peek.Id }).Result.Data;
                peek.CommentsCount = _peekReaderRepository.Get(new GetCommentsCountRequest() { PeekId = peek.Id }).Result.Data;
            }

            response.Success = true;
            response.Data = peekResponse.Peeks;
            return response;
        }

        public async Task<ResponseBase<PagedResult<Output.Comment>>> Get(GetCommentsRequest getCommentsRequest)
        {
            var response = new ResponseBase<PagedResult<Output.Comment>>(success: false, errors: new List<string>(), data: null);

            var result = await _peekReaderRepository.Get(getCommentsRequest);
            if (result == null || result.Data == null)
            {
                return response;
            }

            var commentsResponse = new CommentsResponse(result.Data);

            foreach (var peek in commentsResponse.Comments.Result)
            {
                var user = await _userConsultRepository.Get(new GetUserByIdRequest() { UserId = peek.AuthorId });
                peek.AuthorName = user.Data.Name;
                peek.AuthorProfilePhoto = user.Data.ProfilePhoto;
                
            }

            response.Success = true;
            response.Data = commentsResponse.Comments;
            return response;
        }
    }
}
