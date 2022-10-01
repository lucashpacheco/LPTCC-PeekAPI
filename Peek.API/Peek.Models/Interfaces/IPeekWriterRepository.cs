using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekWriter.Commands;

namespace Peek.Models.Interfaces
{
    public interface IPeekWriterRepository
    {
        Task<ResponseBase<string>> Create(CreatePeekCommand createPeekCommand);
        Task<ResponseBase<string>> Create(CreateCommentCommand createPeekCommand);
        Task<ResponseBase<string>> Create(CreateLikeCommand createPeekCommand);
        Task<ResponseBase<string>> Delete(DeletePeekCommand deletePeekCommand);
        Task<ResponseBase<string>> Delete(DeleteCommentCommand deleteCommentCommand);
        Task<ResponseBase<string>> Delete(DeleteLikeCommand deleteLikeCommand);
        Task<ResponseBase<string>> Update(UpdateCommentCommand deleteLikeCommand);
        Task<ResponseBase<string>> Update(UpdatePeekCommand deleteLikeCommand);

    }
}
