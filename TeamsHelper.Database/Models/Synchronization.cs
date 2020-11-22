using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class Synchronization
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [InverseProperty("Synchronization")]
        public List<SynchronizedEvent> Events { get; set; }
    }
}