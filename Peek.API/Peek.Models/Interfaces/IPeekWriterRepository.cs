using System.Threading.Tasks;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Common.Responses;

namespace Peek.Models.Interfaces
{
    public interface IPeekWriterRepository
    {
        Task<ResponseBase<string>> Create(CreatePeekCommand createPeekCommand);
        Task<ResponseBase<string>> Create(CreateCommentCommand createPeekCommand);
        Task<ResponseBase<string>> Create(CreateLikeCommand createPeekCommand);

    }
}
