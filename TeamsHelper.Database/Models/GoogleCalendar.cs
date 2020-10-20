using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class GoogleCalendar
    {
        [Key]
        public string CalendarId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}