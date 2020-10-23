using System;
using System.Net.Http;

namespace TeamsHelper.CalendarApi
{
    public class DeleteEventRequestGenerator : IDeleteEventRequestGenerator
    {
        public IDeleteEventUrlGenerator DeleteEventUrlGenerator;

        public DeleteEventRequestGenerator(IDeleteEventUrlGenerator deleteEventUrlGenerator)
        {
            DeleteEventUrlGenerator = deleteEventUrlGenerator;
        }

        public HttpRequestMessage Generate(string calendarId, string eventId, string accessToken)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                RequestUri = new Uri(DeleteEventUrlGenerator.Generate(calendarId, eventId)),
                Method = HttpMethod.Delete
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}