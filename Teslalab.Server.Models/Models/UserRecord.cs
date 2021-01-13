using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teslalab.Server.Models.Models
{
    public abstract class UserRecord : Record
    {
        public UserRecord()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ApplicationUser CreatedUser { get; set; }

        [ForeignKey(nameof(CreatedUser))]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser ModifiedByUser { get; set; }

        [ForeignKey(nameof(ModifiedByUser))]
        public string ModifiedByUserId { get; set; }
    }
}