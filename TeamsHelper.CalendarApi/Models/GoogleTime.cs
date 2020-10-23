using System;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GoogleTime
    {
        [JsonProperty("dateTime")]
        public DateTime? DateTime { get; set; }
        
        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }
}