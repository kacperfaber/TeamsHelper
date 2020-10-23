using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventFinder
    {
        Task<GoogleEvent> FindAsync(List<GoogleEvent> googleEvents, string teamsId);
    }
}