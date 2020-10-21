using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class MicrosoftRedirectUrlGenerator : IMicrosoftRedirectUrlGenerator
    {
        public Task<string> GenerateAsync(string clientId, string redirectUrl, string scopes, string state, string responseType)
        {
            return Task.Run(() => $"https://login.microsoftonline.com/466d5c5a-54d4-45fc-98eb-7877acf57f5f/oauth2/v2.0/authorize?client_id={clientId}&scope=offline_access%20{scopes}&response_type={responseType}");
        }
    }
}