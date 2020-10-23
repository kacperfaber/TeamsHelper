using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsEventOrganizer
    {
        [JsonProperty("emailAddress")]
        public TeamsEmailAddress EmailAddress { get; set; }
    }
}