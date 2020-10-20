using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsEventBody
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}