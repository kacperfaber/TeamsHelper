using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class GetCalendarRequestGenerator : IGetCalendarRequestGenerator
    {
        public IGetCalendarUrlGenerator UrlGenerator;

        public GetCalendarRequestGenerator(IGetCalendarUrlGenerator urlGenerator)
        {
            UrlGenerator = urlGenerator;
        }

        public HttpRequestMessage Generate(string calendarId, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(UrlGenerator.Generate(calendarId))
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}