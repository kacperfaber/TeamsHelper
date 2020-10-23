using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleCalendarCleaner
    {
        Task CleanAsync(List<GoogleEvent> googleEvents, List<TeamsEvent> teamsEvents, string accessToken);
    }
}