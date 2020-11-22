using System;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class SynchronizationEventGenerator : ISynchronizationEventGenerator
    {
        public SynchronizedEvent Generate(Event @event)
        {
            return new SynchronizedEvent
            {
                Id = Guid.NewGuid().ToString(),
                GoogleId = @event.GoogleEventId,
                GoogleName = @event.GoogleEventSummary,
                TeamsTitle = @event.TeamsEventSubject,
                TeamsTeacher = @event.TeamsEventOrganizerEmail,
                StartingAt = @event.StartingAt,
                EndingAt = @event.EndingAt
            };
        }
    }
}