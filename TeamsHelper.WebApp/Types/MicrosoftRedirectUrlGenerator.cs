using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class MicrosoftRedirectUrlGenerator : IMicrosoftRedirectUrlGenerator
    {
        public Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType)
        {
            return Task.Run(() => $"https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id={authConfiguration.ClientId}&scope=offline_access%20{authConfiguration.Scopes}&response_type={responseType}&redirect_uri={authConfiguration.RedirectUrl}&code_challenge={authConfiguration.CodeChallenge}&code_challenge_method={authConfiguration.CodeChallengeMethod}");
        }
    }
}