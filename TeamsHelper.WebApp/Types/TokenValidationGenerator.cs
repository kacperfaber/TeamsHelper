using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class TokenValidationGenerator : ITokenValidationGenerator
    {
        public ITokenIdentityGenerator TokenIdentityGenerator;

        public TokenValidationGenerator(ITokenIdentityGenerator tokenIdentityGenerator)
        {
            TokenIdentityGenerator = tokenIdentityGenerator;
        }

        public async Task<TokenValidation> GenerateAsync(OAuthConfiguration authConfiguration, HttpResponseMessage response)
        {
            TokenValidation validation = new TokenValidation
            {
                Success = response.IsSuccessStatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                validation.Identity = await TokenIdentityGenerator.GenerateAsync(authConfiguration, response.Content.ReadAsStringAsync().Result);
                return validation;
            }

            return validation;
        }
    }
}