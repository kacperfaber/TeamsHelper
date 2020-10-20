using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IGetCalendarRequestGenerator
    {
        HttpRequestMessage Generate(string calendarId, string accessToken);
    }
}