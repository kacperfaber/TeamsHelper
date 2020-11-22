using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public interface ICancelledEventsUpdater
    {
        Task<List<CanceledEvent>> UpdateAsync(IEnumerable<TeamsEvent> teamsEvents, GoogleCalendar googleCalendar, List<GoogleEvent> googleEvents,
            GoogleConfiguration configuration, string googleToken);
    }
}