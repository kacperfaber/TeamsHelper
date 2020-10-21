using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GooglePerson
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        [JsonProperty("self")]
        public bool Self { get; set; }
    }
}