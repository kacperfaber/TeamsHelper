using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class TokenContentGenerator : ITokenContentGenerator
    {
        public IFormUrlGenerator FormUrlGenerator;

        public TokenContentGenerator(IFormUrlGenerator formUrlGenerator)
        {
            FormUrlGenerator = formUrlGenerator;
        }

        public Task<FormUrlEncodedContent> GenerateAsync(string code, OAuthConfiguration configuration)
        {
            return FormUrlGenerator.GenerateAsync("code", code, "authorization_code", configuration.RedirectUrl, configuration.ClientId,
                configuration.ClientSecret, configuration.CodeVerifier);
        }
    }
}