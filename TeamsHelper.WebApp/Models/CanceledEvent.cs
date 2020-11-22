using System;

namespace TeamsHelper.WebApp
{
    public class CanceledEvent
    {
        public string GoogleId { get; set; }
        public string GoogleSummary { get; set; }
        public string GoogleDescription { get; set; }
        public DateTime? StartingAt { get; set; }
        public DateTime? EndingAt { get; set; }
        public string TeamsOrganizerEmailAddress { get; set; }
        public string TeamsId { get; set; }
    }
}