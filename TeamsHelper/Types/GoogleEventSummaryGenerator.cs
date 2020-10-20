using TeamsHelper.TeamsApi;

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