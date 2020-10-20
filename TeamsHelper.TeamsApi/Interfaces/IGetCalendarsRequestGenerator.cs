using System.Net.Http;

namespace TeamsHelper.TeamsApi
{
    public interface IGetCalendarsRequestGenerator
    {
        HttpRequestMessage Generate(string accessToken);
    }
}