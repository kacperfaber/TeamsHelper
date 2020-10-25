using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public class ServiceConfigurationProvider : IServiceConfigurationProvider
    {
        public ServiceConfiguration Provide(IConfiguration configuration)
        {
            return configuration.GetSection("ServiceConfiguration").Get<ServiceConfiguration>();
        }
    }
}