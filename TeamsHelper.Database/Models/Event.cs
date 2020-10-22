using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TeamsHelper.Database
{
    public class Event
    {
        [Key]
        public string Id { get; set; }

        public Day Day { get; set; }

        [ForeignKey("TeamsEventId")]
        public TeamsEvent TeamsEvent { get; set; }

        public string TeamsEventId { get; set; }
        
        [ForeignKey("GoogleEventId")]
        public GoogleEvent GoogleEvent { get; set; }

        public string GoogleEventId { get; set; }

        public DateTime GeneratedAt { get; set; }
    }
}