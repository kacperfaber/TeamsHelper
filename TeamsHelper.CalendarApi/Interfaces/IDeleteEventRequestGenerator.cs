using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IDeleteEventRequestGenerator
    {
        HttpRequestMessage Generate(string calendarId, string eventId, string accessToken);
    }
}