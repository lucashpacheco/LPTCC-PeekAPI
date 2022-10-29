using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Peek.Framework.Common.Responses;
using Domain = Peek.Framework.PeekServices.Domain;

namespace Peek.Models.Output
{
    public class CommentsResponse
    {
        public PagedResult<Comment> Comments{ get; set; }
        public CommentsResponse(PagedResult<Domain.Comment> comments)
        {
            Comments = new PagedResult<Comment>();
            Comments.Result = new List<Comment>();
            foreach (var comment in comments.Result)
            {
                Comments.Result.Add(new Comment(comment));
            }
        }
    }

    public class Comment 
    {
        public Guid? Id { get; set; }
        public Guid? AuthorId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfilePhoto { get; set; }

        public Comment(Domain.Comment comment)
        {
            this.Id = comment.Id;
            this.AuthorId = comment.AuthorId;
            this.Message = comment.Message;
            this.CreatedDate = comment.CreatedDate;

        }
    }
}
