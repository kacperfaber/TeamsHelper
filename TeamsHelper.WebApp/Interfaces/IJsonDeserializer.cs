namespace TeamsHelper.WebApp
{
    public interface IJsonDeserializer
    {
        T Deserialize<T>(string json);
    }
}