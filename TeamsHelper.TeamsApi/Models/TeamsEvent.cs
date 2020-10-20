using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsEvent
    {
        [JsonProperty("@odata.etag")]
        public string ETag { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("body")]
        public TeamsEventBody Body { get; set; }
        
        [JsonProperty("start")]
        public TeamsTime Start { get; set; }
        
        [JsonProperty("end")]
        public TeamsTime End { get; set; }
        
        [JsonProperty("organizer")]
        public TeamsEventOrganizer TeamsOrganizer { get; set; }
    }
}