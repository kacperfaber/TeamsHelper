using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IEventGenerator
    {
        Event Generate(TeamsEvent teamsEvent, GoogleEvent googleEvent, bool isOnlyUpdated);
    }
}