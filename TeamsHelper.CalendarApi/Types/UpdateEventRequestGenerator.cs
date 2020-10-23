using System;
using System.Net.Http;
using System.Text;

namespace TeamsHelper.CalendarApi
{
    public class UpdateEventRequestGenerator : IUpdateEventRequestGenerator
    {
        public IUpdateEventUrlGenerator UrlGenerator;
        public IJsonSerializer JsonSerializer;

        public UpdateEventRequestGenerator(IUpdateEventUrlGenerator urlGenerator, IJsonSerializer jsonSerializer)
        {
            UrlGenerator = urlGenerator;
            JsonSerializer = jsonSerializer;
        }

        public HttpRequestMessage Generate(UpdateEventPayload payload, string calendarId, string eventId, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlGenerator.Generate(calendarId, eventId)),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}