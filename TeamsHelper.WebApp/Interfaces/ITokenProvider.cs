using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface ITokenProvider
    {
        Task<Token> ProvideAsync(string code, OAuthConfiguration authConfiguration);
    }
}