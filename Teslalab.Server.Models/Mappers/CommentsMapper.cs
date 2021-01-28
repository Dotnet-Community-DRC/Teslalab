using System.Linq;
using Teslalab.Server.Models.Models;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Models.Mappers
{
    public static class CommentsMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                CommentDate = comment.CreatedOn,
                Content = comment.Content,
                ParentCommentId = comment.ParentCommentId,
                Id = comment.Id,
                Username = $"{comment.CreatedUser.FirstName} {comment.CreatedUser.LastName}",
                VideoId = comment.VideoId,
                Replies = comment.Replies?.Select(c => c.ToCommentDto()),
            };
        }
    }
}