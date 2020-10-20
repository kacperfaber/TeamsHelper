using System.Net.Http;

namespace TeamsHelper
{
    public interface IFormUrlEncodedContentGenerator
    {
        FormUrlEncodedContent Generate(string refreshToken, ClientCredentials credentials);
    }
}