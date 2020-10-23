using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IListEventsRequestGenerator
    {
        HttpRequestMessage Generate(string calendarId, string accessToken);
    }
}