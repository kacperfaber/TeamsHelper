using Microsoft.Extensions.Configuration;

namespace TeamsHelper.WebApp
{
    public class OAuthConfigurationProvider : IOAuthConfigurationProvider
    {
        public IOAuthConfigurationSectionNameGenerator SectionNameGenerator;

        public OAuthConfigurationProvider(IOAuthConfigurationSectionNameGenerator sectionNameGenerator)
        {
            SectionNameGenerator = sectionNameGenerator;
        }

        public OAuthConfiguration Provide(IConfiguration configuration, string oauthProviderName)
        {
            return configuration.GetSection(SectionNameGenerator.Generate(oauthProviderName))
                .Get<OAuthConfiguration>();
        }
    }
}