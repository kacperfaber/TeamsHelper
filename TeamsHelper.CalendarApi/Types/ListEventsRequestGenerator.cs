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

        string Dt(DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public HttpRequestMessage Generate(string calendarId, DateTime updatedMin, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlGenerator.Generate(calendarId, Dt(updatedMin))),
                Method = HttpMethod.Get
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}