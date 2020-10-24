using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IUpdateCanceledEventGenerator
    {
        UpdateEventPayload Generate(GoogleEvent googleEvents, TeamsEvent teamsEvent, GoogleConfiguration configuration);
    }
}