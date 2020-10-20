using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public interface IInsertEventRequestGenerator
    {
        HttpRequestMessage Generate(Calendar calendar, Event googleEvent, string accessToken);
    }
}