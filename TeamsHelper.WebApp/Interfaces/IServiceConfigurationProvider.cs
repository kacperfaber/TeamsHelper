using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public interface IServiceConfigurationProvider
    {
        ServiceConfiguration Provide(IConfiguration configuration);
    }
}