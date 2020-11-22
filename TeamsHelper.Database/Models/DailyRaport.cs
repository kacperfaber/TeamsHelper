using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class DailyRaport
    {
        [Key]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? SentAt { get; set; }

        public string UserId { get; set; }
    }
}