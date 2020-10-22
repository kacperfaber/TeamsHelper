using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;


namespace TeamsHelper.WebApp
{
    public interface IGoogleEventSummaryGenerator
    {
        string Generate(TeamsEvent teamsEvent);
    }
}