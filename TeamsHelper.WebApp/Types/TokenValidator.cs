using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class TokenValidator : ITokenValidator
    {
        public Task<bool> ValidateAsync(Token token)
        {
            return Task.Run(() =>
                !string.IsNullOrEmpty(token.AccessToken) && string.IsNullOrEmpty(token.RefreshToken) && string.Equals(token.TokenType, "Bearer"));
        }
    }
}