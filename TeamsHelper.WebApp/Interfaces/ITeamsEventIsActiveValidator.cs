using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ITeamsEventIsActiveValidator
    {
        Task<bool> ValidateAsync(TeamsEvent teamsEvent);
    }
}