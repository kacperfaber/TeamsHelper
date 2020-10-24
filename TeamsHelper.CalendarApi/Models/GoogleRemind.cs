using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GoogleRemind
    {
        [JsonProperty("method")]
        public string Method { get; set; }
        
        [JsonProperty("minutes")]
        public int Minutes { get; set; }
    }
}