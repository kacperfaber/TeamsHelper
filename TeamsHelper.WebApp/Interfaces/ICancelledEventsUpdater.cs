using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public interface ICancelledEventsUpdater
    {
        Task UpdateAsync(List<TeamsEvent> teamsEvents, GoogleCalendar googleCalendar, List<GoogleEvent> googleEvents,
            GoogleConfiguration configuration, string googleToken);
    }
}