using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IGetCalendarsRequestGenerator
    {
        HttpRequestMessage Generate(string accessToken);
    }
}