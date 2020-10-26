using System.Net;
using Newtonsoft.Json;

namespace TeamsHelper.WebApp
{
    public class Token
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        
        [JsonProperty("response")]
        public string ResponseBody { get; set; }
        
        [JsonProperty("code")]
        public HttpStatusCode Code { get; set; }
    }
}