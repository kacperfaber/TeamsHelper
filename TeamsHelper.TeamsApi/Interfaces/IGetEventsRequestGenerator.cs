using System;
using System.Net.Http;

namespace TeamsHelper.TeamsApi
{
    public interface IGetEventsRequestGenerator
    {
        HttpRequestMessage Generate(TeamsCalendar teamsCalendar, DateTime startingAt, DateTime endingAt, string accessToken);
    }
}