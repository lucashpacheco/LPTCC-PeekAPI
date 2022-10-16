using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekReader.Consults;

namespace Peek.Models.Interfaces
{
    public interface IPeekService
    {
        Task<ResponseBase<PagedResult<Output.Peek>>> Get(GetPeeksRequest getPeeksRequest);
    }
}
