using System;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class Event
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        
        [JsonProperty("etag")]
        public string ETag { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("status")]
        public string Confirmed { get; set; }
        
        [JsonProperty("htmlLink")]
        public string HtmlLink { get; set; }
        
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("creator")]
        public Person Creator { get; set; }
        
        [JsonProperty("start")]
        public GoogleTime Start { get; set; }
        
        [JsonProperty("end")]
        public GoogleTime End { get; set; }
        
        [JsonProperty("transparency")]
        public string Transparency { get; set; }
    }
}