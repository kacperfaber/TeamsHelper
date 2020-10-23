using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class ListEventsRequestGenerator : IListEventsRequestGenerator
    {
        public IListEventsUrlGenerator UrlGenerator;

        public ListEventsRequestGenerator(IListEventsUrlGenerator urlGenerator)
        {
            UrlGenerator = urlGenerator;
        }

        public HttpRequestMessage Generate(string calendarId, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlGenerator.Generate(calendarId)),
                Method = HttpMethod.Get
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}