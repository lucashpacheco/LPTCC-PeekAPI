using System;
using System.Collections.Generic;
using Peek.Framework.Common.Responses;
using Domain = Peek.Framework.PeekServices.Domain;

namespace Peek.Models.Output
{
    public class PeeksResponse
    {

        public PagedResult<Peek> Peeks { get; set; }
        public PeeksResponse(PagedResult<Domain.Peek> peeks)
        {
            Peeks = new PagedResult<Peek>();
            Peeks.Result = new List<Peek>();
            foreach (var peek in peeks.Result)
            {
                Peeks.Result.Add(new Peek(peek));
            }
        }
    }

    public class Peek
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfilePhoto { get; set; }
        public string Message { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public List<Domain.Like> Likes { get; set; }
        public bool Liked { get; set; }
        public DateTime CreatedDate { get; set; }
        public Peek(Domain.Peek peek)
        {
            this.Id = peek.Id;
            this.AuthorId = peek.AuthorId;
            this.AuthorName = "";
            this.Message = peek.Message;
            this.CreatedDate = peek.CreatedDate;
        }
    }
}
