using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IInsertEventRequestGenerator
    {
        HttpRequestMessage Generate(string calendarId, InsertEventPayload payload, string accessToken);
    }
}