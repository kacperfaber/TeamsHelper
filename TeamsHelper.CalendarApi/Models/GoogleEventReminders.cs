using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GoogleEventReminders
    {
        [JsonProperty("useDefault")]
        public bool UseDefault { get; set; }
        
        [JsonProperty("overrides")]
        public List<GoogleRemind> Reminds { get; set; }
    }
}