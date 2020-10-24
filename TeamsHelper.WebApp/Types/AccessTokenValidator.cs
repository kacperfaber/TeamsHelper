using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class AccessTokenValidator : IAccessTokenValidator
    {
        readonly HttpClient _http = new HttpClient();
        public IIdentityRequestGenerator IdentityRequestGenerator;
        public ITokenValidationGenerator TokenValidationGenerator;

        public AccessTokenValidator(IIdentityRequestGenerator identityRequestGenerator, ITokenValidationGenerator tokenValidationGenerator)
        {
            IdentityRequestGenerator = identityRequestGenerator;
            TokenValidationGenerator = tokenValidationGenerator;
        }

        public async Task<TokenValidation> ValidateAsync(Token token, OAuthConfiguration authConfiguration)
        {
            HttpRequestMessage request = IdentityRequestGenerator.Generate(token.AccessToken, authConfiguration);
            HttpResponseMessage response = await _http.SendAsync(request);

            return await TokenValidationGenerator.GenerateAsync(authConfiguration, response);
        }
    }
}