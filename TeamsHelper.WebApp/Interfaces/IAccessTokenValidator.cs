using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IAccessTokenValidator
    {
        Task<TokenValidation> ValidateAsync(Token token, OAuthConfiguration authConfiguration);
    }
}