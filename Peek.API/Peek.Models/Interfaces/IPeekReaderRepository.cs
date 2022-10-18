﻿using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;


namespace Peek.Models.Interfaces
{
    public interface IPeekReaderRepository
    {
        Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getUserByIdRequest);

        Task<ResponseBase<PagedResult<LikesDocument>>> Get(GetLikesRequest getUsersRequest);

        Task<ResponseBase<PagedResult<CommentsDocument>>> Get(GetCommentsRequest getFollowedUsersRequest);

        Task<ResponseBase<int>> Get(GetLikesCountRequest getPeeksRequest);
        Task<ResponseBase<int>> Get(GetCommentsCountRequest getPeeksRequest);
    }
}
