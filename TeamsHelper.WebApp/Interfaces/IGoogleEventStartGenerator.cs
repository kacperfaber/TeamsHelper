using TeamsHelper.CalendarApi;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventStartGenerator
    {
        GoogleTime Generate(TeamsEvent teamsEvent);
    }
}