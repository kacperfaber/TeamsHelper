using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsEventOrganizer
    {
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}