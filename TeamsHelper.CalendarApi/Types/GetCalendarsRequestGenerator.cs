using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class GetCalendarsRequestGenerator : IGetCalendarsRequestGenerator
    {
        public IGetCalendarsUrlGenerator UrlGenerator;

        public GetCalendarsRequestGenerator(IGetCalendarsUrlGenerator urlGenerator)
        {
            UrlGenerator = urlGenerator;
        }

        public HttpRequestMessage Generate(string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage()
            {
                RequestUri = new Uri(UrlGenerator.Generate()),
                Method = HttpMethod.Get
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);
            return req;
        }
    }
}