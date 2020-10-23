using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleCalendarCleaner
    {
        Task CleanAsync(GoogleCalendar googleCalendar, IEnumerable<GoogleEvent> googleEvents, IEnumerable<TeamsEvent> teamsEvents, string accessToken);
    }
}