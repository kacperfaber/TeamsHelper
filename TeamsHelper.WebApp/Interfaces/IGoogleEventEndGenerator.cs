using TeamsHelper.CalendarApi;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventEndGenerator
    {
        GoogleTime Generate(TeamsEvent teamsEvent);
    }
}