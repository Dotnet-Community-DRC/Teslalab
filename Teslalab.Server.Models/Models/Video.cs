using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teslalab.Shared;

namespace Teslalab.Server.Models.Models
{
    public class Video : UserRecord
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string VideoUrl { get; set; }

        [Required]
        [StringLength(255)]
        public string ThumpUrl { get; set; }

        public int Views { get; set; }
        public int Likes { get; set; }
        public DateTime PublishedDate { get; set; }

        public Category Category { get; set; }
        public VideoPrivacy Privacy { get; set; }

        public virtual List<PlaylistVideo> PlaylistVideos { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}