using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class AccessTokenValidator : IAccessTokenValidator
    {
        public IIdentityRequestGenerator IdentityRequestGenerator;
        public ITokenValidationGenerator TokenValidationGenerator;
        public IHttpClient Http;

        public AccessTokenValidator(IIdentityRequestGenerator identityRequestGenerator, ITokenValidationGenerator tokenValidationGenerator, IHttpClient http)
        {
            IdentityRequestGenerator = identityRequestGenerator;
            TokenValidationGenerator = tokenValidationGenerator;
            Http = http;
        }

        public async Task<TokenValidation> ValidateAsync(Token token, OAuthConfiguration authConfiguration)
        {
            HttpRequestMessage request = IdentityRequestGenerator.Generate(token.AccessToken, authConfiguration);
            HttpResponseMessage response = await Http.SendAsync(request);

            return await TokenValidationGenerator.GenerateAsync(authConfiguration, response);
        }
    }
}