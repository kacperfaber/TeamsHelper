using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IInsertEventRequestGenerator
    {
        HttpRequestMessage Generate(GoogleCalendar googleCalendar, GoogleEvent googleGoogleEvent, string accessToken);
    }
}