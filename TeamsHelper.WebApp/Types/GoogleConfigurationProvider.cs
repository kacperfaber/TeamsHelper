using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public class GoogleConfigurationProvider : IGoogleConfigurationProvider
    {
        public GoogleConfiguration Provide(IConfiguration configuration)
        {
            return configuration.GetSection("GoogleConfiguration").Get<GoogleConfiguration>();
        }
    }
}