using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class Calendar
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        
        [JsonProperty("etag")]
        public string ETag { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
        
        [JsonProperty("summaryOverride")]
        public string SummaryOverride { get; set; }
        
        [JsonProperty("colorId")]
        public string ColorId { get; set; }
        
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }
        
        [JsonProperty("foregroundColor")]
        public string ForegroundColor { get; set; }
        
        [JsonProperty("selected")]
        public bool Selected { get; set; }
        
        [JsonProperty("accessRole")]
        public string AccessRole { get; set; }
    }
}