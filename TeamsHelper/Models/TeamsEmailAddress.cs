using Newtonsoft.Json;

namespace TeamsHelper
{
    public class TeamsEmailAddress
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}