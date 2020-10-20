using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TeamsHelper.TeamsApi
{
    public class TeamsApi
    {
        public IGetEventsRequestGenerator GetEventsRequestGenerator;
        public IGetCalendarsRequestGenerator GetCalendarsRequestGenerator;
        
        public IHttpClient HttpClient;

        public TeamsApi(IGetEventsRequestGenerator getEventsRequestGenerator, IHttpClient httpClient, IGetCalendarsRequestGenerator getCalendarsRequestGenerator)
        {
            GetEventsRequestGenerator = getEventsRequestGenerator;
            HttpClient = httpClient;
            GetCalendarsRequestGenerator = getCalendarsRequestGenerator;
        }

        public async Task<List<TeamsEvent>> GetEventsAsync(TeamsCalendar teamsCalendar, DateTime startingAt, DateTime endingAt, string accessToken)
        {
            HttpRequestMessage request = GetEventsRequestGenerator.Generate(teamsCalendar, startingAt, endingAt, accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            JObject jobject = JObject.Parse(json);
            return jobject["value"].ToObject<List<TeamsEvent>>();
        }

        public async Task<List<TeamsCalendar>> GetCalendarsAsync(string accessToken)
        {
            HttpRequestMessage request = GetCalendarsRequestGenerator.Generate(accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            JObject jobject = JObject.Parse(json);
            return jobject["value"].ToObject<List<TeamsCalendar>>();
        }
    }
}