using System;
using Newtonsoft.Json;

namespace TeamsHelper.CalendarApi
{
    public class GoogleTime
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}