using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class Meet
    {
        [Key]
        public string Id { get; set; }

        public DateTime GeneratedAt { get; set; }

        public DateTime ScheduledAt { get; set; }

        [ForeignKey("GoogleEventId")]
        public GoogleEvent GoogleEvent { get; set; }

        public string GoogleEventId { get; set; }
        
        [ForeignKey("TeamsEventId")]
        public TeamsEvent TeamsEvent { get; set; }

        public string TeamsEventId { get; set; }
    }
}