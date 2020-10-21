using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IGoogleTokenProvider
    {
        Task<Token> ProvideAsync(string code, OAuthConfiguration authConfiguration);
    }
}