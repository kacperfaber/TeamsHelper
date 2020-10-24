using System.Net.Http;

namespace TeamsHelper.WebApp
{
    public interface IIdentityRequestGenerator
    {
        HttpRequestMessage Generate(string accessToken, OAuthConfiguration authConfiguration);
    }
}