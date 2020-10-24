using System;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GoogleEvent
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
        public DateTime? Created { get; set; }
        
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("creator")]
        public GooglePerson Creator { get; set; }
        
        [JsonProperty("start")]
        public GoogleTime Start { get; set; }
        
        [JsonProperty("end")]
        public GoogleTime End { get; set; }
        
        [JsonProperty("transparency")]
        public string Transparency { get; set; }
        
        [JsonProperty("extendedProperties")]
        public ExtendedProperties ExtendedProperties { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("reminders")]
        public GoogleEventReminders Reminders { get; set; }
    }
}