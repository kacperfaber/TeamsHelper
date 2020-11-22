using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class EventGenerator : IEventGenerator
    {
        public Event Generate(TeamsEvent teamsEvent, GoogleEvent googleEvent, bool isOnlyUpdated)
        {
            return new Event
            {
                TeamsEventId = teamsEvent.Id,
                TeamsEventSubject = teamsEvent.Subject,
                TeamsEventOrganizerEmail = teamsEvent.TeamsOrganizer.EmailAddress.Address,
                StartingAt = teamsEvent.Start.DateTime,
                EndingAt = teamsEvent.End.DateTime,
                GoogleEventId = googleEvent.Id,
                GoogleEventSummary = googleEvent.Summary,
                GoogleEventDescription = googleEvent.Description,
                IsUpdated = isOnlyUpdated
            };
        }
    }
}