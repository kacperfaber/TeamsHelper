using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class CreateCalendarRequestGenerator : ICreateCalendarRequestGenerator
    {
        public ICreateCalendarUrlGenerator UrlGenerator;
        public IJsonSerializer JsonSerializer;

        public CreateCalendarRequestGenerator(ICreateCalendarUrlGenerator urlGenerator, IJsonSerializer jsonSerializer)
        {
            UrlGenerator = urlGenerator;
            JsonSerializer = jsonSerializer;
        }

        public HttpRequestMessage Generate(GoogleCalendar googleCalendar, string accessToken)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(UrlGenerator.Generate()),
                Content = new StringContent(JsonSerializer.Serialize(googleCalendar))
            };
        }
    }
}