using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class SynchronizedEvent
    {
        [Key]
        public string Id { get; set; }

        public Synchronization Synchronization { get; set; }

        public string GoogleId { get; set; }

        public string GoogleName { get; set; }

        public DateTime PlannedAt { get; set; }

        public string TeamsId { get; set; }

        public string TeamsTitle { get; set; }

        public string TeamsTeacher { get; set; }
    }
}