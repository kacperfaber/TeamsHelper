using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class TeamsEventIsCanceledChecker : ITeamsEventIsCanceledChecker
    {
        public bool Check(TeamsEvent teamsEvent)
        {
            return teamsEvent.IsCancelled;
        }
    }
}