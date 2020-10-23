using System;
using System.Net.Http;
using System.Text;

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

        public HttpRequestMessage Generate(GoogleCalendar googleCalendar, GoogleEvent googleGoogleEvent, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlGenerator.Generate(googleCalendar)),
                Method = HttpMethod.Post,
                Content = new StringContent(Serializer.Serialize(googleGoogleEvent), Encoding.UTF8, "application/json")
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}