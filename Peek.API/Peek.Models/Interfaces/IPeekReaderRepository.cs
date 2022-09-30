using System.Threading.Tasks;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using WriterModels = PeekWriterService.Models;

namespace Peek.Models.Interfaces
{
    public interface IPeekReaderRepository
    {
        Task<ResponseBase<PagedResult<WriterModels.Domain.PeekDocument>>> Get(GetPeeksRequest getUserByIdRequest);
        
        Task<ResponseBase<PagedResult<WriterModels.Domain.LikesDocument>>> Get(GetLikesRequest getUsersRequest);
        
        Task<ResponseBase<PagedResult<WriterModels.Domain.CommentsDocument>>> Get(GetCommentsRequest getFollowedUsersRequest);

        Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest);
    }
}
