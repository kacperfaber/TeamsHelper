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
        public ICreateCalendarRequestGenerator CreateCalendarRequestGenerator;
        
        readonly HttpClient _http = new HttpClient();

        public GoogleApi(IGetCalendarsRequestGenerator getCalendarsRequestGenerator, ICreateCalendarRequestGenerator createCalendarRequestGenerator)
        {
            GetCalendarsRequestGenerator = getCalendarsRequestGenerator;
            CreateCalendarRequestGenerator = createCalendarRequestGenerator;
        }

        public async Task<List<Calendar>> GetCalendarsAsync(string accessToken)
        {
            HttpRequestMessage req = GetCalendarsRequestGenerator.Generate(accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            List<Calendar> calendars = JObject.Parse(content)["items"].ToObject<List<Calendar>>();
            return calendars;
        }

        public async Task<Calendar> CreateCalendarAsync(Calendar calendar, string accessToken)
        {
            HttpRequestMessage req = CreateCalendarRequestGenerator.Generate(calendar, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<Calendar>();
        }
    }
}