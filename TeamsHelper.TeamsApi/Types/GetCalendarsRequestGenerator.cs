using System;
using System.Net.Http;

namespace TeamsHelper.TeamsApi
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
            HttpRequestMessage req = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(UrlGenerator.Generate())
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}