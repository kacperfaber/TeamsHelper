using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ITeamsEventIsCanceledChecker
    {
        bool Check(TeamsEvent teamsEvent);
    }
}