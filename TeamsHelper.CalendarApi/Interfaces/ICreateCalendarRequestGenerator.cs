using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface ICreateCalendarRequestGenerator
    {
        HttpRequestMessage Generate(GoogleCalendar googleCalendar, string accessToken);
    }
}