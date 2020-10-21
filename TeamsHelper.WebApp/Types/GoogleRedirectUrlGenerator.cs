using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class GoogleRedirectUrlGenerator : IGoogleRedirectUrlGenerator
    {
        public Task<string> GenerateAsync(string clientId, string redirectUrl, string scopes, string responseType)
        {
            return Task.Run(() => $"https://accounts.google.com/o/oauth2/v2/auth?redirect_uri={redirectUrl}&scope={scopes}&client_id={clientId}&response_type={responseType}&access_type=offline");
        }
    }
}