using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ICancelledEventsDescriptionGenerator
    {
        string Generate(string originalDescription, DescriptionAfterCancelled afterCancelled);
    }
}