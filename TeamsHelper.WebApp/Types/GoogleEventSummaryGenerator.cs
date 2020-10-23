using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public class GoogleEventSummaryGenerator : IGoogleEventSummaryGenerator
    {
        public string Generate(TeamsEvent teamsEvent)
        {
            return teamsEvent.Subject;
        }
    }
}