using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class TeamsEventIsActiveValidator : ITeamsEventIsActiveValidator
    {
        public Task<bool> ValidateAsync(TeamsEvent teamsEvent)
        {
            return Task.FromResult(!teamsEvent.IsCancelled);
        }
    }
}