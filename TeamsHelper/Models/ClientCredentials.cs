using Newtonsoft.Json;

namespace TeamsHelper
{
    public class ClientCredentials
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }
    }
}