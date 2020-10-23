using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ITeamsEventFinder
    {
        Task<TeamsEvent> FindAsync(List<TeamsEvent> teamsEvents, string teamsId);
    }
}