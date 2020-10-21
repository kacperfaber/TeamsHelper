namespace TeamsHelper.WebApp
{
    public class OAuthConfigurationSectionNameGenerator : IOAuthConfigurationSectionNameGenerator
    {
        public string Generate(string oauthProviderName)
        {
            return $"OAuth:Configuration:{oauthProviderName}";
        }
    }
}