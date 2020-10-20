using System;
using System.Net.Http;

namespace TeamsHelper.TeamsApi
{
    public class GetEventsRequestGenerator : IGetEventsRequestGenerator
    {
        public IGetEventsUrlGenerator GetEventsUrlGenerator;

        public GetEventsRequestGenerator(IGetEventsUrlGenerator getEventsUrlGenerator)
        {
            GetEventsUrlGenerator = getEventsUrlGenerator;
        }

        public HttpRequestMessage Generate(TeamsCalendar teamsCalendar, DateTime startingAt, DateTime endingAt, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(GetEventsUrlGenerator.Generate(teamsCalendar, startingAt, endingAt)),
                Method = HttpMethod.Get
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);
            req.Headers.Add("Prefer", "outlook.timezone=\"Europe/Warsaw\"");
            
            return req;
        }
    }
}