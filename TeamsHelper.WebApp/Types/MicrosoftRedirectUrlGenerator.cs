using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class MicrosoftRedirectUrlGenerator : IMicrosoftRedirectUrlGenerator
    {
        public Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType)
        {
            return Task.Run(() => $"https://login.microsoftonline.com/466d5c5a-54d4-45fc-98eb-7877acf57f5f/oauth2/v2.0/authorize?client_id={authConfiguration.ClientId}&scope=offline_access%20{authConfiguration.Scopes}&response_type={responseType}");
        }
    }
}