using System.Net.Http;

namespace TeamsHelper.WebApp
{
    public interface IIdentityRequestMethodProvider
    {
        HttpMethod Provide(OAuthConfiguration authConfiguration);
    }
}