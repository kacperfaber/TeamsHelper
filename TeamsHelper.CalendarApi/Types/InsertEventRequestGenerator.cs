using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class InsertEventRequestGenerator : IInsertEventRequestGenerator
    {
        public IInsertEventUrlGenerator UrlGenerator;
        public IJsonSerializer Serializer;

        public InsertEventRequestGenerator(IInsertEventUrlGenerator urlGenerator, IJsonSerializer serializer)
        {
            UrlGenerator = urlGenerator;
            Serializer = serializer;
        }

        public HttpRequestMessage Generate(Calendar calendar, Event googleEvent, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlGenerator.Generate(calendar)),
                Method = HttpMethod.Post,
                Content = new StringContent(Serializer.Serialize(googleEvent))
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}