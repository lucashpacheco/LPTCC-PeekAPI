using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.PeekServices.PeekReader.Responses;
using Domain = Peek.Framework.PeekServices.Domain;


namespace Peek.Models.Interfaces
{
    public interface IPeekReaderRepository
    {
        Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getUserByIdRequest);

        Task<ResponseBase<PagedResult<LikesResponse>>> Get(GetLikesRequest getUsersRequest);

        Task<ResponseBase<PagedResult<Domain.Comment>>> Get(GetCommentsRequest getFollowedUsersRequest);

        //Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest);
        Task<ResponseBase<int>> Get(GetCommentsCountRequest getPeeksRequest);
    }
}
