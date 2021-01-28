using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teslalab.Shared.DTOs
{
    public class CommentDto
    {
        public string Id { get; set; }

        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public string Username { get; set; }
        public IEnumerable<CommentDto> Replies { get; set; }

        public string VideoId { get; set; }
        public string ParentCommentId { get; set; }
    }
}