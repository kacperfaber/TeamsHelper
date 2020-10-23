using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IUpdateEventRequestGenerator
    {
        HttpRequestMessage Generate(UpdateEventPayload payload, string calendarId, string eventId, string accessToken);
    }
}