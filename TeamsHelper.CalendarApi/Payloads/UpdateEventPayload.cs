using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class UpdateEventPayload
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

        [JsonProperty("reminders")]
        public GoogleEventReminders Reminders { get; set; }

        [JsonProperty("colorId")]
        public string ColorId { get; set; }
    }
}