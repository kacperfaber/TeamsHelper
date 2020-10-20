using System;
using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsTime
    {
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
        
        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }
}