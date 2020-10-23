using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventFinder : IGoogleEventFinder
    {
        public Task<GoogleEvent> FindAsync(List<GoogleEvent> googleEvents, string teamsId)
        {
            return Task.Run(() => googleEvents.FirstOrDefault(x => x.ExtendedProperties.Private["teamsId"] == teamsId));
        }
    }
}