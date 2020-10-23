using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class InsertEventPayload
    {
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("extendedProperties")]
        public ExtendedProperties ExtendedProperties { get; set; }
        
        [JsonProperty("end")]
        public GoogleTime End { get; set; }
        
        [JsonProperty("start")]
        public GoogleTime Start { get; set; }
    }
}