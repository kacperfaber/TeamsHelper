using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventSummaryGenerator
    {
        string Generate(TeamsEvent teamsEvent);
    }
}