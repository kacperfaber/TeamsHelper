using TeamsHelper.TeamsApi;
using TeamsHelper.WebApp;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper
{
    public class GoogleEventSummaryGenerator : IGoogleEventSummaryGenerator
    {
        public string Generate(TeamsEvent teamsEvent)
        {
            return teamsEvent.Subject;
        }
    }
}