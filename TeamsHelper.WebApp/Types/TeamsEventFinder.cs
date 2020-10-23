using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class TeamsEventFinder : ITeamsEventFinder
    {
        public Task<TeamsEvent> FindAsync(List<TeamsEvent> teamsEvents, string teamsId)
        {
            return Task.Run(() => teamsEvents.FirstOrDefault(x => x.Id == teamsId));
        }
    }
}