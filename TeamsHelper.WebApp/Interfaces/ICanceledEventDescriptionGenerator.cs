using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ICanceledEventDescriptionGenerator
    {
        string Generate(string originalDescription, DescriptionAfterCancelled afterCancelled);
    }
}