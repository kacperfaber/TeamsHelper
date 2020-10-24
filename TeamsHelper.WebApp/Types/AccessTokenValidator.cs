using System;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class AccessTokenValidator : IAccessTokenValidator
    {
        public Task<TokenValidation> ValidateAsync(Token token, OAuthConfiguration authConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}