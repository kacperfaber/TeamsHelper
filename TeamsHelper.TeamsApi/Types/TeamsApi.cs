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
        
        public IHttpClient HttpClient;

        public TeamsApi(IGetEventsRequestGenerator getEventsRequestGenerator, IHttpClient httpClient)
        {
            GetEventsRequestGenerator = getEventsRequestGenerator;
            HttpClient = httpClient;
        }

        public async Task<List<TeamsEvent>> GetEventsAsync(TeamsCalendar teamsCalendar, DateTime startingAt, DateTime endingAt, string accessToken)
        {
            HttpRequestMessage request = GetEventsRequestGenerator.Generate(teamsCalendar, startingAt, endingAt, accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            JObject jobject = JObject.Parse(json);
            return jobject["value"].ToObject<List<TeamsEvent>>();
        }

        
    }
}