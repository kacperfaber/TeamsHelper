using Newtonsoft.Json;

namespace TeamsHelper.WebApp
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}