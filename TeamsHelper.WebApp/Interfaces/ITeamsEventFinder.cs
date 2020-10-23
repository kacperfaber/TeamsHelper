using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ITeamsEventFinder
    {
        Task<TeamsEvent> FindAsync(IEnumerable<TeamsEvent> teamsEvents, string teamsId);
    }
}