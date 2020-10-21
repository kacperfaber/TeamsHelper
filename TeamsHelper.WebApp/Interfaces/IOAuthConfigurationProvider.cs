using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public interface IOAuthConfigurationProvider
    {
        OAuthConfiguration Provide(IConfiguration configuration, string oauthProviderName);
    }
}