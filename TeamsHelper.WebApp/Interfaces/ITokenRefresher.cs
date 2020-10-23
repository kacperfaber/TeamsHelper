using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface ITokenRefresher
    {
        Task<Token> RefreshAsync(Authorization authorization, OAuthConfiguration configuration);
    }
}