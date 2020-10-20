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

        public async Task<List<Calendar>> GetCalendarsAsync(string accessToken)
        {
            HttpRequestMessage req = GetCalendarsRequestGenerator.Generate(accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            List<Calendar> calendars = JObject.Parse(content)["items"].ToObject<List<Calendar>>();
            return calendars;
        }

        public async Task<Calendar> GetCalendar(string calendarId, string accessToken)
        {
            HttpRequestMessage req = GetCalendarRequestGenerator.Generate(calendarId, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content)["items"].ToObject<Calendar>();
        }
        
        public async Task<Calendar> CreateCalendarAsync(Calendar calendar, string accessToken)
        {
            HttpRequestMessage req = CreateCalendarRequestGenerator.Generate(calendar, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<Calendar>();
        }

        public async Task<Event> InsertEventAsync(Calendar calendar, Event googleEvent, string accessToken)
        {
            HttpRequestMessage request = InsertEventRequestGenerator.Generate(calendar, googleEvent, accessToken);
            HttpResponseMessage response = await _http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<Event>();
        }
    }
}