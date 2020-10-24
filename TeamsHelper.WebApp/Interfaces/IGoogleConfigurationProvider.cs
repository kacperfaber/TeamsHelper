using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public interface IGoogleConfigurationProvider
    {
        GoogleConfiguration Provide(IConfiguration configuration);
    }
}