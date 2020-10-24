using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IUpdateCanceledEventPayloadGenerator
    {
        UpdateEventPayload Generate(GoogleEvent googleEvents, TeamsEvent teamsEvent, GoogleConfiguration configuration);
    }
}