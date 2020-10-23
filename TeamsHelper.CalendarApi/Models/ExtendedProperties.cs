using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class ExtendedProperties
    {
        [JsonProperty("private")]
        public Dictionary<string, string> Private { get; set; } = new Dictionary<string, string>();
        
        [JsonProperty("shared")]
        public Dictionary<string, string> Shared { get; set; } = new Dictionary<string, string>();
    }
}