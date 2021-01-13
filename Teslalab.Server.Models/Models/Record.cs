using System;
using System.ComponentModel.DataAnnotations;

namespace Teslalab.Server.Models.Models
{
    public abstract partial class Record
    {
        public Record()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
    }
}