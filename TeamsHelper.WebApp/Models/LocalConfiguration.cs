using Newtonsoft.Json;

namespace TeamsHelper
{
    public class LocalConfiguration
    {
        [JsonProperty("microsoft")]
        public string MicrosoftRefreshToken { get; set; }
        
        [JsonProperty("google")]
        public string GoogleRefreshToken { get; set; }
        
        [JsonProperty("googleClient")]
        public ClientCredentials GoogleClient { get; set; }
        
        [JsonProperty("microsoftClient")]
        public ClientCredentials MicrosoftClient { get; set; }
    }
}