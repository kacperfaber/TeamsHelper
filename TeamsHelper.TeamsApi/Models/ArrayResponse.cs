using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsHelper.TeamsApi
{
    public class ArrayResponse <T>
    {
        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}