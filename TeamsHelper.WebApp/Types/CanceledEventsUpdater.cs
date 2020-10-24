using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class CanceledEventsUpdater : ICanceledEventsUpdater
    {
        public ITeamsEventIsCanceledChecker IsCanceledChecker;
        public GoogleEventFinder GoogleEventFinder;
        public GoogleApi GoogleApi;
        
        public async Task UpdateAsync(List<TeamsEvent> teamsEvents, GoogleCalendar googleCalendar, List<GoogleEvent> googleEvents, GoogleConfiguration configuration, string googleToken)
        {
            foreach (TeamsEvent teamsEvent in teamsEvents)
            {
                if (IsCanceledChecker.Check(teamsEvent))
                {
                    GoogleEvent googleEvent = await GoogleEventFinder.FindAsync(googleEvents, teamsEvent.Id);

                    if (configuration.DeleteCanceled)
                    {
                        await GoogleApi.DeleteAsync(googleCalendar.Id, googleEvent.Id, googleToken);
                    }

                    else
                    {
                        UpdateEventPayload payload = null;
                        await GoogleApi.UpdateAsync(payload, googleCalendar.Id, googleEvent.Id, googleToken);
                    }
                }
            }
        }
    }
}