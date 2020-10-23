using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        }
    }
}