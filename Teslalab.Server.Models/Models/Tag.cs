using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Teslalab.Server.Models.Models
{
    public class Tag : Record
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [ForeignKey(nameof(Video))]
        public string VideoId { get; set; }
    }
}