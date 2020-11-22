using System;

namespace TeamsHelper.WebApp
{
    public class Event
    {
        public string GoogleEventId { get; set; }
        public string TeamsEventId { get; set; }
        public string TeamsEventSubject { get; set; }
        public string TeamsEventOrganizerEmail { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public string GoogleEventSummary { get; set; }
        public string GoogleEventDescription { get; set; }
        public bool IsUpdated { get; set; }
    }
}