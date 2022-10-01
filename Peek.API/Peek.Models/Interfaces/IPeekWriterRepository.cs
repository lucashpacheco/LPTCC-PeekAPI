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

    }
}
