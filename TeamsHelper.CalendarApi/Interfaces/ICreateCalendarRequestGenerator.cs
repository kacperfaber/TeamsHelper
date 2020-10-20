using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface ICreateCalendarRequestGenerator
    {
        HttpRequestMessage Generate(Calendar calendar, string accessToken);
    }
}