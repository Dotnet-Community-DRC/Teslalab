using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teslalab.Server.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Avoid null reference
        public ApplicationUser()
        {
            CreatedPlaylists = new List<Playlist>();
            ModifiedPlaylists = new List<Playlist>();
        }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        public virtual List<Playlist> ModifiedPlaylists { get; set; }
        public virtual List<Playlist> CreatedPlaylists { get; set; }

        public virtual List<Video> ModifiedVideos { get; set; }
        public virtual List<Video> CreatedVideos { get; set; }

        public virtual List<Comment> ModifedComments { get; set; }
        public virtual List<Comment> CreatedComments { get; set; }
    }
}