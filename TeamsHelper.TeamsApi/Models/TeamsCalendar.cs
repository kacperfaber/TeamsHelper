using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class TeamsCalendar
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("color")]
        public string Color { get; set; }
        
        [JsonProperty("hexColor")]
        public string HexColor { get; set; }
        
        [JsonProperty("changeKey")]
        public string ChangeKey { get; set; }
        
        [JsonProperty("canShare")]
        public bool CanShare { get; set; }
        
        [JsonProperty("canViewPrivateItems")]
        public bool CanViewPrivateItems { get; set; }
        
        [JsonProperty("canEdit")]
        public bool CanEdit { get; set; }
        
        [JsonProperty("defaultOnlineMeetingProvider")]
        public string DefaultOnlineMeetingProvider { get; set; }
        
        [JsonProperty("isRemovable")]
        public bool IsRemovable { get; set; }
        
        [JsonProperty("owner")]
        public TeamsEmailAddress Owner { get; set; }
    }
}