namespace TeamsHelper.WebApp
{
    public interface IOAuthConfigurationSectionNameGenerator
    {
        string Generate(string oauthProviderName);
    }
}