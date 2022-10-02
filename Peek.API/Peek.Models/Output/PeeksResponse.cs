using System;
using System.Collections.Generic;
using Peek.Framework.Common.Request;
using Peek.Framework.Common.Responses;
using Documents = Peek.Framework.PeekServices.Documents;

namespace Peek.Models.Output
{
    public class PeeksResponse
    {
        public PageInformation PageInformation { get; set; }

        public List<Peek> Peeks { get; set; }
        public PeeksResponse(PagedResult<Documents.PeekDocument> peeks)
        {
            Peeks = new List<Peek>();
            foreach (var peek in peeks.Result)
            {
                Peeks.Add(new Peek(peek));
            }
        }
    }

    public class Peek
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public Peek(Documents.PeekDocument peek)
        {
            this.Id = peek.Id;
            this.AuthorId = peek.AuthorId;
            this.AuthorName = "";
            this.Message = peek.Message;
            this.CreatedDate = peek.CreatedDate;
        }
    }
}
