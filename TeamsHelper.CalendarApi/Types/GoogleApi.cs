using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TeamsHelper.CalendarApi
{
    public class GoogleApi
    {
        public IGetCalendarsRequestGenerator GetCalendarsRequestGenerator;
        public IGetCalendarRequestGenerator GetCalendarRequestGenerator;
        public ICreateCalendarRequestGenerator CreateCalendarRequestGenerator;
        public IInsertEventRequestGenerator InsertEventRequestGenerator;
        
        readonly HttpClient _http = new HttpClient();

        public GoogleApi(IGetCalendarsRequestGenerator getCalendarsRequestGenerator, ICreateCalendarRequestGenerator createCalendarRequestGenerator, IInsertEventRequestGenerator insertEventRequestGenerator, IGetCalendarRequestGenerator getCalendarRequestGenerator)
        {
            GetCalendarsRequestGenerator = getCalendarsRequestGenerator;
            CreateCalendarRequestGenerator = createCalendarRequestGenerator;
            InsertEventRequestGenerator = insertEventRequestGenerator;
            GetCalendarRequestGenerator = getCalendarRequestGenerator;
        }

        public async Task<List<GoogleCalendar>> GetCalendarsAsync(string accessToken)
        {
            HttpRequestMessage req = GetCalendarsRequestGenerator.Generate(accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            List<GoogleCalendar> calendars = JObject.Parse(content)["items"].ToObject<List<GoogleCalendar>>();
            return calendars;
        }

        public async Task<GoogleCalendar> GetCalendar(string calendarId, string accessToken)
        {
            HttpRequestMessage req = GetCalendarRequestGenerator.Generate(calendarId, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleCalendar>();
        }
        
        public async Task<GoogleCalendar> CreateCalendarAsync(GoogleCalendar googleCalendar, string accessToken)
        {
            HttpRequestMessage req = CreateCalendarRequestGenerator.Generate(googleCalendar, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleCalendar>();
        }

        public async Task<GoogleEvent> InsertEventAsync(GoogleCalendar googleCalendar, GoogleEvent googleGoogleEvent, string accessToken)
        {
            HttpRequestMessage request = InsertEventRequestGenerator.Generate(googleCalendar, googleGoogleEvent, accessToken);
            HttpResponseMessage response = await _http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleEvent>();
        }
    }
}