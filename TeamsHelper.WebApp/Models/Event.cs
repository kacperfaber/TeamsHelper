using System;

namespace TeamsHelper.WebApp
{
    public class Event
    {
        public string GoogleEventId { get; set; }
        public string TeamsEventId { get; set; }
        public string TeamsEventSubject { get; set; }
        public string TeamsEventOrganizerEmail { get; set; }
        public DateTime PlannedAt { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsCreated { get; set; }
    }
}